namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarTelefonoTransportista : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.res_Transp", "Telefono", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.res_Transp", "Telefono");
        }
    }
}
