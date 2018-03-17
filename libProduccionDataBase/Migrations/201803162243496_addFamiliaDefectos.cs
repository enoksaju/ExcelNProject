namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFamiliaDefectos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TDESPERDICIOS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OT = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        OPERADOR = c.String(nullable: false, unicode: false),
                        TURNO = c.Int(nullable: false),
                        MAQUINA = c.Int(nullable: false),
                        NUMERO = c.Int(nullable: false),
                        PESO = c.Double(nullable: false),
                        DEFECTO = c.Int(nullable: false),
                        DESCRIPCION = c.String(unicode: false),
                        FECHA = c.DateTime(nullable: false, precision: 0),
                        USUARIO = c.String(unicode: false),
                        ESTRUCTURA = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TFamiliaDefectosTDefectos", t => t.DEFECTO, cascadeDelete: true)
                .ForeignKey("dbo.TORDENTRABAJO", t => t.OT, cascadeDelete: true)
                .Index(t => t.OT)
                .Index(t => t.DEFECTO);
            
            CreateTable(
                "dbo.TFamiliaDefectosTDefectos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TFamiliaDefectosID = c.Int(nullable: false),
                        TDefectoID = c.Int(nullable: false),
                        ProcesoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TDefectos", t => t.TDefectoID, cascadeDelete: true)
                .ForeignKey("dbo.TFamiliasDefectos", t => t.TFamiliaDefectosID, cascadeDelete: true)
                .ForeignKey("dbo.Procesos", t => t.ProcesoID, cascadeDelete: true)
                .Index(t => t.TFamiliaDefectosID)
                .Index(t => t.TDefectoID)
                .Index(t => t.ProcesoID);
            
            CreateTable(
                "dbo.TDefectos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreDefecto = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TFamiliasDefectos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreFamiliaDefecto = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TDESPERDICIOS", "OT", "dbo.TORDENTRABAJO");
            DropForeignKey("dbo.TDESPERDICIOS", "DEFECTO", "dbo.TFamiliaDefectosTDefectos");
            DropForeignKey("dbo.TFamiliaDefectosTDefectos", "ProcesoID", "dbo.Procesos");
            DropForeignKey("dbo.TFamiliaDefectosTDefectos", "TFamiliaDefectosID", "dbo.TFamiliasDefectos");
            DropForeignKey("dbo.TFamiliaDefectosTDefectos", "TDefectoID", "dbo.TDefectos");
            DropIndex("dbo.TFamiliaDefectosTDefectos", new[] { "ProcesoID" });
            DropIndex("dbo.TFamiliaDefectosTDefectos", new[] { "TDefectoID" });
            DropIndex("dbo.TFamiliaDefectosTDefectos", new[] { "TFamiliaDefectosID" });
            DropIndex("dbo.TDESPERDICIOS", new[] { "DEFECTO" });
            DropIndex("dbo.TDESPERDICIOS", new[] { "OT" });
            DropTable("dbo.TFamiliasDefectos");
            DropTable("dbo.TDefectos");
            DropTable("dbo.TFamiliaDefectosTDefectos");
            DropTable("dbo.TDESPERDICIOS");
        }
    }
}
