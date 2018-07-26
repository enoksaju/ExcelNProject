namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmailResponsable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lineas", "EmailResponsable", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lineas", "EmailResponsable");
        }
    }
}
