using System;
using System.Windows.Forms;

namespace PEHexExplorer
{
    public class FormBase : Form
    {
        public FormBase()
        {
            DoubleBuffered = true;
            StartPosition = FormStartPosition.CenterScreen;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // Turn on WS_EX_COMPOSITED    

                OperatingSystem os = Environment.OSVersion;
                Version vs = os.Version;
                if (os.Platform == PlatformID.Win32NT)
                {
                    if ((vs.Major == 5) && (vs.Minor != 0))
                    {
                        cp.ExStyle |= 0x00080000;  // Turn on WS_EX_LAYERED  
                        Opacity = 1;
                    }
                }

                return cp;
            }
        }

    }

}
