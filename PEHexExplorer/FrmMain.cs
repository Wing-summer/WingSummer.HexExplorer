using PEProcesser;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Be.Windows.Forms;
using System.Collections.Generic;

namespace PEHexExplorer
{
    public partial class FrmMain : Form
    {
        private PEPParser pe;

        private string EditFileExt = string.Empty;

        private PointF pos = new PointF(0, 0);

        private readonly Color EnabledColor = Color.Green;
        private readonly Color DisabledColor = Color.Red;
        private const string DefaultPoint = "(0,0)";
        private const string DefaultSel = "*";
        private const string DefaultFilename = "<未知>";
        private const string NewFilename = "<未命名文件>";

        private BookMarkPE bookMark;

        private readonly List<HexBox.HighlightedRegion> BookMarkregions;

        public FrmMain(string filename=null)
        {
            InitializeComponent();
            BookMarkregions = new List<HexBox.HighlightedRegion>();

            //begin：载入用户设置
            UserSetting.MUserProfile mUser = UserSetting.UserProfile;
            Font = mUser.ProgramFont;
            hexBox.LineInfoBackColor = mUser.LineInfoBackColor;
            hexBox.ColumnInfoBackColor = mUser.ColInfoBackColor;
            hexBox.LineInfoVisible = mUser.EnableLineInfo;
            hexBox.ColumnInfoVisible = mUser.EnableColInfo;
            hexBox.SelectionBackColor = mUser.SelBackColor;
            hexBox.SelectionForeColor = mUser.SelTextColor;
            hexBox.GroupLinePen = mUser.GroupLinePen;
            hexBox.HexStringLinePen = mUser.HexStringLinePen;
            //end：载入用户设置

            if (filename!=null)
            {
                filename = filename.Trim();

                if (filename.Length> 0 && File.Exists(filename))
                {
                    OpenFile(filename, true);
                }
            }

        }

        #region 窗体事件

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

        #endregion

        #region 文件IO相关

        private void OpenFile(string filename, bool writeable)
        {
            pe?.Dispose();
            pe = new PEPParser(filename);
            bookMark = new BookMarkPE(pe);
            bookMark.ApplyTreeView(in tvPEStruct);

        reopen:

            if (!hexBox.OpenFile(out HexBox.IOError error, filename, writeable))
            {
                if (error == HexBox.IOError.Exception && writeable)
                {
                    if (MessageBox.Show("文件无法以写入模式打开，可能被占用，您是否用只读模式打开？",
                        Program.SoftwareName, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        writeable = false;
                        goto reopen;
                    }
                }
            }

            bookMark.ApplyHexbox(hexBox);

            LblFilename.Text = hexBox.Filename;

            LblWritable.ForeColor = writeable ? EnabledColor : DisabledColor;

            hexBox.InsertActive = false;

            EnableEdit();
            EditFileExt = Path.GetExtension(filename).TrimStart('.');
        }

        private void MINew_Click(object sender, EventArgs e)
        {
            if (!hexBox.OpenFile(error: out _, force: true))
            {
                MessageBox.Show("新建文件失败！", Program.SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LblFilename.Text = NewFilename;
            EditFileExt = "bin";
            EnableEdit();
        }

        private void MIOpen_Click(object sender, EventArgs e)
        {
            if (oD.ShowDialog() == DialogResult.OK)
            {
                string filename = oD.FileName;
                bool writeable = !oD.ReadOnlyChecked;
                oD.FileName = string.Empty;
                OpenFile(filename, writeable);
            }
        }

        private void MISave_Click(object sender, EventArgs e)
        {
            if (hexBox.Filename.Length != 0)
            {
                if (!hexBox.SaveFile(out HexBox.IOError oError))
                {
                    if (oError == HexBox.IOError.Exception)
                    {
                        MessageBox.Show("保存文件失败！", Program.SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MISaveAs_Click(sender, e);
            }
        }

        private void MIExport_Click(object sender, EventArgs e)
        {
            sD.Filter = string.Format($"{{0}}文件|*.{{0}}", EditFileExt);
            if (sD.ShowDialog() == DialogResult.OK)
            {
                if (!hexBox.SaveFile(out HexBox.IOError oError, sD.FileName))
                {

                }
                sD.FileName = string.Empty;
            }
        }

        private void MISaveAs_Click(object sender, EventArgs e)
        {
            sD.Filter = string.Format("{0}文件|*.{0}", EditFileExt);
            if (sD.ShowDialog() == DialogResult.OK)
            {
                if (hexBox.SaveFile(out HexBox.IOError oError, sD.FileName, false))
                {
                    if (oError == HexBox.IOError.Exception)
                    {
                        MessageBox.Show("保存文件失败！", Program.SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                sD.FileName = string.Empty;
            }
        }

        private void MIClose_Click(object sender, EventArgs e)
        {
            hexBox.CloseFile(false);
            DisableEdit();
        }


        #endregion

        #region 文件操作相关

        private void MISelectAll_Click(object sender, EventArgs e) => hexBox.SelectAll();

        private void MICut_Click(object sender, EventArgs e) => hexBox.Cut();

        private void MICopy_Click(object sender, EventArgs e) => hexBox.Copy();

        private void MICopyHex_Click(object sender, EventArgs e) => hexBox.CopyHex();

        private void MIPaste_Click(object sender, EventArgs e) => hexBox.Paste();

        private void MIPasteHex_Click(object sender, EventArgs e) => hexBox.PasteHex();

        private void MIDel_Click(object sender, EventArgs e) => hexBox.Delete();

        private void MIInsert_Click(object sender, EventArgs e)
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
            FrmFind frmFind = FrmFind.Instance;
            frmFind.HexBox = hexBox;
            frmFind.Show(this);
        }

        private void MIJmp_Click(object sender, EventArgs e)
        {
            using (FrmGoto frmGoto = FrmGoto.Instance)
            {
                if (frmGoto.ShowDialog() == DialogResult.OK)
                {
                    FrmGoto.GotoResult result = frmGoto.Result;
                    if (result.IsRow)
                    {
                        if (!hexBox.ScrollLineIntoView((long)result.Number))
                        {
                            MessageBox.Show("跳转失败！", Program.SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } 
                    }
                    else
                    {
                        if (!hexBox.GotoByOffset((long)result.Number, result.IsFromBase))
                        {
                            MessageBox.Show("跳转失败！", Program.SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
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

        private void MIFillZero_Click(object sender, EventArgs e) => hexBox.WriteBytes(hexBox.SelectionStart, 0, hexBox.SelectionLength);

        private void MIFillNop_Click(object sender, EventArgs e) => hexBox.WriteBytes(hexBox.SelectionStart, 0x90, hexBox.SelectionLength);

        #endregion

        #region HexBox事件

        private void HexBox_ScalingChanged(object sender, EventArgs e)
        {
            LblScale.Text = string.Format("{0}%", hexBox.Scaling * 100);
        }

        private void HexBox_CurrentLineChanged(object sender, EventArgs e)
        {
            pos.X = hexBox.CurrentLine;
            LblLocation.Text = string.Format("({0},{1})", pos.X - 1, pos.Y - 1);
        }

        private void HexBox_CurrentPositionInLineChanged(object sender, EventArgs e)
        {
            pos.Y = hexBox.CurrentPositionInLine;
            LblLocation.Text = string.Format("({0},{1})", pos.X - 1, pos.Y - 1);
        }

        private void HexBox_InsertActiveChanged(object sender, EventArgs e) =>
            lblInsert.ForeColor = hexBox.InsertActive ? EnabledColor : DisabledColor;

        private void HexBox_ContentChanged(object sender, EventArgs e) =>
            LblSaved.ForeColor = hexBox.ByteProvider.HasChanges() ? DisabledColor : EnabledColor;

        private void HexBox_LockedBufferChanged(object sender, EventArgs e) =>
            lblLocked.ForeColor = hexBox.IsLockedBuffer ? EnabledColor : DisabledColor;

        private void HexBox_SelectionLengthChanged(object sender, EventArgs e) => 
            LblLen.Text = string.Format("{0:D} - 0x{0:X}", hexBox.SelectionLength);

        private void HexBox_ByteProviderChanged(object sender, EventArgs e) => hexBox.ClearHighlightedRegion();

        #endregion

        #region 编辑和文件状态相关

        private void LblScale_DoubleClick(object sender, EventArgs e) => hexBox.Scaling = 1.0F;

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

            LblSaved.Enabled = false;
            lblInsert.Enabled = false;
            lblLocked.Enabled = false;
            LblWritable.Enabled = false;

            LblFilename.Text = DefaultFilename;
            LblLocation.Text = DefaultPoint;
            LblLen.Text = DefaultSel;

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

            LblSaved.Enabled = true;
            lblInsert.Enabled = true;
            lblLocked.Enabled = true;
            LblWritable.Enabled = true;
        }

        private void LblInsert_Click(object sender, EventArgs e)
        {
            if (hexBox.ReadOnly)
            {
                return;
            }
            else
            {
                if (hexBox.InsertActive)
                {
                    hexBox.InsertActive = false;
                    lblInsert.ForeColor = DisabledColor;
                }
                else
                {
                    hexBox.InsertActive = true;
                    lblInsert.ForeColor = EnabledColor;
                }
            }
        }

        private void LblLocked_Click(object sender, EventArgs e) => hexBox.IsLockedBuffer = !hexBox.IsLockedBuffer;

        private void LblFilename_TextChanged(object sender, EventArgs e) => LblFilename.ToolTipText = LblFilename.Text;

        #endregion

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

        #region 实用性相关

        private void MICalculator_Click(object sender, EventArgs e) => Process.Start("calc");

        private void MIExit_Click(object sender, EventArgs e) => Application.Exit();

        private void MIGeneral_Click(object sender, EventArgs e)
        {
            using (FrmSetting setting = FrmSetting.Instance)
            {
                setting.ShowDialog();
            }
        }

        private void MIPlugin_Click(object sender, EventArgs e)
        {
           
        }

        private void MIBookMark_Click(object sender, EventArgs e)
        {
            int res = BookMarkregions.FindIndex(k => k.IsByteSelected(hexBox.SelectionStart));
            if (!hexBox.RemoveHighlightedRegionAt(res))
            {
                hexBox.AddHighligedRegion(new HexBox.HighlightedRegion
                {
                    Color = Color.AliceBlue,
                    Length = hexBox.SelectionLength == 0 ? 1 : hexBox.SelectionLength,
                    Start = hexBox.SelectionStart
                });
            }
        }

        private void MIAboutThis_Click(object sender, EventArgs e)
        {
            using (FrmAbout frmAbout = FrmAbout.Instance)
            {
                frmAbout.ShowDialog();
            }
        }

        #endregion
      
    }
}