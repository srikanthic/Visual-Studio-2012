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
//using System.Data.SQLite;
using SQLite;

namespace Local_sqlite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SQLiteConnection _samplesqliteConn;
        public MainWindow()
        {
            InitializeComponent();
            MyDbConnClass DB= new MyDbConnClass();
            _samplesqliteConn = new SQLiteConnection(MyDbConnClass.DB_PATH);
            DB.DBConn();
            Local_Account acc1=new Local_Account(){Description = "asda",IsSync = false,Name = "12313e",Phone = "54564456",SF_Id = "1354ada4"};
            Local_Contact cnt1=new Local_Contact(){Phone = "132141a",IsSync = false,Description = "sad4sa54",SF_Id = "ad54",AccountId = "2221c",FirstName = "33sdas",LastName = "ded",Salutation = "dasdas"};
            
            DB.InsertAcc(acc1);
            DB.Insertcont(cnt1);
            DB.InsertAcc(acc1);
            DB.Insertcont(cnt1);
            DB.InsertAcc(acc1);
            DB.Insertcont(cnt1);
            DB.InsertAcc(acc1);
            DB.Insertcont(cnt1);
            List<Local_Account> accTable = _samplesqliteConn.Table<Local_Account>().ToList();
            List<Local_Contact> cntTable = _samplesqliteConn.Table<Local_Contact>().ToList();
            ListView.ItemsSource = accTable;
            ListView1.ItemsSource = cntTable;
        }
    }
    public sealed class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
    }
    public sealed class Local_Account
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string SF_Id { get; set; }
        public bool IsSync { get; set; }

    }
    public sealed class Contact
    {
        public string Id { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string AccountId { get; set; }
        public string Phone { get; set; }

    }
    public sealed class Local_Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string SF_Id { get; set; }
        public string AccountId { get; set; }
        public bool IsSync { get; set; }
    }
    public class MyDbConnClass
    {
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

        internal async void Fetchsftodb()
        {
            //List<Local_Account> mylist=new List<Local_Account>();
            Local_Account a = new Local_Account();
            Local_Contact c = new Local_Contact();

            
        }

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
        /*
private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
{
var app = (Application.Current as App);

if (app != null)
{
if ((!string.IsNullOrEmpty(app.InstanceUrl)) & (!string.IsNullOrEmpty(app.AccessToken)))
{
  var client = new ForceClient(app.InstanceUrl, app.AccessToken, "v29.0");
  var accounts = await client.QueryAsync<Account>("SELECT id, name, description FROM Account");

  AccountsList.ItemsSource = accounts.records;
}
else
{
  NavigationService.Navigate(new Uri("/LoginPage.xaml", UriKind.Relative));

}
}
}
*/


    }

}
