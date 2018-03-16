namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTempOT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TEMPCAPT",
                c => new
                    {
                        OT = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Id = c.Int(nullable: false),
                        DISENIOAUT = c.String(unicode: false),
                        CENTROS = c.Int(nullable: false),
                        TINTA = c.Double(nullable: false),
                        ADH1 = c.Double(nullable: false),
                        ADH2 = c.Double(nullable: false),
                        AJUIMP = c.Double(nullable: false),
                        LAMIMP = c.Double(nullable: false),
                        TRIIMP = c.Double(nullable: false),
                        AJULAM = c.Double(nullable: false),
                        LAMLAM = c.Double(nullable: false),
                        TRILAM = c.Double(nullable: false),
                        AJUTRI = c.Double(nullable: false),
                        TRITRI = c.Double(nullable: false),
                        PORCTOLERANCIA = c.Double(nullable: false),
                        ZIPPER = c.Int(nullable: false),
                        ADHPERM = c.Int(nullable: false),
                        ADHREM = c.Int(nullable: false),
                        ESPECIAL = c.Int(nullable: false),
                        ESPECIALLAM = c.Int(nullable: false),
                        ESPECIALREF = c.Int(nullable: false),
                        ML = c.Int(nullable: false),
                        EX1 = c.Int(nullable: false),
                        EX2 = c.Int(nullable: false),
                        EX3 = c.Int(nullable: false),
                        ZIPPER_TYPE = c.Int(nullable: false),
                        MERMAPROCESO = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OT)
                .ForeignKey("dbo.TORDENTRABAJO", t => t.OT)
                .Index(t => t.OT);
            
            CreateTable(
                "dbo.TORDENTRABAJO",
                c => new
                    {
                        OT = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        TIPO = c.Int(nullable: false),
                        FECHARECIBIDO = c.DateTime(nullable: false, precision: 0),
                        FECHAENTREGASOL = c.DateTime(nullable: false, precision: 0),
                        CLIENTE = c.String(unicode: false),
                        PRODUCTO = c.String(unicode: false),
                        CANTIDAD = c.Double(nullable: false),
                        UNIDAD = c.String(unicode: false),
                        ANCHO = c.Double(nullable: false),
                        ALTO = c.Double(nullable: false),
                        SOLAPA = c.Double(nullable: false),
                        FUELLELATERAL = c.Double(nullable: false),
                        FUELLEFONDO = c.Double(nullable: false),
                        COPETE = c.Double(nullable: false),
                        AREASELLOREV = c.Double(nullable: false),
                        AREASELLOFONDO = c.Double(nullable: false),
                        TIPOIMPRESION = c.Int(nullable: false),
                        TIPOTRABAJO = c.Int(nullable: false),
                        REPEJE = c.Double(nullable: false),
                        REPDES = c.Double(nullable: false),
                        MATBASE = c.String(unicode: false),
                        MATBASECALIBRE = c.Double(nullable: false),
                        MATBASEKG = c.Double(nullable: false),
                        MATBASEAMU = c.Double(nullable: false),
                        MATLAMINACION = c.String(unicode: false),
                        MATLAMINACIONCALIBRE = c.Double(nullable: false),
                        MATLAMINACIONKG = c.Double(nullable: false),
                        MATLAMINACIONAMU = c.Double(nullable: false),
                        MATTRILAMINACION = c.String(unicode: false),
                        MATTRILAMINACIONCALIBRE = c.Double(nullable: false),
                        MATTRILAMINACIONKG = c.Double(nullable: false),
                        MATTRILAMINACIONAMU = c.Double(nullable: false),
                        CLAVEINTELISIS = c.String(unicode: false),
                        ORDENCOMPRA = c.String(unicode: false),
                        CLAVEPRODUCTO = c.String(unicode: false),
                        IMPRESORA = c.String(unicode: false),
                        RODILLO = c.Double(nullable: false),
                        FIGURASALIDAFINAL = c.Int(nullable: false),
                        EMPATES = c.String(unicode: false),
                        INSTCORTE = c.String(unicode: false),
                        INSTDOBLADO = c.String(unicode: false),
                        INSTEMBOBINADO = c.String(unicode: false),
                        INSTEXTRUSION = c.String(unicode: false),
                        INSTIMPRESION = c.String(unicode: false),
                        INSTLAMINACION = c.String(unicode: false),
                        INSTMANGAS = c.String(unicode: false),
                        INSTREFINADO = c.String(unicode: false),
                        INSTSELLADO = c.String(unicode: false),
                        OBSERVACIONES = c.String(unicode: false),
                        ESIMPRESO = c.String(unicode: false),
                        KGXMILL = c.Double(nullable: false),
                        EXTIPO = c.String(unicode: false),
                        EXCOLOR = c.String(unicode: false),
                        EXTRATADO = c.String(unicode: false),
                        EXDINAS = c.String(unicode: false),
                        EXDESLIZ = c.String(unicode: false),
                        EXANTIESTATICA = c.String(unicode: false),
                        EXKG = c.String(unicode: false),
                        EXANCHO = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.OT);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TEMPCAPT", "OT", "dbo.TORDENTRABAJO");
            DropIndex("dbo.TEMPCAPT", new[] { "OT" });
            DropTable("dbo.TORDENTRABAJO");
            DropTable("dbo.TEMPCAPT");
        }
    }
}
