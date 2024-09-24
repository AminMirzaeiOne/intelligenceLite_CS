using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace intelligenceLite
{
    [System.ComponentModel.ToolboxItem(false)]
    public class IntelligenceMenuHost : ToolStripDropDown
    {
        private IIntelligenceListView listView;
        public ToolStripControlHost Host { get; set; }
        public readonly IntelligenceMenu Menu;


    }
}
