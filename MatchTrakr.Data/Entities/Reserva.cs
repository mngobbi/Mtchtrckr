using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchTrakr.Data.Entities
{
    [Table("Reservas")]
    public class Reserva
    {
        public int Id { get; set; }
        public int CanchaId { get; set; }
        public int? PartidoId { get; set; }
        public DateTime FechaHora { get; set; }

        public virtual Cancha Cancha { get; set; }
        public virtual Partido Partido { get; set; }
    }
}
