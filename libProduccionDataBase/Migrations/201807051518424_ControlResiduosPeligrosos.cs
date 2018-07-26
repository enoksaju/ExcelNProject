namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ControlResiduosPeligrosos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.res_Manif",
                c => new
                    {
                        NoManifiesto = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaveP = c.Int(nullable: false),
                        ClaveT = c.Int(nullable: false),
                        NombreChofer = c.String(unicode: false),
                        CargoChofer = c.String(unicode: false),
                        NombreReceptor = c.String(unicode: false),
                        CargoReceptor = c.String(unicode: false),
                        Fecha = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.NoManifiesto)
                .ForeignKey("dbo.res_Proved", t => t.ClaveP, cascadeDelete: false)
                .ForeignKey("dbo.res_Transp", t => t.ClaveT, cascadeDelete: false)
                .Index(t => t.ClaveP)
                .Index(t => t.ClaveT);
            
            CreateTable(
                "dbo.res_dmanif",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoManifiesto = c.String(maxLength: 128, storeType: "nvarchar"),
                        ClaveRP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.res_Manif", t => t.NoManifiesto)
                .ForeignKey("dbo.res_TiposRP", t => t.ClaveRP, cascadeDelete: false)
                .Index(t => t.NoManifiesto)
                .Index(t => t.ClaveRP);
            
            CreateTable(
                "dbo.res_SalidaRP",
                c => new
                    {
                        FolioRP = c.Int(nullable: false, identity: true),
                        ClaveRP = c.Int(nullable: false),
                        ClaveL = c.Int(nullable: false),
                        Cantidad = c.Double(nullable: false),
                        FechaEnvasado = c.DateTime(nullable: false, precision: 0),
                        FechaIngreso = c.DateTime(nullable: false, precision: 0),
                        FolioDM = c.Int(),
                    })
                .PrimaryKey(t => t.FolioRP)
                .ForeignKey("dbo.Lineas", t => t.ClaveL, cascadeDelete: false)
                .ForeignKey("dbo.res_dmanif", t => t.FolioDM)
                .ForeignKey("dbo.res_TiposRP", t => t.ClaveRP, cascadeDelete: false)
                .Index(t => t.ClaveRP)
                .Index(t => t.ClaveL)
                .Index(t => t.FolioDM);
            
            CreateTable(
                "dbo.res_TiposRP",
                c => new
                    {
                        ClaveRP = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(unicode: false),
                        Riesgo = c.Int(nullable: false),
                        Unidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClaveRP);
            
            CreateTable(
                "dbo.res_Proved",
                c => new
                    {
                        ClaveP = c.Int(nullable: false, identity: true),
                        Denominacion = c.String(unicode: false),
                        Domicilio = c.String(unicode: false),
                        Municipio = c.String(unicode: false),
                        CP = c.Int(nullable: false),
                        Estado = c.String(unicode: false),
                        AutSEMARNAT = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ClaveP);
            
            CreateTable(
                "dbo.res_Transp",
                c => new
                    {
                        ClaveT = c.Int(nullable: false, identity: true),
                        Denominacion = c.String(unicode: false),
                        Domicilio = c.String(unicode: false),
                        Municipio = c.String(unicode: false),
                        CP = c.Int(nullable: false),
                        Estado = c.String(unicode: false),
                        AutSEMARNAT = c.String(unicode: false),
                        RegSCT = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ClaveT);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.res_Manif", "ClaveT", "dbo.res_Transp");
            DropForeignKey("dbo.res_Manif", "ClaveP", "dbo.res_Proved");
            DropForeignKey("dbo.res_dmanif", "ClaveRP", "dbo.res_TiposRP");
            DropForeignKey("dbo.res_SalidaRP", "ClaveRP", "dbo.res_TiposRP");
            DropForeignKey("dbo.res_SalidaRP", "FolioDM", "dbo.res_dmanif");
            DropForeignKey("dbo.res_SalidaRP", "ClaveL", "dbo.Lineas");
            DropForeignKey("dbo.res_dmanif", "NoManifiesto", "dbo.res_Manif");
            DropIndex("dbo.res_SalidaRP", new[] { "FolioDM" });
            DropIndex("dbo.res_SalidaRP", new[] { "ClaveL" });
            DropIndex("dbo.res_SalidaRP", new[] { "ClaveRP" });
            DropIndex("dbo.res_dmanif", new[] { "ClaveRP" });
            DropIndex("dbo.res_dmanif", new[] { "NoManifiesto" });
            DropIndex("dbo.res_Manif", new[] { "ClaveT" });
            DropIndex("dbo.res_Manif", new[] { "ClaveP" });
            DropTable("dbo.res_Transp");
            DropTable("dbo.res_Proved");
            DropTable("dbo.res_TiposRP");
            DropTable("dbo.res_SalidaRP");
            DropTable("dbo.res_dmanif");
            DropTable("dbo.res_Manif");
        }
    }
}
