using System.ComponentModel;
using WSPEHexPluginHost;

namespace PEHexExplorer
{
    internal partial class WSPlugin
    {

        public class PluginInfo : IWSPEHexPlugin
        {

            [Browsable(false)]
            public string Signature { get; }

            public string PluginName { get; }

            public ushort Version { get; }

            public string Puid { get; }

            public string Author { get; }

            public string Comment { get; }

            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object[] OptionalInfo { get; }

            [Browsable(false)]
            public IWSPEHexPluginBody PluginBody { get; }

            public bool Enabled { get; set; }

            public PluginInfo(IWSPEHexPlugin plugin, bool Enabled = true)
            {
                Signature = plugin.Signature;
                PluginName = plugin.PluginName;
                Version = plugin.Version;
                Puid = plugin.Puid;
                Author = plugin.Author;
                Comment = plugin.Comment;
                OptionalInfo = plugin.OptionalInfo;
                PluginBody = plugin.PluginBody;
                this.Enabled = Enabled;
            }

        }
    }
}