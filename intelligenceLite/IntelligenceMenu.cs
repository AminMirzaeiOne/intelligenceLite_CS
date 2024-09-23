using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static intelligenceLite.EventArgs;

namespace intelligenceLite
{
    [ProvideProperty("IntelligenceMenu", typeof(Control))]
    public partial class IntelligenceMenu : Component, IExtenderProvider
    {
        private static readonly Dictionary<Control, IntelligenceMenu> IntelligenceMenuByControls =
            new Dictionary<Control, IntelligenceMenu>();
        private static readonly Dictionary<Control, ITextBoxWrapper> WrapperByControls =
            new Dictionary<Control, ITextBoxWrapper>();

        private ITextBoxWrapper targetControlWrapper;
        private readonly Timer timer = new Timer();

        private IEnumerable<IntelligenceItem> sourceItems = new List<IntelligenceItem>();
        [Browsable(false)]
        public IList<IntelligenceItem> VisibleItems { get { return Host.ListView.VisibleItems; } private set { Host.ListView.VisibleItems = value; } }
        private Size maximumSize;

        private System.Drawing.Color themeColor = Color.Black;
        private System.Boolean enableThemeColor = false;

        private System.Drawing.Color foreColor = Color.Black;
        private System.Drawing.Color backColor = Color.White;
        private System.Drawing.Color selectedForeColor = Color.White;
        private System.Drawing.Color selectedBackColor = Color.Orange;
        private System.Drawing.Color selectedBackColor2 = Color.Tomato;
        private System.Drawing.Color highlightingColor = Color.White;

        [Category("Border Options")]
        public System.Boolean Border
        {
            get { return this.ListView.Border; }
            set { this.ListView.Border = value; }
        }

        [Category("Border Options")]
        public System.Drawing.Color BorderColor
        {
            get { return this.ListView.BorderColor; }
            set { this.ListView.BorderColor = value; }
        }

        [Category("Border Options")]
        public System.Byte BorderSize
        {
            get { return this.ListView.BorderSize; }
            set { this.ListView.BorderSize = value; }
        }

        [Category("Appearance")]
        public Color ForeColor
        {
            get { return this.foreColor; }
            set
            {
                this.foreColor = value;
                this.ListView.ForeColor = value;
            }
        }

        [Category("Appearance")]
        public Color BackColor
        {
            get { return this.backColor; }
            set
            {
                this.backColor = value;
                this.ListView.BackColor = value;
            }
        }

        [Category("Appearance")]
        public Color SelectedForeColor
        {
            get { return this.selectedForeColor; }
            set
            {
                this.selectedForeColor = value;
                this.ListView.SelectedForeColor = value;
            }
        }

        [Category("Appearance")]
        public Color SelectedBackColor
        {
            get { return this.selectedBackColor; }
            set
            {
                this.selectedBackColor = value;
                this.ListView.SelectedBackColor = value;
            }
        }

        [Category("Appearance")]
        public Color SelectedBackColor2
        {
            get { return this.selectedBackColor2; }
            set
            {
                this.selectedBackColor2 = value;
                this.ListView.SelectedBackColor2 = value;
            }
        }

        [Category("Appearance")]
        public Color HighlightingColor
        {
            get { return this.highlightingColor; }
            set
            {
                this.highlightingColor = value;
                this.ListView.HighlightingColor = value;
            }
        }

        /// <summary>
        /// Duration (ms) of tooltip showing
        /// </summary>
        [Description("Duration (ms) of tooltip showing")]
        [DefaultValue(3000)]
        public int ToolTipDuration
        {
            get { return Host.ListView.ToolTipDuration; }
            set { Host.ListView.ToolTipDuration = value; }
        }

        public IntelligenceMenu()
        {
            Host = new IntelligenceMenuHost(this);
            Host.ListView.ItemSelected += new EventHandler(ListView_ItemSelected);
            Host.ListView.ItemHovered += new EventHandler<HoveredEventArgs>(ListView_ItemHovered);
            VisibleItems = new List<IntelligenceItem>();
            Enabled = true;
            AppearInterval = 500;
            timer.Tick += timer_Tick;
            MaximumSize = new Size(180, 200);
            AutoPopup = true;
            SearchPattern = @"[\w\.]";
            MinFragmentLength = 2;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                timer.Dispose();
                Host.Dispose();
            }
            base.Dispose(disposing);
        }

        void ListView_ItemSelected(object sender, System.EventArgs e)
        {
            OnSelecting();
        }

        void ListView_ItemHovered(object sender, HoveredEventArgs e)
        {
            OnHovered(e);
        }

        public void OnHovered(HoveredEventArgs e)
        {
            if (Hovered != null)
                Hovered(this, e);
        }

        [Browsable(false)]
        public int SelectedItemIndex
        {
            get { return Host.ListView.SelectedItemIndex; }
            internal set { Host.ListView.SelectedItemIndex = value; }
        }

        internal IntelligenceMenuHost Host { get; set; }

        /// <summary>
        /// Called when user selected the control and needed wrapper over it.
        /// You can assign own Wrapper for target control.
        /// </summary>
        [Description("Called when user selected the control and needed wrapper over it. You can assign own Wrapper for target control.")]
        public event EventHandler<WrapperNeededEventArgs> WrapperNeeded;


        protected void OnWrapperNeeded(WrapperNeededEventArgs args)
        {
            if (WrapperNeeded != null)
                WrapperNeeded(this, args);
            if (args.Wrapper == null)
                args.Wrapper = TextBoxWrapper.Create(args.TargetControl);
        }

        ITextBoxWrapper CreateWrapper(Control control)
        {
            if (WrapperByControls.ContainsKey(control))
                return WrapperByControls[control];

            var args = new WrapperNeededEventArgs(control);
            OnWrapperNeeded(args);
            if (args.Wrapper != null)
                WrapperByControls[control] = args.Wrapper;

            return args.Wrapper;
        }

        /// <summary>
        /// Current target control wrapper
        /// </summary>
        [Browsable(false)]
        public ITextBoxWrapper TargetControlWrapper
        {
            get { return targetControlWrapper; }
            set
            {
                targetControlWrapper = value;
                if (value != null && !WrapperByControls.ContainsKey(value.TargetControl))
                {
                    WrapperByControls[value.TargetControl] = value;
                    SetIntelligenceMenu(value.TargetControl, this);
                }
            }
        }

        /// <summary>
        /// Maximum size of popup menu
        /// </summary>
        [DefaultValue(typeof(Size), "180, 200")]
        [Description("Maximum size of popup menu")]
        public Size MaximumSize
        {
            get { return maximumSize; }
            set
            {
                maximumSize = value;
                (Host.ListView as Control).MaximumSize = maximumSize;
                (Host.ListView as Control).Size = maximumSize;
                Host.CalcSize();
            }
        }

        /// <summary>
        /// Font
        /// </summary>
        public Font Font
        {
            get { return (Host.ListView as Control).Font; }
            set { (Host.ListView as Control).Font = value; }
        }

        /// <summary>
        /// Left padding of text
        /// </summary>
        [DefaultValue(18)]
        [Description("Left padding of text")]
        public int LeftPadding
        {
            get
            {
                if (Host.ListView is IntelligenceListView)
                    return (Host.ListView as IntelligenceListView).LeftPadding;
                else
                    return 0;
            }
            set
            {
                if (Host.ListView is IntelligenceListView)
                    (Host.ListView as IntelligenceListView).LeftPadding = value;
            }
        }

        /// <summary>
        /// AutocompleteMenu will popup automatically (when user writes text). Otherwise it will popup only programmatically or by Ctrl-Space.
        /// </summary>
        [DefaultValue(true)]
        [Description("AutocompleteMenu will popup automatically (when user writes text). Otherwise it will popup only programmatically or by Ctrl-Space.")]
        public bool AutoPopup { get; set; }

        /// <summary>
        /// AutocompleteMenu will capture focus when opening.
        /// </summary>
        [DefaultValue(false)]
        [Description("AutocompleteMenu will capture focus when opening.")]
        public bool CaptureFocus { get; set; }

        /// <summary>
        /// Indicates whether the component should draw right-to-left for RTL languages.
        /// </summary>
        [DefaultValue(typeof(RightToLeft), "No")]
        [Description("Indicates whether the component should draw right-to-left for RTL languages.")]
        public RightToLeft RightToLeft
        {
            get { return Host.RightToLeft; }
            set { Host.RightToLeft = value; }
        }

        /// <summary>
        /// Image list
        /// </summary>
        public ImageList ImageList
        {
            get { return Host.ListView.ImageList; }
            set { Host.ListView.ImageList = value; }
        }

        /// <summary>
        /// Fragment
        /// </summary>
        [Browsable(false)]
        public Range Fragment { get; internal set; }

        /// <summary>
        /// Regex pattern for serach fragment around caret
        /// </summary>
        [Description("Regex pattern for serach fragment around caret")]
        [DefaultValue(@"[\w\.]")]
        public string SearchPattern { get; set; }


        public IntelligenceMenu()
        {
            InitializeComponent();
        }

        public IntelligenceMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
