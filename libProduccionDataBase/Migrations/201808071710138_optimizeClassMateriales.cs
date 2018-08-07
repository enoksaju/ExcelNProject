namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class optimizeClassMateriales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.mat_calibres",
                c => new
                    {
                        MaterialId = c.Int(nullable: false),
                        Valor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaterialId, t.Valor })
                .ForeignKey("dbo.Material", t => t.MaterialId, cascadeDelete: true)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.MovPrec_Fam_Mat",
                c => new
                    {
                        MovimientoPrecioId = c.Int(nullable: false, identity: true),
                        FamiliaId = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false, precision: 0),
                        FechaOperacion = c.DateTime(nullable: false, precision: 0),
                        FamiliaMateriales_Id = c.Int(),
                    })
                .PrimaryKey(t => t.MovimientoPrecioId)
                .ForeignKey("dbo.FamiliasMaterial", t => t.FamiliaMateriales_Id)
                .Index(t => t.FamiliaMateriales_Id);
            
            AddColumn("dbo.Material", "Caracteristicas", c => c.String(unicode: false));
            AddColumn("dbo.Material", "Unidad", c => c.Int(nullable: false));
            AddColumn("dbo.Material", "FactorDensidad", c => c.Double(nullable: false));
            AddColumn("dbo.Material", "PrecioInicial", c => c.Double(nullable: false));
            AddColumn("dbo.Material", "CostoInicial", c => c.Double(nullable: false));
            AddColumn("dbo.Material", "Metalizado", c => c.Boolean());
            AddColumn("dbo.Material", "Convenio", c => c.Boolean());
            AddColumn("dbo.Material", "FechaRegistro", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Material", "FechaOperacion", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Material", "Apariencia", c => c.String(nullable: false, unicode: false));
            DropColumn("dbo.Material", "Formula");
            DropColumn("dbo.Material", "Densidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Material", "Densidad", c => c.Double(nullable: false));
            AddColumn("dbo.Material", "Formula", c => c.String(maxLength: 250, storeType: "nvarchar"));
            DropForeignKey("dbo.MovPrec_Fam_Mat", "FamiliaMateriales_Id", "dbo.FamiliasMaterial");
            DropForeignKey("dbo.mat_calibres", "MaterialId", "dbo.Material");
            DropIndex("dbo.MovPrec_Fam_Mat", new[] { "FamiliaMateriales_Id" });
            DropIndex("dbo.mat_calibres", new[] { "MaterialId" });
            AlterColumn("dbo.Material", "Apariencia", c => c.String(nullable: false, maxLength: 250, storeType: "nvarchar"));
            DropColumn("dbo.Material", "FechaOperacion");
            DropColumn("dbo.Material", "FechaRegistro");
            DropColumn("dbo.Material", "Convenio");
            DropColumn("dbo.Material", "Metalizado");
            DropColumn("dbo.Material", "CostoInicial");
            DropColumn("dbo.Material", "PrecioInicial");
            DropColumn("dbo.Material", "FactorDensidad");
            DropColumn("dbo.Material", "Unidad");
            DropColumn("dbo.Material", "Caracteristicas");
            DropTable("dbo.MovPrec_Fam_Mat");
            DropTable("dbo.mat_calibres");
        }
    }
}
