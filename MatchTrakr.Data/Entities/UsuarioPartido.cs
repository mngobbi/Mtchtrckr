using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MatchTrakr.Data.Entities
{
    public class UsuarioPartido
    {
        [Key]
        public int UsuarioId { get; set; }
        [Key]
        public int PartidoId { get; set; }
        public bool? EquipoA { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Partido Partido { get; set; }
    }
}
