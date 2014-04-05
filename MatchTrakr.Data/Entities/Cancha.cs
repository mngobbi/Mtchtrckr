using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTrakr.Data.Entities
{
    class Cancha
    {
        public int Id { get; set; }
        public int ComplejoId { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public virtual List<Reserva> Reservas { get; set; }
        public virtual Complejo Complejo { get; set; }
    }
}
