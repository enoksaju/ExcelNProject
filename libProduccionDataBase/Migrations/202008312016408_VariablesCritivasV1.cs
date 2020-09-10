namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VariablesCritivasV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VC_Root",
                c => new
                    {
                        ClaveDiseno = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RutaImagenFigura = c.String(unicode: false),
                        FechaCaptura = c.DateTime(nullable: false, precision: 0),
                        Fotocelda_Estandar = c.String(unicode: false),
                        Fotocelda_Minimo = c.String(unicode: false),
                        Fotocelda_Maximo = c.String(unicode: false),
                        Fotocelda_Unidad = c.String(unicode: false),
                        CodigoBarras = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ClaveDiseno)
                .ForeignKey("dbo.VC_Estructura", t => t.ClaveDiseno)
                .Index(t => t.ClaveDiseno);
            
            CreateTable(
                "dbo.VC_Impresion",
                c => new
                    {
                        ClaveDiseno = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        MaquinaId = c.Int(nullable: false),
                        TipoImpresora = c.Int(nullable: false),
                        FiguraSalida = c.Int(nullable: false),
                        TipoTinta = c.String(unicode: false),
                        NumeroSobre = c.String(unicode: false),
                        Ancho_Estandar = c.Double(),
                        Ancho_Minimo = c.Double(),
                        Ancho_Maximo = c.Double(),
                        Ancho_Unidad = c.String(unicode: false),
                        Alto_Estandar = c.Double(),
                        Alto_Minimo = c.Double(),
                        Alto_Maximo = c.Double(),
                        Alto_Unidad = c.String(unicode: false),
                        Dureza_Estandar = c.Double(),
                        Dureza_Minimo = c.Double(),
                        Dureza_Maximo = c.Double(),
                        Dureza_Unidad = c.String(unicode: false),
                        Velocidad_Estandar = c.Double(),
                        Velocidad_Minimo = c.Double(),
                        Velocidad_Maximo = c.Double(),
                        Velocidad_Unidad = c.String(unicode: false),
                        PresionRodilloPisorCalandra_Estandar = c.Double(),
                        PresionRodilloPisorCalandra_Minimo = c.Double(),
                        PresionRodilloPisorCalandra_Maximo = c.Double(),
                        PresionRodilloPisorCalandra_Unidad = c.String(unicode: false),
                        PresionRodilloTamborCentral_Estandar = c.Double(),
                        PresionRodilloTamborCentral_Minimo = c.Double(),
                        PresionRodilloTamborCentral_Maximo = c.Double(),
                        PresionRodilloTamborCentral_Unidad = c.String(unicode: false),
                        PresionRodilloPisorEmbobinador_Estandar = c.Double(),
                        PresionRodilloPisorEmbobinador_Minimo = c.Double(),
                        PresionRodilloPisorEmbobinador_Maximo = c.Double(),
                        PresionRodilloPisorEmbobinador_Unidad = c.String(unicode: false),
                        PotenciaTratador_Estandar = c.Double(),
                        PotenciaTratador_Minimo = c.Double(),
                        PotenciaTratador_Maximo = c.Double(),
                        PotenciaTratador_Unidad = c.String(unicode: false),
                        TensionEmbobinador_Estandar = c.Double(),
                        TensionEmbobinador_Minimo = c.Double(),
                        TensionEmbobinador_Maximo = c.Double(),
                        TensionEmbobinador_Unidad = c.String(unicode: false),
                        TensionBanda_Estandar = c.Double(),
                        TensionBanda_Minimo = c.Double(),
                        TensionBanda_Maximo = c.Double(),
                        TensionBanda_Unidad = c.String(unicode: false),
                        TensionArrastreODesbobinador_Estandar = c.Double(),
                        TensionArrastreODesbobinador_Minimo = c.Double(),
                        TensionArrastreODesbobinador_Maximo = c.Double(),
                        TensionArrastreODesbobinador_Unidad = c.String(unicode: false),
                        G_TensionRodilloRefrigerante_Estandar = c.Double(),
                        G_TensionRodilloRefrigerante_Minimo = c.Double(),
                        G_TensionRodilloRefrigerante_Maximo = c.Double(),
                        G_TensionRodilloRefrigerante_Unidad = c.String(unicode: false),
                        G_FuerzaApriete_Estandar = c.Double(),
                        G_FuerzaApriete_Minimo = c.Double(),
                        G_FuerzaApriete_Maximo = c.Double(),
                        G_FuerzaApriete_Unidad = c.String(unicode: false),
                        G_IndiceReduccion_Estandar = c.Double(),
                        G_IndiceReduccion_Minimo = c.Double(),
                        G_IndiceReduccion_Maximo = c.Double(),
                        G_IndiceReduccion_Unidad = c.String(unicode: false),
                        G_DiametroInicial = c.Double(),
                        G_DiametroFinal = c.Double(),
                        E_PresionBalancinEmbobinador_Estandar = c.Double(),
                        E_PresionBalancinEmbobinador_Minimo = c.Double(),
                        E_PresionBalancinEmbobinador_Maximo = c.Double(),
                        E_PresionBalancinEmbobinador_Unidad = c.String(unicode: false),
                        E_PresionBalancinDesbobinador_Estandar = c.Double(),
                        E_PresionBalancinDesbobinador_Minimo = c.Double(),
                        E_PresionBalancinDesbobinador_Maximo = c.Double(),
                        E_PresionBalancinDesbobinador_Unidad = c.String(unicode: false),
                        E_Offset_Estandar = c.Double(),
                        E_Offset_Minimo = c.Double(),
                        E_Offset_Maximo = c.Double(),
                        E_Offset_Unidad = c.String(unicode: false),
                        TemperaturaPuente_Estandar = c.String(unicode: false),
                        TemperaturaPuente_Minimo = c.String(unicode: false),
                        TemperaturaPuente_Maximo = c.String(unicode: false),
                        TemperaturaPuente_Unidad = c.String(unicode: false),
                        TemperaturaEntrecolores_Estandar = c.String(unicode: false),
                        TemperaturaEntrecolores_Minimo = c.String(unicode: false),
                        TemperaturaEntrecolores_Maximo = c.String(unicode: false),
                        TemperaturaEntrecolores_Unidad = c.String(unicode: false),
                        Comentarios = c.String(unicode: false),
                        Unidad1_Color = c.String(unicode: false),
                        Unidad1_Descripcion = c.String(unicode: false),
                        Unidad1_Anilox = c.String(unicode: false),
                        Unidad1_Stickyback = c.String(unicode: false),
                        Unidad1_L = c.Double(),
                        Unidad1_A = c.Double(),
                        Unidad1_B = c.Double(),
                        Unidad1_Densidad = c.Double(),
                        Unidad2_Color = c.String(unicode: false),
                        Unidad2_Descripcion = c.String(unicode: false),
                        Unidad2_Anilox = c.String(unicode: false),
                        Unidad2_Stickyback = c.String(unicode: false),
                        Unidad2_L = c.Double(),
                        Unidad2_A = c.Double(),
                        Unidad2_B = c.Double(),
                        Unidad2_Densidad = c.Double(),
                        Unidad3_Color = c.String(unicode: false),
                        Unidad3_Descripcion = c.String(unicode: false),
                        Unidad3_Anilox = c.String(unicode: false),
                        Unidad3_Stickyback = c.String(unicode: false),
                        Unidad3_L = c.Double(),
                        Unidad3_A = c.Double(),
                        Unidad3_B = c.Double(),
                        Unidad3_Densidad = c.Double(),
                        Unidad4_Color = c.String(unicode: false),
                        Unidad4_Descripcion = c.String(unicode: false),
                        Unidad4_Anilox = c.String(unicode: false),
                        Unidad4_Stickyback = c.String(unicode: false),
                        Unidad4_L = c.Double(),
                        Unidad4_A = c.Double(),
                        Unidad4_B = c.Double(),
                        Unidad4_Densidad = c.Double(),
                        Unidad5_Color = c.String(unicode: false),
                        Unidad5_Descripcion = c.String(unicode: false),
                        Unidad5_Anilox = c.String(unicode: false),
                        Unidad5_Stickyback = c.String(unicode: false),
                        Unidad5_L = c.Double(),
                        Unidad5_A = c.Double(),
                        Unidad5_B = c.Double(),
                        Unidad5_Densidad = c.Double(),
                        Unidad6_Color = c.String(unicode: false),
                        Unidad6_Descripcion = c.String(unicode: false),
                        Unidad6_Anilox = c.String(unicode: false),
                        Unidad6_Stickyback = c.String(unicode: false),
                        Unidad6_L = c.Double(),
                        Unidad6_A = c.Double(),
                        Unidad6_B = c.Double(),
                        Unidad6_Densidad = c.Double(),
                        Unidad7_Color = c.String(unicode: false),
                        Unidad7_Descripcion = c.String(unicode: false),
                        Unidad7_Anilox = c.String(unicode: false),
                        Unidad7_Stickyback = c.String(unicode: false),
                        Unidad7_L = c.Double(),
                        Unidad7_A = c.Double(),
                        Unidad7_B = c.Double(),
                        Unidad7_Densidad = c.Double(),
                        Unidad8_Color = c.String(unicode: false),
                        Unidad8_Descripcion = c.String(unicode: false),
                        Unidad8_Anilox = c.String(unicode: false),
                        Unidad8_Stickyback = c.String(unicode: false),
                        Unidad8_L = c.Double(),
                        Unidad8_A = c.Double(),
                        Unidad8_B = c.Double(),
                        Unidad8_Densidad = c.Double(),
                        Unidad9_Color = c.String(unicode: false),
                        Unidad9_Descripcion = c.String(unicode: false),
                        Unidad9_Anilox = c.String(unicode: false),
                        Unidad9_Stickyback = c.String(unicode: false),
                        Unidad9_L = c.Double(),
                        Unidad9_A = c.Double(),
                        Unidad9_B = c.Double(),
                        Unidad9_Densidad = c.Double(),
                        Unidad10_Color = c.String(unicode: false),
                        Unidad10_Descripcion = c.String(unicode: false),
                        Unidad10_Anilox = c.String(unicode: false),
                        Unidad10_Stickyback = c.String(unicode: false),
                        Unidad10_L = c.Double(),
                        Unidad10_A = c.Double(),
                        Unidad10_B = c.Double(),
                        Unidad10_Densidad = c.Double(),
                        FechaCaptura = c.DateTime(nullable: false, precision: 0),
                        FechaActualizacion = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => new { t.ClaveDiseno, t.MaquinaId })
                .ForeignKey("dbo.Maquinas", t => t.MaquinaId, cascadeDelete: true)
                .ForeignKey("dbo.VC_Root", t => t.ClaveDiseno, cascadeDelete: true)
                .Index(t => t.ClaveDiseno)
                .Index(t => t.MaquinaId);
            
            CreateTable(
                "dbo.VC_Estructura",
                c => new
                    {
                        ClaveDiseno = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        FechaCaptura = c.DateTime(nullable: false, precision: 0),
                        FechaUltimaActualizacion = c.DateTime(nullable: false, precision: 0),
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
                .ForeignKey("dbo.VC_Estructura", t => t.ClaveDiseno, cascadeDelete: true)
                .Index(t => t.ClaveDiseno);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VC_Root", "ClaveDiseno", "dbo.VC_Estructura");
            DropForeignKey("dbo.VC_Estructura_Items", "ClaveDiseno", "dbo.VC_Estructura");
            DropForeignKey("dbo.VC_Impresion", "ClaveDiseno", "dbo.VC_Root");
            DropForeignKey("dbo.VC_Impresion", "MaquinaId", "dbo.Maquinas");
            DropIndex("dbo.VC_Estructura_Items", new[] { "ClaveDiseno" });
            DropIndex("dbo.VC_Impresion", new[] { "MaquinaId" });
            DropIndex("dbo.VC_Impresion", new[] { "ClaveDiseno" });
            DropIndex("dbo.VC_Root", new[] { "ClaveDiseno" });
            DropTable("dbo.VC_Estructura_Items");
            DropTable("dbo.VC_Estructura");
            DropTable("dbo.VC_Impresion");
            DropTable("dbo.VC_Root");
        }
    }
}
