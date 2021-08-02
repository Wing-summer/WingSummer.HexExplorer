using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Be.Windows.Forms
{
    public partial class HexBox
    {
        /// <summary>
        /// Handles user input such as mouse and keyboard input during string view edit
        /// </summary>
        private class StringKeyInterpreter : KeyInterpreter
        {
            #region Ctors

            public StringKeyInterpreter(HexBox hexBox)
                : base(hexBox)
            {
                _hexBox._byteCharacterPos = 0;
            }

            #endregion

            #region PreProcessWmKeyDown methods

            public override bool PreProcessWmKeyDown(ref Message m)
            {
                Keys vc = (Keys)m.WParam.ToInt32();

                Keys keyData = vc | Control.ModifierKeys;

                switch (keyData)
                {
                    case Keys.Tab | Keys.Shift:
                    case Keys.Tab:
                        if (RaiseKeyDown(keyData))
                            return true;
                        break;
                }

                switch (keyData)
                {
                    case Keys.Tab | Keys.Shift:
                        return PreProcessWmKeyDown_ShiftTab(ref m);

                    case Keys.Tab:
                        return PreProcessWmKeyDown_Tab(ref m);

                    default:
                        return base.PreProcessWmKeyDown(ref m);
                }
            }

            protected override bool PreProcessWmKeyDown_Left(ref Message m)
            {
                return PerformPosMoveLeftByte();
            }

            protected override bool PreProcessWmKeyDown_Right(ref Message m)
            {
                return PerformPosMoveRightByte();
            }

            #endregion

            #region PreProcessWmChar methods

            public override bool PreProcessWmChar(ref Message m)
            {
                if (ModifierKeys == Keys.Control)
                {
                    return _hexBox.BasePreProcessMessage(ref m);
                }

                bool sw = _hexBox._byteProvider.SupportsWriteByte();
                bool si = _hexBox._byteProvider.SupportsInsertBytes();
                bool sd = _hexBox._byteProvider.SupportsDeleteBytes();

                long pos = _hexBox._bytePos;
                long sel = _hexBox._selectionLength;
                int cp;

                if (
                    (!sw && pos != _hexBox._byteProvider.Length) ||
                    (!si && pos == _hexBox._byteProvider.Length))
                {
                    return _hexBox.BasePreProcessMessage(ref m);
                }

                char c = (char)m.WParam.ToInt32();

                if (RaiseKeyPress(c))
                    return true;

                if (_hexBox._readOnly)
                    return true;

                bool isInsertMode = pos == _hexBox._byteProvider.Length;
                if (_hexBox._isLockedBuffer&&isInsertMode)
                {
                    return true;
                }

                // do insert when insertActive = true
                if (!isInsertMode && si && _hexBox.InsertActive)
                    isInsertMode = true;

                if (sd && si && sel > 0)
                {
                    _hexBox._byteProvider.DeleteBytes(pos, sel);
                    isInsertMode = true;
                    cp = 0;
                    _hexBox.SetPosition(pos, cp);
                }

                _hexBox.ReleaseSelection();

                byte b = _hexBox.ByteCharConverter.ToByte(c);
                if (isInsertMode)
                    _hexBox._byteProvider.InsertBytes(pos, new byte[] { b });
                else
                    _hexBox._byteProvider.WriteByte(pos, b);

                PerformPosMoveRightByte();
                _hexBox.Invalidate();

                return true;
            }

            #endregion

            #region Misc

            public override PointF GetCaretPointF(long byteIndex)
            {
                Debug.WriteLine("GetCaretPointF()", "StringKeyInterpreter");

                Point gp = _hexBox.GetGridBytePoint(byteIndex);
                return _hexBox.GetByteStringPointF(gp);
            }

            protected override BytePositionInfo GetBytePositionInfo(Point p)
            {
                return _hexBox.GetStringBytePositionInfo(p);
            }

            #endregion
        }
    }
}