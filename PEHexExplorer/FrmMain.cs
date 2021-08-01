using PEProcesser;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PEHexExplorer
{
    public partial class FrmMain : Form
    {
        private PEPParser pe;

        private string EditFileExt = string.Empty;

        private PointF pos = new PointF(0, 0);

        public FrmMain()
        {
            InitializeComponent();
        }

        private void MIOpen_Click(object sender, EventArgs e)
        {
            if (oD.ShowDialog() == DialogResult.OK)
            {
                string filename = oD.FileName;
                oD.FileName = string.Empty;
                pe?.Dispose();
                pe = new PEPParser(filename);
                hexBox.OpenFile(filename);
                EnableEdit();
                EditFileExt = Path.GetExtension(filename).TrimStart('.');
            }
        }

        private void hexBox_ScalingChanged(object sender, EventArgs e)
        {
            LblScale.Text = string.Format("{0}%", hexBox.Scaling * 100);
        }

        private void hexBox_CurrentLineChanged(object sender, EventArgs e)
        {
            pos.X = hexBox.CurrentLine;
            LblLocation.Text = string.Format("({0},{1})", pos.X - 1, pos.Y - 1);
        }

        private void hexBox_CurrentPositionInLineChanged(object sender, EventArgs e)
        {
            pos.Y = hexBox.CurrentPositionInLine;
            LblLocation.Text = string.Format("({0},{1})", pos.X - 1, pos.Y - 1);
        }

        private void LblScale_DoubleClick(object sender, EventArgs e)
        {
            hexBox.Scaling = 1.0F;
        }

        private void MICalculator_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }

        private void MIExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                if (MessageBox.Show("你确定退出程序吗？", "羽云PE浏览器", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void MISelectAll_Click(object sender, EventArgs e)
        {
            hexBox.SelectAll();
        }

        private void MICut_Click(object sender, EventArgs e)
        {
            hexBox.Cut();
        }

        private void MICopy_Click(object sender, EventArgs e)
        {
            hexBox.Copy();
        }

        private void MICopyHex_Click(object sender, EventArgs e)
        {
            hexBox.CopyHex();
        }

        private void MIPaste_Click(object sender, EventArgs e)
        {
            hexBox.Paste();
        }

        private void MIPasteHex_Click(object sender, EventArgs e)
        {
            hexBox.PasteHex();
        }

        private void MISave_Click(object sender, EventArgs e)
        {
            if (hexBox.Filename.Length != 0)
            {
                hexBox.SaveFile();
            }
            else
            {
                MISaveAs_Click(sender, e);
            }
        }

        private void MIExport_Click(object sender, EventArgs e)
        {
            sD.Filter = string.Format("{0}文件|*.{0}");
            if (sD.ShowDialog() == DialogResult.OK)
            {
                hexBox.SaveFile(sD.FileName);
                sD.FileName = string.Empty;
            }
        }

        private void MIAboutThis_Click(object sender, EventArgs e)
        {
            FrmAbout.Instance.ShowDialog();
        }

        private void MIDel_Click(object sender, EventArgs e)
        {
            hexBox.Delete();
        }

        private void MIInsert_Click(object sender, EventArgs e)
        {
            using (FrmInsert frmInsert=FrmInsert.Instance)
            {
                if (frmInsert.ShowDialog()== DialogResult.OK)
                {
                    hexBox.ByteProvider.InsertBytes(hexBox.SelectionStart, frmInsert.Result.buffer);
                    hexBox.Invalidate();
                }
            }
        }

        private void MINewInsert_Click(object sender, EventArgs e)
        {

            using (FrmInsert frmInsert = FrmInsert.Instance)
            {
                if (frmInsert.ShowDialog() == DialogResult.OK)
                {

                    hexBox.ByteProvider.InsertBytes(hexBox.SelectionStart, frmInsert.Result.buffer);
                    hexBox.Invalidate();
                }
            }
        }

        private void MIFind_Click(object sender, EventArgs e)
        {
        }

        private void MIJmp_Click(object sender, EventArgs e)
        {
            FrmGoto frmGoto = FrmGoto.Instance;
            if (frmGoto.ShowDialog() == DialogResult.OK)
            {
                FrmGoto.GotoResult result = frmGoto.Result;
                if (result.IsRow)
                {
                    hexBox.ScrollLineIntoView((long)result.Number);
                }
                else
                {
                    hexBox.GotoByOffset((long)result.Number, result.IsFromBase);
                }
            }
        }

        private void MIFill_Click(object sender, EventArgs e)
        {
            using (FrmFill frmFill = FrmFill.Instance)
            {
                if (frmFill.ShowDialog() == DialogResult.OK)
                {
                    hexBox.Delete();
                    hexBox.ByteProvider.InsertBytes(hexBox.SelectionStart, frmFill.Result.buffer);
                    hexBox.Invalidate();
                }
            }
        }

        private void MIFillZero_Click(object sender, EventArgs e)
        {
            hexBox.WriteBytes(hexBox.SelectionStart, 0, hexBox.SelectionLength);
        }

        private void MIFillNop_Click(object sender, EventArgs e)
        {
            hexBox.WriteBytes(hexBox.SelectionStart, 0x90, hexBox.SelectionLength);
        }

        private void MIBookMark_Click(object sender, EventArgs e)
        {
        }

        private void MIGeneral_Click(object sender, EventArgs e)
        {
            FrmSetting setting = FrmSetting.Instance;
            setting.ShowDialog();
        }

        private void MIPlugin_Click(object sender, EventArgs e)
        {
        }

        private void MISaveAs_Click(object sender, EventArgs e)
        {
            sD.Filter = string.Format("{0}文件|*.{0}", EditFileExt);
            if (sD.ShowDialog() == DialogResult.OK)
            {
                hexBox.SaveFile(sD.FileName, false);
                sD.FileName = string.Empty;
            }
        }

        private void MINew_Click(object sender, EventArgs e)
        {
            hexBox.OpenFile();
            EditFileExt = "bin";
            EnableEdit();
        }

        private void MIClose_Click(object sender, EventArgs e)
        {
            DisableEdit();
            hexBox.CloseFile(false);
        }

        private void DisableEdit()
        {
            hexMenuStrip.Enabled = false;

            tbExport.Enabled = false;
            tbSave.Enabled = false;
            tbSaveAs.Enabled = false;
            tbCut.Enabled = false;
            tbCopy.Enabled = false;
            tbPaste.Enabled = false;
            tbDel.Enabled = false;
            tbFill.Enabled = false;
            tbFillNop.Enabled = false;
            tbFillZero.Enabled = false;
            tbBookMark.Enabled = false;
            tbClose.Enabled = false;
        }

        private void EnableEdit()
        {
            hexMenuStrip.Enabled = true;
            foreach (var item in hexMenuStrip.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    (item as ToolStripMenuItem).Enabled = true;
                }
            }

            tbExport.Enabled = true;
            tbSave.Enabled = true;
            tbSaveAs.Enabled = true;
            tbCut.Enabled = true;
            tbCopy.Enabled = true;
            tbPaste.Enabled = true;
            tbDel.Enabled = true;
            tbFill.Enabled = true;
            tbFillNop.Enabled = true;
            tbFillZero.Enabled = true;
            tbBookMark.Enabled = true;
            tbClose.Enabled = true;
        }

        private void hexBox_SelectionLengthChanged(object sender, EventArgs e)
        {
            LblLen.Text = string.Format("{0:D} - 0x{0:X}", hexBox.SelectionLength);
        }

        #region 主状态栏ToolTip防闪烁解决方案

        private void ShowToolTipGroup_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripItem stripItem = sender as ToolStripItem;
            switch (stripItem.Tag)
            {
                case "1":
                    toolTip.Show(stripItem.ToolTipText, statusStrip, e.X + stripItem.Bounds.X, e.Y - statusStrip.Height);
                    break;

                case "2":
                    toolTip.Show(stripItem.ToolTipText, toolStrip, stripItem.Bounds.X + stripItem.Bounds.Width, toolStrip.Height);
                    break;
            }
        }

        private void HideToolTipGroup_MouseLeave(object sender, EventArgs e)
        {
            ToolStripItem stripItem = sender as ToolStripItem;
            switch (stripItem.Tag)
            {
                case "1":
                    toolTip.Hide(statusStrip);
                    break;

                case "2":
                    toolTip.Hide(toolStrip);
                    break;
            }
        }

        #endregion

        private void lblInsert_Click(object sender, EventArgs e)
        {

        }

        private void lblLocked_Click(object sender, EventArgs e)
        {

        }
    }
}