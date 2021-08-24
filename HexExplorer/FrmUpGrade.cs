using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace HexExplorer
{

    public partial class FrmUpGrade : ToolWindowBase
    {
        private static FrmUpGrade upGrade;

        private delegate void UpdateProgram(Action<string> Log = null, Action<long, long> UpdateProgressBarValue = null);
        private UpdateProgram updateProgram;

        private readonly UpdateLib updateLib;

        public static FrmUpGrade Instance
        {
            get
            {
                if (upGrade == null || upGrade.IsDisposed)
                {
                    upGrade = new FrmUpGrade();
                }
                return upGrade;
            }
        }

        private FrmUpGrade()
        {
            InitializeComponent();
            updateLib = UpdateLib.Instance;
        }

        private void DownloadComplete(IAsyncResult result)
        {
            if (result.IsCompleted)
            {
                if (File.Exists(Program.AppUpDateBin))
                {
                    Process.Start(Program.AppUpDateBin);

                    //剩下的等待被杀死开始安装
                }
                else
                {
                    Close();
                }
            }
        }

        private void Log(string log)
        {
            tbLog.AppendText($"\r\n>{log}");
        }


        private void FrmUpGrade_Shown(object sender, EventArgs e)
        {
            var info = updateLib.GetUpdateInfo();
            if (info != null)
            {
                if (MessageBox.Show($"获取到更新：版本号为{info.ver}，大小为{info.size}，您确定要更新吗？\n" +
                    $"【注：更新前请一定要保存好您的更改，否则会导致全部丢失】", Program.AppName,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    updateProgram = updateLib.UpdateProgramNewest;
                    updateProgram.BeginInvoke(Log, UpdateProgressBarValue, DownloadComplete, null);
                }
            }
        }

        private void UpdateProgressBarValue(long recieved, long total)
        {
            proBar.Value = (int)(recieved / total);
        }

    }
}
