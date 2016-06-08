using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notify.Models
{
    public class ViewLogModel
    {
        public DateTime date { get; set; }
        public string direction { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
        public string status { get; set; }
        public string sidid { get; set; }
        public int segmentnumber { get; set; }
        public string AccountId { get; set; }
    }
}