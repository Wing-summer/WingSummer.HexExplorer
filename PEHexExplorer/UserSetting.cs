using System.Collections.Generic;
using WSPEHexPluginHost;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace PEHexExplorer
{
    partial class UserSetting
    {

        public List<IWSPEHexPlugin> pluginVers;

        public static MUserProfile UserProfile;

        private readonly BinaryFormatter formatter;


        public UserSetting()
        {
            formatter = new BinaryFormatter();
            pluginVers = new List<IWSPEHexPlugin>();
        }

        public bool Load(string config = null)
        {
            if (File.Exists(config ?? Program.AppConfig))
            {
                using (Stream content = File.OpenRead(config ?? Program.AppConfig))
                {
                    try
                    {
                        if (content.Length > 0)
                        {
                            MUserProfile res = (MUserProfile)formatter.Deserialize(content);
                            if (res == null || res.ProgramFont == null || res.GroupLinePen == null || res.HexStringLinePen == null)
                            {
                                var re = MessageBox.Show("配置信息出错，如果让程序重置继续，请点击 是 。如果保留现场直接退出程序，请选择 否。",
                               Program.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                                if (re == DialogResult.No)
                                    Process.GetCurrentProcess().Kill();     //直接把自己杀掉以保留现场

                                UserProfile = new MUserProfile();
                                return false;
                            }
                            UserProfile = res;
                        }
                    }
                    catch
                    {
                        UserProfile = new MUserProfile();
                    }
                }
            }
            else
            {
                UserProfile = new MUserProfile();
                return false;
            }
            return true;
        }

        public bool Reset()
        {
            return true;
        }

        public bool Save(string outconfig = null)
        {
            using (Stream stream = File.Create(outconfig ?? Program.AppConfig))
            {
                formatter.Serialize(stream, UserProfile);
            }
            return true;
        }

    }

}
