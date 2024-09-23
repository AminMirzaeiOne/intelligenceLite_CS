using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.ComponentModel;
using System.Drawing;
using static intelligenceLite.EventArgs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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

        [Category("Border Options")]
        public System.Boolean Border { get; set; } = true;

        [Category("Border Options")]
        public System.Drawing.Color BorderColor { get; set; } = Color.Red;

        [Category("Border Options")]
        public System.Byte BorderSize { get; set; } = 2;


        [Category("Color Options")]
        public Color ForeColor { get; set; } = Color.Black;

        [Category("Color Options")]
        public Color BackColor { get; set; } = Color.White;

        [Category("Color Options")]
        public Color SelectedForeColor { get; set; } = Color.White;

        [Category("Color Options")]
        public Color SelectedBackColor { get; set; } = Color.Orange;

        [Category("Color Options")]
        public Color SelectedBackColor2 { get; set; } = Color.Tomato;

        [Category("Color Options")]
        public Color HighlightingColor { get; set; } = Color.White;

        /// <summary>
        /// Duration (ms) of tooltip showing
        /// </summary>
        public int ToolTipDuration { get; set; }

        /// <summary>
        /// Occurs when user selected item for inserting into text
        /// </summary>
        public event EventHandler ItemSelected;

        /// <summary>
        /// Occurs when current hovered item is changing
        /// </summary>
        public event EventHandler<HoveredEventArgs> ItemHovered;

        /// <summary>
        /// Colors
        /// </summary>
        /// 

        internal IntelligenceListView()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            base.Font = new Font(FontFamily.GenericSansSerif, 9);
            ItemHeight = Font.Height + 2;
            VerticalScroll.SmallChange = ItemHeight;
            BackColor = Color.White;
            LeftPadding = 18;
            ToolTipDuration = 3000;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.BorderStyle = BorderStyle.None;
        }
    }
}
