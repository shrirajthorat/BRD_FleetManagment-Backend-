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
using System.Security.Cryptography;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace FInalProject.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class CustomerController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET api/Customer
        public IEnumerable<Customer> GetCustomers()
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            return db.Customers.AsEnumerable();
        }

        // GET api/Customer/5
        public Customer GetCustomer(int id)
        {

            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return customer;
        }

        // PUT api/Customer/5
        public HttpResponseMessage PutCustomer(int id, Customer customer)
        {
            if (ModelState.IsValid && id == customer.customerId)
            {
                db.Entry(customer).State = EntityState.Modified;

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
        public static string GenerateToken(int length)
        {
            using (RNGCryptoServiceProvider cryptRNG = new RNGCryptoServiceProvider())
            {
                byte[] tokenBuffer = new byte[length];
                cryptRNG.GetBytes(tokenBuffer);
                return Convert.ToBase64String(tokenBuffer);
            }
        }

        // POST api/Customer
        public HttpResponseMessage PostCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.password = GenerateToken(3);
                db.Customers.Add(customer);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, customer);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = customer.customerId }));
                //Console.WriteLine(customer.customerId);
                
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Customer/5
        public HttpResponseMessage DeleteCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Customers.Remove(customer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}