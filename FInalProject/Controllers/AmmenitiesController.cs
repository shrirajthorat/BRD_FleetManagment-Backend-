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

namespace FInalProject.Controllers
{
    public class AmmenitiesController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET api/Ammenities
        public IEnumerable<Ammenities> GetAmmenities()
        {
            return db.Ammenities.AsEnumerable();
        }

        // GET api/Ammenities/5
        public Ammenities GetAmmenities(int id)
        {
            Ammenities ammenities = db.Ammenities.Find(id);
            if (ammenities == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return ammenities;
        }

        // PUT api/Ammenities/5
        public HttpResponseMessage PutAmmenities(int id, Ammenities ammenities)
        {
            if (ModelState.IsValid && id == ammenities.ammenitiesId)
            {
                db.Entry(ammenities).State = EntityState.Modified;

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

        // POST api/Ammenities
        public HttpResponseMessage PostAmmenities(Ammenities ammenities)
        {
            if (ModelState.IsValid)
            {
                db.Ammenities.Add(ammenities);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, ammenities);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = ammenities.ammenitiesId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Ammenities/5
        public HttpResponseMessage DeleteAmmenities(int id)
        {
            Ammenities ammenities = db.Ammenities.Find(id);
            if (ammenities == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Ammenities.Remove(ammenities);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ammenities);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}