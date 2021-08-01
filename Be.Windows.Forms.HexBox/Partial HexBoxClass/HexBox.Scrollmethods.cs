using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Be.Windows.Forms
{
    public partial class HexBox
    {
        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                switch (e.Type)
                {
                    case ScrollEventType.Last:
                        break;

                    case ScrollEventType.EndScroll:
                        break;

                    case ScrollEventType.SmallIncrement:
                        PerformScrollLineDown();
                        break;

                    case ScrollEventType.SmallDecrement:
                        PerformScrollLineUp();
                        break;

                    case ScrollEventType.LargeIncrement:
                        PerformScrollPageDown();
                        break;

                    case ScrollEventType.LargeDecrement:
                        PerformScrollPageUp();
                        break;

                    case ScrollEventType.ThumbPosition:
                        long lPos = FromVScrollPos(e.NewValue);
                        PerformVScrollThumpPosition(lPos);
                        break;

                    case ScrollEventType.ThumbTrack:
                        // to avoid performance problems use a refresh delay implemented with a timer
                        if (_vthumbTrackTimer.Enabled) // stop old timer
                            _vthumbTrackTimer.Enabled = false;

                        // perform scroll immediately only if last refresh is very old
                        int currentThumbTrack = Environment.TickCount;
                        if (currentThumbTrack - _lastVThumbtrack > THUMPTRACKDELAY)
                        {
                            PerformVScrollThumbTrack(null, null);
                            _lastVThumbtrack = currentThumbTrack;
                            break;
                        }

                        // start thumbtrack timer
                        _thumbTrackPosition = FromVScrollPos(e.NewValue);
                        _vthumbTrackTimer.Enabled = true;
                        break;

                    case ScrollEventType.First:
                        break;

                    default:
                        break;
                }

                e.NewValue = ToScrollVPos(_scrollVpos);
            }
            else
            {
                switch (e.Type)
                {
                    case ScrollEventType.Last:
                        break;

                    case ScrollEventType.EndScroll:
                        break;

                    case ScrollEventType.SmallIncrement:
                    case ScrollEventType.LargeIncrement:
                        PerformScrollColDown();
                        break;

                    case ScrollEventType.SmallDecrement:
                    case ScrollEventType.LargeDecrement:
                        PerformScrollColUp();
                        break;

                    case ScrollEventType.ThumbPosition:
                        long lPos = FromHScrollPos(e.NewValue);
                        PerformHScrollThumpPosition(lPos);
                        break;

                    case ScrollEventType.ThumbTrack:
                        // to avoid performance problems use a refresh delay implemented with a timer
                        if (_hthumbTrackTimer.Enabled) // stop old timer
                            _hthumbTrackTimer.Enabled = false;

                        // perform scroll immediately only if last refresh is very old
                        int currentThumbTrack = Environment.TickCount;
                        if (currentThumbTrack - _lastHThumbtrack > THUMPTRACKDELAY)
                        {
                            PerformHScrollThumbTrack(null, null);
                            _lastHThumbtrack = currentThumbTrack;
                            break;
                        }

                        // start thumbtrack timer
                        _thumbTrackPosition = FromHScrollPos(e.NewValue);
                        _hthumbTrackTimer.Enabled = true;
                        break;

                    case ScrollEventType.First:
                        break;

                    default:
                        break;
                }

                e.NewValue = ToScrollHPos(_scrollHpos);
            }
        }

        /// <summary>
        /// Performs the thumbtrack scrolling after an delay.
        /// </summary>
        private void PerformVScrollThumbTrack(object sender, EventArgs e)
        {
            _vthumbTrackTimer.Enabled = false;
            PerformVScrollThumpPosition(_thumbTrackPosition);
            _lastVThumbtrack = Environment.TickCount;
        }

        /// <summary>
        /// Performs the thumbtrack scrolling after an delay.
        /// </summary>
        private void PerformHScrollThumbTrack(object sender, EventArgs e)
        {
            _hthumbTrackTimer.Enabled = false;
            PerformHScrollThumpPosition(_thumbTrackPosition);
            _lastHThumbtrack = Environment.TickCount;
        }

        /// <summary>
        /// 刷新控件
        /// </summary>
        public override void Refresh()
        {
            DestroyCaret();
            UpdateRectanglePositioning();
            UpdateVisibilityBytes();
            CreateCaret();
            UpdateCaret();
            Invalidate();
            base.Refresh();
        }

        private void UpdateHScrollSize()
        {
            Debug.WriteLine("UpdateHScrollSize()", "HexBox");
            // calc scroll bar info
            if (_hScrollBarVisible)
            {
                long scrollmax = Math.Abs(_requiredWidth - ClientRectangle.Width);

                long scrollpos = _scrollHpos;

                if (scrollmax < _scrollHmax)
                {
                    /* Data size has been decreased. */
                    if (_scrollHpos == _scrollHmax)
                        /* Scroll one line up if we at bottom. */
                        PerformScrollColUp();
                }

                if (scrollmax == _scrollHmax && scrollpos == _scrollHpos)
                    return;

                _scrollHmin = 0;
                _scrollHmax = scrollmax;
                _scrollHpos = Math.Min(scrollpos, scrollmax);
                UpdateHScroll();
            }
            else if (_hScrollBarVisible)
            {
                // disable scroll bar
                _scrollHmin = 0;
                _scrollHmax = 0;
                _scrollHpos = 0;
                UpdateHScroll();
            }
        }

        private void UpdateVScrollSize()
        {
            Debug.WriteLine("UpdateVScrollSize()", "HexBox");

            // calc scroll bar info
            if (_vScrollBarVisible && _byteProvider != null && _byteProvider.Length > 0 && _iHexMaxHBytes != 0)
            {
                long scrollmax = (long)Math.Ceiling((_byteProvider.Length + 1) / (double)_iHexMaxHBytes - _iHexMaxVBytes);
                scrollmax = Math.Max(0, scrollmax);

                long scrollpos = _startByte / _iHexMaxHBytes;

                if (scrollmax < _scrollVmax)
                {
                    /* Data size has been decreased. */
                    if (_scrollVpos == _scrollVmax)
                        /* Scroll one line up if we at bottom. */
                        PerformScrollLineUp();
                }

                if (scrollmax == _scrollVmax && scrollpos == _scrollVpos)
                    return;

                _scrollVmin = 0;
                _scrollVmax = scrollmax;
                _scrollVpos = Math.Min(scrollpos, scrollmax);
                UpdateVScroll();
            }
            else if (_vScrollBarVisible)
            {
                // disable scroll bar
                _scrollVmin = 0;
                _scrollVmax = 0;
                _scrollVpos = 0;
                UpdateVScroll();
            }
        }

        private void UpdateVScroll()
        {
            Debug.WriteLine("UpdateVScroll()", "HexBox");

            int max = ToScrollMax(_scrollVmax);

            if (max > 0)
            {
                _vScrollBar.Minimum = 0;
                _vScrollBar.Maximum = max;
                _vScrollBar.Value = ToScrollVPos(_scrollVpos);
                _vScrollBar.Visible = true;
            }
            else
            {
                _vScrollBar.Visible = false;
            }
        }

        private void UpdateHScroll()
        {
            Debug.WriteLine("UpdateHScroll()", "HexBox");

            int max = ToScrollMax(_scrollHmax);

            if (max > 0 && _requiredWidth > ClientRectangle.Width)
            {
                _hScrollBar.Minimum = 0;
                _hScrollBar.Maximum = max;
                _hScrollBar.Value = ToScrollHPos(_scrollHpos);
                _hScrollBar.Visible = true;
            }
            else
            {
                _hScrollBar.Visible = false;
            }
        }

        private int ToScrollHPos(long value)
        {
            int max = 65535;

            if (_scrollHmax < max)
                return (int)value;
            else
            {
                double valperc = value / (double)_scrollHmax * 100;
                int res = (int)Math.Floor((double)max / 100 * valperc);
                res = (int)Math.Max(_scrollHmin, res);
                res = (int)Math.Min(_scrollHmax, res);
                return res;
            }
        }

        private int ToScrollVPos(long value)
        {
            int max = 65535;

            if (_scrollVmax < max)
                return (int)value;
            else
            {
                double valperc = value / (double)_scrollVmax * 100;
                int res = (int)Math.Floor((double)max / 100 * valperc);
                res = (int)Math.Max(_scrollVmin, res);
                res = (int)Math.Min(_scrollVmax, res);
                return res;
            }
        }

        private long FromVScrollPos(int value)
        {
            int max = 65535;
            if (_scrollVmax < max)
            {
                return value;
            }
            else
            {
                double valperc = value / (double)max * 100;
                long res = (int)Math.Floor(_scrollVmax / (double)100 * valperc);
                return res;
            }
        }

        private long FromHScrollPos(int value)
        {
            int max = 65535;
            if (_scrollHmax < max)
            {
                return value;
            }
            else
            {
                double valperc = value / (double)max * 100;
                long res = (int)Math.Floor(_scrollHmax / (double)100 * valperc);
                return res;
            }
        }

        private int ToScrollMax(long value)
        {
            long max = 65535;
            if (value > max)
                return (int)max;
            else
                return (int)value;
        }

        private void PerformScrollToLine(long pos)
        {
            if (pos < _scrollVmin || pos > _scrollVmax || pos == _scrollVpos)
                return;

            _scrollVpos = pos;

            UpdateVScroll();
            UpdateVisibilityBytes();
            UpdateCaret();
            Invalidate();
        }

        private void PerformScrollToCol(long pos)
        {
            if (pos < _scrollHmin || pos > _scrollHmax || pos == _scrollHpos)
                return;

            _scrollHpos = pos;

            UpdateHScroll();
            UpdateVisibilityBytes();
            UpdateCaret();
            Invalidate();
        }

        private void PerformScrollLines(int lines)
        {
            long pos;
            if (lines > 0)
            {
                pos = Math.Min(_scrollVmax, _scrollVpos + lines);
            }
            else if (lines < 0)
            {
                pos = Math.Max(_scrollVmin, _scrollVpos + lines);
            }
            else
            {
                return;
            }

            PerformScrollToLine(pos);
        }

        private void PerformScrollCols(int cols)
        {
            long pos;
            if (cols > 0)
            {
                pos = Math.Min(_scrollHmax, _scrollHpos + cols);
            }
            else if (cols < 0)
            {
                pos = Math.Max(_scrollHmin, _scrollHpos + cols);
            }
            else
            {
                return;
            }

            PerformScrollToCol(pos);
        }

        private void PerformScrollColDown()
        {
            PerformScrollCols(1);
        }

        private void PerformScrollColUp()
        {
            PerformScrollCols(-1);
        }

        private void PerformScrollLineDown()
        {
            PerformScrollLines(1);
        }

        private void PerformScrollLineUp()
        {
            PerformScrollLines(-1);
        }

        private void PerformScrollPageDown()
        {
            PerformScrollLines(_iHexMaxVBytes);
        }

        private void PerformScrollPageUp()
        {
            PerformScrollLines(-_iHexMaxVBytes);
        }

        private void PerformVScrollThumpPosition(long pos)
        {
            // Bug fix: Scroll to end, do not scroll to end
            int difference = (_scrollVmax > 65535) ? 10 : 9;

            if (ToScrollVPos(pos) == ToScrollMax(_scrollVmax) - difference)
                pos = _scrollVmax;
            // End Bug fix

            PerformScrollToLine(pos);
        }

        private void PerformHScrollThumpPosition(long pos)
        {

            // Bug fix: Scroll to end, do not scroll to end
            int difference = (_scrollHmax > 65535) ? 10 : 9;

            if (ToScrollVPos(pos) == ToScrollMax(_scrollHmax) - difference)
                pos = _scrollHmax;
            // End Bug fix

            PerformScrollToCol(pos);
        }

        /// <summary>
        /// Scrolls the selection start byte into view
        /// </summary>
        public void ScrollByteIntoView()
        {
            Debug.WriteLine("ScrollByteIntoView()", "HexBox");

            ScrollByteIntoView(_bytePos);
        }

        /// <summary>
        /// Scrolls the specific byte into view
        /// </summary>
        /// <param name="index">the index of the byte</param>
        public void ScrollByteIntoView(long index)
        {
            Debug.WriteLine("ScrollByteIntoView(long index)", "HexBox");

            if (_byteProvider == null || _keyInterpreter == null)
                return;

            if (index < _startByte)
            {
                Point point = GetGridBytePoint(index);
                PerformVScrollThumpPosition(point.Y);
                PointF pointF = GetBytePointF(point);
                /*水平滚动条重定位*/
                if (_hScrollBar.Visible && (ClientRectangle.X > pointF.X || ClientRectangle.X+ClientRectangle.Width/2 < pointF.X))
                {
                    PerformHScrollThumpPosition((long)_charSize.Width * point.X);
                }
            }
            else if (index > _endByte)
            {
                Point point = GetGridBytePoint(index);
                PerformVScrollThumpPosition(point.Y - _iHexMaxVBytes - 1);
                PointF pointF = GetBytePointF(point);
                /*水平滚动条重定位*/
                if (_hScrollBar.Visible && (ClientRectangle.X > pointF.X || ClientRectangle.X + ClientRectangle.Width / 2 < pointF.X))
                {
                    PerformHScrollThumpPosition((long) _charSize.Width * point.X );
                }
            }
        }

        /// <summary>
        /// 跳转至指定行
        /// </summary>
        /// <param name="line">第几行</param>
        public void ScrollLineIntoView(long line) => PerformVScrollThumpPosition(line - 1);
    }
}