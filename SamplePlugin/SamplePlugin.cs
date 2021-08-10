using System;
using System.ComponentModel.Composition;
using WSPEHexPluginHost;

namespace SamplePlugin
{
    [Export(typeof(IWSPEHexPlugin))]
    public partial class SamplePlugin : IWSPEHexPlugin
    {

        #region PluginHeader

        /// <summary>
        /// 插件名
        /// </summary>
        private const string pluginname = "SamplePlugin";
        private const string author = "WingSummer";
        private const string comment = "插件测试……";
        private const ushort version = 0;

        /// <summary>
        /// Plugin Unique Identifier（插件通用标识符）
        /// 每个插件都有一个独属自己的
        /// 可通过 WSPEHexPluginLib 中的 GetPuid 函数进行获取
        /// </summary>
        private readonly string puid = WSPEHexPluginLib.GetPuid(pluginname, author, comment, version);

        public string Signature => WSPEHexPluginLib.Sig;       //插件签名

        public string PluginName => pluginname;

        public ushort Version => version;

        public string Puid => puid;

        public string Author => author;

        public string Comment => comment;

        public object[] OptionalInfo => null;

        #endregion

        public IWSPEHexPluginBody PluginBody => pluginBody;

        private readonly MyPluginBody pluginBody = new MyPluginBody();

    }
}
