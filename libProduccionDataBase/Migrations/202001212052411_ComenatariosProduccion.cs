namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComenatariosProduccion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TPRODUCCION", "Comentarios", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TPRODUCCION", "Comentarios");
        }
    }
}
