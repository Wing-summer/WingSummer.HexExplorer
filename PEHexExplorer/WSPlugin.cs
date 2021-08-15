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
    internal class WSPlugin
    {
        internal static class PluginSupportFuc
        {
            public static WSPlugin pluginManager = null;
            public static void PluginSupport(MessageType messageType, Action action)
            {
                HostPluginArgs args = new HostPluginArgs { MessageType = messageType, IsBefore = true };
                bool isvalid = pluginManager != null && pluginManager.MSGQueue.Value.ContainsKey(messageType);

                if (isvalid)
                {
                    foreach (var item in pluginManager.MSGQueue.Value[messageType])
                    {
                        item.Invoke(null, args);

                        if (args.Cancel)
                            return;
                    }
                }

                action.Invoke();

                if (isvalid)
                {
                    args.IsBefore = false;
                    foreach (var item in pluginManager.MSGQueue.Value[messageType])
                        item.Invoke(null, args);
                }

            }
        }

        private readonly CompositionContainer container;
        private readonly ContextMenuStrip pluginMenuStrip;
        private readonly ContextMenuStrip toolMenuStrip;
        private readonly HostPluginArgs LoadingPlugin = new HostPluginArgs { MessageType = MessageType.PluginLoading };
        private readonly HostPluginArgs LoadedPlugin = new HostPluginArgs { MessageType = MessageType.PluginLoaded };

        public ContextMenuStrip PluginMenuStrip => pluginMenuStrip;
        public ContextMenuStrip ToolMenuStrip => toolMenuStrip;

        private readonly IEnumerable<Lazy<IWSPEHexPlugin>> _plugins;
        public Lazy<List<IWSPEHexPlugin>> plugins=new Lazy<List<IWSPEHexPlugin>>();
        public Lazy<Dictionary<MessageType, List<Action<object, HostPluginArgs>>>> MSGQueue
            = new Lazy<Dictionary<MessageType, List<Action<object, HostPluginArgs>>>>();

        public WSPlugin()
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

            foreach (var item in _plugins)
            {
                if (item.Value.Signature != WSPEHexPluginLib.Sig)
                {
                    container.ReleaseExport(item);
                    continue;
                }

                IWSPEHexPluginBody pluginBody = item.Value.PluginBody;

                var hostto = pluginBody.HostToMessagePipe;

                hostto?.Invoke(null, LoadingPlugin);

                var messages = pluginBody.Messages;

                if (pluginBody.Messages == null)
                {
                    container.ReleaseExport(item);
                    continue;
                }

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

                ToolStripItem menuItem = pluginBody.MenuPluginMenu;
                if (menuItem == null)
                {
                    container.ReleaseExport(item);
                    continue;
                }

                pluginMenuStrip.Items.Add(menuItem);

                menuItem = pluginBody.MenuToolMenu;
                if (menuItem != null)
                {
                    toolMenuStrip.Items.Add(menuItem);
                }
                pluginBody.ToHostMessagePipe += PluginBody_ToHostMessagePipe;
                hostto?.Invoke(null, LoadedPlugin);
                plugins.Value.Add(item.Value);
            }

        }

        private void PluginBody_ToHostMessagePipe(object sender, HostPluginArgs e)
        {
            if (e.MessageType== MessageType.HostQuit)
            {
                Application.Exit();
            }
        }

        private void PluginBody_HostToMessagePipe(object sender, HostPluginArgs e)
        {
       
        }

    }

}