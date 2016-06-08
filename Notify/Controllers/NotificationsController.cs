using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml;

namespace Notify.Controllers
{
    public class NotificationsController : ApiController
    {
        private NotifyContext db = new NotifyContext();
        int clientId = Convert.ToInt32(HttpContext.Current.Session["ClientId"]);
        // GET api/Notifications
        public IEnumerable<Notification> GetNotifications()
        {
            return db.Notifications.AsEnumerable().Where(c => c.ClientId == clientId);
        }

        // GET api/Notifications/5
        public Notification GetNotification(int id)
        {
            Notification notification = db.Notifications.Find(id);
            if (notification == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return notification;
        }

        // PUT api/Notifications/5
        public HttpResponseMessage PutNotification(int id, Notification notification)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != notification.NotificationId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(notification).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Notifications
        public HttpResponseMessage PostNotification(Notification notification)
        {
            if (ModelState.IsValid)
            {

                notification.ClientId = clientId;
                db.Notifications.Add(notification);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, notification);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = notification.NotificationId }));

                ///////////////////////////////////////////////////////////

                DataTable dt = GetEmployees(Convert.ToInt32(notification.NotificationId));
                if (Convert.ToInt32(dt.Rows[0]["TypeId"]) == 3)
                {
                    XmlTextWriter xmlwriter = new XmlTextWriter(System.Web.HttpContext.Current.Server.MapPath("~/VoiceXmlTemplate/" + dt.Rows[0]["TemplateName"].ToString() + ".xml"), Encoding.UTF8);
                    xmlwriter.Formatting = Formatting.Indented;
                    xmlwriter.WriteStartDocument();
                    xmlwriter.WriteStartElement("Response");
                    //GetEmployees() method returns DataTable with data. Download the code attached to see it in action               

                    xmlwriter.WriteElementString("Say", dt.Rows[0]["NotificationMessage"].ToString());
                    xmlwriter.WriteEndElement();
                    //xmlwriter.WriteAttributeString("voice", "alice");
                    xmlwriter.WriteEndDocument();
                    xmlwriter.Flush();
                    xmlwriter.Close();

                }
                ////////////////////////////////////////////////////////////

                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public DataTable GetEmployees(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["upload"].ToString());
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetVoiceTemplate";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        // DELETE api/Notifications/5
        public HttpResponseMessage DeleteNotification(int id)
        {
            Notification notification = db.Notifications.Find(id);
            if (notification == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Notifications.Remove(notification);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, notification);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}