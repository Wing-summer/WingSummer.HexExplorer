using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSPEHexPluginHost
{
    public interface IWSPEHexPlugin
    {
        //GM意为give me，即为给宿主识别的信息

        string GMPluginName();

        ToolStripItem GMMenuPluginMenu();

        ToolStripItem GMMenuToolMenu();

        Dictionary<object,EventArgs> MenuEvent { get; set; }



    }
}
