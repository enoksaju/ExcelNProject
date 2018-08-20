namespace libPostgreeTry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Children",
                c => new
                    {
                        ChildId = c.Int(nullable: false, identity: true),
                        MasterId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ChildId)
                .ForeignKey("public.Masters", t => t.MasterId, cascadeDelete: true)
                .Index(t => t.MasterId);
            
            CreateTable(
                "public.Masters",
                c => new
                    {
                        MasterId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.MasterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Children", "MasterId", "public.Masters");
            DropIndex("public.Children", new[] { "MasterId" });
            DropTable("public.Masters");
            DropTable("public.Children");
        }
    }
}
