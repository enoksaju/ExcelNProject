namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIndexProduction : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TPRODUCCION", "INDICE", c => c.String(maxLength: 128, storeType: "nvarchar"));
            CreateIndex("dbo.TPRODUCCION", "INDICE", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.TPRODUCCION", new[] { "INDICE" });
            AlterColumn("dbo.TPRODUCCION", "INDICE", c => c.String(unicode: false));
        }
    }
}
