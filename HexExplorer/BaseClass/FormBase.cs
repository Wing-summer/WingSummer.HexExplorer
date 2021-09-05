using System.ComponentModel;
using System.Windows.Forms;

namespace HexExplorer
{

    public class FormBase : Form
    {
        public FormBase()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
            DoubleBuffered = true;
            StartPosition = FormStartPosition.CenterScreen;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                DataBindings.Add(new Binding("Font", UserSetting.UserProfile, "ProgramFont", true, DataSourceUpdateMode.OnPropertyChanged));
            }

        }

    }

}
