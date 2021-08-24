using System;
using System.Windows.Forms;

namespace HexExplorer
{
    public partial class FrmSaveDialog : ToolWindowBase
    {

        private static FrmSaveDialog saveDialog;

        public static FrmSaveDialog Instance
        {
            get
            {
                if (saveDialog == null || saveDialog.IsDisposed)
                {
                    saveDialog = new FrmSaveDialog();
                }
                return saveDialog;
            }
        }

        public EditPage[] ChangesPages { get; set; }

        private FrmSaveDialog()
        {
            InitializeComponent();         
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void BtnDiscard_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FrmSaveDialog_Load(object sender, EventArgs e)
        {
            if (ChangesPages == null)
            {
                throw new NullReferenceException("FrmSaveDialog.changesPages");
            }
            foreach (var item in ChangesPages)
            {
                lbFiles.Items.Add(item.Filename);
            }
        }

      
    }
}
