using System;
using System.Windows.Forms;

namespace PEHexExplorer
{
    public partial class FrmGoto : Form
    {
        private static FrmGoto frmGoto;

        public struct GotoResult
        {
            public bool IsRow;
            public decimal Number;
            public bool IsFromBase;
        }

        public static FrmGoto Instance
        {
            get
            {
                if (frmGoto == null || frmGoto.IsDisposed)
                {
                    frmGoto = new FrmGoto();
                }
                return frmGoto;
            }
        }

        public GotoResult Result { get; private set; }

        public FrmGoto()
        {
            InitializeComponent();
        }

        private void rbGotoGroup_CheckedChanged(object sender, EventArgs e)
        {
            bool canoffset = rbOffset.Checked;
            ntOffset.Enabled = canoffset;
            ntRow.Enabled = !canoffset;
            gbOffset.Enabled = canoffset;
        }

        private void btnJmp_Click(object sender, EventArgs e)
        {
            Result = new GotoResult()
            {
                IsRow = rbRow.Checked,
                Number = rbRow.Checked ? ntRow.Value : ntOffset.Value,
                IsFromBase = rbOffset.Checked
            };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cbHex_CheckedChanged(object sender, EventArgs e)
        {
            bool ishex = cbHex.Checked;
            ntRow.Hexadecimal = ishex;
            ntOffset.Hexadecimal = ishex;
        }

        private void FrmGoto_VisibleChanged(object sender, EventArgs e)
        {
            ntOffset.Value = 0;
            ntRow.Value = 0;
        }
    }
}