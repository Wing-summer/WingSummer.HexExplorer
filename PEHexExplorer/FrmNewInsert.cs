using System;
using System.Windows.Forms;

namespace PEHexExplorer
{
    public partial class FrmNewInsert : Form
    {
        private static FrmNewInsert newInsert;

        public static FrmNewInsert Instance
        {
            get
            {
                if (newInsert == null || newInsert.IsDisposed )
                {
                    newInsert = new FrmNewInsert();
                }
                return newInsert;
            }
        }

        public struct NewInsertResult
        {
            public decimal Base;
            public decimal Value;
        }

        public NewInsertResult Result
        {
            get;private set;
        }

        public FrmNewInsert()
        {
            InitializeComponent();
        }

        private void cbHex_CheckedChanged(object sender, EventArgs e)
        {
            bool ishex = cbHex.Checked;
            ntOffset.Hexadecimal = ishex;
            ntValue.Hexadecimal = ishex;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Result = new NewInsertResult
            {
                Base = ntOffset.Value,
                Value = ntValue.Value
            };
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
