using System.Windows.Forms;

namespace PEHexExplorer
{
    static class BindingEnum
    {

        public static class Setting
        {
            public readonly static Binding ProgramFont
                = new Binding("Font", UserSetting.UserProfile, "ProgramFont", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding ProgramFontName
                = new Binding("Text", UserSetting.UserProfile.ProgramFont, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding StringViewEncoding
                = new Binding("SelectedIndex", UserSetting.UserProfile, "StringViewEncoding", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding ScalingPercent
                = new Binding("Value", UserSetting.UserProfile, "ScalingPercent", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding EnableStringView
                = new Binding("Checked", UserSetting.UserProfile, "EnableStringView", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding SelBackColor
                = new Binding("ForeColor", UserSetting.UserProfile, "SelBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding SelTextColor
                = new Binding("ForeColor", UserSetting.UserProfile, "SelTextColor", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding EnableLineInfo
                = new Binding("Checked", UserSetting.UserProfile, "EnableLineInfo", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding EnableColInfo
                = new Binding("Checked", UserSetting.UserProfile, "EnableColInfo", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding EnableGroupLine
                = new Binding("Checked", UserSetting.UserProfile, "EnableGroupLine", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding EnableHexStringLine
                = new Binding("Checked", UserSetting.UserProfile, "EnableHexStringLine", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding IMAGE_DOS_HEADER_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_DOS_HEADER_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding IMAGE_NT_HEADERS_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_NT_HEADERS_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding IMAGE_FILE_HEADER_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_FILE_HEADER_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding IMAGE_OPTIONAL_HEADER_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_OPTIONAL_HEADER_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding IMAGE_IMPORT_DESCRIPTOR_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_IMPORT_DESCRIPTOR_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding IMAGE_EXPORT_DIRECTORY_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_EXPORT_DIRECTORY_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding IMAGE_DATA_DIRECTORY_Color =
                new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_DATA_DIRECTORY_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding IMAGE_BASE_RELOCATION_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_BASE_RELOCATION_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding IMAGE_SECTION_HEADER_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_SECTION_HEADER_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding Image_OtherColor
                = new Binding("ForeColor", UserSetting.UserProfile, "Image_OtherColor", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding EnablePE
                = new Binding("Checked", UserSetting.UserProfile, "EnablePE", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding EnablePlugin
                = new Binding("Checked", UserSetting.UserProfile, "EnablePlugin", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding EnableAdvBookMark
                = new Binding("Checked", UserSetting.UserProfile, "EnableAdvBookMark", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding LineInfoBtnForeColor
                = new Binding("ForeColor", UserSetting.UserProfile, "LineInfoBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding ColInfoBtnForeColor
                = new Binding("ForeColor", UserSetting.UserProfile, "ColInfoBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding GroupLinePen
                = new Binding("Tag", UserSetting.UserProfile, "GroupLinePen", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding HexStringLinePen
                = new Binding("Tag", UserSetting.UserProfile, "HexStringLinePen", true, DataSourceUpdateMode.OnPropertyChanged);

            public readonly static Binding GroupLinePenFore
                = new Binding("ForeColor", UserSetting.UserProfile.GroupLinePen, "Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public readonly static Binding HexStringLinePenFore
                = new Binding("ForeColor", UserSetting.UserProfile.HexStringLinePen, "Color", true, DataSourceUpdateMode.OnPropertyChanged);

        }

    }
}
