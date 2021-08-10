using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Be.Windows.Forms;
using System.Security.Principal;
using System.Collections.Generic;

namespace PEHexExplorer
{
    public partial class FrmMain : FormBase
    {
        readonly EditorPageManager pageManager;

        private readonly string EditFileExt = string.Empty;

        private PointF pos = new PointF(0, 0);

        private readonly Color EnabledColor = Color.Green;
        private readonly Color DisabledColor = Color.Red;
        private const string DefaultPoint = "(0,0)";
        private const string DefaultScaling = "100%";
        private const string DefaultFilename = "<未知>";
        private const string DefaultSel = "*";
        private readonly ConstInfo constInfo;


        private readonly List<HexBox.HighlightedRegion> BookMarkregions;



        public FrmMain(string filename = null)
        {
            InitializeComponent();

            tscbEncoding.SelectedIndex = 0;
            tvPEStruct.ExpandAll();

            /*修复首次在HexBox右击打开菜单的位置等同于在主菜单点击编辑的Bug*/
            MenuItemEdit.ShowDropDown();

            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                MIAdmin.Click -= MIAdmin_Click;
                ts13.Dispose();
                MIAdmin.Dispose();
                MenuItemFile.Image = SystemIcons.Shield.ToBitmap();
            }
            else
            {
                MIAdmin.Image = SystemIcons.Shield.ToBitmap();
            }

            BookMarkregions = new List<HexBox.HighlightedRegion>();

            //begin：载入用户设置
            MUserProfile mUser = UserSetting.UserProfile;
            Font = mUser.ProgramFont;

            pageManager = new EditorPageManager(tabEditArea,hexMenuStrip);
            pageManager.EditorPageChanged += PageManager_EditorPageChanged;
            pageManager.EditorPageMessagePipe += PageManager_EditorPageMessagePipe;
            pageManager.EditorPageClosing += PageManager_EditorPageClosing;

            //end：载入用户设置

            if (filename != null)
            {
                filename = filename.Trim();

                if (filename.Length > 0 && File.Exists(filename))
                {
                    pageManager.OpenOrCreateFilePage(filename);
                }
            }

            constInfo = new ConstInfo();
            pgConst.SelectedObject = constInfo;
        }

        private void PageManager_EditorPageClosing(object sender, EditPage.CloseFileArgs e)
        {
            DialogResult result = MessageBox.Show("此文件已有修改，你确定要丢弃吗？",
                    Program.SoftwareName, MessageBoxButtons.YesNoCancel);
            switch (result)
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    MISave_Click(this, EventArgs.Empty);
                    e.Cancel = false;
                    break;
                case DialogResult.No:
                    e.Cancel = false;
                    break;
            }
        }

        private void PageManager_EditorPageMessagePipe(object sender, EditPage.EditorPageMessageArgs e)
        {
            switch (e.EditorMessageType)
            {
                case EditPage.EditorMessageType.All:
                    HexBox_ScalingChanged(e.EditorMessage.Scaling);
                    HexBox_CurrentLineChanged(e.EditorMessage.CurrentLine);
                    HexBox_CurrentPositionInLineChanged(e.EditorMessage.CurrentPositionInLine);
                    HexBox_InsertActiveChanged(e.EditorMessage.InsertActive);
                    HexBox_ContentChanged(e.EditorHost == null, e.EditorMessage.HasChanges);
                    HexBox_LockedBufferChanged(e.EditorMessage.LockedBuffer);
                    HexBox_SelectionLengthChanged(e.EditorMessage.SelectionLength);
                    HexBox_CurrentPositionChanged(e.EditorMessage.SelectionStart);
                    tbLineInfo.Checked = e.EditorMessage.LineInfo;
                    tbLineBg.Checked = e.EditorMessage.LineInfoBG;
                    tbColInfo.Checked = e.EditorMessage.ColInfo;
                    tbColBg.Checked = e.EditorMessage.ColInfoBG;
                    tbGroupSep.Checked = e.EditorMessage.GroupLine;
                    tbPEInfo.Checked = e.EditorMessage.PEInfo;
                    tbString.Checked = e.EditorMessage.HexStr;
                    tscbEncoding.SelectedIndex = (int)e.EditorMessage.Encoding;
                    break;
                case EditPage.EditorMessageType.Scaling:
                    HexBox_ScalingChanged(e.EditorMessage.Scaling);
                    break;
                case EditPage.EditorMessageType.CurrentLine:
                    HexBox_CurrentLineChanged(e.EditorMessage.CurrentLine);
                    break;
                case EditPage.EditorMessageType.CurrentPositionInLine:
                    HexBox_CurrentPositionInLineChanged(e.EditorMessage.CurrentPositionInLine);
                    break;
                case EditPage.EditorMessageType.InsertActive:
                    HexBox_InsertActiveChanged(e.EditorMessage.InsertActive);
                    break;
                case EditPage.EditorMessageType.SavedStatus:
                    HexBox_ContentChanged(e.EditorHost == null, e.EditorMessage.HasChanges);
                    break;
                case EditPage.EditorMessageType.LockedBuffer:
                    HexBox_LockedBufferChanged(e.EditorMessage.LockedBuffer);
                    break;
                case EditPage.EditorMessageType.SelectionLength:
                    HexBox_SelectionLengthChanged(e.EditorMessage.SelectionLength);
                    break;
                case EditPage.EditorMessageType.SelectionStart:
                    HexBox_CurrentPositionChanged(e.EditorMessage.SelectionStart);
                    break;
                case EditPage.EditorMessageType.ApplyTreeView:
                    
                    break;
                case EditPage.EditorMessageType.Quit:

                    break;
                case EditPage.EditorMessageType.LineInfoStatus:
                    tbLineInfo.Checked = e.EditorMessage.LineInfo;
                    break;
                case EditPage.EditorMessageType.LineInfoBGStatus:
                    tbLineBg.Checked = e.EditorMessage.LineInfoBG;
                    break;
                case EditPage.EditorMessageType.ColInfoStatus:
                    tbColInfo.Checked = e.EditorMessage.ColInfo;
                    break;
                case EditPage.EditorMessageType.ColInfoBGStatus:
                    tbColBg.Checked = e.EditorMessage.ColInfoBG;
                    break;
                case EditPage.EditorMessageType.GroupStatus:
                    tbGroupSep.Checked = e.EditorMessage.GroupLine;
                    break;
                case EditPage.EditorMessageType.PEInfoStatus:
                    tbPEInfo.Checked = e.EditorMessage.PEInfo;
                    break;
                case EditPage.EditorMessageType.StringStatus:
                    tbString.Checked = e.EditorMessage.HexStr;
                    break;
                case EditPage.EditorMessageType.EncodingChanged:
                    tscbEncoding.SelectedIndex = (int)e.EditorMessage.Encoding;
                    break;
                default:
                    break;
            }
        }

        private void PageManager_EditorPageChanged(object sender, EditorPageManager.EditorPageEventArgs e)
        {
            if (e.EditorPageData.EditEnabled)
            {
                EnableEdit();
            }
            else
            {
                DisableEdit();
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

        private void MINew_Click(object sender, EventArgs e) => pageManager.OpenOrCreateFilePage();

        private void MIOpen_Click(object sender, EventArgs e)
        {
            if (oD.ShowDialog() == DialogResult.OK)
            {
                string filename = oD.FileName;
                bool writeable = !oD.ReadOnlyChecked;
                oD.FileName = string.Empty;
                pageManager.OpenOrCreateFilePage(filename, writeable);
            }
        }

        private void MISave_Click(object sender, EventArgs e)
        {
            if (!pageManager.CurrentPage.SaveFile())
            {
                MISaveAs_Click(sender, e);
            }
        }

        private void MIExport_Click(object sender, EventArgs e)
        {
            sD.Filter = $"{EditFileExt}文件|*.{EditFileExt}";
            if (sD.ShowDialog() == DialogResult.OK)
            {
                pageManager.CurrentPage.SaveFileAs(sD.FileName, true);
                sD.FileName = string.Empty;
            }
        }

        private void MISaveAs_Click(object sender, EventArgs e)
        {
            sD.Filter = string.Format("{0}文件|*.{0}", EditFileExt);
            if (sD.ShowDialog() == DialogResult.OK)
            {
                pageManager.CurrentPage.SaveFileAs(sD.FileName, true);            
                sD.FileName = string.Empty;
            }
        }

        private void MIOpenProcess_Click(object sender, EventArgs e) => pageManager.OpenProcessPage();

        private void MIClose_Click(object sender, EventArgs e) => pageManager.CloseCurrentPage();

        #endregion

        #region 文件操作相关

        private void MISelectAll_Click(object sender, EventArgs e) => pageManager.CurrentHexBox.SelectAll();

        private void MICut_Click(object sender, EventArgs e) => pageManager.CurrentHexBox.Cut();

        private void MICopy_Click(object sender, EventArgs e) => pageManager.CurrentHexBox.Copy();

        private void MICopyHex_Click(object sender, EventArgs e) => pageManager.CurrentHexBox.CopyHex();

        private void MIPaste_Click(object sender, EventArgs e) => pageManager.CurrentHexBox.Paste();

        private void MIPasteHex_Click(object sender, EventArgs e) => pageManager.CurrentHexBox.PasteHex();

        private void MIDel_Click(object sender, EventArgs e) => pageManager.CurrentHexBox.Delete();

        private void MIInsert_Click(object sender, EventArgs e)
        {
            using (FrmInsert frmInsert = FrmInsert.Instance)
            {
                if (frmInsert.ShowDialog() == DialogResult.OK)
                {
                    pageManager.CurrentHexBox.InsertBytes(pageManager.CurrentHexBox.SelectionStart, frmInsert.Result.buffer);
                }
            }
        }

        private void MINewInsert_Click(object sender, EventArgs e)
        {
            using (FrmInsert frmInsert = FrmInsert.Instance)
            {
                if (frmInsert.ShowDialog() == DialogResult.OK)
                {
                    pageManager.CurrentHexBox.InsertBytes(pageManager.CurrentHexBox.SelectionStart, frmInsert.Result.buffer);
                }
            }
        }

        private void MIFind_Click(object sender, EventArgs e)
        {
            FrmFind frmFind = FrmFind.Instance;
            frmFind.HexBox = pageManager.CurrentHexBox;
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
                        if (!pageManager.CurrentHexBox.ScrollLineIntoView((long)result.Number))
                        {
                            MessageBox.Show("跳转失败！", Program.SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (!pageManager.CurrentHexBox.GotoByOffset((long)result.Number, result.IsFromBase))
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
                    HexBox hexBox = pageManager.CurrentHexBox;
                    byte[] buffer = frmFill.Result.buffer;
                    pageManager.CurrentHexBox.WriteBytes(hexBox.SelectionStart, buffer, hexBox.SelectionLength);
                }
            }
        }

        private void MIFillZero_Click(object sender, EventArgs e) 
            => pageManager.CurrentHexBox.WriteBytes
            (pageManager.CurrentHexBox.SelectionStart, 0, pageManager.CurrentHexBox.SelectionLength);

        private void MIFillNop_Click(object sender, EventArgs e) 
            => pageManager.CurrentHexBox.WriteBytes
            (pageManager.CurrentHexBox.SelectionStart, 0x90, pageManager.CurrentHexBox.SelectionLength);

        #endregion

        #region HexBox事件处理

        private void HexBox_ScalingChanged(uint scaling) => LblScale.Text = $"{scaling}%";

        private void HexBox_CurrentLineChanged(long CurrentLine)
        {
            pos.X = CurrentLine;
            LblLocation.Text = $"({pos.X - 1},{pos.Y - 1})";
        }

        private void HexBox_CurrentPositionInLineChanged(long CurrentPositionInLine)
        {
            pos.Y = CurrentPositionInLine;
            LblLocation.Text = $"({pos.X - 1},{pos.Y - 1})";
        }

        private void HexBox_InsertActiveChanged(bool InsertActive) =>
            lblInsert.ForeColor = InsertActive ? EnabledColor : DisabledColor;

        private void HexBox_ContentChanged(bool ByteProviderIsNull, bool HasChanges)
        {
            if (!ByteProviderIsNull)
            {
                LblSaved.ForeColor = HasChanges ? DisabledColor : EnabledColor;
            }
        }

        private void HexBox_LockedBufferChanged(bool IsLockedBuffer) =>
            lblLocked.ForeColor = IsLockedBuffer ? EnabledColor : DisabledColor;

        private void HexBox_SelectionLengthChanged(long SelectionLength) =>
            LblLen.Text = $"{SelectionLength:D} - 0x{SelectionLength:X}";

        private void HexBox_ByteProviderChanged(object sender, EventArgs e) => pageManager.CurrentHexBox.ClearHighlightedRegion();

        private void HexBox_CurrentPositionChanged(long SelectionStart)
        {
            long sels = SelectionStart;
            constInfo.Char = null;
            constInfo.Int = null;
            constInfo.Int16 = null;
            constInfo.Long = null;
            constInfo.UInt = null;
            constInfo.UInt16 = null;
            constInfo.ULong = null;

            //吃掉不必处理的异常
            try
            {
                if (pageManager.CurrentHexBox.ByteProvider?.Length != 0)
                {
                    constInfo.Char = pageManager.CurrentHexBox.ByteProvider?.ReadByte(sels);
                }
                constInfo.Int = pageManager.CurrentHexBox.Readint(sels);
                constInfo.Int16 = pageManager.CurrentHexBox.Readshort(sels);
                constInfo.Long = pageManager.CurrentHexBox.Readlong(sels);
                constInfo.UInt = (uint)constInfo?.Int;
                constInfo.UInt16 = (ushort)constInfo?.Int16;
                constInfo.ULong = (ulong)constInfo?.Long;
            }
            catch
            {
            }

            pgConst.Refresh();
        }

        #endregion

        #region 编辑和文件状态相关

        private void LblScale_DoubleClick(object sender, EventArgs e) => pageManager.CurrentHexBox.Scaling = 1.0F;

        private void DisableEdit()
        {
            hexMenuStrip.Enabled = false;
            toolStripHexEdit.Enabled = false;

            MISave.Enabled = false;
            MISaveAs.Enabled = false;
            MIExport.Enabled = false;
            MIClose.Enabled = false;

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

            if (pageManager.CurrentPage!=null)
            {
                LblFilename.Text = pageManager.CurrentPage.Filename;
            }
            else
            {
                LblFilename.Text = DefaultFilename;
            }

            LblScale.Text = DefaultScaling;
            LblLocation.Text = DefaultPoint;
            LblLen.Text = DefaultSel;

        }

        private void EnableEdit()
        {
            toolStripHexEdit.Enabled = true;
            hexMenuStrip.Enabled = true;
            foreach (var item in hexMenuStrip.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    (item as ToolStripMenuItem).Enabled = true;
                }
            }

            MISave.Enabled = true;
            MISaveAs.Enabled = true;
            MIExport.Enabled = true;
            MIClose.Enabled = true;

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
            if (pageManager.CurrentHexBox.ReadOnly)
            {
                return;
            }
            else
            {
                if (pageManager.CurrentHexBox.InsertActive)
                {
                    pageManager.CurrentHexBox.InsertActive = false;
                    lblInsert.ForeColor = DisabledColor;
                }
                else
                {
                    pageManager.CurrentHexBox.InsertActive = true;
                    lblInsert.ForeColor = EnabledColor;
                }
            }
        }

        private void LblLocked_Click(object sender, EventArgs e) => pageManager.CurrentHexBox.IsLockedBuffer = !pageManager.CurrentHexBox.IsLockedBuffer;

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
        private void MIAddrConverter_Click(object sender, EventArgs e)
        {
            FrmAddrConvert.Instance.Show(this);
        }

        private void MIPlugin_Click(object sender, EventArgs e)
        {
            using (FrmSetting setting = FrmSetting.Instance)
            {
                setting.IsPluginShow = true;
                setting.ShowDialog();
            }
        }

        private void MIBookMark_Click(object sender, EventArgs e)
        {
            int res = BookMarkregions.FindIndex(k => k.IsByteSelected(pageManager.CurrentHexBox.SelectionStart));
            if (!pageManager.CurrentHexBox.RemoveHighlightedRegionAt(res))
            {
                pageManager.CurrentHexBox.AddHighligedRegion(new HexBox.HighlightedRegion
                {
                    Color = Color.AliceBlue,
                    Length = pageManager.CurrentHexBox.SelectionLength == 0 ? 1 : pageManager.CurrentHexBox.SelectionLength,
                    Start = pageManager.CurrentHexBox.SelectionStart
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

        private void MIInfo_Click(object sender, EventArgs e) => scEdit.Panel2Collapsed = !scEdit.Panel2Collapsed;

        private void MIAdmin_Click(object sender, EventArgs e)
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
                MessageBox.Show("管理员权限重启程序失败！", Program.SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 状态栏

        private void LblFilename_Click(object sender, EventArgs e)
        {
            string filename = pageManager.CurrentHexBox.Filename;
            if (filename?.Length > 0)
            {
                Process.Start("Explorer.exe", $"/e,/select,{filename}");
            }
        }

        private void TscbEncoding_SelectedIndexChanged(object sender, EventArgs e) 
            => pageManager?.CurrentPage.ChangeEncoding(tscbEncoding.SelectedIndex);

        private void TbAddr_Click(object sender, EventArgs e)
        {
            using (FrmAddrBase frmAddr= FrmAddrBase.Instance)
            {
                if (frmAddr.ShowDialog()== DialogResult.OK)
                {
                    pageManager.CurrentPage.ChangeBaseAddr(frmAddr.Result);
                }
            }
        }

        private void TbLineInfo_Click(object sender, EventArgs e)
            => pageManager.CurrentPage.ChangeLineInfoVisible();

        private void TbLineBg_Click(object sender, EventArgs e)
            => pageManager.CurrentPage.ChangeLineInfoBGVisible();

        private void TbColInfo_Click(object sender, EventArgs e)
             => pageManager.CurrentPage.ChangeColInfoVisible();

        private void TbColBg_Click(object sender, EventArgs e)
            => pageManager.CurrentPage.ChangeColInfoBGVisible();

        private void TbGroupSep_Click(object sender, EventArgs e)
            => pageManager.CurrentPage.ChangeGroupSepVisible();

        private void TbPEInfo_Click(object sender, EventArgs e)
             => pageManager.CurrentPage.ChangePEInfoVisible();

        private void TbString_Click(object sender, EventArgs e)
            => pageManager.CurrentPage.ChangeHexStrVisible();

        #endregion



        private void TvPEStruct_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }


    }
}