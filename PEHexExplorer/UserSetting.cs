using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using WSPEHexPluginHost;
using Newtonsoft.Json;
using Be.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace PEHexExplorer
{
    class UserSetting
    {

        public  List<IWSPEHexPluginVer> pluginVers;

        public static MUserProfile UserProfile = new MUserProfile();

        #region 预定义默认颜色和笔刷

        public static Color DefaultSelBackColor = Color.FromArgb(100, 66, 137, 202);
        public static Color DefaultSelTextColor = Color.White;
        public static Color DefaultShadowSelColor = Color.FromArgb(100, 60, 188, 255);
        public static Color DefaultLineInfoBackColor = Color.Cyan;
        public static Color DefaultColInfoBackColor = Color.FromArgb(255, 255, 255, 128);
        public static Color DefaultIMAGE_DOS_HEADER_Color = Color.FromArgb(255, 240, 230, 140);
        public static Color DefaultIMAGE_NT_HEADERS_Color = Color.FromArgb(255, 200, 250, 200);
        public static Color DefaultIMAGE_OPTIONAL_HEADER_Color = Color.FromArgb(255, 200, 200, 250);
        public static Color DefaultIMAGE_SECTION_HEADER_Color = Color.FromArgb(255, 255, 192, 192);
        public static Color DefaultIMAGE_DATA_DIRECTORY_Color = Color.FromArgb(255, 173, 239, 237);
        public static Color DefaultIMAGE_DATA_DIRECTORY_Item_Color = Color.FromArgb(255, 213, 252, 120);
        public static Color DefaultIMAGE_IMPORT_DESCRIPTOR_Color = Color.FromArgb(255, 120, 204, 252);
        public static Color DefaultIMAGE_BASE_RELOCATION_Color = Color.FromArgb(255, 252, 120, 213);
        public static Color DefaultIMAGE_EXPORT_DIRECTORY_Color = Color.FromArgb(255, 252, 144, 120);
        public static Color DefaultImage_OtherColor = Color.FromArgb(255, 255, 255, 224);

        public static PenF DefaultGroupLinePen = new PenF()
        {
            Color = Color.Green,
            Alignment = PenAlignment.Center,
            DashCap = DashCap.Flat,
            DashOffset = 0,
            DashStyle = DashStyle.Solid,
            EndCap = LineCap.Flat,
            StartCap = LineCap.Flat,
            Width = 1
        };

        public static PenF DefaultHexStringLinePen = new PenF()
        {
            Color = Color.Fuchsia,
            Alignment = PenAlignment.Center,
            DashCap = DashCap.Flat,
            DashOffset = 0,
            DashStyle = DashStyle.Dash,
            EndCap = LineCap.Flat,
            StartCap = LineCap.Flat,
            Width = 1
        };

        #endregion

        public class MUserProfile
        {
            public MUserProfile()
            {

                ProgramFont = SystemFonts.DefaultFont;
                StringViewTable = 0;
                ScalingPercent = 100;
                EnableStringView = true;
                EnableLineInfo = true;
                EnableColInfo = true;
                EnableGroupLine = true;
                EnableHexStringLine = true;
                SelBackColor = DefaultSelBackColor;
                SelTextColor = DefaultSelTextColor;
                ShadowSelColor = DefaultShadowSelColor;

                GroupLinePen = DefaultGroupLinePen;
                HexStringLinePen = DefaultHexStringLinePen;
                LineInfoBackColor = DefaultLineInfoBackColor;
                ColInfoBackColor = DefaultColInfoBackColor;
                IMAGE_DOS_HEADER_Color = DefaultIMAGE_DOS_HEADER_Color;
                IMAGE_NT_HEADERS_Color = DefaultIMAGE_NT_HEADERS_Color;
                IMAGE_OPTIONAL_HEADER_Color = DefaultIMAGE_OPTIONAL_HEADER_Color;
                IMAGE_SECTION_HEADER_Color = DefaultIMAGE_SECTION_HEADER_Color;
                IMAGE_DATA_DIRECTORY_Color = DefaultIMAGE_DATA_DIRECTORY_Color;
                IMAGE_DATA_DIRECTORY_Item_Color = DefaultIMAGE_DATA_DIRECTORY_Item_Color;
                IMAGE_IMPORT_DESCRIPTOR_Color = DefaultIMAGE_IMPORT_DESCRIPTOR_Color;
                IMAGE_BASE_RELOCATION_Color = DefaultIMAGE_BASE_RELOCATION_Color;
                IMAGE_EXPORT_DIRECTORY_Color = DefaultIMAGE_EXPORT_DIRECTORY_Color;
                Image_OtherColor = DefaultImage_OtherColor;

                EnableAdvBookMark = true;
                MarkProperties = null;

                EnablePlugin = true;
                DisableGuid = null;

            }

            #region 常规

            public  Font ProgramFont { get; set; }
            public  uint StringViewTable { get; set; }
            public  uint ScalingPercent { get; set; }
            public  bool EnableStringView { get; set; }
            public bool EnableLineInfo { get; set; }
            public bool EnableColInfo { get; set; }
            public bool EnableGroupLine { get; set; }
            public bool EnableHexStringLine { get; set; }
            public  Color SelBackColor { get; set; }
            public  Color SelTextColor { get; set; }
            public  Color LineInfoBackColor { get; set; }
            public  Color ColInfoBackColor { get; set; }
            public Color ShadowSelColor { get; set; }
            public  PenF GroupLinePen { get; set; }
            public  PenF HexStringLinePen { get; set; }

            #endregion

            #region PE结构

            public  Color IMAGE_DOS_HEADER_Color { get; set; }
            public  Color IMAGE_NT_HEADERS_Color { get; set; }
            public  Color IMAGE_OPTIONAL_HEADER_Color { get; set; }
            public Color IMAGE_SECTION_HEADER_Color { get; set; }
            public  Color IMAGE_DATA_DIRECTORY_Color { get; set; }
            public  Color IMAGE_DATA_DIRECTORY_Item_Color { get; set; }
            public  Color IMAGE_IMPORT_DESCRIPTOR_Color { get; set; }
            public  Color IMAGE_BASE_RELOCATION_Color { get; set; }
            public  Color IMAGE_EXPORT_DIRECTORY_Color { get; set; }
            public  Color Image_OtherColor { get; set; }

            #endregion

            #region 书签

            public  bool EnableAdvBookMark { get; set; }
            public  List<BookMarkProperty> MarkProperties { get; set; }

            #endregion

            #region 插件

            public  bool EnablePlugin { get; set; }
            public  List<Guid> DisableGuid { get; set; }

            #endregion

        }

        public UserSetting()
        {
            pluginVers = new List<IWSPEHexPluginVer>();
        }

        public bool Load(string config = null)
        {
            if (config==null)
            {
                if (File.Exists(config??Program.AppConfigDir))
                {
                    string content = File.ReadAllText(Program.AppConfigDir, Encoding.ASCII);
                    object res = JsonConvert.DeserializeObject(content);
                    if (res==null)
                    {
                        UserProfile = new MUserProfile();
                        return false;
                    }
                    UserProfile = res as MUserProfile ;
                }
                else
                {
                    UserProfile = new MUserProfile();
                    return false;
                }
            }
            return true;
        }

        public bool Reset()
        {

            return true;
        }

        public bool Save(string outconfig = null)
        {
            using (StreamWriter streamWriter = new StreamWriter(outconfig??Program.AppConfigDir, false, Encoding.ASCII))
            {
                streamWriter.Write(JsonConvert.SerializeObject(UserProfile));
            }
            return true;
        }

    }
}
