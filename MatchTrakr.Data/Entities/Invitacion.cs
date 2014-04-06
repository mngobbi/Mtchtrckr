using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MatchTrakr.Data.Entities
{
    public class Invitacion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int GrupoId { get; set; }
        public int PartidoId { get; set; }
        public bool? Asistencia { get; set; }
        public DateTime TSEnvio { get; set; }
        public DateTime? TSLectura { get; set; }
        public string Detalle { get; set; }
        public string Respuesta { get; set; }

        public virtual Partido Partido { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
