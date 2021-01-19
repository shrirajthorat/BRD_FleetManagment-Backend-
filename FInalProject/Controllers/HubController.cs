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
using FInalProject.Models;
using System.Web.Http.Cors;

namespace FInalProject.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class HubController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET api/Hub
        public IEnumerable<Hub> GetHubs()
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            var hubs = db.Hubs.Include(h => h.City);
            return hubs.AsEnumerable();
        }

        // GET api/Hub/5
        public Hub GetHub(int id)
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            Hub hub = db.Hubs.Find(id);
            if (hub == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return hub;
        }

        // GET api/Hub/5
        [Route("/api/hub/city")]
        [HttpGet]
        public IEnumerable<Hub> GetHubByCity(string city , int cityId)
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            var hubs = db.Hubs.Where(hub => hub.City_cityId == cityId).ToList();
            if (hubs == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return hubs;
        }

        // PUT api/Hub/5
        public HttpResponseMessage PutHub(int id, Hub hub)
        {
            if (ModelState.IsValid && id == hub.hubId)
            {
                db.Entry(hub).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Hub
        public HttpResponseMessage PostHub(Hub hub)
        {
            if (ModelState.IsValid)
            {
                db.Hubs.Add(hub);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, hub);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = hub.hubId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Hub/5
        public HttpResponseMessage DeleteHub(int id)
        {
            Hub hub = db.Hubs.Find(id);
            if (hub == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Hubs.Remove(hub);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, hub);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}