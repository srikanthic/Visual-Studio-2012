using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace WpfApplication3.Model
{
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
        public Local_Account(Account a)
        {
            Name = a.Name;
            Description = a.Description;
            Phone = a.Phone;
            SF_Id = a.Id;
            IsSync = true;
        }

        public Local_Account()
        {
            
        }
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

        public Local_Contact(Contact c)
        {
            Salutation = c.Salutation;
            FirstName = c.FirstName;
            LastName = c.LastName;
            Description = c.Description;
            Phone = c.Phone;
            SF_Id = c.Id;
            AccountId = c.AccountId;
            IsSync = true;
        }

        public Local_Contact()
        {
            
        }
    }

    public sealed class LoginAttribute
    {
        public string _username { get; set; }
        public string _password { get; set; }

        [System.ComponentModel.DefaultValue("")]   
        public string _token { get; set; }
        [System.ComponentModel.DefaultValue("https://login.salesforce.com/services/oauth2/token")]   
        public string TokenRequestEndPointUrl { get; set; }
        [System.ComponentModel.DefaultValue("3MVG9ZL0ppGP5UrBAr_AfS4s1CMPjDxJsoEVHv46goFLdXXdKK.9X9gJ_9tkebRJLhGK_gZ9r1DAtXoO9JTqO")] 
        public string ClientId { get; set; }
        [System.ComponentModel.DefaultValue("8975182172956404836")] 
        public string ClientSecret { get; set; } 
    }
}
