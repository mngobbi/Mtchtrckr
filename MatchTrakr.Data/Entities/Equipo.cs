using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MatchTrakr.Data.Entities
{
    public class Equipo
    {
        public Equipo()
        {
            this.Partidos = new HashSet<Partido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        //public virtual List<Usuario> Jugadores { get; set; }
        public virtual ICollection<Partido> Partidos { get; set; }
    }
}
