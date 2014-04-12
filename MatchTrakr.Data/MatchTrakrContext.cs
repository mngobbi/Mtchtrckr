using MatchTrakr.Data.Entities;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MatchTrakr.Data
{
    public class MatchTrakrContext : IdentityDbContext<Usuario>
    {
        public MatchTrakrContext() :
            base("DefaultConnection")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<MatchTrakrContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MatchTrakrContext,MatchTrakr.Data.Migrations.Configuration>());
        }

        public virtual DbSet<Cancha> Canchas { get; set; }
        public virtual DbSet<Complejo> Complejos { get; set; }
        //public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Invitacion> Invitaciones { get; set; }
        public virtual DbSet<Partido> Partidos { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<UsuarioGrupo> UsuariosGrupos { get; set; }
        public virtual DbSet<UsuarioPartido> UsuariosPartidos { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cancha>()
                .HasMany(e => e.Reservas)
                .WithRequired(e => e.Cancha).HasForeignKey(e => e.CanchaId);

            modelBuilder.Entity<Complejo>()
                .HasMany(e => e.Canchas)
                .WithRequired(e => e.Complejo).HasForeignKey(e => e.ComplejoId);

            //modelBuilder.Entity<Equipo>()
            //    .HasMany(e => e.Partidos)
            //    .WithOptional(p => p.EquipoA).HasForeignKey(e => e.EquipoAId);

            //modelBuilder.Entity<Equipo>()
            //    .HasMany(e => e.Partidos)
            //    .WithOptional(p => p.EquipoB).HasForeignKey(e => e.EquipoBId);

            modelBuilder.Entity<Grupo>()
                .HasMany(e => e.Partidos)
                .WithRequired(e => e.Grupo).HasForeignKey(e => e.GrupoId);

            modelBuilder.Entity<Grupo>()
                .HasMany(e => e.Partidos)
                .WithOptional(e => e.GrupoB).HasForeignKey(e => e.GrupoBId);

            modelBuilder.Entity<Grupo>()
                .HasMany(e => e.UsuariosInfo)
                .WithRequired(e => e.Grupo).HasForeignKey(e => e.GrupoId);

            //modelBuilder.Entity<Grupo>()
            //    .HasMany(e => e.Invitaciones)
            //    .WithRequired(e => e.Grupo).HasForeignKey(e => e.GrupoId);

            modelBuilder.Entity<Partido>()
                .HasMany(e => e.UsuariosInfo)
                .WithRequired(e => e.Partido).HasForeignKey(e => e.PartidoId);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.GruposInfo)
                .WithRequired(e => e.Usuario).HasForeignKey(e => e.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.PartidosInfo)
                .WithRequired(e => e.Usuario).HasForeignKey(e => e.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Invitaciones)
                .WithRequired(e => e.Usuario).HasForeignKey(e => e.UsuarioId);

            modelBuilder.Entity<Grupo>()
                .HasMany(e=> e.Invitaciones).WithRequired(e=> e.Grupo).HasForeignKey(e => e.GrupoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Partido>()
                .HasMany(e => e.Invitaciones).WithRequired(e => e.Partido).HasForeignKey(e => e.PartidoId);

            modelBuilder.Entity<Partido>()
                .HasRequired(e => e.Reserva)
                .WithOptional(e => e.Partido);


            base.OnModelCreating(modelBuilder);
        }

        public static MatchTrakrContext Create()
        {
            return new MatchTrakrContext();
        }
    }
}
