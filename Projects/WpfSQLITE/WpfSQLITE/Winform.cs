using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfSQLITE
{
    public partial class Winform : UserControl
    {
        public Winform()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //int i = 0;

            if (label1.Text == "1")
            {
                label1.Text = "2";
            }
            else
            {
                label1.Text = "1";
            }
            //label1.Text = i++.ToString();
        }
    }
}
