using Notify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;
using Twilio;
using System.Data.Entity;


namespace Notify.Controllers
{
    public class SendNotificationController : Controller
    {
        NotifyContext dc = new NotifyContext();
        //
        // GET: /SendNotification/

        public ActionResult Create()
        {
            return View();
        }



        //  private NotifyContext db = new NotifyContext();

        // GET: /SendNotification/
        //public IEnumerable<Tbl_NotificationSchedule> GetNotificationSchedule()
        //{
        //    return db.Tbl_NotificationSchedule.AsEnumerable();
        //}

        [HttpPost]
        public ActionResult Create(int[] schedule)
        {
            string AccountSid = "ACadc200cf09ccb955be54787e851f744e";
            string AuthToken = " a87a0a6fd7975e7f54f8e666404cb6cf ";
            TwilioRestClient client = new TwilioRestClient(AccountSid, AuthToken);
            string phonenumber = "+17402003194";


            int clist, contid, Ntid, NsheduleId;
            string Nmsg = string.Empty;
            string chmodel = string.Empty;
            string contname = string.Empty;
            string Contemail = string.Empty;
            string Contphone = string.Empty;
            string Ntempname = string.Empty;
            string NMode = string.Empty;
            string path = string.Empty;



            //List<NotifcationScheduleModel> notifymdl = new List<NotifcationScheduleModel>();
            for (int i = 0; i <= schedule.Length - 1; i++)
            {
                //var statements = dc.Tbl_NotificationSchedule.ToList();
                var n = schedule[i];
                var Nschid = from m in dc.Tbl_NotificationSchedule
                             where m.NScheduleID == n
                             select m;

                foreach (var md in Nschid)
                {
                    clist = Convert.ToInt32(md.ContactListId);
                    Ntid = Convert.ToInt32(md.NotificationId);
                    chmodel = Convert.ToString(md.ChanelMode);
                    NsheduleId = Convert.ToInt32(md.NScheduleID);
                    var ntmsg = from ntm in dc.Notifications where ntm.NotificationId == Ntid select ntm;
                    foreach (var nt in ntmsg)
                    {
                        Nmsg = Convert.ToString(nt.NotificationMessage);
                        Ntempname = Convert.ToString(nt.TemplateName);
                        NMode = Convert.ToString(nt.NotificationType);
                        if (NMode == "Voice Call")
                        {
                            path = HttpContext.Server.MapPath("~/Notify/VoiceXmlTemplate/" + Ntempname + ".xml");
                        }

                    }

                    var contlist = from ct in dc.ContactListDetails where ct.ContactListID == clist select ct;

                    foreach (var cmd in contlist)
                    {
                        contid = Convert.ToInt32(cmd.ContactID);
                        var ca = from cont in dc.Contacts where cont.ContactId == contid select cont;

                        foreach (var ct in ca)
                        {
                            contname = Convert.ToString(ct.FirstName);
                            Contemail = Convert.ToString(ct.Email);
                            Contphone = Convert.ToString(ct.PrimaryPhone);

                            if (chmodel == "SMS")
                            {
                                var msg = client.SendMessage(phonenumber, Contphone, Nmsg);

                            }
                            else if (chmodel == "Voice Call")
                            {
                                var call = client.InitiateOutboundCall(phonenumber, Contphone, path);
                                //  string AccountSid = "ACadc200cf09ccb955be54787e851f744e";
                                //string AuthToken = " a87a0a6fd7975e7f54f8e666404cb6cf ";

                                var twilio = new TwilioRestClient(AccountSid, AuthToken);

                                twilio.HangupCall("CAe1644a7eed5088b159577c5802d8be38", HangupStyle.Completed);

                            }
                            else if (chmodel == "Email")
                            {
                                string st = sendmail(Contemail, contname, Nmsg);
                                if (st == "Success")
                                {
                                    var res = dc.Tbl_NotificationSchedule.Find(NsheduleId);
                                    res.Status = true;
                                    dc.Entry(res).State = EntityState.Modified;
                                    dc.SaveChanges();

                                }
                            }
                        }
                    }

                }
            }
            return View();
        }

        public string sendmail(string Email, string Name, string Message)
        {
            MailMessage mailMsg = new MailMessage();

            // To

            var fromAddress = Email;
            var name = Name;
            if (IsAlphabets(fromAddress) == true)
            {
                mailMsg.To.Add(new MailAddress(fromAddress, name));
            }
            else
            {
                ViewBag.Name = "Please enter correct Insured Name ";

            }
            // From
            mailMsg.From = new MailAddress("acharyatc@gmail.com", "From Tripurari Acharya");


            mailMsg.Subject = "subject";
            string url = Url.Action("receipt123", "Home",
           new System.Web.Routing.RouteValueDictionary(),
              "http", Request.Url.Host);

            string html = Message + url;
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            // Init SmtpClient and send
            SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("CirrusNotification", "N0+ify2016");
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;

            if (IsAlphabets(fromAddress) == true)
            {
                smtpClient.Send(mailMsg);
            }
            dc.SaveChanges();
            return "Success";
        }
        private bool IsAlphabets(string fromAddress)
        {
            Regex r = new Regex(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");

            if (r.IsMatch(fromAddress))
                return true;
            else
                return false;
            throw new NotImplementedException();
        }
    }
}

//http://ahoy.twilio.com/voice/api/demo