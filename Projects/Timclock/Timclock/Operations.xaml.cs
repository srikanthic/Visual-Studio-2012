using System;
using System.Threading;
using System.Windows;
using Timclock.Control;
using Timclock.Model;
using Timclock.View;

namespace Timclock
{
    /// <summary>
    /// Interaction logic for Operations.xaml
    /// </summary>
    public partial class Operations : Window
    {
        MyDbConnClass MyDbConnClass = new MyDbConnClass();
        
        private Timeclock _timeclock;
        private Login _login;
        private static bool iswifishow = false;
        Checkwifi checkwifi = new Checkwifi();
        //private string loginout;
        //public string Loginout {
        //    get
        //    {
        //        if (Cradentials.Logintrys == 0)
        //        {
        //            return "Logout";
        //        }
        //        else
        //        {
        //            return "LogIn";
        //        }
        //    }
        //}

        public Operations()
        {
            InitializeComponent();
            Checkwifi.DispatcherTimer.Tick += time_tick1;
            if (Cradentials.RunSampleSucess)
            {
                Inout.Content = "Logout";
            }
            //this.Hide += new EventHandler(this.Hide);    
           // Signell_check.Source = new BitmapImage(new Uri("Souce/Imgs/Custom-Icon-Design-Mono-General-3-Wifi.ico", UriKind.Relative));
          //  Button_Click_1(this,new RoutedEventArgs());
            //var wi = Application.Current.Windows;
            //foreach (var VARIABLE in wi)
            //{
            //    if ((VARIABLE as Window).Title.ToLower() == "operations")
            //    {
            //        (VARIABLE as Operations).Grid.Children.RemoveRange(0, (VARIABLE as Operations).Grid.Children.Count - 1);
            //    }
            //}
            //if(!iswifishow)
           // {
           
            Grid.Children.Add(checkwifi);
            //checkwifi.Name = "checkwifi";
            iswifishow = true;
           // }
        }

        private void time_tick1(object sender, EventArgs e)
        {
            if (Cradentials.Asyncrun == 1)
            {
                Inout.Content = "Logout";
            }
            else
            {
                Inout.Content = "LogIn";
            }
        }

        private void Removewifi()
        {
            Grid.Children.Remove(checkwifi);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Properties["SFUsername"] == null ||
                Application.Current.Properties["SFPassword"] == null ||
                (Application.Current.Properties["SFToken"] == null && LoginAttribute.sandbox==false) || Cradentials.RunSampleSucess == false)
            {
                _login = null;
                _login = new Login();
                _login.Show();
                //new Login().Show();
                Hide();
            }
            else
            {
                new List_of_SF_Records().Show();
                Hide();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Cradentials.RunSampleSucess)
            {
                Cradentials.RunSampleSucess = false;
                Cradentials.Asyncrun = 0;
                Cradentials.SetLogout();

                Inout.Content = "Login";
             if (Properties.Settings.Default.AutoLogin)
                {
                    Properties.Settings.Default.AutoLogin = false;
                }
                Properties.Settings.Default.Save();
            }
            else
            {
                _login = null;
                _login = new Login();
                _login.Show();
                //new Login().Show();
                Hide();
            }

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Close();
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
            Application.Current.Shutdown();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new ViewLocalDb().Show();
            this.Hide();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            App.fetchRec = true;
            bool i = MyDbConnClass.Fetchsftodb();
            if (!i)
            {
                _login = null;
                _login = new Login();
                _login.Show();
                //if (!Cradentials.OpenHiddenWindowCheack(new Login()))
                //{
                //    new Login().Show();
                //}
                //new Login().Show();
                Hide();
            }
        }

      
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //if (Cradentials.RunSampleSucess)
            //{
                _timeclock = null;
                _timeclock= new Timeclock();
                Hide();
                _timeclock.ShowDialog();
                
                //if (!Cradentials.OpenHiddenWindowCheack(new Timeclock()))
                //{
                //    new Timeclock().Show();
                //}
                //new Timeclock().Show();
                
            //}
            //else
            //{
            //    _login = null;
            //    _login= new Login();
            //    _login.Show();
            //    //if (!Cradentials.OpenHiddenWindowCheack(new Login()))
            //    //{
            //    //    new Login().Show();
            //    //}
            //    //new Login().Show();
            //    Hide();
            //}
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
           MyDbConnClass.DeleteallLclRec();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Hidden)
            {
                checkwifi.stopDispatcherTimer();
            }
        }
    }
}
