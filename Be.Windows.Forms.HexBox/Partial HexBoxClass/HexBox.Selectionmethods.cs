using System.Diagnostics;

namespace Be.Windows.Forms
{
    public partial class HexBox
    {
        private void ReleaseSelection()
        {
            Debug.WriteLine("ReleaseSelection()", "HexBox");

            if (_selectionLength == 0)
                return;
            _selectionLength = 0;
            SelectionLengthChanged?.Invoke(this, null);

            if (!_caretVisible)
                CreateCaret();
            else
                UpdateCaret();

            Invalidate();
        }

        /// <summary>
        /// Returns true if Select method could be invoked.
        /// </summary>
        public bool CanSelectAll()
        {
            if (!Enabled)
                return false;
            if (_byteProvider == null)
                return false;

            return true;
        }

        /// <summary>
        /// Selects all bytes.
        /// </summary>
        public void SelectAll()
        {
            if (ByteProvider == null)
                return;
            Select(0, ByteProvider.Length);
        }

        /// <summary>
        /// Selects the hex box.
        /// </summary>
        /// <param name="start">the start index of the selection</param>
        /// <param name="length">the length of the selection</param>
        public void Select(long start, long length)
        {
            if (ByteProvider == null)
                return;
            if (!Enabled)
                return;

            InternalSelect(start, length);
            ScrollByteIntoView();
        }

        private void InternalSelect(long start, long length)
        {
            long pos = start;
            long sel = length;
            int cp = 0;

            if (sel > 0 && _caretVisible)
                DestroyCaret();
            else if (sel == 0 && !_caretVisible)
                CreateCaret();

            SetPosition(pos, cp);
            SetSelectionLength(sel);

            UpdateCaret();
            Invalidate();
        }
    }
}