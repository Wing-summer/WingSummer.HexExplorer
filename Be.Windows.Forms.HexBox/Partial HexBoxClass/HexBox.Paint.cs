using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Be.Windows.Forms
{
    public partial class HexBox
    {
        /// <summary>f
        /// Paints the background.
        /// </summary>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            switch (_borderStyle)
            {
                case BorderStyle.Fixed3D:
                    {
                        if (TextBoxRenderer.IsSupported)
                        {
                            VisualStyleElement state = VisualStyleElement.TextBox.TextEdit.Normal;
                            Color backColor = BackColor;

                            if (Enabled)
                            {
                                if (_readOnly)
                                    state = VisualStyleElement.TextBox.TextEdit.ReadOnly;
                                else if (Focused)
                                    state = VisualStyleElement.TextBox.TextEdit.Focused;
                            }
                            else
                            {
                                state = VisualStyleElement.TextBox.TextEdit.Disabled;
                                backColor = BackColorDisabled;
                            }

                            VisualStyleRenderer vsr = new VisualStyleRenderer(state);
                            vsr.DrawBackground(e.Graphics, ClientRectangle);

                            Rectangle rectContent = vsr.GetBackgroundContentRectangle(e.Graphics, ClientRectangle);
                            e.Graphics.FillRectangle(new SolidBrush(backColor), rectContent);
                        }
                        else
                        {
                            // draw background
                            e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

                            // draw default border
                            ControlPaint.DrawBorder3D(e.Graphics, ClientRectangle, Border3DStyle.Sunken);
                        }

                        break;
                    }
                case BorderStyle.FixedSingle:
                    {
                        // draw background
                        e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

                        // draw fixed single border
                        ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
                        break;
                    }
                default:
                    {
                        // draw background
                        e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
                        break;
                    }
            }
        }

        /// <summary>
        /// Paints the hex box.
        /// </summary>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_byteProvider == null)
                return;

            Debug.WriteLine("OnPaint " + DateTime.Now.ToString(), "HexBox");

            // draw only in the content rectangle, so exclude the border and the scrollbar.
            Region r = new Region(ClientRectangle);
            r.Exclude(_recContent);
            e.Graphics.ExcludeClip(r);

            UpdateVisibilityBytes();

            if (_lineInfoVisible)
                PaintLineInfo(e.Graphics, _startByte, _endByte);

            if (_stringViewVisible)
            {
                PaintHexAndStringView(e.Graphics, _startByte, _endByte);
                if (_shadowSelectionVisible)
                    PaintCurrentBytesSign(e.Graphics);
            }
            else
            {
                PaintHex(e.Graphics, _startByte, _endByte);
            }
            if (_columnInfoVisible)
                PaintHeaderRow(e.Graphics);
            if (_groupSeparatorVisible)
                PaintColumnSeparator(e.Graphics);
        }

        /// <summary>
        /// 当水平滚动条移动时提供的相对原来的位移，记编辑区向右移动为正
        /// </summary>
        /// <returns></returns>
        private long GetHOffValue()
        {
            return (long)(-_scrollHpos * _scaling);
        }

        private void PaintLineInfo(Graphics g, long startByte, long endByte)
        {
            // Ensure endByte isn't > length of array.
            endByte = Math.Min(_byteProvider.Length - 1, endByte);

            Color lineInfoColor = (InfoForeColor != Color.Empty) ? InfoForeColor : ForeColor;
            Brush brush = new SolidBrush(lineInfoColor);

            int maxLine = GetGridBytePoint(endByte - startByte).Y + 1;

            if (ShowLineInfoBackColor)
                g.FillRectangle(new Pen(_lineInfoBackColor).Brush, _recLineInfo.X + GetHOffValue(), 0, _recLineInfo.Width - _charSize.Width / 2, _recLineInfo.Y);

            for (int i = 0; i < maxLine; i++)
            {
                long firstLineByte = startByte + _iHexMaxHBytes * i + _baseAddr;

                PointF bytePointF = GetBytePointF(new Point(0, 0 + i));
                string info = firstLineByte.ToString(_hexStringFormat, Thread.CurrentThread.CurrentCulture);
                int addrlen = curIsLongHex ? 16 : 8;
                int nulls = addrlen - info.Length;
                string formattedInfo;
                if (nulls > -1)
                {
                    formattedInfo = info.PadLeft(addrlen, '0');
                }
                else
                {
                    formattedInfo = curIsLongHex ? longhex : shorthex;
                }

                SizeF sizeF = g.MeasureString(formattedInfo, font);
                PointF pointF;
                switch (LineInfoAlignment)
                {
                    case HorizontalAlignment.Left:
                        pointF = new PointF(_recLineInfo.X + GetHOffValue(), bytePointF.Y);
                        break;

                    case HorizontalAlignment.Right:
                        pointF = new PointF(_recLineInfo.Right - sizeF.Width + GetHOffValue(), bytePointF.Y);
                        break;

                    case HorizontalAlignment.Center:
                        pointF = new PointF(_recLineInfo.X + (_recLineInfo.Width - sizeF.Width) / 2 + GetHOffValue(), bytePointF.Y);
                        break;

                    default:
                        throw new ArgumentException("LineInfoAlignment参数无效");
                }
                if (ShowLineInfoBackColor)
                    g.FillRectangle(new Pen(_lineInfoBackColor).Brush, _recLineInfo.X + GetHOffValue(), bytePointF.Y,
                        _recLineInfo.Width - _charSize.Width / 2, _charSize.Height);
                g.DrawString(formattedInfo, font, brush, pointF, _stringFormat);
            }
        }

        private void PaintHeaderRow(Graphics g)
        {
            Brush brush = new SolidBrush(InfoForeColor);
            for (int col = 0; col < _iHexMaxHBytes; col++)
            {
                PaintColumnInfo(g, (byte)col, brush, col);
            }
        }

        private void PaintColumnSeparator(Graphics g)
        {
            PointF headerPointF;

            if (StringViewVisible)
            {
                headerPointF = new PointF(_iHexMaxHBytes, _recColumnInfo.Y);
                headerPointF.X = (3 * _charSize.Width) * headerPointF.X + _recColumnInfo.X + GetHOffValue();
                headerPointF.X -= _charSize.Width / 2;
                g.DrawLine(HexStringLinePen, headerPointF, new PointF(headerPointF.X, headerPointF.Y + _recColumnInfo.Height + _recHex.Height));
            }

            for (int col = GroupSize; col < _iHexMaxHBytes; col += GroupSize)
            {
                headerPointF = GetColumnInfoPointF(col);
                headerPointF.X -= _charSize.Width / 2;
                g.DrawLine(GroupLinePen, headerPointF, new PointF(headerPointF.X, headerPointF.Y + _recColumnInfo.Height + _recHex.Height));
            }
        }

        private void PaintHex(Graphics g, long startByte, long endByte)
        {
            Brush brush = new SolidBrush(GetDefaultForeColor());
            Brush selBrush = new SolidBrush(_selectionForeColor);
            Brush selBrushBack = new SolidBrush(Color.FromArgb(_selectionBackColorOpacity, _selectionBackColor));
            g.CompositingQuality = CompositingQuality.GammaCorrected;

            int counter = -1;
            long intern_endByte = Math.Min(_byteProvider.Length - 1, endByte + _iHexMaxHBytes);

            bool isKeyInterpreterActive = _keyInterpreter == null || _keyInterpreter.GetType() == typeof(KeyInterpreter);

            for (long i = startByte; i < intern_endByte + 1; i++)
            {
                counter++;
                Point gridPoint = GetGridBytePoint(counter);
                byte b = _byteProvider.ReadByte(i);

                bool isSelectedByte = i >= _bytePos && i <= (_bytePos + _selectionLength - 1) && _selectionLength != 0;

                if (isSelectedByte && isKeyInterpreterActive)
                {
                    PaintHexStringSelected(g, b, selBrush, selBrushBack, gridPoint);
                }
                else
                {
                    PaintHexString(g, b, brush, gridPoint);
                }
            }
        }

        private void PaintHexString(Graphics g, byte b, Brush brush, Point gridPoint, Brush brushBack = null)
        {
            PointF bytePointF = GetBytePointF(gridPoint);

            string sB = ConvertByteToHex(b);

            // Color the backgound over ere
            if (brushBack != null)
            {
                float bcWidth = _charSize.Width * 3;
                g.FillRectangle(brushBack, bytePointF.X - _charSize.Width / 2, bytePointF.Y, bcWidth, _charSize.Height);
            }
            g.DrawString(sB.Substring(0, 1), font, brush, bytePointF, _stringFormat);
            bytePointF.X += _charSize.Width;
            g.DrawString(sB.Substring(1, 1), font, brush, bytePointF, _stringFormat);
        }

        private void PaintColumnInfo(Graphics g, byte b, Brush brush, int col)
        {
            PointF headerPointF = GetColumnInfoPointF(col);

            string sB = ConvertByteToHex(b);

            if (ShowColumnInfoBackColor)
                g.FillRectangle(new Pen(_columnInfoBackColor).Brush, new Rectangle((int)(headerPointF.X - _charSize.Width / 2),
                    (int)headerPointF.Y, (int)_charSize.Width * 3, (int)_charSize.Height));

            g.DrawString(sB.Substring(0, 1), font, brush, headerPointF, _stringFormat);
            headerPointF.X += _charSize.Width;
            g.DrawString(sB.Substring(1, 1), font, brush, headerPointF, _stringFormat);
        }

        private void PaintHexStringSelected(Graphics g, byte b, Brush brush, Brush brushBack, Point gridPoint)
        {
            string sB = b.ToString(_hexStringFormat, System.Threading.Thread.CurrentThread.CurrentCulture);
            if (sB.Length == 1)
                sB = "0" + sB;

            PointF bytePointF = GetBytePointF(gridPoint);

            float bcWidth = _charSize.Width * 3;
            g.FillRectangle(brushBack, bytePointF.X - _charSize.Width / 2, bytePointF.Y, bcWidth, _charSize.Height);
            g.DrawString(sB.Substring(0, 1), font, brush, bytePointF, _stringFormat);
            bytePointF.X += _charSize.Width;
            g.DrawString(sB.Substring(1, 1), font, brush, bytePointF, _stringFormat);
        }

        /// <summary>
        /// 绘制hex和右边栏string
        /// </summary>
        /// <param name="g"></param>
        /// <param name="startByte"></param>
        /// <param name="endByte"></param>
        private void PaintHexAndStringView(Graphics g, long startByte, long endByte)
        {
            Brush brush = new SolidBrush(GetDefaultForeColor());
            Brush selBrush = new SolidBrush(_selectionForeColor);
            Brush selBrushBack = new SolidBrush(Color.FromArgb(_selectionBackColorOpacity, _selectionBackColor));
            g.CompositingQuality = CompositingQuality.GammaCorrected;

            int counter = -1;
            long intern_endByte = Math.Min(_byteProvider.Length - 1, endByte + _iHexMaxHBytes);

            bool isKeyInterpreterActive = _keyInterpreter == null || _keyInterpreter.GetType() == typeof(KeyInterpreter);
            bool isStringKeyInterpreterActive = _keyInterpreter != null && _keyInterpreter.GetType() == typeof(StringKeyInterpreter);

            byte[] buffer = null;
            if (_isCharToUnicode)
            {
                buffer = new byte[2];
            }

            for (long i = startByte; i < intern_endByte + 1; i++)
            {
                counter++;
                Point gridPoint = GetGridBytePoint(counter);
                PointF byteStringPointF = GetByteStringPointF(gridPoint);
                byte b = _byteProvider.ReadByte(i);

                bool isSelectedByte = i >= _bytePos && i <= (_bytePos + _selectionLength - 1) && _selectionLength != 0;

                if (isSelectedByte && isKeyInterpreterActive)
                {
                    HighlightedRegion highlighted = HighligedRegions.Find(k => k.IsByteSelected(i));
                    if (highlighted != null)
                    {
                        PaintHexStringSelected(g, b, selBrush, new HatchBrush(HatchStyle.Percent50, highlighted.Color), gridPoint);
                    }
                    else
                    {
                        PaintHexStringSelected(g, b, selBrush, selBrushBack, gridPoint);
                    }
                }
                else
                {
                    // Check if its in a higlighted region
                    bool paintedByte = false;
                    if (_ShowBookMarkMain)
                    {
                        foreach (var HiSection in HighligedRegions)
                        {
                            if (HiSection.IsByteSelected(i))
                            {
                                var colorBrush = new SolidBrush(HiSection.Color);
                                PaintHexString(g, b, brush, gridPoint, colorBrush);
                                paintedByte = true;
                                break;
                            }
                        }
                    }

                    if (_ShowBookMark)
                    {
                        foreach (var HiSection in HighlightedRegions)
                        {
                            if (HiSection.IsByteSelected(i))
                            {
                                var colorBrush = new SolidBrush(HiSection.Color);
                                PaintHexString(g, b, brush, gridPoint, colorBrush);
                                paintedByte = true;
                                break;
                            }
                        }
                    }

                    if (!paintedByte)
                    {
                        PaintHexString(g, b, brush, gridPoint);
                    }
                }
                /*绘制解析后的字符串*/
                string s;
                if (_isCharToUnicode)
                {
                    if ((i - startByte) % 2 != 0)
                    {
                        continue;
                    }
                    buffer[0] = b;
                    buffer[1] = _byteProvider.ReadByte(i + 1);
                    s = Encoding.Unicode.GetString(buffer);
                }
                else
                {
                    s = ByteCharConverter.ToChar(b).ToString();
                }
                if (isSelectedByte && isStringKeyInterpreterActive)
                {
                    g.FillRectangle(selBrushBack, byteStringPointF.X, byteStringPointF.Y, _charSize.Width, _charSize.Height);

                    g.DrawString(s, font, selBrush, byteStringPointF, _stringFormat);
                }
                else
                {
                    g.DrawString(s, font, brush, byteStringPointF, _stringFormat);
                }
            }
        }

        private void PaintCurrentBytesSign(Graphics g)
        {
            if (_keyInterpreter != null && _bytePos != -1 && Enabled)
            {
                if (_keyInterpreter.GetType() == typeof(KeyInterpreter))
                {
                    /*选左边*/
                    if (_selectionLength == 0)
                    {
                        Point gp = GetGridBytePoint(_bytePos - _startByte);
                        PointF pf = GetByteStringPointF(gp);
                        Size s = new Size((int)_charSize.Width, (int)_charSize.Height);
                        Rectangle r = new Rectangle((int)pf.X, (int)pf.Y, s.Width, s.Height);
                        if (r.IntersectsWith(_recStringView))
                        {
                            r.Intersect(_recStringView);
                            PaintCurrentByteSign(g, r);
                        }
                    }
                    else
                    {
                        Rectangle _recStringView = this._recStringView;
                        _recStringView.X += (int)GetHOffValue();

                        int lineWidth = (int)(_recStringView.Width - _charSize.Width);

                        Point startSelGridPoint = GetGridBytePoint(_bytePos - _startByte);
                        PointF startSelPointF = GetByteStringPointF(startSelGridPoint);

                        Point endSelGridPoint = GetGridBytePoint(_bytePos - _startByte + _selectionLength - 1);
                        PointF endSelPointF = GetByteStringPointF(endSelGridPoint);

                        int multiLine = endSelGridPoint.Y - startSelGridPoint.Y;
                        if (multiLine == 0)
                        {
                            Rectangle singleLine = new Rectangle(
                                (int)startSelPointF.X,
                                (int)startSelPointF.Y,
                                (int)(endSelPointF.X - startSelPointF.X + _charSize.Width),
                                (int)_charSize.Height);
                            if (singleLine.IntersectsWith(_recStringView))
                            {
                                singleLine.Intersect(_recStringView);
                                PaintCurrentByteSign(g, singleLine);
                            }
                        }
                        else
                        {
                            Rectangle firstLine = new Rectangle(
                                (int)startSelPointF.X,
                                (int)startSelPointF.Y,
                                (int)(_recStringView.X + lineWidth - startSelPointF.X + _charSize.Width),
                                (int)_charSize.Height);
                            if (firstLine.IntersectsWith(_recStringView))
                            {
                                firstLine.Intersect(_recStringView);
                                PaintCurrentByteSign(g, firstLine);
                            }

                            if (multiLine > 1)
                            {
                                Rectangle betweenLines = new Rectangle(
                                    _recStringView.X,
                                    (int)(startSelPointF.Y + _charSize.Height),
                                    _recStringView.Width,
                                    (int)(_charSize.Height * (multiLine - 1)));
                                if (betweenLines.IntersectsWith(_recStringView))
                                {
                                    betweenLines.Intersect(_recStringView);
                                    PaintCurrentByteSign(g, betweenLines);
                                }
                            }

                            Rectangle lastLine = new Rectangle(
                                _recStringView.X,
                                (int)endSelPointF.Y,
                                (int)(endSelPointF.X - _recStringView.X + _charSize.Width),
                                (int)_charSize.Height);
                            if (lastLine.IntersectsWith(_recStringView))
                            {
                                lastLine.Intersect(_recStringView);
                                PaintCurrentByteSign(g, lastLine);
                            }
                        }
                    }
                }
                else
                {
                    /*选右边*/
                    if (_selectionLength == 0)
                    {
                        Point gp = GetGridBytePoint(_bytePos - _startByte);
                        PointF pf = GetBytePointF(gp);
                        Size s = new Size((int)_charSize.Width * 2, (int)_charSize.Height);
                        Rectangle r = new Rectangle((int)pf.X, (int)pf.Y, s.Width, s.Height);
                        PaintCurrentByteSign(g, r);
                    }
                    else
                    {
                        Rectangle _recHex = this._recHex;
                        _recHex.X += (int)GetHOffValue();

                        int lineWidth = (int)(_recHex.Width - _charSize.Width * 5);

                        Point startSelGridPoint = GetGridBytePoint(_bytePos - _startByte);
                        PointF startSelPointF = GetBytePointF(startSelGridPoint);

                        Point endSelGridPoint = GetGridBytePoint(_bytePos - _startByte + _selectionLength - 1);
                        PointF endSelPointF = GetBytePointF(endSelGridPoint);

                        int multiLine = endSelGridPoint.Y - startSelGridPoint.Y;
                        if (multiLine == 0)
                        {
                            Rectangle singleLine = new Rectangle(
                                (int)startSelPointF.X,
                                (int)startSelPointF.Y,
                                (int)(endSelPointF.X - startSelPointF.X + _charSize.Width * 2),
                                (int)_charSize.Height);
                            if (singleLine.IntersectsWith(_recHex))
                            {
                                singleLine.Intersect(_recHex);
                                PaintCurrentByteSign(g, singleLine);
                            }
                        }
                        else
                        {
                            Rectangle firstLine = new Rectangle(
                                (int)startSelPointF.X,
                                (int)startSelPointF.Y,
                                (int)(_recHex.X + lineWidth - startSelPointF.X + _charSize.Width * 2),
                                (int)_charSize.Height);
                            if (firstLine.IntersectsWith(_recHex))
                            {
                                firstLine.Intersect(_recHex);
                                PaintCurrentByteSign(g, firstLine);
                            }

                            if (multiLine > 1)
                            {
                                Rectangle betweenLines = new Rectangle(
                                    _recHex.X,
                                    (int)(startSelPointF.Y + _charSize.Height),
                                    (int)(lineWidth + _charSize.Width * 2),
                                    (int)(_charSize.Height * (multiLine - 1)));
                                if (betweenLines.IntersectsWith(_recHex))
                                {
                                    betweenLines.Intersect(_recHex);
                                    PaintCurrentByteSign(g, betweenLines);
                                }
                            }

                            Rectangle lastLine = new Rectangle(
                                _recHex.X,
                                (int)endSelPointF.Y,
                                (int)(endSelPointF.X - _recHex.X + _charSize.Width * 2),
                                (int)_charSize.Height);
                            if (lastLine.IntersectsWith(_recHex))
                            {
                                lastLine.Intersect(_recHex);
                                PaintCurrentByteSign(g, lastLine);
                            }
                        }
                    }
                }
            }
        }

        private void PaintCurrentByteSign(Graphics g, Rectangle rec)
        {
            // stack overflowexception on big files - workaround
            if (rec.Top < 0 || rec.Left < 0 || rec.Width <= 0 || rec.Height <= 0)
                return;

            Bitmap myBitmap = new Bitmap(rec.Width, rec.Height);
            Graphics bitmapGraphics = Graphics.FromImage(myBitmap);

            SolidBrush greenBrush = new SolidBrush(_shadowSelectionColor);

            bitmapGraphics.FillRectangle(greenBrush, 0,
                0, rec.Width, rec.Height);

            g.CompositingQuality = CompositingQuality.GammaCorrected;

            g.DrawImage(myBitmap, rec.Left, rec.Top);
        }

        private Color GetDefaultForeColor()
        {
            if (Enabled)
                return ForeColor;
            else
                return Color.Gray;
        }

        private void UpdateVisibilityBytes()
        {
            if (_byteProvider == null || _byteProvider.Length == 0)
                return;

            _startByte = _scrollVpos * _iHexMaxHBytes;
            _endByte = Math.Min(_byteProvider.Length - 1, _startByte + _iHexMaxBytes);
        }
    }
}