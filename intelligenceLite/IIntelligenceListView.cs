﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static intelligenceLite.EventArgs;

namespace intelligenceLite
{
    internal interface IIntelligenceListView
    {
        /// <summary>
        /// Image list
        /// </summary>
        ImageList ImageList { get; set; }

        /// <summary>
        /// Index of current selected item
        /// </summary>
        int SelectedItemIndex { get; set; }

        /// <summary>
        /// Index of current selected item
        /// </summary>
        int HighlightedItemIndex { get; set; }

        /// <summary>
        /// List of visible elements
        /// </summary>
        IList<IntelligenceItem> VisibleItems { get; set; }

        /// <summary>
        /// Duration (ms) of tooltip showing
        /// </summary>
        int ToolTipDuration { get; set; }

        /// <summary>
        /// Occurs when user selected item for inserting into text
        /// </summary>
        event EventHandler ItemSelected;

        /// <summary>
        /// Occurs when current hovered item is changing
        /// </summary>
        event EventHandler<HoveredEventArgs> ItemHovered;

        /// <summary>
        /// Shows tooltip
        /// </summary>
        /// <param name="autocompleteItem"></param>
        /// <param name="control"></param>
        void ShowToolTip(IntelligenceItem autocompleteItem, Control control = null);
    }
}
