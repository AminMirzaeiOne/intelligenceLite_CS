﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static intelligenceLite.EventArgs;

namespace intelligenceLite
{
    public class MethodAutocompleteItem : IntelligenceItem
    {
        string firstPart;
        string lowercaseText;

        public MethodAutocompleteItem(string text)
            : base(text)
        {
            lowercaseText = Text.ToLower();
        }

        public override CompareResult Compare(string fragmentText)
        {
            int i = fragmentText.LastIndexOf('.');
            if (i < 0)
                return CompareResult.Hidden;
            string lastPart = fragmentText.Substring(i + 1);
            firstPart = fragmentText.Substring(0, i);

            if (lastPart == "") return CompareResult.Visible;
            if (Text.StartsWith(lastPart, StringComparison.InvariantCultureIgnoreCase))
                return CompareResult.VisibleAndSelected;
            if (lowercaseText.Contains(lastPart.ToLower()))
                return CompareResult.Visible;

            return CompareResult.Hidden;
        }

        public override string GetTextForReplace()
        {
            return firstPart + "." + Text;
        }


    }

    /// <summary>
    /// Autocomplete item for code snippets
    /// </summary>
    /// <remarks>Snippet can contain special char ^ for caret position.</remarks>
    public class SnippetAutocompleteItem : IntelligenceItem
    {
        public SnippetAutocompleteItem(string snippet)
        {
            Text = snippet.Replace("\r", "");
            ToolTipTitle = "Code snippet:";
            ToolTipText = Text;
        }

        public override string ToString()
        {
            return MenuText ?? Text.Replace("\n", " ").Replace("^", "");
        }

        public override string GetTextForReplace()
        {
            return Text;
        }

        public override void OnSelected(SelectedEventArgs e)
        {
            var tb = Parent.TargetControlWrapper;
            //
            if (!Text.Contains("^"))
                return;
            var text = tb.Text;
            for (int i = Parent.Fragment.Start; i < text.Length; i++)
                if (text[i] == '^')
                {
                    tb.SelectionStart = i;
                    tb.SelectionLength = 1;
                    tb.SelectedText = "";
                    return;
                }
        }

        /// <summary>
        /// Compares fragment text with this item
        /// </summary>
        public override CompareResult Compare(string fragmentText)
        {
            if (Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase) &&
                   Text != fragmentText)
                return CompareResult.Visible;

            return CompareResult.Hidden;
        }


    }

    /// <summary>
    /// This class finds items by substring
    /// </summary>
    public class SubstringAutocompleteItem : IntelligenceItem
    {
        protected readonly string lowercaseText;
        protected readonly bool ignoreCase;

        public SubstringAutocompleteItem(string text, bool ignoreCase = true)
            : base(text)
        {
            this.ignoreCase = ignoreCase;
            if (ignoreCase)
                lowercaseText = text.ToLower();
        }


    }

}
