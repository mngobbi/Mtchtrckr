using MatchTrakr.Data.Entities;
using MatchTrakr.Data.Mappers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTrakr.Data
{
   public class MatchTrakrContext:DbContext
    {
       public MatchTrakrContext() :
            base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MatchTrakrContext, MatchTrakrContextMigrationConfiguration>());
        }

        public virtual DbSet<Cancha> Canchas { get; set; }
        public virtual DbSet<Complejo> Complejos { get; set; }
        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Invitacion> Invitaciones { get; set; }
        public virtual DbSet<Partido> Partidos { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioGrupo> UsuariosGrupos { get; set; }

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Cancha>() 
              .HasMany(e => e.Reservas)
              .WithRequired(e => e.Cancha)
              .HasForeignKey(e => e.CanchaId)

         modelBuilder.Entity<Complejo>()
             .HasMany(e => e.Canchas)
             .WithRequired(e => e.Complejo)
             .HasForeignKey(e => e.ComplejoId)

            base.OnModelCreating(modelBuilder);
        }
    }
}
