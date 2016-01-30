using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Astrid.Astrid.Common.UI {
    public partial class TextDisplay : UserControl {
        public TextDisplay() {
            InitializeComponent();
        }

        
        public void AppendLine(string str) {
            rtxt.AppendText(str);
            rtxt.AppendText("\r\n");
        }
    }
}
