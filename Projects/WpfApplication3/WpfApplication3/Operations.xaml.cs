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
using System.Windows.Shapes;
using WpfApplication3.Control;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for Operations.xaml
    /// </summary>
    public partial class Operations : Window
    {
        MyDbConnClass MyDbConnClass= new MyDbConnClass();
        public Operations()
        {
            InitializeComponent();
            if (Cradentials.RunSampleSucess)
            {
                Inout.Content = "Logout";
            }
            Signell_check.Source = new BitmapImage(new Uri("Souce/Imgs/Custom-Icon-Design-Mono-General-3-Wifi.ico", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Properties["SFUsername"] == null ||
                Application.Current.Properties["SFPassword"] == null ||
                Application.Current.Properties["SFToken"] == null || Cradentials.RunSampleSucess == false)
            {
                new Login().Show();
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
            }
            else
            {
                new Login().Show();
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
           int i= MyDbConnClass.Fetchsftodb();
            if (i == 0)
            {
                new Login().Show();
                Hide();
            }
        }   
    }
}
