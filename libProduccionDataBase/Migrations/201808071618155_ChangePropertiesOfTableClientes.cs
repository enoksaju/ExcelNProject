namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePropertiesOfTableClientes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "NombreContacto", c => c.String(nullable: false, maxLength: 250, storeType: "nvarchar"));
            AddColumn("dbo.Clientes", "Telefono", c => c.String(unicode: false));
            AddColumn("dbo.Clientes", "Email", c => c.String(unicode: false));
            AddColumn("dbo.Clientes", "Domicilio", c => c.String(unicode: false));
            AddColumn("dbo.Clientes", "Ciudad", c => c.String(unicode: false));
            AddColumn("dbo.Clientes", "Estado", c => c.String(unicode: false));
            AddColumn("dbo.Clientes", "AgenteId", c => c.Int());
            CreateIndex("dbo.Clientes", "AgenteId");
            AddForeignKey("dbo.Clientes", "AgenteId", "dbo.Z_Usuarios", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "AgenteId", "dbo.Z_Usuarios");
            DropIndex("dbo.Clientes", new[] { "AgenteId" });
            DropColumn("dbo.Clientes", "AgenteId");
            DropColumn("dbo.Clientes", "Estado");
            DropColumn("dbo.Clientes", "Ciudad");
            DropColumn("dbo.Clientes", "Domicilio");
            DropColumn("dbo.Clientes", "Email");
            DropColumn("dbo.Clientes", "Telefono");
            DropColumn("dbo.Clientes", "NombreContacto");
        }
    }
}
