using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace PEHexExplorer
{
    class AdminLib
    {
        private static AdminLib adminLib;
        private readonly bool isAdmin;

        public bool IsAdmin => isAdmin;
        public static AdminLib Instance
        {
            get
            {
                if (adminLib == null)
                {
                    adminLib = new AdminLib();
                }
                return adminLib;
            }
        }

        private AdminLib()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            if (principal.IsInRole(WindowsBuiltInRole.Administrator))
                isAdmin = true;
        }

        public void RestartAsAdmin()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = Process.GetCurrentProcess().ProcessName,
                Verb = "runas",
                UseShellExecute = true,
                WorkingDirectory = Environment.CurrentDirectory,
            };

            try
            {
                Process.Start(startInfo);
                Environment.Exit(0);
            }
            catch
            {
                MessageBox.Show("管理员权限重启程序失败！", Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
