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
using Salesforce.Force;
using WpfApplication3.Model;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for List_of_SF_Records.xaml
    /// </summary>
    public partial class List_of_SF_Records : Window
    {
        LoginAttribute loginattributs = new LoginAttribute();
        public List_of_SF_Records()
        {
            InitializeComponent();
            if (Application.Current.Properties["SFUsername"] == null ||
    Application.Current.Properties["SFPassword"] == null ||
    Application.Current.Properties["SFToken"] == null || Application.Current.Properties["AccessToken"] == null || Application.Current.Properties["InstanceUrl"] == null || Application.Current.Properties["SF_ApiVersion"] == null)
            {
                new Login().Show();
                Hide();
            }
            else if (string.IsNullOrEmpty(Application.Current.Properties["SFUsername"].ToString()) ||
                     string.IsNullOrEmpty(Application.Current.Properties["SFPassword"].ToString()) ||
                     string.IsNullOrEmpty(Application.Current.Properties["SFToken"].ToString()) ||
                     string.IsNullOrEmpty(Application.Current.Properties["AccessToken"].ToString()) ||
                     string.IsNullOrEmpty(Application.Current.Properties["InstanceUrl"].ToString()) ||
                     string.IsNullOrEmpty(Application.Current.Properties["SF_ApiVersion"].ToString())) 
            {

                new Login().Show();
                Hide();

            }
            else
            {
                Dysplay();

               
            }
        }

        private async  void Dysplay()
        {
            var client = new ForceClient(Application.Current.Properties["InstanceUrl"].ToString(), Application.Current.Properties["AccessToken"].ToString(), Application.Current.Properties["SF_ApiVersion"].ToString());
            List<Account> accounts = (await client.QueryAsync<Account>("SELECT id, name, description, Phone FROM Account")).Records;
            List<Contact> contacts = (await client.QueryAsync<Contact>("SELECT id, AccountId, Salutation, FirstName, LastName, description, Phone FROM Contact")).Records;
             ListView.ItemsSource = accounts;
             ListView1.ItemsSource = contacts;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new Operations().Show();
            Hide();
        }
    }
}
