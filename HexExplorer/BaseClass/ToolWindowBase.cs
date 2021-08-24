using System.Windows.Forms;

namespace HexExplorer
{
    public class ToolWindowBase : FormBase
    {
        public ToolWindowBase()
        {
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ShowIcon = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }
    }
}
