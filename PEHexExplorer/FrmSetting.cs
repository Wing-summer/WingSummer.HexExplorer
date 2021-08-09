using System.Windows.Forms;
using System.ComponentModel;

namespace PEHexExplorer
{
    public partial class FrmSetting : Form
    {

        private static FrmSetting frmSetting=null;
        private readonly MUserProfile userProfile = UserSetting.UserProfile;

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
            DataBindings.Add(new Binding("Font", userProfile, "ProgramFont", true, DataSourceUpdateMode.OnPropertyChanged));
            btnFont.DataBindings.Add(new Binding("Text", userProfile.ProgramFont, "Name", true, DataSourceUpdateMode.OnPropertyChanged));
            cbEncoding.DataBindings.Add(new Binding("SelectedIndex", userProfile, "StringViewEncoding", true, DataSourceUpdateMode.OnPropertyChanged));
            ntScaling.DataBindings.Add(new Binding("Value", userProfile, "ScalingPercent", true, DataSourceUpdateMode.OnPropertyChanged));
            cbEnableString.DataBindings.Add(new Binding("Checked", userProfile, "EnableStringView", true, DataSourceUpdateMode.OnPropertyChanged));
            btnSelBackColor.DataBindings.Add(new Binding("ForeColor", userProfile, "SelBackColor", true, DataSourceUpdateMode.OnPropertyChanged));
            btnSelTextColor.DataBindings.Add(new Binding("ForeColor", userProfile, "SelTextColor", true, DataSourceUpdateMode.OnPropertyChanged));
            cbFileAddr.DataBindings.Add(new Binding("Checked", userProfile, "EnableLineInfo", true, DataSourceUpdateMode.OnPropertyChanged));
            cbColInfo.DataBindings.Add(new Binding("Checked", userProfile, "EnableColInfo", true, DataSourceUpdateMode.OnPropertyChanged));
            cbGroupLine.DataBindings.Add(new Binding("Checked", userProfile, "EnableGroupLine", true, DataSourceUpdateMode.OnPropertyChanged));
            cbStringLine.DataBindings.Add(new Binding("Checked", userProfile, "EnableHexStringLine", true, DataSourceUpdateMode.OnPropertyChanged));
            btnIMAGE_DOS_HEADER.DataBindings.Add(new Binding("ForeColor", userProfile, "IMAGE_DOS_HEADER_Color", true, DataSourceUpdateMode.OnPropertyChanged));
            btnIMAGE_NT_HEADERS.DataBindings.Add(new Binding("ForeColor", userProfile, "IMAGE_NT_HEADERS_Color", true, DataSourceUpdateMode.OnPropertyChanged));
            btnIMAGE_FILE_HEADER.DataBindings.Add(new Binding("ForeColor", userProfile, "IMAGE_FILE_HEADER_Color", true, DataSourceUpdateMode.OnPropertyChanged));
            btnIMAGE_OPTIONAL_HEADER.DataBindings.Add(new Binding("ForeColor", userProfile, "IMAGE_OPTIONAL_HEADER_Color", true, DataSourceUpdateMode.OnPropertyChanged));
            btnIMAGE_IMPORT_DESCRIPTOR.DataBindings.Add(new Binding("ForeColor", userProfile, "IMAGE_IMPORT_DESCRIPTOR_Color", true, DataSourceUpdateMode.OnPropertyChanged));
            btnIMAGE_EXPORT_DIRECTORY.DataBindings.Add(new Binding("ForeColor", userProfile, "IMAGE_EXPORT_DIRECTORY_Color", true, DataSourceUpdateMode.OnPropertyChanged));
            btnIMAGE_DATA_DIRECTORY.DataBindings.Add(new Binding("ForeColor", userProfile, "IMAGE_DATA_DIRECTORY_Color", true, DataSourceUpdateMode.OnPropertyChanged));
            btnIMAGE_BASE_RELOCATION.DataBindings.Add(new Binding("ForeColor", userProfile, "IMAGE_BASE_RELOCATION_Color", true, DataSourceUpdateMode.OnPropertyChanged));
            btnIMAGE_SECTION_HEADER.DataBindings.Add(new Binding("ForeColor", userProfile, "IMAGE_SECTION_HEADER_Color", true, DataSourceUpdateMode.OnPropertyChanged));
            btnOther.DataBindings.Add(new Binding("ForeColor", userProfile, "Image_OtherColor", true, DataSourceUpdateMode.OnPropertyChanged));
            cbEnablePE.DataBindings.Add(new Binding("Checked", userProfile, "EnablePE", true, DataSourceUpdateMode.OnPropertyChanged));
            cbEnablePlugin.DataBindings.Add(new Binding("Checked", userProfile, "EnablePlugin", true, DataSourceUpdateMode.OnPropertyChanged));
            cbEnableBookMark.DataBindings.Add(new Binding("Checked", userProfile, "EnableAdvBookMark", true, DataSourceUpdateMode.OnPropertyChanged));

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
                (sender as Button).ForeColor = cD.Color;
            }
        }

    }
}