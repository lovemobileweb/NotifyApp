using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notify.Models
{
    public class NotifcationScheduleModel
    {
        public int NScheduleID { get; set; }
        public string NotificationCampaign { get; set; }
        public Nullable<int> ContactListId { get; set; }
        public Nullable<int> ResourceId { get; set; }
        public Nullable<int> NotificationId { get; set; }
        public Nullable<int> NotificationSmsId { get; set; }
        public Nullable<int> NotificationVoiceId { get; set; }
        public Nullable<System.DateTime> CampaignDate { get; set; }
        public string ChanelMode { get; set; }
        public string ChanelsmsMode { get; set; }       
        public string ChanelvoiceMode { get; set; }
        public string NotificationMessage { get; set; }
        public string RequestConfirmMsg { get; set; }
        public string RepeatNotificationAllow { get; set; }
        public Nullable<int> MsgNumberOfTime { get; set; }
        public Nullable<System.DateTime> ReapeatDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> IsActive { get; set; }
        
    }
}