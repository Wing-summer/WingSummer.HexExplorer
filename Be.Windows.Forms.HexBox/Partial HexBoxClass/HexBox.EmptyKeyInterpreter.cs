using System.Drawing;
using System.Windows.Forms;

namespace Be.Windows.Forms
{
    public partial class HexBox
    {
        /// <summary>
        /// Represents an empty input handler without any functionality.
        /// If is set ByteProvider to null, then this interpreter is used.
        /// </summary>
        private class EmptyKeyInterpreter : IKeyInterpreter
        {
            private readonly HexBox _hexBox;

            public EmptyKeyInterpreter(HexBox hexBox)
            {
                _hexBox = hexBox;
            }

            #region IKeyInterpreter Members

            public void Activate()
            {
            }

            public void Deactivate()
            {
            }

            public bool PreProcessWmKeyUp(ref Message m)
            { return _hexBox.BasePreProcessMessage(ref m); }

            public bool PreProcessWmChar(ref Message m)
            { return _hexBox.BasePreProcessMessage(ref m); }

            public bool PreProcessWmKeyDown(ref Message m)
            { return _hexBox.BasePreProcessMessage(ref m); }

            public PointF GetCaretPointF(long byteIndex)
            { return new PointF(); }

            #endregion
        }
    }
}