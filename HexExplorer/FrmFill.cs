﻿using System.Windows.Forms;
using System;
using Be.Windows.Forms;


namespace HexExplorer
{
    public partial class FrmFill : ToolWindowBase
    {
        private static FrmFill frmFill=null;

        public static FrmFill Instance
        {
            get
            {
                if (frmFill == null || frmFill.IsDisposed)
                {
                    frmFill = new FrmFill();
                }
                return frmFill;
            }
        }

        public FillResult Result
        {
            get;private set;
        }

        public long Limit { get; set; }

        public struct FillResult
        {
            public byte[] buffer;
        }   

        private FrmFill()
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
            Result = new FillResult() { buffer = buffer };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FrmFill_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                hexBoxFill.CreateBuffer(true,Limit);
            }
            else
            {
                Limit = 0;
                hexBoxFill.Close();
            }
        }
    }
}