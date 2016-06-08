﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Notify
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NotifyContext : DbContext
    {
        public NotifyContext()
            : base("name=NotifyContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ContactListDetail> ContactListDetails { get; set; }
        public virtual DbSet<ContactListMaster> ContactListMasters { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<NotificationLog> NotificationLogs { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tbl_NotificationSchedule> Tbl_NotificationSchedule { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserClientRoleMapping> UserClientRoleMappings { get; set; }
    
        public virtual ObjectResult<GetVoiceTemplate_Result> GetVoiceTemplate(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetVoiceTemplate_Result>("GetVoiceTemplate", idParameter);
        }
    }
}
