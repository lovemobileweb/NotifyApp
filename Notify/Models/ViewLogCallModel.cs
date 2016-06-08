using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notify.Models
{
    public class ViewLogCallModel
    {
        public string AccountId { get; set; }
        public string CallerName { get; set; }
        public DateTime DateCreated { get; set; }
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PhoneNumberSidId { get; set; }
        public string SidId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Satus { get; set; }
    }
}