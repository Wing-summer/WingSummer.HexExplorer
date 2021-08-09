using System.Windows.Forms;

namespace PEHexExplorer
{
    public partial class FrmAbout : ToolWindowBase
    {
        private static FrmAbout frmAbout = null;

        public FrmAbout()
        {
            InitializeComponent();
        }

        public static FrmAbout Instance
        {
            get
            {
                if (frmAbout == null || frmAbout.IsDisposed)
                {
                    frmAbout = new FrmAbout();
                }
                return frmAbout;
            }
        }
    }
}