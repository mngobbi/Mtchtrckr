using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTrakr.Data.Entities
{
    class Partido
    {
        public int Id { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime Fecha { get; set; }
        public int IdReserva { get; set; }
        public int? Equipo1Rdo { get; set; }
        public int? Equipo2Rdo { get; set; }

        public virtual Equipo Equipo1 { get; set; }
        public virtual Equipo Equipo2 { get; set; }
        public virtual List<Usuario> Usuarios { get; set; }
    }
}
