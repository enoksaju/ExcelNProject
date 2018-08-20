namespace libPostgreeTry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "admin.customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("public.Masters", "CustomerId", c => c.Int());
            CreateIndex("public.Masters", "CustomerId");
            AddForeignKey("public.Masters", "CustomerId", "admin.customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("public.Masters", "CustomerId", "admin.customers");
            DropIndex("public.Masters", new[] { "CustomerId" });
            DropColumn("public.Masters", "CustomerId");
            DropTable("admin.customers");
        }
    }
}
