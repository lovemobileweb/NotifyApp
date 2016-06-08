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
    public class ClientAPIController : ApiController
    {
        private NotifyContext db = new NotifyContext();
        int clientId = Convert.ToInt32(HttpContext.Current.Session["ClientadminId"]);
        // GET api/ClientAPI
        public IEnumerable<Client> GetClients()
        {
            return db.Clients.AsEnumerable().Where(c=>c.AdminId==clientId);
        }

        // GET api/ClientAPI/5
        public Client GetClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return client;
        }

        // PUT api/ClientAPI/5
        public HttpResponseMessage PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != client.ClientId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(client).State = EntityState.Modified;

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

        // POST api/ClientAPI
        public HttpResponseMessage PostClient(Client client)
        {
            if (ModelState.IsValid)
            {
                client.AdminId = clientId;
                db.Clients.Add(client);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, client);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = client.ClientId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/ClientAPI/5
        public HttpResponseMessage DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Clients.Remove(client);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, client);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}