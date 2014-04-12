using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MatchTrakr.Data.Entities
{
    public class Usuario : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public Usuario()
        {
            this.GruposInfo = new HashSet<UsuarioGrupo>();
            this.PartidosInfo = new HashSet<UsuarioPartido>();
            this.Invitaciones = new HashSet<Invitacion>();
        }

        //public int? FacebookId { get; set; }
        public UsuarioEstado? EstadoId { get; set; }
        public string EstadoDetalle { get; set; }
        public bool? Activo { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual ICollection<UsuarioGrupo> GruposInfo { get; set; }
        public virtual ICollection<UsuarioPartido> PartidosInfo { get; set; }
        public virtual ICollection<Invitacion> Invitaciones { get; set; }
        //public virtual List<Equipo> Equipos { get; set; }
    }
}
