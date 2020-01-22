namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ControlDurezas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TPRODUCCION", "DurezaIzquierda", c => c.Double());
            AddColumn("dbo.TPRODUCCION", "DurezaDerecha", c => c.Double());
            AddColumn("dbo.TPRODUCCION", "DurezaCentro", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TPRODUCCION", "DurezaCentro");
            DropColumn("dbo.TPRODUCCION", "DurezaDerecha");
            DropColumn("dbo.TPRODUCCION", "DurezaIzquierda");
        }
    }
}
