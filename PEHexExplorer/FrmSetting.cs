using System.Windows.Forms;
using System.ComponentModel;
using Be.Windows.Forms;
using System.Drawing;

namespace PEHexExplorer
{
    public partial class FrmSetting : ToolWindowBase
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

        [DefaultValue(false)]
        public bool IsPluginShow { get; set; }

        public FrmSetting()
        {
            InitializeComponent();

            //创建绑定，少些重复性代码
            DataBindings.Add(BindingEnum.Setting.ProgramFont);
            btnFont.DataBindings.Add(BindingEnum.Setting.ProgramFontName);
            cbEncoding.DataBindings.Add(BindingEnum.Setting.StringViewEncoding);
            ntScaling.DataBindings.Add(BindingEnum.Setting.ScalingPercent);
            cbEnableString.DataBindings.Add(BindingEnum.Setting.EnableStringView);

            btnSelBackColor.DataBindings.Add(BindingEnum.Setting.SelBackColor);
            btnSelTextColor.DataBindings.Add(BindingEnum.Setting.SelTextColor);
            cbLineInfo.DataBindings.Add(BindingEnum.Setting.EnableLineInfo);
            cbColInfo.DataBindings.Add(BindingEnum.Setting.EnableColInfo);
            cbGroupLine.DataBindings.Add(BindingEnum.Setting.EnableGroupLine);
            cbStringLine.DataBindings.Add(BindingEnum.Setting.EnableHexStringLine);

            btnIMAGE_DOS_HEADER.DataBindings.Add(BindingEnum.Setting.IMAGE_DOS_HEADER_Color);
            btnIMAGE_NT_HEADERS.DataBindings.Add(BindingEnum.Setting.IMAGE_NT_HEADERS_Color);
            btnIMAGE_FILE_HEADER.DataBindings.Add(BindingEnum.Setting.IMAGE_FILE_HEADER_Color);
            btnIMAGE_OPTIONAL_HEADER.DataBindings.Add(BindingEnum.Setting.IMAGE_OPTIONAL_HEADER_Color);
            btnIMAGE_IMPORT_DESCRIPTOR.DataBindings.Add(BindingEnum.Setting.IMAGE_IMPORT_DESCRIPTOR_Color);
            btnIMAGE_EXPORT_DIRECTORY.DataBindings.Add(BindingEnum.Setting.IMAGE_EXPORT_DIRECTORY_Color);
            btnIMAGE_DATA_DIRECTORY.DataBindings.Add(BindingEnum.Setting.IMAGE_DATA_DIRECTORY_Color);
            btnIMAGE_BASE_RELOCATION.DataBindings.Add(BindingEnum.Setting.IMAGE_BASE_RELOCATION_Color);
            btnIMAGE_SECTION_HEADER.DataBindings.Add(BindingEnum.Setting.IMAGE_SECTION_HEADER_Color);
            btnOther.DataBindings.Add(BindingEnum.Setting.Image_OtherColor);

            cbEnablePE.DataBindings.Add(BindingEnum.Setting.EnablePE);
            cbEnablePlugin.DataBindings.Add(BindingEnum.Setting.EnablePlugin);
            cbEnableBookMark.DataBindings.Add(BindingEnum.Setting.EnableAdvBookMark);

            btnLineInfo.DataBindings.Add(BindingEnum.Setting.LineInfoBtnForeColor);
            btnColInfo.DataBindings.Add(BindingEnum.Setting.ColInfoBtnForeColor);
            btnGroupLine.DataBindings.Add(BindingEnum.Setting.GroupLinePen);
            btnGroupLine.DataBindings.Add(BindingEnum.Setting.GroupLinePenFore);
            btnStringLine.DataBindings.Add(BindingEnum.Setting.HexStringLinePen);
            btnStringLine.DataBindings.Add(BindingEnum.Setting.HexStringLinePenFore);

        }

        private void FrmSetting_VisibleChanged(object sender, System.EventArgs e)
        {
            if (Visible)
            {
                if (IsPluginShow)
                {
                    tabSetting.SelectedIndex = 3;
                    IsPluginShow = false;
                }
                else
                {
                    tabSetting.SelectedIndex = 0;
                }
            }
        }

        private void BtnSelectColor_Click(object sender, System.EventArgs e)
        {
            if (cD.ShowDialog() == DialogResult.OK)
            {
                if (cD.Color == Color.Black)
                {
                    MessageBox.Show("所选颜色不能为黑色！", Program.SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                (sender as Button).ForeColor = cD.Color;
            }
        }

        private void BtnPenFEdit_Click(object sender, System.EventArgs e)
        {
            using (FrmPenFEdit frmPenF = FrmPenFEdit.Instance)
            {
                frmPenF.PenF = (sender as Button).Tag as PenF;
                frmPenF.ShowDialog();
                frmPenF.Dispose();
            }
        }
    }
}