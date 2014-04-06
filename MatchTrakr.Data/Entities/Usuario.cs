using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MatchTrakr.Data.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            this.GruposInfo = new HashSet<UsuarioGrupo>();
            this.PartidosInfo = new HashSet<UsuarioPartido>();
            this.Invitaciones = new HashSet<Invitacion>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? FacebookId { get; set; }
        public int? Telefono { get; set; }
        public UsuarioEstado? EstadoId { get; set; }
        public string EstadoDetalle { get; set; }
        public bool? Activo { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual ICollection<UsuarioGrupo> GruposInfo { get; set; }
        public virtual ICollection<UsuarioPartido> PartidosInfo { get; set; }
        public virtual ICollection<Invitacion> Invitaciones { get; set; }
        //public virtual List<Equipo> Equipos { get; set; }
    }
}
