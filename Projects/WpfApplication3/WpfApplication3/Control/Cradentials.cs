using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using Salesforce.Common;
using Salesforce.Force;
using WpfApplication3.Model;
using SQLite;
//using SQLiteCommand = SQLite.SQLiteCommand;
//using SQLiteConnection = SQLite.SQLiteConnection;

namespace WpfApplication3.Control
{
#region SF Toolkit operation
    class Cradentials:Window
    {
        LoginAttribute loginattributs = new LoginAttribute();
        public static bool RunSampleSucess { get; set; }
        public static int Asyncrun { get; set; } //0 for default, 1 for asnyc  done 2 for async fail
        AuthenticationClient auth = new Salesforce.Common.AuthenticationClient();

        public LoginAttribute Login()
        {
            RunSampleSucess = false;
            loginattributs._username = Properties.Settings.Default.SFUsername;
            loginattributs._password = Properties.Settings.Default.SFPassword;
            loginattributs._token = Properties.Settings.Default.SFToken;
            loginattributs.ClientId = Properties.Settings.Default.ClientId;
            loginattributs.ClientSecret = Properties.Settings.Default.ClientSecret;
            loginattributs.TokenRequestEndPointUrl = Properties.Settings.Default.TokenRequestEndPointUrl;
            if (string.IsNullOrEmpty(loginattributs.ClientId))
            {
                loginattributs.ClientId = "3MVG9ZL0ppGP5UrBAr_AfS4s1CMPjDxJsoEVHv46goFLdXXdKK.9X9gJ_9tkebRJLhGK_gZ9r1DAtXoO9JTqO";
            }
            if (string.IsNullOrEmpty(loginattributs.ClientSecret))
            {
                loginattributs.ClientSecret = "8975182172956404836";
            }
            if (Application.Current.Properties["SFUsername"] == null || Application.Current.Properties["SFPassword"] == null || Application.Current.Properties["SFToken"] == null) return loginattributs;
            if (string.IsNullOrEmpty(Application.Current.Properties["SFUsername"].ToString()) || string.IsNullOrEmpty(Application.Current.Properties["SFPassword"].ToString()) || string.IsNullOrEmpty(Application.Current.Properties["SFToken"].ToString())) return loginattributs;
            loginattributs._username= Application.Current.Properties["SFUsername"].ToString();
            loginattributs._password = Application.Current.Properties["SFPassword"].ToString();
            loginattributs._token = Application.Current.Properties["SFToken"].ToString();
            return loginattributs;
        }

        public void RunSample(LoginAttribute loginAttribute)
        {
            loginattributs= loginAttribute;
            RunSample();
            
        }
        
        public async void RunSample()
        {
            try
            {
                //List<Contact> myClasses = new List<Contact>();
                Asyncrun = 0;
                RunSampleSucess = false;
                await auth.UsernamePasswordAsync(loginattributs.ClientId, loginattributs.ClientSecret, loginattributs._username, loginattributs._password + loginattributs._token);
                //while (Asyncrun>0)
                //{
                    RunSample_continue();
               // }
            }
            catch (Exception e)
            {
                Asyncrun = 2;
                RunSampleSucess = false;
                MessageBox.Show(e.Message);
            }
            //ApplicationData.Current.RoamingSettings.Values["SF_ApiVersion"] = auth.ApiVersion;
            //Label_Status.Text = "Login Success";

        }
        public void RunSample_continue()
        {
            if (auth.ApiVersion == null || auth.InstanceUrl == null || auth.AccessToken == null) return; //if credintials not satisfied Exit here
            //var client = new ForceClient(auth.InstanceUrl, auth.AccessToken, auth.ApiVersion);
            //var results = await client.QueryAsync<Contact>("SELECT id, AccountId, Salutation, FirstName, LastName, description, Phone FROM Contact");

            //var app = App.Current.Properties;
            Asyncrun = 1;
            RunSampleSucess = true;
            SetLogout();
            Application.Current.Properties["SFToken"] = loginattributs._token;
            if (Properties.Settings.Default.SFToken != (string)Application.Current.Properties["SFToken"])
            {
                Properties.Settings.Default.SFToken = (string)Application.Current.Properties["SFToken"];
            }
            Application.Current.Properties["SFUsername"] = loginattributs._username;
            if (Properties.Settings.Default.SFUsername != (string)Application.Current.Properties["SFUsername"])
            {
                Properties.Settings.Default.SFUsername = (string)Application.Current.Properties["SFUsername"];
            }
            Application.Current.Properties["SFPassword"] = loginattributs._password;
            if (Properties.Settings.Default.SFPassword != (string)Application.Current.Properties["SFPassword"])
            {
                Properties.Settings.Default.SFPassword = (string)Application.Current.Properties["SFPassword"];
            }
            //Properties.Settings.Default.Save();
            Application.Current.Properties["AccessToken"] = auth.AccessToken;
            Application.Current.Properties["InstanceUrl"] = auth.InstanceUrl;
            Application.Current.Properties["SF_ApiVersion"] = auth.ApiVersion;
            int i = 0;
            foreach (Window v in Application.Current.Windows)
            {
                if (v.GetType() == typeof(Login))
                {
                i++;
                if (i == 1)
                {
                    v.Close();
                }
                else
                {
                    v.Hide();
                }
                }
            }
        }

        public static void SetLogout()
        {
            Properties.Settings.Default.LogIn = Asyncrun;
            //Properties.Settings.Default.Save();
        }
    }
#endregion

#region Sqlite Operations
    public class MyDbConnClass
    {
#region DB conection
        private static SQLiteConnection _samplesqliteConn;
        public static string DB_PATH = "Demo.sqlite";
        //private IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        internal void DBConn()
        {
            if (_samplesqliteConn != null)
            {
                _samplesqliteConn.Close();
            }
            _samplesqliteConn = new SQLiteConnection(DB_PATH);
            // Create the table Task, if it doesn't exist.
            _samplesqliteConn.CreateTable<Local_Account>();
            _samplesqliteConn.CreateTable<Local_Contact>();
        }
#endregion

#region Create
        internal int InsertAcc(Local_Account account)
        {
            this.DBConn();
            return _samplesqliteConn.Insert(account);
        }
        internal int Insertcont(Local_Contact contact)
        {
            this.DBConn();
            return _samplesqliteConn.Insert(contact);
        }
#endregion

#region Read
        internal int Fetchsftodb()
        {
            //List<Local_Account> mylist=new List<Local_Account>();
            //Local_Account a = new Local_Account();
            //Local_Contact c = new Local_Contact();

            if (Application.Current.Properties["SFUsername"] == null ||
    Application.Current.Properties["SFPassword"] == null ||
    Application.Current.Properties["SFToken"] == null || Application.Current.Properties["AccessToken"] == null || Application.Current.Properties["InstanceUrl"] == null || Application.Current.Properties["SF_ApiVersion"] == null) return 0;

            if (string.IsNullOrEmpty(Application.Current.Properties["SFUsername"].ToString()) ||
                string.IsNullOrEmpty(Application.Current.Properties["SFPassword"].ToString()) ||
                string.IsNullOrEmpty(Application.Current.Properties["SFToken"].ToString()) ||
                string.IsNullOrEmpty(Application.Current.Properties["AccessToken"].ToString()) ||
                string.IsNullOrEmpty(Application.Current.Properties["InstanceUrl"].ToString()) ||
                string.IsNullOrEmpty(Application.Current.Properties["SF_ApiVersion"].ToString())) return 0;
            FetchAll();
            return 1;
        }
        private async void FetchAll()
        {
            var client = new ForceClient(Application.Current.Properties["InstanceUrl"].ToString(), Application.Current.Properties["AccessToken"].ToString(), Application.Current.Properties["SF_ApiVersion"].ToString());
            List<Account> accounts = (await client.QueryAsync<Account>("SELECT id, name, description, Phone FROM Account")).Records;
            List<Contact> contacts = (await client.QueryAsync<Contact>("SELECT id, AccountId, Salutation, FirstName, LastName, description, Phone FROM Contact")).Records;
            List<Local_Account> localAccounts = new List<Local_Account>();
            List<Local_Contact> localContacts = new List<Local_Contact>();
            DBConn();
            foreach (Account account in accounts)
            {
                localAccounts.Add(new Local_Account(account));
                #region Update
                
                
                //if (account.Id == "00128000008zguZAAQ")
                //{
                //    Account account1=new Account();
                //    account1.Phone = "1";
                //    account1.Name = account.Name;
                //    account1.Description = "asdadsd";
                //    //account1.Id = account.Id;
                //    var a = await client.UpdateAsync("Account", account.Id, account1);
                //}
                #endregion
            }
            foreach (Contact contact in contacts)
            {
                localContacts.Add(new Local_Contact(contact));
            }
            _samplesqliteConn.InsertAll(localAccounts);
            _samplesqliteConn.InsertAll(localContacts);
            MessageBox.Show("Records are transferred successfully");
            //        _samplesqliteConn.InsertAll(new (List<Local_Contact>)(  contacts));
        }

        public Dictionary<string, string> GetLocalTables()
        {
            //DBConn();
            //ArrayList arrayList = new ArrayList();
            //var v = _samplesqliteConn.Query<List<string>>("SELECT name FROM sqlite_master WHERE type = 'table'");
            //List<Dictionary<string, string>> tablelist = new List<Dictionary<string, string>>();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Local_Account", "Account");
            dictionary.Add("Local_Contact", "Contact");
            //tablelist.Add(dictionary);
            return dictionary;
        }
        internal List<Local_Account> GetLocalAccounts()
        {
            DBConn();
            return _samplesqliteConn.Table<Local_Account>().ToList();
        }

        internal List<Local_Contact> GetLocalContacts()
        {
            DBConn();
            return _samplesqliteConn.Table<Local_Contact>().ToList();
        }
#endregion
        #region MyRegion
        //public List<Dictionary<string, string>> GetLocalTables()
        //{
        //   //DBConn();
        //   //ArrayList arrayList = new ArrayList();
        //   //var v = _samplesqliteConn.Query<List<string>>("SELECT name FROM sqlite_master WHERE type = 'table'");
        //   List<Dictionary<string,string>> tablelist=new List<Dictionary<string, string>>();
        //    Dictionary<string,string> dictionary=new Dictionary<string, string>();
        //    dictionary.Add("Local_Account", "Account");
        //   dictionary.Add("Local_Contact", "Contact");
        //    tablelist.Add(dictionary);
        //   return tablelist;
        //}


        //public ArrayList GetTables()
        //{
        //    //_samplesqliteConn = new SQLiteConnection(MyDbConnClass.DB_PATH);
        //ArrayList list = new ArrayList();

        //// executes query that select names of all tables in master table of the database
        //String query = "SELECT name FROM sqlite_master " +
        //        "WHERE type = 'table'" +
        //        "ORDER BY 1";
        //try
        //{

        //    DataTable table = GetDataTable(query);

        //    // Return all table names in the ArrayList

        //    foreach (DataRow row in table.Rows)
        //    {
        //        list.Add(row.ItemArray[0].ToString());
        //    }
        //}
        //catch (Exception e)
        //{
        //    MessageBox.Show(e.Message);
        //}
        //return list;
        //}

        //public DataTable GetDataTable(string sql)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        using (_samplesqliteConn)
        //        {

        //            using (SQLiteCommand cmd = new SQLiteCommand(sql,_samplesqliteConn))
        //            {
        //                using (SQLiteDataReader rdr = cmd.ExecuteReader())
        //                {
        //                    dt.Load(rdr);
        //                    return dt;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return null;
        //    }
        //}

        //private async void Dysplay()
        //{

        //    var client = new ForceClient(Application.Current.Properties["InstanceUrl"].ToString(), Application.Current.Properties["AccessToken"].ToString(), Application.Current.Properties["SF_ApiVersion"].ToString());
        //    List<Account> accounts = (await client.QueryAsync<Account>("SELECT id, name, description, Phone FROM Account")).Records;
        //    List<Contact> contacts = (await client.QueryAsync<Contact>("SELECT id, AccountId, Salutation, FirstName, LastName, description, Phone FROM Contact")).Records;
        //}

        //internal void Insertrec(List<Local_Account> accounts)
        //{
        //    samplesqliteConn = new SQLiteConnection(MyDbConnClass.DB_PATH);
        //    // Create the table Task, if it doesn't exist.
        //    samplesqliteConn.CreateTable<Local_Account>();
        //    int COUNT= samplesqliteConn.Insert(accounts);
        //    if (COUNT == 0)
        //    {
        //        MessageBox.Show("Records are not stored in localDB");
        //    }
        //    else
        //    {
        //        MessageBox.Show(COUNT + " Records are stored in LocalDB");
        //    }
        //    //foreach (Local_Account item in accounts)
        //    //{
        //    //    samplesqliteConn.Insert(item);

        //    //}
        //}
        #endregion

#region Update
        private void UpdateresentAcc(string sfid)
        {
            this.DBConn();
            var v = _samplesqliteConn.Query<Local_Account>("select * from local_account ORDER BY id desc").FirstOrDefault();
            if (v == null)
            {
                MessageBox.Show("No Records in Local Database");
            }
            else
            {
                int id = v.Id;
                var v1 = _samplesqliteConn.Query<Local_Account>("update local_account set sf_id = '" + sfid + "', IsSync=1 where id=" + id).FirstOrDefault();
                _samplesqliteConn.Update(v1);
            }
        }
        private void UpdateresentCont(string sfid)
        {
            this.DBConn();
            var v = _samplesqliteConn.Query<Local_Contact>("select * from Local_Contact ORDER BY id desc").FirstOrDefault();
            if (v == null)
            {
                MessageBox.Show("No Records in Local Database");
                //return 0;
            }
            else
            {
                int id = v.Id;
                var v1 = _samplesqliteConn.Query<Local_Contact>("update Local_Contact set sf_id = '" + sfid + "', IsSync=1 where id=" + id).FirstOrDefault();
                //return 
                _samplesqliteConn.Update(v1);
            }
        }
#endregion

#region Delete
        internal void deletealltabrec()
        {
            _samplesqliteConn = new SQLiteConnection(MyDbConnClass.DB_PATH);
            _samplesqliteConn.DeleteAll<Local_Account>();
            _samplesqliteConn.DeleteAll<Local_Contact>();
            _samplesqliteConn.Close();
        }

        public static int DeleteSingleAccRec(int Id)
        {
            _samplesqliteConn = new SQLiteConnection(MyDbConnClass.DB_PATH);
            var checktable = _samplesqliteConn.Query<Local_Account>("select * from Local_Account where Id=" + Id).FirstOrDefault();
            // Check result is empty or not   
            if (checktable == null)
            {
                MessageBox.Show("Title Not Present in DataBase");
                return 0;
            }
            //Delete row from database   
            return _samplesqliteConn.Delete(checktable); //you can delete single column e.g. dbConn.Delete(tp.Text);   
        }

        public static int DeleteSingleContRec(int Id)
        {
            _samplesqliteConn = new SQLiteConnection(MyDbConnClass.DB_PATH);
            var checktable = _samplesqliteConn.Query<Local_Contact>("select * from Local_Contact where Id=" + Id).FirstOrDefault();
            // Check result is empty or not   
            if (checktable == null)
            {
                MessageBox.Show("Title Not Present in DataBase");
                return 0;
            }
            //Delete row from database   
            return _samplesqliteConn.Delete(checktable); //you can delete single column e.g. dbConn.Delete(tp.Text);   
        }
#endregion
        
    }
#endregion
}
