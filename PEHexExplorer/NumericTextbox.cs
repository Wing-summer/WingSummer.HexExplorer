using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace PEHexExplorer
{
    public partial class NumericTextbox : TextBox
    {
        private const int WM_CHAR = 0x0102;

        public NumericTextbox()
        {
            InitializeComponent();
        }

        public NumericTextbox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            CharacterCasing = CharacterCasing.Upper;
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text { get => base.Text; }

        public int Number
        {
            get
            {
                return ishex ? int.Parse(base.Text, NumberStyles.HexNumber) : int.Parse(base.Text);
            }

            set
            {
                base.Text = value.ToString();
            }
        }

        [DefaultValue(false)]
        public bool IsHex
        {
            get
            {
                return ishex;
            }
            set
            {
                if (base.Text.Length > 0)
                {
                    Text = value ? int.Parse(base.Text).ToString("X") : int.Parse(base.Text, NumberStyles.HexNumber).ToString();
                }
                ishex = value;
            }
        }

        private bool ishex = false;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Multiline { get => false; }

        public override bool PreProcessMessage(ref Message msg)
        {
            if (msg.Msg == WM_CHAR)
            {
                int vk = msg.WParam.ToInt32();
                if (IsHex)
                {
                    if ((vk >= '0' && vk <= '9') || (vk == '\b') || (vk >= 'A' && vk <= 'F') || (vk >= 'a' && vk <= 'f'))
                    {
                        return base.PreProcessMessage(ref msg);
                    }
                }
                else
                {
                    if ((vk >= '0' && vk <= '9') || (vk == '\b'))
                    {
                        return base.PreProcessMessage(ref msg);
                    }
                }
                return true;
            }
            return base.PreProcessMessage(ref msg);
        }
    }
}