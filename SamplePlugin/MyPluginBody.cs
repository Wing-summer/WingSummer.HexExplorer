using System;
using System.Drawing;
using System.Windows.Forms;
using WSPEHexPluginHost;

namespace SamplePlugin
{
    public partial class SamplePlugin
    {
        public class MyPluginBody : IWSPEHexPluginBody
        {
            private readonly ToolStripMenuItem ToolMenu = null;
            private readonly ToolStripMenuItem PluginMenu = null;

            public ToolStripItem MenuPluginMenu => PluginMenu;

            public ToolStripItem MenuToolMenu => ToolMenu;

            public Action<object, HostPluginArgs> ToHostMessagePipe { get ; set ; }

            public event EventHandler<HostPluginArgs> HostToMessagePipe;

            public MyPluginBody()
            {
                Image image = Properties.Resources.test;
                ToolMenu = new ToolStripMenuItem("Tool Menu Test", image, MenuItemClick);
                PluginMenu = new ToolStripMenuItem("Plugin Menu Test", image);
                PluginMenu.DropDownItems.AddRange(new ToolStripItem[] {
                    new ToolStripMenuItem("二级菜单（1）",null, MenuItemClick),
                     new ToolStripMenuItem("二级菜单（2）",null, MenuItemClick),
                    new ToolStripSeparator(),
                    new ToolStripMenuItem("二级菜单（3）",null,MenuItemClick)
                });
                HostToMessagePipe += MyPluginBody_HostToMessagePipe;
            }

            private void MyPluginBody_HostToMessagePipe(object sender, HostPluginArgs e)
            {
                
            }

            private void MenuItemClick(object sender, EventArgs e)
            {
                ToolStripItem stripItem = sender as ToolStripItem;
                string tmp = stripItem.Text;
                if (tmp[0] == 'T')
                {
                    MessageBox.Show("您点击了工具菜单项目！");
                }
                else
                {
                    MessageBox.Show($"您点击了二级菜单项目{tmp[5]}！");
                }

            }

        }

    }
}
