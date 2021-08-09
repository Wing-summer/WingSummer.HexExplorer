using System.Windows.Forms;

namespace PEHexExplorer
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
