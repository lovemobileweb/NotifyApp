using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notify.Models
{
    public class ClientUserRoleMappingModule
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> RoleId { get; set; }
    }
}