namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDensidadColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Material", "Densidad", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Material", "Densidad");
        }
    }
}
