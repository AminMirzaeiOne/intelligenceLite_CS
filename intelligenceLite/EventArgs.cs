using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intelligenceLite
{
    public class EventArgs
    {
        public class SelectingEventArgs : EventArgs
        {
            public IntelligenceItem Item { get; internal set; }
            public bool Cancel { get; set; }
            public int SelectedIndex { get; set; }
            public bool Handled { get; set; }
        }

        public class SelectedEventArgs : EventArgs
        {
            public IntelligenceItem Item { get; internal set; }
            public Control Control { get; set; }
        }

        public class HoveredEventArgs : EventArgs
        {
            public IntelligenceItem Item { get; internal set; }
        }

        public class PaintItemEventArgs : PaintEventArgs
        {
            public RectangleF TextRect { get; internal set; }
            public StringFormat StringFormat { get; internal set; }
            public Font Font { get; internal set; }
            public bool IsSelected { get; internal set; }
            public bool IsHovered { get; internal set; }



        }

    }
}
