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
    public class ResourcesController : ApiController
    {
        private NotifyContext db = new NotifyContext();
        int clientId = Convert.ToInt32(HttpContext.Current.Session["ClientId"]);
        // GET api/Resources
        public IEnumerable<Resource> GetResources()
        {
            return db.Resources.AsEnumerable().Where(c=>c.ClientId==clientId);
        }

        // GET api/Resources/5
        public Resource GetResource(int id)
        {
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return resource;
        }

        // PUT api/Resources/5
        public HttpResponseMessage PutResource(int id, Resource resource)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != resource.ResoureId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(resource).State = EntityState.Modified;

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

        // POST api/Resources
        public HttpResponseMessage PostResource(Resource resource)
        {
            if (ModelState.IsValid)
            {

                resource.ClientId = clientId;
                db.Resources.Add(resource);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, resource);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = resource.ResoureId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Resources/5
        public HttpResponseMessage DeleteResource(int id)
        {
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Resources.Remove(resource);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, resource);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}