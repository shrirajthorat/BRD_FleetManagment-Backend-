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
    public class BookingController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET api/Booking
        public IEnumerable<Booking> GetBookings()
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            var bookings = db.Bookings;
            return bookings.AsEnumerable();
        }

        // GET api/Booking/5
        public Booking GetBooking(int id)
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return booking;
        }

        // PUT api/Booking/5
        public HttpResponseMessage PutBooking(int id, Booking booking)
        {
            if (ModelState.IsValid && id == booking.bookingId)
            {
                db.Entry(booking).State = EntityState.Modified;

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

        // POST api/Booking
        public HttpResponseMessage PostBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, booking);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = booking.bookingId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Booking/5
        public HttpResponseMessage DeleteBooking(int id)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Bookings.Remove(booking);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, booking);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}