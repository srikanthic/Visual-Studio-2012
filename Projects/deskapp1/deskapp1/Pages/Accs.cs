using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Salesforce.Common;
using Salesforce.Force;
using System.Threading.Tasks;
using System.Dynamic;
using deskapp1.Models;
using Salesforce.Common.Models;

namespace deskapp1.Pages
{
    public partial class Accs : Form
    {
        private static string ClientId = "3MVG9ZL0ppGP5UrBAr_AfS4s1CMPjDxJsoEVHv46goFLdXXdKK.9X9gJ_9tkebRJLhGK_gZ9r1DAtXoO9JTqO";
        private static string ClientSecret = "8975182172956404836";

        #region username/password

        private static string Username = "sfcrmdev@sri.kanth";
        private static string Token = "yxhSXst9fIHQzI0jU02y93QV";
        //private static string Token = "";
        private static string Password = "srikanth.123" + Token;
        //private static string UserAgent = "DemoSFSDK";
        private const string TokenRequestEndPointURL = "https://login.salesforce.com/services/oauth2/token";
        #endregion
    //    public Salesforce.Common.Models.QueryResult<Contact> results { get; set; }
        public Accs()
        {
            InitializeComponent();
            RunSample();
        }

        private void bckBttn_Click(object sender, EventArgs e)
        {
            
        }

        private async void RunSample()
        {
            var auth = new Salesforce.Common.AuthenticationClient();
            List<Contact> myClasses = new List<Contact>();
            await auth.UsernamePasswordAsync(ClientId, ClientSecret, Username, Password);
           var client = new ForceClient(auth.InstanceUrl, auth.AccessToken, auth.ApiVersion);
           //var results = await client.QueryAsync<Contact>("SELECT id, AccountId, Salutation, FirstName, LastName, description, Phone FROM Contact");

            //var app = App.Current.Properties;

            
            if (auth.ApiVersion != null && auth.InstanceUrl != null && auth.AccessToken!=null)
            {
                App.Current.Properties["AccessToken"] = auth.AccessToken;
                App.Current.Properties["InstanceUrl"] = auth.InstanceUrl;
                App.Current.Properties["SF_ApiVersion"] = auth.ApiVersion;                
            }
            //ApplicationData.Current.RoamingSettings.Values["SF_ApiVersion"] = auth.ApiVersion;
            //Label_Status.Text = "Login Success";
            
        }

        
    }
}
