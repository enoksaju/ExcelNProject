namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEtiquetas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etiquetas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 250, storeType: "nvarchar"),
                        ZPLCode = c.String(unicode: false),
                        Definition = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Etiquetas");
        }
    }
}
