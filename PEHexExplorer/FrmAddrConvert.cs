using System;
using System.ComponentModel;
using System.Windows.Forms;
using PEProcesser;

namespace PEHexExplorer
{
    public partial class FrmAddrConvert : Form
    {

        public static FrmAddrConvert frmAddrConvert;

        public static FrmAddrConvert Instance
        {
            get
            {
                if (frmAddrConvert != null && frmAddrConvert.IsDisposed)
                {
                    frmAddrConvert = new FrmAddrConvert();
                }
                return frmAddrConvert;
            }
        }

        [DefaultValue(null)]
        public PEPParser PEPParser { get; set; }

        public FrmAddrConvert()
        {
            InitializeComponent();
        }

        private void ntOffset_ValueChanged(object sender, EventArgs e)
        {
            if (PEPParser!=null)
            {
                ntValue.Value = (decimal)PEPParser.FOA2RVA((ulong)ntOffset.Value);
            }
        }

        private void ntValue_ValueChanged(object sender, EventArgs e)
        {
            if (PEPParser != null)
            {
                ntOffset.Value = (decimal)PEPParser.RVA2FOA((ulong)ntOffset.Value);
            }
        }

        private void FrmAddrConvert_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (PEPParser!=null)
                {
                    ntOffset.Enabled = true;
                    ntValue.Enabled = true;
                }
                else
                {
                    ntOffset.Enabled = false;
                    ntValue.Enabled = false;
                }
            }
        }

    }
}
