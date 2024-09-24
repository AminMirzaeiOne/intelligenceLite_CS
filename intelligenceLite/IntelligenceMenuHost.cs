using System;
using System.Collections.Generic;
using System.Drawing;
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

        public IIntelligenceListView ListView
        {
            get { return listView; }
            set
            {

                if (listView != null)
                    (listView as Control).LostFocus -= new EventHandler(ListView_LostFocus);

                if (value == null)
                    listView = new IntelligenceListView();
                else
                {
                    if (!(value is Control))
                        throw new Exception("ListView must be derived from Control class");

                    listView = value;
                }

                Host = new ToolStripControlHost(ListView as Control);
                Host.Margin = new Padding(2, 2, 2, 2);
                Host.Padding = Padding.Empty;
                Host.AutoSize = false;
                Host.AutoToolTip = false;

                (ListView as Control).MaximumSize = Menu.MaximumSize;
                (ListView as Control).Size = Menu.MaximumSize;
                (ListView as Control).LostFocus += new EventHandler(ListView_LostFocus);

                CalcSize();
                base.Items.Clear();
                base.Items.Add(Host);
                (ListView as Control).Parent = this;
            }
        }

        public IntelligenceMenuHost(IntelligenceMenu menu)
        {
            AutoClose = false;
            AutoSize = false;
            Margin = Padding.Empty;
            Padding = Padding.Empty;

            Menu = menu;
            ListView = new IntelligenceListView();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(listView.BackColor))
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
        }

        internal void CalcSize()
        {
            Host.Size = (ListView as Control).Size;
            Size = new System.Drawing.Size((ListView as Control).Size.Width + 4, (ListView as Control).Size.Height + 4);
        }

        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
                (ListView as Control).RightToLeft = value;
            }
        }

    }
}
