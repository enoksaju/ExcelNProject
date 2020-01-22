namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaneoArrugasProduccion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TPRODUCCION", "EnSaneoArrugas", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TPRODUCCION", "EnSaneoArrugas");
        }
    }
}
