using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Be.Windows.Forms
{
    public partial class HexBox
    {
        /// <summary>
        /// Contains the hole content bounds of all text
        /// </summary>
        private Rectangle _recContent;

        /// <summary>
        /// Contains the line info bounds
        /// </summary>
        private Rectangle _recLineInfo;

        /// <summary>
        /// Contains the column info header rectangle bounds
        /// </summary>
        private Rectangle _recColumnInfo;

        /// <summary>
        /// Contains the hex data bounds
        /// </summary>
        private Rectangle _recHex;

        /// <summary>
        /// Contains the string view bounds
        /// </summary>
        private Rectangle _recStringView;

        /// <summary>
        /// Contains string format information for text drawing
        /// </summary>
        private readonly StringFormat _stringFormat;

        /// <summary>
        /// Contains the maximum of visible horizontal bytes
        /// </summary>
        private int _iHexMaxHBytes;

        /// <summary>
        /// Contains the maximum of visible vertical bytes
        /// </summary>
        private int _iHexMaxVBytes;

        /// <summary>
        /// Contains the maximum of visible bytes.
        /// </summary>
        private int _iHexMaxBytes;

        /// <summary>
        /// Contains the scroll bars minimum value
        /// </summary>
        private long _scrollVmin;

        /// <summary>
        /// Contains the scroll bars maximum value
        /// </summary>
        private long _scrollVmax;

        /// <summary>
        /// Contains the scroll bars current position
        /// </summary>
        private long _scrollVpos;

        /// <summary>
        /// Contains the scroll bars minimum value
        /// </summary>
        private long _scrollHmin;

        /// <summary>
        /// Contains the scroll bars maximum value
        /// </summary>
        private long _scrollHmax;

        /// <summary>
        /// Contains the scroll bars current position
        /// </summary>
        private long _scrollHpos;

        /// <summary>
        /// Contains a vertical scroll
        /// </summary>
        private readonly VScrollBar _vScrollBar;

        /// <summary>
        /// 提供一个水平滚动条
        /// </summary>
        private readonly HScrollBar _hScrollBar;

        /// <summary>
        /// Contains a timer for thumbtrack scrolling
        /// </summary>
        private readonly Timer _vthumbTrackTimer = new Timer();

        /// <summary>
        /// Contains a timer for thumbtrack scrolling
        /// </summary>
        private readonly Timer _hthumbTrackTimer = new Timer();

        /// <summary>
        /// Contains the thumbtrack scrolling position
        /// </summary>
        private long _thumbTrackPosition;

        /// <summary>
        /// Contains the thumptrack delay for scrolling in milliseconds.
        /// </summary>
        private const int THUMPTRACKDELAY = 50;

        /// <summary>
        /// Contains the Enviroment.TickCount of the last refresh
        /// </summary>
        private int _lastVThumbtrack;

        /// <summary>
        /// Contains the Enviroment.TickCount of the last refresh
        /// </summary>
        private int _lastHThumbtrack;

        /// <summary>
        /// Contains the border's left shift
        /// </summary>
        private int _recBorderLeft = SystemInformation.Border3DSize.Width;

        /// <summary>
        /// Contains the border's right shift
        /// </summary>
        private int _recBorderRight = SystemInformation.Border3DSize.Width;

        /// <summary>
        /// Contains the border's top shift
        /// </summary>
        private int _recBorderTop = SystemInformation.Border3DSize.Height;

        /// <summary>
        /// Contains the border bottom shift
        /// </summary>
        private int _recBorderBottom = SystemInformation.Border3DSize.Height;

        /// <summary>
        /// Contains the index of the first visible byte
        /// </summary>
        private long _startByte;

        /// <summary>
        /// Contains the index of the last visible byte
        /// </summary>
        private long _endByte;

        /// <summary>
        /// Contains the current byte position
        /// </summary>
        private long _bytePos = -1;

        /// <summary>
        /// Contains the current char position in one byte
        /// </summary>
        /// <example>
        /// "1A"
        /// "1" = char position of 0
        /// "A" = char position of 1
        /// </example>
        private int _byteCharacterPos;

        /// <summary>
        /// Contains string format information for hex values
        /// </summary>
        private string _hexStringFormat = "X";

        /// <summary>
        /// Contains the current key interpreter
        /// </summary>
        private IKeyInterpreter _keyInterpreter;

        /// <summary>
        /// Contains an empty key interpreter without functionality
        /// </summary>
        private EmptyKeyInterpreter _eki;

        /// <summary>
        /// Contains the default key interpreter
        /// </summary>
        private KeyInterpreter _ki;

        /// <summary>
        /// Contains the string key interpreter
        /// </summary>
        private StringKeyInterpreter _ski;

        /// <summary>
        /// Contains True if caret is visible
        /// </summary>
        private bool _caretVisible;

        /// <summary>
        /// Contains true, if the find (Find method) should be aborted.
        /// </summary>
        private bool _abortFind;

        /// <summary>
        /// Contains a value of the current finding position.
        /// </summary>
        private long _findingPos;

        /// <summary>
        /// Contains a state value about Insert or Write mode. When this value is true and the ByteProvider SupportsInsert is true bytes are inserted instead of overridden.
        /// </summary>
        private bool _insertActive;

        /// <summary>
        /// 高亮区段列表
        /// </summary>
        private List<HighlightedRegion> HighligedRegions = new List<HighlightedRegion>();

        /// <summary>
        /// 添加高亮区段
        /// </summary>
        /// <param name="region"></param>
        public bool AddHighligedRegion(HighlightedRegion region)
        {
            if (HighligedRegions.Contains(region))
            {
                return false;
            }
            HighligedRegions.Add(region);
            Invalidate();
            return true;
        }

        /// <summary>
        /// 清空高亮区段
        /// </summary>
        public void ClearHighlightedRegion()
        {
            HighligedRegions.Clear();
            Invalidate();
        }

        /// <summary>
        /// 删除高亮区域，全部已知
        /// </summary>
        /// <param name="region"></param>
        public void RemoveHighlightedRegion(HighlightedRegion region)
        {
            HighligedRegions.Remove(region);
            Invalidate();
        }

        /// <summary>
        /// 删除高亮区域，已知高亮区域开头
        /// </summary>
        /// <param name="regionStart"></param>
        public void RemoveHighlightedRegion(int regionStart)
        {
            HighligedRegions.RemoveAll(k => k.Start == regionStart);
            Invalidate();
        }

        /// <summary>
        /// 删除高亮区域，已知在高亮区块列表中的索引
        /// </summary>
        /// <param name="index"></param>
        public bool RemoveHighlightedRegionAt(int index)
        {
            if (index>= HighligedRegions.Count)
            {
                return false;
            }
            HighligedRegions.RemoveAt(index);
            Invalidate();
            return true;
        }

        /// <summary>
        /// 修改高亮区域
        /// </summary>
        /// <param name="OldRegion"></param>
        /// <param name="newRegion"></param>
        /// <returns></returns>
        public bool ModHighlightedRegion(HighlightedRegion OldRegion, HighlightedRegion newRegion)
        {
            if (HighligedRegions.Remove(OldRegion))
            {
                HighligedRegions.Add(newRegion);
                Invalidate();
                return true;
            }
            return false;
        }
    }
}