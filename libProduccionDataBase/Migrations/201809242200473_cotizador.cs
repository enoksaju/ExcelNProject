namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cotizador : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cotizaciones_detalle",
                c => new
                    {
                        CotizacionDetalleId = c.Int(nullable: false, identity: true),
                        Cantidad = c.Double(nullable: false),
                        Unidad = c.Int(nullable: false),
                        Cotizamos = c.Double(),
                        Tipo = c.Int(nullable: false),
                        Maquina_Id = c.Int(),
                        Rodillo_Id = c.Int(),
                        AnchoDisenio = c.Double(nullable: false),
                        AltoDisenio = c.Double(),
                        RepeticionesEje = c.Double(nullable: false),
                        RepeticionesDesarrollo = c.Double(),
                        NombreProducto = c.String(nullable: false, unicode: false),
                        Cotizacion_CotizacionId = c.Int(),
                    })
                .PrimaryKey(t => t.CotizacionDetalleId)
                .ForeignKey("dbo.Maquinas", t => t.Maquina_Id)
                .ForeignKey("dbo.Rodillos", t => t.Rodillo_Id)
                .ForeignKey("dbo.cotizaciones", t => t.Cotizacion_CotizacionId)
                .Index(t => t.Maquina_Id)
                .Index(t => t.Rodillo_Id)
                .Index(t => t.Cotizacion_CotizacionId);
            
            CreateTable(
                "dbo.cotizaciones_detalle_decks",
                c => new
                    {
                        CotizacionDetalleId = c.Int(nullable: false),
                        Deck = c.Int(nullable: false),
                        TintaId = c.Int(nullable: false),
                        PorcentajeCobertura = c.Double(nullable: false),
                        GR_MT = c.Double(nullable: false),
                        PORC_SOLID = c.Double(nullable: false),
                        Color = c.String(unicode: false),
                    })
                .PrimaryKey(t => new { t.CotizacionDetalleId, t.Deck })
                .ForeignKey("dbo.cat_tintas", t => t.TintaId, cascadeDelete: true)
                .ForeignKey("dbo.cotizaciones_detalle", t => t.CotizacionDetalleId, cascadeDelete: true)
                .Index(t => t.CotizacionDetalleId)
                .Index(t => t.TintaId);
            
            CreateTable(
                "dbo.cotizaciones_detalle_peliculas",
                c => new
                    {
                        CotizacionDetalleId = c.Int(nullable: false),
                        Uso = c.Int(nullable: false),
                        Material_Id = c.Int(nullable: false),
                        Calibre = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.CotizacionDetalleId, t.Uso })
                .ForeignKey("dbo.Material", t => t.Material_Id, cascadeDelete: true)
                .ForeignKey("dbo.cotizaciones_detalle", t => t.CotizacionDetalleId, cascadeDelete: true)
                .Index(t => t.CotizacionDetalleId)
                .Index(t => t.Material_Id);
            
            CreateTable(
                "dbo.cotizaciones",
                c => new
                    {
                        CotizacionId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        AgenteId = c.Int(nullable: false),
                        DiasVigencia = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.CotizacionId)
                .ForeignKey("dbo.Z_Usuarios", t => t.AgenteId, cascadeDelete: true)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.AgenteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cotizaciones_detalle", "Cotizacion_CotizacionId", "dbo.cotizaciones");
            DropForeignKey("dbo.cotizaciones", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.cotizaciones", "AgenteId", "dbo.Z_Usuarios");
            DropForeignKey("dbo.cotizaciones_detalle", "Rodillo_Id", "dbo.Rodillos");
            DropForeignKey("dbo.cotizaciones_detalle_peliculas", "CotizacionDetalleId", "dbo.cotizaciones_detalle");
            DropForeignKey("dbo.cotizaciones_detalle_peliculas", "Material_Id", "dbo.Material");
            DropForeignKey("dbo.cotizaciones_detalle", "Maquina_Id", "dbo.Maquinas");
            DropForeignKey("dbo.cotizaciones_detalle_decks", "CotizacionDetalleId", "dbo.cotizaciones_detalle");
            DropForeignKey("dbo.cotizaciones_detalle_decks", "TintaId", "dbo.cat_tintas");
            DropIndex("dbo.cotizaciones", new[] { "AgenteId" });
            DropIndex("dbo.cotizaciones", new[] { "ClienteId" });
            DropIndex("dbo.cotizaciones_detalle_peliculas", new[] { "Material_Id" });
            DropIndex("dbo.cotizaciones_detalle_peliculas", new[] { "CotizacionDetalleId" });
            DropIndex("dbo.cotizaciones_detalle_decks", new[] { "TintaId" });
            DropIndex("dbo.cotizaciones_detalle_decks", new[] { "CotizacionDetalleId" });
            DropIndex("dbo.cotizaciones_detalle", new[] { "Cotizacion_CotizacionId" });
            DropIndex("dbo.cotizaciones_detalle", new[] { "Rodillo_Id" });
            DropIndex("dbo.cotizaciones_detalle", new[] { "Maquina_Id" });
            DropTable("dbo.cotizaciones");
            DropTable("dbo.cotizaciones_detalle_peliculas");
            DropTable("dbo.cotizaciones_detalle_decks");
            DropTable("dbo.cotizaciones_detalle");
        }
    }
}
