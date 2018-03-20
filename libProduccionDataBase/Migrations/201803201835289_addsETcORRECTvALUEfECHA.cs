namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsETcORRECTvALUEfECHA : DbMigration
    {
        public override void Up()
        {
			Sql ( "UPDATE TEMPCAPT SET FechaCaptura='2018.03.20';" );
		}
        
        public override void Down()
        {
        }
    }
}
