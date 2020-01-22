namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TPRODUCCION", "Item", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TPRODUCCION", "Item");
        }
    }
}
