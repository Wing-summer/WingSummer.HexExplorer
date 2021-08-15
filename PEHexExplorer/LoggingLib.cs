using System.Text;
using WSPEHexPluginHost;

namespace PEHexExplorer
{
    class LoggingLib
    {

        private static LoggingLib loggingLib = null;
        public static LoggingLib Instance
        {
            get
            {
                if (loggingLib==null)
                {
                    loggingLib = new LoggingLib();
                }
                return loggingLib;
            }
        }

        public string LogInfo => log.ToString();

        private readonly StringBuilder log;
        private const string LoadSuccess = "加载成功：";
        private const string LoadErr = "加载失败：";
        private const string Header = ">> ";
        private const string SuccessResion = "已注册！！！";
        private const string spt = " --> ";
        private const string InfoHeader = "【信息】";

        private LoggingLib()
        {
            log = new StringBuilder();
        }

        public void WriteInfo<T>(T info)
        {
            log.Append(info);
        }

        public void WriteLineInfo<T>(T info)
        {
            log.AppendLine(info.ToString());
        }

        public void WritePluginInfo(IWSPEHexPlugin plugin, bool LoadedSuccess = true, string Resion = SuccessResion)
        {
            log.AppendLine($" {Header}{(LoadedSuccess ? LoadSuccess : LoadErr)}{plugin.PluginName}{spt}{Resion}");
            if (LoadedSuccess)
            {
                log.AppendLine($" {plugin.PluginBody.MenuPluginMenu.Text}{spt}{SuccessResion}");
                var tmp = plugin.PluginBody.MenuToolMenu;
                if (tmp != null)
                    log.AppendLine($" {tmp.Text}{spt}{SuccessResion}");
                log.AppendLine(InfoHeader);
                log.AppendLine($" 作者：{plugin.Author}\r\n 说明：{plugin.Comment}\r\n 版本：{plugin.Version}");
                log.AppendLine($" 可选头个数：{(plugin.OptionalInfo != null ? plugin.OptionalInfo.Length : -1)}\r\n 插件标识符：{plugin.Puid}");
                log.AppendLine();
            }
        }

        public void Clear() => log.Clear();

    }
}
