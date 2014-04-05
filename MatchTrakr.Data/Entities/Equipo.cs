using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTrakr.Data.Entities
{
    class Equipo
    {
        public int Id { get; set; }

        public virtual List<Usuario> Jugadores { get; set; }
        public virtual List<Partido> Partidos { get; set; }
    }
}
