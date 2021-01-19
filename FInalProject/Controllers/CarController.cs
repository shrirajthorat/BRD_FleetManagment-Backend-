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
    public class CarController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET api/Car
        public IEnumerable<Car> GetCars()
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            var cars = db.Cars.Include(c => c.CarCategory).Include(c => c.Hub);
            return cars.AsEnumerable();
        }

        // GET api/Car/5
        public Car GetCar(int id)
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return car;
        }

        // GET api/Car/5
        public IEnumerable<Car> GetCarByCategory(string category , int category_id)
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            var cars = db.Cars.Where(car => car.CarCategories_categoryId == category_id).ToList();
            if (cars == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return cars;
        }

        // PUT api/Car/5
        public HttpResponseMessage PutCar(int id, Car car)
        {
            if (ModelState.IsValid && id == car.carId)
            {
                db.Entry(car).State = EntityState.Modified;

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

        // POST api/Car
        public HttpResponseMessage PostCar(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, car);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = car.carId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Car/5
        public HttpResponseMessage DeleteCar(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Cars.Remove(car);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, car);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}