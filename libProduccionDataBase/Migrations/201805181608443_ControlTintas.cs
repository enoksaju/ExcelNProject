namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ControlTintas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tinta_Articulos",
                c => new
                    {
                        Clave = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Descripcion = c.String(nullable: false, unicode: false),
                        TiposTinta_Id = c.Int(nullable: false),
                        Proveedor_Id = c.Int(nullable: false),
                        ClaveIntelisis = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Clave)
                .ForeignKey("dbo.Tinta_Proveedores", t => t.Proveedor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tinta_Tipos", t => t.TiposTinta_Id, cascadeDelete: true)
                .Index(t => t.TiposTinta_Id)
                .Index(t => t.Proveedor_Id);
            
            CreateTable(
                "dbo.Tinta_Entradas",
                c => new
                    {
                        MovId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, precision: 0),
                        FechaCaptura = c.DateTime(nullable: false, precision: 0),
                        ClaveTinta = c.String(maxLength: 128, storeType: "nvarchar"),
                        Cantidad = c.Double(nullable: false),
                        UsoBascula = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MovId)
                .ForeignKey("dbo.Tinta_Articulos", t => t.ClaveTinta)
                .Index(t => t.ClaveTinta);
            
            CreateTable(
                "dbo.Tinta_Proveedores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tinta_Tipos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                        Proveedor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tinta_Proveedores", t => t.Proveedor_Id, cascadeDelete: true)
                .Index(t => t.Proveedor_Id);
            
            CreateTable(
                "dbo.Tinta_SalidasComponents",
                c => new
                    {
                        ComponenteId = c.Int(nullable: false, identity: true),
                        MovId = c.Int(nullable: false),
                        ClaveTinta = c.String(maxLength: 128, storeType: "nvarchar"),
                        Cantidad = c.Double(nullable: false),
                        UsoBascula = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ComponenteId)
                .ForeignKey("dbo.Tinta_Salidas", t => t.MovId, cascadeDelete: true)
                .ForeignKey("dbo.Tinta_Articulos", t => t.ClaveTinta)
                .Index(t => t.MovId)
                .Index(t => t.ClaveTinta);
            
            CreateTable(
                "dbo.Tinta_Salidas",
                c => new
                    {
                        MovId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, precision: 0),
                        FechaCaptura = c.DateTime(nullable: false, precision: 0),
                        OT = c.String(maxLength: 128, storeType: "nvarchar"),
                        Motivo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovId)
                .ForeignKey("dbo.TORDENTRABAJO", t => t.OT)
                .Index(t => t.OT);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tinta_Articulos", "TiposTinta_Id", "dbo.Tinta_Tipos");
            DropForeignKey("dbo.Tinta_SalidasComponents", "ClaveTinta", "dbo.Tinta_Articulos");
            DropForeignKey("dbo.Tinta_Salidas", "OT", "dbo.TORDENTRABAJO");
            DropForeignKey("dbo.Tinta_SalidasComponents", "MovId", "dbo.Tinta_Salidas");
            DropForeignKey("dbo.Tinta_Articulos", "Proveedor_Id", "dbo.Tinta_Proveedores");
            DropForeignKey("dbo.Tinta_Tipos", "Proveedor_Id", "dbo.Tinta_Proveedores");
            DropForeignKey("dbo.Tinta_Entradas", "ClaveTinta", "dbo.Tinta_Articulos");
            DropIndex("dbo.Tinta_Salidas", new[] { "OT" });
            DropIndex("dbo.Tinta_SalidasComponents", new[] { "ClaveTinta" });
            DropIndex("dbo.Tinta_SalidasComponents", new[] { "MovId" });
            DropIndex("dbo.Tinta_Tipos", new[] { "Proveedor_Id" });
            DropIndex("dbo.Tinta_Entradas", new[] { "ClaveTinta" });
            DropIndex("dbo.Tinta_Articulos", new[] { "Proveedor_Id" });
            DropIndex("dbo.Tinta_Articulos", new[] { "TiposTinta_Id" });
            DropTable("dbo.Tinta_Salidas");
            DropTable("dbo.Tinta_SalidasComponents");
            DropTable("dbo.Tinta_Tipos");
            DropTable("dbo.Tinta_Proveedores");
            DropTable("dbo.Tinta_Entradas");
            DropTable("dbo.Tinta_Articulos");
        }
    }
}
