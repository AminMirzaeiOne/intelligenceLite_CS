using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAutoComplete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.intelligenceMenu1.ThemeColor = Color.DodgerBlue;
            this.intelligenceMenu1.Items[1].Symbol_Y = 10;
            this.intelligenceMenu1.Items[0].ToolTipTitle = "Microsoft Account";
            this.intelligenceMenu1.Items[0].ToolTipText = "Microsoft Is Account One Drive";
            
        }
    }
}
