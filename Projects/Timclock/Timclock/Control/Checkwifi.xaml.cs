using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Timclock.Control
{
    /// <summary>
    /// Interaction logic for Checkwifi.xaml
    /// </summary>
    public partial class Checkwifi : UserControl
    {
        public static DispatcherTimer DispatcherTimer = null;
        public Checkwifi()
        {
            InitializeComponent();
            DispatcherTimer = null;
            DispatcherTimer = new DispatcherTimer();
            DispatcherTimer.Tick += time_tick;
            DispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            DispatcherTimer.Start();
        }

        public void stopDispatcherTimer()
        {
            DispatcherTimer.Stop();
        }

        private void time_tick(object sender, EventArgs e)
        {

            if (Cradentials.IsConnectedToInternet)
            {
                Image1.Visibility = Visibility.Hidden;
                //MessageBox.Show("");
            }
            else
            {
                Image1.Visibility = Visibility.Visible;
                
            }
        }

        //[DllImport("wininet.dll")]
        //private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        //public static bool IsConnectedToInternet()
        //{
        //    int desc;
        //    return InternetGetConnectedState(out desc, 0);
        //}
    }
}
