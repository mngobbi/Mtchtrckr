using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTrakr.Data.Entities
{
    class Invitacion
    {
        public int IdUsuario { get; set; }
        public int IdGrupo { get; set; }
        public int IdPartido { get; set; }
        public bool? Asistencia { get; set; }
        public DateTime TSEnvio { get; set; }
        public DateTime? TSLectura { get; set; }

        public virtual Partido Partido { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
