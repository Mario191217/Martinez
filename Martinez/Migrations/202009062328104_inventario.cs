namespace Martinez.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articulos",
                c => new
                    {
                        IdArticulo = c.Int(nullable: false, identity: true),
                        Articulo = c.String(),
                        Cantidad = c.Double(nullable: false),
                        Precio = c.Double(nullable: false),
                        Descripcion = c.String(),
                        UltimaCompra = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdArticulo);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        Categoria = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdCategoria);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Categorias");
            DropTable("dbo.Articulos");
        }
    }
}
