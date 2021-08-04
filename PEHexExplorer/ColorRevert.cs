using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEHexExplorer
{
    static class ColorRevert
    {
        public static Color GetRevertColor(Color color)=> Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
    }
}
