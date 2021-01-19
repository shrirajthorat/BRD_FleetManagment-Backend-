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
    public class EmployeeController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET api/Employee
        public IEnumerable<Employee> GetEmployees()
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            var employees = db.Employees.Include(e => e.Hub);
            return employees.AsEnumerable();
        }

        // GET api/Employee/5
        public Employee GetEmployee(int id)
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return employee;
        }

        [Route("/api/Employee/validate")]
        [HttpPost]
        public IHttpActionResult ValidateEmployee(string method, Employee a)
        {
            if (method == "validate")
            {
                db.Configuration.LazyLoadingEnabled = true;
                db.Configuration.ProxyCreationEnabled = false;
                Employee employee = null;
                employee = db.Employees.FirstOrDefault(e => e.empMailId == a.empMailId && e.empPassword == a.empPassword);
                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            return InternalServerError();
        }

        // PUT api/Employee/5
        public HttpResponseMessage PutEmployee(int id, Employee employee)
        {
            if (ModelState.IsValid && id == employee.empId)
            {
                db.Entry(employee).State = EntityState.Modified;

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

        // POST api/Employee
        public HttpResponseMessage PostEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, employee);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = employee.empId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Employee/5
        public HttpResponseMessage DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Employees.Remove(employee);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}