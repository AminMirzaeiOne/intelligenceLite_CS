using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intelligenceLite
{
    public partial class IntelligenceMenu : Component
    {
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
