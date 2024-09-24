using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static intelligenceLite.EventArgs;

namespace intelligenceLite
{
    public enum Themes
    {
        None, Light, Dark, Gray
    }
    public enum Styles
    {
        Fusion, Flat
    }

    [ProvideProperty("IntelligenceMenu", typeof(Control))]
    public class IntelligenceMenu : Component, IExtenderProvider
    {
        private static readonly Dictionary<Control, IntelligenceMenu> IntelligenceMenuByControls =
            new Dictionary<Control, IntelligenceMenu>();
        private static readonly Dictionary<Control, ITextBoxWrapper> WrapperByControls =
            new Dictionary<Control, ITextBoxWrapper>();

        private ITextBoxWrapper targetControlWrapper;
        private readonly Timer timer = new Timer();
        private Form myForm;

        private IEnumerable<IntelligenceItem> sourceItems = new List<IntelligenceItem>();
        [Browsable(false)]
        public IList<IntelligenceItem> VisibleItems { get { return Host.ListView.VisibleItems; } private set { Host.ListView.VisibleItems = value; } }
        private Size maximumSize;
        bool forcedOpened = false;


        private System.Drawing.Color themeColor = Color.Black;
        private intelligenceLite.Themes theme = intelligenceLite.Themes.None;
        private intelligenceLite.Styles style = Styles.Fusion;
        private System.Boolean themeColorEnable = false;

        private System.Drawing.Color foreColor = Color.Black;
        private System.Drawing.Color backColor = Color.White;
        private System.Drawing.Color selectedForeColor = Color.White;
        private System.Drawing.Color selectedBackColor = Color.Orange;
        private System.Drawing.Color selectedBackColor2 = Color.Tomato;
        private System.Drawing.Color highlightingColor = Color.White;

        [Category("Theme Options")]
        public intelligenceLite.Styles Style
        {
            get { return this.style; }
            set
            {
                this.style = value;
                if (this.ThemeColorEnable)
                {
                    if (value == intelligenceLite.Styles.Fusion)
                    {
                        this.SelectedBackColor2 = System.Drawing.Color.FromArgb(100, this.ThemeColor.R, this.ThemeColor.G, this.ThemeColor.B);
                    }
                    else
                    {
                        this.SelectedBackColor2 = this.ThemeColor;
                    }
                }
                
            }
        }

        [Category("Theme Options")]
        public intelligenceLite.Themes Theme
        {
            get { return this.theme; }
            set
            {
                this.theme = value;
                switch (value)
                {
                    case Themes.Light:
                        this.BackColor = System.Drawing.Color.White;
                        this.ForeColor = System.Drawing.Color.Black;
                        this.SelectedForeColor = System.Drawing.Color.Black;
                        break;
                    case Themes.Dark:
                        this.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
                        this.ForeColor = System.Drawing.Color.White;
                        this.SelectedForeColor = System.Drawing.Color.White;
                        break;
                    case Themes.Gray:
                        this.BackColor = System.Drawing.Color.DimGray;
                        this.ForeColor = System.Drawing.Color.Black;
                        this.SelectedForeColor = System.Drawing.Color.Black;
                        break;
                }
            }
        }

        [Category("Theme Options")]
        public System.Boolean ThemeColorEnable
        {
            get { return this.themeColorEnable; }
            set
            {
                this.themeColorEnable = value;
                if (value)
                {
                    this.BorderColor = this.ThemeColor;
                    this.HighlightingColor = this.ThemeColor;
                    this.SelectedBackColor = this.ThemeColor;
                    if (this.Style == Styles.Fusion)
                        this.SelectedBackColor2 = System.Drawing.Color.FromArgb(100, this.ThemeColor.R, this.ThemeColor.G, this.ThemeColor.B);
                    else
                        this.SelectedBackColor2 = this.ThemeColor;
                }
            }
        }

        [Category("Theme Options")]
        public System.Drawing.Color ThemeColor
        {
            get { return this.themeColor; }
            set
            {
                this.themeColor = value;
                if (this.ThemeColorEnable)
                {
                    this.BorderColor = value;
                    this.HighlightingColor = value;
                    this.SelectedBackColor = value;
                    if (this.Style == Styles.Fusion)
                        this.SelectedBackColor2 = System.Drawing.Color.FromArgb(100, value.R, value.G, value.B);
                    else
                        this.SelectedBackColor2 = value;
                }
            }
        }


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

        /// <summary>
        /// Minimum fragment length for popup
        /// </summary>
        [Description("Minimum fragment length for popup")]
        [DefaultValue(2)]
        public int MinFragmentLength { get; set; }

        /// <summary>
        /// Allows TAB for select menu item
        /// </summary>
        [Description("Allows TAB for select menu item")]
        [DefaultValue(false)]
        public bool AllowsTabKey { get; set; }

        /// <summary>
        /// Interval of menu appear (ms)
        /// </summary>
        [Description("Interval of menu appear (ms)")]
        [DefaultValue(500)]
        public int AppearInterval { get; set; }

        [DefaultValue(null)]
        public intelligenceLite.IntelligenceItem[] Items
        {
            get
            {
                if (sourceItems == null)
                    return null;
                var list = new List<intelligenceLite.IntelligenceItem>();
                foreach (IntelligenceItem item in sourceItems)
                    list.Add(item);
                return list.ToArray();
            }
            set { SetIntelligenceItems(value); }
        }

        // <summary>
        /// The control for menu displaying.
        /// Set to null for restore default ListView (AutocompleteListView).
        /// </summary>
        [Browsable(false)]
        internal IIntelligenceListView ListView
        {
            get { return Host.ListView; }
            set
            {
                if (ListView != null)
                {
                    var ctrl = value as Control;
                    value.ImageList = ImageList;
                    ctrl.RightToLeft = RightToLeft;
                    ctrl.Font = Font;
                    ctrl.MaximumSize = MaximumSize;
                }
                Host.ListView = value;
                Host.ListView.ItemSelected += new EventHandler(ListView_ItemSelected);
                Host.ListView.ItemHovered += new EventHandler<HoveredEventArgs>(ListView_ItemHovered);
            }
        }

        [DefaultValue(true)]
        public bool Enabled { get; set; }

        /// <summary>
        /// Updates size of the menu
        /// </summary>
        public void Update()
        {
            Host.CalcSize();
        }

        /// <summary>
        /// Returns rectangle of item
        /// </summary>
        public Rectangle GetItemRectangle(int itemIndex)
        {
            return Host.ListView.GetItemRectangle(itemIndex);
        }

        #region IExtenderProvider Members

        bool IExtenderProvider.CanExtend(object extendee)
        {
            //find  AutocompleteMenu with lowest hashcode
            if (Container != null)
                foreach (object comp in Container.Components)
                    if (comp is IntelligenceMenu)
                        if (comp.GetHashCode() < GetHashCode())
                            return false;
            //we are main autocomplete menu on form ...
            //check extendee as TextBox
            if (!(extendee is Control))
                return false;
            var temp = TextBoxWrapper.Create(extendee as Control);
            return temp != null;
        }

        public void SetIntelligenceMenu(Control control, IntelligenceMenu menu)
        {
            if (menu != null)
            {
                if (WrapperByControls.ContainsKey(control))
                    return;
                var wrapper = menu.CreateWrapper(control);
                if (wrapper == null) return;
                //
                if (control.IsHandleCreated)
                    menu.SubscribeForm(wrapper);
                else
                    control.HandleCreated += (o, e) => menu.SubscribeForm(wrapper);
                //
                IntelligenceMenuByControls[control] = this;
                //
                wrapper.LostFocus += menu.control_LostFocus;
                wrapper.Scroll += menu.control_Scroll;
                wrapper.KeyDown += menu.control_KeyDown;
                wrapper.MouseDown += menu.control_MouseDown;
            }
            else
            {
                IntelligenceMenuByControls.TryGetValue(control, out menu);
                IntelligenceMenuByControls.Remove(control);
                ITextBoxWrapper wrapper = null;
                WrapperByControls.TryGetValue(control, out wrapper);
                WrapperByControls.Remove(control);
                if (wrapper != null && menu != null)
                {
                    wrapper.LostFocus -= menu.control_LostFocus;
                    wrapper.Scroll -= menu.control_Scroll;
                    wrapper.KeyDown -= menu.control_KeyDown;
                    wrapper.MouseDown -= menu.control_MouseDown;
                }
            }
        }

        #endregion

        /// <summary>
        /// User selects item
        /// </summary>
        [Description("Occurs when user selects item.")]
        public event EventHandler<SelectingEventArgs> Selecting;

        /// <summary>
        /// It fires after item was inserting
        /// </summary>
        [Description("Occurs after user selected item.")]
        public event EventHandler<SelectedEventArgs> Selected;

        /// <summary>
        /// It fires when item was hovered
        /// </summary>
        [Description("Occurs when user hovered item.")]
        public event EventHandler<HoveredEventArgs> Hovered;

        /// <summary>
        /// Occurs when popup menu is opening
        /// </summary>
        public event EventHandler<CancelEventArgs> Opening;

        private void timer_Tick(object sender, System.EventArgs e)
        {
            timer.Stop();
            if (TargetControlWrapper != null)
                ShowIntelligence(false);
        }

        void SubscribeForm(ITextBoxWrapper wrapper)
        {
            if (wrapper == null) return;
            var form = wrapper.TargetControl.FindForm();
            if (form == null) return;
            if (myForm != null)
            {
                if (myForm == form)
                    return;
                UnsubscribeForm(wrapper);
            }

            myForm = form;

            form.LocationChanged += new EventHandler(form_LocationChanged);
            form.ResizeBegin += new EventHandler(form_LocationChanged);
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.LostFocus += new EventHandler(form_LocationChanged);
        }

        void UnsubscribeForm(ITextBoxWrapper wrapper)
        {
            if (wrapper == null) return;
            var form = wrapper.TargetControl.FindForm();
            if (form == null) return;

            form.LocationChanged -= new EventHandler(form_LocationChanged);
            form.ResizeBegin -= new EventHandler(form_LocationChanged);
            form.FormClosing -= new FormClosingEventHandler(form_FormClosing);
            form.LostFocus -= new EventHandler(form_LocationChanged);
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }

        private void form_LocationChanged(object sender, System.EventArgs e)
        {
            Close();
        }

        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            Close();
        }

        ITextBoxWrapper FindWrapper(Control sender)
        {
            while (sender != null)
            {
                if (WrapperByControls.ContainsKey(sender))
                    return WrapperByControls[sender];

                sender = sender.Parent;
            }

            return null;
        }

        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            TargetControlWrapper = FindWrapper(sender as Control);

            bool backspaceORdel = e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete;

            if (Host.Visible)
            {
                if (ProcessKey((char)e.KeyCode, Control.ModifierKeys))
                    e.SuppressKeyPress = true;
                else
                    if (!backspaceORdel)
                    ResetTimer(1);
                else
                    ResetTimer();

                return;
            }

            if (!Host.Visible)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.PageUp:
                    case Keys.PageDown:
                    case Keys.Left:
                    case Keys.Right:
                    case Keys.End:
                    case Keys.Home:
                    case Keys.ControlKey:
                        {
                            timer.Stop();
                            return;
                        }
                }

                if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Space)
                {
                    ShowIntelligence(true);
                    e.SuppressKeyPress = true;
                    return;
                }
            }

            ResetTimer();
        }

        void ResetTimer()
        {
            ResetTimer(-1);
        }

        void ResetTimer(int interval)
        {
            if (interval <= 0)
                timer.Interval = AppearInterval;
            else
                timer.Interval = interval;
            timer.Stop();
            timer.Start();
        }

        private void control_Scroll(object sender, ScrollEventArgs e)
        {
            Close();
        }

        private void control_LostFocus(object sender, System.EventArgs e)
        {
            if (!Host.Focused) Close();
        }

        public IntelligenceMenu GetIntelligenceMenu(Control control)
        {
            if (IntelligenceMenuByControls.ContainsKey(control))
                return IntelligenceMenuByControls[control];
            else
                return null;
        }

        internal void ShowIntelligence(bool forced)
        {
            if (forced)
                forcedOpened = true;

            if (TargetControlWrapper != null && TargetControlWrapper.Readonly)
            {
                Close();
                return;
            }

            if (!Enabled)
            {
                Close();
                return;
            }

            if (!forcedOpened && !AutoPopup)
            {
                Close();
                return;
            }

            //build list
            BuildIntelligenceList(forcedOpened);

            //show popup menu
            if (VisibleItems.Count > 0)
            {
                if (forced && VisibleItems.Count == 1 && Host.ListView.SelectedItemIndex == 0)
                {
                    //do autocomplete if menu contains only one line and user press CTRL-SPACE
                    OnSelecting();
                    Close();
                }
                else
                    ShowMenu();
            }
            else
                Close();
        }

        private void ShowMenu()
        {
            if (!Host.Visible)
            {
                var args = new CancelEventArgs();
                OnOpening(args);
                if (!args.Cancel)
                {
                    //calc screen point for popup menu
                    Point point = TargetControlWrapper.TargetControl.Location;
                    point.Offset(2, TargetControlWrapper.TargetControl.Height + 2);
                    point = TargetControlWrapper.GetPositionFromCharIndex(Fragment.Start);
                    point.Offset(2, TargetControlWrapper.TargetControl.Font.Height + 2);
                    //
                    Host.Show(TargetControlWrapper.TargetControl, point);
                    if (CaptureFocus)
                    {
                        (Host.ListView as Control).Focus();
                        //ProcessKey((char) Keys.Down, Keys.None);
                    }
                }
            }
            else
                (Host.ListView as Control).Invalidate();
        }


        private void BuildIntelligenceList(bool forced)
        {
            var visibleItems = new List<IntelligenceItem>();

            bool foundSelected = false;
            int selectedIndex = -1;
            //get fragment around caret
            Range fragment = GetFragment(SearchPattern);
            string text = fragment.Text;
            //
            if (sourceItems != null)
                if (forced || (text.Length >= MinFragmentLength /* && tb.Selection.Start == tb.Selection.End*/))
                {
                    Fragment = fragment;
                    //build popup menu
                    foreach (IntelligenceItem item in sourceItems)
                    {
                        item.Parent = this;
                        CompareResult res = item.Compare(text);
                        if (res != CompareResult.Hidden)
                            visibleItems.Add(item);
                        if (res == CompareResult.VisibleAndSelected && !foundSelected)
                        {
                            foundSelected = true;
                            selectedIndex = visibleItems.Count - 1;
                        }
                    }

                }

            VisibleItems = visibleItems;

            if (foundSelected)
                SelectedItemIndex = selectedIndex;
            else
                SelectedItemIndex = 0;

            Host.ListView.HighlightedItemIndex = -1;

            Host.CalcSize();
        }

        internal void OnOpening(CancelEventArgs args)
        {
            if (Opening != null)
                Opening(this, args);
        }

        private Range GetFragment(string searchPattern)
        {
            var tb = TargetControlWrapper;

            if (tb.SelectionLength > 0) return new Range(tb);

            string text = tb.Text;
            var regex = new Regex(searchPattern);
            var result = new Range(tb);

            int startPos = tb.SelectionStart;
            //go forward
            int i = startPos;
            while (i >= 0 && i < text.Length)
            {
                if (!regex.IsMatch(text[i].ToString()))
                    break;
                i++;
            }
            result.End = i;

            //go backward
            i = startPos;
            while (i > 0 && (i - 1) < text.Length)
            {
                if (!regex.IsMatch(text[i - 1].ToString()))
                    break;
                i--;
            }
            result.Start = i;

            return result;
        }

        public void Close()
        {
            Host.Close();
            forcedOpened = false;
        }

        public void SetIntelligenceItems(IEnumerable<string> items)
        {
            var list = new List<IntelligenceItem>();
            if (items == null)
            {
                sourceItems = null;
                return;
            }
            foreach (string item in items)
                list.Add(new IntelligenceItem(item));
            SetIntelligenceItems(list);
        }

        public void SetIntelligenceItems(IEnumerable<IntelligenceItem> items)
        {
            sourceItems = items;
        }

        public void AddItem(string item)
        {
            AddItem(new IntelligenceItem(item));
        }


        public void AddItem(IntelligenceItem item)
        {
            if (sourceItems == null)
                sourceItems = new List<IntelligenceItem>();

            if (sourceItems is IList)
                (sourceItems as IList).Add(item);
            else
                throw new Exception("Current autocomplete items does not support adding");
        }

        /// <summary>
        /// Shows popup menu immediately
        /// </summary>
        /// <param name="forced">If True - MinFragmentLength will be ignored</param>
        public void Show(Control control, bool forced)
        {
            SetIntelligenceMenu(control, this);
            this.TargetControlWrapper = FindWrapper(control);
            ShowIntelligence(forced);
        }

        internal virtual void OnSelecting()
        {
            if (SelectedItemIndex < 0 || SelectedItemIndex >= VisibleItems.Count)
                return;

            IntelligenceItem item = VisibleItems[SelectedItemIndex];
            var args = new SelectingEventArgs
            {
                Item = item,
                SelectedIndex = SelectedItemIndex
            };

            OnSelecting(args);

            if (args.Cancel)
            {
                SelectedItemIndex = args.SelectedIndex;
                (Host.ListView as Control).Invalidate(true);
                return;
            }

            if (!args.Handled)
            {
                Range fragment = Fragment;
                ApplyIntelligence(item, fragment);
            }

            Close();
            //
            var args2 = new SelectedEventArgs
            {
                Item = item,
                Control = TargetControlWrapper.TargetControl
            };
            item.OnSelected(args2);
            OnSelected(args2);
        }

        private void ApplyIntelligence(IntelligenceItem item, Range fragment)
        {
            string newText = item.GetTextForReplace();
            //replace text of fragment
            fragment.Text = newText;
            fragment.TargetWrapper.TargetControl.Focus();
        }

        internal void OnSelecting(SelectingEventArgs args)
        {
            if (Selecting != null)
                Selecting(this, args);
        }

        public void OnSelected(SelectedEventArgs args)
        {
            if (Selected != null)
                Selected(this, args);
        }

        public void SelectNext(int shift)
        {
            SelectedItemIndex = Math.Max(0, Math.Min(SelectedItemIndex + shift, VisibleItems.Count - 1));
            //
            (Host.ListView as Control).Invalidate();
        }

        public bool ProcessKey(char c, Keys keyModifiers)
        {
            var page = Host.Height / (Font.Height + 4);
            if (keyModifiers == Keys.None)
                switch ((Keys)c)
                {
                    case Keys.Down:
                        SelectNext(+1);
                        return true;
                    case Keys.PageDown:
                        SelectNext(+page);
                        return true;
                    case Keys.Up:
                        SelectNext(-1);
                        return true;
                    case Keys.PageUp:
                        SelectNext(-page);
                        return true;
                    case Keys.Enter:
                        OnSelecting();
                        return true;
                    case Keys.Tab:
                        if (!AllowsTabKey)
                            break;
                        OnSelecting();
                        return true;
                    case Keys.Left:
                    case Keys.Right:
                        Close();
                        return false;
                    case Keys.Escape:
                        Close();
                        return true;
                }

            return false;
        }

        /// <summary>
        /// Menu is visible
        /// </summary>
        public bool Visible
        {
            get { return Host != null && Host.Visible; }
        }




    }
}
