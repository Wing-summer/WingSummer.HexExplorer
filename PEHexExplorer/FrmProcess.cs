using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PEHexExplorer
{
    public partial class FrmProcess : Form
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
                if (frmProcess==null||frmProcess.IsDisposed)
                {
                    frmProcess = new FrmProcess();
                }
                return frmProcess;
            }
        }

        public FrmProcess()
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
            processes = Process.GetProcesses();
            lbProcess.Items.Clear();
            foreach (var item in processes)
            {
                lbProcess.Items.Add($"{item.ProcessName}：{item.Id}");
            }
        }

        private void LbProcess_SelectedIndexChanged(object sender, EventArgs e) 
            => pg.SelectedObject = lbProcess.SelectedIndex >= 0 ? processes[lbProcess.SelectedIndex] : null;

        private void FrmProcess_FormClosed(object sender, FormClosedEventArgs e) => Dispose();

        private void MIOK_Click(object sender, EventArgs e) => SelectOk(true);
      
        private void MIOpenR_Click(object sender, EventArgs e) => SelectOk(false);

        private void SelectOk(bool writeable)
        {
            Process process = (Process)pg.SelectedObject;
            if (process != null)
            {
                Result = new ProcessResult { Process = process, writeable = writeable };
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("请选择进程！", Program.SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void MICancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

      
    }
}
