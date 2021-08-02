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

        private void lbSetting_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            StringFormat stringFormat = new StringFormat(StringFormatFlags.NoClip);
            stringFormat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString( lbSetting.Items[e.Index].ToString(), e.Font,  new SolidBrush(e.ForeColor), e.Bounds, stringFormat);
        }

        private void lbSetting_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)(e.Graphics.MeasureString(lbSetting.Items[e.Index].ToString(),Font).Height + 2);
        }
    }
}