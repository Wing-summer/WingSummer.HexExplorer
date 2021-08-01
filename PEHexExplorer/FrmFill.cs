using System.Windows.Forms;
using System;
using Be.Windows.Forms;


namespace PEHexExplorer
{
    public partial class FrmFill : Form
    {
        private static FrmFill frmFill=null;

        public static FrmFill Instance
        {
            get
            {
                if (frmFill == null)
                {
                    frmFill = new FrmFill();
                }
                return frmFill;
            }
        }

        public static FillResult Result
        {
            get;private set;
        }

        public struct FillResult
        {
            public byte[] buffer;
        }   

        public FrmFill()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            IByteProvider byteProvider = hexBoxFill.ByteProvider;
            byte[] buffer = new byte[byteProvider.Length];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = byteProvider.ReadByte(i);
            }
            Result = new FillResult { buffer = buffer };
        }

        private void FrmFill_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                hexBoxFill.OpenFile();
            }
            else
            {
                hexBoxFill.CloseFile(false);
            }
        }
    }
}