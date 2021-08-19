using System;
using System.Windows.Forms;
using System.IO;

namespace PEHexExplorer
{
    internal static class Program
    {

        internal static readonly string AppName="羽云PE浏览器";
        internal static readonly string AppDir = AppDomain.CurrentDomain.BaseDirectory;
        internal static readonly string AppConfig = AppDir + "config.dat";
        internal static readonly string AppErrDir = AppDir + "Error";
        internal static readonly string AppPlugin = AppDir + "Plugin";
        internal static readonly string AppUpDate = AppDir + "Update";
        internal static readonly string AppUpDateBin = AppUpDate + "\\update.exe";
        internal static UserSetting userSetting;
        internal static float Version = 1.0F;

        internal const ulong Int64Max = (1UL << 63) - 1;

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
         
            SingleInstanceHelper instanceHelper = SingleInstanceHelper.SingleInstance;
            instanceHelper.IsSingleApp = true;
            if (instanceHelper.IsFirstStartUp)
            {
                userSetting = new UserSetting();
                userSetting.Load();
            }

            AdminLib adminLib = AdminLib.Instance;
            if (UserSetting.UserProfile.AdminStart && !adminLib.IsAdmin)
            {
                adminLib.RestartAsAdmin();
            }

            instanceHelper.Run(typeof(FrmMain), args, true, args);
            //启动新实例事件相应写到FrmMain中实现订阅

        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            userSetting?.Save();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (ex.InnerException is DllNotFoundException)
            {
                MessageBox.Show(ex.InnerException.Message, AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Directory.CreateDirectory(AppErrDir);
            string errfile = $"{AppErrDir}\\{DateTime.UtcNow.ToBinary()}.log";
            File.WriteAllText(errfile, e.ExceptionObject.ToString());
            MessageBox.Show(
                $"恭喜你，你发现了一个Bug，已将错误信息填入{errfile}文件，" +
                $"请在开发者的开发仓库提 Issue 并将其附上并描述触发操作，感谢您对开源软件做出的贡献！",
                AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}