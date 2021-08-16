﻿using System.ComponentModel;
using System.Windows.Forms;

namespace PEHexExplorer
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
                Font = UserSetting.UserProfile.ProgramFont;
            }

        }

    }

}
