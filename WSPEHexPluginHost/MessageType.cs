namespace WSPEHexPluginHost
{
    /// <summary>
    /// 插件与宿主通信所用消息类型
    /// 如果包含“（请求）”则说明插件可向宿主发送请求消息
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 插件加载中
        /// </summary>
        PluginLoading,
        /// <summary>
        /// 插件加载完毕时
        /// </summary>
        PluginLoaded,
        /// <summary>
        /// 插件请求操作出现错误时
        /// </summary>
        ErrorMessage,
        /// <summary>
        /// 获取多文档当前或者指定打开索引
        /// </summary>
        PageIndex,
        /// <summary>
        /// （请求）新建文件
        /// </summary>
        NewFile,
        /// <summary>
        /// （请求）打开文件
        /// </summary>
        OpenFile,
        /// <summary>
        /// （请求）打开进程
        /// </summary>
        OpenProcess,
        /// <summary>
        /// （请求）另存为
        /// </summary>
        SaveAs,
        /// <summary>
        /// （请求）保存
        /// </summary>
        Save,
        /// <summary>
        /// （请求）导出
        /// </summary>
        Export,
        /// <summary>
        /// 请求宿主退出
        /// </summary>
        HostQuit,
        /// <summary>
        /// （请求）关闭文件
        /// </summary>
        CloseFile,
        /// <summary>
        /// （请求）拷贝
        /// </summary>
        Copy,
        /// <summary>
        /// （请求）十六进制拷贝
        /// </summary>
        CopyHex,
        /// <summary>
        /// （请求）粘贴
        /// </summary>
        Paste,
        /// <summary>
        /// （请求）十六进制粘贴
        /// </summary>
        PasteHex,
        /// <summary>
        /// （请求）删除
        /// </summary>
        Delete,
        /// <summary>
        /// （请求）查找
        /// </summary>
        Find,
        /// <summary>
        /// （请求）新建插入数据块
        /// </summary>
        NewInsert,
        /// <summary>
        /// （请求）填充
        /// </summary>
        Fill,
        /// <summary>
        /// （请求）跳转
        /// </summary>
        Goto,
        /// <summary>
        /// （请求）全选
        /// </summary>
        SelectAll,
        /// <summary>
        /// （请求）剪切
        /// </summary>
        Cut,
        /// <summary>
        /// （请求）写入
        /// </summary>
        Write,
        /// <summary>
        /// （请求）读取
        /// </summary>
        Read,
        /// <summary>
        /// （请求）插入
        /// </summary>
        Insert,
        /// <summary>
        /// （请求）打开PE底色显示
        /// </summary>
        ShowPEInfo,
        /// <summary>
        /// （请求）关闭PE底色显示
        /// </summary>
        HidePEInfo,
        /// <summary>
        /// （请求）隐藏行信息
        /// </summary>
        HideLineInfo,
        /// <summary>
        /// （请求）显示行信息
        /// </summary>
        ShowLineInfo,
        /// <summary>
        /// （请求）隐藏列信息
        /// </summary>
        HideColInfo,
        /// <summary>
        /// （请求）显示列信息
        /// </summary>
        ShowColInfo,

    }

}
