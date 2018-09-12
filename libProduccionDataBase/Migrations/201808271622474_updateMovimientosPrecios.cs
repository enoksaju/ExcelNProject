namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMovimientosPrecios : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovPrec_Fam_Mat", "FamiliaMateriales_Id", "dbo.FamiliasMaterial");
            DropIndex("dbo.MovPrec_Fam_Mat", new[] { "FamiliaMateriales_Id" });
            AlterColumn("dbo.MovPrec_Fam_Mat", "FamiliaMateriales_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MovPrec_Fam_Mat", "FamiliaMateriales_Id");
            AddForeignKey("dbo.MovPrec_Fam_Mat", "FamiliaMateriales_Id", "dbo.FamiliasMaterial", "Id", cascadeDelete: true);
            DropColumn("dbo.MovPrec_Fam_Mat", "FamiliaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovPrec_Fam_Mat", "FamiliaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.MovPrec_Fam_Mat", "FamiliaMateriales_Id", "dbo.FamiliasMaterial");
            DropIndex("dbo.MovPrec_Fam_Mat", new[] { "FamiliaMateriales_Id" });
            AlterColumn("dbo.MovPrec_Fam_Mat", "FamiliaMateriales_Id", c => c.Int());
            CreateIndex("dbo.MovPrec_Fam_Mat", "FamiliaMateriales_Id");
            AddForeignKey("dbo.MovPrec_Fam_Mat", "FamiliaMateriales_Id", "dbo.FamiliasMaterial", "Id");
        }
    }
}
