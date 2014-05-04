using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MatchTrakr.Data;
using MatchTrakr.Data.Services;
using MatchTrakr.Data.Entities;
using MatchTrakr.Web.DTO;

namespace MatchTrakr.Web.Controllers
{
    [RoutePrefix("api")]
    public class ComplejosController : ApiController
    {
        private readonly ComplejosRepository _repo;

        public ComplejosController()
        {
            _repo = new ComplejosRepository(new MatchTrakrContext());
        }

        // GET: api/Complejos
        [Route("complejos")]
        public IEnumerable<ComplejoDTO> GetComplejos()
        {
            return _repo.GetAll().AsDTO();
        }

        // GET: api/Complejos/5
        [Route("complejos/{id}", Name = "GetComplejoById")]
        [ResponseType(typeof(ComplejoDTO))]
        public IHttpActionResult GetComplejo(int id)
        {
            Complejo complejo = _repo.Find(e => e.Id == id);
            if (complejo == null)
            {
                return NotFound();
            }

            return Ok(complejo.AsDTO());
        }

        // PUT: api/Complejos/5
        [Route("complejos/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComplejo(int id, ComplejoDTO complejoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != complejoDTO.Id)
            {
                return BadRequest();
            }

            Complejo comp = _repo.Find(e => e.Id == id);

            if (comp != null)
            {
                try
                {
                    ComplejoDTOtoComplejo(ref comp, complejoDTO);
                    _repo.Update(comp, id);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            else
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Complejos
        [Route("complejos")]
        [ResponseType(typeof(ComplejoDTO))]
        public IHttpActionResult PostComplejo(ComplejoDTO complejoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Complejo comp = new Complejo();
            ComplejoDTOtoComplejo(ref comp, complejoDTO);

            _repo.Add(comp);

            complejoDTO.Id = comp.Id;

            return CreatedAtRoute("GetComplejoByID", new { id = complejoDTO.Id }, complejoDTO);
        }

        // DELETE: api/Complejos/5
        [Route("complejos/{id}")]
        [ResponseType(typeof(ComplejoDTO))]
        public IHttpActionResult DeleteComplejo(int id)
        {
            Complejo complejo = _repo.Find(e => e.Id == id);
            if (complejo == null)
            {
                return NotFound();
            }

            _repo.Delete(complejo);

            return Ok(complejo.AsDTO());
        }

        private void ComplejoDTOtoComplejo(ref Complejo comp, ComplejoDTO complejoDTO)
        {
            comp.Nombre = complejoDTO.Nombre;
            comp.Descripcion = complejoDTO.Descripcion;
            comp.Direccion = complejoDTO.Direccion;
            comp.Telefono = complejoDTO.Telefono;
            comp.Canchas.Clear();
            if (complejoDTO.Canchas.Length > 0)
            {
                List<Cancha> canchas = new List<Cancha>();
                foreach (var cDTO in complejoDTO.Canchas)
                {
                    Cancha c = new Cancha();
                    c.Complejo = comp;
                    c.Nombre = cDTO.Nombre;
                    c.Precio = cDTO.Precio;
                    canchas.Add(c);
                }
                comp.Canchas = canchas.ToArray();
            }
        }
    }
}