using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Notify.Models;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;
using Twilio;
using AutoMapper;
using System.Web.Providers.Entities;


namespace Notify.Controllers
{
    public class HomeController : Controller
    {
        int ClientId = 0;
        int ClientAdminId = 0;
        NotifyContext dc = new NotifyContext();

        public ActionResult Index()
        {
            if (Session["Role"] != null)
            {
                string role = Session["Role"].ToString();
                //int ClientId = 0;
                //if (role == Convert.ToString("Admin"))
                //{
                ClientAdminId = Convert.ToInt32(Session["ClientadminId"]);
                ClientId = Convert.ToInt32(Session["ClientId"]);
                //  }

            }
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult AddContact()
        {
            return View();
        }
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase upload, int Locate)
        {

            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {

                    if (upload.FileName.EndsWith(".csv"))
                    {
                        string con = ConfigurationManager.ConnectionStrings["upload"].ConnectionString;

                        Stream stream = upload.InputStream;
                        DataTable csvTable = new DataTable();
                        using (CsvReader csvReader =
                            new CsvReader(new StreamReader(stream), true))
                        {
                            csvTable.Load(csvReader);
                        }
                        if (Locate == 1)
                        {
                            SqlBulkCopy sqlBulk = new SqlBulkCopy(con);
                            //Give your Destination table name
                            sqlBulk.DestinationTableName = "Contacts";// name of the upload file table
                            //sqlBulk.ColumnMappings.Add("ContactId", "ContactId");
                            sqlBulk.ColumnMappings.Add("AnniversaryDate", "AnniversaryDate");
                            sqlBulk.ColumnMappings.Add("CellPhone", "CellPhone");
                            sqlBulk.ColumnMappings.Add("City", "City");
                            sqlBulk.ColumnMappings.Add("DateOfBirth", "DateOfBirth");
                            sqlBulk.ColumnMappings.Add("Email", "Email");
                            sqlBulk.ColumnMappings.Add("FirstName", "FirstName");
                            sqlBulk.ColumnMappings.Add("IsActive", "IsActive");
                            sqlBulk.ColumnMappings.Add("LastName", "LastName");
                            sqlBulk.ColumnMappings.Add("SecondaryPhone", "SecondaryPhone");
                            sqlBulk.ColumnMappings.Add("State", "State");
                            sqlBulk.ColumnMappings.Add("Street", "Street");
                            sqlBulk.ColumnMappings.Add("UserMappingId", "UserMappingId");
                            sqlBulk.ColumnMappings.Add("ZipCode", "ZipCode");
                            try
                            {
                                sqlBulk.WriteToServer(csvTable);
                                //ModelState.AddModelError("File", "contact file  uploaded");

                                TempData["notice"] = "Successfully Contact file is uploaded";

                                //return RedirectToAction("Upload", "Home");
                            }
                            catch
                            {
                                TempData["notice"] = "The File shouls be in specified format only for the selected category. ";
                            }

                        }

                        else
                        {
                            if (Locate == 2)
                            {
                                SqlBulkCopy sqlBulk = new SqlBulkCopy(con);
                                //Give your Destination table name
                                sqlBulk.DestinationTableName = "Resources";// name of the upload file table
                                sqlBulk.ColumnMappings.Add("AccountNumber", "AccountNumber");
                                sqlBulk.ColumnMappings.Add("CellPhoneNumber", "CellPhoneNumber");
                                sqlBulk.ColumnMappings.Add("City", "City");
                                sqlBulk.ColumnMappings.Add("ClientId", "ClientId");
                                sqlBulk.ColumnMappings.Add("EmailAddress", "EmailAddress");
                                sqlBulk.ColumnMappings.Add("FirstName", "FirstName");
                                sqlBulk.ColumnMappings.Add("LastName", "LastName");
                                sqlBulk.ColumnMappings.Add("PrimaryPhoneNumber", "PrimaryPhoneNumber");
                                sqlBulk.ColumnMappings.Add("ResoureDescription", "ResoureDescription");
                                sqlBulk.ColumnMappings.Add("ResoureName", "ResoureName");
                                sqlBulk.ColumnMappings.Add("SecondaryPhoneNumber", "SecondaryPhoneNumber");
                                sqlBulk.ColumnMappings.Add("State", "State");
                                sqlBulk.ColumnMappings.Add("Street", "Street");
                                sqlBulk.ColumnMappings.Add("URL", "URL");
                                sqlBulk.ColumnMappings.Add("ZipCode", "ZipCode");
                                try
                                {
                                    sqlBulk.WriteToServer(csvTable);
                                    TempData["notice"] = "Successfully Resources file is uploaded";
                                }
                                catch
                                {
                                    TempData["notice"] = "resources file coloum field is not matching with resources database coloum field ";

                                }

                            }
                            else
                            {
                                TempData["notice"] = ("Please Choose your file type is Resource or Contact ");

                            }
                        }
                    }
                    else
                    {
                        TempData["notice"] = ("only csv file  format   supported");


                    }
                }
                else
                {
                    TempData["notice"] = ("Please Select Your Contact or resource file");

                }
            }
            return View();


        }

        public FileResult downloadFile()
        {

            return new FilePathResult(Server.MapPath("/Notify/Files/Contact.csv"), "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }

        public FileResult downloadFile1()
        {
            return new FilePathResult(Server.MapPath("/Notify/Files/resource.csv"), "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }

        public ActionResult Resources()
        {
            return View();
        }

        public ActionResult AddResources()
        {
            return View();
        }

        public ActionResult Notifications()
        {
            return View();
        }

        public ActionResult AddNotifications()
        {
            return View();
        }

        public ActionResult ContactList()
        {
            return View();
        }
        public ActionResult AddContactList()
        {
            return View();
        }

        public ActionResult NotificationSchedule()
        {
            return View();
        }
        public ActionResult Client()
        {
            return View();
        }
        public ActionResult AddClient()
        {
            return View();
        }
        public ActionResult EditContactList()
        {
            return View();
        }
        public JsonResult getcontactPerson()
        {
            ClientId = Convert.ToInt32(Session["ClientId"]);
            return new JsonResult { Data = dc.Contacts.ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult getcategories()
        {
            ClientId = Convert.ToInt32(Session["ClientId"]);
            return new JsonResult { Data = dc.Contacts.ToList().Where(c => c.ClientId == ClientId), JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }

        [HttpPost]
        public JsonResult savedata(int[] categoryIds, string contactlistname)
        {
            string Message = string.Empty;
            List<CategoryList> list = new List<CategoryList>();
            ContactListMaster master = new ContactListMaster();
            ContactListDetail contactlist = new ContactListDetail();

            if (categoryIds != null)
            {

                master.ContactListname = contactlistname;
                var clExist = dc.ContactListMasters.Where(cli => cli.ContactListname == contactlistname).FirstOrDefault();
                if (string.IsNullOrEmpty(Convert.ToString(clExist)))
                {

                    ClientId = Convert.ToInt32(Session["ClientId"]);
                    if (ClientId != null)
                    {
                        master.ClientId = ClientId;
                    }
                    dc.ContactListMasters.Add(master);
                    dc.SaveChanges();
                    int last_insert_id = master.ListId;

                    var query = dc.Contacts.Where(item => categoryIds.Contains((int)item.ContactId)).ToList();

                    foreach (var fl in query)
                    {

                        contactlist.ContactID = fl.ContactId;
                        contactlist.ContactListID = last_insert_id;
                        dc.ContactListDetails.Add(contactlist);
                        dc.SaveChanges();
                        Message = "Contact list Success.";
                    }

                    // Message = "Contact list Success.";
                }
                else
                {
                    Message = "Contact list name cannot be duplicate.";
                    return new JsonResult { Data = new { Message = Message, Status = false } };
                }
            }
            return new JsonResult { Data = new { Message = Message, Status = false } };
        }
        public JsonResult savecategory(int CtListId, int CtId)
        {
            //int ClientId = 0;
            ContactListDetail contactlist = new ContactListDetail();
            if (Session["ClientId"] != Convert.ToString(""))
            {
                contactlist.ClientId = Convert.ToInt32(Session["ClientId"]);
                contactlist.ContactListID = CtListId;
                contactlist.ContactID = CtId;
                dc.ContactListDetails.Add(contactlist);
                dc.SaveChanges();
            }
            else
            {
                contactlist.ClientId = 0;
                contactlist.ContactListID = CtListId;
                contactlist.ContactID = CtId;
                dc.ContactListDetails.Add(contactlist);
                dc.SaveChanges();
            }
            return new JsonResult { Data = contactlist };
        }

        public JsonResult getcontactList()
        {
            ClientId = Convert.ToInt32(Session["ClientId"]);

            return new JsonResult { Data = dc.ContactListMasters.ToList().Where(c => c.ClientId == ClientId), JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public JsonResult GetResourcesList()
        {
            ClientId = Convert.ToInt32(Session["ClientId"]);
            return new JsonResult { Data = dc.Resources.Where(c => c.ClientId == ClientId).ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public string GetContactListDetail(int id)
        {
            List<ContactListDataModel> contactdata = new List<ContactListDataModel>();

            var mdl = (from cm in
                           dc.ContactListMasters
                       join ct in dc.ContactListDetails on cm.ListId equals ct.ContactListID
                       join cont in dc.Contacts on ct.ContactID equals cont.ContactId
                       where ct.ContactListID == id
                       select new { Contactmster = cm, Contactlist = ct, contact = cont });
            foreach (var md in mdl)
            {
                contactdata.Add(new ContactListDataModel { ContactID = md.Contactlist.ContactID, ListDetailID = md.Contactlist.ListDetailID, ContactListname = md.Contactmster.ContactListname, FirstName = md.contact.FirstName, LastName = md.contact.LastName });
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(contactdata.ToList());

        }

        public string AddNotification(NotifcationScheduleModel Nschedule)
        {
            using (NotifyContext dc = new NotifyContext())
            {
                Tbl_NotificationSchedule Schedule = new Tbl_NotificationSchedule();
                ClientId = Convert.ToInt32(Session["ClientId"]);
                Schedule.ClientId = ClientId;
                if (Nschedule.ChanelMode == "Email")
                {
                    Schedule.NScheduleID = Nschedule.NScheduleID;
                    Schedule.NotificationCampaign = Nschedule.NotificationCampaign;
                    Schedule.CampaignDate = Nschedule.CampaignDate;
                    Schedule.ChanelMode = Nschedule.ChanelMode;
                    Schedule.ContactListId = Nschedule.ContactListId;
                    Schedule.ResourceId = Nschedule.ResourceId;
                    Schedule.NotificationId = Nschedule.NotificationId;
                    Schedule.NotificationMessage = Nschedule.NotificationMessage;
                    Schedule.ReapeatDate = Nschedule.ReapeatDate;
                    Schedule.RequestConfirmMsg = Nschedule.RequestConfirmMsg;
                    Schedule.RepeatNotificationAllow = Nschedule.RepeatNotificationAllow;
                    Schedule.MsgNumberOfTime = Nschedule.MsgNumberOfTime;
                    Schedule.Status = Nschedule.Status;
                    Schedule.IsActive = Nschedule.IsActive;
                    dc.Tbl_NotificationSchedule.Add(Schedule);
                    dc.SaveChanges();
                }
                if (Nschedule.ChanelsmsMode == "SMS")
                {
                    // Schedule.NScheduleID = Nschedule.NScheduleID;
                    Schedule.NotificationCampaign = Nschedule.NotificationCampaign;
                    Schedule.CampaignDate = Nschedule.CampaignDate;
                    Schedule.ChanelMode = Nschedule.ChanelsmsMode;
                    Schedule.ContactListId = Nschedule.ContactListId;
                    Schedule.ResourceId = Nschedule.ResourceId;
                    Schedule.NotificationId = Nschedule.NotificationSmsId;
                    Schedule.NotificationMessage = Nschedule.NotificationMessage;
                    Schedule.ReapeatDate = Nschedule.ReapeatDate;
                    Schedule.RequestConfirmMsg = Nschedule.RequestConfirmMsg;
                    Schedule.RepeatNotificationAllow = Nschedule.RepeatNotificationAllow;
                    Schedule.MsgNumberOfTime = Nschedule.MsgNumberOfTime;
                    Schedule.Status = Nschedule.Status;
                    Schedule.IsActive = Nschedule.IsActive;
                    dc.Tbl_NotificationSchedule.Add(Schedule);
                    dc.SaveChanges();
                }
                if (Nschedule.ChanelvoiceMode == "Voice Call")
                {
                    // Schedule.NScheduleID = Nschedule.NScheduleID;
                    Schedule.NotificationCampaign = Nschedule.NotificationCampaign;
                    Schedule.CampaignDate = Nschedule.CampaignDate;
                    Schedule.ChanelMode = Nschedule.ChanelvoiceMode;
                    Schedule.ContactListId = Nschedule.ContactListId;
                    Schedule.ResourceId = Nschedule.ResourceId;
                    Schedule.NotificationId = Nschedule.NotificationVoiceId;
                    Schedule.NotificationMessage = Nschedule.NotificationMessage;
                    Schedule.ReapeatDate = Nschedule.ReapeatDate;
                    Schedule.RequestConfirmMsg = Nschedule.RequestConfirmMsg;
                    Schedule.RepeatNotificationAllow = Nschedule.RepeatNotificationAllow;
                    Schedule.MsgNumberOfTime = Nschedule.MsgNumberOfTime;
                    Schedule.Status = Nschedule.Status;
                    Schedule.IsActive = Nschedule.IsActive;
                    dc.Tbl_NotificationSchedule.Add(Schedule);
                    dc.SaveChanges();

                }
                return "Notification Schedule has been created.";
            }

        }
        //Get template record in dropdown in notification schedule
        public JsonResult GetTemplateRecord(string Mode)
        {
            ClientId = Convert.ToInt32(Session["ClientId"]);
            var NotifyTemplate = (from cm in
                                      dc.Notifications
                                  where cm.NotificationType == Mode && cm.ClientId == ClientId
                                  select new { TemplateName = cm.TemplateName, NotificationId = cm.NotificationId });
            return new JsonResult { Data = NotifyTemplate.ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetNotificationMessageRecord(int Template)
        {
            ClientId = Convert.ToInt32(Session["ClientId"]);
            var Notifymsg = (from cm in
                                 dc.Notifications
                             where cm.NotificationId == Template && cm.ClientId == ClientId
                             select new { NotificationMessage = cm.NotificationMessage });
            return new JsonResult { Data = Notifymsg.ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetNotificationSMSMessageRecord(int Template)
        {
            var Notifymsg = (from cm in
                                 dc.Notifications
                             where cm.NotificationId == Template && cm.ClientId == ClientId
                             select new { NotificationMessage = cm.NotificationMessage });
            return new JsonResult { Data = Notifymsg.ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetNotificationVoiceMessageRecord(int Template)
        {
            var Notifymsg = (from cm in
                                 dc.Notifications
                             where cm.NotificationId == Template
                             select new { NotificationMessage = cm.NotificationMessage });
            return new JsonResult { Data = Notifymsg.ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult SaveFiles(string clientName, string clientEmail, string ClientUserName, string ClientPassword)
        {
            string Message, fileName, actualFileName;
            Message = fileName = actualFileName = string.Empty;
            bool flag = false;
            ClientId = Convert.ToInt32(Session["ClientadminId"]);
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                actualFileName = file.FileName;
                fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                int size = file.ContentLength;

                try
                {
                    //file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), fileName));

                    Client f = new Client
                    {
                        ClientLogo = actualFileName,
                        ClientEmail = clientEmail,
                        ClientName = clientName,
                        ClientUserName = ClientUserName,
                        ClientPassword = ClientPassword,
                        RoleId = 2,
                        AdminId = ClientId

                    };
                    //UploadedFile f = new UploadedFile
                    //{
                    //    FileName = actualFileName,
                    //    FilePath = fileName,
                    //    Description = description,
                    //    FileSize = size
                    //};
                    using (NotifyContext dc = new NotifyContext())
                    {
                        dc.Clients.Add(f);
                        dc.SaveChanges();
                        int newIdentityValue = f.ClientId;
                        UserClientRoleMapping clientrole = new UserClientRoleMapping();
                        clientrole.ClientId = newIdentityValue;
                        clientrole.RoleId = 2;
                        clientrole.UserId = 0;
                        dc.UserClientRoleMappings.Add(clientrole);
                        dc.SaveChanges();
                        Message = "Submit successfully";
                        flag = true;
                    }
                }
                catch (Exception)
                {
                    Message = "File upload failed! Please try again";
                }

            }
            return new JsonResult { Data = new { Message = Message, Status = flag } };
        }

        public string DeleteContactList(int listId)
        {
            ContactListDetail personalDetail = dc.ContactListDetails.Find(listId);
            dc.ContactListDetails.Remove(personalDetail);
            dc.SaveChanges();
            return ("sucess");
        }

        public ActionResult SendNotification()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendNotification(int[] schedule)
        {
            string AccountSid = "ACadc200cf09ccb955be54787e851f744e";
            string AuthToken = " a87a0a6fd7975e7f54f8e666404cb6cf ";
            TwilioRestClient client = new TwilioRestClient(AccountSid, AuthToken);
            string phonenumber = "+17402003194";
            var options = new CallOptions();
            int clist, contid, Ntid;
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
                    var ntmsg = from ntm in dc.Notifications where ntm.NotificationId == Ntid select ntm;
                    foreach (var nt in ntmsg)
                    {
                        Nmsg = Convert.ToString(nt.NotificationMessage);
                        Ntempname = Convert.ToString(nt.TemplateName);
                        NMode = Convert.ToString(nt.NotificationType);
                        if (NMode == "Voice Call")
                        {
                            path = HttpContext.Server.MapPath("~/VoiceXmlTemplate/" + Ntempname + ".xml");
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
                                //options.Url = path;
                                //options.From = phonenumber;
                                //options.Method = "GET";
                                //options.StatusCallback = "https://www.myapp.com/events";
                                //options.StatusCallbackMethod = "POST";
                                //options.StatusCallbackEvents = "initiated", "ringing", "answered", "completed" ;
                                // var call = client.InitiateOutboundCall(options);
                                var call = client.InitiateOutboundCall(phonenumber, Contphone, path);
                            }
                            else if (chmodel == "Email")
                            {
                                sendmail(Contemail, contname, Nmsg);

                            }
                        }
                    }

                }
            }
            return View();

        }

        public void sendmail(string Email, string Name, string Message)
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
        public ActionResult User()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public JsonResult saveUserdata(UserModule umd)
        {
            string Message = string.Empty;
            ClientId = Convert.ToInt32(Session["ClientId"]);

            UserClientRoleMapping UserMapping = new UserClientRoleMapping();
            User usd = new User();
            usd = dc.Users.Find(ClientId);
            usd.RoleId = umd.RoleId;
            usd.UserName = umd.UserName;
            usd.Fullname = umd.Fullname;
            usd.EmailId = umd.EmailId;
            usd.Password = umd.Password;
            dc.Users.Add(usd);
            var Id = dc.SaveChanges();
            UserMapping.UserId = Convert.ToInt32(usd.UserID);
            UserMapping.ClientId = ClientId;
            UserMapping.RoleId = usd.RoleId;
            dc.UserClientRoleMappings.Add(UserMapping);
            dc.SaveChanges();
            return new JsonResult { Data = new { Message = Message, Status = false } };
        }

        public string getuserList()
        {
            ClientId = Convert.ToInt32(Session["ClientId"]);
            List<UserModule> usrmdl = new List<UserModule>();
            //var mdl = (from usr in dc.Users 
            //           join rt in dc.UserClientRoleMappings on usr.UserID equals rt.UserId
            //           join rold in dc.Roles on usr.RoleId equals rold.RoleId
            //           where rt.ClientId == ClientId && rt.RoleId==2
            //           orderby usr.UserName
            //           select new { usertable = usr, usrmaping = rt, roltable = rold });
            var mdl = (from usr in dc.Users
                       where usr.ClientId == ClientId && usr.RoleId == 2
                       orderby usr.UserName
                       select new { usertable = usr });
            foreach (var md in mdl)
            {
                usrmdl.Add(new UserModule { UserID = md.usertable.UserID, UserName = md.usertable.UserName, Fullname = md.usertable.Fullname, EmailId = md.usertable.EmailId });

            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(usrmdl.ToList());

        }

        //public ActionResult edituserList(UserModule umd)
        //{
        //    using (NotifyContext db = new NotifyContext())
        //    {


        //       //NotifyContext.user.Add(umd);
        //       // NotifyContext.SaveChanges();
        //       //         return View();
        //    }
        //}

        public string DeleteUserList(int listId)
        {
            User usr = dc.Users.Find(listId);
            dc.Users.Remove(usr);
            dc.SaveChanges();
            return ("sucess");
        }

        public JsonResult getuserClientList()
        {
            return new JsonResult { Data = dc.Clients.ToList().OrderBy(c => c.ClientUserName), JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public JsonResult GetUserClientId(int id)
        {
            int Cid = 0;
            List<UserModule> usrmdl = new List<UserModule>();
            var mdl = (from usr in dc.Clients
                       join usrmap in dc.UserClientRoleMappings on usr.ClientId equals usrmap.ClientId
                       where usr.ClientId == id
                       select new { usertable = usr, usrmapping = usrmap });
            //var mdl = (from usr in dc.Users
            //           join usrmap in dc.UserClientRoleMappings on usr.UserID equals usrmap.UserId
            //           where usr.UserID == id
            //           select new { usertable = usr, usrmapping = usrmap });
            foreach (var ct in mdl)
            {

                usrmdl.Add(new UserModule { UserID = ct.usertable.ClientId, ClientId = ct.usrmapping.ClientId, RoleId = ct.usertable.RoleId });
                Cid = ct.usertable.ClientId;
                Session["ClientId"] = Cid;

            }

            //return new JsonResult { Data = dc.Users.Where(c=>c.ClientId==id).ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };           
            return new JsonResult { Data = usrmdl.ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public int GetUserCount()
        {
            int Countuser = dc.UserClientRoleMappings.Count();
            return Countuser;
        }
        public int GetContactCount()
        {
            int CountContact = dc.Contacts.Count();
            return CountContact;
        }
        public int GetNotificationCount()
        {
            int Countnotification = dc.Tbl_NotificationSchedule.Count();
            return Countnotification;
        }
        public int GetClientUserCount()
        {
            int ClientId = Convert.ToInt32(Session["ClientId"]);
            int CountClientUser = dc.UserClientRoleMappings.Where(c => c.ClientId == ClientId).Count();
            return CountClientUser;
        }
        public int GetClientContactCount()
        {
            int ClientId = Convert.ToInt32(Session["ClientId"]);
            int CountClientContact = dc.Contacts.Where(c => c.ClientId == ClientId).Count();
            return CountClientContact;
        }
        public int GetClientNotificationCount()
        {
            int ClientId = Convert.ToInt32(Session["ClientId"]);
            int CountClientNotification = dc.Tbl_NotificationSchedule.Where(c => c.ClientId == ClientId).Count();
            return CountClientNotification;
        }
        public ActionResult ViewLog()
        {

            return View();
        }
        public JsonResult GetViewLog()
        {
            List<ViewLogModel> usrmdl = new List<ViewLogModel>();
            string AccountSid = "ACadc200cf09ccb955be54787e851f744e";
            string AuthToken = " a87a0a6fd7975e7f54f8e666404cb6cf ";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);

            var request = new MessageListRequest();

            var messages = twilio.ListMessages(request);

            foreach (var message in messages.Messages)
            {

                DateTime Cdate = Convert.ToDateTime(message.DateCreated);
                usrmdl.Add(new ViewLogModel { date = Convert.ToDateTime(Cdate), direction = message.Direction, From = message.From, To = message.To, Message = message.Body, status = message.Status, sidid = message.Sid, segmentnumber = message.NumSegments, AccountId = message.AccountSid });

            }
            return new JsonResult { Data = usrmdl.ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult CallLog()
        {
            return View();
        }
        public JsonResult GetCallViewLog()
        {
            List<ViewLogCallModel> usrmdl = new List<ViewLogCallModel>();
            string AccountSid = "ACadc200cf09ccb955be54787e851f744e";
            string AuthToken = " a87a0a6fd7975e7f54f8e666404cb6cf ";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);

            var request = new CallListRequest();

            var calls = twilio.ListCalls(request);
            foreach (var call in calls.Calls)
            {
                //DateTime Cdate = Convert.ToDateTime(message.DateCreated);
                usrmdl.Add(new ViewLogCallModel { DateCreated = call.DateCreated, StartTime = Convert.ToDateTime(call.StartTime), EndTime = Convert.ToDateTime(call.EndTime), Duration = Convert.ToInt32(call.Duration), CallerName = call.CallerName, PhoneNumberSidId = call.PhoneNumberSid, SidId = call.Sid, From = call.From, To = call.To, Satus = call.Status });

            }
            return new JsonResult { Data = usrmdl.ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
