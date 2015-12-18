using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Script.Serialization;


namespace SalesforceREST
{
    public partial class MainForm : Form
    {
        // Consumer Key from SFDC account
        private string clientID = "3MVG9ZL0ppGP5UrBAr_AfS4s1CMPjDxJsoEVHv46goFLdXXdKK.9X9gJ_9tkebRJLhGK_gZ9r1DAtXoO9JTqO";

        // Consumer Secret from SFDC account
        private string clientSecret = "8975182172956404836";

        // Redirect URL configured in SFDC account
        private string redirectURL = "sfdc://success";

        // Code an token generated during authentication
        private string code;
        private TokenResponse token; 

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            // Build authorization URI
            var authURI = new StringBuilder();
            authURI.Append("https://login.salesforce.com/services/oauth2/authorize?");
            authURI.Append("response_type=code");
            authURI.Append("&client_id=" + clientID);
            authURI.Append("&redirect_uri=" + redirectURL);

            // Redirect the browser control the the SFDC login page
            UIWebBrowser.Navigate(authURI.ToString());
        }


        private void UIwebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Wait for a redirect to your callback URL
            if (e.Url.AbsoluteUri.StartsWith("sfdc://success"))
            {
                // Redirect so we end up with a blank web browser control
                UIWebBrowser.Navigate("about:blank");

                // Get the returned code
                code = e.Url.Query;
                code = code.Substring(6);

                // Get the access token
                GetToken();
            }
        }

        private void GetToken()
        {   
            // Create the message used to request a token
            string URI = "https://login.salesforce.com/services/oauth2/token";

            StringBuilder body = new StringBuilder();
            body.Append("code=" + code + "&");
            body.Append("grant_type=authorization_code&");
            body.Append("client_id=" + clientID + "&");
            body.Append("client_secret=" + clientSecret + "&");
            body.Append("redirect_uri = " + redirectURL);
            string result = HttpPost(URI, body.ToString());

            // Convert the JSON response into a token object
            JavaScriptSerializer ser = new JavaScriptSerializer();
            token = ser.Deserialize<TokenResponse>(result);

            // Read the REST resources
            string s = HttpGet(token.instance_url + @"/services/data/v20.0/", "");
            UIResults.Text = s;
        }

        public string HttpPost(string URI, string Parameters)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";

            // Add parameters to post
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = data.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(data, 0, data.Length); 
            os.Close();

            // Do the post and get the response.
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        public string HttpGet(string URI, string Parameters)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            req.Method = "GET";
            req.Headers.Add("Authorization: OAuth " + token.access_token );
        
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
    }

    public class TokenResponse
    {
        public string id { get; set; }
        public string issued_at { get; set; }
        public string refresh_token { get; set; }
        public string instance_url { get; set; }
        public string signature { get; set; }
        public string access_token { get; set; }
    }

}
