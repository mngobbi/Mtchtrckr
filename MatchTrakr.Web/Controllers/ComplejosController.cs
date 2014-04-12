using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MatchTrakr.Data;
using MatchTrakr.Data.Entities;

namespace MatchTrakr.Web.Controllers
{
    public class ComplejosController : ApiController
    {
        private MatchTrakrContext db = new MatchTrakrContext();

        // GET: api/Complejos
        public IQueryable<Complejo> GetComplejos()
        {
            return db.Complejos;
        }

        // GET: api/Complejos/5
        [ResponseType(typeof(Complejo))]
        public IHttpActionResult GetComplejo(int id)
        {
            Complejo complejo = db.Complejos.Find(id);
            if (complejo == null)
            {
                return NotFound();
            }

            return Ok(complejo);
        }

        // PUT: api/Complejos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComplejo(int id, Complejo complejo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != complejo.Id)
            {
                return BadRequest();
            }

            db.Entry(complejo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplejoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Complejos
        [ResponseType(typeof(Complejo))]
        public IHttpActionResult PostComplejo(Complejo complejo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Complejos.Add(complejo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = complejo.Id }, complejo);
        }

        // DELETE: api/Complejos/5
        [ResponseType(typeof(Complejo))]
        public IHttpActionResult DeleteComplejo(int id)
        {
            Complejo complejo = db.Complejos.Find(id);
            if (complejo == null)
            {
                return NotFound();
            }

            db.Complejos.Remove(complejo);
            db.SaveChanges();

            return Ok(complejo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComplejoExists(int id)
        {
            return db.Complejos.Count(e => e.Id == id) > 0;
        }
    }
}