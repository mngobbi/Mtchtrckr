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

        public static PartidoDTO AsDTO(this Partido p)
        {
            return new PartidoDTO(p);
        }

        public static IEnumerable<PartidoDTO> AsDTO(this IEnumerable<Partido> p)
        {
            List<PartidoDTO> partidos = new List<PartidoDTO>();
            foreach (var e in p)
            {
                partidos.Add(new PartidoDTO(e));
            }
            return partidos.AsEnumerable();
        }

        public static ComplejoDTO AsDTO(this Complejo c)
        {
            return new ComplejoDTO(c);
        }

        public static IEnumerable<ComplejoDTO> AsDTO(this IEnumerable<Complejo> c)
        {
            List<ComplejoDTO> complejos = new List<ComplejoDTO>();
            foreach (var e in c)
            {
                complejos.Add(new ComplejoDTO(e));
            }
            return complejos.AsEnumerable();
        }
    }
        
}