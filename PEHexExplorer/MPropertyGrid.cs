using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace PEHexExplorer
{
    class MPropertyGrid : PropertyGrid
    {
        public MPropertyGrid()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            DoubleBuffered = true;
        }

    }
}
