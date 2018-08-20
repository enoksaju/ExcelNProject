namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTintasOtros : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cat_otros",
                c => new
                    {
                        OtroId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, unicode: false),
                        Precio = c.Double(nullable: false),
                        Costo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OtroId);
            
            CreateTable(
                "dbo.cat_tintas",
                c => new
                    {
                        TintaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, unicode: false),
                        Tipo = c.String(unicode: false),
                        Precio = c.Double(nullable: false),
                        Costo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TintaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.cat_tintas");
            DropTable("dbo.cat_otros");
        }
    }
}
