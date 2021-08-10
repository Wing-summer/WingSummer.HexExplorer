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

        private readonly CompositionContainer container;
        private readonly ContextMenuStrip pluginMenuStrip;
        private readonly ContextMenuStrip toolMenuStrip;
        private readonly Action<object, HostPluginArgs> pipe = 
            new Action<object, HostPluginArgs>((sender,e)=> { PluginBody_HostMenuMessagePipe(sender, e); });
        public ContextMenuStrip PluginMenuStrip => pluginMenuStrip;
        public ContextMenuStrip ToolMenuStrip => toolMenuStrip;

        private readonly IEnumerable<Lazy<IWSPEHexPlugin>> _plugins;
        public Lazy<List<IWSPEHexPlugin>> plugins=new Lazy<List<IWSPEHexPlugin>>();

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

            foreach (var item in _plugins)
            {
                if (item.Value.Signature != WSPEHexPluginLib.Sig)
                {
                    container.ReleaseExport(item);
                    continue;
                }

                IWSPEHexPluginBody pluginBody = item.Value.PluginBody;

                ToolStripItem menuItem = pluginBody.MenuPluginMenu;
                if (menuItem == null)
                {
                    container.ReleaseExport(item);
                    continue;
                }

                pluginMenuStrip = new ContextMenuStrip();
                toolMenuStrip = new ContextMenuStrip();

                pluginMenuStrip.Items.Add(menuItem);

                menuItem = pluginBody.MenuToolMenu;
                if (menuItem != null)
                {
                    toolMenuStrip.Items.Add(menuItem);
                }
                pluginBody.ToHostMessagePipe = pipe;
                pluginBody.HostToMessagePipe += PluginBody_PluginMenuMessagePipe;
                plugins.Value.Add(item.Value);                
            }

        }

        private void PluginBody_PluginMenuMessagePipe(object sender, HostPluginArgs e)
        {
           
        }

        private static void PluginBody_HostMenuMessagePipe(object sender, HostPluginArgs e)
        {

        }
    }

}