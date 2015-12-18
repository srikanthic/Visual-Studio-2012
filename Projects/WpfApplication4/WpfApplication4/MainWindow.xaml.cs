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
using WpfApplication4.SFDC;

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string userName;
        string password;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userName = "sfcrmdev@sri.kanth";
            password = "srikanth.123yxhSXst9fIHQzI0jU02y93QV";
            SforceService SfdcBinding = null;
            LoginResult CurrentLoginResult = null;
            SfdcBinding = new SforceService();
            try
            {
                CurrentLoginResult = SfdcBinding.login(userName, password);
            }
            catch (System.Web.Services.Protocols.SoapException a)
            {
                // This is likley to be caused by bad username or password
                SfdcBinding = null;
                throw (a);
            }
            catch (Exception a)
            {
                // This is something else, probably comminication
                SfdcBinding = null;
                throw (a);
            }
        }
    }
}
