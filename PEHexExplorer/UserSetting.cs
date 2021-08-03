using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using WSPEHexPluginHost;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEHexExplorer
{
    class UserSetting
    {
        public class BookMarkProperty
        {
            public Keys KeyDown { get; set; }

            public MouseButtons MouseButton { get; set; }

            public Color Color { get; set; }

        }

        public static List<IWSPEHexPluginVer> pluginVers = new List<IWSPEHexPluginVer>();
        public static List<BookMarkProperty> markProperties = new List<BookMarkProperty>();

    }
}
