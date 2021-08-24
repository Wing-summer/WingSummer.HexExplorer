using System.Drawing;
using System.Windows.Forms;
using Be.Windows.Forms;

namespace HexExplorer
{
    public partial class FrmPenFEdit : ToolWindowBase
    {
        private static FrmPenFEdit frmPenFEdit;
        private PenF OldpenF;
        
        public static FrmPenFEdit Instance
        {
            get
            {
                if (frmPenFEdit == null || frmPenFEdit.IsDisposed)
                {
                    frmPenFEdit = new FrmPenFEdit();
                }
                return frmPenFEdit;
            }
        }

        public PenF PenF { get; set; }

        private FrmPenFEdit()
        {
            InitializeComponent();          
        }

        private void FrmPenFEdit_Load(object sender, System.EventArgs e)
        {
            if (PenF == null)
            {
                DialogResult = DialogResult.None;
                Close();
            }
            OldpenF = PenF.Clone() as PenF;
            pg.SelectedObject = PenF;
        }

        private void Pg_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.Label == "Color")
            {
                if ((Color)e.ChangedItem.Value == Color.White)
                {
                    MessageBox.Show("所选颜色不能为白色！", Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PenF.Color = (Color)e.OldValue;
                }
            }

        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            PenF = OldpenF;
        }

        private void BtnOK_Click(object sender, System.EventArgs e)
        {
            Close();
        }

    }
}
