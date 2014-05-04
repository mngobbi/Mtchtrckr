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
    public class PartidosController : ApiController
    {
        private readonly PartidosRepository _repo;

        public PartidosController()
        {
            _repo = new PartidosRepository(new MatchTrakrContext());
        }

        // GET: api/Partidos
        [Route("partidos")]
        public IEnumerable<PartidoDTO> GetPartidos()
        {
            return _repo.GetAll().AsDTO();
        }

        // GET: api/Partidos/5
        [Route("partidos/{id}", Name = "GetPartidoById")]
        [ResponseType(typeof(PartidoDTO))]
        public IHttpActionResult GetPartido(int id)
        {
            Partido partido = _repo.Find(e => e.Id == id);
            if (partido == null)
            {
                return NotFound();
            }

            return Ok(partido.AsDTO());
        }

        // PUT: api/Partidos/5
        [Route("partidos/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartido(int id, PartidoDTO partidoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partidoDTO.Id)
            {
                return BadRequest();
            }

            Partido p = _repo.Find(e => e.Id == id);

            if (p != null)
            {
                try
                {
                    DTOToEntity(ref p, partidoDTO);
                    _repo.Update(p, id);
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

        // POST: api/Partidos
        [Route("partidos")]
        [ResponseType(typeof(PartidoDTO))]
        public IHttpActionResult PostPartido(PartidoDTO partidoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Partido p = new Partido();
            DTOToEntity(ref p, partidoDTO);

            _repo.Add(p);

            partidoDTO.Id = p.Id;

            return CreatedAtRoute("GetPartidoByID", new { id = partidoDTO.Id }, partidoDTO);
        }

        // DELETE: api/Partidos/5
        [Route("partidos/{id}")]
        [ResponseType(typeof(PartidoDTO))]
        public IHttpActionResult DeletePartido(int id)
        {
            Partido partido = _repo.Find(e => e.Id == id);
            if (partido == null)
            {
                return NotFound();
            }

            _repo.Delete(partido);

            return Ok(partido.AsDTO());
        }

        private void DTOToEntity(ref Partido p, PartidoDTO partidoDTO)
        {
            p.GrupoId = partidoDTO.GrupoId;
            p.ReservaId = partidoDTO.ReservaId;
            p.Fecha = partidoDTO.Fecha;
            p.EquipoARdo = partidoDTO.EquipoARdo;
            p.EquipoBRdo = partidoDTO.EquipoBRdo;
            p.UsuariosInfo.Clear();
            if (partidoDTO.Jugadores.Length > 0)
            {
                List<UsuarioPartido> jugadores = new List<UsuarioPartido>();
                foreach (var e in partidoDTO.Jugadores)
                {
                    UsuarioPartido up = new UsuarioPartido();
                    up.Partido = p;
                    up.UsuarioId = e.Id;
                    if (e.EquipoA != null)
                    {
                        up.EquipoA = e.EquipoA;
                    }
                    jugadores.Add(up);
                }
                p.UsuariosInfo = jugadores;
            }
        }
    }
}