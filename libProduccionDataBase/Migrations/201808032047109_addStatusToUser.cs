namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatusToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Z_Usuarios", "Estatus", c => c.Int(nullable: false));
            AlterColumn("dbo.res_Manif", "NombreChofer", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.res_Manif", "NombreReceptor", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.res_Manif", "NombreReceptor", c => c.String(unicode: false));
            AlterColumn("dbo.res_Manif", "NombreChofer", c => c.String(unicode: false));
            DropColumn("dbo.Z_Usuarios", "Estatus");
        }
    }
}
