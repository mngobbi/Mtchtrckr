using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTrakr.Data.Entities
{
    class UsuarioGrupo
    {
        public int IdGrupo { get; set; }
        public int IdJugador { get; set; }
        public int Prioridad { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
