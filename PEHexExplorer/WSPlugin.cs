using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WSPEHexPluginHost;

namespace PEHexExplorer
{
    internal partial class WSPlugin
    {

        private readonly CompositionContainer container;
        private readonly ContextMenuStrip pluginMenuStrip;
        private readonly ContextMenuStrip toolMenuStrip;
        private readonly HostPluginArgs LoadingPlugin = new HostPluginArgs { MessageType = MessageType.PluginLoading };
        private readonly HostPluginArgs LoadedPlugin = new HostPluginArgs { MessageType = MessageType.PluginLoaded };
        private const string NullMSG = "无消息传递到插件的接口错误";
        private const string ErrSig = "文件签名错误";
        private const string ErrPUID = "插件标识符校验失败";
        private const string NullMNP = "无插件菜单错误";
   

        private static WSPlugin sPlugin = null;
        private readonly LoggingLib logging = LoggingLib.Instance;

        public static WSPlugin Instance
        {
            get
            {
                if (sPlugin == null)
                {
                    sPlugin = new WSPlugin();
                }
                return sPlugin;
            }
        }

        public ContextMenuStrip PluginMenuStrip => pluginMenuStrip;
        public ContextMenuStrip ToolMenuStrip => toolMenuStrip;

        private readonly IEnumerable<Lazy<IWSPEHexPlugin>> _plugins;
        public Lazy<List<IWSPEHexPlugin>> plugins = new Lazy<List<IWSPEHexPlugin>>();

        public Lazy<Dictionary<MessageType, List<Action<object, HostPluginArgs>>>> MSGQueue
            = new Lazy<Dictionary<MessageType, List<Action<object, HostPluginArgs>>>>();

        /// <summary>
        /// 将事件传递到FrmMain处理
        /// </summary>
        public event EventHandler<HostPluginArgs> ToHostMessagePipe;

        private WSPlugin()
        {
            Directory.CreateDirectory(Program.AppPlugin);
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Program.AppPlugin));
            container = new CompositionContainer(catalog);
            try
            {
                container.ComposeParts(this);
            }
            catch (CompositionException ex)
            {
                MessageBox.Show(ex.ToString(), Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _plugins = container.GetExports<IWSPEHexPlugin>();
            if (_plugins.Count() == 0)
            {
                return;
            }

            pluginMenuStrip = new ContextMenuStrip();
            toolMenuStrip = new ContextMenuStrip();
            var msgqueue = MSGQueue.Value;
            msgqueue.Add(MessageType.ErrorMessage, new List<Action<object, HostPluginArgs>>());

            foreach (var item in _plugins)
            {
                var plugin = item.Value;
                if (plugin.Signature != WSPEHexPluginLib.Sig)
                {
                    container.ReleaseExport(item);
                    logging.WritePluginInfo(plugin, false, ErrSig);
                    continue;
                }

                if (plugin.Puid != WSPEHexPluginLib.GetPuid(plugin))
                {
                    container.ReleaseExport(item);
                    logging.WritePluginInfo(plugin, false, ErrPUID);
                    continue;
                }

                IWSPEHexPluginBody pluginBody = plugin.PluginBody;

                var hostto = pluginBody.HostToMessagePipe;

                if (hostto == null)
                {
                    container.ReleaseExport(item);
                    logging.WritePluginInfo(plugin, false, NullMSG);
                    continue;
                }
                pluginBody.Self = plugin;

                hostto.Invoke(null, LoadingPlugin);

                var messages = pluginBody.Messages;

                if (messages != null)
                {
                    foreach (var msg in messages)
                    {
                        if (msgqueue.ContainsKey(msg))
                        {
                            msgqueue[msg].Add(hostto);
                        }
                        else
                        {
                            msgqueue.Add(msg, new List<Action<object, HostPluginArgs>> { hostto });
                        }
                    }
                }

                msgqueue[MessageType.ErrorMessage].Add(hostto);

                ToolStripItem menuItem = pluginBody.MenuPluginMenu;
                if (menuItem == null)
                {
                    container.ReleaseExport(item);
                    logging.WritePluginInfo(plugin, false, NullMNP);
                    continue;
                }

                pluginMenuStrip.Items.Add(menuItem);

                menuItem = pluginBody.MenuToolMenu;
                if (menuItem != null)
                {
                    menuItem.Visible = true;
                    toolMenuStrip.Items.Add(menuItem);
                }
                pluginBody.ToHostMessagePipe += PluginBody_ToHostMessagePipe;
                hostto?.Invoke(null, LoadedPlugin);
                plugins.Value.Add(item.Value);
                logging.WritePluginInfo(plugin);
            }
        }

        private void PluginBody_ToHostMessagePipe(object sender, HostPluginArgs e)
        {
            ToHostMessagePipe?.Invoke(sender, e);
        }

        public void SendErrorMessage(object sender, MessageType err, Exception exception)
        {
            if (!(sender is IWSPEHexPlugin s)) return;
            s.PluginBody.HostToMessagePipe.Invoke(this, new HostPluginArgs
            {
                MessageType = MessageType.ErrorMessage,
                Content = (new object[] { err, exception })
            });
        }

    }
}