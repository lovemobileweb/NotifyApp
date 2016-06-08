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
    public class ContactListAPIController : ApiController
    {
        private NotifyContext db = new NotifyContext();

        // GET api/ContactListAPI
        public IEnumerable<ContactListDetail> GetContactListDetails()
        {
            return db.ContactListDetails.AsEnumerable();
        }

        // GET api/ContactListAPI/5
        public ContactListDetail GetContactListDetail(int id)
        {
            ContactListDetail contactlistdetail = db.ContactListDetails.Find(id);
            if (contactlistdetail == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return contactlistdetail;
        }

        // PUT api/ContactListAPI/5
        public HttpResponseMessage PutContactListDetail(int id, ContactListDetail contactlistdetail)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != contactlistdetail.ListDetailID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(contactlistdetail).State = EntityState.Modified;

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

        // POST api/ContactListAPI
        public HttpResponseMessage PostContactListDetail(ContactListDetail contactlistdetail)
        {
            if (ModelState.IsValid)
            {
                db.ContactListDetails.Add(contactlistdetail);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, contactlistdetail);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = contactlistdetail.ListDetailID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/ContactListAPI/5
        public HttpResponseMessage DeleteContactListDetail(int id)
        {
            ContactListDetail contactlistdetail = db.ContactListDetails.Find(id);
            if (contactlistdetail == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.ContactListDetails.Remove(contactlistdetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, contactlistdetail);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}