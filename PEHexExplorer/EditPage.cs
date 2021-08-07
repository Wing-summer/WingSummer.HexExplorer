using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Be.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using PEProcesser;

namespace PEHexExplorer
{
    public class EditPage : TabPage
    {

        public class CloseFileArgs : EventArgs
        {
            public bool? info;
        }

        public enum EditorMessageType
        {
            All,
            Scaling,
            CurrentLine,
            CurrentPositionInLine,
            InsertActive,
            SavedStatus,
            LockedBuffer,
            SelectionLength,
            SelectionStart
        }

        public struct EditorMessage
        {
            public uint Scaling;
            public long CurrentLine;
            public long CurrentPositionInLine;
            public bool InsertActive;
            public bool SavedStatus;
            public bool LockedBuffer;
            public long SelectionLength;
            public long SelectionStart;

        }

        public class EditorPageMessageArgs : EventArgs
        {

            public EditorMessageType EditorMessageType;
            public EditorMessage EditorMessage;

            public override string ToString()
            {
                return "EditorPageMessageArgs";
            }
        }

        private readonly HexBox hexBox;
        private PEPParser pe;
        private BookMarkPE bookMark;

        public event EventHandler EnableEdit;
        public event EventHandler DisableEdit;
        public event EventHandler<EditorPageMessageArgs> HostMessagePipe;
        public event EventHandler<CloseFileArgs> ClosingFile;
        private EditorMessage  editorMessage =new EditorMessage();
       
        private const string DefaultFilename = "<未知>";
        private const string NewFilename = "<未命名文件>";

        [DefaultValue(DefaultFilename)]
        public string Filename
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
                Text = File.Exists(value) ? Path.GetFileName(value) : value;
            }
        }
        private string _filename;

        public HexBox HexBox => hexBox;

        [DefaultValue(-1)]
        public int Index { get; set; }

        public EditPage() 
        {
            MUserProfile mUser = UserSetting.UserProfile;

            hexBox = new HexBox
            {
                Parent = this,
                Dock = DockStyle.Fill,
                UseFixedBytesPerLine = true,
                StringViewVisible = true,
                SelectionBackColorOpacity = 100,
                ShowColumnInfoBackColor = true,
                ShowLineInfoBackColor = true,
                HScrollBarVisible=true,
                VScrollBarVisible=true,
                GroupSeparatorVisible=true,
                LineInfoAlignment= HorizontalAlignment.Center,
                LineInfoBackColor = mUser.LineInfoBackColor,
                ColumnInfoBackColor = mUser.ColInfoBackColor,
                LineInfoVisible = mUser.EnableLineInfo,
                ColumnInfoVisible = mUser.EnableColInfo,
                SelectionBackColor = mUser.SelBackColor,
                SelectionForeColor = mUser.SelTextColor,
                GroupLinePen = mUser.GroupLinePen,
                HexStringLinePen = mUser.HexStringLinePen
            };

            hexBox.CurrentLineChanged += HexBox_CurrentLineChanged;
            hexBox.ScalingChanged += HexBox_ScalingChanged;
            hexBox.CurrentPositionInLineChanged += HexBox_CurrentPositionInLineChanged;
            hexBox.InsertActiveChanged += HexBox_InsertActiveChanged;
            hexBox.LockedBufferChanged += HexBox_LockedBufferChanged;
            hexBox.SavedStatusChanged += HexBox_SavedStatusChanged;
            hexBox.SelectionLengthChanged += HexBox_SelectionLengthChanged;
            hexBox.SelectionStartChanged += HexBox_SelectionStartChanged;

            Controls.Add(hexBox);
        }

        private void HexBox_SelectionStartChanged(object sender, EventArgs e)
        {
            editorMessage.SelectionStart = hexBox.SelectionStart;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorMessageType = EditorMessageType.SelectionStart,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_SelectionLengthChanged(object sender, EventArgs e)
        {
            editorMessage.SelectionLength = hexBox.SelectionLength;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorMessageType = EditorMessageType.SelectionLength,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_SavedStatusChanged(object sender, EventArgs e)
        {
            editorMessage.SavedStatus = hexBox.ByteProvider.HasChanges();
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorMessageType = EditorMessageType.SavedStatus,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_LockedBufferChanged(object sender, EventArgs e)
        {
            editorMessage.LockedBuffer = hexBox.IsLockedBuffer;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorMessageType = EditorMessageType.LockedBuffer,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_InsertActiveChanged(object sender, EventArgs e)
        {
            editorMessage.InsertActive = hexBox.InsertActive;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorMessageType = EditorMessageType.InsertActive,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_CurrentPositionInLineChanged(object sender, EventArgs e)
        {
            editorMessage.CurrentPositionInLine = hexBox.CurrentPositionInLine;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorMessageType = EditorMessageType.CurrentPositionInLine,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_ScalingChanged(object sender, EventArgs e)
        {
            editorMessage.Scaling = (uint)(hexBox.Scaling * 100);
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorMessageType = EditorMessageType.Scaling,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_CurrentLineChanged(object sender, EventArgs e)
        {
            editorMessage.CurrentLine = hexBox.CurrentLine;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorMessageType = EditorMessageType.CurrentLine,
                EditorMessage = editorMessage
            });
        }

        ~EditPage()
        {
            CloseFile();
        }

        #region 文件操作相关

        /// <summary>
        /// 新建文件
        /// </summary>
        /// <returns></returns>
        public bool NewFile()
        {
            if (!hexBox.OpenFile(error: out _, force: true))
            {
                MessageBox.Show("新建文件失败！", Program.SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            Filename = NewFilename;
            return true;
        }

        /// <summary>
        /// 打开PE文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="writeable"></param>
        /// <param name="EnablePEParser"></param>
        /// <param name="tvPEStruct"></param>
        /// <returns></returns>
        public void OpenFile(string filename, bool writeable, bool EnablePEParser = true)
        {
            bool? res = Closefile();
            if (res.HasValue)
            {
                hexBox.Close();
                DisableEdit?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                return;
            }

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

            if (EnablePEParser)
            {
                pe?.Dispose();
                pe = new PEPParser(filename);
                bookMark = new BookMarkPE(pe);
                //bookMark.ApplyTreeView(in tvPEStruct);
                bookMark.ApplyHexbox(hexBox);
            }

            hexBox.InsertActive = false;
            Filename = filename;
            EnableEdit?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// 关闭文件
        /// </summary>
        public void CloseFile()
        {
            bool? res = Closefile();
            if (res.HasValue)
            {
                hexBox.Close();
                Filename = DefaultFilename;
                DisableEdit?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <returns>如果需要另存为，则返回false</returns>
        public bool SaveFile()
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
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// 另存为
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="isExport">是否仅导出文件</param>
        public void SaveFileAs(string filename, bool isExport = false)
        {
            if (filename==null)
            {
                throw new ArgumentNullException("filename");
            }

            if (hexBox.SaveFile(out HexBox.IOError oError, filename, isExport))
            {
                if (oError == HexBox.IOError.Exception)
                {
                    MessageBox.Show("保存文件失败！", Program.SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Filename = filename;
        }

        public void OpenProcess()
        {
            bool? res = Closefile();
            if (res.HasValue)
            {
                hexBox.Close();
                DisableEdit?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                return;
            }

            using (FrmProcess frmProcess = FrmProcess.Instance)
            {
                if (frmProcess.ShowDialog() == DialogResult.OK)
                {
                    FrmProcess.ProcessResult result = frmProcess.Result;
                    if (!hexBox.OpenProcessMemory(result.Process, result.writeable))
                    {
                        MessageBox.Show("打开进程失败，可能是由于权限不足导致！", Program.SoftwareName,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    EnableEdit?.Invoke(this, EventArgs.Empty);
                    pe?.Dispose();
                    Stream provider = (hexBox.ByteProvider as ProcessByteProvider).Stream;
                    provider.Position = 0;
                    pe = new PEPParser(provider);
                    bookMark = new BookMarkPE(pe);
                    //bookMark.ApplyTreeView(in tvPEStruct);
                    bookMark.ApplyHexbox(hexBox);
                    Filename = result.Process.ProcessName;
                }
            }
        }

        private bool? Closefile()
        {
            bool? res = hexBox.ByteProvider?.HasChanges();
            if (res.HasValue && res.Value)
            {
                if (ClosingFile==null)
                {
                    throw new NullReferenceException("必要事件未接入");
                }
                CloseFileArgs args = new CloseFileArgs();
                ClosingFile.Invoke(this, args);
                return args.info;
            }
            return true;
        }

        #endregion


        #region 需要进一步封装的HexBox方法


        #endregion

        /// <summary>
        /// 向 EditorPageManager 宿主发送自己的完整信息
        /// </summary>
        public void PostWholeMessage()
        {

        }

    }

}
