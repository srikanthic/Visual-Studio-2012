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
using enterprise = WpfApplication2.SfdcReference;


namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();          
        }
        public void SFDC_Connect()
        {
            using (enterprise.SoapClient loginClient = new enterprise.SoapClient("Soap"))
            {
                //set account password and account token variables
                string sfdcPassword = "srikanth.123";
                string sfdcToken = "yxhSXst9fIHQzI0jU02y93QV";
                //set to Force.com user account that has API access enabled
                string sfdcUserName = "sfcrmdev@sri.kanth";

                //create login password value which combines password and token
                string loginPassword = sfdcPassword + sfdcToken;

                //call Login operation from Enterprise WSDL
                enterprise.LoginResult result =
                    loginClient.login(
                    null,           //LoginScopeHeader
                    sfdcUserName,   //username
                    loginPassword); //password

                //get response values
                var sessionId = result.sessionId;
                var serverUrl = result.serverUrl;

                App.Current.Properties["SF_sessionId"] = sessionId;
                App.Current.Properties["SF_serverUrl"] = serverUrl;

                //print response values
                Sessionid.Content = sessionId;
                Url.Content = serverUrl;
                }
        }

        public async void SFDC_Connect1()
        {
            using (enterprise.SoapClient loginClient = new enterprise.SoapClient("Soap"))
            {
                //set account password and account token variables
                string sfdcPassword = "srikanth.123";
                string sfdcToken = "yxhSXst9fIHQzI0jU02y93QV";
                //set to Force.com user account that has API access enabled
                string sfdcUserName = "sfcrmdev@sri.kanth";

                //create login password value which combines password and token
                string loginPassword = sfdcPassword + sfdcToken;

                //call Login operation from Enterprise WSDL
                var result = await
                    loginClient.loginAsync(
                    null,           //LoginScopeHeader
                    sfdcUserName,   //username
                    loginPassword); //password

                //get response values
                var sessionId = result.result.sessionId;
                var serverUrl = result.result.serverUrl;

                App.Current.Properties["SF_sessionId"] = sessionId;
                App.Current.Properties["SF_serverUrl"] = serverUrl;

                //print response values
                Sessionid.Content = sessionId;
                Url.Content = serverUrl;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SFDC_Connect1();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {

        }
    }
}
