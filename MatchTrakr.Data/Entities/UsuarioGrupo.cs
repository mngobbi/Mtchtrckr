﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MatchTrakr.Data.Entities
{
    public class UsuarioGrupo
    {
        [Key]
        public int GrupoId { get; set; }
        [Key]
        public int UsuarioId { get; set; }
        public int? Prioridad { get; set; }
        public bool? IsAdmin { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
