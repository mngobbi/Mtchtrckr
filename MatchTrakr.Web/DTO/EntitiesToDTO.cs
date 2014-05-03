using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MatchTrakr.Web.DTO;
using MatchTrakr.Data.Entities;

namespace MatchTrakr.Web.DTO
{
    public static class Extensions {
        public static GrupoDTO AsDTO(this Grupo g)
        {
            return new GrupoDTO(g);
        }

        public static IEnumerable<GrupoDTO> AsDTO(this IEnumerable<Grupo> g)
        {
            List<GrupoDTO> grupos = new List<GrupoDTO>();
            foreach (var e in g)
            {
                grupos.Add(new GrupoDTO(e));
            }
            return grupos.AsEnumerable();
        }
    }
        
}