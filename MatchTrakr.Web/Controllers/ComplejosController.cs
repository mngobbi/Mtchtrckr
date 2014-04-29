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
using MatchTrakr.Web.DTO;

namespace MatchTrakr.Web.Controllers
{
    [Authorize]
    public class ComplejosController : ApiController
    {
        private MatchTrakrContext db = new MatchTrakrContext();

        // GET: api/Complejos
        [ResponseType(typeof(ComplejoDTO))]
        public IHttpActionResult GetComplejos()
        {
            Complejo[] complejos = db.Complejos.ToArray();

            if (complejos.Length > 0) 
            {
                List<ComplejoDTO> complejosDTO = new List<ComplejoDTO>();
                foreach (Complejo c in complejos)
                {
                    complejosDTO.Add(new ComplejoDTO(c));
                }
                return Ok(complejosDTO.AsEnumerable());
            }
            else
            {
                return Content(HttpStatusCode.NoContent,"No se han encontrado complejos.");
            }
           
        }

        // GET: api/Complejos/5
        [ResponseType(typeof(ComplejoDTO))]
        public IHttpActionResult GetComplejo(int id)
        {
            Complejo complejo = db.Complejos.Find(id);
            if (complejo == null)
            {
                return NotFound();
            }

            return Ok(new ComplejoDTO(complejo));
        }

        //// PUT: api/Complejos/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutComplejo(int id, Complejo complejo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != complejo.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(complejo).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ComplejoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Complejos
        //[ResponseType(typeof(Complejo))]
        //public IHttpActionResult PostComplejo(Complejo complejo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Complejos.Add(complejo);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = complejo.Id }, complejo);
        //}

        //// DELETE: api/Complejos/5
        //[ResponseType(typeof(Complejo))]
        //public IHttpActionResult DeleteComplejo(int id)
        //{
        //    Complejo complejo = db.Complejos.Find(id);
        //    if (complejo == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Complejos.Remove(complejo);
        //    db.SaveChanges();

        //    return Ok(complejo);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ComplejoExists(int id)
        //{
        //    return db.Complejos.Count(e => e.Id == id) > 0;
        //}
    }
}