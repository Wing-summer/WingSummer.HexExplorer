using System;
using Be.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEHexExplorer
{
    public class EditorPageManager
    {

        public event EventHandler<EditorPageEventArgs> EditorPageChanged;
        public event EventHandler<EditorPageEventArgs> EditorPageMessagePipe;

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

        public EditorPageManager(TabControl tabControl)
        {
            _tabControl = tabControl ?? throw new ArgumentNullException("TabControl");
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditorPageEventArgs args = new EditorPageEventArgs
            {
                EditorPageData = new EditorPageData { EditEnabled = true }
            };
            EditorPageChanged?.Invoke(sender, args);
        }

        public void NewPage(string filename = null, bool writeable = true)
        {
            EditPage page = new EditPage();
            if (filename==null)
            {
                page.NewFile();
            }
            else
            {
                page.OpenFile(filename, writeable);
            }
            _tabControl.TabPages.Add(page);
            _tabControl.SelectedTab = page;
            page.HostMessagePipe += Page_HostMessagePipe;
        }

        private void Page_HostMessagePipe(object sender, EventArgs e)
        {
            if (sender== CurrentPage)
            {
                EditorPageEventArgs args = new EditorPageEventArgs
                {
                    EditorPageData = new EditorPageData { EditEnabled = true }
                };
                EditorPageMessagePipe?.Invoke(sender, args);
            }
        }

        public void DeletePage(int index)
        {

        }

    }
}
