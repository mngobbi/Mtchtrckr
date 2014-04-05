using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTrakr.Data.Entities
{
    class Complejo
    {
        public int Id { get; set; }
        public string Nombre {get; set; }
        public string Direccion {get; set; }
        public string Telefono { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual List<Cancha> Canchas { get; set; }  
    }
}
