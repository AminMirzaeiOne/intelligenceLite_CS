﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
