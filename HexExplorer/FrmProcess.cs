using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace HexExplorer
{
    public partial class FrmProcess : ToolWindowBase
    {
        private Process[] processes;
        private static FrmProcess frmProcess;

        public struct ProcessResult
        {
            public Process Process;
            public bool writeable;
        }

        public ProcessResult Result
        {
            get;set;
        }

        public static FrmProcess Instance
        {
            get
            {
                if (frmProcess == null || frmProcess.IsDisposed)
                {
                    frmProcess = new FrmProcess();
                }
                return frmProcess;
            }
        }

        private FrmProcess()
        {
            InitializeComponent();
            GetProcesses();
        }

        private void MIRefresh_Click(object sender, EventArgs e)
        {
            GetProcesses();
        }

        private void GetProcesses()
        {
            if (processes != null)
                foreach (var item in processes)
                    item?.Dispose();

            processes = Process.GetProcesses();
            lbProcess.Items.Clear();
            foreach (var item in processes)
            {
                lbProcess.Items.Add($"{item.ProcessName}：{item.Id}");
            }
        }

        private void LbProcess_SelectedIndexChanged(object sender, EventArgs e) 
            => pg.SelectedObject = lbProcess.SelectedIndex >= 0 ? processes[lbProcess.SelectedIndex] : null;

        private void FrmProcess_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var item in processes)
                item?.Dispose();

            Dispose();
        }

        private void MIOK_Click(object sender, EventArgs e) => SelectOk(true);
      
        private void MIOpenR_Click(object sender, EventArgs e) => SelectOk(false);

        private void SelectOk(bool writeable)
        {
            Process process = (Process)pg.SelectedObject;
            if (process != null)
            {
                try
                {
                    if (process.MaxWorkingSet == IntPtr.Zero) { }
                }
                catch 
                {
                    if (MessageBox.Show("读取该程序可能需要管理员权限，建议请以管理员身份启动该程序后重试操作。您是否要继续吗？",
                        Program.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.No)
                    {
                        return;
                    }
                
                }
               
                Result = new ProcessResult { Process = process, writeable = writeable };
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("请选择进程！", Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void MICancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchitem = txtSearch.Text.Trim();
            if (searchitem.Length == 0)
            {
                return;
            }
            foreach (string item in lbProcess.Items)
            {
                if (item.IndexOf(searchitem, 0, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    lbProcess.SelectedItem = item;
                    break;
                }
            }
        }

        private void FrmProcess_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                MICancel_Click(sender, e);
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (e.Control && !e.Alt)
                {
                    if (e.Shift)
                    {
                        MIOpenR_Click(sender, e);
                    }
                    else
                    {
                        MIOK_Click(sender, e);
                    }
                }
            }

        }
    }
}
