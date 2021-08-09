using System.Collections.Generic;
using WSPEHexPluginHost;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PEHexExplorer
{
    partial class UserSetting
    {

        public  List<IWSPEHexPluginVer> pluginVers;

        public static MUserProfile UserProfile = new MUserProfile();

       // private readonly XmlSerializer serializer;
        private readonly BinaryFormatter formatter;


        public UserSetting()
        {
           // serializer = new XmlSerializer(typeof(MUserProfile));
            formatter = new BinaryFormatter();
            pluginVers = new List<IWSPEHexPluginVer>();
        }

        public bool Load(string config = null)
        {
            if (config==null)
            {
                if (File.Exists(config ?? Program.AppConfig))
                {
                    using (Stream content = File.OpenRead(config ?? Program.AppConfig))
                    {
                        try
                        {
                            if (content.Length > 0)
                            {
                                object res = formatter.Deserialize(content);
                                if (res == null)
                                {
                                    UserProfile = new MUserProfile();
                                    return false;
                                }
                                UserProfile = res as MUserProfile;
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
            }
            return true;
        }

        public bool Reset()
        {
            return true;
        }

        public bool Save(string outconfig = null)
        {
            using (Stream stream = File.Create(outconfig??Program.AppConfig))
            {
                formatter.Serialize(stream, UserProfile);
            }
            return true;
        }

    }

}
