using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Notify.Controllers
{
    public class ScheduleController : ApiController
    {
        private NotifyContext db = new NotifyContext();
        int clientId = Convert.ToInt32(HttpContext.Current.Session["ClientId"]);
        public IEnumerable<Tbl_NotificationSchedule> GetNotificationSchedule()
        {
            return db.Tbl_NotificationSchedule.AsEnumerable().Where(c=>c.ClientId==clientId);
        }

    }
    //// GET api/Notifications
    //public IEnumerable<Notification> GetNotificationSchedule()
    //{
    //    return db.Tbl_NotificationSchedule.AsEnumerable();
    //}
   

}
