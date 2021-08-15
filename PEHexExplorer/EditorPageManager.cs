using System;
using Be.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace PEHexExplorer
{
    public class EditorPageManager
    {

        public event EventHandler<EditorPageEventArgs> EditorPageChanged;
        public event EventHandler<EditPage.EditorPageMessageArgs> EditorPageMessagePipe;
        public event EventHandler<EditPage.CloseFileArgs> EditorPageClosing;

        private readonly List<string> OpenFilenames;
        readonly ContextMenuStrip MenuStrip;
        private readonly EditPage.EditorPageMessageArgs quitMessage 
            = new EditPage.EditorPageMessageArgs { EditorMessageType = EditPage.EditorMessageType.Quit };

        public EditPage CurrentPage => _tabControl.SelectedTab as EditPage;
        public HexBox CurrentHexBox => (_tabControl.SelectedTab as EditPage).HexBox;

        public struct EditorPageData
        {
            public bool EditEnabled;

        }

        public class EditorPageEventArgs : EventArgs
        {
            public EditorPageData EditorPageData { get; set; }

            public override string ToString()
            {
                return "EditorPageEventArgs";
            }
        }

        private readonly TabControl _tabControl;

        public EditorPageManager(TabControlEx tabControl, ContextMenuStrip menuStrip = null)
        {
            _tabControl = tabControl ?? throw new ArgumentNullException("TabControl");
            MenuStrip = menuStrip;
            tabControl.Padding = new Point(12, 3);
            tabControl.AllowDrop = true;
            tabControl.Appearance = TabAppearance.Normal;
            tabControl.ControlAdded += TabControl_ControlAdded;
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            tabControl.OnClosingPage += TabControl_OnClosingPage;
            tabControl.ControlRemoved += TabControl_ControlRemoved;
            tabControl.GotFocus += TabControl_GotFocus;
            
            OpenFilenames = new List<string>();
        }

        private void TabControl_OnClosingPage(object sender, TabControlEx.ClosingPageArgs e)
        {
            e.Cancel = true;
            ClosePage(sender as EditPage);
        }

        ~EditorPageManager()
        {
            OpenFilenames.Clear();
            _tabControl.ControlAdded -= TabControl_ControlAdded;
            _tabControl.SelectedIndexChanged -= TabControl_SelectedIndexChanged;
            _tabControl.ControlRemoved -= TabControl_ControlRemoved;
            _tabControl.GotFocus -= TabControl_GotFocus;
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPage?.PostWholeMessage();
        }

        private void TabControl_GotFocus(object sender, EventArgs e)
        {
            _tabControl.SelectedTab?.Focus();   //去虚框
        }

        private void TabControl_ControlRemoved(object sender, ControlEventArgs e)
        {
            EditorPageEventArgs args = new EditorPageEventArgs
            {
                EditorPageData = new EditorPageData { EditEnabled = _tabControl.TabCount > 1 }      //虽然被删除了，但这个数在这一时刻还没改
            };
            EditorPageChanged?.Invoke(sender, args);
        }

        private void TabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.Focus();
            EditorPageEventArgs args = new EditorPageEventArgs
            {
                EditorPageData = new EditorPageData { EditEnabled = _tabControl.TabCount > 0 }
            };
            EditorPageChanged?.Invoke(sender, args);
        }

        public void OpenOrCreateFilePage(string filename = null, bool writeable = true)
        {
            try
            {
                EditPage page = new EditPage { UseVisualStyleBackColor = false };
                if (filename == null)
                {
                    page.NewFile();
                }
                else
                {
                    if (OpenFilenames.Contains(filename))
                    {
                        foreach (EditPage item in _tabControl.TabPages)
                        {
                            if (string.Compare(item.Filename, filename, true) == 0)
                            {
                                _tabControl.SelectedTab = item;
                                page.Dispose();
                                return;
                            }
                        }
                    }
                    page.OpenFile(filename, writeable);
                    OpenFilenames.Add(filename);
                }
                _tabControl.TabPages.Add(page);
                _tabControl.SelectedTab = page;
                page.ApplyContextMenuStrip(MenuStrip);
                page.HostMessagePipe += Page_HostMessagePipe;
                page.ClosingFile += Page_ClosingFile;

                page.PostWholeMessage();
            }
            catch
            {
                throw;
            }

        }

        private void Page_ClosingFile(object sender, EditPage.CloseFileArgs e)
        {
            if (EditorPageClosing==null)
            {
                throw new NullReferenceException("必要事件未接入");
            }
            _tabControl.SelectedTab = (TabPage)sender;
            EditorPageClosing.Invoke(sender, e);
        }

        public void OpenProcessPage()
        {
            EditPage page = new EditPage { UseVisualStyleBackColor = false };
            if (page.OpenProcess())
            {
                _tabControl.TabPages.Add(page);
                _tabControl.SelectedTab = page;
                page.ApplyContextMenuStrip(MenuStrip);
                page.HostMessagePipe += Page_HostMessagePipe;
                page.ClosingFile += Page_ClosingFile;

                page.PostWholeMessage();
            }
        }

        /// <summary>
        /// 将合适的消息传递到宿主
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_HostMessagePipe(object sender, EditPage.EditorPageMessageArgs e)
        {
            if (sender== CurrentPage)
            {
                EditorPageMessagePipe?.Invoke(sender, e);
            }
        }

        public void ClosePage(EditPage page)
        {
            bool res = page.CloseFile();
            if (res)
            {
                EditorPageMessagePipe?.Invoke(page,quitMessage);

                page.HostMessagePipe -= Page_HostMessagePipe;
                page.ClosingFile -= Page_ClosingFile;
                _tabControl.TabPages.Remove(page);
                page.Dispose();
            }
        }

        public void CloseCurrentPage() => ClosePage(_tabControl.SelectedTab as EditPage);

        public void CloseAllPage()
        {
            List<EditPage> editPages = new List<EditPage>();
            foreach (EditPage item in _tabControl.TabPages)
            {
                editPages.Add(item);
            }
            foreach (var item in editPages)
            {
                ClosePage(item);
            }
            editPages.Clear();
        }

    }
}
