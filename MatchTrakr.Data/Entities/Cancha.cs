using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MatchTrakr.Data.Entities
{
   [Table("Canchas")]
    public class Cancha
    {
        public Cancha()
        {
            this.Reservas = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public int ComplejoId { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int DeltaMinutos { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
        public virtual Complejo Complejo { get; set; }
    }
}
