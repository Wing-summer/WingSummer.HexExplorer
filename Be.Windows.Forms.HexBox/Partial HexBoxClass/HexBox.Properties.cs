using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Be.Windows.Forms
{
    public partial class HexBox
    {
        /// <summary>
        /// Gets or sets the background color for the disabled control.
        /// </summary>
        [Category("外观"), DefaultValue(typeof(Color), "WhiteSmoke")]
        public Color BackColorDisabled
        {
            get
            {
                return _backColorDisabled;
            }
            set
            {
                _backColorDisabled = value;
            }
        }

        private Color _backColorDisabled = Color.WhiteSmoke;

        /// <summary>
        /// Gets or sets if the count of bytes in one line is fix.
        /// </summary>
        /// <remarks>
        /// When set to True, BytesPerLine property determine the maximum count of bytes in one line.
        /// </remarks>
        [DefaultValue(false), Category("十六进制相关"), Description("获取或设置是否只读")]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                if (_readOnly == value)
                    return;

                _readOnly = value;
                ReadOnlyChanged?.Invoke(this, null);
                Invalidate();
            }
        }

        private bool _readOnly;

        /// <summary>
        /// 缩放率，正常数值为1.0
        /// </summary>

        [DefaultValue(1.0), Category("Hex"), Description("缩放率")]
        public float Scaling
        {
            get { return _scaling; }
            set
            {
                if (value <= 0)
                    return;
                _scaling = value;
                font = new Font(Font.FontFamily, Font.Size * Scaling, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
                Refresh();
                ScalingChanged?.Invoke(this, null);
            }
        }

        private float _scaling;

        /// <summary>
        /// Gets or sets the maximum count of bytes in one line.
        /// </summary>
        /// <remarks>
        /// UseFixedBytesPerLine property no longer has to be set to true for this to work
        /// </remarks>
        [DefaultValue(16), Category("Hex"), Description("Gets or sets the maximum count of bytes in one line.")]
        public int BytesPerLine
        {
            get { return _bytesPerLine; }
            set
            {
                if (_bytesPerLine == value)
                    return;

                _bytesPerLine = value;

                BytesPerLineChanged?.Invoke(this, null);

                UpdateRectanglePositioning();
                Invalidate();
            }
        }

        private int _bytesPerLine = 16;

        /// <summary>
        /// Gets or sets the number of bytes in a group. Used to show the group separator line (if GroupSeparatorVisible is true)
        /// </summary>
        /// <remarks>
        /// GroupSeparatorVisible property must set to true
        /// </remarks>
        [DefaultValue(4), Category("Hex"), Description("Gets or sets the byte-count between group separators (if visible).")]
        public int GroupSize
        {
            get { return _groupSize; }
            set
            {
                if (_groupSize == value)
                    return;

                _groupSize = value;

                GroupSizeChanged?.Invoke(this, null);

                UpdateRectanglePositioning();
                Invalidate();
            }
        }

        private int _groupSize = 4;

        /// <summary>
        /// Gets or sets if the count of bytes in one line is fix.
        /// </summary>
        /// <remarks>
        /// When set to True, BytesPerLine property determine the maximum count of bytes in one line.
        /// </remarks>
        [DefaultValue(false), Category("Hex"), Description("Gets or sets if the count of bytes in one line is fix.")]
        public bool UseFixedBytesPerLine
        {
            get { return _useFixedBytesPerLine; }
            set
            {
                if (_useFixedBytesPerLine == value)
                    return;

                _useFixedBytesPerLine = value;
                UseFixedBytesPerLineChanged?.Invoke(this, null);

                UpdateRectanglePositioning();
                Invalidate();
            }
        }

        private bool _useFixedBytesPerLine;

        /// <summary>
        /// Gets or sets the visibility of a vertical scroll bar.
        /// </summary>
        [DefaultValue(false), Category("Hex"), Description("Gets or sets the visibility of a vertical scroll bar.")]
        public bool VScrollBarVisible
        {
            get { return _vScrollBarVisible; }
            set
            {
                if (_vScrollBarVisible == value)
                    return;

                _vScrollBarVisible = value;

                if (_vScrollBarVisible)
                    Controls.Add(_vScrollBar);
                else
                    Controls.Remove(_vScrollBar);

                UpdateRectanglePositioning();
                UpdateVScrollSize();

                VScrollBarVisibleChanged?.Invoke(this, null);
            }
        }

        private bool _vScrollBarVisible;

        /// <summary>
        /// 获取或设置水平滚动条是否可见
        /// </summary>
        [DefaultValue(false), Category("Hex"), Description("获取或设置水平滚动条是否可见")]
        public bool HScrollBarVisible
        {
            get { return _hScrollBarVisible; }
            set
            {
                if (_hScrollBarVisible == value)
                    return;

                _hScrollBarVisible = value;

                if (_hScrollBarVisible)
                    Controls.Add(_hScrollBar);
                else
                    Controls.Remove(_hScrollBar);

                UpdateRectanglePositioning();
                UpdateHScrollSize();

                HScrollBarVisibleChanged?.Invoke(this, null);
            }
        }

        private bool _hScrollBarVisible;

        /// <summary>
        /// Gets or sets the ByteProvider.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IByteProvider ByteProvider
        {
            get { return _byteProvider; }
            set
            {
                if (_byteProvider == value)
                    return;

                if (value == null)
                    ActivateEmptyKeyInterpreter();
                else
                    ActivateKeyInterpreter();

                if (_byteProvider != null)
                {
                    _byteProvider.LengthChanged -= new EventHandler(ByteProvider_LengthChanged);
                    _byteProvider.Changed -= ByteProvider_Changed;
                }
                _byteProvider = value;
                if (_byteProvider != null)
                {
                    _byteProvider.LengthChanged += new EventHandler(ByteProvider_LengthChanged);
                    _byteProvider.Changed += ByteProvider_Changed;
                    SavedStatusChanged?.Invoke(this, EventArgs.Empty);

                    /*begin：判断文件长度是否必须用int64显示*/

                    if (Force64Bit)
                    {
                        curIsLongHex = true;
                    }
                    else
                    {
                        if (value.Length > 4294967295L)   //int32能表示的最大数字
                        {
                            curIsLongHex = true;
                        }
                        else
                        {
                            curIsLongHex = false;
                        }
                    }

                    /*end：判断文件长度是否必须用int64显示*/
                }

                ByteProviderChanged?.Invoke(this, EventArgs.Empty);

                if (value == null) // do not raise events if value is null
                {
                    _bytePos = -1;
                    _byteCharacterPos = 0;
                    _selectionLength = 0;

                    DestroyCaret();
                }
                else
                {
                    SetPosition(0, 0);
                    SetSelectionLength(0);

                    if (_caretVisible && Focused)
                        UpdateCaret();
                    else
                        CreateCaret();
                }

                CheckCurrentLineChanged();
                CheckCurrentPositionInLineChanged();

                _scrollVpos = 0;
                _scrollHpos = 0;

                UpdateVisibilityBytes();
                UpdateRectanglePositioning();

                Invalidate();
            }
        }

        private void ByteProvider_Changed(object sender, EventArgs e)
        {
            SavedStatusChanged?.Invoke(sender,e);
        }

        private IByteProvider _byteProvider;

        /// <summary>
        /// 查看打开的文件路径
        /// </summary>
        public string Filename { get; private set; }

        /// <summary>
        /// Gets or sets the visibility of the group separator.
        /// </summary>
        [DefaultValue(false), Category("Hex"), Description("Gets or sets the visibility of a separator vertical line.")]
        public bool GroupSeparatorVisible
        {
            get { return _groupSeparatorVisible; }
            set
            {
                if (_groupSeparatorVisible == value)
                    return;

                _groupSeparatorVisible = value;
                GroupSeparatorVisibleChanged?.Invoke(this, null);

                UpdateRectanglePositioning();
                Invalidate();
            }
        }

        private bool _groupSeparatorVisible = false;

        /// <summary>
        /// Gets or sets the visibility of the column info
        /// </summary>
        [DefaultValue(false), Category("Hex"), Description("Gets or sets the visibility of header row.")]
        public bool ColumnInfoVisible
        {
            get { return _columnInfoVisible; }
            set
            {
                if (_columnInfoVisible == value)
                    return;

                _columnInfoVisible = value;
                ColumnInfoVisibleChanged?.Invoke(this, null);

                UpdateRectanglePositioning();
                Invalidate();
            }
        }

        private bool _columnInfoVisible = false;

        /// <summary>
        /// Gets or sets the visibility of a line info.
        /// </summary>
        [DefaultValue(false), Category("Hex"), Description("Gets or sets the visibility of a line info.")]
        public bool LineInfoVisible
        {
            get { return _lineInfoVisible; }
            set
            {
                if (_lineInfoVisible == value)
                    return;

                _lineInfoVisible = value;
                LineInfoVisibleChanged?.Invoke(this, null);

                UpdateRectanglePositioning();
                Invalidate();
            }
        }

        private bool _lineInfoVisible = false;

        /// <summary>
        /// Gets or sets the hex box's  border style.
        /// </summary>
        [DefaultValue(typeof(BorderStyle), "Fixed3D"), Category("Hex"), Description("Gets or sets the hex box's border style.")]
        public BorderStyle BorderStyle
        {
            get { return _borderStyle; }
            set
            {
                if (_borderStyle == value)
                    return;
                _borderStyle = value;
                switch (_borderStyle)
                {
                    case BorderStyle.None:
                        _recBorderLeft = _recBorderTop = _recBorderRight = _recBorderBottom = 0;
                        break;

                    case BorderStyle.Fixed3D:
                        _recBorderLeft = _recBorderRight = SystemInformation.Border3DSize.Width;
                        _recBorderTop = _recBorderBottom = SystemInformation.Border3DSize.Height;
                        break;

                    case BorderStyle.FixedSingle:
                        _recBorderLeft = _recBorderTop = _recBorderRight = _recBorderBottom = 1;
                        break;
                }

                UpdateRectanglePositioning();

                BorderStyleChanged?.Invoke(this, null);
            }
        }

        private BorderStyle _borderStyle = BorderStyle.Fixed3D;

        /// <summary>
        /// Gets or sets the visibility of the string view.
        /// </summary>
        [DefaultValue(false), Category("Hex"), Description("Gets or sets the visibility of the string view.")]
        public bool StringViewVisible
        {
            get { return _stringViewVisible; }
            set
            {
                if (_stringViewVisible == value)
                    return;

                _stringViewVisible = value;
                StringViewVisibleChanged?.Invoke(this, null);
                UpdateRectanglePositioning();
                Invalidate();
            }
        }

        private bool _stringViewVisible;

        /// <summary>
        /// 设置绘制十六进制数据组间隔线
        /// </summary>
        [Category("Hex"), Description("设置绘制十六进制数据组间隔线"),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
            TypeConverter(typeof(ExpandableObjectConverter))]
        public PenF GroupLinePen { get; set; } = Pens.Gray;

        /// <summary>
        /// 设置绘制十六进制数据组间隔线
        /// </summary>
        [Category("Hex"), Description("设置绘制十六进制数据和字符串间隔线"), TypeConverter(typeof(ExpandableObjectConverter))]
        public PenF HexStringLinePen { get; set; } = Pens.Gray;

        /// <summary>
        /// Gets or sets whether the HexBox control displays the hex characters in upper or lower case.
        /// </summary>
        [DefaultValue(typeof(HexCasing), "Upper"), Category("Hex"), Description("Gets or sets whether the HexBox control displays the hex characters in upper or lower case.")]
        public HexCasing HexCasing
        {
            get
            {
                if (_hexStringFormat == "X")
                    return HexCasing.Upper;
                else
                    return HexCasing.Lower;
            }
            set
            {
                string format;
                if (value == HexCasing.Upper)
                    format = "X";
                else
                    format = "x";

                if (_hexStringFormat == format)
                    return;

                _hexStringFormat = format;

                HexCasingChanged?.Invoke(this, null);
                Invalidate();
            }
        }

        /// <summary>
        /// Gets and sets the starting point of the bytes selected in the hex box.（同时也是光标位置）
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long SelectionStart
        {
            get { return _bytePos; }
            set
            {
                SetPosition(value, 0);
                ScrollByteIntoView();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets and sets the number of bytes selected in the hex box.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long SelectionLength
        {
            get { return _selectionLength; }
            set
            {
                SetSelectionLength(value);
                ScrollByteIntoView();
                Invalidate();
            }
        }

        private long _selectionLength;

        /// <summary>
        /// Gets or sets the info color used for column info and line info. When this property is null, then ForeColor property is used.
        /// </summary>
        [DefaultValue(typeof(Color), "Gray"), Category("Hex"), Description("Gets or sets the line info color. When this property is null, then ForeColor property is used.")]
        public Color InfoForeColor
        {
            get { return _infoForeColor; }
            set { _infoForeColor = value; Invalidate(); }
        }

        private Color _infoForeColor = Color.Gray;

        /// <summary>
        /// Gets or sets the background color for the selected bytes.
        /// </summary>
        [DefaultValue(typeof(Color), "Blue"), Category("Hex"), Description("Gets or sets the background color for the selected bytes.")]
        public Color SelectionBackColor
        {
            get { return _selectionBackColor; }
            set { _selectionBackColor = value; Invalidate(); }
        }

        private Color _selectionBackColor = Color.Blue;

        /// <summary>
        /// 选择区块色彩透明度
        /// </summary>
        [DefaultValue(100), Category("Hex"), Description("选择区块色彩透明度")]
        public int SelectionBackColorOpacity
        {
            get { return _selectionBackColorOpacity; }
            set
            {
                if (value >= 0 && value <= 255)
                {
                    _selectionBackColorOpacity = value;
                }
            }
        }

        private int _selectionBackColorOpacity = 100;

        /// <summary>
        /// Gets or sets the foreground color for the selected bytes.
        /// </summary>
        [DefaultValue(typeof(Color), "White"), Category("Hex"), Description("Gets or sets the foreground color for the selected bytes.")]
        public Color SelectionForeColor
        {
            get { return _selectionForeColor; }
            set { _selectionForeColor = value; Invalidate(); }
        }

        private Color _selectionForeColor = Color.White;

        /// <summary>
        /// 获取或设置列标号的背景色
        /// </summary>
        [DefaultValue(typeof(Color), "White"), Category("Hex"), Description("获取或设置列标号的背景色")]
        public Color ColumnInfoBackColor
        {
            get
            {
                return _columnInfoBackColor;
            }
            set
            {
                _columnInfoBackColor = value;
                Invalidate();
            }
        }

        private Color _columnInfoBackColor = Color.White;

        /// <summary>
        /// 获取或设置是否填充列标号的背景色
        /// </summary>
        [DefaultValue(false), Category("Hex"), Description("获取或设置列标号的背景色")]
        public bool ShowColumnInfoBackColor
        {
            get; set;
        }

        /// <summary>
        /// 获取或设置列标号的背景色
        /// </summary>
        [DefaultValue(typeof(Color), "White"), Category("Hex"), Description("获取或设置行标号的背景色")]
        public Color LineInfoBackColor
        {
            get
            {
                return _lineInfoBackColor;
            }

            set
            {
                _lineInfoBackColor = value;
                Invalidate();
            }
        }

        private Color _lineInfoBackColor = Color.White;

        /// <summary>
        /// 获取或设置是否填充行标号的背景色
        /// </summary>
        [DefaultValue(false), Category("Hex"), Description("获取或设置行标号的背景色")]
        public bool ShowLineInfoBackColor
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the visibility of a shadow selection.
        /// </summary>
        [DefaultValue(true), Category("Hex"), Description("Gets or sets the visibility of a shadow selection.")]
        public bool ShadowSelectionVisible
        {
            get { return _shadowSelectionVisible; }
            set
            {
                if (_shadowSelectionVisible == value)
                    return;
                _shadowSelectionVisible = value;
                Invalidate();
            }
        }

        private bool _shadowSelectionVisible = true;

        /// <summary>
        /// 设置或获取行列标号对齐方式
        /// </summary>
        [DefaultValue(HorizontalAlignment.Center), Category("Hex"), Description("设置或获取行列标号对齐方式")]
        public HorizontalAlignment LineInfoAlignment
        {
            get
            {
                return _lineInfoAlignment;
            }
            set
            {
                _lineInfoAlignment = value;
                Invalidate();
            }
        }

        private HorizontalAlignment _lineInfoAlignment = HorizontalAlignment.Center;

        /// <summary>
        /// 行标号边缘空白大小
        /// </summary>
        [DefaultValue(4), Category("Hex"), Description("行标号边缘空白大小")]
        public int MarginLineInfo
        {
            get
            {
                return _marginLineInfo;
            }
            set
            {
                if (value >= 0)
                {
                    _marginLineInfo = value;
                    Invalidate();
                }
            }
        }

        private int _marginLineInfo = 4;

        /// <summary>
        /// Gets or sets the color of the shadow selection.
        /// </summary>
        /// <remarks>
        /// A alpha component must be given!
        /// Default alpha = 100
        /// </remarks>
        [Category("Hex"), Description("Gets or sets the color of the shadow selection.")]
        public Color ShadowSelectionColor
        {
            get { return _shadowSelectionColor; }
            set { _shadowSelectionColor = value; Invalidate(); }
        }

        private Color _shadowSelectionColor = Color.FromArgb(100, 60, 188, 255);

        /// <summary>
        /// Contains the size of a single character in pixel
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SizeF CharSize
        {
            get { return _charSize; }
            private set
            {
                if (_charSize == value)
                    return;
                _charSize = value;
                CharSizeChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private SizeF _charSize;

        /// <summary>
        /// Gets the width required for the content
        /// </summary>
        [DefaultValue(0), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RequiredWidth
        {
            get { return _requiredWidth; }
            private set
            {
                if (_requiredWidth == value)
                    return;
                _requiredWidth = value;
                RequiredWidthChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private int _requiredWidth;

        /// <summary>
        /// Gets the number bytes drawn horizontally.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HorizontalByteCount
        {
            get { return _iHexMaxHBytes; }
        }

        /// <summary>
        /// Gets the number bytes drawn vertically.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int VerticalByteCount
        {
            get { return _iHexMaxVBytes; }
        }

        /// <summary>
        /// Gets the current line
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long CurrentLine
        {
            get { return _currentLine; }
        }

        private long _currentLine;

        /// <summary>
        /// Gets the current position in the current line
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long CurrentPositionInLine
        {
            get { return _currentPositionInLine; }
        }

        private int _currentPositionInLine;

        /// <summary>
        /// 判断是否已打开文件
        /// </summary>
        [DefaultValue(false), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsOpenedFile
        { get; private set; }

        /// <summary>
        /// 判断是否已打开缓冲区
        /// </summary>
        [DefaultValue(false), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsOpenedBuffer
        { get; private set; }

        /// <summary>
        /// Gets the a value if insertion mode is active or not.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool InsertActive
        {
            get { return _insertActive; }
            set
            {
                if (_insertActive == value)
                    return;

                _insertActive = value;

                // recreate caret
                DestroyCaret();
                CreateCaret();

                // raise change event
                InsertActiveChanged?.Invoke(this, null);
            }
        }

        /// <summary>
        /// Gets or sets the converter that will translate between byte and character values.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IByteCharConverter ByteCharConverter
        {
            get
            {
                if (_byteCharConverter == null)
                    _byteCharConverter = new DefaultByteCharConverter();
                return _byteCharConverter;
            }
            set
            {
                if (value != null && value != _byteCharConverter)
                {
                    _byteCharConverter = value;
                    Invalidate();
                }
            }
        }

        private IByteCharConverter _byteCharConverter;

        /// <summary>
        /// 是否不用ASCII编码而用Unicode显示字符串解析结果
        /// </summary>
        [DefaultValue(false), Category("Hex"), Description("是否不用ASCII编码而用Unicode显示字符串解析结果")]
        public bool IsCharToUnicode
        {
            get
            {
                return _isCharToUnicode;
            }
            set
            {
                _isCharToUnicode = value;
                Refresh();
            }
        }

        private bool _isCharToUnicode = false;

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false), Category("Hex"), Description("越界锁，如果开启，光标最后一个空白字节，插入将失效")]
        public bool IsLockedBuffer
        {
            get
            {
                return _isLockedBuffer;
            }
            set
            {
                _isLockedBuffer = value;
                LockedBufferChanged?.Invoke(this,EventArgs.Empty);
            }
        }private bool _isLockedBuffer;

        /// <summary>
        /// 行信息的默认起始
        /// </summary>
        [DefaultValue(0), Category("Hex"), Description("行信息的默认起始")]
        public long BaseAddr
        {
            get
            {
                return _baseAddr;
            }
            set
            {
                if (value >= 0)
                    _baseAddr = value;
            }
        }
        private long _baseAddr = 0;


        /// <summary>
        /// 是否强制64位地址显示
        /// </summary>
        [DefaultValue(false), Category("Hex"), Description("是否强制64位地址显示")]
        public bool Force64Bit
        {
            get;set;
        }

        /// <summary>
        /// 每个字符占用宽度参考字符串，不得为空
        /// </summary>
        [DefaultValue("A."), Category("Hex"), Description("每个字符占用宽度参考字符串，不得为空")]
        public string CharSizeRefer
        {
            get { return _charSizeRefer; }
            set
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in value)
                {
                    if (item != '\n' && item != '\r' && item != '\t' && item != '\b')
                    {
                        stringBuilder.Append(item);
                    }
                }
                if (stringBuilder.Length > 0)
                {
                    _charSizeRefer = stringBuilder.ToString();
                }
                stringBuilder.Clear();
            }
        }

        private string _charSizeRefer = "A.";
    }
}