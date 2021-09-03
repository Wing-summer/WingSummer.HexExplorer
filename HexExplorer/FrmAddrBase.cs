using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HexExplorer
{
    public partial class FrmAddrBase : ToolWindowBase
    {
        private static FrmAddrBase addrBase;
        public static FrmAddrBase Instance
        {
            get
            {
                if (addrBase==null||addrBase.IsDisposed)
                {
                    addrBase = new FrmAddrBase();
                }
                return addrBase;
            }
        }

        public long Result { get; set; }

        private FrmAddrBase()
        {
            InitializeComponent();
            nAddr.Maximum = decimal.MaxValue;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Result = (long)nAddr.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
