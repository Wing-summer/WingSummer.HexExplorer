using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

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

            Font = userProfile.ProgramFont;
            btnFont.Name = userProfile.ProgramFont.Name;
            cbEncoding.SelectedIndex = (int)userProfile.StringViewEncoding;
            ntScaling.Value = userProfile.ScalingPercent;
            cbEnableString.Checked = userProfile.EnableStringView;
            btnSelBackColor.ForeColor = userProfile.SelBackColor;
            btnSelTextColor.ForeColor = userProfile.SelTextColor;
            cbFileAddr.Checked = userProfile.EnableLineInfo;
            cbColInfo.Checked = userProfile.EnableColInfo;
            cbGroupLine.Checked = userProfile.EnableGroupLine;
            cbStringLine.Checked = userProfile.EnableHexStringLine;

            btnIMAGE_DOS_HEADER.ForeColor = userProfile.IMAGE_DOS_HEADER_Color;
            btnIMAGE_NT_HEADERS.ForeColor = userProfile.IMAGE_NT_HEADERS_Color;
            btnIMAGE_FILE_HEADER.ForeColor = userProfile.IMAGE_FILE_HEADER_Color;
            btnIMAGE_OPTIONAL_HEADER.ForeColor = userProfile.IMAGE_OPTIONAL_HEADER_Color;
            btnIMAGE_IMPORT_DESCRIPTOR.ForeColor = userProfile.IMAGE_IMPORT_DESCRIPTOR_Color;
            btnIMAGE_EXPORT_DIRECTORY.ForeColor = userProfile.IMAGE_EXPORT_DIRECTORY_Color;
            btnIMAGE_DATA_DIRECTORY.ForeColor = userProfile.IMAGE_DATA_DIRECTORY_Color;
            btnIMAGE_BASE_RELOCATION.ForeColor = userProfile.IMAGE_BASE_RELOCATION_Color;
            btnIMAGE_SECTION_HEADER.ForeColor = userProfile.IMAGE_SECTION_HEADER_Color;
            btnOther.ForeColor = userProfile.Image_OtherColor;

            cbEnablePE.Checked = userProfile.EnablePE;
            cbEnablePlugin.Checked = userProfile.EnablePlugin;
            cbEnableBookMark.Checked = userProfile.EnableAdvBookMark;

            
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
    }
}