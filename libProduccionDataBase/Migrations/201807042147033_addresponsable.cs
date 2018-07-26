namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addresponsable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lineas", "Responsable", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lineas", "Responsable");
        }
    }
}
