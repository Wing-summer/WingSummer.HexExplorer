namespace WSPEHexPluginHost
{
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
