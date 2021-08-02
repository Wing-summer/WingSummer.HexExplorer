using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WSPEHexPluginHost
{
    public interface IWSPEHexPlugin
    {

        /*Version 0 beta*/

        ToolStripItem MenuPluginMenu { get; }

        ToolStripItem MenuToolMenu { get; }

        Dictionary<ToolStripItem,EventArgs> MenuEvent { get; }


    }

    /// <summary>
    /// 定义插件信息的重要接口，为了兼容性，必须尽量不能变化
    /// </summary>
    public interface IWSPEHexPluginVer
    {
        /// <summary>
        /// 插件签名，要求必须为 WingSummer
        /// </summary>
        string Signature { get; } 

        /// <summary>
        /// 插件名称，用于显示
        /// </summary>
        string PluginName { get; }

        /// <summary>
        /// 插件版本，是校验插件是否支持更多新功能的关键
        /// </summary>
        ushort Version { get; }

        /// <summary>
        /// 识别不同插件的标识符
        /// </summary>
        Guid Guid { get; }

        /// <summary>
        /// 插件作者
        /// </summary>
        string Author { get; }

        /// <summary>
        /// 插件说明
        /// </summary>
        string Comment { get; }

        /// <summary>
        /// 用于扩展信息的列表
        /// </summary>
        object[] OptionalInfo { get; }

    }

}
