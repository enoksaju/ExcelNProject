namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReferenciaFigura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TEMPCAPT", "ref_fig", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TEMPCAPT", "ref_fig");
        }
    }
}
