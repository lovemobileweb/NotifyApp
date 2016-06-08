using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Notify.Models;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace Notify.Controllers
{

    public class AccountController : Controller
    {
        NotifyContext dc = new NotifyContext();
        //
        // GET: /Account/
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(Logindata d)
        {
            using (NotifyContext dc = new NotifyContext())
            {

                var user = dc.Users.Where(a => a.UserName.Equals(d.Username) && a.Password.Equals(d.Password)).FirstOrDefault();
                if (user == null)
                {
                    var client = dc.Clients.Where(a => a.ClientUserName.Equals(d.Username) && a.ClientPassword.Equals(d.Password)).FirstOrDefault();
                    Session["ClientId"] = client.ClientId;
                    Session["Role"] = "Client Admin";
                    return new JsonResult { Data = client, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    if (user.RoleId == 1)
                    {
                        Session["ClientadminId"] = user.UserID;
                        Session["Role"] = "Admin";

                    }
                    else
                    {
                        Session["ClientId"] = user.UserID;
                        Session["Role"] = "User";
                    }
                }
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Register(User u)
        {

            string message = "";
            //Here we will save data to the database
            if (ModelState.IsValid)
            {
                using (NotifyContext dc = new NotifyContext())
                {
                    //check username available
                    var user = dc.Users.Where(a => a.UserName.Equals(u.UserName)).FirstOrDefault();
                    if (user == null)
                    {
                        //Save here
                        dc.Users.Add(u);
                        dc.SaveChanges();
                        message = "Success";
                    }
                    else
                    {
                        message = "Username not available!";
                    }
                }
            }
            else
            {
                message = "Failed!";
            }
            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private bool IsAlphabets(string email)
        {
            Regex r = new Regex(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");

            if (r.IsMatch(email))
                return true;
            else
                return false;
            throw new NotImplementedException();
        }
        public ActionResult ForgetPassword()
        {

            return View();
        }

        public ActionResult recoverpassword(string id)
        {

            string pswd;
            string email;

            var pswrd = (from cm in
                             dc.Users
                         where cm.EmailId == id
                         select new { psw = cm.Password, email = cm.EmailId });
            foreach (var md in pswrd)
            {
                pswd = Convert.ToString(md.psw);
                email = Convert.ToString(md.email);


                // From

                MailMessage mailMsg = new MailMessage();
                mailMsg.From = new MailAddress("acharyatc@gmail.com", "From Tripurari Acharya");
                mailMsg.Subject = " Notify recovered password:";
                if (IsAlphabets(email) == true)
                {
                    mailMsg.To.Add(new MailAddress(email));
                }
                else
                {
                    ViewBag.Name = "Please enter correct Insured Name ";

                }

                string url = ("Your Notifyapp recovered password:");

                string html = pswd + url;
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("CirrusNotification", "N0+ify2016");
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;

                if (IsAlphabets(email) == true)
                {
                    smtpClient.Send(mailMsg);
                }

                TempData["notice"] = "Succesfully Send password ur email ";
            }
            TempData["notice"] = "Please Enter a Valid EmailID";
            return View();

        }


        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }


    }
}
