namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexToTProduccion : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TPRODUCCION", "NUMERO");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TPRODUCCION", new[] { "NUMERO" });
        }
    }
}
