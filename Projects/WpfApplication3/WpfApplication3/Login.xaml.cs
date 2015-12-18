using Salesforce.Force;
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
using WpfApplication3.Model;
using System.IO.IsolatedStorage;
using WpfApplication3.Control;
namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        #region username/password

        //private static string Username = "sfcrmdev@sri.kanth";
        //private static string Token = "yxhSXst9fIHQzI0jU02y93QV";
        
        //private static string Password = "srikanth.123" + Token;
        //private static string UserAgent = "DemoSFSDK";
        //private const string TokenRequestEndPointUrl = "https://login.salesforce.com/services/oauth2/token";
        #endregion
        LoginAttribute loginattributs = new LoginAttribute();
        Cradentials cradentials = new Cradentials();
        public Login()
        {
            InitializeComponent();
            //sfusername.Text = "sfcrmdev@sri.kanth";
            //sfpassword.Password = "srikanth.123";
            //sftoken.Text = "yxhSXst9fIHQzI0jU02y93QV";
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
            if (Application.Current.Properties["SFUsername"] == null || Application.Current.Properties["SFPassword"] == null || Application.Current.Properties["SFToken"] == null) return;
            if (string.IsNullOrEmpty(Application.Current.Properties["SFUsername"].ToString()) || string.IsNullOrEmpty(Application.Current.Properties["SFPassword"].ToString()) || string.IsNullOrEmpty(Application.Current.Properties["SFToken"].ToString())) return;
            sfusername.Text =loginattributs._username;
            sfpassword.Password = loginattributs._password;
            Label_error.Text = "";
            if (Properties.Settings.Default.LogIn == 1)
            {
                Label_error.Text = "....";
                Label_error.Foreground = Brushes.Blue;
                new Operations().Show();
                Close();
            }
            else if (Properties.Settings.Default.LogIn == 2)
            {
                Label_error.Text = "Login Error";
                Label_error.Foreground = Brushes.Red;
            }
            else
            {
                Label_error.Text = "";
            }

            //else
            //{
                    //if (Properties.Settings.Default.LogIn == 0)
                    //{
                    //    if (!string.IsNullOrEmpty(sfusername.Text) && !string.IsNullOrEmpty(sfpassword.Password) && !string.IsNullOrEmpty(loginattributs._token))
                    //    {
                    //        cradentials.RunSample();
                    //        if (Cradentials.RunSampleSucess)
                    //        {
                    //            new Operations().Show();
                    //            Close();
                    //        }

                    //    }
                    //}
            //}
            
            
        }
        //private async void RunSample()
        //{
        //    try
        //    {
        //        var auth = new Salesforce.Common.AuthenticationClient();
        //        List<Contact> myClasses = new List<Contact>();
        //        await auth.UsernamePasswordAsync(loginattributs.ClientId, loginattributs.ClientSecret, loginattributs._username, loginattributs._password + loginattributs._token);
        //        var client = new ForceClient(auth.InstanceUrl, auth.AccessToken, auth.ApiVersion);
        //        //var results = await client.QueryAsync<Contact>("SELECT id, AccountId, Salutation, FirstName, LastName, description, Phone FROM Contact");

        //        //var app = App.Current.Properties;


        //        if (auth.ApiVersion == null || auth.InstanceUrl == null || auth.AccessToken == null) return; //if credintials not satisfied Exit here
                
        //        Application.Current.Properties["SFToken"] = loginattributs._token;
        //        if (Properties.Settings.Default.SFToken != (string)Application.Current.Properties["SFToken"])
        //        {
        //            Properties.Settings.Default.SFToken = (string)Application.Current.Properties["SFToken"];
        //        }
        //        Application.Current.Properties["SFUsername"] = loginattributs._username;
        //        if (Properties.Settings.Default.SFUsername != (string)Application.Current.Properties["SFUsername"])
        //        {
        //            Properties.Settings.Default.SFUsername = (string)Application.Current.Properties["SFUsername"];
        //        }
        //        Application.Current.Properties["SFPassword"] = loginattributs._password;
        //        if (Properties.Settings.Default.SFPassword != (string)Application.Current.Properties["SFPassword"])
        //        {
        //            Properties.Settings.Default.SFPassword = (string)Application.Current.Properties["SFPassword"];
        //        }
        //        Properties.Settings.Default.Save();
        //        Application.Current.Properties["AccessToken"] = auth.AccessToken;
        //        Application.Current.Properties["InstanceUrl"] = auth.InstanceUrl;
        //        Application.Current.Properties["SF_ApiVersion"] = auth.ApiVersion;
        //        new Operations().Show();
        //        Hide();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    //ApplicationData.Current.RoamingSettings.Values["SF_ApiVersion"] = auth.ApiVersion;
        //    //Label_Status.Text = "Login Success";

        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sftoken.Text.Trim() != "")
            {
                loginattributs._token = sftoken.Text.Trim();
            }
            if (sfusername.Text.Trim() != "" && sfpassword.Password != "" && loginattributs._token.Trim() != "")
            {
                loginattributs._username = sfusername.Text.Trim();
                loginattributs._password = sfpassword.Password;
                cradentials.RunSample(loginattributs);
                //while (Cradentials.Asyncrun>0)
                // {
                //if (Cradentials.RunSampleSucess)
                //{
                //    if (Cradentials.Asyncrun == 1)
                //    {
                //        Close();
                //    }
                //    //else
                //    //{
                //    //    new Login().Show();
                //    //    Hide();
                //    //}
                //}
                //}
            }
            else 
            {
                MessageBox.Show("Please Enter Username, Password and Token");
            }
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new Operations().Show();
            //Close();
        }

    //    private GridLength _rememberWidth = GridLength.Auto;

    //    private void Grid_Collapsed(object sender, RoutedEventArgs e)
    //    {
    //        var grid = sender as Grid;
    //        if (grid != null)
    //        {
    //            _rememberWidth = grid.ColumnDefinitions[1].Width;
    //            grid.ColumnDefinitions[1].Width = GridLength.Auto;
    //        }
    //    }

    //    private void Grid_Expanded(object sender, RoutedEventArgs e)
    //    {
    //        var grid = sender as Grid;
    //        if (grid != null)
    //        {
    //            grid.ColumnDefinitions[1].Width = _rememberWidth;
    //        }
    //    }
      }
}
