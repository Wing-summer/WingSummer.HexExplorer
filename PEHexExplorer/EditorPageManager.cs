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
        private List<string> OpenFilenames;

        ContextMenuStrip MenuStrip;

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

        public EditorPageManager(TabControl tabControl, ContextMenuStrip menuStrip = null)
        {
            _tabControl = tabControl ?? throw new ArgumentNullException("TabControl");
            MenuStrip = menuStrip;
            tabControl.Padding = new Point(12, 3);
            tabControl.Appearance = TabAppearance.Normal;
            tabControl.DrawItem += TabControl_DrawItem;
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.ControlAdded += TabControl_ControlAdded;
            tabControl.MouseDown += TabControl_MouseDown;
            tabControl.ControlRemoved += TabControl_ControlRemoved;
            tabControl.GotFocus += TabControl_GotFocus;
            OpenFilenames = new List<string>();
        }

        private void TabControl_GotFocus(object sender, EventArgs e)
        {
            _tabControl.SelectedTab?.Focus();   //去虚框
        }

        private void TabControl_MouseDown(object sender, MouseEventArgs e)
        {
            EditPage page=null;
            foreach (EditPage item in _tabControl.TabPages)
            {
                Rectangle rec = (Rectangle)item.Tag;
                if (rec.Contains(e.Location))
                {
                    page = item;
                    break;
                }
            }
            if (page!=null)
                ClosePage(page);

        }

        private const int CloseButtonSize= 12;

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
           
                var tabPage = _tabControl.TabPages[e.Index];            
                var tabRect = _tabControl.GetTabRect(e.Index);
                tabRect.Inflate(-2, -2);

                Rectangle CloseButtonRec = new Rectangle(tabRect.Right - CloseButtonSize - 2,
                      tabRect.Top + (tabRect.Height - CloseButtonSize) / 2, CloseButtonSize, CloseButtonSize);

                    e.Graphics.DrawImage(Properties.Resources.close, CloseButtonRec);

                tabPage.Tag = CloseButtonRec;

                TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font, tabRect,
                    e.State == DrawItemState.Selected ? Color.White : tabPage.ForeColor, TextFormatFlags.Left);

            }
            catch
            {
            }

        }

        private void TabControl_ControlRemoved(object sender, ControlEventArgs e)
        {
            EditorPageEventArgs args = new EditorPageEventArgs
            {
                EditorPageData = new EditorPageData { EditEnabled = _tabControl.TabCount > 1 }      //虽然被删除了，但这个数还没改
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
            EditPage page = new EditPage();
            if (filename==null)
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
        }

        public void OpenProcessPage()
        {
            EditPage page = new EditPage { ContextMenuStrip = MenuStrip };
            page.OpenProcess();
            _tabControl.TabPages.Add(page);
            _tabControl.SelectedTab = page;
            page.ApplyContextMenuStrip(MenuStrip);
            page.HostMessagePipe += Page_HostMessagePipe;
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
            page.HostMessagePipe -= Page_HostMessagePipe;
            _tabControl.TabPages.Remove(page);
            page.Dispose();
        }

        public void CloseCurrentPage() => ClosePage(_tabControl.SelectedTab as EditPage);

    }
}
