using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchTrakr.Data.Entities
{
    [Table("Partidos")]
    public class Partido
    {
        public Partido()
        {
            this.UsuariosInfo = new HashSet<UsuarioPartido>();
            this.Invitaciones = new HashSet<Invitacion>();
        }

        public int Id { get; set; }
        public int GrupoId { get; set; }
        public int? GrupoBId { get; set; }
        public int? EquipoAId { get; set; }
        public int? EquipoBId { get; set; }
        public int ReservaId { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime Fecha { get; set; }
        public int? EquipoARdo { get; set; }
        public int? EquipoBRdo { get; set; }

        //public virtual Equipo EquipoA { get; set; }
        //public virtual Equipo EquipoB { get; set; }
        public virtual Reserva Reserva { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual Grupo GrupoB { get; set; }
        public virtual ICollection<UsuarioPartido> UsuariosInfo { get; set; }
        public virtual ICollection<Invitacion> Invitaciones { get; set; }
    }
}
