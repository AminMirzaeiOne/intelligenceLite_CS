using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace intelligenceLite
{
    public class TextBoxWrapper : ITextBoxWrapper
    {
        private Control target;
        private PropertyInfo selectionStart;
        private PropertyInfo selectionLength;
        private PropertyInfo selectedText;
        private PropertyInfo readonlyProperty;
        private MethodInfo getPositionFromCharIndex;
        private event ScrollEventHandler RTBScroll;

        private TextBoxWrapper(Control targetControl)
        {
            this.target = targetControl;
            Init();
        }

        protected virtual void Init()
        {
            var t = target.GetType();
            selectedText = t.GetProperty("SelectedText");
            selectionLength = t.GetProperty("SelectionLength");
            selectionStart = t.GetProperty("SelectionStart");
            readonlyProperty = t.GetProperty("ReadOnly");
            getPositionFromCharIndex = t.GetMethod("GetPositionFromCharIndex") ?? t.GetMethod("PositionToPoint");

            if (target is RichTextBox)
                (target as RichTextBox).VScroll += new EventHandler(TextBoxWrapper_VScroll);
        }

        void TextBoxWrapper_VScroll(object sender, EventArgs e)
        {
            if (RTBScroll != null)
                RTBScroll(sender, new ScrollEventArgs(ScrollEventType.EndScroll, 0, 1));
        }

    }
}
