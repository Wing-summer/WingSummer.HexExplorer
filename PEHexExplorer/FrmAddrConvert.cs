using System;
using System.ComponentModel;
using System.Windows.Forms;
using PEProcesser;

namespace PEHexExplorer
{
    public partial class FrmAddrConvert : ToolWindowBase
    {

        public static FrmAddrConvert frmAddrConvert=null;

        public static FrmAddrConvert Instance
        {
            get
            {
                if (frmAddrConvert == null || frmAddrConvert.IsDisposed)
                {
                    frmAddrConvert = new FrmAddrConvert();
                }
                return frmAddrConvert;
            }
        }

        [DefaultValue(null)]
        public PEPParser PEPParser { get; set; }

        private FrmAddrConvert()
        {
            InitializeComponent();
            ntBase.Maximum = Program.Int64Max;
            ntFOA.Maximum = Program.Int64Max;
            ntRVA.Maximum = Program.Int64Max;
            ntVA.Maximum = Program.Int64Max;
        }

        private void NtOffset_ValueChanged(object sender, EventArgs e)
        {
            if (PEPParser!=null)
            {
                ntRVA.Value = (decimal)PEPParser.FOA2RVA((ulong)ntFOA.Value);
            }
        }

        private void NtValue_ValueChanged(object sender, EventArgs e)
        {
            if (PEPParser != null)
            {
                ntFOA.Value = (decimal)PEPParser.RVA2FOA((ulong)ntFOA.Value);
            }
        }

        private void FrmAddrConvert_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (PEPParser!=null)
                {
                    ntFOA.Enabled = true;
                    ntRVA.Enabled = true;
                }
                else
                {
                    ntFOA.Enabled = false;
                    ntRVA.Enabled = false;
                }
            }
        }

        private void FrmAddrConvert_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}
