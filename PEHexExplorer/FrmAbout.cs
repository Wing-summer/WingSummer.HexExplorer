using System.Windows.Forms;

namespace PEHexExplorer
{
    public partial class FrmAbout : Form
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
                if (frmAbout == null)
                {
                    frmAbout = new FrmAbout();
                }
                return frmAbout;
            }
        }
    }
}