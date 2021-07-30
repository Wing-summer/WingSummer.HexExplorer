using System;
using System.Diagnostics;
using System.Drawing;

namespace Be.Windows.Forms
{
    public partial class HexBox
    {
        #region Caret methods

        private void CreateCaret()
        {
            if (_byteProvider == null || _keyInterpreter == null || _caretVisible || !Focused)
                return;

            Debug.WriteLine("CreateCaret()", "HexBox");

            // define the caret width depending on InsertActive mode
            int caretWidth = (InsertActive) ? 1 : (int)_charSize.Width;
            int caretHeight = (int)_charSize.Height;
            Caret.Create(Handle, IntPtr.Zero, caretWidth, caretHeight);

            UpdateCaret();

            Caret.Show(Handle);

            _caretVisible = true;
        }

        private void UpdateCaret()
        {
            if (_byteProvider == null || _keyInterpreter == null)
                return;

            Debug.WriteLine("UpdateCaret()", "HexBox");

            long byteIndex = _bytePos - _startByte;
            PointF p = _keyInterpreter.GetCaretPointF(byteIndex);
            p.X += _byteCharacterPos * _charSize.Width;
            Caret.SetPos((int)p.X, (int)p.Y);
        }

        private void DestroyCaret()
        {
            if (!_caretVisible)
                return;

            Debug.WriteLine("DestroyCaret()", "HexBox");

            Caret.Destroy();
            _caretVisible = false;
        }

        private void SetCaretPosition(Point p)
        {
            Debug.WriteLine("SetCaretPosition()", "HexBox");

            if (_byteProvider == null || _keyInterpreter == null)
                return;
            int cp;

            long pos;

            Rectangle _recHex = this._recHex;
            _recHex.X += (int)GetHOffValue();

            if (_recHex.Contains(p))
            {
                BytePositionInfo bpi = GetHexBytePositionInfo(p);
                pos = bpi.Index;
                cp = bpi.CharacterPosition;

                SetPosition(pos, cp);

                ActivateKeyInterpreter();
                UpdateCaret();
                Invalidate();
            }
            else if (_recStringView.Contains(p))
            {
                BytePositionInfo bpi = GetStringBytePositionInfo(p);
                pos = bpi.Index;
                cp = bpi.CharacterPosition;

                SetPosition(pos, cp);

                ActivateStringKeyInterpreter();
                UpdateCaret();
                Invalidate();
            }
        }

        private BytePositionInfo GetHexBytePositionInfo(Point p)
        {
            Debug.WriteLine("GetHexBytePositionInfo()", "HexBox");

            long bytePos;
            int byteCharaterPos;

            Rectangle _recHex = this._recHex;
            _recHex.X += (int)GetHOffValue();

            float x = (p.X - _recHex.X) / _charSize.Width;
            float y = (p.Y - _recHex.Y) / _charSize.Height;
            int iX = (int)x;
            int iY = (int)y;

            int hPos = (iX / 3 + 1);

            bytePos = Math.Min(_byteProvider.Length,
                _startByte + (_iHexMaxHBytes * (iY + 1) - _iHexMaxHBytes) + hPos - 1);
            byteCharaterPos = (iX % 3);
            if (byteCharaterPos > 1)
                byteCharaterPos = 1;

            if (bytePos == _byteProvider.Length)
                byteCharaterPos = 0;

            if (bytePos < 0)
                return new BytePositionInfo(0, 0);
            return new BytePositionInfo(bytePos, byteCharaterPos);
        }

        private BytePositionInfo GetStringBytePositionInfo(Point p)
        {
            Debug.WriteLine("GetStringBytePositionInfo()", "HexBox");

            long bytePos;
            int byteCharacterPos;

            float x = ((float)(p.X - _recStringView.X) / _charSize.Width);
            float y = ((float)(p.Y - _recStringView.Y) / _charSize.Height);
            int iX = (int)x;
            int iY = (int)y;

            int hPos = iX + 1;

            bytePos = Math.Min(_byteProvider.Length,
                _startByte + (_iHexMaxHBytes * (iY + 1) - _iHexMaxHBytes) + hPos - 1);
            byteCharacterPos = 0;

            if (bytePos < 0)
                return new BytePositionInfo(0, 0);
            return new BytePositionInfo(bytePos, byteCharacterPos);
        }

        #endregion
    }
}