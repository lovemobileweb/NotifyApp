using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notify.Models
{
    public class UserModule
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string EmailId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public string RoleName { get; set; }
        public int clientId { get; set; }
        public string Clientusername { get; set; }
        public string ClientName { get; set; }
       
    }
}