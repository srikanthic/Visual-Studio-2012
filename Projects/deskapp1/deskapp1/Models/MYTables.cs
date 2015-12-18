using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deskapp1.Models
{
    class MYTables
    {
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
//        [PrimaryKey, AutoIncrement]
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
//        [PrimaryKey, AutoIncrement]
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
}
