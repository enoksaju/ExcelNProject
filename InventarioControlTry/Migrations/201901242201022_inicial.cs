namespace InventarioControlTry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.rolls",
                c => new
                    {
                        RolloId = c.Int(nullable: false, identity: true),
                        OT = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        FechaRegistro = c.DateTime(nullable: false, precision: 0),
                        add_g = c.Double(nullable: false),
                        PesoBruto = c.Double(),
                        Ancho = c.Double(),
                        Calibre = c.Double(),
                        FamiliaMateriales = c.String(unicode: false),
                        Apariencia = c.String(unicode: false),
                        ToProcess = c.String(unicode: false),
                        TProd = c.Int(),
                        TipoLaminacion = c.Int(),
                        RollType = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.RolloId)
                .Index(t => t.OT);
            
            CreateTable(
                "dbo.roll_roll_orgs",
                c => new
                    {
                        RolloId = c.Int(nullable: false),
                        RolloOrigenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RolloId, t.RolloOrigenId })
                .ForeignKey("dbo.rolls", t => t.RolloOrigenId, cascadeDelete: true)
                .ForeignKey("dbo.rolls", t => t.RolloId, cascadeDelete: true)
                .Index(t => t.RolloId)
                .Index(t => t.RolloOrigenId);
            
            CreateTable(
                "dbo.TProd",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OT = c.String(nullable: false, unicode: false),
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.NUMERO);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.roll_roll_orgs", "RolloId", "dbo.rolls");
            DropForeignKey("dbo.roll_roll_orgs", "RolloOrigenId", "dbo.rolls");
            DropIndex("dbo.TProd", new[] { "NUMERO" });
            DropIndex("dbo.roll_roll_orgs", new[] { "RolloOrigenId" });
            DropIndex("dbo.roll_roll_orgs", new[] { "RolloId" });
            DropIndex("dbo.rolls", new[] { "OT" });
            DropTable("dbo.TProd");
            DropTable("dbo.roll_roll_orgs");
            DropTable("dbo.rolls");
        }
    }
}
