using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchTrakr.Data.Entities
{
    [Table("UsuariosGrupos")]
    public class UsuarioGrupo
    {
        [Key]
        [Column(Order = 0)]
        public int UsuarioId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int GrupoId { get; set; }
        public int? Prioridad { get; set; }
        public bool? IsAdmin { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
