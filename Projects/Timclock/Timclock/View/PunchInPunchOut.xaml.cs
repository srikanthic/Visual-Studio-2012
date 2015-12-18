using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//using Salesforce.Force;
using Timclock.Control;
using Timclock.Model;

namespace Timclock.View
{
    /// <summary>
    /// Interaction logic for PunchInPunchOut.xaml
    /// </summary>
    public partial class PunchInPunchOut : Window
    {
        private Timeclock _timeclock;
        private string SFID;
        MyDbConnClass _myDbConnClass= new MyDbConnClass();
        
        //Cradentials Cradentials=new Cradentials();
        public PunchInPunchOut()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                Height = SystemParameters.PrimaryScreenWidth/2.5;
                Width = SystemParameters.PrimaryScreenHeight/1.8;
            }
            //MessageBox.Show("Height"+Height+" Width "+Width);
            MessageBox.Show("Invalide Entry");
            this.Close();
        }

        public PunchInPunchOut(string SFID)
        {
            this.SFID = SFID;
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                Height = SystemParameters.PrimaryScreenWidth / 2.5;
                Width = SystemParameters.PrimaryScreenHeight / 1.8;
            }
            InitializeComponent();
            Name.Text = "";
            Badge.Text = "";
            if (string.IsNullOrEmpty(this.SFID))
            {
                MessageBox.Show("Invalide Employee");
            }
            else
            {
                //_myDbConnClass.DBConn();
                List<Local_Person> localPerson = new List<Local_Person>();
                //MessageBox.Show("No Record With this RFID");
                localPerson = _myDbConnClass.GetLocalPerson(new string[] { SFID});
               // MessageBox.Show("No Record With this RFID");
                if (localPerson != null)
                {
                    foreach (Local_Person person in localPerson)
                    {
                        if (person.SF_Id == SFID)
                        {
                            Name.Text = person.FirstName;
                            Badge.Text = person.RFId;
                        }
                    }
                }
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.SFID))
            {
                MessageBox.Show("Invalide Employee");
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-us");
                string DateTime = System.DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                int result = _myDbConnClass.UpdateDailyShift(new KeyValuePair<string, string>("Punch_In__c",DateTime),SFID);
                if (result > 0)
                {
                    //Close();
                    MessageBox.Show("Your Punch_In succeed");
                    #region SFTEST
                    ////List<DailyShift> dailyShifts = _myDbConnClass.Getonerecord("DailyShift", "Associate__c", SFID).Result;
                    //List<DailyShift> dailyShifts = _myDbConnClass.Getonerecord_dailyShifts("Associate__c", SFID).Result;
                    //if (dailyShifts != null)
                    //{
                    //    foreach (DailyShift dailyShift1 in dailyShifts)
                    //    {
                    //        if (dailyShift1 != null)
                    //        {
                    //            Associate__c.Text = dailyShift1.Associate__c;
                    //            Punch_In__c.Text = dailyShift1.Punch_In__c;
                    //            Punch_Out__c.Text = dailyShift1.Punch_Out__c;
                    //            Date__c.Text = dailyShift1.Date__c;
                    //        }
                    //    }
                    //}
                    #endregion
                }
                else
                {
                    MessageBox.Show("Punch_In Fail");
                }

            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-us");
            string DateTime = System.DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            int result = _myDbConnClass.UpdateDailyShift(new KeyValuePair<string, string>("Punch_Out__c", DateTime), SFID);
            if (result > 0)
            {
                
                MessageBox.Show("Your Punch_Out succeed");
            }
            else
            {
                MessageBox.Show("Punch_Out Fail");
            }
        }
        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Cradentials.OpenHiddenWindowCheack(new Timeclock());
            _timeclock = null;
            _timeclock=new Timeclock();
            _timeclock.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(WindowState == WindowState.Normal)
            {
               WindowState=WindowState.Maximized;
            }
        else
            {
                WindowState=WindowState.Normal;
            }
        }

        private void PunchInPunchOut_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
