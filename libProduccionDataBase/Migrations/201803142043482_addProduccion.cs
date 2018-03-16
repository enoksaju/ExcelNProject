namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProduccion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TPRODUCCION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OT = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        TIPOPROCESO = c.Int(nullable: false),
                        NUMERO = c.Int(nullable: false),
                        PESOBRUTO = c.Double(nullable: false),
                        PESOCORE = c.Double(nullable: false),
                        PIEZAS = c.Int(nullable: false),
                        BANDERAS = c.Int(nullable: false),
                        MAQUINA = c.Int(nullable: false),
                        ORIGEN = c.String(unicode: false),
                        OPERADOR = c.String(unicode: false),
                        TURNO = c.Int(nullable: false),
                        FECHA = c.DateTime(nullable: false, precision: 0),
                        ENSANEO = c.Short(nullable: false),
                        FUESANEADA = c.Short(nullable: false),
                        FUEEDITADA = c.Short(nullable: false),
                        ESRECHAZADA = c.Short(nullable: false),
                        USUARIO = c.String(unicode: false),
                        INDICE = c.String(unicode: false),
                        REPETICION = c.Int(nullable: false),
                        EXTRUSION_ID = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maquinas", t => t.MAQUINA, cascadeDelete: true)
                .ForeignKey("dbo.TORDENTRABAJO", t => t.OT, cascadeDelete: true)
                .ForeignKey("dbo.Procesos", t => t.TIPOPROCESO, cascadeDelete: true)
                .Index(t => t.OT)
                .Index(t => t.TIPOPROCESO)
                .Index(t => t.MAQUINA);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TPRODUCCION", "TIPOPROCESO", "dbo.Procesos");
            DropForeignKey("dbo.TPRODUCCION", "OT", "dbo.TORDENTRABAJO");
            DropForeignKey("dbo.TPRODUCCION", "MAQUINA", "dbo.Maquinas");
            DropIndex("dbo.TPRODUCCION", new[] { "MAQUINA" });
            DropIndex("dbo.TPRODUCCION", new[] { "TIPOPROCESO" });
            DropIndex("dbo.TPRODUCCION", new[] { "OT" });
            DropTable("dbo.TPRODUCCION");
        }
    }
}
