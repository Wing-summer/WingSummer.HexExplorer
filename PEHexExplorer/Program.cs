using System;
using System.Windows.Forms;

namespace PEHexExplorer
{
    internal static class Program
    {

        internal static readonly string SoftwareName="羽云PE浏览器";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}