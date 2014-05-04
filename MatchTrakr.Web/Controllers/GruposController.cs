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
    public class GruposController : ApiController
    {
        private readonly GruposRepository _repo;

        public GruposController()
        {
            _repo = new GruposRepository(new MatchTrakrContext());
        }

        // GET: api/Grupos
        [Route("grupos")]
        public IEnumerable<GrupoDTO> GetGrupos()
        {
            return _repo.GetAll().AsDTO();
        }

        // GET: api/Grupos/5
        [Route("grupos/{id}", Name="GetGrupoById")]
        [ResponseType(typeof(GrupoDTO))]
        public IHttpActionResult GetGrupo(int id)
        {
            Grupo grupo = _repo.Find(e => e.Id == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return Ok(grupo.AsDTO());
        }

        // PUT: api/Grupos/5
        [Route("grupos/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGrupo(int id, GrupoDTO grupoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grupoDTO.Id)
            {
                return BadRequest();
            }

            Grupo g = _repo.Find(e => e.Id == id);

            if (g != null)
            {
                try
                {
                    GrupoDTOtoGrupo(ref g, grupoDTO);
                    _repo.Update(g, id);
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

        // POST: api/Grupos
        [Route("grupos")]
        [ResponseType(typeof(GrupoDTO))]
        public IHttpActionResult PostGrupo(GrupoDTO grupoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Grupo g = new Grupo();
            GrupoDTOtoGrupo(ref g, grupoDTO);

            _repo.Add(g);

            grupoDTO.Id = g.Id;

            return CreatedAtRoute("GetGrupoByID", new { id = grupoDTO.Id }, grupoDTO);
        }

        // DELETE: api/Grupos/5
        [Route("grupos/{id}")]
        [ResponseType(typeof(GrupoDTO))]
        public IHttpActionResult DeleteGrupo(int id)
        {
            Grupo grupo = _repo.Find(e => e.Id == id);
            if (grupo == null)
            {
                return NotFound();
            }

            _repo.Delete(grupo);

            return Ok(grupo.AsDTO());
        }

        private void GrupoDTOtoGrupo(ref Grupo g, GrupoDTO grupoDTO)
        {
            g.Nombre = grupoDTO.Nombre;
        }
    }
}