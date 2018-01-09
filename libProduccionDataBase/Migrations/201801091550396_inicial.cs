namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCliente = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        ClaveCliente = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ClaveCliente, unique: true, name: "ClaveCliente_IDX");
            
            CreateTable(
                "dbo.Recetas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaveIntelisis = c.String(nullable: false, maxLength: 1000, storeType: "nvarchar"),
                        Producto = c.String(nullable: false, maxLength: 500, storeType: "nvarchar"),
                        DisenoAutorizado = c.String(nullable: false, maxLength: 500, storeType: "nvarchar"),
                        FechaCreacion = c.DateTime(nullable: false, precision: 0),
                        CalibreMaterialBase = c.Double(nullable: false),
                        CalibreMaterialLaminacion = c.Double(nullable: false),
                        CalibreMaterialTrilaminacion = c.Double(nullable: false),
                        GramosTinta = c.Double(nullable: false),
                        GramosAdhesivoLaminacion = c.Double(nullable: false),
                        GramosAdhesivoTrilaminacion = c.Double(nullable: false),
                        Diseño_Alto = c.Double(nullable: false),
                        Diseño_Ancho = c.Double(nullable: false),
                        Diseño_Solapa = c.Double(),
                        Diseño_Copete = c.Double(),
                        Diseño_FuelleLateral = c.Double(),
                        Diseño_FuelleFondo = c.Double(),
                        Diseño_AreaSelloReverso = c.Double(),
                        Diseño_AreaSelloFondo = c.Double(),
                        Diseño_RepeticionesEje = c.Int(nullable: false),
                        Diseño_RepeticionesDesarrollo = c.Int(nullable: false),
                        Diseño_Zipper = c.Int(nullable: false),
                        Diseño_TipoCopete = c.Int(nullable: false),
                        Diseño_Adhesivo = c.Int(nullable: false),
                        Diseño_FiguraFinal = c.Int(nullable: false),
                        Diseño_FiguraImpresion = c.Int(nullable: false),
                        Diseño_TipoImpresion = c.String(unicode: false),
                        Descripcion = c.String(unicode: false),
                        MaterialBase_Id = c.Int(nullable: false),
                        MaterialLaminacion_Id = c.Int(),
                        MaterialTrilaminacion_Id = c.Int(),
                        Rodillo_Id = c.Int(),
                        TipoProducto_Id = c.Int(nullable: false),
                        Cliente_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Material", t => t.MaterialBase_Id)
                .ForeignKey("dbo.Material", t => t.MaterialLaminacion_Id)
                .ForeignKey("dbo.Material", t => t.MaterialTrilaminacion_Id)
                .ForeignKey("dbo.Rodillos", t => t.Rodillo_Id)
                .ForeignKey("dbo.TiposProducto", t => t.TipoProducto_Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .Index(t => t.ClaveIntelisis, unique: true)
                .Index(t => t.Producto)
                .Index(t => t.DisenoAutorizado)
                .Index(t => t.MaterialBase_Id)
                .Index(t => t.MaterialLaminacion_Id)
                .Index(t => t.MaterialTrilaminacion_Id)
                .Index(t => t.Rodillo_Id)
                .Index(t => t.TipoProducto_Id)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Formula = c.String(maxLength: 250, storeType: "nvarchar"),
                        Apariencia = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        FamiliaMateriales_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamiliasMaterial", t => t.FamiliaMateriales_Id)
                .Index(t => t.FamiliaMateriales_Id);
            
            CreateTable(
                "dbo.FamiliasMaterial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreFamilia = c.String(maxLength: 250, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrdenesTrabajo",
                c => new
                    {
                        OT = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        FechaCaptura = c.DateTime(nullable: false, precision: 0),
                        Pedido_CantidadPedido = c.Double(nullable: false),
                        Pedido_AnchoMaterialBase = c.Double(nullable: false),
                        Pedido_AnchoMaterialLaminacion = c.Double(),
                        Pedido_AnchoMaterialTrilaminacion = c.Double(),
                        Ajustes_AjusteImpresion = c.Double(nullable: false),
                        Ajustes_AjusteLaminacion = c.Double(nullable: false),
                        Ajustes_AjusteTrilaminacion = c.Double(nullable: false),
                        Ajustes_MermaProceso = c.Double(nullable: false),
                        Instrucciones_Impresion = c.String(unicode: false),
                        Instrucciones_UsarEspecialImpresion = c.Boolean(nullable: false),
                        Instrucciones_HabilitarImpresion = c.Boolean(nullable: false),
                        Instrucciones_Laminacion = c.String(unicode: false),
                        Instrucciones_UsarEspecialLaminacion = c.Boolean(nullable: false),
                        Instrucciones_HabilitarLaminacion = c.Boolean(nullable: false),
                        Instrucciones_Refinado = c.String(unicode: false),
                        Instrucciones_UsarEspecialRefinado = c.Boolean(nullable: false),
                        Instrucciones_HabilitarRefinado = c.Boolean(nullable: false),
                        Instrucciones_Doblado = c.String(unicode: false),
                        Instrucciones_HabilitarDoblado = c.Boolean(nullable: false),
                        Instrucciones_Corte = c.String(unicode: false),
                        Instrucciones_HabilitarCorte = c.Boolean(nullable: false),
                        Instrucciones_Embobinado = c.String(unicode: false),
                        Instrucciones_HabilitarEmbobinado = c.Boolean(nullable: false),
                        Instrucciones_Mangas = c.String(unicode: false),
                        Instrucciones_HabilitarMangas = c.Boolean(nullable: false),
                        Instrucciones_Sellado = c.String(unicode: false),
                        Instrucciones_HabilitarSellado = c.Boolean(nullable: false),
                        Instrucciones_Extrusion = c.String(unicode: false),
                        Instrucciones_HabilitarExtrusion = c.Boolean(nullable: false),
                        Comentarios = c.String(unicode: false),
                        Receta_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OT)
                .ForeignKey("dbo.Recetas", t => t.Receta_Id)
                .Index(t => t.OT, unique: true)
                .Index(t => t.Receta_Id);
            
            CreateTable(
                "dbo.Embarques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        FechaEmpaque = c.DateTime(nullable: false, precision: 0),
                        Usuario = c.String(unicode: false),
                        OrdenTrabajo_OT = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrdenesTrabajo", t => t.OrdenTrabajo_OT)
                .Index(t => t.Numero, unique: true, name: "EmbarqueNumero")
                .Index(t => t.OrdenTrabajo_OT);
            
            CreateTable(
                "dbo.Tarimas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Embarque_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Embarques", t => t.Embarque_Id)
                .Index(t => t.Embarque_Id);
            
            CreateTable(
                "dbo.Produccion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OT = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        ProcesoId = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        Captura_PesoBruto = c.Double(nullable: false),
                        Captura_PesoTara = c.Double(nullable: false),
                        Captura_Piezas = c.Int(nullable: false),
                        Captura_Banderas = c.Int(nullable: false),
                        Captura_Operador = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        Captura_Turno = c.Int(nullable: false),
                        Captura_Repeticion = c.Int(nullable: false),
                        Captura_ExtrusionId = c.String(maxLength: 20, storeType: "nvarchar"),
                        Captura_FechaCaptura = c.DateTime(nullable: false, precision: 0),
                        Captura_UltimaEdicion = c.DateTime(nullable: false, precision: 0),
                        Captura_Estatus = c.String(nullable: false, unicode: false),
                        Maquina_Id = c.Int(nullable: false),
                        Tarima_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Procesos", t => t.ProcesoId)
                .ForeignKey("dbo.Maquinas", t => t.Maquina_Id)
                .ForeignKey("dbo.OrdenesTrabajo", t => t.OT)
                .ForeignKey("dbo.Tarimas", t => t.Tarima_Id)
                .Index(t => new { t.OT, t.ProcesoId, t.Numero }, unique: true, name: "Unique_for_OT_Produccion")
                .Index(t => t.Maquina_Id)
                .Index(t => t.Tarima_Id);
            
            CreateTable(
                "dbo.Maquinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreMaquina = c.String(unicode: false),
                        Velocidad = c.Double(nullable: false),
                        TipoMaquina_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TiposMaquina", t => t.TipoMaquina_Id)
                .Index(t => t.TipoMaquina_Id);
            
            CreateTable(
                "dbo.Desperdicios",
                c => new
                    {
                        OT = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        Proceso_Id = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        Captura_Peso = c.Double(nullable: false),
                        Captura_Operador = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        Captura_Turno = c.Int(nullable: false),
                        Captura_FechaCaptura = c.DateTime(nullable: false, precision: 0),
                        Captura_UltimaEdicion = c.DateTime(nullable: false, precision: 0),
                        Captura_Estatus = c.String(nullable: false, unicode: false),
                        Defecto_Id = c.Int(nullable: false),
                        Material1_Id = c.Int(),
                        Material2_Id = c.Int(),
                        Material3_Id = c.Int(),
                        Maquina_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OT, t.Proceso_Id, t.Numero })
                .ForeignKey("dbo.Defectos", t => t.Defecto_Id)
                .ForeignKey("dbo.Material", t => t.Material1_Id)
                .ForeignKey("dbo.Material", t => t.Material2_Id)
                .ForeignKey("dbo.Material", t => t.Material3_Id)
                .ForeignKey("dbo.OrdenesTrabajo", t => t.OT)
                .ForeignKey("dbo.Procesos", t => t.Proceso_Id)
                .ForeignKey("dbo.Maquinas", t => t.Maquina_Id)
                .Index(t => t.OT)
                .Index(t => t.Proceso_Id)
                .Index(t => t.Defecto_Id)
                .Index(t => t.Material1_Id)
                .Index(t => t.Material2_Id)
                .Index(t => t.Material3_Id)
                .Index(t => t.Maquina_Id);
            
            CreateTable(
                "dbo.Defectos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreDefecto = c.String(maxLength: 500, storeType: "nvarchar"),
                        FamiliaDefectos_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamiliasDefectos", t => t.FamiliaDefectos_Id)
                .Index(t => t.FamiliaDefectos_Id);
            
            CreateTable(
                "dbo.FamiliasDefectos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreFamiliaDefecto = c.String(maxLength: 500, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Procesos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NombreProceso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rodillos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Medida = c.Double(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Maquina_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maquinas", t => t.Maquina_Id)
                .Index(t => t.Maquina_Id);
            
            CreateTable(
                "dbo.TiposMaquina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo_Maquina = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TiposProducto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreTipoProducto = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recetas", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Recetas", "TipoProducto_Id", "dbo.TiposProducto");
            DropForeignKey("dbo.OrdenesTrabajo", "Receta_Id", "dbo.Recetas");
            DropForeignKey("dbo.Tarimas", "Embarque_Id", "dbo.Embarques");
            DropForeignKey("dbo.Produccion", "Tarima_Id", "dbo.Tarimas");
            DropForeignKey("dbo.Produccion", "OT", "dbo.OrdenesTrabajo");
            DropForeignKey("dbo.Maquinas", "TipoMaquina_Id", "dbo.TiposMaquina");
            DropForeignKey("dbo.Rodillos", "Maquina_Id", "dbo.Maquinas");
            DropForeignKey("dbo.Recetas", "Rodillo_Id", "dbo.Rodillos");
            DropForeignKey("dbo.Produccion", "Maquina_Id", "dbo.Maquinas");
            DropForeignKey("dbo.Desperdicios", "Maquina_Id", "dbo.Maquinas");
            DropForeignKey("dbo.Desperdicios", "Proceso_Id", "dbo.Procesos");
            DropForeignKey("dbo.Produccion", "ProcesoId", "dbo.Procesos");
            DropForeignKey("dbo.Desperdicios", "OT", "dbo.OrdenesTrabajo");
            DropForeignKey("dbo.Desperdicios", "Material3_Id", "dbo.Material");
            DropForeignKey("dbo.Desperdicios", "Material2_Id", "dbo.Material");
            DropForeignKey("dbo.Desperdicios", "Material1_Id", "dbo.Material");
            DropForeignKey("dbo.Desperdicios", "Defecto_Id", "dbo.Defectos");
            DropForeignKey("dbo.Defectos", "FamiliaDefectos_Id", "dbo.FamiliasDefectos");
            DropForeignKey("dbo.Embarques", "OrdenTrabajo_OT", "dbo.OrdenesTrabajo");
            DropForeignKey("dbo.Recetas", "MaterialTrilaminacion_Id", "dbo.Material");
            DropForeignKey("dbo.Recetas", "MaterialLaminacion_Id", "dbo.Material");
            DropForeignKey("dbo.Recetas", "MaterialBase_Id", "dbo.Material");
            DropForeignKey("dbo.Material", "FamiliaMateriales_Id", "dbo.FamiliasMaterial");
            DropIndex("dbo.Rodillos", new[] { "Maquina_Id" });
            DropIndex("dbo.Defectos", new[] { "FamiliaDefectos_Id" });
            DropIndex("dbo.Desperdicios", new[] { "Maquina_Id" });
            DropIndex("dbo.Desperdicios", new[] { "Material3_Id" });
            DropIndex("dbo.Desperdicios", new[] { "Material2_Id" });
            DropIndex("dbo.Desperdicios", new[] { "Material1_Id" });
            DropIndex("dbo.Desperdicios", new[] { "Defecto_Id" });
            DropIndex("dbo.Desperdicios", new[] { "Proceso_Id" });
            DropIndex("dbo.Desperdicios", new[] { "OT" });
            DropIndex("dbo.Maquinas", new[] { "TipoMaquina_Id" });
            DropIndex("dbo.Produccion", new[] { "Tarima_Id" });
            DropIndex("dbo.Produccion", new[] { "Maquina_Id" });
            DropIndex("dbo.Produccion", "Unique_for_OT_Produccion");
            DropIndex("dbo.Tarimas", new[] { "Embarque_Id" });
            DropIndex("dbo.Embarques", new[] { "OrdenTrabajo_OT" });
            DropIndex("dbo.Embarques", "EmbarqueNumero");
            DropIndex("dbo.OrdenesTrabajo", new[] { "Receta_Id" });
            DropIndex("dbo.OrdenesTrabajo", new[] { "OT" });
            DropIndex("dbo.Material", new[] { "FamiliaMateriales_Id" });
            DropIndex("dbo.Recetas", new[] { "Cliente_Id" });
            DropIndex("dbo.Recetas", new[] { "TipoProducto_Id" });
            DropIndex("dbo.Recetas", new[] { "Rodillo_Id" });
            DropIndex("dbo.Recetas", new[] { "MaterialTrilaminacion_Id" });
            DropIndex("dbo.Recetas", new[] { "MaterialLaminacion_Id" });
            DropIndex("dbo.Recetas", new[] { "MaterialBase_Id" });
            DropIndex("dbo.Recetas", new[] { "DisenoAutorizado" });
            DropIndex("dbo.Recetas", new[] { "Producto" });
            DropIndex("dbo.Recetas", new[] { "ClaveIntelisis" });
            DropIndex("dbo.Clientes", "ClaveCliente_IDX");
            DropTable("dbo.TiposProducto");
            DropTable("dbo.TiposMaquina");
            DropTable("dbo.Rodillos");
            DropTable("dbo.Procesos");
            DropTable("dbo.FamiliasDefectos");
            DropTable("dbo.Defectos");
            DropTable("dbo.Desperdicios");
            DropTable("dbo.Maquinas");
            DropTable("dbo.Produccion");
            DropTable("dbo.Tarimas");
            DropTable("dbo.Embarques");
            DropTable("dbo.OrdenesTrabajo");
            DropTable("dbo.FamiliasMaterial");
            DropTable("dbo.Material");
            DropTable("dbo.Recetas");
            DropTable("dbo.Clientes");
        }
    }
}
