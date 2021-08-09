using Be.Windows.Forms;
using System;
using System.Windows.Forms;

namespace PEHexExplorer
{
    public partial class FrmInsert : ToolWindowBase
    {
        private static FrmInsert frmInsert;
        public static FrmInsert Instance
        {
            get
            {
                if (frmInsert == null || frmInsert.IsDisposed)
                {
                    frmInsert = new FrmInsert();
                }
                return frmInsert;
            }
        }

        public InsertResult Result
        {
            get; private set;
        }

        public struct InsertResult
        {
            public byte[] buffer;
        }


        public FrmInsert()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            IByteProvider byteProvider = hexBoxFill.ByteProvider;
            byte[] buffer = new byte[byteProvider.Length];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = byteProvider.ReadByte(i);
            }
            Result = new InsertResult() { buffer = buffer };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FrmFill_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                hexBoxFill.CreateBuffer(true);
            }
            else
            {
                hexBoxFill.Close();
            }
        }

    }
}
