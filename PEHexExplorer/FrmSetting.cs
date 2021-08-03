using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

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

        [DefaultValue(false)]
        public bool IsPluginShow { get; set; }

        public FrmSetting()
        {
            InitializeComponent();
        }

        private void FrmSetting_VisibleChanged(object sender, System.EventArgs e)
        {
            if (Visible)
            {
                if (IsPluginShow)
                {
                    tabSetting.SelectedIndex = 3;
                    IsPluginShow = false;
                }
                else
                {
                    tabSetting.SelectedIndex = 0;
                }
            }
        }
    }
}