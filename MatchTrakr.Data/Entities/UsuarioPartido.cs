using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchTrakr.Data.Entities
{
    public class UsuarioPartido
    {
        [Key]
        [Column(Order=0)]
        public int UsuarioId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int PartidoId { get; set; }
        public bool? EquipoA { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Partido Partido { get; set; }
    }
}
