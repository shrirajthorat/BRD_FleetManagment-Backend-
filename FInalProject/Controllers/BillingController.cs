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
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace FInalProject.Controllers
{
    public class BillingController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET api/Billing
        public IEnumerable<Billing> GetBillings()
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            var billings = db.Billings;
            return billings.AsEnumerable();
        }

        // GET api/Billing/5
        public Billing GetBilling(int id)
        {
            Billing billing = db.Billings.Find(id);
            if (billing == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return billing;
        }

        // PUT api/Billing/5
        public HttpResponseMessage PutBilling(int id, Billing billing)
        {
            if (ModelState.IsValid && id == billing.billingId)
            {
                db.Entry(billing).State = EntityState.Modified;

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

        // POST api/Billing
        public HttpResponseMessage PostBilling(Billing billing)
        {
            if (ModelState.IsValid)
            {
                db.Billings.Add(billing);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }


                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, billing);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = billing.billingId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Billing/5
        public HttpResponseMessage DeleteBilling(int id)
        {
            Billing billing = db.Billings.Find(id);
            if (billing == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Billings.Remove(billing);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, billing);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}