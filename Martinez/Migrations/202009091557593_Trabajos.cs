namespace Martinez.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trabajos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonos",
                c => new
                    {
                        IdAbono = c.Int(nullable: false, identity: true),
                        Abono = c.Double(nullable: false),
                        IdTrabajo = c.Int(nullable: false),
                        FechaAbono = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdAbono)
                .ForeignKey("dbo.Trabajos", t => t.IdTrabajo, cascadeDelete: true)
                .Index(t => t.IdTrabajo);
            
            CreateTable(
                "dbo.Trabajos",
                c => new
                    {
                        IdTrabajo = c.Int(nullable: false, identity: true),
                        Trabajo = c.String(),
                        IdEmpleado = c.Int(nullable: false),
                        Comision = c.Double(nullable: false),
                        CostoTotal = c.Double(nullable: false),
                        MontoTotal = c.Double(nullable: false),
                        Rentabilidad = c.Double(nullable: false),
                        Ubicacion = c.String(),
                        IdCliente = c.Int(nullable: false),
                        Abono = c.Double(nullable: false),
                        Saldo = c.Double(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        FechaFinalizacion = c.DateTime(nullable: false),
                        Terminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdTrabajo)
                .ForeignKey("dbo.Clientes", t => t.IdCliente, cascadeDelete: true)
                .ForeignKey("dbo.Empleados", t => t.IdEmpleado, cascadeDelete: true)
                .Index(t => t.IdEmpleado)
                .Index(t => t.IdCliente);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Cliente = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        DUI = c.String(),
                        NIT = c.String(),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.TrabajoProyectoes",
                c => new
                    {
                        IdTrabajoProyecto = c.Int(nullable: false, identity: true),
                        IdTrabajo = c.Int(nullable: false),
                        IdProyecto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTrabajoProyecto)
                .ForeignKey("dbo.Proyectos", t => t.IdProyecto, cascadeDelete: true)
                .ForeignKey("dbo.Trabajos", t => t.IdTrabajo, cascadeDelete: true)
                .Index(t => t.IdTrabajo)
                .Index(t => t.IdProyecto);
            
            CreateTable(
                "dbo.Proyectos",
                c => new
                    {
                        IdProyecto = c.Int(nullable: false, identity: true),
                        Proyecto = c.String(),
                        Costo = c.Double(nullable: false),
                        Monto = c.Double(nullable: false),
                        Rentabilidad = c.Double(nullable: false),
                        Terminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdProyecto);
            
            CreateTable(
                "dbo.DetalleProyectoes",
                c => new
                    {
                        IdDetalle = c.Int(nullable: false, identity: true),
                        IdArticulo = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetalle)
                .ForeignKey("dbo.Articulos", t => t.IdArticulo, cascadeDelete: true)
                .Index(t => t.IdArticulo);
            
            AddColumn("dbo.Articulos", "IdCategoria", c => c.Int(nullable: false));
            CreateIndex("dbo.Articulos", "IdCategoria");
            AddForeignKey("dbo.Articulos", "IdCategoria", "dbo.Categorias", "IdCategoria", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleProyectoes", "IdArticulo", "dbo.Articulos");
            DropForeignKey("dbo.Articulos", "IdCategoria", "dbo.Categorias");
            DropForeignKey("dbo.TrabajoProyectoes", "IdTrabajo", "dbo.Trabajos");
            DropForeignKey("dbo.TrabajoProyectoes", "IdProyecto", "dbo.Proyectos");
            DropForeignKey("dbo.Trabajos", "IdEmpleado", "dbo.Empleados");
            DropForeignKey("dbo.Trabajos", "IdCliente", "dbo.Clientes");
            DropForeignKey("dbo.Abonos", "IdTrabajo", "dbo.Trabajos");
            DropIndex("dbo.DetalleProyectoes", new[] { "IdArticulo" });
            DropIndex("dbo.Articulos", new[] { "IdCategoria" });
            DropIndex("dbo.TrabajoProyectoes", new[] { "IdProyecto" });
            DropIndex("dbo.TrabajoProyectoes", new[] { "IdTrabajo" });
            DropIndex("dbo.Trabajos", new[] { "IdCliente" });
            DropIndex("dbo.Trabajos", new[] { "IdEmpleado" });
            DropIndex("dbo.Abonos", new[] { "IdTrabajo" });
            DropColumn("dbo.Articulos", "IdCategoria");
            DropTable("dbo.DetalleProyectoes");
            DropTable("dbo.Proyectos");
            DropTable("dbo.TrabajoProyectoes");
            DropTable("dbo.Clientes");
            DropTable("dbo.Trabajos");
            DropTable("dbo.Abonos");
        }
    }
}
