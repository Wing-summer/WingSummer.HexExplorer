using System;
using System.Security.Cryptography;
using System.Collections.Generic;
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

    }

    public class HostPluginArgs : EventArgs
    {
        public MessageType MessageType;
        public object Content;
    }

    public interface IWSPEHexPluginBody
    {
        /*Version 0 beta*/

        ToolStripItem MenuPluginMenu { get; }

        ToolStripItem MenuToolMenu { get; }

        Action<object, HostPluginArgs> ToHostMessagePipe { get; set; }

        event EventHandler<HostPluginArgs> HostToMessagePipe;

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
