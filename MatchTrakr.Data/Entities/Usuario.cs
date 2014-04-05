using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace MatchTrakr.Data.Entities
{
    class Usuario
    {
        public int Id { get; set; }
        public int? FacebookId { get; set; }
        public string UserName { get; set; }
        public UsuarioEstado EstadoId { get; set; }
        public string? EstadoDetalle { get; set; }
        public bool? Activo { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual List<UsuarioGrupo> GruposInfo { get; set; }
        public virtual List<Partido> Partidos { get; set; }
        public virtual List<Invitacion> Invitaciones { get; set; }
        public virtual List<Equipo> Equipos { get; set; }
    }
}
