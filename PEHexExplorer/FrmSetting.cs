using System.Windows.Forms;
using System.Drawing;

namespace PEHexExplorer
{
    public partial class FrmSetting : Form
    {

        private static FrmSetting frmSetting=null;

        public static FrmSetting Instance
        {
            get
            {
                if (frmSetting == null || frmSetting.IsDisposed)
                {
                    frmSetting = new FrmSetting();
                }
                return frmSetting;
            }
        }

        public FrmSetting()
        {
            InitializeComponent();
        }

       
    }
}