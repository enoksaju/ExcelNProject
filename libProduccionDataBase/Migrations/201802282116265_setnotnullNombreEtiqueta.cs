namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setnotnullNombreEtiqueta : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Etiquetas", "Nombre", c => c.String(nullable: false, maxLength: 250, storeType: "nvarchar"));
            CreateIndex("dbo.Etiquetas", "Nombre", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Etiquetas", new[] { "Nombre" });
            AlterColumn("dbo.Etiquetas", "Nombre", c => c.String(maxLength: 250, storeType: "nvarchar"));
        }
    }
}
