namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
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
                        ClaveIntelisis = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        Producto = c.String(nullable: false, maxLength: 500, storeType: "nvarchar"),
                        DisenoAutorizado = c.String(nullable: false, maxLength: 500, storeType: "nvarchar"),
                        FechaCreacion = c.DateTime(nullable: false, precision: 0),
                        Cliente_Id = c.Int(nullable: false),
                        Rodillo_Id = c.Int(nullable: false),
                        MaterialBase_Id = c.Int(nullable: false),
                        CalibreMaterialBase = c.Double(nullable: false),
                        MaterialLaminacion_Id = c.Int(),
                        CalibreMaterialLaminacion = c.Double(nullable: false),
                        MaterialTrilaminacion_Id = c.Int(),
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
                        TipoProducto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Material", t => t.MaterialBase_Id, cascadeDelete: true)
                .ForeignKey("dbo.Material", t => t.MaterialLaminacion_Id)
                .ForeignKey("dbo.Material", t => t.MaterialTrilaminacion_Id)
                .ForeignKey("dbo.Rodillos", t => t.Rodillo_Id, cascadeDelete: true)
                .ForeignKey("dbo.TiposProducto", t => t.TipoProducto_Id, cascadeDelete: true)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id, cascadeDelete: true)
                .Index(t => t.ClaveIntelisis, unique: true)
                .Index(t => t.Producto)
                .Index(t => t.DisenoAutorizado)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Rodillo_Id)
                .Index(t => t.MaterialBase_Id)
                .Index(t => t.MaterialLaminacion_Id)
                .Index(t => t.MaterialTrilaminacion_Id)
                .Index(t => t.TipoProducto_Id);
            
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Formula = c.String(maxLength: 250, storeType: "nvarchar"),
                        Apariencia = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        Densidad = c.Double(nullable: false),
                        FamiliaMateriales_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamiliasMaterial", t => t.FamiliaMateriales_Id, cascadeDelete: true)
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
                        Receta_Id = c.Int(nullable: false),
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
                    })
                .PrimaryKey(t => t.OT)
                .ForeignKey("dbo.Recetas", t => t.Receta_Id, cascadeDelete: true)
                .Index(t => t.OT, unique: true)
                .Index(t => t.Receta_Id);
            
            CreateTable(
                "dbo.Embarques",
                c => new
                    {
                        claveEmbarque = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        Numero = c.Int(nullable: false),
                        OT = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        FechaEmpaque = c.DateTime(nullable: false, precision: 0),
                        Usuario = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.claveEmbarque)
                .ForeignKey("dbo.OrdenesTrabajo", t => t.OT, cascadeDelete: true)
                .Index(t => new { t.OT, t.Numero }, unique: true, name: "EmbarqueNumero");
            
            CreateTable(
                "dbo.Tarimas",
                c => new
                    {
                        claveTarima = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        numero = c.Int(nullable: false),
                        claveEmbarque = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.claveTarima)
                .ForeignKey("dbo.Embarques", t => t.claveEmbarque, cascadeDelete: true)
                .Index(t => t.numero, unique: true, name: "TarimaNumero")
                .Index(t => t.claveEmbarque);
            
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
                        claveTarima = c.String(maxLength: 250, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Procesos", t => t.ProcesoId, cascadeDelete: true)
                .ForeignKey("dbo.Maquinas", t => t.Maquina_Id, cascadeDelete: true)
                .ForeignKey("dbo.OrdenesTrabajo", t => t.OT, cascadeDelete: true)
                .ForeignKey("dbo.Tarimas", t => t.claveTarima)
                .Index(t => new { t.OT, t.ProcesoId, t.Numero }, unique: true, name: "Unique_for_OT_Produccion")
                .Index(t => t.Maquina_Id)
                .Index(t => t.claveTarima);
            
            CreateTable(
                "dbo.Maquinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreMaquina = c.String(nullable: false, unicode: false),
                        Velocidad = c.Double(nullable: false),
                        Decks = c.Int(nullable: false),
                        TipoMaquina_Id = c.Int(nullable: false),
                        Linea_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lineas", t => t.Linea_Id, cascadeDelete: true)
                .ForeignKey("dbo.TiposMaquina", t => t.TipoMaquina_Id, cascadeDelete: true)
                .Index(t => t.TipoMaquina_Id)
                .Index(t => t.Linea_Id);
            
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
                        Maquina_Id = c.Int(nullable: false),
                        Defecto_Id = c.Int(nullable: false),
                        Material1_Id = c.Int(),
                        Material2_Id = c.Int(),
                        Material3_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.OT, t.Proceso_Id, t.Numero })
                .ForeignKey("dbo.Defectos", t => t.Defecto_Id, cascadeDelete: true)
                .ForeignKey("dbo.Maquinas", t => t.Maquina_Id, cascadeDelete: true)
                .ForeignKey("dbo.Material", t => t.Material1_Id)
                .ForeignKey("dbo.Material", t => t.Material2_Id)
                .ForeignKey("dbo.Material", t => t.Material3_Id)
                .ForeignKey("dbo.OrdenesTrabajo", t => t.OT, cascadeDelete: true)
                .ForeignKey("dbo.Procesos", t => t.Proceso_Id, cascadeDelete: true)
                .Index(t => t.OT)
                .Index(t => t.Proceso_Id)
                .Index(t => t.Maquina_Id)
                .Index(t => t.Defecto_Id)
                .Index(t => t.Material1_Id)
                .Index(t => t.Material2_Id)
                .Index(t => t.Material3_Id);
            
            CreateTable(
                "dbo.Defectos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreDefecto = c.String(maxLength: 500, storeType: "nvarchar"),
                        FamiliaDefectos_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamiliasDefectos", t => t.FamiliaDefectos_Id, cascadeDelete: true)
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
                        NombreProceso = c.String(maxLength: 250, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Lineas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .ForeignKey("dbo.Maquinas", t => t.Maquina_Id, cascadeDelete: true)
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
            
            CreateTable(
                "dbo.Etiquetas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        ZPLCode = c.String(unicode: false),
                        Definition = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nombre, unique: true);
            
            CreateTable(
                "dbo.Z_Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Z_UsuariosRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Z_Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Z_Usuarios", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TEMPCAPT",
                c => new
                    {
                        OT = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Id = c.Int(nullable: false),
                        DISENIOAUT = c.String(unicode: false),
                        CENTROS = c.Int(nullable: false),
                        TINTA = c.Double(nullable: false),
                        ADH1 = c.Double(nullable: false),
                        ADH2 = c.Double(nullable: false),
                        AJUIMP = c.Double(nullable: false),
                        LAMIMP = c.Double(nullable: false),
                        TRIIMP = c.Double(nullable: false),
                        AJULAM = c.Double(nullable: false),
                        LAMLAM = c.Double(nullable: false),
                        TRILAM = c.Double(nullable: false),
                        AJUTRI = c.Double(nullable: false),
                        TRITRI = c.Double(nullable: false),
                        PORCTOLERANCIA = c.Double(nullable: false),
                        ZIPPER = c.Int(nullable: false),
                        ADHPERM = c.Int(nullable: false),
                        ADHREM = c.Int(nullable: false),
                        ESPECIAL = c.Int(nullable: false),
                        ESPECIALLAM = c.Int(nullable: false),
                        ESPECIALREF = c.Int(nullable: false),
                        ML = c.Int(nullable: false),
                        EX1 = c.Int(nullable: false),
                        EX2 = c.Int(nullable: false),
                        EX3 = c.Int(nullable: false),
                        ZIPPER_TYPE = c.Int(nullable: false),
                        MERMAPROCESO = c.Double(nullable: false),
                        ENABLED = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OT)
                .ForeignKey("dbo.TORDENTRABAJO", t => t.OT)
                .Index(t => t.OT);
            
            CreateTable(
                "dbo.TORDENTRABAJO",
                c => new
                    {
                        OT = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        TIPO = c.Int(nullable: false),
                        FECHARECIBIDO = c.DateTime(nullable: false, precision: 0),
                        FECHAENTREGASOL = c.DateTime(nullable: false, precision: 0),
                        CLIENTE = c.String(unicode: false),
                        PRODUCTO = c.String(unicode: false),
                        CANTIDAD = c.Double(nullable: false),
                        UNIDAD = c.String(unicode: false),
                        ANCHO = c.Double(nullable: false),
                        ALTO = c.Double(nullable: false),
                        SOLAPA = c.Double(nullable: false),
                        FUELLELATERAL = c.Double(nullable: false),
                        FUELLEFONDO = c.Double(nullable: false),
                        COPETE = c.Double(nullable: false),
                        AREASELLOREV = c.Double(nullable: false),
                        AREASELLOFONDO = c.Double(nullable: false),
                        TIPOIMPRESION = c.Int(nullable: false),
                        TIPOTRABAJO = c.Int(nullable: false),
                        REPEJE = c.Double(nullable: false),
                        REPDES = c.Double(nullable: false),
                        MATBASE = c.String(unicode: false),
                        MATBASECALIBRE = c.Double(nullable: false),
                        MATBASEKG = c.Double(nullable: false),
                        MATBASEAMU = c.Double(nullable: false),
                        MATLAMINACION = c.String(unicode: false),
                        MATLAMINACIONCALIBRE = c.Double(nullable: false),
                        MATLAMINACIONKG = c.Double(nullable: false),
                        MATLAMINACIONAMU = c.Double(nullable: false),
                        MATTRILAMINACION = c.String(unicode: false),
                        MATTRILAMINACIONCALIBRE = c.Double(nullable: false),
                        MATTRILAMINACIONKG = c.Double(nullable: false),
                        MATTRILAMINACIONAMU = c.Double(nullable: false),
                        CLAVEINTELISIS = c.String(unicode: false),
                        ORDENCOMPRA = c.String(unicode: false),
                        CLAVEPRODUCTO = c.String(unicode: false),
                        IMPRESORA = c.String(unicode: false),
                        RODILLO = c.Double(nullable: false),
                        FIGURASALIDAFINAL = c.Int(nullable: false),
                        EMPATES = c.String(unicode: false),
                        INSTCORTE = c.String(unicode: false),
                        INSTDOBLADO = c.String(unicode: false),
                        INSTEMBOBINADO = c.String(unicode: false),
                        INSTEXTRUSION = c.String(unicode: false),
                        INSTIMPRESION = c.String(unicode: false),
                        INSTLAMINACION = c.String(unicode: false),
                        INSTMANGAS = c.String(unicode: false),
                        INSTREFINADO = c.String(unicode: false),
                        INSTSELLADO = c.String(unicode: false),
                        OBSERVACIONES = c.String(unicode: false),
                        ESIMPRESO = c.String(unicode: false),
                        KGXMILL = c.Double(nullable: false),
                        EXTIPO = c.String(unicode: false),
                        EXCOLOR = c.String(unicode: false),
                        EXTRATADO = c.String(unicode: false),
                        EXDINAS = c.String(unicode: false),
                        EXDESLIZ = c.String(unicode: false),
                        EXANTIESTATICA = c.String(unicode: false),
                        EXKG = c.String(unicode: false),
                        EXANCHO = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.OT);
            
            CreateTable(
                "dbo.Z_Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, unicode: false),
                        ApellidoPaterno = c.String(nullable: false, unicode: false),
                        ApellidoMaterno = c.String(nullable: false, unicode: false),
                        ClaveTrabajador = c.String(maxLength: 10, storeType: "nvarchar"),
                        Email = c.String(unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ClaveTrabajador, unique: true);
            
            CreateTable(
                "dbo.Z_UsuariosClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Z_Usuarios", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Z_UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Z_Usuarios", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Z_UsuariosRoles", "UserId", "dbo.Z_Usuarios");
            DropForeignKey("dbo.Z_UserLogin", "UserId", "dbo.Z_Usuarios");
            DropForeignKey("dbo.Z_UsuariosClaims", "UserId", "dbo.Z_Usuarios");
            DropForeignKey("dbo.TEMPCAPT", "OT", "dbo.TORDENTRABAJO");
            DropForeignKey("dbo.Z_UsuariosRoles", "RoleId", "dbo.Z_Roles");
            DropForeignKey("dbo.Recetas", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Recetas", "TipoProducto_Id", "dbo.TiposProducto");
            DropForeignKey("dbo.OrdenesTrabajo", "Receta_Id", "dbo.Recetas");
            DropForeignKey("dbo.Produccion", "claveTarima", "dbo.Tarimas");
            DropForeignKey("dbo.Produccion", "OT", "dbo.OrdenesTrabajo");
            DropForeignKey("dbo.Maquinas", "TipoMaquina_Id", "dbo.TiposMaquina");
            DropForeignKey("dbo.Rodillos", "Maquina_Id", "dbo.Maquinas");
            DropForeignKey("dbo.Recetas", "Rodillo_Id", "dbo.Rodillos");
            DropForeignKey("dbo.Produccion", "Maquina_Id", "dbo.Maquinas");
            DropForeignKey("dbo.Maquinas", "Linea_Id", "dbo.Lineas");
            DropForeignKey("dbo.Desperdicios", "Proceso_Id", "dbo.Procesos");
            DropForeignKey("dbo.Produccion", "ProcesoId", "dbo.Procesos");
            DropForeignKey("dbo.Desperdicios", "OT", "dbo.OrdenesTrabajo");
            DropForeignKey("dbo.Desperdicios", "Material3_Id", "dbo.Material");
            DropForeignKey("dbo.Desperdicios", "Material2_Id", "dbo.Material");
            DropForeignKey("dbo.Desperdicios", "Material1_Id", "dbo.Material");
            DropForeignKey("dbo.Desperdicios", "Maquina_Id", "dbo.Maquinas");
            DropForeignKey("dbo.Desperdicios", "Defecto_Id", "dbo.Defectos");
            DropForeignKey("dbo.Defectos", "FamiliaDefectos_Id", "dbo.FamiliasDefectos");
            DropForeignKey("dbo.Tarimas", "claveEmbarque", "dbo.Embarques");
            DropForeignKey("dbo.Embarques", "OT", "dbo.OrdenesTrabajo");
            DropForeignKey("dbo.Recetas", "MaterialTrilaminacion_Id", "dbo.Material");
            DropForeignKey("dbo.Recetas", "MaterialLaminacion_Id", "dbo.Material");
            DropForeignKey("dbo.Recetas", "MaterialBase_Id", "dbo.Material");
            DropForeignKey("dbo.Material", "FamiliaMateriales_Id", "dbo.FamiliasMaterial");
            DropIndex("dbo.Z_UserLogin", new[] { "UserId" });
            DropIndex("dbo.Z_UsuariosClaims", new[] { "UserId" });
            DropIndex("dbo.Z_Usuarios", new[] { "ClaveTrabajador" });
            DropIndex("dbo.TEMPCAPT", new[] { "OT" });
            DropIndex("dbo.Z_UsuariosRoles", new[] { "RoleId" });
            DropIndex("dbo.Z_UsuariosRoles", new[] { "UserId" });
            DropIndex("dbo.Etiquetas", new[] { "Nombre" });
            DropIndex("dbo.Rodillos", new[] { "Maquina_Id" });
            DropIndex("dbo.Defectos", new[] { "FamiliaDefectos_Id" });
            DropIndex("dbo.Desperdicios", new[] { "Material3_Id" });
            DropIndex("dbo.Desperdicios", new[] { "Material2_Id" });
            DropIndex("dbo.Desperdicios", new[] { "Material1_Id" });
            DropIndex("dbo.Desperdicios", new[] { "Defecto_Id" });
            DropIndex("dbo.Desperdicios", new[] { "Maquina_Id" });
            DropIndex("dbo.Desperdicios", new[] { "Proceso_Id" });
            DropIndex("dbo.Desperdicios", new[] { "OT" });
            DropIndex("dbo.Maquinas", new[] { "Linea_Id" });
            DropIndex("dbo.Maquinas", new[] { "TipoMaquina_Id" });
            DropIndex("dbo.Produccion", new[] { "claveTarima" });
            DropIndex("dbo.Produccion", new[] { "Maquina_Id" });
            DropIndex("dbo.Produccion", "Unique_for_OT_Produccion");
            DropIndex("dbo.Tarimas", new[] { "claveEmbarque" });
            DropIndex("dbo.Tarimas", "TarimaNumero");
            DropIndex("dbo.Embarques", "EmbarqueNumero");
            DropIndex("dbo.OrdenesTrabajo", new[] { "Receta_Id" });
            DropIndex("dbo.OrdenesTrabajo", new[] { "OT" });
            DropIndex("dbo.Material", new[] { "FamiliaMateriales_Id" });
            DropIndex("dbo.Recetas", new[] { "TipoProducto_Id" });
            DropIndex("dbo.Recetas", new[] { "MaterialTrilaminacion_Id" });
            DropIndex("dbo.Recetas", new[] { "MaterialLaminacion_Id" });
            DropIndex("dbo.Recetas", new[] { "MaterialBase_Id" });
            DropIndex("dbo.Recetas", new[] { "Rodillo_Id" });
            DropIndex("dbo.Recetas", new[] { "Cliente_Id" });
            DropIndex("dbo.Recetas", new[] { "DisenoAutorizado" });
            DropIndex("dbo.Recetas", new[] { "Producto" });
            DropIndex("dbo.Recetas", new[] { "ClaveIntelisis" });
            DropIndex("dbo.Clientes", "ClaveCliente_IDX");
            DropTable("dbo.Z_UserLogin");
            DropTable("dbo.Z_UsuariosClaims");
            DropTable("dbo.Z_Usuarios");
            DropTable("dbo.TORDENTRABAJO");
            DropTable("dbo.TEMPCAPT");
            DropTable("dbo.Z_UsuariosRoles");
            DropTable("dbo.Z_Roles");
            DropTable("dbo.Etiquetas");
            DropTable("dbo.TiposProducto");
            DropTable("dbo.TiposMaquina");
            DropTable("dbo.Rodillos");
            DropTable("dbo.Lineas");
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
