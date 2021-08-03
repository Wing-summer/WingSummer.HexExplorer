using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using WSPEHexPluginHost;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Be.Windows.Forms;
using System.ComponentModel;
using System.IO;

namespace PEHexExplorer
{
    class UserSetting
    {

        public  List<IWSPEHexPluginVer> pluginVers;

        public MUserProfile UserProfile { get; private set; }

        public  class MUserProfile
        {

            #region 常规
            public  Font ProgramFont { get; set; }
            public  uint StringViewTable { get; set; }
            public  uint ScalingPercent { get; set; }
            public  bool EnableStringView { get; set; }
            public  bool EnableLineInfo { get; set; }
            public  bool EnableColInfo { get; set; }
            public  bool EnableGroupLine { get; set; }
            public  bool EnableHexStringLine { get; set; }
            public  Color SelBackColor { get; set; }
            public  Color SelTextColor { get; set; }
            public  Color LineInfoBackColor { get; set; }
            public  Color ColInfBackColor { get; set; }
            public  PenF GroupLinePen { get; set; }
            public  PenF HexStringLinePen { get; set; }
            #endregion

            #region PE结构

            [DefaultValue(typeof(Color), "")]
            public  Color IMAGE_DOS_HEADER_Color { get; set; }

            [DefaultValue(typeof(Color), "")]
            public  Color IMAGE_NT_HEADERS_Color { get; set; }

            [DefaultValue(typeof(Color), "")]
            public  Color IMAGE_DATA_DIRECTORY_Color { get; set; }

            [DefaultValue(typeof(Color), "")]
            public  Color IMAGE_OPTIONAL_HEADER_Color { get; set; }

            [DefaultValue(typeof(Color), "")]
            public  Color IMAGE_DATA_DIRECTORY_Item_Color { get; set; }

            [DefaultValue(typeof(Color), "")]
            public  Color IMAGE_IMPORT_DESCRIPTOR_Color { get; set; }

            [DefaultValue(typeof(Color), "")]
            public  Color IMAGE_BASE_RELOCATION_Color { get; set; }

            [DefaultValue(typeof(Color), "")]
            public  Color IMAGE_SECTION_HEADER_Color { get; set; }

            [DefaultValue(typeof(Color), "")]
            public  Color IMAGE_EXPORT_DIRECTORY_Color { get; set; }

            [DefaultValue(typeof(Color), "")]
            public  Color Image_OtherColor { get; set; }

            #endregion

            #region 书签

            public  bool EnableAdvBookMark { get; set; }
            public  List<BookMarkProperty> markProperties { get; set; }

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
