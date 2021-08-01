using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Be.Windows.Forms
{
    public partial class HexBox
    {
        /// <summary>
        /// Handles user input such as mouse and keyboard input during hex view edit
        /// </summary>
        private class KeyInterpreter : IKeyInterpreter
        {
            /// <summary>
            /// Delegate for key-down processing.
            /// </summary>
            /// <param name="m">the message object contains key data information</param>
            /// <returns>True, if the message was processed</returns>
            private delegate bool MessageDelegate(ref Message m);

            #region Fields

            /// <summary>
            /// Contains the parent HexBox control
            /// </summary>
            protected HexBox _hexBox;

            /// <summary>
            /// Contains True, if shift key is down
            /// </summary>
            protected bool _shiftDown;

            /// <summary>
            /// Contains True, if mouse is down
            /// </summary>
            private bool _mouseDown;

            /// <summary>
            /// Contains the selection start position info
            /// </summary>
            private BytePositionInfo _bpiStart;

            /// <summary>
            /// Contains the current mouse selection position info
            /// </summary>
            private BytePositionInfo _bpi;

            /// <summary>
            /// Contains all message handlers of key interpreter key down message
            /// </summary>
            private Dictionary<Keys, MessageDelegate> _messageHandlers;

            #endregion

            #region Ctors

            public KeyInterpreter(HexBox hexBox)
            {
                _hexBox = hexBox;
            }

            #endregion

            #region Activate, Deactive methods

            public virtual void Activate()
            {
                _hexBox.MouseDown += new MouseEventHandler(BeginMouseSelection);
                _hexBox.MouseMove += new MouseEventHandler(UpdateMouseSelection);
                _hexBox.MouseUp += new MouseEventHandler(EndMouseSelection);
                _hexBox.MouseDoubleClick += new MouseEventHandler(MouseDblClickSelection);
            }

            public virtual void Deactivate()
            {
                _hexBox.MouseDown -= new MouseEventHandler(BeginMouseSelection);
                _hexBox.MouseMove -= new MouseEventHandler(UpdateMouseSelection);
                _hexBox.MouseUp -= new MouseEventHandler(EndMouseSelection);
                _hexBox.MouseDoubleClick -= new MouseEventHandler(MouseDblClickSelection);
            }

            #endregion

            #region Mouse selection methods

            private void MouseDblClickSelection(object sender, MouseEventArgs e)
            {
                Debug.WriteLine("MouseDblClickSelection()", "KeyInterpreter");
                if (e.Button != MouseButtons.Left)
                    return;
                _hexBox.InternalSelect(GetBytePositionInfo(new Point(e.X, e.Y)).Index, 1);
            }

            private void BeginMouseSelection(object sender, MouseEventArgs e)
            {
                Debug.WriteLine("BeginMouseSelection()", "KeyInterpreter");

                if (e.Button != MouseButtons.Left)
                    return;

                _mouseDown = true;

                if (!_shiftDown)
                {
                    _bpiStart = new BytePositionInfo(_hexBox._bytePos, _hexBox._byteCharacterPos);
                    _hexBox.ReleaseSelection();
                }
                else
                {
                    UpdateMouseSelection(this, e);
                }
            }

            private void UpdateMouseSelection(object sender, MouseEventArgs e)
            {
                if (!_mouseDown)
                    return;

                _bpi = GetBytePositionInfo(new Point(e.X, e.Y));
                long selEnd = _bpi.Index;
                long realselStart;
                long realselLength;

                if (selEnd < _bpiStart.Index)
                {
                    realselStart = selEnd;
                    realselLength = _bpiStart.Index - selEnd + 1;
                }
                else if (selEnd > _bpiStart.Index)
                {
                    realselStart = _bpiStart.Index;
                    realselLength = selEnd - realselStart + 1;
                }
                else
                {
                    realselStart = _hexBox._bytePos;
                    realselLength = 0;
                }

                if (realselStart != _hexBox._bytePos || realselLength != _hexBox._selectionLength)
                {
                    _hexBox.InternalSelect(realselStart, realselLength);
                    _hexBox.ScrollByteIntoView(_bpi.Index);
                }
            }

            private void EndMouseSelection(object sender, MouseEventArgs e)
            {
                _mouseDown = false;
            }

            #endregion

            #region PrePrcessWmKeyDown methods

            public virtual bool PreProcessWmKeyDown(ref Message m)
            {
                Debug.WriteLine("PreProcessWmKeyDown(ref Message m)", "KeyInterpreter");

                Keys vc = (Keys)m.WParam.ToInt32();

                Keys keyData = vc | ModifierKeys;

                // detect whether key down event should be raised
                var hasMessageHandler = MessageHandlers.ContainsKey(keyData);
                if (hasMessageHandler && RaiseKeyDown(keyData))
                    return true;

                MessageDelegate messageHandler = hasMessageHandler
                    ? MessageHandlers[keyData]
                    : new MessageDelegate(PreProcessWmKeyDown_Default);

                return messageHandler(ref m);
            }

            protected bool PreProcessWmKeyDown_Default(ref Message m)
            {
                 _hexBox.ScrollByteIntoView();
                return _hexBox.BasePreProcessMessage(ref m);
            }

            protected bool RaiseKeyDown(Keys keyData)
            {
                KeyEventArgs e = new KeyEventArgs(keyData);
                _hexBox.OnKeyDown(e);
                return e.Handled;
            }

            protected virtual bool PreProcessWmKeyDown_Left(ref Message m)
            {
                return PerformPosMoveLeft();
            }

            protected virtual bool PreProcessWmKeyDown_Up(ref Message m)
            {
                long pos = _hexBox._bytePos;
                int cp = _hexBox._byteCharacterPos;

                if (!(pos == 0 && cp == 0))
                {
                    pos = Math.Max(-1, pos - _hexBox._iHexMaxHBytes);
                    if (pos == -1)
                        return true;

                    _hexBox.SetPosition(pos);

                    if (pos < _hexBox._startByte)
                    {
                        _hexBox.PerformScrollLineUp();
                    }

                    _hexBox.UpdateCaret();
                    _hexBox.Invalidate();
                }

                _hexBox.ScrollByteIntoView();
                _hexBox.ReleaseSelection();

                return true;
            }

            protected virtual bool PreProcessWmKeyDown_Right(ref Message m)
            {
                return PerformPosMoveRight();
            }

            protected virtual bool PreProcessWmKeyDown_Down(ref Message m)
            {
                long pos = _hexBox._bytePos;
                int cp = _hexBox._byteCharacterPos;

                if (pos == _hexBox._byteProvider.Length && cp == 0)
                    return true;

                pos = Math.Min(_hexBox._byteProvider.Length, pos + _hexBox._iHexMaxHBytes);

                if (pos == _hexBox._byteProvider.Length)
                    cp = 0;

                _hexBox.SetPosition(pos, cp);

                if (pos > _hexBox._endByte - 1)
                {
                    _hexBox.PerformScrollLineDown();
                }

                _hexBox.UpdateCaret();
                _hexBox.ScrollByteIntoView();
                _hexBox.ReleaseSelection();
                _hexBox.Invalidate();

                return true;
            }

            protected virtual bool PreProcessWmKeyDown_PageUp(ref Message m)
            {
                long pos = _hexBox._bytePos;
                int cp = _hexBox._byteCharacterPos;

                if (pos == 0 && cp == 0)
                    return true;

                pos = Math.Max(0, pos - _hexBox._iHexMaxBytes);
                if (pos == 0)
                    return true;

                _hexBox.SetPosition(pos);

                if (pos < _hexBox._startByte)
                {
                    _hexBox.PerformScrollPageUp();
                }

                _hexBox.ReleaseSelection();
                _hexBox.UpdateCaret();
                _hexBox.Invalidate();
                return true;
            }

            protected virtual bool PreProcessWmKeyDown_PageDown(ref Message m)
            {
                long pos = _hexBox._bytePos;
                int cp = _hexBox._byteCharacterPos;

                if (pos == _hexBox._byteProvider.Length && cp == 0)
                    return true;

                pos = Math.Min(_hexBox._byteProvider.Length, pos + _hexBox._iHexMaxBytes);

                if (pos == _hexBox._byteProvider.Length)
                    cp = 0;

                _hexBox.SetPosition(pos, cp);

                if (pos > _hexBox._endByte - 1)
                {
                    _hexBox.PerformScrollPageDown();
                }

                _hexBox.ReleaseSelection();
                _hexBox.UpdateCaret();
                _hexBox.Invalidate();

                return true;
            }

            protected virtual bool PreProcessWmKeyDown_ShiftLeft(ref Message m)
            {
                long pos = _hexBox._bytePos;
                long sel = _hexBox._selectionLength;

                if (pos + sel < 1)
                    return true;

                if (pos + sel <= _bpiStart.Index)
                {
                    if (pos == 0)
                        return true;

                    pos--;
                    sel++;
                }
                else
                {
                    sel = Math.Max(0, sel - 1);
                }

                _hexBox.ScrollByteIntoView();
                _hexBox.InternalSelect(pos, sel);

                return true;
            }

            protected virtual bool PreProcessWmKeyDown_ShiftUp(ref Message m)
            {
                long pos = _hexBox._bytePos;
                long sel = _hexBox._selectionLength;

                if (pos - _hexBox._iHexMaxHBytes < 0 && pos <= _bpiStart.Index)
                    return true;

                if (_bpiStart.Index >= pos + sel)
                {
                    pos -= _hexBox._iHexMaxHBytes;
                    sel += _hexBox._iHexMaxHBytes;
                    _hexBox.InternalSelect(pos, sel);
                    _hexBox.ScrollByteIntoView();
                }
                else
                {
                    sel -= _hexBox._iHexMaxHBytes;
                    if (sel < 0)
                    {
                        pos = _bpiStart.Index + sel;
                        sel = -sel;
                        _hexBox.InternalSelect(pos, sel);
                        _hexBox.ScrollByteIntoView();
                    }
                    else
                    {
                        sel -= _hexBox._iHexMaxHBytes;
                        _hexBox.InternalSelect(pos, sel);
                        _hexBox.ScrollByteIntoView(pos + sel);
                    }
                }

                return true;
            }

            protected virtual bool PreProcessWmKeyDown_ShiftRight(ref Message m)
            {
                long pos = _hexBox._bytePos;
                long sel = _hexBox._selectionLength;

                if (pos + sel >= _hexBox._byteProvider.Length)
                    return true;

                if (_bpiStart.Index <= pos)
                {
                    sel++;
                    _hexBox.InternalSelect(pos, sel);
                    _hexBox.ScrollByteIntoView(pos + sel);
                }
                else
                {
                    pos++;
                    sel = Math.Max(0, sel - 1);
                    _hexBox.InternalSelect(pos, sel);
                    _hexBox.ScrollByteIntoView();
                }

                return true;
            }

            protected virtual bool PreProcessWmKeyDown_ShiftDown(ref Message m)
            {
                long pos = _hexBox._bytePos;
                long sel = _hexBox._selectionLength;

                long max = _hexBox._byteProvider.Length;

                if (pos + sel + _hexBox._iHexMaxHBytes > max)
                    return true;

                if (_bpiStart.Index <= pos)
                {
                    sel += _hexBox._iHexMaxHBytes;
                    _hexBox.InternalSelect(pos, sel);
                    _hexBox.ScrollByteIntoView(pos + sel);
                }
                else
                {
                    sel -= _hexBox._iHexMaxHBytes;
                    if (sel < 0)
                    {
                        pos = _bpiStart.Index;
                        sel = -sel;
                    }
                    else
                    {
                        pos += _hexBox._iHexMaxHBytes;
                        //sel -= _hexBox._iHexMaxHBytes;
                    }

                    _hexBox.InternalSelect(pos, sel);
                    _hexBox.ScrollByteIntoView();
                }

                return true;
            }

            protected virtual bool PreProcessWmKeyDown_Tab(ref Message m)
            {
                if (_hexBox._stringViewVisible && _hexBox._keyInterpreter.GetType() == typeof(KeyInterpreter))
                {
                    _hexBox.ActivateStringKeyInterpreter();
                    _hexBox.ScrollByteIntoView();
                    _hexBox.ReleaseSelection();
                    _hexBox.UpdateCaret();
                    _hexBox.Invalidate();
                    return true;
                }

                if (_hexBox.Parent == null) return true;
                _hexBox.Parent.SelectNextControl(_hexBox, true, true, true, true);
                return true;
            }

            protected virtual bool PreProcessWmKeyDown_ShiftTab(ref Message m)
            {
                if (_hexBox._keyInterpreter is StringKeyInterpreter)
                {
                    _shiftDown = false;
                    _hexBox.ActivateKeyInterpreter();
                    _hexBox.ScrollByteIntoView();
                    _hexBox.ReleaseSelection();
                    _hexBox.UpdateCaret();
                    _hexBox.Invalidate();
                    return true;
                }

                if (_hexBox.Parent == null) return true;
                _hexBox.Parent.SelectNextControl(_hexBox, false, true, true, true);
                return true;
            }

            protected virtual bool PreProcessWmKeyDown_Back(ref Message m)
            {
                if (!_hexBox._byteProvider.SupportsDeleteBytes())
                    return true;

                if (_hexBox.ReadOnly)
                    return true;

                PerformPosMoveLeftByte();

                byte[] buffer = new byte[1];
                buffer[0] = _hexBox._byteProvider.ReadByte(_hexBox._bytePos);
                _hexBox.UndoStack.Push(_hexBox.SnapShotOperation(EditOperation.OverWrite, buffer));

                _hexBox._byteProvider.WriteByte(_hexBox._bytePos, 0);

                return true;
            }

            protected virtual bool PreProcessWmKeyDown_Delete(ref Message m)
            {
                if (!_hexBox._byteProvider.SupportsDeleteBytes())
                    return true;

                if (_hexBox.ReadOnly)
                    return true;

                long pos = _hexBox._bytePos;
                long sel = _hexBox._selectionLength;

                if (pos >= _hexBox._byteProvider.Length)
                    return true;

                if (sel == 0)
                {
                    return true;
                }

                byte[] buffer = new byte[sel];
                for (int i = 0; i < sel; i++)
                {
                    buffer[i] = _hexBox._byteProvider.ReadByte(pos + i);
                }
                _hexBox.UndoStack.Push(_hexBox.SnapShotOperation(EditOperation.Delete, buffer));

                _hexBox._byteProvider.DeleteBytes(pos, sel);

                _hexBox.UpdateVScrollSize();
                _hexBox.ReleaseSelection();
                _hexBox.Invalidate();

                return true;
            }

            protected virtual bool PreProcessWmKeyDown_Home(ref Message m)
            {
                long pos = _hexBox._bytePos;
                int cp;

                if (pos < 1)
                    return true;

                pos = 0;
                cp = 0;
                _hexBox.SetPosition(pos, cp);

                _hexBox.ScrollByteIntoView();
                _hexBox.UpdateCaret();
                _hexBox.ReleaseSelection();

                return true;
            }

            protected virtual bool PreProcessWmKeyDown_End(ref Message m)
            {
                long pos = _hexBox._bytePos;
                int cp;

                if (pos >= _hexBox._byteProvider.Length - 1)
                    return true;

                pos = _hexBox._byteProvider.Length;
                cp = 0;
                _hexBox.SetPosition(pos, cp);

                _hexBox.ScrollByteIntoView();
                _hexBox.UpdateCaret();
                _hexBox.ReleaseSelection();

                return true;
            }

            protected virtual bool PreProcessWmKeyDown_ShiftShiftKey(ref Message m)
            {
                if (_mouseDown)
                    return true;
                if (_shiftDown)
                    return true;

                _shiftDown = true;

                if (_hexBox._selectionLength > 0)
                    return true;

                _bpiStart = new BytePositionInfo(_hexBox._bytePos, _hexBox._byteCharacterPos);

                return true;
            }

            protected virtual bool PreProcessWmKeyDown_ControlC(ref Message m)
            {
                _hexBox.Copy();
                return true;
            }

            protected virtual bool PreProcessWmKeyDown_ControlX(ref Message m)
            {
                _hexBox.Cut();
                return true;
            }

            protected virtual bool PreProcessWmKeyDown_ControlV(ref Message m)
            {
                _hexBox.Paste();
                return true;
            }

            protected virtual bool PreProcessWmKeyDown_ControlZ(ref Message m)
            {
                _hexBox.Undo();
                return true;
            }

            protected virtual bool PreProcessWmKeyDown_ControlY(ref Message m)
            {
                _hexBox.Redo();
                return true;
            }

            #endregion

            #region PreProcessWmChar methods

            public virtual bool PreProcessWmChar(ref Message m)
            {
                if (Control.ModifierKeys == Keys.Control)
                {
                    return _hexBox.BasePreProcessMessage(ref m);
                }

                bool sw = _hexBox._byteProvider.SupportsWriteByte();
                bool si = _hexBox._byteProvider.SupportsInsertBytes();
                bool sd = _hexBox._byteProvider.SupportsDeleteBytes();

                long pos = _hexBox._bytePos;
                long sel = _hexBox._selectionLength;
                int cp = _hexBox._byteCharacterPos;

                if (
                    (!sw && pos != _hexBox._byteProvider.Length) ||
                    (!si && pos == _hexBox._byteProvider.Length))
                {
                    return _hexBox.BasePreProcessMessage(ref m);
                }

                char c = (char)m.WParam.ToInt32();

                if (Uri.IsHexDigit(c))
                {
                    if (RaiseKeyPress(c))
                        return true;

                    if (_hexBox.ReadOnly)
                        return true;

                    bool isInsertMode = (pos == _hexBox._byteProvider.Length);

                    // do insert when insertActive = true
                    if (!isInsertMode && si && _hexBox.InsertActive && cp == 0)
                        isInsertMode = true;

                    if (sd && si && sel > 0)
                    {
                        _hexBox._byteProvider.DeleteBytes(pos, sel);
                        isInsertMode = true;
                        cp = 0;
                        _hexBox.SetPosition(pos, cp);
                    }

                    _hexBox.ReleaseSelection();

                    byte currentByte;
                    if (isInsertMode)
                        currentByte = 0;
                    else
                        currentByte = _hexBox._byteProvider.ReadByte(pos);

                    string sCb = currentByte.ToString("X", System.Threading.Thread.CurrentThread.CurrentCulture);
                    if (sCb.Length == 1)
                        sCb = "0" + sCb;

                    string sNewCb = c.ToString();
                    if (cp == 0)
                        sNewCb += sCb.Substring(1, 1);
                    else
                        sNewCb = sCb.Substring(0, 1) + sNewCb;
                    byte newcb = byte.Parse(sNewCb, System.Globalization.NumberStyles.AllowHexSpecifier, System.Threading.Thread.CurrentThread.CurrentCulture);

                    if (isInsertMode)
                        _hexBox._byteProvider.InsertBytes(pos, new byte[] { newcb });
                    else
                        _hexBox._byteProvider.WriteByte(pos, newcb);

                    PerformPosMoveRight();

                    _hexBox.Invalidate();
                    return true;
                }
                else
                {
                    return _hexBox.BasePreProcessMessage(ref m);
                }
            }

            protected bool RaiseKeyPress(char keyChar)
            {
                KeyPressEventArgs e = new KeyPressEventArgs(keyChar);

                byte[] buffer = new byte[1];
                buffer[0] = _hexBox._byteProvider.ReadByte(_hexBox._bytePos);
                _hexBox.UndoStack.Push(_hexBox.SnapShotOperation(EditOperation.OverWrite, buffer));

                _hexBox.RedoStack.Clear();

                _hexBox.OnKeyPress(e);
                return e.Handled;
            }

            #endregion

            #region PreProcessWmKeyUp methods

            public virtual bool PreProcessWmKeyUp(ref Message m)
            {
                Debug.WriteLine("PreProcessWmKeyUp(ref Message m)", "KeyInterpreter");

                Keys vc = (Keys)m.WParam.ToInt32();

                Keys keyData = vc | Control.ModifierKeys;

                switch (keyData)
                {
                    case Keys.ShiftKey:
                    case Keys.Insert:
                        if (RaiseKeyUp(keyData))
                            return true;
                        break;
                }

                switch (keyData)
                {
                    case Keys.ShiftKey:
                        _shiftDown = false;
                        return true;

                    case Keys.Insert:
                        return PreProcessWmKeyUp_Insert(ref m);

                    default:
                        return _hexBox.BasePreProcessMessage(ref m);
                }
            }

            protected virtual bool PreProcessWmKeyUp_Insert(ref Message m)
            {
                _hexBox.InsertActive = !_hexBox.InsertActive;
                return true;
            }

            protected bool RaiseKeyUp(Keys keyData)
            {
                KeyEventArgs e = new KeyEventArgs(keyData);
                _hexBox.OnKeyUp(e);
                return e.Handled;
            }

            #endregion

            #region Misc

            private Dictionary<Keys, MessageDelegate> MessageHandlers
            {
                get
                {
                    if (_messageHandlers == null)
                    {
                        _messageHandlers = new Dictionary<Keys, MessageDelegate>
                        {
                            { Keys.Left, new MessageDelegate(PreProcessWmKeyDown_Left) }, // move left
                            { Keys.Up, new MessageDelegate(PreProcessWmKeyDown_Up) }, // move up
                            { Keys.Right, new MessageDelegate(PreProcessWmKeyDown_Right) }, // move right
                            { Keys.Down, new MessageDelegate(PreProcessWmKeyDown_Down) }, // move down
                            { Keys.PageUp, new MessageDelegate(PreProcessWmKeyDown_PageUp) }, // move pageup
                            { Keys.PageDown, new MessageDelegate(PreProcessWmKeyDown_PageDown) }, // move page down
                            { Keys.Left | Keys.Shift, new MessageDelegate(PreProcessWmKeyDown_ShiftLeft) }, // move left with selection
                            { Keys.Up | Keys.Shift, new MessageDelegate(PreProcessWmKeyDown_ShiftUp) }, // move up with selection
                            { Keys.Right | Keys.Shift, new MessageDelegate(PreProcessWmKeyDown_ShiftRight) }, // move right with selection
                            { Keys.Down | Keys.Shift, new MessageDelegate(PreProcessWmKeyDown_ShiftDown) }, // move down with selection
                            { Keys.Tab, new MessageDelegate(PreProcessWmKeyDown_Tab) }, // switch to string view
                            { Keys.Back, new MessageDelegate(PreProcessWmKeyDown_Back) }, // back
                            { Keys.Delete, new MessageDelegate(PreProcessWmKeyDown_Delete) }, // delete
                            { Keys.Home, new MessageDelegate(PreProcessWmKeyDown_Home) }, // move to home
                            { Keys.End, new MessageDelegate(PreProcessWmKeyDown_End) }, // move to end
                            { Keys.ShiftKey | Keys.Shift, new MessageDelegate(PreProcessWmKeyDown_ShiftShiftKey) }, // begin selection process
                            { Keys.C | Keys.Control, new MessageDelegate(PreProcessWmKeyDown_ControlC) }, // copy
                            { Keys.X | Keys.Control, new MessageDelegate(PreProcessWmKeyDown_ControlX) }, // cut
                            { Keys.V | Keys.Control, new MessageDelegate(PreProcessWmKeyDown_ControlV) }, // paste

                            { Keys.Z | Keys.Control, new MessageDelegate(PreProcessWmKeyDown_ControlZ) } ,// undo
                            { Keys.Y | Keys.Control, new MessageDelegate(PreProcessWmKeyDown_ControlY) } // redo
                        };
                    }
                    return _messageHandlers;
                }
            }

            protected virtual bool PerformPosMoveLeft()
            {
                long pos = _hexBox._bytePos;
                long sel = _hexBox._selectionLength;
                int cp = _hexBox._byteCharacterPos;

                if (sel != 0)
                {
                    cp = 0;
                    _hexBox.SetPosition(pos, cp);
                    _hexBox.ReleaseSelection();
                }
                else
                {
                    if (pos == 0 && cp == 0)
                        return true;

                    if (cp > 0)
                    {
                        cp--;
                    }
                    else
                    {
                        pos = Math.Max(0, pos - 1);
                        cp++;
                    }

                    _hexBox.SetPosition(pos, cp);

                    if (pos < _hexBox._startByte)
                    {
                        _hexBox.PerformScrollLineUp();
                    }
                    _hexBox.UpdateCaret();
                    _hexBox.Invalidate();
                }

                _hexBox.ScrollByteIntoView();
                return true;
            }

            protected virtual bool PerformPosMoveRight()
            {
                long pos = _hexBox._bytePos;
                int cp = _hexBox._byteCharacterPos;
                long sel = _hexBox._selectionLength;

                if (sel != 0)
                {
                    pos += sel;
                    cp = 0;
                    _hexBox.SetPosition(pos, cp);
                    _hexBox.ReleaseSelection();
                }
                else
                {
                    if (!(pos == _hexBox._byteProvider.Length && cp == 0))
                    {
                        if (cp > 0)
                        {
                            pos = Math.Min(_hexBox._byteProvider.Length, pos + 1);
                            cp = 0;
                        }
                        else
                        {
                            cp++;
                        }

                        _hexBox.SetPosition(pos, cp);

                        if (pos > _hexBox._endByte - 1)
                        {
                            _hexBox.PerformScrollLineDown();
                        }
                        _hexBox.UpdateCaret();
                        _hexBox.Invalidate();
                    }
                }

                _hexBox.ScrollByteIntoView();
                return true;
            }

            protected virtual bool PerformPosMoveLeftByte()
            {
                long pos = _hexBox._bytePos;
                int cp;

                if (pos == 0)
                    return true;

                pos = Math.Max(0, pos - 1);
                cp = 0;

                _hexBox.SetPosition(pos, cp);

                if (pos < _hexBox._startByte)
                {
                    _hexBox.PerformScrollLineUp();
                }
                _hexBox.UpdateCaret();
                _hexBox.ScrollByteIntoView();
                _hexBox.Invalidate();

                return true;
            }

            protected virtual bool PerformPosMoveRightByte()
            {
                long pos = _hexBox._bytePos;

                if (pos == _hexBox._byteProvider.Length)
                    return true;

                pos = Math.Min(_hexBox._byteProvider.Length, pos + 1);
                int cp = 0;

                _hexBox.SetPosition(pos, cp);

                if (pos > _hexBox._endByte - 1)
                {
                    _hexBox.PerformScrollLineDown();
                }
                _hexBox.UpdateCaret();
                _hexBox.ScrollByteIntoView();
                _hexBox.Invalidate();

                return true;
            }

            public virtual PointF GetCaretPointF(long byteIndex)
            {
                Debug.WriteLine("GetCaretPointF()", "KeyInterpreter");

                return _hexBox.GetBytePointF(byteIndex);
            }

            protected virtual BytePositionInfo GetBytePositionInfo(Point p)
            {
                return _hexBox.GetHexBytePositionInfo(p);
            }

            #endregion
        }
    }
}