using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Be.Windows.Forms
{
    /// <summary>
    /// Represents a hex box control.
    /// </summary>
    [ToolboxBitmap(typeof(HexBox), "HexBox.bmp")]
    public partial class HexBox : Control
    {
        /// <summary>
        /// Initializes a new instance of a HexBox class.
        /// </summary>
        public HexBox()
        {
            _vScrollBar = new VScrollBar();
            _vScrollBar.Scroll += new ScrollEventHandler(ScrollBar_Scroll);

            _hScrollBar = new HScrollBar();
            _hScrollBar.Scroll += new ScrollEventHandler(ScrollBar_Scroll);

            BackColor = Color.White;
            Scaling = 1.0F;
            Font = SystemFonts.MessageBoxFont;

            _stringFormat = new StringFormat(StringFormat.GenericTypographic)
            {
                FormatFlags = StringFormatFlags.MeasureTrailingSpaces
            };

            ActivateEmptyKeyInterpreter();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            _vthumbTrackTimer.Interval = 50;
            _vthumbTrackTimer.Tick += new EventHandler(PerformVScrollThumbTrack);
            _hthumbTrackTimer.Interval = 50;
            _hthumbTrackTimer.Tick += new EventHandler(PerformHScrollThumbTrack);
        }

        #region Find methods

        /// <summary>
        /// Searches the current ByteProvider
        /// </summary>
        /// <param name="options">contains all find options</param>
        /// <returns>the SelectionStart property value if find was successfull or
        /// -1 if there is no match
        /// -2 if Find was aborted.</returns>
        public long Find(FindOptions options)
        {
            var startIndex = SelectionStart + SelectionLength;
            int match = 0;

            byte[] buffer1 = null;
            byte[] buffer2 = null;
            if (options.Type == FindType.Text && options.MatchCase)
            {
                if (options.FindBuffer == null || options.FindBuffer.Length == 0)
                    throw new ArgumentException("FindBuffer can not be null when Type: Text and MatchCase: false");
                buffer1 = options.FindBuffer;
            }
            else if (options.Type == FindType.Text && !options.MatchCase)
            {
                if (options.FindBufferLowerCase == null || options.FindBufferLowerCase.Length == 0)
                    throw new ArgumentException("FindBufferLowerCase can not be null when Type is Text and MatchCase is true");
                if (options.FindBufferUpperCase == null || options.FindBufferUpperCase.Length == 0)
                    throw new ArgumentException("FindBufferUpperCase can not be null when Type is Text and MatchCase is true");
                if (options.FindBufferLowerCase.Length != options.FindBufferUpperCase.Length)
                    throw new ArgumentException("FindBufferUpperCase and FindBufferUpperCase must have the same size when Type is Text and MatchCase is true");
                buffer1 = options.FindBufferLowerCase;
                buffer2 = options.FindBufferUpperCase;
            }
            else if (options.Type == FindType.Hex)
            {
                if (options.Hex == null || options.Hex.Length == 0)
                    throw new ArgumentException("Hex can not be null when Type is Hex");
                buffer1 = options.Hex;
            }

            int buffer1Length = buffer1.Length;

            _abortFind = false;

            for (long pos = startIndex; pos < _byteProvider.Length; pos++)
            {
                if (_abortFind)
                    return -2;

                if (pos % 1000 == 0) // for performance reasons: DoEvents only 1 times per 1000 loops
                    Application.DoEvents();

                byte compareByte = _byteProvider.ReadByte(pos);
                bool buffer1Match = compareByte == buffer1[match];
                bool hasBuffer2 = buffer2 != null;
                bool buffer2Match = hasBuffer2 && compareByte == buffer2[match];
                bool isMatch = buffer1Match || buffer2Match;
                if (!isMatch)
                {
                    pos -= match;
                    match = 0;
                    _findingPos = pos;
                    continue;
                }

                match++;

                if (match == buffer1Length)
                {
                    long bytePos = pos - buffer1Length + 1;
                    Select(bytePos, buffer1Length);
                    ScrollByteIntoView(_bytePos + _selectionLength);
                    ScrollByteIntoView(_bytePos);

                    return bytePos;
                }
            }

            return -1;
        }

        /// <summary>
        /// Aborts a working Find method.
        /// </summary>
        public void AbortFind()
        {
            _abortFind = true;
        }

        /// <summary>
        /// Gets a value that indicates the current position during Find method execution.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long CurrentFindingPosition
        {
            get
            {
                return _findingPos;
            }
        }

        #endregion

        #region Copy, Cut and Paste and Delete  methods

        private byte[] GetCopyData()
        {
            if (!CanCopy()) return new byte[0];

            // put bytes into buffer
            byte[] buffer = new byte[_selectionLength];
            int id = -1;
            for (long i = _bytePos; i < _bytePos + _selectionLength; i++)
            {
                id++;
                buffer[id] = _byteProvider.ReadByte(i);
            }
            return buffer;
        }

        /// <summary>
        /// Copies the current selection in the hex box to the Clipboard.
        /// </summary>
        public void Copy()
        {
            if (!CanCopy()) return;

            // put bytes into buffer
            byte[] buffer = GetCopyData();

            DataObject da = new DataObject();

            // set string buffer clipbard data

            string sBuffer = _isCharToUnicode ?
                Encoding.Unicode.GetString(buffer, 0, buffer.Length) : Encoding.ASCII.GetString(buffer, 0, buffer.Length);

            da.SetData(typeof(string), sBuffer);

            //set memorystream (BinaryData) clipboard data
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer, 0, buffer.Length, false, true);
            da.SetData("BinaryData", ms);

            Clipboard.SetDataObject(da, true);
            UpdateCaret();
            ScrollByteIntoView();
            Invalidate();

            Copied?.Invoke(this, null);
        }

        /// <summary>
        /// Return true if Copy method could be invoked.
        /// </summary>
        public bool CanCopy()
        {
            if (_selectionLength < 1 || _byteProvider == null)
                return false;

            return true;
        }

        /// <summary>
        /// Moves the current selection in the hex box to the Clipboard.
        /// </summary>
        public void Cut()
        {
            if (!CanCut()) return;

            Copy();

            byte[] buffer = new byte[_selectionLength];

            for (int i = 0; i < _selectionLength; i++)
            {
                buffer[i] = _byteProvider.ReadByte(_bytePos + i);
            }

            UndoStack.Push(SnapShotOperation(EditOperation.Delete, buffer));

            /*======================*/

            _byteProvider.DeleteBytes(_bytePos, _selectionLength);

            _byteCharacterPos = 0;
            UpdateCaret();
            ScrollByteIntoView();
            ReleaseSelection();
            Invalidate();
            Refresh();
        }

        /// <summary>
        /// 删除选定字节
        /// </summary>
        public void Delete()
        {
            if (!CanCut()) return;

            byte[] buffer = new byte[_selectionLength];

            for (int i = 0; i < _selectionLength; i++)
            {
                buffer[i] = _byteProvider.ReadByte(_bytePos + i);
            }

            UndoStack.Push(SnapShotOperation(EditOperation.Delete, buffer));

            /*======================*/

            _byteProvider.DeleteBytes(_bytePos, _selectionLength);

            _byteCharacterPos = 0;
            UpdateCaret();
            ScrollByteIntoView();
            ReleaseSelection();
            Invalidate();
            Refresh();
        }

        /// <summary>
        /// Return true if Cut method could be invoked.
        /// </summary>
        public bool CanCut()
        {
            if (ReadOnly || !Enabled)
                return false;
            if (_byteProvider == null)
                return false;
            if (_selectionLength < 1 || !_byteProvider.SupportsDeleteBytes())
                return false;

            return true;
        }

        /// <summary>
        /// Replaces the current selection in the hex box with the contents of the Clipboard.
        /// </summary>
        public void Paste()
        {
            if (!CanPaste()) return;

            if (_selectionLength > 0)
                _byteProvider.DeleteBytes(_bytePos, _selectionLength);

            IDataObject da = Clipboard.GetDataObject();

            byte[] buffer;
            if (da.GetDataPresent("BinaryData"))
            {
                System.IO.MemoryStream ms = (System.IO.MemoryStream)da.GetData("BinaryData");
                buffer = new byte[ms.Length];
                ms.Read(buffer, 0, buffer.Length);
            }
            else if (da.GetDataPresent(typeof(string)))
            {
                string sBuffer = (string)da.GetData(typeof(string));
                buffer = Encoding.ASCII.GetBytes(sBuffer);
            }
            else
            {
                return;
            }

            UndoStack.Push(SnapShotOperation(EditOperation.Insert, buffer));

            /*=========================*/

            _byteProvider.InsertBytes(_bytePos, buffer);

            SetPosition(_bytePos + buffer.Length, 0);

            ReleaseSelection();
            ScrollByteIntoView();
            UpdateCaret();
            Invalidate();
        }

        /// <summary>
        /// Return true if Paste method could be invoked.
        /// </summary>
        public bool CanPaste()
        {
            if (ReadOnly || !Enabled) return false;

            if (_byteProvider == null || !_byteProvider.SupportsInsertBytes())
                return false;

            if (!_byteProvider.SupportsDeleteBytes() && _selectionLength > 0)
                return false;

            IDataObject da = Clipboard.GetDataObject();
            if (da.GetDataPresent("BinaryData"))
                return true;
            else if (da.GetDataPresent(typeof(string)))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Return true if PasteHex method could be invoked.
        /// </summary>
        public bool CanPasteHex()
        {
            if (!CanPaste()) return false;
            IDataObject da = Clipboard.GetDataObject();
            if (da.GetDataPresent(typeof(string)))
            {
                string hexString = (string)da.GetData(typeof(string));
                byte[] buffer = ConvertHexToBytes(hexString);
                return (buffer != null);
            }
            return false;
        }

        /// <summary>
        /// Replaces the current selection in the hex box with the hex string data of the Clipboard.
        /// </summary>
        public void PasteHex()
        {
            if (!CanPaste()) return;
            IDataObject da = Clipboard.GetDataObject();

            byte[] buffer;
            if (da.GetDataPresent(typeof(string)))
            {
                string hexString = (string)da.GetData(typeof(string));
                buffer = ConvertHexToBytes(hexString);
                if (buffer == null)
                    return;
            }
            else
            {
                return;
            }

            if (_selectionLength > 0)
                _byteProvider.DeleteBytes(_bytePos, _selectionLength);

            _byteProvider.InsertBytes(_bytePos, buffer);

            SetPosition(_bytePos + buffer.Length, 0);

            ReleaseSelection();
            ScrollByteIntoView();
            UpdateCaret();
            Invalidate();
        }

        /// <summary>
        /// Copies the current selection in the hex box to the Clipboard in hex format.
        /// </summary>
        public void CopyHex()
        {
            if (!CanCopy()) return;

            // put bytes into buffer
            byte[] buffer = GetCopyData();

            DataObject da = new DataObject();

            // set string buffer clipbard data
            string hexString = ConvertBytesToHex(buffer); ;
            da.SetData(typeof(string), hexString);

            //set memorystream (BinaryData) clipboard data
            MemoryStream ms = new MemoryStream(buffer, 0, buffer.Length, false, true);
            da.SetData("BinaryData", ms);

            Clipboard.SetDataObject(da, true);
            UpdateCaret();
            ScrollByteIntoView();
            Invalidate();

            CopiedHex?.Invoke(this, null);
        }

        #endregion

        #region Positioning methods

        /// <summary>
        /// 更新矩形区域位置大小
        /// </summary>
        private void UpdateRectanglePositioning()
        {
            // calc char size
            SizeF charSize;
            using (var graphics = CreateGraphics())
            {
                charSize = CreateGraphics().MeasureString(_charSizeRefer, font, 100, _stringFormat);
            }
            CharSize = new SizeF((float)Math.Ceiling(charSize.Width), (float)Math.Ceiling(charSize.Height));

            int requiredWidth = 0;

            // calc content bounds
            _recContent = ClientRectangle;
            _recContent.X += _recBorderLeft;
            _recContent.Y += _recBorderTop;
            _recContent.Width -= _recBorderRight + _recBorderLeft;
            _recContent.Height -= _recBorderBottom + _recBorderTop;

            if (_vScrollBarVisible)
            {
                _recContent.Width -= _vScrollBar.Width;
                _vScrollBar.Left = _recContent.X + _recContent.Width;
                _vScrollBar.Top = _recContent.Y;
                _vScrollBar.Height = _recContent.Height;
                requiredWidth += _vScrollBar.Width;
            }

            // calc line info bounds
            if (_lineInfoVisible)
            {
                _recLineInfo = new Rectangle(_recContent.X + _marginLineInfo,
                    _recContent.Y,
                    (int)(_charSize.Width * _lineInfoWidth),
                    _recContent.Height);
                requiredWidth += _recLineInfo.Width;
            }
            else
            {
                _recLineInfo = Rectangle.Empty;
                _recLineInfo.X = _marginLineInfo;
                requiredWidth += _marginLineInfo;
            }

            // calc line info bounds
            _recColumnInfo = new Rectangle(_recLineInfo.X + _recLineInfo.Width, _recContent.Y, _recContent.Width - _recLineInfo.Width, (int)charSize.Height + 4);
            if (_columnInfoVisible)
            {
                _recLineInfo.Y += (int)charSize.Height + 4;
                _recLineInfo.Height -= (int)charSize.Height + 4;
            }
            else
            {
                _recColumnInfo.Height = 0;
            }

            // calc hex bounds and grid
            _recHex = new Rectangle(_recLineInfo.X + _recLineInfo.Width,
                _recLineInfo.Y,
                _recContent.Width - _recLineInfo.Width,
                _recContent.Height - _recColumnInfo.Height);

            if (UseFixedBytesPerLine)
            {
                SetHorizontalByteCount(_bytesPerLine);
                _recHex.Width = (int)Math.Floor(((double)_iHexMaxHBytes) * _charSize.Width * 3 + (2 * _charSize.Width));
                requiredWidth += _recHex.Width;
            }
            else
            {
                int hmax = (int)Math.Floor(_recHex.Width / (double)_charSize.Width);
                if (_stringViewVisible)
                {
                    hmax -= 2;
                    if (hmax > 1)
                        SetHorizontalByteCount((int)Math.Floor((double)hmax / 4));
                    else
                        SetHorizontalByteCount(1);
                }
                else
                {
                    if (hmax > 1)
                        SetHorizontalByteCount((int)Math.Floor((double)hmax / 3));
                    else
                        SetHorizontalByteCount(1);
                }
                _recHex.Width = (int)Math.Floor(((double)_iHexMaxHBytes) * _charSize.Width * 3 + (2 * _charSize.Width));
                requiredWidth += _recHex.Width;
            }

            if (_stringViewVisible)
            {
                _recStringView = new Rectangle(_recHex.X + _recHex.Width,
                    _recHex.Y,
                    (int)(_charSize.Width * _iHexMaxHBytes),
                    _recHex.Height);

                /*修复当stringview显示时没留给水平滚动条右边距的Bug*/
                requiredWidth += (int)(_recStringView.Width + _charSize.Width * 2.5);
            }
            else
            {
                _recStringView = Rectangle.Empty;
            }

            RequiredWidth = requiredWidth;

            /*水平滚动条添加*/
            if (_hScrollBarVisible && requiredWidth > ClientRectangle.Width)
            {
                _recContent.Height -= _hScrollBar.Height;
                _hScrollBar.Left = _recContent.X;
                _hScrollBar.Top = _recContent.Y + _recContent.Height;
                _hScrollBar.Width = _recContent.Width;
            }

            int vmax = (int)Math.Floor(_recHex.Height / (double)_charSize.Height);
            SetVerticalByteCount(vmax);

            _iHexMaxBytes = _iHexMaxHBytes * _iHexMaxVBytes;

            UpdateHScrollSize();
            UpdateVScrollSize();
        }

        private PointF GetBytePointF(long byteIndex)
        {
            Point gp = GetGridBytePoint(byteIndex);

            return GetBytePointF(gp);
        }

        private PointF GetBytePointF(Point gp)
        {
            float x = (3 * _charSize.Width) * gp.X + _recHex.X + GetHOffValue();
            float y = (gp.Y + 1) * _charSize.Height - _charSize.Height + _recHex.Y;

            return new PointF(x, y);
        }

        private PointF GetColumnInfoPointF(int col)
        {
            Point gp = GetGridBytePoint(col);
            float x = (3 * _charSize.Width) * gp.X + _recColumnInfo.X + GetHOffValue();
            float y = _recColumnInfo.Y;

            return new PointF(x, y);
        }

        private PointF GetByteStringPointF(Point gp)
        {
            float x = _charSize.Width * gp.X + _recStringView.X + GetHOffValue();
            float y = gp.Y * _charSize.Height + _recStringView.Y;

            return new PointF(x, y);
        }

        private Point GetGridBytePoint(long byteIndex)
        {
            int row = (int)Math.Floor(byteIndex / (double)_iHexMaxHBytes);
            int column = (int)(byteIndex - _iHexMaxHBytes * row);
            Point res = new Point(column, row);
            return res;
        }

        #endregion

        #region Overridden properties

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        /// <summary>
        /// The font used to display text in the hexbox.
        /// </summary>
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                if (value == null)
                    return;

                base.Font = value;
                font = new Font(Font.FontFamily, Font.Size * Scaling, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
                UpdateRectanglePositioning();
                Invalidate();
            }
        }

        private Font font;

        /// <summary>
        /// Not used.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never), Bindable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        /// <summary>
        /// Not used.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never), Bindable(false)]
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        #endregion

        #region Undo,Redo Method

        /// <summary>
        /// 执行操作
        /// </summary>
        public enum EditOperation
        {
            /// <summary>
            /// 复写
            /// </summary>
            OverWrite,

            /// <summary>
            /// 删除
            /// </summary>
            Delete,

            /// <summary>
            /// 插入
            /// </summary>
            Insert
        }

        /// <summary>
        /// 修改数据存储
        /// </summary>
        public class ModifiedData
        {
            /// <summary>
            /// 操作
            /// </summary>
            public EditOperation operation;

            /// <summary>
            /// 字节数据
            /// </summary>
            public byte[] bytes;

            /// <summary>
            /// 光标位置
            /// </summary>
            public int caretPos;

            /// <summary>
            /// 字节索引
            /// </summary>
            public long byteindex;

            /// <summary>
            ///
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static bool operator ==(ModifiedData a, ModifiedData b) => a.byteindex == b.byteindex && a.bytes.GetHashCode() == b.bytes.GetHashCode();

            /// <summary>
            ///
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static bool operator !=(ModifiedData a, ModifiedData b) => a.byteindex != b.byteindex || a.bytes.GetHashCode() != b.bytes.GetHashCode();

            /// <summary>
            ///
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                if (GetType() != obj.GetType()) return false;
                return true;
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return bytes.GetHashCode() * (int)byteindex;
            }
        }

        private Stack<ModifiedData> UndoStack = new Stack<ModifiedData>();
        private Stack<ModifiedData> RedoStack = new Stack<ModifiedData>();

        /// <summary>
        /// 生成操作历史快照
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public ModifiedData SnapShotOperation(EditOperation operation, byte[] buffer)
        {
            return new ModifiedData
            {
                caretPos = _byteCharacterPos,
                operation = operation,
                bytes = buffer,
                byteindex = _bytePos,
            };
        }

        /// <summary>
        /// 生成操作历史快照
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="bytePos"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public ModifiedData SnapShotOperation(EditOperation operation, long bytePos, byte[] buffer)
        {
            return new ModifiedData
            {
                caretPos = 0,
                operation = operation,
                bytes = buffer,
                byteindex = bytePos,
            };
        }

        /// <summary>
        /// 判断是否可以撤销
        /// </summary>
        /// <returns></returns>
        public bool CanUndo()
        {
            if (UndoStack.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否可以恢复更改
        /// </summary>
        /// <returns></returns>
        public bool CanRedo()
        {
            if (RedoStack.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 撤销更改
        /// </summary>
        /// <returns></returns>
        public bool Undo()
        {
            if (!CanUndo())
            {
                return false;
            }
            ModifiedData data = UndoStack.Pop();
            switch (data.operation)
            {
                case EditOperation.OverWrite:
                    if (!_byteProvider.SupportsWriteByte())
                        return false;
                    int len = data.bytes.Length;
                    byte[] buffer = new byte[len];
                    for (int i = 0; i < len; i++)
                    {
                        buffer[i] = _byteProvider.ReadByte(data.byteindex + i);
                        _byteProvider.WriteByte(data.byteindex + i, data.bytes[i]);
                    }
                    data.bytes = buffer;
                    break;

                case EditOperation.Delete:
                    if (_byteProvider.SupportsInsertBytes())
                        _byteProvider.InsertBytes(data.byteindex, data.bytes);
                    data.operation = EditOperation.Insert;
                    break;

                case EditOperation.Insert:
                    if (_byteProvider.SupportsDeleteBytes())
                        _byteProvider.DeleteBytes(data.byteindex, data.bytes.Length);
                    data.operation = EditOperation.Delete;
                    break;

                default:
                    return false;
            }
            RedoStack.Push(data);
            Refresh();
            SetPosition(data.byteindex, data.caretPos);
            UpdateCaret();
            return true;
        }

        /// <summary>
        /// 恢复更改
        /// </summary>
        /// <returns></returns>
        public bool Redo()
        {
            if (!CanRedo())
            {
                return false;
            }
            ModifiedData data = RedoStack.Pop();
            switch (data.operation)
            {
                case EditOperation.OverWrite:
                    if (!_byteProvider.SupportsWriteByte())
                        return false;
                    int len = data.bytes.Length;
                    byte[] buffer = new byte[len];
                    for (int i = 0; i < len; i++)
                    {
                        buffer[i] = _byteProvider.ReadByte(data.byteindex + i);
                        _byteProvider.WriteByte(data.byteindex + i, data.bytes[i]);
                    }
                    data.bytes = buffer;
                    break;

                case EditOperation.Delete:
                    if (_byteProvider.SupportsInsertBytes())
                        _byteProvider.InsertBytes(data.byteindex, data.bytes);
                    data.operation = EditOperation.Insert;
                    break;

                case EditOperation.Insert:
                    if (_byteProvider.SupportsDeleteBytes())
                        _byteProvider.DeleteBytes(data.byteindex, data.bytes.Length);
                    data.operation = EditOperation.Delete;
                    break;

                default:
                    return false;
            }
            UndoStack.Push(data);
            Refresh();
            SetPosition(data.byteindex, data.caretPos);
            UpdateCaret();
            return true;
        }

        /// <summary>
        /// 清空撤销恢复历史记录
        /// </summary>
        public void ClearUnRedoHistory()
        {
            UndoStack.Clear();
            RedoStack.Clear();
        }

        #endregion

        #region 其他操作

        /// <summary>
        /// 填充字节
        /// </summary>
        /// <param name="start"></param>
        /// <param name="buffer"></param>
        public void WriteBytes(long start, byte[] buffer)
        {
            UndoStack.Push(SnapShotOperation(EditOperation.OverWrite, start, buffer));
            for (int i = 0; i < buffer.Length; i++)
            {
                _byteProvider.WriteByte(start + i, buffer[i]);
            }
            Invalidate();
        }

        /// <summary>
        /// 填充字节
        /// </summary>
        /// <param name="start"></param>
        /// <param name="value"></param>
        /// <param name="length"></param>
        public void WriteBytes(long start, byte value, long length)
        {
            byte[] buffer = new byte[length];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = value;
                _byteProvider.WriteByte(start + i, value);
            }
            UndoStack.Push(SnapShotOperation(EditOperation.OverWrite, start, buffer));
            Invalidate();
        }

        /// <summary>
        /// 填充字节
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="value"></param>
        public void WriteBytes(long start, long end, byte value)
        {
            byte[] buffer = new byte[end - start + 1];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = value;
                _byteProvider.WriteByte(start + i, value);
            }
            UndoStack.Push(SnapShotOperation(EditOperation.OverWrite, start, buffer));
            Invalidate();
        }

        /// <summary>
        /// 跳转定位
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="isfromBase"></param>
        public void GotoByOffset(long offset, bool isfromBase)
        {
            long _base = 0;
            if (!isfromBase)
            {
                _base = _bytePos;
            }
            ScrollByteIntoView(offset + _base);
            _bytePos = offset + _base;
            UpdateCaret();
            Invalidate();
        }

        #endregion

        #region Scaling Support for High DPI resolution screens

        /// <summary>
        /// For high resolution screen support
        /// </summary>
        /// <param name="factor">the factor</param>
        /// <param name="specified">bounds</param>
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);

            BeginInvoke(new MethodInvoker(() =>
                {
                    UpdateRectanglePositioning();
                    if (_caretVisible)
                    {
                        DestroyCaret();
                        CreateCaret();
                    }
                    Invalidate();
                }));
        }

        #endregion
    }
}