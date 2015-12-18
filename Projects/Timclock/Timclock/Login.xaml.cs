using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Timclock.Control;
using Timclock.Model;
using Timclock.View;

namespace Timclock
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        #region username/password

        //private static string Username = "hillphoenix@live.com.sandbox";
        //private static string Token = "yxhSXst9fIHQzI0jU02y93QV";

        //private static string Password = "srikanth.123" + Token;
        //private static string UserAgent = "DemoSFSDK";
        //private const string TokenRequestEndPointUrl = "https://login.salesforce.com/services/oauth2/token";
        #endregion
        LoginAttribute loginattributs = new LoginAttribute();
        Cradentials cradentials = new Cradentials();
        private bool sandbox = LoginAttribute.sandbox;
        public static int LoginCount { get; set; }
        public Login()
        {
            InitializeComponent();
            LoginCount++;
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-us");
            //string DateTime = System.DateTime.Now.AddDays(-3).ToString("MM/dd/yyyy hh:mm tt");
            //DateTime  dateTime =DateTime.Parse(Cradentials.today);
            //sfusername.Text = "hillphoenix@live.com.sandbox";
            //sfpassword.Password = "srikanth.123";
            //sftoken.Text = "yxhSXst9fIHQzI0jU02y93QV";
            //DateTime DT=DateTime.Now;
            //string s= String.Format("{0:d/M/yyyy HH:mm:ss}", DT);
            //s = DT.ToString("g");
            loginattributs = cradentials.Login();
            if (!string.IsNullOrEmpty(loginattributs._username))
            {
                sfusername.Text = loginattributs._username;
            }
            if (!string.IsNullOrEmpty(loginattributs._password))
            {
                sfpassword.Password = loginattributs._password;
            }
            //if (!string.IsNullOrEmpty(loginattributs._token))
            //{
            //    sftoken.Text = loginattributs._token;
            //}
            if (sandbox)
            {
                if (Application.Current.Properties["SFUsername"] == null || Application.Current.Properties["SFPassword"] == null) return;
                if (string.IsNullOrEmpty(Application.Current.Properties["SFUsername"].ToString()) || string.IsNullOrEmpty(Application.Current.Properties["SFPassword"].ToString())) return;
            }
            else
            {
                if (Application.Current.Properties["SFUsername"] == null || Application.Current.Properties["SFPassword"] == null || Application.Current.Properties["SFToken"] == null) return;
                if (string.IsNullOrEmpty(Application.Current.Properties["SFUsername"].ToString()) || string.IsNullOrEmpty(Application.Current.Properties["SFPassword"].ToString()) || string.IsNullOrEmpty(Application.Current.Properties["SFToken"].ToString())) return;
            }
            
            sfusername.Text = loginattributs._username;
            sfpassword.Password = loginattributs._password;
 //           Label_error.Text = "";
            if (Properties.Settings.Default.LogIn == 1)
            {
 //               Label_error.Text = "....";
 //               Label_error.Foreground = Brushes.Blue;
                if (!ApplicationOperations.OpenHiddenWindowCheack(new Operations()))
                {
                    new Operations().Show();
                }
                Close();
            }
            //else if (Properties.Settings.Default.LogIn == 2)
            //{
            //    Label_error.Text = "Login Error";
            //    Label_error.Foreground = Brushes.Red;
            //}
            //else
            //{
            //    Label_error.Text = "";
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sftoken.Text.Trim() != "")
            {
                loginattributs._token = sftoken.Text.Trim();
            }
            if (CheckBox.IsChecked != null && CheckBox.IsChecked.Value)
            {
                if (sfusername.Text.Trim() != "" && sfpassword.Password != "")
                {
                    loginattributs._username = sfusername.Text.Trim();
                    loginattributs._password = sfpassword.Password;
                    cradentials.RunSample(loginattributs);
                }
                else
                {
                    MessageBox.Show("Please Enter Username, Password");
                }
            }
            else
            {
                
                if (sfusername.Text.Trim() != "" && sfpassword.Password != "" && loginattributs._token.Trim() != "")
                {
                    loginattributs._username = sfusername.Text.Trim();
                    loginattributs._password = sfpassword.Password;
                    cradentials.RunSample(loginattributs);
                }
                else
                {
                    MessageBox.Show("Please Enter Username, Password and Token");
                }
            }
            
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {

        }

        private Operations _operations;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _operations = null;
            _operations = new Operations();
            _operations.Show();
            //if (!Cradentials.OpenHiddenWindowCheack(new Operations()))
            //{
            //    new Operations().Show();
            //}
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBox.IsChecked != null && CheckBox.IsChecked.Value)
            {
                if (Properties.Settings.Default.Sandbox !=true)
                {
                    Properties.Settings.Default.Sandbox = true;
                }
            }
            else
            {
                if (Properties.Settings.Default.Sandbox == true)
                {
                    Properties.Settings.Default.Sandbox = false;
                }
            }
            Properties.Settings.Default.Save();
        }

        private void SavePassword_OnChecked(object sender, RoutedEventArgs e)
        {
            if (SavePassword.IsChecked != null && SavePassword.IsChecked.Value)
            {
                if (Properties.Settings.Default.AutoLogin !=true)
                {
                    Properties.Settings.Default.AutoLogin = true;
                }
            }
            else
            {
                if (Properties.Settings.Default.AutoLogin)
                {
                    Properties.Settings.Default.AutoLogin = false;
                }
            }
            Properties.Settings.Default.Save();
        }
    }
}
