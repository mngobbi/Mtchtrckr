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
    [RoutePrefix("api/")]
    public class GruposController : ApiController
    {
        private readonly IMatchTrakrRepository _repo;

        public GruposController(IMatchTrakrRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Grupos
        [Route("grupos")]
        public IEnumerable<GrupoDTO> GetGrupos()
        {
            return _repo.AllGrupos().AsDTO();
        }

        // GET: api/Grupos/5
        [Route("grupos/{id}")]
        [ResponseType(typeof(Grupo))]
        public IHttpActionResult GetGrupo(int id)
        {
            Grupo grupo = _repo.FindGrupo(id);
            if (grupo == null)
            {
                return NotFound();
            }

            return Ok(grupo.AsDTO());
        }

        // PUT: api/Grupos/5
        [Route("grupos/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGrupo(int id, GrupoDTO grupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grupo.Id)
            {
                return BadRequest();
            }

            try
            {
                _repo.UpdateGrupo(grupo.Id, grupo.Nombre);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repo.GrupoExists(id))
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

        // POST: api/Grupos
        [Route("grupos")]
        [ResponseType(typeof(GrupoDTO))]
        public IHttpActionResult PostGrupo(GrupoDTO grupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.AddGrupo(grupo.Id, grupo.Nombre);

            return CreatedAtRoute("DefaultApi", new { id = grupo.Id }, grupo);
        }

        // DELETE: api/Grupos/5
        [Route("grupos/{id}")]
        [ResponseType(typeof(GrupoDTO))]
        public IHttpActionResult DeleteGrupo(int id)
        {
            Grupo grupo = _repo.FindGrupo(id);
            if (grupo == null)
            {
                return NotFound();
            }

            _repo.RemoveGrupo(grupo);

            return Ok(grupo.AsDTO());
        }
    }
}