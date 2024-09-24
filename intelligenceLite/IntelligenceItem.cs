using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static intelligenceLite.EventArgs;

namespace intelligenceLite
{
    public class IntelligenceItem
    {
        public object Tag;
        string toolTipTitle;
        string toolTipText;
        string menuText;

        /// <summary>
        /// Parent AutocompleteMenu
        /// </summary>
        public IntelligenceMenu Parent { get; internal set; }

        /// <summary>
        /// Text for inserting into textbox
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Image index for this item
        /// </summary>
        public int ImageIndex { get; set; }

        /// <summary>
        /// Title for tooltip.
        /// </summary>
        /// <remarks>Return null for disable tooltip for this item</remarks>
        public virtual string ToolTipTitle
        {
            get { return toolTipTitle; }
            set { toolTipTitle = value; }
        }

        /// <summary>
        /// Tooltip text.
        /// </summary>
        /// <remarks>For display tooltip text, ToolTipTitle must be not null</remarks>
        public virtual string ToolTipText
        {
            get { return toolTipText; }
            set { toolTipText = value; }
        }

        /// <summary>
        /// Menu text. This text is displayed in the drop-down menu.
        /// </summary>
        public virtual string MenuText
        {
            get { return menuText; }
            set { menuText = value; }
        }

        [Category("Icon Options")]
        public System.Drawing.Image Icon { get; set; } = null;

        [Category("Icon Options")]
        public System.Byte IconSize { get; set; } = 20;

        [Category("Symbol Options")]
        public System.String SymbolIcon { get; set; } = "";

        [Category("Symbol Options")]
        public System.Drawing.Color SymbolColor { get; set; } = System.Drawing.Color.Crimson;

        [Category("Symbol Options")]
        public System.Byte SymbolSize { get; set; } = 10;

        [Category("Symbol Options")]
        public System.Byte Symbol_Y = 5;

        public IntelligenceItem()
        {
            ImageIndex = -1;
        }

        public IntelligenceItem(string text) : this()
        {
            Text = text;
        }

        public IntelligenceItem(string text, int imageIndex)
            : this(text)
        {
            this.ImageIndex = imageIndex;
        }

        public IntelligenceItem(string text, int imageIndex, string menuText)
            : this(text, imageIndex)
        {
            this.menuText = menuText;
        }

        public IntelligenceItem(string text, int imageIndex, string menuText, string toolTipTitle, string toolTipText)
            : this(text, imageIndex, menuText)
        {
            this.toolTipTitle = toolTipTitle;
            this.toolTipText = toolTipText;
        }

        /// <summary>
        /// Returns text for inserting into Textbox
        /// </summary>
        public virtual string GetTextForReplace()
        {
            return Text;
        }

        /// <summary>
        /// Compares fragment text with this item
        /// </summary>
        public virtual CompareResult Compare(string fragmentText)
        {
            if (Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase) &&
                   Text != fragmentText)
                return CompareResult.VisibleAndSelected;

            return CompareResult.Hidden;
        }


        /// <summary>
        /// Returns text for display into popup menu
        /// </summary>
        public override string ToString()
        {
            return menuText ?? Text;
        }

        /// <summary>
        /// This method is called after item was inserted into text
        /// </summary>
        public virtual void OnSelected(SelectedEventArgs e)
        {
        }

        public virtual void OnPaint(PaintItemEventArgs e)
        {
            using (var brush = new SolidBrush(e.IsSelected ? Parent.SelectedForeColor : Parent.ForeColor))
                e.Graphics.DrawString(ToString(), e.Font, brush, e.TextRect, e.StringFormat);

            if (this.Icon == null)
                e.Graphics.DrawString(this.SymbolIcon, new Font("Segoe MDL2 Assets", 10, FontStyle.Regular), new SolidBrush(this.SymbolColor), new Point(1, (int)e.TextRect.Y + 5));
            else
                e.Graphics.DrawImage(ResizeImage(this.Icon, 14, 14), new Point(1, (int)e.TextRect.Y + 5));

        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }





    }

    public enum CompareResult
    {
        /// <summary>
        /// Item do not appears
        /// </summary>
        Hidden,
        /// <summary>
        /// Item appears
        /// </summary>
        Visible,
        /// <summary>
        /// Item appears and will selected
        /// </summary>
        VisibleAndSelected
    }
}
