using System;
using System.Collections.Generic;
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
            private readonly Action<object, HostPluginArgs> action;
            private readonly List<MessageType> messages = new List<MessageType>();

            private delegate void dHostToMessagePipe(object sender, HostPluginArgs e);
            private static dHostToMessagePipe hostToMessagePipe;

            public IWSPEHexPlugin Self { get; set; }
            public ToolStripItem MenuPluginMenu => PluginMenu;
            public ToolStripItem MenuToolMenu => ToolMenu;
            public Action<object, HostPluginArgs> HostToMessagePipe => action;
            public List<MessageType> Messages => messages;

            public event EventHandler<HostPluginArgs> ToHostMessagePipe;

            public MyPluginBody()
            {

                Image image = Properties.Resources.test;

                //初始化小工具附属菜单
                ToolMenu = new ToolStripMenuItem("Tool Menu Test（关闭主程序）", image, MenuItemClick);

                //初始化插件菜单
                PluginMenu = new ToolStripMenuItem("Plugin Menu Test", image);
                PluginMenu.DropDownItems.AddRange(new ToolStripItem[] {
                    new ToolStripMenuItem("二级菜单（1）",null, MenuItemClick),
                     new ToolStripMenuItem("二级菜单（2）",null, MenuItemClick),
                    new ToolStripSeparator(),
                    new ToolStripMenuItem("二级菜单（3）",null,MenuItemClick)
                });

                //插件订阅的Hook
                messages.AddRange(new MessageType[]
                {
                    MessageType.OpenFile
                });

                //将方法转为静态委托并传递，优点：避免静态方法的一些编码限制
                hostToMessagePipe = MyPluginBody_HostToMessagePipe;
                action = new Action<object, HostPluginArgs>(hostToMessagePipe);
            }

            /// <summary>
            /// 本方法为什么注释掉那句代码，详情请看<see cref="MenuItemClick"/>里面的多行注释
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void MyPluginBody_HostToMessagePipe(object sender, HostPluginArgs e)
            {
                if (e.MessageType == MessageType.OpenFile /*&& sender != Self*/)
                {
                    if (e.IsBefore && MessageBox.Show("监听到打开文件事件，是否要取消！", pluginname,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    MessageBox.Show($"监听到事件{e}", pluginname, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            private void MenuItemClick(object sender, EventArgs e)
            {
                ToolStripItem stripItem = sender as ToolStripItem;
                string tmp = stripItem.Text;
                if (tmp[0] == 'T')
                {
                    HostPluginArgs args = new HostPluginArgs
                    {
                        MessageType = MessageType.HostQuit
                    };

                    /*
                     * 为什么sender传Self呢，因为插件引起的操作也是可被订阅Hook的，如果不传Self判断会引起混乱
                     * 这个是插件开发者的问题了，本实例没有判断是因为，我根本不主动告诉宿主我要打开这巴拉巴拉文件
                     *  所以不会涉及该问题，但我会用注释说明该问题，可以说这个是规范                  
                    */

                    ToHostMessagePipe.Invoke(Self, args);
                }
                else
                {
                    MessageBox.Show($"您点击了二级菜单项目{tmp[5]}！");
                }

            }

        }

    }
}
