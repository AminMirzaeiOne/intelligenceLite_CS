using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;

namespace intelligenceLite
{
    [System.ComponentModel.ToolboxItem(false)]
    public class IntelligenceListView : UserControl, IIntelligenceListView
    {
        private readonly System.Windows.Controls.ToolTip toolTip = new System.Windows.Controls.ToolTip();
        public int HighlightedItemIndex { get; set; }
        private int oldItemCount;
        private int selectedItemIndex = -1;
        private IList<IntelligenceItem> visibleItems;


    }
}
