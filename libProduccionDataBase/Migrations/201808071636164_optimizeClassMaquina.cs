namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class optimizeClassMaquina : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.config_tintas_maquina",
                c => new
                    {
                        MaquinaId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        MinimoMetros = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaquinaId, t.Cantidad })
                .ForeignKey("dbo.Maquinas", t => t.MaquinaId, cascadeDelete: true)
                .Index(t => t.MaquinaId);
            
            AddColumn("dbo.Maquinas", "ModeloMaquina", c => c.String(unicode: false));
            AddColumn("dbo.Maquinas", "CostoArranque", c => c.Double());
            AddColumn("dbo.Maquinas", "CostoTurno", c => c.Double());
            AddColumn("dbo.Maquinas", "PorcentajeDesperdicio", c => c.Double());
            AddColumn("dbo.Maquinas", "MinutosTurno", c => c.Int());
            AddColumn("dbo.Maquinas", "AnchoMinimoImpresion", c => c.Double());
            AddColumn("dbo.Maquinas", "AnchoMaximoImpresion", c => c.Double());
            AddColumn("dbo.Maquinas", "AnchoMinimoMaterial", c => c.Double());
            AddColumn("dbo.Maquinas", "AnchoMaximoMaterial", c => c.Double());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.config_tintas_maquina", "MaquinaId", "dbo.Maquinas");
            DropIndex("dbo.config_tintas_maquina", new[] { "MaquinaId" });
            DropColumn("dbo.Maquinas", "AnchoMaximoMaterial");
            DropColumn("dbo.Maquinas", "AnchoMinimoMaterial");
            DropColumn("dbo.Maquinas", "AnchoMaximoImpresion");
            DropColumn("dbo.Maquinas", "AnchoMinimoImpresion");
            DropColumn("dbo.Maquinas", "MinutosTurno");
            DropColumn("dbo.Maquinas", "PorcentajeDesperdicio");
            DropColumn("dbo.Maquinas", "CostoTurno");
            DropColumn("dbo.Maquinas", "CostoArranque");
            DropColumn("dbo.Maquinas", "ModeloMaquina");
            DropTable("dbo.config_tintas_maquina");
        }
    }
}
