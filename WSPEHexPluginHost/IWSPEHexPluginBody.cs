using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WSPEHexPluginHost
{
    public interface IWSPEHexPluginBody
    {
        /*Version 0 beta*/

        /// <summary>
        /// 编写的时候实现此接口即可，当插件接收到<see cref="MessageType.PluginLoading"/>消息那一刻前，
        /// 插件系统将此值填充，是自己的插件头部
        /// </summary>
        IWSPEHexPlugin Self { get; set; }

        /// <summary>
        /// 插件订阅的消息Hook
        /// </summary>
        List<MessageType> Messages { get; }

        /// <summary>
        /// 插件添加项菜单，不能为空
        /// </summary>
        ToolStripItem MenuPluginMenu { get; }

        /// <summary>
        /// 小工具添加项菜单，可选，如果不需要，设置为null
        /// </summary>
        ToolStripItem MenuToolMenu { get; }

        /// <summary>
        /// 宿主传递给本插件的消息通道，不能为空
        /// </summary>
        Action<object, HostPluginArgs> HostToMessagePipe { get; }

        /// <summary>
        /// 传递给宿主的消息通道
        /// </summary>
        event EventHandler<HostPluginArgs> ToHostMessagePipe;

    }

}
