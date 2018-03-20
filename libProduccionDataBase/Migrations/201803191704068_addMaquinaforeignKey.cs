namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMaquinaforeignKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TDESPERDICIOS", "MAQUINA");
            AddForeignKey("dbo.TDESPERDICIOS", "MAQUINA", "dbo.Maquinas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TDESPERDICIOS", "MAQUINA", "dbo.Maquinas");
            DropIndex("dbo.TDESPERDICIOS", new[] { "MAQUINA" });
        }
    }
}
