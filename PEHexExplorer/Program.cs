using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace PEHexExplorer
{
    internal static class Program
    {

        internal static readonly string SoftwareName="羽云PE浏览器";
        internal static readonly string AppDir = AppDomain.CurrentDomain.BaseDirectory;
        internal static readonly string AppConfig = AppDir + "config.dat";
        internal static readonly string AppErrDir = AppDir + "Error";
        internal static UserSetting userSetting;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {

#if !DEBUG
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
#endif
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            userSetting = new UserSetting();

            userSetting.Load();

            if (args.Length>0)
                Application.Run(new FrmMain(args[0]));
            else
                Application.Run(new FrmMain());

        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            userSetting.Save();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Directory.CreateDirectory(AppErrDir);
            string errfile = $"{AppErrDir}\\{DateTime.UtcNow.ToBinary()}.log";
            File.WriteAllText(errfile, e.ExceptionObject.ToString());
            MessageBox.Show(
                $"恭喜你，你发现了一个Bug，已将错误信息填入{errfile}文件，" +
                $"请在开发者的开发仓库提 Issue 并将其附上并描述触发操作，感谢您对开源软件做出的贡献！",
                SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}