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
using Timclock.Control;
using Timclock.Model;

namespace Timclock.View
{
    /// <summary>
    /// Interaction logic for List_of_SF_Records.xaml
    /// </summary>
    public partial class List_of_SF_Records : Window
    {
        //LoginAttribute loginattributs = new LoginAttribute();
        public List_of_SF_Records()
        {
            InitializeComponent();
            if (Application.Current.Properties["SFUsername"] == null ||
    Application.Current.Properties["SFPassword"] == null ||
    (Application.Current.Properties["SFToken"] == null && LoginAttribute.sandbox == false) || Application.Current.Properties["AccessToken"] == null || Application.Current.Properties["InstanceUrl"] == null || Application.Current.Properties["SF_ApiVersion"] == null)
            {
                new Login().Show();
                Hide();
            }
            else if (string.IsNullOrEmpty(Application.Current.Properties["SFUsername"].ToString()) ||
                     string.IsNullOrEmpty(Application.Current.Properties["SFPassword"].ToString()) ||
                     (string.IsNullOrEmpty(Application.Current.Properties["SFToken"].ToString()) && LoginAttribute.sandbox==false)||
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

        private async void Dysplay()
        {
            var client = new ForceClient(Application.Current.Properties["InstanceUrl"].ToString(), Application.Current.Properties["AccessToken"].ToString(), Application.Current.Properties["SF_ApiVersion"].ToString());
            List<Person> persons = (await client.QueryAsync<Person>("select Id,RF_ID__c, HRMSUS__First_Name__c from HRMSUS__Person__c limit 10")).Records;
            string s = "select Id,Associate__c,Punch_In__c, Punch_Out__c,Date__c from Daily_Shift__c where Date__c =" + Cradentials.today + " limit 100";
            List<DailyShift> dailyShifts = (await client.QueryAsync<DailyShift>(s)).Records;
           // List<LoginDetail> loginDetails=new List<LoginDetail>();
        //    List<LoginDetail> loginDetails = (await client.QueryAsync<LoginDetail>("select Id, HRMS__Worker_Id__c,Name,Start_Time__c,End_Time__c, IsUpdated__c,HRMS__In_TIme_1__c,HRMS__Out_TIme_2__c ,BreakIn1__c ,BreakOut1__c,LunchIn__c,LunchOut__c,BreakIn2__c,BreakOut2__c , HRMS__Date__c   from HRMSUS__Login_Details__r limit 100")).Records;
           //var loginDetails = (await client.QueryAsync<LoginDetail>("select Id from Daily_Shift__c limit 100")).Records;
            ListView.ItemsSource = persons;
            ListView1.ItemsSource = dailyShifts;
          //string s = DateTime.Now.ToString("MM/dd/yyyy h:mm tt", CultureInfo.CreateSpecificCulture("en-US"));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new Operations().Show();
            Hide();
        }
    }
}
