using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace intelligenceLite
{
    internal interface IIntelligenceListView
    {
        /// <summary>
        /// Image list
        /// </summary>
        ImageList ImageList { get; set; }
    }
}
