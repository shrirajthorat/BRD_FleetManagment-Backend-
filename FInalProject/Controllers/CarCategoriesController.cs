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
    public class CarCategoriesController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET api/CarCategories
        public IEnumerable<CarCategories> GetCarCategories()
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            return db.CarCategories.AsEnumerable();
        }

        // GET api/CarCategories/5
        public CarCategories GetCarCategories(int id)
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            CarCategories carcategories = db.CarCategories.Find(id);
            if (carcategories == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return carcategories;
        }

        // PUT api/CarCategories/5
        public HttpResponseMessage PutCarCategories(int id, CarCategories carcategories)
        {
            if (ModelState.IsValid && id == carcategories.categoryId)
            {
                db.Entry(carcategories).State = EntityState.Modified;

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

        // POST api/CarCategories
        public HttpResponseMessage PostCarCategories(CarCategories carcategories)
        {
            if (ModelState.IsValid)
            {
                db.CarCategories.Add(carcategories);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, carcategories);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = carcategories.categoryId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/CarCategories/5
        public HttpResponseMessage DeleteCarCategories(int id)
        {
            CarCategories carcategories = db.CarCategories.Find(id);
            if (carcategories == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.CarCategories.Remove(carcategories);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, carcategories);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}