namespace InventarioControlTry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movimientoes",
                c => new
                    {
                        MovimientoId = c.Int(nullable: false, identity: true),
                        FechaGenerado = c.DateTime(nullable: false, precision: 0),
                        FechaConcluido = c.DateTime(nullable: false, precision: 0),
                        Usuario = c.String(maxLength: 250, storeType: "nvarchar"),
                        Terminal = c.String(maxLength: 250, storeType: "nvarchar"),
                        alm_origen = c.String(maxLength: 128, storeType: "nvarchar"),
                        alm_destino = c.String(maxLength: 128, storeType: "nvarchar"),
                        cantidad = c.Double(nullable: false),
                        unidad = c.String(maxLength: 250, storeType: "nvarchar"),
                        Factor = c.Double(nullable: false),
                        FechaEntrada = c.DateTime(precision: 0),
                        ubicacion_destino = c.String(maxLength: 128, storeType: "nvarchar"),
                        ubicacion_origen = c.String(maxLength: 128, storeType: "nvarchar"),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Almacen_AlmacenId = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.MovimientoId)
                .ForeignKey("dbo.Almacens", t => t.Almacen_AlmacenId)
                .ForeignKey("dbo.Almacens", t => t.alm_destino)
                .ForeignKey("dbo.Almacens", t => t.alm_origen)
                .Index(t => t.alm_origen)
                .Index(t => t.alm_destino)
                .Index(t => t.Almacen_AlmacenId);
            
            CreateTable(
                "dbo.Almacens",
                c => new
                    {
                        almacen = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Descripcion = c.String(maxLength: 250, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.almacen);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movimientoes", "alm_origen", "dbo.Almacens");
            DropForeignKey("dbo.Movimientoes", "alm_destino", "dbo.Almacens");
            DropForeignKey("dbo.Movimientoes", "Almacen_AlmacenId", "dbo.Almacens");
            DropIndex("dbo.Movimientoes", new[] { "Almacen_AlmacenId" });
            DropIndex("dbo.Movimientoes", new[] { "alm_destino" });
            DropIndex("dbo.Movimientoes", new[] { "alm_origen" });
            DropTable("dbo.Almacens");
            DropTable("dbo.Movimientoes");
        }
    }
}
