namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VariablesCriticas_Imp_Lam_Ref_V1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VC_Root",
                c => new
                    {
                        ClaveDiseno = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RutaImagenFigura = c.String(unicode: false),
                        Fotocelda_Estandar = c.String(unicode: false),
                        Fotocelda_Minimo = c.String(unicode: false),
                        Fotocelda_Maximo = c.String(unicode: false),
                        Fotocelda_Unidad = c.String(unicode: false),
                        CodigoBarras = c.String(unicode: false),
                        Ancho_Estandar = c.Double(),
                        Ancho_Minimo = c.Double(),
                        Ancho_Maximo = c.Double(),
                        Ancho_Unidad = c.String(unicode: false),
                        Alto_Estandar = c.Double(),
                        Alto_Minimo = c.Double(),
                        Alto_Maximo = c.Double(),
                        Alto_Unidad = c.String(unicode: false),
                        NumeroSobre = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ClaveDiseno);
            
            CreateTable(
                "dbo.VC_Estructura_Items",
                c => new
                    {
                        ClaveDiseno = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Posicion = c.Int(nullable: false),
                        Elemento = c.String(unicode: false),
                        Ancho = c.String(unicode: false),
                        Calibre = c.String(unicode: false),
                        UnidadCalibre = c.Int(nullable: false),
                        Descripcion = c.String(unicode: false),
                        SeImprime = c.Boolean(nullable: false),
                        EsSustrato = c.Boolean(nullable: false),
                        Tratado_Estandar = c.String(unicode: false),
                        Tratado_Minimo = c.String(unicode: false),
                        Tratado_Maximo = c.String(unicode: false),
                        Tratado_Unidad = c.String(unicode: false),
                    })
                .PrimaryKey(t => new { t.ClaveDiseno, t.Posicion })
                .ForeignKey("dbo.VC_Root", t => t.ClaveDiseno, cascadeDelete: true)
                .Index(t => t.ClaveDiseno);
            
            CreateTable(
                "dbo.VC_BaseProcesos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaveDiseno = c.String(maxLength: 128, storeType: "nvarchar"),
                        MaquinaId = c.Int(nullable: false),
                        TipoProceso = c.Int(nullable: false),
                        FiguraSalida = c.Int(nullable: false),
                        Dureza_Estandar = c.Double(),
                        Dureza_Minimo = c.Double(),
                        Dureza_Maximo = c.Double(),
                        Dureza_Unidad = c.String(unicode: false),
                        Comentarios = c.String(unicode: false),
                        ParametroVelocidad_Estandar = c.Double(),
                        ParametroVelocidad_Minimo = c.Double(),
                        ParametroVelocidad_Maximo = c.Double(),
                        ParametroVelocidad_Unidad = c.String(unicode: false),
                        ParametroTensionDecreciente_Estandar = c.Double(),
                        ParametroTensionDecreciente_Minimo = c.Double(),
                        ParametroTensionDecreciente_Maximo = c.Double(),
                        ParametroTensionDecreciente_Unidad = c.String(unicode: false),
                        ParametroPotenciaTratador_Estandar = c.Double(),
                        ParametroPotenciaTratador_Minimo = c.Double(),
                        ParametroPotenciaTratador_Maximo = c.Double(),
                        ParametroPotenciaTratador_Unidad = c.String(unicode: false),
                        FechaCaptura = c.DateTime(nullable: false, precision: 0),
                        FechaActualizacion = c.DateTime(nullable: false, precision: 0),
                        TipoImpresora = c.Int(),
                        TipoTinta = c.String(unicode: false),
                        ParametroPresionRodilloPisorCalandra_Estandar = c.Double(),
                        ParametroPresionRodilloPisorCalandra_Minimo = c.Double(),
                        ParametroPresionRodilloPisorCalandra_Maximo = c.Double(),
                        ParametroPresionRodilloPisorCalandra_Unidad = c.String(unicode: false),
                        ParametroPresionRodilloTamborCentral_Estandar = c.Double(),
                        ParametroPresionRodilloTamborCentral_Minimo = c.Double(),
                        ParametroPresionRodilloTamborCentral_Maximo = c.Double(),
                        ParametroPresionRodilloTamborCentral_Unidad = c.String(unicode: false),
                        ParametroPresionRodilloPisorEmbobinador_Estandar = c.Double(),
                        ParametroPresionRodilloPisorEmbobinador_Minimo = c.Double(),
                        ParametroPresionRodilloPisorEmbobinador_Maximo = c.Double(),
                        ParametroPresionRodilloPisorEmbobinador_Unidad = c.String(unicode: false),
                        ParametroTensionEmbobinador_Estandar = c.Double(),
                        ParametroTensionEmbobinador_Minimo = c.Double(),
                        ParametroTensionEmbobinador_Maximo = c.Double(),
                        ParametroTensionEmbobinador_Unidad = c.String(unicode: false),
                        ParametroTensionBanda_Estandar = c.Double(),
                        ParametroTensionBanda_Minimo = c.Double(),
                        ParametroTensionBanda_Maximo = c.Double(),
                        ParametroTensionBanda_Unidad = c.String(unicode: false),
                        ParametroTensionArrastreODesbobinador_Estandar = c.Double(),
                        ParametroTensionArrastreODesbobinador_Minimo = c.Double(),
                        ParametroTensionArrastreODesbobinador_Maximo = c.Double(),
                        ParametroTensionArrastreODesbobinador_Unidad = c.String(unicode: false),
                        ParametroGearlessTensionRodilloRefrigerante_Estandar = c.Double(),
                        ParametroGearlessTensionRodilloRefrigerante_Minimo = c.Double(),
                        ParametroGearlessTensionRodilloRefrigerante_Maximo = c.Double(),
                        ParametroGearlessTensionRodilloRefrigerante_Unidad = c.String(unicode: false),
                        ParametroGearlessFuerzaApriete_Estandar = c.Double(),
                        ParametroGearlessFuerzaApriete_Minimo = c.Double(),
                        ParametroGearlessFuerzaApriete_Maximo = c.Double(),
                        ParametroGearlessFuerzaApriete_Unidad = c.String(unicode: false),
                        ParametroGearlessDiametroInicial = c.Double(),
                        ParametroGearlessDiametroFinal = c.Double(),
                        ParametroEngranesPresionBalancinEmbobinador_Estandar = c.Double(),
                        ParametroEngranesPresionBalancinEmbobinador_Minimo = c.Double(),
                        ParametroEngranesPresionBalancinEmbobinador_Maximo = c.Double(),
                        ParametroEngranesPresionBalancinEmbobinador_Unidad = c.String(unicode: false),
                        ParametroEngranesPresionBalancinDesbobinador_Estandar = c.Double(),
                        ParametroEngranesPresionBalancinDesbobinador_Minimo = c.Double(),
                        ParametroEngranesPresionBalancinDesbobinador_Maximo = c.Double(),
                        ParametroEngranesPresionBalancinDesbobinador_Unidad = c.String(unicode: false),
                        ParametroEngranesOffset_Estandar = c.Double(),
                        ParametroEngranesOffset_Minimo = c.Double(),
                        ParametroEngranesOffset_Maximo = c.Double(),
                        ParametroEngranesOffset_Unidad = c.String(unicode: false),
                        ParametroTemperaturaPuente_Estandar = c.String(unicode: false),
                        ParametroTemperaturaPuente_Minimo = c.String(unicode: false),
                        ParametroTemperaturaPuente_Maximo = c.String(unicode: false),
                        ParametroTemperaturaPuente_Unidad = c.String(unicode: false),
                        ParametroTemperaturaEntrecolores_Estandar = c.String(unicode: false),
                        ParametroTemperaturaEntrecolores_Minimo = c.String(unicode: false),
                        ParametroTemperaturaEntrecolores_Maximo = c.String(unicode: false),
                        ParametroTemperaturaEntrecolores_Unidad = c.String(unicode: false),
                        GomaMedida = c.Double(),
                        GomaAnchoUtil = c.Double(),
                        GomaAnchoTotal = c.Double(),
                        GomaComentarios = c.String(unicode: false),
                        AdhesivoResinaClave = c.String(unicode: false),
                        AdhesivoCatalizadorClave = c.String(unicode: false),
                        ParametroAdhesivoCatalizadorRelacion_Estandar = c.Double(),
                        ParametroAdhesivoCatalizadorRelacion_Minimo = c.Double(),
                        ParametroAdhesivoCatalizadorRelacion_Maximo = c.Double(),
                        ParametroAdhesivoCatalizadorRelacion_Unidad = c.String(unicode: false),
                        ParametroAdhesivoAplicacion_Estandar = c.Double(),
                        ParametroAdhesivoAplicacion_Minimo = c.Double(),
                        ParametroAdhesivoAplicacion_Maximo = c.Double(),
                        ParametroAdhesivoAplicacion_Unidad = c.String(unicode: false),
                        ParametroTemperaturaResina_Estandar = c.Double(),
                        ParametroTemperaturaResina_Minimo = c.Double(),
                        ParametroTemperaturaResina_Maximo = c.Double(),
                        ParametroTemperaturaResina_Unidad = c.String(unicode: false),
                        ParametroTemperaturaCatalizador_Estandar = c.Double(),
                        ParametroTemperaturaCatalizador_Minimo = c.Double(),
                        ParametroTemperaturaCatalizador_Maximo = c.Double(),
                        ParametroTemperaturaCatalizador_Unidad = c.String(unicode: false),
                        ParametroTemperaturaRodilloAplicador_Estandar = c.Double(),
                        ParametroTemperaturaRodilloAplicador_Minimo = c.Double(),
                        ParametroTemperaturaRodilloAplicador_Maximo = c.Double(),
                        ParametroTemperaturaRodilloAplicador_Unidad = c.String(unicode: false),
                        ParametroTemperaturaRodilloLaminador_Estandar = c.Double(),
                        ParametroTemperaturaRodilloLaminador_Minimo = c.Double(),
                        ParametroTemperaturaRodilloLaminador_Maximo = c.Double(),
                        ParametroTemperaturaRodilloLaminador_Unidad = c.String(unicode: false),
                        ParametroPresionRodilloMangas_Estandar = c.Double(),
                        ParametroPresionRodilloMangas_Minimo = c.Double(),
                        ParametroPresionRodilloMangas_Maximo = c.Double(),
                        ParametroPresionRodilloMangas_Unidad = c.String(unicode: false),
                        ParametroPresionRodilloLaminadorIzquierdo_Estandar = c.Double(),
                        ParametroPresionRodilloLaminadorIzquierdo_Minimo = c.Double(),
                        ParametroPresionRodilloLaminadorIzquierdo_Maximo = c.Double(),
                        ParametroPresionRodilloLaminadorIzquierdo_Unidad = c.String(unicode: false),
                        ParametroPresionRodilloLaminadorDerecho_Estandar = c.Double(),
                        ParametroPresionRodilloLaminadorDerecho_Minimo = c.Double(),
                        ParametroPresionRodilloLaminadorDerecho_Maximo = c.Double(),
                        ParametroPresionRodilloLaminadorDerecho_Unidad = c.String(unicode: false),
                        ParametroPresionRodilloPresorIzquierdo_Estandar = c.Double(),
                        ParametroPresionRodilloPresorIzquierdo_Minimo = c.Double(),
                        ParametroPresionRodilloPresorIzquierdo_Maximo = c.Double(),
                        ParametroPresionRodilloPresorIzquierdo_Unidad = c.String(unicode: false),
                        ParametroPresionRodilloPresorDerecho_Estandar = c.Double(),
                        ParametroPresionRodilloPresorDerecho_Minimo = c.Double(),
                        ParametroPresionRodilloPresorDerecho_Maximo = c.Double(),
                        ParametroPresionRodilloPresorDerecho_Unidad = c.String(unicode: false),
                        ParametroPresionRodilloAplicador_Estandar = c.Double(),
                        ParametroPresionRodilloAplicador_Minimo = c.Double(),
                        ParametroPresionRodilloAplicador_Maximo = c.Double(),
                        ParametroPresionRodilloAplicador_Unidad = c.String(unicode: false),
                        ParametroGalgaIzquierda_Estandar = c.Double(),
                        ParametroGalgaIzquierda_Minimo = c.Double(),
                        ParametroGalgaIzquierda_Maximo = c.Double(),
                        ParametroGalgaIzquierda_Unidad = c.String(unicode: false),
                        ParametroGalgaDerecha_Estandar = c.Double(),
                        ParametroGalgaDerecha_Minimo = c.Double(),
                        ParametroGalgaDerecha_Maximo = c.Double(),
                        ParametroGalgaDerecha_Unidad = c.String(unicode: false),
                        ParametroTensionDesbobinadorUno_Estandar = c.Double(),
                        ParametroTensionDesbobinadorUno_Minimo = c.Double(),
                        ParametroTensionDesbobinadorUno_Maximo = c.Double(),
                        ParametroTensionDesbobinadorUno_Unidad = c.String(unicode: false),
                        ParametroTensionDesbobinadorDos_Estandar = c.Double(),
                        ParametroTensionDesbobinadorDos_Minimo = c.Double(),
                        ParametroTensionDesbobinadorDos_Maximo = c.Double(),
                        ParametroTensionDesbobinadorDos_Unidad = c.String(unicode: false),
                        ParametroTensionBobinador_Estandar = c.Double(),
                        ParametroTensionBobinador_Minimo = c.Double(),
                        ParametroTensionBobinador_Maximo = c.Double(),
                        ParametroTensionBobinador_Unidad = c.String(unicode: false),
                        ParametroTensionPuente_Estandar = c.Double(),
                        ParametroTensionPuente_Minimo = c.Double(),
                        ParametroTensionPuente_Maximo = c.Double(),
                        ParametroTensionPuente_Unidad = c.String(unicode: false),
                        Curling_Estandar = c.Double(),
                        Curling_Minimo = c.Double(),
                        Curling_Maximo = c.Double(),
                        Curling_Unidad = c.String(unicode: false),
                        FuerzaLaminacionUno_Estandar = c.Double(),
                        FuerzaLaminacionUno_Minimo = c.Double(),
                        FuerzaLaminacionUno_Maximo = c.Double(),
                        FuerzaLaminacionUno_Unidad = c.String(unicode: false),
                        FuerzaLaminacionDos_Estandar = c.Double(),
                        FuerzaLaminacionDos_Minimo = c.Double(),
                        FuerzaLaminacionDos_Maximo = c.Double(),
                        FuerzaLaminacionDos_Unidad = c.String(unicode: false),
                        DesbobinadorUnoElemento = c.String(unicode: false),
                        DesbobinadorUnoTratado_Estandar = c.String(unicode: false),
                        DesbobinadorUnoTratado_Minimo = c.String(unicode: false),
                        DesbobinadorUnoTratado_Maximo = c.String(unicode: false),
                        DesbobinadorUnoTratado_Unidad = c.String(unicode: false),
                        DesbobinadorDosElemento = c.String(unicode: false),
                        DesbobinadorDosTratado_Estandar = c.String(unicode: false),
                        DesbobinadorDosTratado_Minimo = c.String(unicode: false),
                        DesbobinadorDosTratado_Maximo = c.String(unicode: false),
                        DesbobinadorDosTratado_Unidad = c.String(unicode: false),
                        Core = c.Int(),
                        Marca = c.String(unicode: false),
                        VariableSecundaria = c.String(unicode: false),
                        VariablePrincipal = c.String(unicode: false),
                        VariablePrincipalTolerancias_Estandar = c.String(unicode: false),
                        VariablePrincipalTolerancias_Minimo = c.String(unicode: false),
                        VariablePrincipalTolerancias_Maximo = c.String(unicode: false),
                        VariablePrincipalTolerancias_Unidad = c.String(unicode: false),
                        ParametroTensionDesbobinador_Estandar = c.Double(),
                        ParametroTensionDesbobinador_Minimo = c.Double(),
                        ParametroTensionDesbobinador_Maximo = c.Double(),
                        ParametroTensionDesbobinador_Unidad = c.String(unicode: false),
                        ParametroTensionBobinadorSuperior_Estandar = c.Double(),
                        ParametroTensionBobinadorSuperior_Minimo = c.Double(),
                        ParametroTensionBobinadorSuperior_Maximo = c.Double(),
                        ParametroTensionBobinadorSuperior_Unidad = c.String(unicode: false),
                        ParametroTensionBobinadorInferior_Estandar = c.Double(),
                        ParametroTensionBobinadorInferior_Minimo = c.Double(),
                        ParametroTensionBobinadorInferior_Maximo = c.Double(),
                        ParametroTensionBobinadorInferior_Unidad = c.String(unicode: false),
                        ParametroPresionRodilloPisorSuperior_Estandar = c.Double(),
                        ParametroPresionRodilloPisorSuperior_Minimo = c.Double(),
                        ParametroPresionRodilloPisorSuperior_Maximo = c.Double(),
                        ParametroPresionRodilloPisorSuperior_Unidad = c.String(unicode: false),
                        ParametroPresionRodilloPisorInferior_Estandar = c.Double(),
                        ParametroPresionRodilloPisorInferior_Minimo = c.Double(),
                        ParametroPresionRodilloPisorInferior_Maximo = c.Double(),
                        ParametroPresionRodilloPisorInferior_Unidad = c.String(unicode: false),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maquinas", t => t.MaquinaId, cascadeDelete: true)
                .ForeignKey("dbo.Procesos", t => t.TipoProceso, cascadeDelete: true)
                .ForeignKey("dbo.VC_Root", t => t.ClaveDiseno)
                .Index(t => new { t.ClaveDiseno, t.MaquinaId, t.TipoProceso }, unique: true, name: "UniqueBase");
            
            CreateTable(
                "dbo.VC_DecksImpresion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProceso = c.Int(nullable: false),
                        Unidad = c.Int(nullable: false),
                        Color = c.String(unicode: false),
                        Descripcion = c.String(unicode: false),
                        Anilox = c.String(unicode: false),
                        Stickyback = c.String(unicode: false),
                        L = c.Double(),
                        A = c.Double(),
                        B = c.Double(),
                        Densidad = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VC_BaseProcesos", t => t.IdProceso, cascadeDelete: true)
                .Index(t => new { t.IdProceso, t.Unidad }, unique: true, name: "UniqueDeck");
            
            AddColumn("dbo.TORDENTRABAJO", "VC_ClaveDiseno", c => c.String(maxLength: 128, storeType: "nvarchar"));
            CreateIndex("dbo.TORDENTRABAJO", "VC_ClaveDiseno");
            AddForeignKey("dbo.TORDENTRABAJO", "VC_ClaveDiseno", "dbo.VC_Root", "ClaveDiseno");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TORDENTRABAJO", "VC_ClaveDiseno", "dbo.VC_Root");
            DropForeignKey("dbo.VC_DecksImpresion", "IdProceso", "dbo.VC_BaseProcesos");
            DropForeignKey("dbo.VC_BaseProcesos", "ClaveDiseno", "dbo.VC_Root");
            DropForeignKey("dbo.VC_BaseProcesos", "TipoProceso", "dbo.Procesos");
            DropForeignKey("dbo.VC_BaseProcesos", "MaquinaId", "dbo.Maquinas");
            DropForeignKey("dbo.VC_Estructura_Items", "ClaveDiseno", "dbo.VC_Root");
            DropIndex("dbo.VC_DecksImpresion", "UniqueDeck");
            DropIndex("dbo.VC_BaseProcesos", "UniqueBase");
            DropIndex("dbo.VC_Estructura_Items", new[] { "ClaveDiseno" });
            DropIndex("dbo.TORDENTRABAJO", new[] { "VC_ClaveDiseno" });
            DropColumn("dbo.TORDENTRABAJO", "VC_ClaveDiseno");
            DropTable("dbo.VC_DecksImpresion");
            DropTable("dbo.VC_BaseProcesos");
            DropTable("dbo.VC_Estructura_Items");
            DropTable("dbo.VC_Root");
        }
    }
}
