using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
