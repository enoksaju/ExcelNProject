namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFechaToTEMPCAPT : DbMigration
    {
        public override void Up()
        {
			Sql ( "ALTER TABLE TEMPCAPT DROP FechaCaptura;" );
			AddColumn ("dbo.TEMPCAPT", "FechaCaptura", c => c.DateTime(nullable: false, precision: 0));
			Sql ( "UPDATE TEMPCAPT SET FechaCaptura='2018.03.20';" );
        }
        
        public override void Down()
        {
            DropColumn("dbo.TEMPCAPT", "FechaCaptura");
        }
    }
}
