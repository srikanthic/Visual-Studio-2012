#region Using
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using Salesforce.Common;
using Salesforce.Force;
using SQLite;
using Timclock.Model;
#endregion
namespace Timclock.Control
{
    #region SF Toolkit operation
    class Cradentials 
    {
        #region Credentials
        LoginAttribute loginattributs = new LoginAttribute();
        public static int Logintrys = 0;
        public static bool RunSampleSucess { get; set; }
        public static int Asyncrun { get; set; } //0 for default, 1 for asnyc  done 2 for async fail
        AuthenticationClient auth = new Salesforce.Common.AuthenticationClient();
        public static string today = DateTime.Now.ToString("yyyy-MM-dd");//"2015-08-04";//DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd");
        public static bool IsConnectedToInternet;
        #endregion
        #region Login
        public LoginAttribute Login()
        {
                RunSampleSucess = false;
                loginattributs._username = Properties.Settings.Default.SFUsername;
                loginattributs._password = Properties.Settings.Default.SFPassword;
                loginattributs._token = Properties.Settings.Default.SFToken;
                loginattributs.ClientId = Properties.Settings.Default.ClientId;
                loginattributs.ClientSecret = Properties.Settings.Default.ClientSecret;
                loginattributs.TokenRequestEndPointUrl = Properties.Settings.Default.TokenRequestEndPointUrl;
            try
            {
                
                if (string.IsNullOrEmpty(loginattributs.ClientId))
                {
                    loginattributs.ClientId = "3MVG9MHOv_bskkhSDUYQKfusFVb7Sm8F.e8rmby7OEuUQpHSf9w3pyoHssPEJVmblbXqVbTGhsUgNv8s8XgQv";
                }
                if (string.IsNullOrEmpty(loginattributs.ClientSecret))
                {
                    loginattributs.ClientSecret = "8538928391097187856";
                }
                if (LoginAttribute.sandbox)
                {
                    if (Application.Current.Properties["SFUsername"] == null || Application.Current.Properties["SFPassword"] == null) return loginattributs;
                    if (string.IsNullOrEmpty(Application.Current.Properties["SFUsername"].ToString()) || string.IsNullOrEmpty(Application.Current.Properties["SFPassword"].ToString())) return loginattributs;
                }
                else
                {
                    if (Application.Current.Properties["SFUsername"] == null || Application.Current.Properties["SFPassword"] == null || Application.Current.Properties["SFToken"] == null) return loginattributs;
                    if (string.IsNullOrEmpty(Application.Current.Properties["SFUsername"].ToString()) || string.IsNullOrEmpty(Application.Current.Properties["SFPassword"].ToString()) || string.IsNullOrEmpty(Application.Current.Properties["SFToken"].ToString())) return loginattributs;
                }

                loginattributs._username = Application.Current.Properties["SFUsername"].ToString();
                loginattributs._password = Application.Current.Properties["SFPassword"].ToString();
                loginattributs._token = Application.Current.Properties["SFToken"].ToString();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return loginattributs;
        }

        public void RunSample(LoginAttribute loginAttribute)
        {
            loginattributs = loginAttribute; //assign credentials
            RunSample();

        }

        //Try to login Salesforce using credentials
        public async void RunSample()
        {
            try
            {
                //List<Contact> myClasses = new List<Contact>();
                Asyncrun = 0;
                Logintrys++;
                RunSampleSucess = false;
                //await auth.UsernamePasswordAsync(loginattributs.ClientId, loginattributs.ClientSecret, loginattributs._username, loginattributs._password + loginattributs._token);   //Normal Login
                await auth.UsernamePasswordAsync(loginattributs.ClientId, loginattributs.ClientSecret, loginattributs._username, loginattributs._password + loginattributs._token, "https://test.salesforce.com/services/oauth2/token");     //Sandbox Login
                //while (Asyncrun>0)
                //{
                RunSample_continue();
                // }
            }
            catch (Exception e)
            {
                App.TryForLogin = false;
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
           // var client = new ForceClient(auth.InstanceUrl, auth.AccessToken, auth.ApiVersion);
           // var results = await client.QueryAsync<dynamic>("select Id from HRMSUS__Person__c limit 10");

            //var app = App.Current.Properties;
            App.TryForLogin = true;
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
            if (Timclock.Login.LoginCount >0)
            {
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
            if (App.fetchRec)
            {
                MyDbConnClass MyDbConnClass = new MyDbConnClass();
                MyDbConnClass.Fetchsftodb();
                App.fetchRec = false;
            }
            Logintrys = 0;
        }
        #endregion
        #region Crude Operations
        
        #endregion
        
        #region Logout
        public static void SetLogout()
        {
            Properties.Settings.Default.LogIn = Asyncrun;
            //Properties.Settings.Default.Save();
        }
        #endregion
    }
    #endregion

    class ApplicationOperations:Window
    {
        public static bool OpenHiddenWindowCheack(object o)
        {
            int i = 0;
            foreach (Window v in Application.Current.Windows)
            {
                if (v.GetType() == o.GetType())
                {
                    i++;

                    if (i == 1 && v.GetType() != typeof(Operations))
                    {
                        v.Close();
                    }
                    else
                    {
                        v.Hide();
                    }
                }
                //if (v.GetType() == o.GetType())
                //{
                //    v.Show();
                //    //if (v.GetType() == typeof (Timeclock))
                //    //{
                //    //    if (Timeclock.closing_window > 1)
                //    //    {
                //    //        v.Hide();
                //    //    }
                //    //}
                //    return true;
                //}

            }
            //if (o.GetType()==typeof(Timeclock))
            //{
            //    //MessageBox.Show(o.GetType().ToString());
            //}
            return false;
        }
    }

    #region Sqlite Operations
    public class MyDbConnClass
    {        
        private readonly string _today = Cradentials.today;//DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd");
        #region DB conection
        private static SQLiteConnection _samplesqliteConn;
        public static string DB_PATH = "TC.sqlite";
        //private DailyShift DailyShift;
        private DailyShift1 _dailyShift1;
        //private IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        internal void DBConn()
        {
            if (_samplesqliteConn != null)
            {
                _samplesqliteConn.Close();
            }
            _samplesqliteConn = new SQLiteConnection(DB_PATH);
            // Create the table Task, if it doesn't exist.
            _samplesqliteConn.CreateTable<Local_Person>();
            _samplesqliteConn.CreateTable<Local_LoginDetail>();
            _samplesqliteConn.CreateTable<Local_DailyShift>();
        }
        #endregion

        #region Create
        internal int Insert_rec_sqlite(Local_Person person)
        {
            this.DBConn();
            return _samplesqliteConn.Insert(person);
        }
        internal int Insert_rec_sqlite(Local_LoginDetail loginDetail)
        {
            this.DBConn();
            return _samplesqliteConn.Insert(loginDetail);
        }
        internal int Insert_rec_sqlite(Local_DailyShift localDailyShift)
        {
            this.DBConn();
            return _samplesqliteConn.Insert(localDailyShift);
        }
        #endregion

        #region Read
        internal bool CheckCredentials()
        {
            if (Application.Current.Properties["SFUsername"] == null ||
    Application.Current.Properties["SFPassword"] == null ||
    Application.Current.Properties["SFToken"] == null || Application.Current.Properties["AccessToken"] == null || Application.Current.Properties["InstanceUrl"] == null || Application.Current.Properties["SF_ApiVersion"] == null) return false;

            if (string.IsNullOrEmpty(Application.Current.Properties["SFUsername"].ToString()) ||
                string.IsNullOrEmpty(Application.Current.Properties["SFPassword"].ToString()) ||
                (string.IsNullOrEmpty(Application.Current.Properties["SFToken"].ToString()) && !LoginAttribute.sandbox) ||
                string.IsNullOrEmpty(Application.Current.Properties["AccessToken"].ToString()) ||
                string.IsNullOrEmpty(Application.Current.Properties["InstanceUrl"].ToString()) ||
                string.IsNullOrEmpty(Application.Current.Properties["SF_ApiVersion"].ToString())) return false;
            return true;
        }

        internal bool Fetchsftodb()
        {
            //List<Local_Account> mylist=new List<Local_Account>();
            //Local_Account a = new Local_Account();
            //Local_Contact c = new Local_Contact();
            if (!CheckCredentials())
            {
                return false;
            }
            else
            {
                FetchAll();
                return true;
            }
        }

        private async void FetchAll()
        {
            var client = new ForceClient(Application.Current.Properties["InstanceUrl"].ToString(),
                Application.Current.Properties["AccessToken"].ToString(),
                Application.Current.Properties["SF_ApiVersion"].ToString());
            //var persons = await client.QueryAsync<Person>("select Id,RF_Id__c, HRMS__First_Name__c from HRMS__Person__c");
            List<Person> persons =
                (await client.QueryAsync<Person>("select Id,RF_Id__c, HRMSUS__First_Name__c from HRMSUS__Person__c where RF_Id__c like '________'"))
                    .Records;
            string s = "select Id,Associate__c,Punch_In__c, Punch_Out__c,Date__c from Daily_Shift__c where Date__c =" + _today;
            //string s = "select Id,Associate__c,Punch_In__c, Punch_Out__c,Date__c from Daily_Shift__c where Date__c>" + DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd") + " and Associate__c ='a12L0000000m8oaIAA' ORDER BY Date__c DESC limit 100";
            List<DailyShift> dailyShifts = (await client.QueryAsync<DailyShift>(s)).Records;
            //var a = DateTime.Today;
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-us");
            //List<DailyShift> dailyShifts = (await client.QueryAsync<DailyShift>("select Id,Punch_In__c, Punch_Out__c,Date__c from Daily_Shift__c where Date__c > " + DateTime.Now.ToString("d") + " limit 10")).Records;
           // List<DailyShift> dailyShifts = (await client.QueryAsync<DailyShift>("select Id,Punch_In__c, Punch_Out__c,Date__c from Daily_Shift__c limit 10")).Records;
                //(await client.QueryAsync<LoginDetail>("select Id, HRMS__Worker_Id__c,Name,Start_Time__c,End_Time__c, IsUpdated__c,HRMS__In_TIme_1__c,HRMS__Out_TIme_2__c ,BreakIn1__c ,BreakOut1__c,LunchIn__c,LunchOut__c,BreakIn2__c,BreakOut2__c , HRMS__Date__c   from HRMS__Login_Details__r")).Records;
            List<Local_Person> localPersons = new List<Local_Person>();
            //List<Local_LoginDetail> localLoginDetails = new List<Local_LoginDetail>();
            List<Local_DailyShift> localDailyShifts = new List<Local_DailyShift>(); 
            DBConn();
            foreach (Person person in persons)
            {
                localPersons.Add(new Local_Person(person));
            }

            //if (loginDetails != null)
            //{
            //    foreach (LoginDetail loginDetail in loginDetails)
            //    {
            //        localLoginDetails.Add(new Local_LoginDetail(loginDetail));
            //    }
            //}
            
                foreach (DailyShift dailyShift in dailyShifts)
                {
                    localDailyShifts.Add(new Local_DailyShift(dailyShift));
                }
           

        _samplesqliteConn.InsertAll(localPersons);
        //_samplesqliteConn.InsertAll(localLoginDetails);
        _samplesqliteConn.InsertAll(localDailyShifts);
        App.fetchRec = false;
        MessageBox.Show("Records are transferred successfully");
            //        _samplesqliteConn.InsertAll(new (List<Local_Contact>)(  contacts));
        }

        //public async Task<List<DailyShift>> Getonerecord_dailyShifts(string searchfield, string searchItem)
        //{
        //    var client = new ForceClient(Application.Current.Properties["InstanceUrl"].ToString(),
        //        Application.Current.Properties["AccessToken"].ToString(),
        //        Application.Current.Properties["SF_ApiVersion"].ToString());
        //    string s = "select Id,Associate__c,Punch_In__c, Punch_Out__c,Date__c from Daily_Shift__c where Date__c =" + _today + " and " + searchfield + " = '" + searchItem + "'";
        //        List<DailyShift> dailyShifts = (await client.QueryAsync<DailyShift>(s)).Records;
        //        return dailyShifts;
        //}

        //public async Task<dynamic> Getonerecord(string Classtype, string searchfield, string searchItem)
        //{
        //    string sftable="";
        //    var client = new ForceClient(Application.Current.Properties["InstanceUrl"].ToString(),
        //        Application.Current.Properties["AccessToken"].ToString(),
        //        Application.Current.Properties["SF_ApiVersion"].ToString());
        //    if (Classtype == "DailyShift")
        //    {
        //        sftable = "Daily_Shift__c";
        //        string s = "select Id,Associate__c,Punch_In__c, Punch_Out__c,Date__c from " + sftable + " where Date__c =" + _today + " and " + searchfield + " = '" + searchItem + "'";
        //        List<DailyShift> dailyShifts = (await client.QueryAsync<DailyShift>(s)).Records;
        //        return dailyShifts;
        //    }
        //    else if (Classtype == "LoginDetail")
        //    {
        //        sftable = "HRMSUS__Person__c";
        //        string s = "select Id,Associate__c,Punch_In__c, Punch_Out__c,Date__c from " + sftable + " where Date__c =" + _today + " and " + searchfield + " = '" + searchItem + "'";
        //        List<LoginDetail> loginDetails = (await client.QueryAsync<LoginDetail>(s)).Records;
        //        return loginDetails;
        //    }
        //    return null;
        //}

        public Dictionary<string, string> GetLocalTables()
        {
            //DBConn();
            //ArrayList arrayList = new ArrayList();
            //var v = _samplesqliteConn.Query<List<string>>("SELECT name FROM sqlite_master WHERE type = 'table'");
            //List<Dictionary<string, string>> tablelist = new List<Dictionary<string, string>>();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Local_Person", "Person");
           // dictionary.Add("Local_LoginDetail", "LoginDetail");
            dictionary.Add("Local_DailyShift", "DailyShift");
            //tablelist.Add(dictionary);
            return dictionary;
        }
        internal List<Local_Person> GetLocalPersons()
        {
            DBConn();
            return _samplesqliteConn.Table<Local_Person>().ToList();
        }
        internal List<Local_Person> GetLocalPerson(string[] SFID)
        {
            DBConn();
            if (!string.IsNullOrEmpty(SFID[0]))
            {
                string sfid = string.Join("','", SFID);
                string selectQuery = "select * from Local_Person where SF_Id in ('" + sfid + "')";
               var v = _samplesqliteConn.Query<Local_Person>(selectQuery);
                    if (v != null)
                    {

                        return v;
                    }
             }
            return null;
        }
        internal List<Local_LoginDetail> GetLocalLoginDetails()
        {
            DBConn();
            return _samplesqliteConn.Table<Local_LoginDetail>().ToList();
        }
        internal List<Local_DailyShift> GetLocalDailyShifts()
        {
            DBConn();
            return _samplesqliteConn.Table<Local_DailyShift>().ToList();
        }
        internal List<Local_DailyShift> GetLocalDailyShift(string[] SFID)
        {
            DBConn();
            if (!string.IsNullOrEmpty(SFID[0]))
            {
                string sfid = string.Join("','", SFID);
                string selectQuery = "select * from Local_DailyShift where SF_Id in ('" + sfid + "')";
                var v = _samplesqliteConn.Query<Local_DailyShift>(selectQuery);
                if (v != null)
                {

                    return v;
                }
            }
            return null;
        }

        #region Search
        public string SearchQuery(string Classtype, string searchfield, string SearchString)
        {
            
            DBConn();
            if (!string.IsNullOrEmpty(SearchString))
            {
                //bool b = false;
                string selectQuery = "select SF_Id from " + Classtype + " where " + searchfield + "='" + SearchString + "'  ORDER BY id desc";
                if (Classtype == "Local_Person")
                {
                    var v = _samplesqliteConn.Query<Local_Person>(selectQuery).FirstOrDefault();
                    if (v != null)
                    {
                        //b = true;
                        return v.SF_Id;
                    }
                }
                else if (Classtype == "Local_DailyShift")
                {
                    var v = _samplesqliteConn.Query<Local_DailyShift>(selectQuery).FirstOrDefault();

                    if (v != null)
                    {
                       // b = true;
                        return v.SF_Id;
                    }
                }
            }
            return "";
            #region MyRegion


            //Type.GetType(type.Name) ;

            //Type type1 = Type.GetType(type.Name); //target type
            //object o = Activator.CreateInstance(type1); // an instance of target type

            //if (Type.GetType(type.Name) == Local_Person)
            //{
            //    t = typeof(Local_Person);
            //}
            //DBConn();
            //Local_Person localPerson= new Local_Person();
            //var v = _samplesqliteConn.Query <Type.GetType("localPerson") > ("select * from " + Type.GetType(type.Name) + " where" + searchfield + "=" + SearchString + "  ORDER BY id desc").FirstOrDefault();
            //if (v == null)
            //{
            //    MessageBox.Show("No Records in Local Database");
            //}
            //else
            //{
            //    int id = v.Id;
            //    var v1 = _samplesqliteConn.Query<Local_Account>("update local_account set sf_id = '" + sfid + "', IsSync=1 where id=" + id).FirstOrDefault();
            //    _samplesqliteConn.Update(v1);
            //}
            #endregion
        }
        public dynamic SearchQuery(string Classtype, string searchfield, int searchItem)
        {
            DBConn();

            string selectQuery = "select * from " + Classtype + " where " + searchfield + "=" + searchItem;
                if (Classtype == "Local_Person")
                {
                    var v = _samplesqliteConn.Query<Local_Person>(selectQuery);
                    return v;
                }
                else if (Classtype == "Local_DailyShift")
                {
                    var v = _samplesqliteConn.Query<Local_DailyShift>(selectQuery);

                    return v;
                }
            return null;
        }
        #endregion  
        #endregion

        #region Update Local
        public int UpdateDailyShift(KeyValuePair<string, string> keyValuePair,string SFID)
        {
            if (keyValuePair.Key != null)
            {
                string s = "";
                //MessageBox.Show(s);
                if (keyValuePair.Key == "IsSync")
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-us");
                string DateTime = System.DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                s = "update Local_DailyShift set DateModified " + "='" + DateTime + "', IsSync=0 where Associate__c='" + SFID + "' and Date__c ='" + _today + "';";
                }
                else
                {
                    s = "update Local_DailyShift set " + keyValuePair.Key + "='" + keyValuePair.Value + "',  DateModified " + "='" + keyValuePair.Value + "', IsSync=1 where Associate__c='" + SFID + "' and Date__c ='" + _today + "';";
                 //   s = "update Local_DailyShift set IsSync=1";
                }
                //MessageBox.Show(s);
                DBConn();
                int v = _samplesqliteConn.Execute(s);
                MessageBox.Show(v.ToString());
                return v;
            }
            //MessageBox.Show("keyvalueempty");
            return 0;
        }
      
        #endregion

        #region Update Sf
        internal bool SyncLocalToSF(List<Local_DailyShift> syncRecrds)
        {
            //List<Local_Account> mylist=new List<Local_Account>();
            //Local_Account a = new Local_Account();
            //Local_Contact c = new Local_Contact();
             //if (!CheckCredentials())
             //{
             //    return false;
             //}
            foreach (Local_DailyShift localDailyShift in syncRecrds)
            {
                UpdateDailyShiftToSF(localDailyShift);
            }
            //UpdateDailyShiftToSF(syncRecrds);
             return true;
        }


        private async void  UpdateDailyShiftToSF(Local_DailyShift localDailyShift)
        {
            var client = new ForceClient(Application.Current.Properties["InstanceUrl"].ToString(),
                Application.Current.Properties["AccessToken"].ToString(),
                Application.Current.Properties["SF_ApiVersion"].ToString());

            _dailyShift1 = new DailyShift1();
            //DailyShift.Id = localDailyShift.SF_Id;
            //DailyShift.Associate__c = localDailyShift.Associate__c;
            //DailyShift.Date__c = localDailyShift.Date__c;
            //DailyShift.Punch_In__c = localDailyShift.Punch_In__c;
            //DailyShift.Punch_Out__c = localDailyShift.Punch_Out__c;
            _dailyShift1.Punch_In__c=DateTime.Parse(localDailyShift.Punch_In__c);
            //_dailyShift1.Punch_In__c = DateTime.Now;
            if (!string.IsNullOrEmpty(localDailyShift.Punch_Out__c))    _dailyShift1.Punch_Out__c = DateTime.Parse(localDailyShift.Punch_Out__c);
            _dailyShift1.Associate__c = localDailyShift.Associate__c;
            var success = await client.UpdateAsync("Daily_Shift__c", localDailyShift.SF_Id, _dailyShift1);
            if (success.Success == "true")
            {
                UpdateDailyShift(new KeyValuePair<string, string>("IsSync", "False"), localDailyShift.Associate__c);
            }
        }

        #endregion

        #region Delete
        internal void DeleteallLclRec()
        {
            
            try
            {
            _samplesqliteConn = new SQLiteConnection(DB_PATH);
            _samplesqliteConn.DeleteAll<Local_Person>();
            _samplesqliteConn.DeleteAll<Local_LoginDetail>();
            _samplesqliteConn.DeleteAll<Local_DailyShift>();
            _samplesqliteConn.Close();
                MessageBox.Show("Cleared Succesfully");
            }
            catch (Exception e)
            {

                MessageBox.Show("Recors are no cleard Because of ==> "+e.Message);
            }
           
            
        }

  /*      public static int DeleteSingleAccRec(int Id)
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
   */
        #endregion

        //#region InternetGetConnectedState
        //[DllImport("wininet.dll")]
        //private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        //public static bool IsConnectedToInternet()
        //{
        //    int desc;
        //    return InternetGetConnectedState(out desc, 0);
        //}
        //#endregion
        
    }
    #endregion
}
