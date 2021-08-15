using System;
using System.IO;
using System.Windows.Forms;
using Be.Windows.Forms;
using System.ComponentModel;
using PEProcesser;

namespace PEHexExplorer
{
    public class EditPage : TabPage
    {

        public class CloseFileArgs : EventArgs
        {
            [DefaultValue(false)]
            public bool Cancel { get; set; }

        }

        public enum StrEncoding : int
        {
            ASCII,
            EBCDIC,
            Unicode
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
            SelectionStart,
            ApplyTreeView,
            Quit,
            LineInfoStatus,
            LineInfoBGStatus,
            ColInfoStatus,
            ColInfoBGStatus,
            GroupStatus,
            PEInfoStatus,
            StringStatus,
            EncodingChanged
        }

        public struct EditorMessage
        {
            public uint Scaling;
            public long CurrentLine;
            public long CurrentPositionInLine;
            public bool InsertActive;
            public bool HasChanges;
            public bool LockedBuffer;
            public long SelectionLength;
            public long SelectionStart;
            public bool LineInfo;
            public bool LineInfoBG;
            public bool ColInfo;
            public bool ColInfoBG;
            public bool GroupLine;
            public bool HexStr;
            public bool PEInfo;
            public StrEncoding Encoding;
        }

        public class EditorPageMessageArgs : EventArgs
        {
            public HexBox EditorHost;
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

        [DefaultValue(null)]
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
                StringViewVisible = mUser.EnableStringView,
                SelectionBackColorOpacity = 150,
                ShowColumnInfoBackColor = true,
                ShowLineInfoBackColor = true,
                HScrollBarVisible = true,
                VScrollBarVisible = true,
                GroupSeparatorVisible = true,
                ShowBookMark = true,
                ShowBookMarkMain=mUser.EnablePE,
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
            hexBox.LineInfoVisibleChanged += HexBox_LineInfoVisibleChanged;
            hexBox.ColumnInfoVisibleChanged += HexBox_ColumnInfoVisibleChanged;
            hexBox.ShowColumnInfoBackColorChanged += HexBox_ShowColumnInfoBackColorChanged;
            hexBox.ShowLineInfoBackColorChanged += HexBox_ShowLineInfoBackColorChanged;
            hexBox.StringViewVisibleChanged += HexBox_StringViewVisibleChanged;
            hexBox.GroupSeparatorVisibleChanged += HexBox_GroupSeparatorVisibleChanged;
            hexBox.ShowBookMarkMainChanged += HexBox_ShowBookMarkMainChanged;
            hexBox.EncodingChanged += HexBox_EncodingChanged;
            hexBox.InsertActiveChanged += HexBox_InsertActiveChanged;
            hexBox.LockedBufferChanged += HexBox_LockedBufferChanged;
            hexBox.SavedStatusChanged += HexBox_SavedStatusChanged;
            hexBox.SelectionLengthChanged += HexBox_SelectionLengthChanged;
            hexBox.SelectionStartChanged += HexBox_SelectionStartChanged;

            Controls.Add(hexBox);
        }

        private void HexBox_StringViewVisibleChanged(object sender, EventArgs e)
        {
            editorMessage.HexStr = hexBox.StringViewVisible;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.StringStatus,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_ShowBookMarkMainChanged(object sender, EventArgs e)
        {
            editorMessage.PEInfo = hexBox.ShowBookMarkMain;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.PEInfoStatus,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_SelectionStartChanged(object sender, EventArgs e)
        {
            editorMessage.SelectionStart = hexBox.SelectionStart;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost=hexBox,
                EditorMessageType = EditorMessageType.SelectionStart,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_SelectionLengthChanged(object sender, EventArgs e)
        {
            editorMessage.SelectionLength = hexBox.SelectionLength;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.SelectionLength,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_SavedStatusChanged(object sender, EventArgs e)
        {
            editorMessage.HasChanges = hexBox.ByteProvider.HasChanges();
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.SavedStatus,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_LockedBufferChanged(object sender, EventArgs e)
        {
            editorMessage.LockedBuffer = hexBox.IsLockedBuffer;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.LockedBuffer,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_InsertActiveChanged(object sender, EventArgs e)
        {
            editorMessage.InsertActive = hexBox.InsertActive;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.InsertActive,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_CurrentPositionInLineChanged(object sender, EventArgs e)
        {
            editorMessage.CurrentPositionInLine = hexBox.CurrentPositionInLine;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.CurrentPositionInLine,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_ScalingChanged(object sender, EventArgs e)
        {
            editorMessage.Scaling = (uint)(hexBox.Scaling * 100);
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.Scaling,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_CurrentLineChanged(object sender, EventArgs e)
        {
            editorMessage.CurrentLine = hexBox.CurrentLine;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.CurrentLine,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_LineInfoVisibleChanged(object sender, EventArgs e)
        {
            editorMessage.LineInfo = hexBox.LineInfoVisible;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.LineInfoStatus,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_ShowLineInfoBackColorChanged(object sender, EventArgs e)
        {
            editorMessage.LineInfoBG = hexBox.ShowLineInfoBackColor;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.LineInfoBGStatus,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_ColumnInfoVisibleChanged(object sender, EventArgs e)
        {
            editorMessage.ColInfo = hexBox.ColumnInfoVisible;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.ColInfoStatus,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_ShowColumnInfoBackColorChanged(object sender, EventArgs e)
        {
            editorMessage.ColInfoBG = hexBox.ShowColumnInfoBackColor;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.ColInfoBGStatus,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_GroupSeparatorVisibleChanged(object sender, EventArgs e)
        {
            editorMessage.GroupLine = hexBox.GroupSeparatorVisible;
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.GroupStatus,
                EditorMessage = editorMessage
            });
        }

        private void HexBox_EncodingChanged(object sender, EventArgs e)
        {
            editorMessage.Encoding = GetStrEncoding();
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.EncodingChanged,
                EditorMessage = editorMessage
            });
        }

        private StrEncoding GetStrEncoding()
        {
            string j = hexBox.ByteCharConverter.ToString();

            if (j[0] == 'A')        //ASCII
            {
                if (hexBox.IsCharToUnicode)
                {
                    return StrEncoding.Unicode;
                }
                else
                {
                    return StrEncoding.ASCII;
                }
            }
            else
            {
                return StrEncoding.EBCDIC;
            }
        }

        public void ChangeEncoding(int SelIndex)
        {
            switch (SelIndex)
            {
                case 0:
                    hexBox.ByteCharConverter = new DefaultByteCharConverter() ;
                    hexBox.IsCharToUnicode = false;
                    break;
                case 1:
                    hexBox.ByteCharConverter = new EbcdicByteCharProvider();
                    hexBox.IsCharToUnicode = false;
                    break;
                case 2:
                    hexBox.ByteCharConverter = new DefaultByteCharConverter();
                    hexBox.IsCharToUnicode = true;
                    break;
            }
        }

        public void ChangeLineInfoVisible()
            => hexBox.LineInfoVisible = !hexBox.LineInfoVisible;

        public void ChangeColInfoVisible()
            => hexBox.ColumnInfoVisible = !hexBox.ColumnInfoVisible;

        public void ChangeLineInfoBGVisible()
            => hexBox.ShowLineInfoBackColor = !hexBox.ShowLineInfoBackColor;

        public void ChangeColInfoBGVisible()
            => hexBox.ShowColumnInfoBackColor = !hexBox.ShowColumnInfoBackColor;

        public void ChangeHexStrVisible()
            => hexBox.StringViewVisible = !hexBox.StringViewVisible;

        public void ChangeGroupSepVisible()
            => hexBox.GroupSeparatorVisible = !hexBox.GroupSeparatorVisible;

        public void ChangePEInfoVisible()
            => hexBox.ShowBookMarkMain = !hexBox.ShowBookMarkMain;

        public void ChangeBaseAddr(long Base)
            => hexBox.BaseAddr = Base;

        /// <summary>
        /// 向 EditorPageManager 宿主发送自己的完整信息
        /// </summary>
        public void PostWholeMessage()
        {
            editorMessage.CurrentLine = hexBox.CurrentLine;
            editorMessage.CurrentPositionInLine = hexBox.CurrentPositionInLine;
            editorMessage.HasChanges = hexBox.ByteProvider.HasChanges();
            editorMessage.InsertActive = hexBox.InsertActive;
            editorMessage.LockedBuffer = hexBox.IsLockedBuffer;
            editorMessage.Scaling = (uint)(hexBox.Scaling * 100);
            editorMessage.SelectionLength = hexBox.SelectionLength;
            editorMessage.SelectionStart = hexBox.SelectionStart;
            editorMessage.LineInfo = hexBox.LineInfoVisible;
            editorMessage.LineInfoBG = hexBox.ShowLineInfoBackColor;
            editorMessage.ColInfo = hexBox.ColumnInfoVisible;
            editorMessage.ColInfoBG = hexBox.ShowColumnInfoBackColor;
            editorMessage.GroupLine = hexBox.GroupSeparatorVisible;
            editorMessage.PEInfo = hexBox.ShowBookMarkMain;
            editorMessage.HexStr = hexBox.StringViewVisible;
            editorMessage.Encoding = GetStrEncoding();
         
            HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
            {
                EditorHost = hexBox,
                EditorMessageType = EditorMessageType.All,
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
                MessageBox.Show("新建文件失败！", Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (res.HasValue&&res.Value)
            {
                return;
            }
            else
            {
                hexBox.Close();
                DisableEdit?.Invoke(this, EventArgs.Empty);
            }

        reopen:

            if (!hexBox.OpenFile(out HexBox.IOError error, filename, writeable))
            {
                if (error == HexBox.IOError.Exception && writeable)
                {
                    if (MessageBox.Show("文件无法以写入模式打开，可能被占用，您是否用只读模式打开？",
                        Program.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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

                HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
                {
                    EditorHost = hexBox,
                    EditorMessageType = EditorMessageType.ApplyTreeView,
                    EditorMessage = editorMessage
                });

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
        /// <returns>如果文件正常关闭，则返回true</returns>
        public bool CloseFile()
        {
            bool? res = Closefile();
            if (res == null || (res.HasValue && !res.Value))
            {
                hexBox.Close();
                Filename = DefaultFilename;
                DisableEdit?.Invoke(this, EventArgs.Empty);
                return true;
            }
            return false;
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
                        MessageBox.Show("保存文件失败！", Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("保存文件失败！", Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Filename = filename;
        }

        public bool OpenProcess()
        {
            bool? res = Closefile();
            if (res.HasValue && res.Value)
            {
                return false;
            }
            else
            {
                hexBox.Close();
                DisableEdit?.Invoke(this, EventArgs.Empty);
            }

            using (FrmProcess frmProcess = FrmProcess.Instance)
            {
                if (frmProcess.ShowDialog() == DialogResult.OK)
                {
                    FrmProcess.ProcessResult result = frmProcess.Result;
                    if (!hexBox.OpenProcessMemory(result.Process, result.writeable))
                    {
                        MessageBox.Show("打开进程失败，可能是由于权限不足导致！", Program.AppName,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    EnableEdit?.Invoke(this, EventArgs.Empty);
                    pe?.Dispose();
                    Stream provider = (hexBox.ByteProvider as ProcessByteProvider).Stream;
                    provider.Position = 0;
                    pe = new PEPParser(provider);
                    bookMark = new BookMarkPE(pe);

                    HostMessagePipe?.Invoke(this, new EditorPageMessageArgs
                    {
                        EditorHost = hexBox,
                        EditorMessageType = EditorMessageType.ApplyTreeView,
                        EditorMessage = editorMessage
                    });

                    //bookMark.ApplyTreeView(in tvPEStruct);
                    bookMark.ApplyHexbox(hexBox);
                    Filename = result.Process.ProcessName;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 返回值为真，说明被取消关闭；
        /// 返回为空，则无更改；
        /// 返回为假，文件已被正常关闭。
        /// </summary>
        /// <returns></returns>
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
                return args.Cancel;
            }
            return null;
        }

        public void ApplyContextMenuStrip(ContextMenuStrip menuStrip)
        {
            hexBox.ContextMenuStrip = menuStrip;
        }

        #endregion


        #region 需要进一步封装的方法

        public void ApplyTreeView(in TreeView treeView) => bookMark?.ApplyTreeView(treeView);

        public void Jmpto(long index)
        {
            hexBox.SelectionStart = index;
            hexBox.SelectionLength = 1;
            hexBox.ScrollByteIntoView(index);
            hexBox.Focus();
        }

        #endregion


    }

}
