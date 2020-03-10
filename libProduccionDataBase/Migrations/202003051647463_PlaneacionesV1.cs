namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlaneacionesV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Planeacion",
                c => new
                    {
                        OT = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Status = c.Int(nullable: false),
                        UltimaActualizacion = c.DateTime(nullable: false, precision: 0),
                        FechaCaptura = c.DateTime(nullable: false, precision: 0),
                        FechaPE = c.DateTime(nullable: false, precision: 0),
                        FechaMateriales = c.DateTime(nullable: false, precision: 0),
                        FechaProgEntregaAlmacen = c.DateTime(nullable: false, precision: 0),
                        FechaRealEntregaAlmacen = c.DateTime(nullable: false, precision: 0),
                        FechaEmbarque = c.DateTime(nullable: false, precision: 0),
                        FechaEntregaCliente = c.DateTime(nullable: false, precision: 0),
                        estatusDiseno = c.Int(nullable: false),
                        Comentarios = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.OT)
                .ForeignKey("dbo.TORDENTRABAJO", t => t.OT)
                .Index(t => t.OT);
            
            CreateTable(
                "dbo.PlaneacionProducciones",
                c => new
                    {
                        OT = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        TipoProceso = c.Int(nullable: false),
                        MaquinaId = c.Int(),
                        Activa = c.Boolean(nullable: false),
                        TipoProcesoNombre = c.String(unicode: false),
                        FechaProgramada = c.DateTime(precision: 0),
                        FechaProcesada = c.DateTime(precision: 0),
                        prioridad = c.Int(),
                        Estatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OT, t.TipoProceso })
                .ForeignKey("dbo.Maquinas", t => t.MaquinaId)
                .ForeignKey("dbo.Planeacion", t => t.OT, cascadeDelete: true)
                .Index(t => t.OT)
                .Index(t => t.MaquinaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaneacionProducciones", "OT", "dbo.Planeacion");
            DropForeignKey("dbo.PlaneacionProducciones", "MaquinaId", "dbo.Maquinas");
            DropForeignKey("dbo.Planeacion", "OT", "dbo.TORDENTRABAJO");
            DropIndex("dbo.PlaneacionProducciones", new[] { "MaquinaId" });
            DropIndex("dbo.PlaneacionProducciones", new[] { "OT" });
            DropIndex("dbo.Planeacion", new[] { "OT" });
            DropTable("dbo.PlaneacionProducciones");
            DropTable("dbo.Planeacion");
        }
    }
}
