using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTrakr.Data.Entities
{
    class Grupo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual List<Usuario> Usuarios { get; set; }
        public virtual List<Partido> Partidos { get; set; }
        public virtual List<Invitacion> Invitaciones { get; set; }
    }
}
