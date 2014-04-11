namespace MatchTrakr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Identity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuariosGrupos", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Invitaciones", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuariosPartidos", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Usuarios");
            DropIndex("dbo.Invitaciones", new[] { "UsuarioId" });
            DropIndex("dbo.UsuariosGrupos", new[] { "UsuarioId" });
            DropIndex("dbo.UsuariosPartidos", new[] { "UsuarioId" });
            DropPrimaryKey("dbo.Usuarios");
            DropPrimaryKey("dbo.UsuariosGrupos");
            DropPrimaryKey("dbo.UsuariosPartidos");
            RenameTable(name: "dbo.Usuarios", newName: "AspNetUsers");
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            AddColumn("dbo.AspNetUsers", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PasswordHash", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecurityStamp", c => c.String());
            AddColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AccessFailedCount", c => c.Int(nullable: false));
            AlterColumn("dbo.Invitaciones", "UsuarioId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.AspNetUsers", "Id");
            AddColumn("dbo.AspNetUsers", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.UsuariosGrupos", "UsuarioId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UsuariosPartidos", "UsuarioId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            AddPrimaryKey("dbo.UsuariosGrupos", new[] { "UsuarioId", "GrupoId" });
            AddPrimaryKey("dbo.UsuariosPartidos", new[] { "UsuarioId", "PartidoId" });
            CreateIndex("dbo.Invitaciones", "UsuarioId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.UsuariosGrupos", "UsuarioId");
            CreateIndex("dbo.UsuariosPartidos", "UsuarioId");
            AddForeignKey("dbo.UsuariosGrupos", "UsuarioId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Invitaciones", "UsuarioId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsuariosPartidos", "UsuarioId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.AspNetUsers", "FacebookId");
            DropColumn("dbo.AspNetUsers", "Telefono");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Telefono", c => c.Int());
            AddColumn("dbo.AspNetUsers", "FacebookId", c => c.Int());
            DropForeignKey("dbo.UsuariosPartidos", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Invitaciones", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsuariosGrupos", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.UsuariosPartidos", new[] { "UsuarioId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.UsuariosGrupos", new[] { "UsuarioId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Invitaciones", new[] { "UsuarioId" });
            DropPrimaryKey("dbo.UsuariosPartidos");
            DropPrimaryKey("dbo.UsuariosGrupos");
            DropPrimaryKey("dbo.AspNetUsers");
            AlterColumn("dbo.UsuariosPartidos", "UsuarioId", c => c.Int(nullable: false));
            AlterColumn("dbo.UsuariosGrupos", "UsuarioId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String());
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Invitaciones", "UsuarioId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "AccessFailedCount");
            DropColumn("dbo.AspNetUsers", "LockoutEnabled");
            DropColumn("dbo.AspNetUsers", "LockoutEndDateUtc");
            DropColumn("dbo.AspNetUsers", "TwoFactorEnabled");
            DropColumn("dbo.AspNetUsers", "PhoneNumberConfirmed");
            DropColumn("dbo.AspNetUsers", "PhoneNumber");
            DropColumn("dbo.AspNetUsers", "SecurityStamp");
            DropColumn("dbo.AspNetUsers", "PasswordHash");
            DropColumn("dbo.AspNetUsers", "EmailConfirmed");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            AddPrimaryKey("dbo.UsuariosPartidos", new[] { "UsuarioId", "PartidoId" });
            AddPrimaryKey("dbo.UsuariosGrupos", new[] { "UsuarioId", "GrupoId" });
            AddPrimaryKey("dbo.Usuarios", "Id");
            CreateIndex("dbo.UsuariosPartidos", "UsuarioId");
            CreateIndex("dbo.UsuariosGrupos", "UsuarioId");
            CreateIndex("dbo.Invitaciones", "UsuarioId");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsuariosPartidos", "UsuarioId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Invitaciones", "UsuarioId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsuariosGrupos", "UsuarioId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.AspNetUsers", newName: "Usuarios");
        }
    }
}
