using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Be.Windows.Forms
{
    public partial class HexBox
    {
        /// <summary>
        /// Converts a byte array to a hex string. For example: {10,11} = "0A 0B"
        /// </summary>
        /// <param name="data">the byte array</param>
        /// <returns>the hex string</returns>
        private string ConvertBytesToHex(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in data)
            {
                string hex = ConvertByteToHex(b);
                sb.Append(hex);
                sb.Append(" ");
            }
            if (sb.Length > 0)
                sb.Remove(sb.Length - 1, 1);
            string result = sb.ToString();
            return result;
        }

        /// <summary>
        /// Converts the byte to a hex string. For example: "10" = "0A";
        /// </summary>
        /// <param name="b">the byte to format</param>
        /// <returns>the hex string</returns>
        private string ConvertByteToHex(byte b)
        {
            string sB = b.ToString(_hexStringFormat, System.Threading.Thread.CurrentThread.CurrentCulture);
            if (sB.Length == 1)
                sB = "0" + sB;
            return sB;
        }

        /// <summary>
        /// Converts the hex string to an byte array. The hex string must be separated by a space char ' '. If there is any invalid hex information in the string the result will be null.
        /// </summary>
        /// <param name="hex">the hex string separated by ' '. For example: "0A 0B 0C"</param>
        /// <returns>the byte array. null if hex is invalid or empty</returns>
        private byte[] ConvertHexToBytes(string hex)
        {
            if (string.IsNullOrEmpty(hex))
                return null;
            hex = hex.Trim();
            var hexArray = hex.Split(' ');
            var byteArray = new byte[hexArray.Length];

            for (int i = 0; i < hexArray.Length; i++)
            {
                var hexValue = hexArray[i];

                var isByte = ConvertHexToByte(hexValue, out byte b);
                if (!isByte)
                    return null;
                byteArray[i] = b;
            }

            return byteArray;
        }

        private bool ConvertHexToByte(string hex, out byte b)
        {
            bool isByte = byte.TryParse(hex, System.Globalization.NumberStyles.HexNumber, System.Threading.Thread.CurrentThread.CurrentCulture, out b);
            return isByte;
        }

        private void SetPosition(long bytePos)
        {
            SetPosition(bytePos, _byteCharacterPos);
        }

        private void SetPosition(long bytePos, int byteCharacterPos)
        {
            if (_byteCharacterPos != byteCharacterPos)
            {
                _byteCharacterPos = byteCharacterPos;
            }

            if (bytePos != _bytePos)
            {
                _bytePos = bytePos;
                CheckCurrentLineChanged();
                CheckCurrentPositionInLineChanged();

                SelectionStartChanged?.Invoke(this, null);
            }
        }

        private void SetSelectionLength(long selectionLength)
        {
            if (selectionLength != _selectionLength)
            {
                _selectionLength = selectionLength;
                SelectionLengthChanged?.Invoke(this, null);
            }
        }

        private void SetHorizontalByteCount(int value)
        {
            if (_iHexMaxHBytes == value)
                return;

            _iHexMaxHBytes = value;
            HorizontalByteCountChanged?.Invoke(this, null);
        }

        private void SetVerticalByteCount(int value)
        {
            if (_iHexMaxVBytes == value)
                return;

            _iHexMaxVBytes = value;
            VerticalByteCountChanged?.Invoke(this, null);
        }

        private void CheckCurrentLineChanged()
        {
            long currentLine = (long)Math.Floor(_bytePos / (double)_iHexMaxHBytes) + 1;

            if (_byteProvider == null && _currentLine != 0)
                _currentLine = 0;
            else if (currentLine != _currentLine)
                _currentLine = currentLine;
            CurrentLineChanged?.Invoke(this, null);
            CurrentPositionChanged?.Invoke(this, null);
        }

        private void CheckCurrentPositionInLineChanged()
        {
            Point gb = GetGridBytePoint(_bytePos);
            int currentPositionInLine = gb.X + 1;

            if (_byteProvider == null && _currentPositionInLine != 0)
                _currentPositionInLine = 0;
            else if (currentPositionInLine != _currentPositionInLine)
                _currentPositionInLine = currentPositionInLine;

            CurrentPositionInLineChanged?.Invoke(this, null);
            CurrentPositionChanged?.Invoke(this, null);

        }

        /// <summary>
        /// Raises the MouseDown event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            Debug.WriteLine("OnMouseDown()", "HexBox");

            if (!Focused)
                Focus();

            if (e.Button == MouseButtons.Left)
                SetCaretPosition(new Point(e.X, e.Y));

            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the MouseWhell event
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int linesToScroll = -(e.Delta * SystemInformation.MouseWheelScrollLines / 120);
            if (NativeMethods.GetAsyncKeyState(NativeMethods.VK_CONTROL) != 0)
            {
                Scaling -= linesToScroll / 100.0F;
            }
            else
            {
                PerformScrollLines(linesToScroll);
            }
            base.OnMouseWheel(e);
        }

        /// <summary>
        /// Raises the Resize event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRectanglePositioning();
        }

        /// <summary>
        /// Raises the GotFocus event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            Debug.WriteLine("OnGotFocus()", "HexBox");

            base.OnGotFocus(e);

            CreateCaret();
        }

        /// <summary>
        /// Raises the LostFocus event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            Debug.WriteLine("OnLostFocus()", "HexBox");

            base.OnLostFocus(e);

            DestroyCaret();
        }

        private void ByteProvider_LengthChanged(object sender, EventArgs e)
        {
            UpdateVScrollSize();
        }
    }
}