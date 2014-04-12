namespace MatchTrakr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Canchas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComplejoId = c.Int(nullable: false),
                        Nombre = c.String(),
                        Precio = c.Int(nullable: false),
                        DeltaMinutos = c.Int(nullable: false),
                        HoraInicio = c.DateTime(nullable: false),
                        HoraFin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Complejos", t => t.ComplejoId, cascadeDelete: true)
                .Index(t => t.ComplejoId);
            
            CreateTable(
                "dbo.Complejos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        FechaAlta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CanchaId = c.Int(nullable: false),
                        PartidoId = c.Int(),
                        FechaHora = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Canchas", t => t.CanchaId, cascadeDelete: true)
                .Index(t => t.CanchaId);
            
            CreateTable(
                "dbo.Partidos",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        GrupoId = c.Int(nullable: false),
                        GrupoBId = c.Int(),
                        EquipoAId = c.Int(),
                        EquipoBId = c.Int(),
                        ReservaId = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        EquipoARdo = c.Int(),
                        EquipoBRdo = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grupos", t => t.GrupoBId)
                .ForeignKey("dbo.Grupos", t => t.GrupoId, cascadeDelete: true)
                .ForeignKey("dbo.Reservas", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.GrupoId)
                .Index(t => t.GrupoBId);
            
            CreateTable(
                "dbo.Grupos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaAlta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invitaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        GrupoId = c.Int(nullable: false),
                        PartidoId = c.Int(nullable: false),
                        Asistencia = c.Boolean(),
                        TSEnvio = c.DateTime(nullable: false),
                        TSLectura = c.DateTime(),
                        Detalle = c.String(),
                        Respuesta = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.Grupos", t => t.GrupoId)
                .ForeignKey("dbo.Partidos", t => t.PartidoId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.GrupoId)
                .Index(t => t.PartidoId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        FacebookId = c.Int(),
                        Telefono = c.Int(),
                        EstadoId = c.Int(),
                        EstadoDetalle = c.String(),
                        Activo = c.Boolean(),
                        FechaAlta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsuariosGrupos",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false),
                        GrupoId = c.Int(nullable: false),
                        Prioridad = c.Int(),
                        IsAdmin = c.Boolean(),
                        FechaAlta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UsuarioId, t.GrupoId })
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.Grupos", t => t.GrupoId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.GrupoId);
            
            CreateTable(
                "dbo.UsuariosPartidos",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false),
                        PartidoId = c.Int(nullable: false),
                        EquipoA = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.UsuarioId, t.PartidoId })
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.Partidos", t => t.PartidoId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.PartidoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservas", "CanchaId", "dbo.Canchas");
            DropForeignKey("dbo.UsuariosPartidos", "PartidoId", "dbo.Partidos");
            DropForeignKey("dbo.Partidos", "Id", "dbo.Reservas");
            DropForeignKey("dbo.Invitaciones", "PartidoId", "dbo.Partidos");
            DropForeignKey("dbo.Partidos", "GrupoId", "dbo.Grupos");
            DropForeignKey("dbo.UsuariosGrupos", "GrupoId", "dbo.Grupos");
            DropForeignKey("dbo.Partidos", "GrupoBId", "dbo.Grupos");
            DropForeignKey("dbo.Invitaciones", "GrupoId", "dbo.Grupos");
            DropForeignKey("dbo.UsuariosPartidos", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Invitaciones", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuariosGrupos", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Canchas", "ComplejoId", "dbo.Complejos");
            DropIndex("dbo.UsuariosPartidos", new[] { "PartidoId" });
            DropIndex("dbo.UsuariosPartidos", new[] { "UsuarioId" });
            DropIndex("dbo.UsuariosGrupos", new[] { "GrupoId" });
            DropIndex("dbo.UsuariosGrupos", new[] { "UsuarioId" });
            DropIndex("dbo.Invitaciones", new[] { "PartidoId" });
            DropIndex("dbo.Invitaciones", new[] { "GrupoId" });
            DropIndex("dbo.Invitaciones", new[] { "UsuarioId" });
            DropIndex("dbo.Partidos", new[] { "GrupoBId" });
            DropIndex("dbo.Partidos", new[] { "GrupoId" });
            DropIndex("dbo.Partidos", new[] { "Id" });
            DropIndex("dbo.Reservas", new[] { "CanchaId" });
            DropIndex("dbo.Canchas", new[] { "ComplejoId" });
            DropTable("dbo.UsuariosPartidos");
            DropTable("dbo.UsuariosGrupos");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Invitaciones");
            DropTable("dbo.Grupos");
            DropTable("dbo.Partidos");
            DropTable("dbo.Reservas");
            DropTable("dbo.Complejos");
            DropTable("dbo.Canchas");
        }
    }
}
