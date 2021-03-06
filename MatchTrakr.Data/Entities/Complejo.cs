﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchTrakr.Data.Entities
{
    [Table("Complejos")]
    public class Complejo
    {
        public Complejo()
        {
            this.Canchas = new HashSet<Cancha>();
            this.FechaAlta = DateTime.Now;
        }

        public int Id { get; set; }
        public string Nombre {get; set; }
        public string Descripcion { get; set; }
        public string Direccion {get; set; }
        public string Telefono { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual ICollection<Cancha> Canchas { get; set; }  
    }
}
