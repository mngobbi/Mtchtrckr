using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MatchTrakr.Data.Entities;

namespace MatchTrakr.Web.DTO
{
    public class ComplejoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaAlta { get; set; }
        public CanchaDTO[] Canchas {get; set;}

        public ComplejoDTO(Complejo c)
        {
            this.Id = c.Id;
            this.Nombre = c.Nombre;
            this.Descripcion = c.Descripcion;
            this.Direccion = c.Direccion;
            this.Telefono = c.Telefono;
            this.FechaAlta = c.FechaAlta;
            List<CanchaDTO> listaCanchas = new List<CanchaDTO>();
            foreach (Cancha ch in c.Canchas)
            {
                listaCanchas.Add(new CanchaDTO(ch));
            }
            this.Canchas = listaCanchas.ToArray();
        }

        public ComplejoDTO()
        {

        }
    }

    public class CanchaDTO 
    {
        public int Id { get; set; }
        public int ComplejoId { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public CanchaDTO(Cancha ch)
        {
            this.Id = ch.Id;
            this.ComplejoId = ch.ComplejoId;
            this.Nombre = ch.Nombre;
            this.Precio = ch.Precio;
        }

        public CanchaDTO()
        {

        }
    }

    public class GrupoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public GrupoDTO()
        {

        }

        public GrupoDTO(Grupo g)
        {
            this.Id = g.Id;
            this.Nombre = g.Nombre;
        }
    }
}