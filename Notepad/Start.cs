using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            this.timer1.Enabled = true;
            this.timer1.Interval = 6000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
