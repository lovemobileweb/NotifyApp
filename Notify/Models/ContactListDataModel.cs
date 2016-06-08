using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notify.Models
{
    public class ContactListDataModel
    {
        public int ListDetailID { get; set; }
        public Nullable<int> ContactListID { get; set; }
        public Nullable<int> ContactID { get; set; }
        public string ContactListname { get; set; }
        public string CellPhone { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string IsActive { get; set; }
        public string LastName { get; set; }        
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
    }
}