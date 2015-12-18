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
namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string ClientId = "3MVG9ZL0ppGP5UrBAr_AfS4s1CMPjDxJsoEVHv46goFLdXXdKK.9X9gJ_9tkebRJLhGK_gZ9r1DAtXoO9JTqO";
        private static string ClientSecret = "8975182172956404836";

        #region username/password

        //private static string Username = "sfcrmdev@sri.kanth";
        //private static string Token = "yxhSXst9fIHQzI0jU02y93QV";
        
        //private static string Password = "srikanth.123" + Token;
        //private static string UserAgent = "DemoSFSDK";
        private static string _username;
        private static string _password;
        private static string _token = "";
        private const string TokenRequestEndPointUrl = "https://login.salesforce.com/services/oauth2/token";
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            if (Application.Current.Properties["SFUsername"] == null ||
                Application.Current.Properties["SFPassword"] == null ||
               Application.Current.Properties["SFToken"] == null) return;
            sfusername.Text = _username = Application.Current.Properties["SFUsername"].ToString();
            sfpassword.Password = _password = Application.Current.Properties["SFPassword"].ToString();
            _token = Application.Current.Properties["SFToken"].ToString();
        }
        private async void RunSample()
        {
            try
            {
                var auth = new Salesforce.Common.AuthenticationClient();
                List<Contact> myClasses = new List<Contact>();
                await auth.UsernamePasswordAsync(ClientId, ClientSecret, _username, _password+_token);
                var client = new ForceClient(auth.InstanceUrl, auth.AccessToken, auth.ApiVersion);
                //var results = await client.QueryAsync<Contact>("SELECT id, AccountId, Salutation, FirstName, LastName, description, Phone FROM Contact");

                //var app = App.Current.Properties;


                if (auth.ApiVersion == null || auth.InstanceUrl == null || auth.AccessToken == null) return;
                Application.Current.Properties["AccessToken"] = auth.AccessToken;
                Application.Current.Properties["InstanceUrl"] = auth.InstanceUrl;
                Application.Current.Properties["SF_ApiVersion"] = auth.ApiVersion;
                Application.Current.Properties["SFToken"] = _token;
                Application.Current.Properties["SFUsername"] = _username;
                Application.Current.Properties["SFPassword"] = _password;
                new Window1().Show();
                Hide();
            }
            catch (Exception e)
            {
                ;
                MessageBox.Show(e.Message);
            }
            //ApplicationData.Current.RoamingSettings.Values["SF_ApiVersion"] = auth.ApiVersion;
            //Label_Status.Text = "Login Success";

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sftoken.Text.Trim() != "")
            {
                _token = sftoken.Text.Trim();
            }
            if (sfusername.Text.Trim() != "" && sfpassword.Password != "" && _token.Trim() != "")
            {
                _username = sfusername.Text.Trim();
                _password = sfpassword.Password;
                RunSample();
            }
            else 
            {
                MessageBox.Show("Please Enter Username, Password and Token");
            }
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            
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
