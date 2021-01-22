namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AVTSystem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AVTFolios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaImpresion = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AVTFolios");
        }
    }
}
