using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Timclock.Model
{
    public sealed class LoginAttribute
    {
        public string _username { get; set; }
        public string _password { get; set; }
        public static bool sandbox = Properties.Settings.Default.Sandbox;
        [System.ComponentModel.DefaultValue("")]
        public string _token { get; set; }
        [System.ComponentModel.DefaultValue("https://test.salesforce.com/services/oauth2/token")]              //login.salesforce.com/services/oauth2/token
        public string TokenRequestEndPointUrl { get; set; }
        [System.ComponentModel.DefaultValue("3MVG9MHOv_bskkhSDUYQKfusFVb7Sm8F.e8rmby7OEuUQpHSf9w3pyoHssPEJVmblbXqVbTGhsUgNv8s8XgQv")] //For demo(3MVG9ZL0ppGP5UrBAr_AfS4s1CMPjDxJsoEVHv46goFLdXXdKK.9X9gJ_9tkebRJLhGK_gZ9r1DAtXoO9JTqO)
        public string ClientId { get; set; }
        [System.ComponentModel.DefaultValue("8538928391097187856")]     //For demo (8975182172956404836)
        public string ClientSecret { get; set; }
    }
    public sealed class Person
    {
        public string Id { get; set; }
        public string RF_ID__c { get; set; }
        public string HRMSUS__First_Name__c { get; set; }
    }
    public sealed class Local_Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string RFId { get; set; }
        public string FirstName { get; set; }
        public string SF_Id { get; set; }
        public bool IsSync { get; set; }
        public Local_Person(Person a)
        {
            RFId = a.RF_ID__c;
            FirstName = a.HRMSUS__First_Name__c;
            SF_Id = a.Id;
            IsSync = false;
        }

        public Local_Person()
        {

        }
    }

    public sealed class DailyShift
    {   
        public string Id { get; set; }
        public string Associate__c { get; set; }
        public string Punch_In__c { get; set; }
        public string Punch_Out__c { get; set; }
        public string Date__c { get; set; }
    }
    public sealed class DailyShift1
    {
        public string Id { get; set; }
        public string Associate__c { get; set; }
        public DateTime? Punch_In__c { get; set; }
        public DateTime? Punch_Out__c { get; set; }
        public string Date__c { get; set; }
    }
    //public sealed class GetUseful
    //{
    //    public static string s = (DateTime.Now).ToString("g");
    //}

    public sealed class Local_DailyShift
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SF_Id { get; set; } //SF DailyShift ID
        public string Associate__c { get; set; } //SF Worker ID
        public string Punch_In__c { get; set; } //SF record
        public string Punch_Out__c { get; set; }    //SF recor
        public string Date__c { get; set; } //SF Date
        public string DateCreated { get; set; } //local date created
        //public string DateCreated = (DateTime.Now).ToString("g"); //local date created
        public bool IsSync { get; set; }        //For localy chech sync or not
        public string DateModified { get; set; } 
        public Local_DailyShift(DailyShift a)
        {
            //DateTime DT = DateTime.Now;
            //string s= String.Format("{0:d/M/yyyy HH:mm:ss}", DT);
            //s = DT.ToString("g");
            Associate__c = a.Associate__c;
            Punch_In__c = a.Punch_In__c;
            Punch_Out__c = a.Punch_Out__c;
            SF_Id = a.Id;
            Date__c = a.Date__c;
            DateCreated = DateTime.Now.ToString("yyyy-MM-dd"); //(DateTime.Now).ToString("g"); 
            IsSync = false;
        }
        public Local_DailyShift()
        {
          //DateCreated=(DateTime.Now).ToString("g");
        }
    }
    public sealed class LoginDetail
    {
        public string Id { get; set; }
        public string WorkerId { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string IsUpdated { get; set; }
        public string InTIme1 { get; set; }
        public string Out_TIme_2 { get; set; }
        public string BreakIn1 { get; set; }
        public string BreakOut1 { get; set; }
        public string LunchIn { get; set; }
        public string LunchOut { get; set; }
        public string BreakIn2 { get; set; }
        public string BreakOut2 { get; set; }
        public string Date { get; set; }
    }
    public sealed class Local_LoginDetail
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string WorkerId { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string IsUpdated { get; set; }
        public string InTIme1 { get; set; }
        public string Out_TIme_2 { get; set; }
        public string BreakIn1 { get; set; }
        public string BreakOut1 { get; set; }
        public string LunchIn { get; set; }
        public string LunchOut { get; set; }
        public string BreakIn2 { get; set; }
        public string BreakOut2 { get; set; }
        public string Date { get; set; }
        public string SF_Id { get; set; }
        public bool IsSync { get; set; }

        public Local_LoginDetail(LoginDetail c)
        {
            WorkerId = c.WorkerId;
            Name = c.Name;
            StartTime = c.StartTime;
            EndTime = c.EndTime;
            IsUpdated = c.IsUpdated;
            InTIme1 = c.InTIme1;
            Out_TIme_2 = c.Out_TIme_2;
            BreakIn1 = c.BreakIn1;
            BreakOut1 = c.BreakOut1;
            LunchIn = c.LunchIn;
            LunchOut = c.LunchOut;
            BreakIn2 = c.BreakIn2;
            BreakOut2 = c.BreakOut2;
            Date = c.Date;
            SF_Id = c.Id;
            IsSync = false;
        }

        public Local_LoginDetail()
        {

        }
    }
}
