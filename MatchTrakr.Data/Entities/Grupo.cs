using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchTrakr.Data.Entities
{
    [Table("Grupos")]
    public class Grupo
    {
        public Grupo()
        {
            this.UsuariosInfo = new HashSet<UsuarioGrupo>();
            this.Partidos = new HashSet<Partido>();
            this.Invitaciones = new HashSet<Invitacion>();
            this.FechaAlta = DateTime.Now;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual ICollection<UsuarioGrupo> UsuariosInfo { get; set; }
        public virtual ICollection<Partido> Partidos { get; set; }
        public virtual ICollection<Invitacion> Invitaciones { get; set; }
    }
}
