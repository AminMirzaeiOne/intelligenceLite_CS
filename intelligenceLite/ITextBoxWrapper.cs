using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace intelligenceLite
{
    public interface ITextBoxWrapper
    {
        Control TargetControl { get; }

        string Text { get; }
        string SelectedText { get; set; }
        int SelectionLength { get; set; }
        int SelectionStart { get; set; }

        Point GetPositionFromCharIndex(int pos);

    }
}
