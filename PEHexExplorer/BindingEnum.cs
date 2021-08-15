using System.Windows.Forms;

namespace PEHexExplorer
{
    static class BindingEnum
    {

        public static class Setting
        {
            public static readonly Binding ProgramFont
                = new Binding("Font", UserSetting.UserProfile, "ProgramFont", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding ProgramFontName
                = new Binding("Text", UserSetting.UserProfile.ProgramFont, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding StringViewEncoding
                = new Binding("SelectedIndex", UserSetting.UserProfile, "StringViewEncoding", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding ScalingPercent
                = new Binding("Value", UserSetting.UserProfile, "ScalingPercent", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding EnableStringView
                = new Binding("Checked", UserSetting.UserProfile, "EnableStringView", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding SelBackColor
                = new Binding("ForeColor", UserSetting.UserProfile, "SelBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding SelTextColor
                = new Binding("ForeColor", UserSetting.UserProfile, "SelTextColor", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding EnableLineInfo
                = new Binding("Checked", UserSetting.UserProfile, "EnableLineInfo", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding EnableColInfo
                = new Binding("Checked", UserSetting.UserProfile, "EnableColInfo", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding EnableGroupLine
                = new Binding("Checked", UserSetting.UserProfile, "EnableGroupLine", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding EnableHexStringLine
                = new Binding("Checked", UserSetting.UserProfile, "EnableHexStringLine", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding IMAGE_DOS_HEADER_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_DOS_HEADER_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding IMAGE_NT_HEADERS_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_NT_HEADERS_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding IMAGE_FILE_HEADER_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_FILE_HEADER_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding IMAGE_OPTIONAL_HEADER_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_OPTIONAL_HEADER_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding IMAGE_IMPORT_DESCRIPTOR_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_IMPORT_DESCRIPTOR_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding IMAGE_EXPORT_DIRECTORY_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_EXPORT_DIRECTORY_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding IMAGE_DATA_DIRECTORY_Color =
                new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_DATA_DIRECTORY_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding IMAGE_BASE_RELOCATION_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_BASE_RELOCATION_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding IMAGE_SECTION_HEADER_Color
                = new Binding("ForeColor", UserSetting.UserProfile, "IMAGE_SECTION_HEADER_Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding Image_OtherColor
                = new Binding("ForeColor", UserSetting.UserProfile, "Image_OtherColor", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding EnablePE
                = new Binding("Checked", UserSetting.UserProfile, "EnablePE", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding EnablePlugin
                = new Binding("Checked", UserSetting.UserProfile, "EnablePlugin", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding EnableAdvBookMark
                = new Binding("Checked", UserSetting.UserProfile, "EnableAdvBookMark", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding LineInfoBtnForeColor
                = new Binding("ForeColor", UserSetting.UserProfile, "LineInfoBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding ColInfoBtnForeColor
                = new Binding("ForeColor", UserSetting.UserProfile, "ColInfoBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding GroupLinePen
                = new Binding("Tag", UserSetting.UserProfile, "GroupLinePen", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding HexStringLinePen
                = new Binding("Tag", UserSetting.UserProfile, "HexStringLinePen", true, DataSourceUpdateMode.OnPropertyChanged);

            public static readonly Binding GroupLinePenFore
                = new Binding("ForeColor", UserSetting.UserProfile.GroupLinePen, "Color", true, DataSourceUpdateMode.OnPropertyChanged);
            public static readonly Binding HexStringLinePenFore
                = new Binding("ForeColor", UserSetting.UserProfile.HexStringLinePen, "Color", true, DataSourceUpdateMode.OnPropertyChanged);

        }

        public static readonly Binding LogInfo = new Binding("Text", LoggingLib.Instance, "LogInfo");


    }
}
