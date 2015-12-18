using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for Checkwifi.xaml
    /// </summary>
    public partial class Checkwifi : UserControl
    {
        DispatcherTimer DispatcherTimer= new DispatcherTimer();

        public Checkwifi()
        {
            InitializeComponent();
            DispatcherTimer.Tick += time_tick;
            DispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            DispatcherTimer.Start();
        }

        private void time_tick(object sender, EventArgs e)
        {
            if (IsConnectedToInternet())
            {
                Image1.Visibility = Visibility.Visible;
            }
            else
            {
                Image1.Visibility = Visibility.Hidden;
            }
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public static bool IsConnectedToInternet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }
    }
}
