using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WSPEHexPluginHost
{
    public static class WSPEHexPluginLib
    {
        public const string Sig = "WingSummer";

        /// <summary>
        /// 获取Puid（Plugin Unique Identifier）
        /// </summary>
        /// <param name="plugin"></param>
        /// <returns></returns>
        public static string GetPuid(IWSPEHexPlugin plugin)
        {
            string tmp = $"{Sig}{plugin.PluginName}{plugin.Author}{plugin.Comment}{plugin.Version}";
            byte[] buffer = Encoding.ASCII.GetBytes(tmp);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] res = md5.ComputeHash(buffer);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in res)
            {
                stringBuilder.Append(item.ToString("X"));
            }
            return stringBuilder.ToString();
        }

        public static string GetPuid(string PluginName,string Author,string Comment, ushort Version)
        {
            string tmp = $"{Sig}{PluginName}{Author}{Comment}{Version}";
            byte[] buffer = Encoding.ASCII.GetBytes(tmp);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] res = md5.ComputeHash(buffer);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in res)
            {
                stringBuilder.Append(item.ToString("X"));
            }
            return stringBuilder.ToString();
        }

    }

    public enum MessageType
    {
        PluginLoading,
        PluginLoaded,
        NewFile,
        OpenFile,
        OpenProcess,
        SaveAs,
        Save,
        Export,
        HostQuit,
        CloseFile,
        Copy,
        CopyHex,
        Paste,
        PasteHex,
        Delete,
        Find,
        NewInsert,
        Fill,
        Goto,
        SelectAll,
        Cut,
        Write,
        Read,
        Inset,
        ShowPEInfo,
        HidePEInfo,
        HideLineInfo,
        ShowLineInfo,
        HideColInfo,
        ShowColInfo,

    }

    public class HostPluginArgs : EventArgs
    {
        public MessageType MessageType;
        public bool Cancel;
        public bool IsBefore;
        public object Content;

        public override string ToString()
        {
            return MessageType.ToString();
        }
    }

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

    /// <summary>
    /// 定义插件信息的重要接口，为了兼容性，必须尽量不能变化
    /// </summary>
    public interface IWSPEHexPlugin
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
        string Puid { get; }

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

        /// <summary>
        /// 插件内容
        /// </summary>
        IWSPEHexPluginBody PluginBody { get; }

    }

}
