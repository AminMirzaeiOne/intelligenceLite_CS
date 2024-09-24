using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

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
            public System.Windows.Forms.Control Control { get; set; }
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

            public PaintItemEventArgs(Graphics graphics, Rectangle clipRect) : base(graphics, clipRect)
            {
            }

        }

        public class WrapperNeededEventArgs : EventArgs
        {
            public System.Windows.Forms.Control TargetControl { get; private set; }
            public ITextBoxWrapper Wrapper { get; set; }

            public WrapperNeededEventArgs(System.Windows.Forms.Control targetControl)
            {
                this.TargetControl = targetControl;
            }
        }

    }
}
