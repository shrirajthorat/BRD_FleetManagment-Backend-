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

    public class StateController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET api/State
        public IEnumerable<State> GetStates()
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            return db.States.AsEnumerable();
        }

        // GET api/State/5
        public State GetState(int id)
        {
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
            State state = db.States.Find(id);
            if (state == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return state;
        }

        // PUT api/State/5
        public HttpResponseMessage PutState(int id, State state)
        {
            if (ModelState.IsValid && id == state.stateId)
            {
                db.Entry(state).State = EntityState.Modified;

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

        // POST api/State
        public HttpResponseMessage PostState(State state)
        {
            if (ModelState.IsValid)
            {
                db.States.Add(state);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, state);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = state.stateId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/State/5
        public HttpResponseMessage DeleteState(int id)
        {
            State state = db.States.Find(id);
            if (state == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.States.Remove(state);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, state);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}