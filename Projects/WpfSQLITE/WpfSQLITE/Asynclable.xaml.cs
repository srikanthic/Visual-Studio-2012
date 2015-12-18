using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfSQLITE
{
    /// <summary>
    /// Interaction logic for Asynclable.xaml
    /// </summary>
    public partial class Asynclable : UserControl
    {
        DispatcherTimer DispatcherTimer = new DispatcherTimer();
        public Asynclable()
        {
            InitializeComponent();
            DispatcherTimer.Tick += time_tick;
            DispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            DispatcherTimer.Start();
        }
        private void time_tick(object sender, EventArgs e)
        {
            if (Label.Content=="1")
            {
               Label.Content = "2";
            }
            else
            {
                Label.Content = "1";
            }
        }
    }
}
