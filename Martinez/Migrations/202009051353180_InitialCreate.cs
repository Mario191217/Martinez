namespace Martinez.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        IdEmpleado = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Cargo = c.String(),
                        Direccion = c.String(),
                        DUI = c.String(),
                        NIT = c.String(),
                        Email = c.String(),
                        ContactoEmergencia = c.String(),
                        TelefonoEmergencia = c.String(),
                        Observaciones = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        IdEstado = c.Int(nullable: false),
                        IdGenero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdEmpleado)
                .ForeignKey("dbo.Estados", t => t.IdEstado, cascadeDelete: true)
                .ForeignKey("dbo.Generos", t => t.IdGenero, cascadeDelete: true)
                .Index(t => t.IdEstado)
                .Index(t => t.IdGenero);
            
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        IdEstado = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.IdEstado);
            
            CreateTable(
                "dbo.Generos",
                c => new
                    {
                        IdGenero = c.Int(nullable: false, identity: true),
                        Genero = c.String(),
                    })
                .PrimaryKey(t => t.IdGenero);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Password = c.String(),
                        IdRol = c.Int(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Empleados", t => t.IdEmpleado, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.IdRol, cascadeDelete: true)
                .Index(t => t.IdRol)
                .Index(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        IdRol = c.Int(nullable: false, identity: true),
                        Rol = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdRol);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "IdRol", "dbo.Roles");
            DropForeignKey("dbo.Usuarios", "IdEmpleado", "dbo.Empleados");
            DropForeignKey("dbo.Empleados", "IdGenero", "dbo.Generos");
            DropForeignKey("dbo.Empleados", "IdEstado", "dbo.Estados");
            DropIndex("dbo.Usuarios", new[] { "IdEmpleado" });
            DropIndex("dbo.Usuarios", new[] { "IdRol" });
            DropIndex("dbo.Empleados", new[] { "IdGenero" });
            DropIndex("dbo.Empleados", new[] { "IdEstado" });
            DropTable("dbo.Roles");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Generos");
            DropTable("dbo.Estados");
            DropTable("dbo.Empleados");
        }
    }
}
