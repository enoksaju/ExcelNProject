using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace excelnobleza.shared.db.Migrations
{
    public partial class VC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClaveDiseno",
                table: "TORDENTRABAJO",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "vc_diseno",
                columns: table => new
                {
                    ClaveDiseno = table.Column<string>(maxLength: 200, nullable: false),
                    TamañoFotocelda_Alto_Std = table.Column<double>(nullable: true),
                    TamañoFotocelda_Alto_Min = table.Column<double>(nullable: true),
                    TamañoFotocelda_Alto_Max = table.Column<double>(nullable: true),
                    TamañoFotocelda_Alto_Unidad = table.Column<string>(nullable: true),
                    TamañoFotocelda_Ancho_Std = table.Column<double>(nullable: true),
                    TamañoFotocelda_Ancho_Min = table.Column<double>(nullable: true),
                    TamañoFotocelda_Ancho_Max = table.Column<double>(nullable: true),
                    TamañoFotocelda_Ancho_Unidad = table.Column<string>(nullable: true),
                    TamañoDiseño_Alto_Std = table.Column<double>(nullable: true),
                    TamañoDiseño_Alto_Min = table.Column<double>(nullable: true),
                    TamañoDiseño_Alto_Max = table.Column<double>(nullable: true),
                    TamañoDiseño_Alto_Unidad = table.Column<string>(nullable: true),
                    TamañoDiseño_Ancho_Std = table.Column<double>(nullable: true),
                    TamañoDiseño_Ancho_Min = table.Column<double>(nullable: true),
                    TamañoDiseño_Ancho_Max = table.Column<double>(nullable: true),
                    TamañoDiseño_Ancho_Unidad = table.Column<string>(nullable: true),
                    CodigoBarras = table.Column<string>(nullable: true),
                    SobreViajero = table.Column<string>(nullable: true),
                    ClaveIntelisis = table.Column<string>(nullable: true),
                    FiguraFinal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vc_diseno", x => x.ClaveDiseno);
                });

            migrationBuilder.CreateTable(
                name: "vc_estructuras",
                columns: table => new
                {
                    Posicion = table.Column<int>(nullable: false),
                    ClaveDiseno = table.Column<string>(maxLength: 200, nullable: false),
                    Elemento = table.Column<string>(nullable: true),
                    Caracteristicas = table.Column<string>(nullable: true),
                    Comentarios = table.Column<string>(nullable: true),
                    EsImpreso = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vc_estructuras", x => new { x.ClaveDiseno, x.Posicion });
                    table.ForeignKey(
                        name: "FK_vc_estructuras_vc_diseno_ClaveDiseno",
                        column: x => x.ClaveDiseno,
                        principalTable: "vc_diseno",
                        principalColumn: "ClaveDiseno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vc_procesos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Comentarios = table.Column<string>(nullable: true),
                    TamañoDiseño_Alto_Std = table.Column<double>(nullable: true),
                    TamañoDiseño_Alto_Min = table.Column<double>(nullable: true),
                    TamañoDiseño_Alto_Max = table.Column<double>(nullable: true),
                    TamañoDiseño_Alto_Unidad = table.Column<string>(nullable: true),
                    TamañoDiseño_Ancho_Std = table.Column<double>(nullable: true),
                    TamañoDiseño_Ancho_Min = table.Column<double>(nullable: true),
                    TamañoDiseño_Ancho_Max = table.Column<double>(nullable: true),
                    TamañoDiseño_Ancho_Unidad = table.Column<string>(nullable: true),
                    FiguraEmbobinado = table.Column<int>(nullable: false),
                    ImagenFiguraSalida = table.Column<byte[]>(type: "blob", nullable: true),
                    ProcesoId = table.Column<int>(nullable: false),
                    ClaveDiseno = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ProveedorTinta = table.Column<string>(nullable: true),
                    TipoTinta = table.Column<string>(nullable: true),
                    ReferenciaEntonacion = table.Column<string>(nullable: true),
                    TipoImpresion = table.Column<string>(nullable: true),
                    Dureza_Std = table.Column<double>(nullable: true),
                    Dureza_Min = table.Column<double>(nullable: true),
                    Dureza_Max = table.Column<double>(nullable: true),
                    Dureza_Unidad = table.Column<string>(nullable: true),
                    ClaveResina = table.Column<string>(nullable: true),
                    ClaveCatalizador = table.Column<string>(nullable: true),
                    AplicacionAdhesivo_Std = table.Column<double>(nullable: true),
                    AplicacionAdhesivo_Min = table.Column<double>(nullable: true),
                    AplicacionAdhesivo_Max = table.Column<double>(nullable: true),
                    AplicacionAdhesivo_Unidad = table.Column<string>(nullable: true),
                    RelacionAdhesivo_Std = table.Column<double>(nullable: true),
                    RelacionAdhesivo_Min = table.Column<double>(nullable: true),
                    RelacionAdhesivo_Max = table.Column<double>(nullable: true),
                    RelacionAdhesivo_Unidad = table.Column<string>(nullable: true),
                    Curling_Std = table.Column<double>(nullable: true),
                    Curling_Min = table.Column<double>(nullable: true),
                    Curling_Max = table.Column<double>(nullable: true),
                    Curling_Unidad = table.Column<string>(nullable: true),
                    FuerzaLaminacionUno_Std = table.Column<double>(nullable: true),
                    FuerzaLaminacionUno_Min = table.Column<double>(nullable: true),
                    FuerzaLaminacionUno_Max = table.Column<double>(nullable: true),
                    FuerzaLaminacionUno_Unidad = table.Column<string>(nullable: true),
                    FuerzaLaminacionDos_Std = table.Column<double>(nullable: true),
                    FuerzaLaminacionDos_Min = table.Column<double>(nullable: true),
                    FuerzaLaminacionDos_Max = table.Column<double>(nullable: true),
                    FuerzaLaminacionDos_Unidad = table.Column<string>(nullable: true),
                    MedidaCore = table.Column<int>(nullable: true),
                    MarcaCore = table.Column<string>(nullable: true),
                    ControlPrincipal = table.Column<string>(nullable: true),
                    ControlPrincipalTolerancia_Std = table.Column<double>(nullable: true),
                    ControlPrincipalTolerancia_Min = table.Column<double>(nullable: true),
                    ControlPrincipalTolerancia_Max = table.Column<double>(nullable: true),
                    ControlPrincipalTolerancia_Unidad = table.Column<string>(nullable: true),
                    ControlSecundario = table.Column<string>(nullable: true),
                    PistaDoble = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vc_procesos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vc_procesos_vc_diseno_ClaveDiseno",
                        column: x => x.ClaveDiseno,
                        principalTable: "vc_diseno",
                        principalColumn: "ClaveDiseno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vc_procesos_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vc_parametros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MaquinaId = table.Column<int>(nullable: false),
                    FechaCaptura = table.Column<DateTime>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    Velocidad_Std = table.Column<double>(nullable: true),
                    Velocidad_Min = table.Column<double>(nullable: true),
                    Velocidad_Max = table.Column<double>(nullable: true),
                    Velocidad_Unidad = table.Column<string>(nullable: true),
                    TaperTension_Std = table.Column<double>(nullable: true),
                    TaperTension_Min = table.Column<double>(nullable: true),
                    TaperTension_Max = table.Column<double>(nullable: true),
                    TaperTension_Unidad = table.Column<string>(nullable: true),
                    BaseProcesoId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    IsGearless = table.Column<bool>(nullable: true),
                    PresionRodilloPisorCalandra_Std = table.Column<double>(nullable: true),
                    PresionRodilloPisorCalandra_Min = table.Column<double>(nullable: true),
                    PresionRodilloPisorCalandra_Max = table.Column<double>(nullable: true),
                    PresionRodilloPisorCalandra_Unidad = table.Column<string>(nullable: true),
                    PresionRodilloPisorTambor_Std = table.Column<double>(nullable: true),
                    PresionRodilloPisorTambor_Min = table.Column<double>(nullable: true),
                    PresionRodilloPisorTambor_Max = table.Column<double>(nullable: true),
                    PresionRodilloPisorTambor_Unidad = table.Column<string>(nullable: true),
                    PresionRodilloPisorEmbobinador_Std = table.Column<double>(nullable: true),
                    PresionRodilloPisorEmbobinador_Min = table.Column<double>(nullable: true),
                    PresionRodilloPisorEmbobinador_Max = table.Column<double>(nullable: true),
                    PresionRodilloPisorEmbobinador_Unidad = table.Column<string>(nullable: true),
                    PotenciaTratador_Std = table.Column<double>(nullable: true),
                    PotenciaTratador_Min = table.Column<double>(nullable: true),
                    PotenciaTratador_Max = table.Column<double>(nullable: true),
                    PotenciaTratador_Unidad = table.Column<string>(nullable: true),
                    TensionBanda_Puente_Std = table.Column<double>(nullable: true),
                    TensionBanda_Puente_Min = table.Column<double>(nullable: true),
                    TensionBanda_Puente_Max = table.Column<double>(nullable: true),
                    TensionBanda_Puente_Unidad = table.Column<string>(nullable: true),
                    Tension_Embobinador_Std = table.Column<double>(nullable: true),
                    Tension_Embobinador_Min = table.Column<double>(nullable: true),
                    Tension_Embobinador_Max = table.Column<double>(nullable: true),
                    Tension_Embobinador_Unidad = table.Column<string>(nullable: true),
                    TemperaturaPuente_Std = table.Column<string>(nullable: true),
                    TemperaturaPuente_Min = table.Column<string>(nullable: true),
                    TemperaturaPuente_Max = table.Column<string>(nullable: true),
                    TemperaturaPuente_Unidad = table.Column<string>(nullable: true),
                    TemperaturaIntergrupos_Std = table.Column<string>(nullable: true),
                    TemperaturaIntergrupos_Min = table.Column<string>(nullable: true),
                    TemperaturaIntergrupos_Max = table.Column<string>(nullable: true),
                    TemperaturaIntergrupos_Unidad = table.Column<string>(nullable: true),
                    TensionArrastre_Desbobinador_Std = table.Column<double>(nullable: true),
                    TensionArrastre_Desbobinador_Min = table.Column<double>(nullable: true),
                    TensionArrastre_Desbobinador_Max = table.Column<double>(nullable: true),
                    TensionArrastre_Desbobinador_Unidad = table.Column<string>(nullable: true),
                    TensionRodilloRefrigeranteG_Std = table.Column<double>(nullable: true),
                    TensionRodilloRefrigeranteG_Min = table.Column<double>(nullable: true),
                    TensionRodilloRefrigeranteG_Max = table.Column<double>(nullable: true),
                    TensionRodilloRefrigeranteG_Unidad = table.Column<string>(nullable: true),
                    FuerzaAprieteG_Std = table.Column<double>(nullable: true),
                    FuerzaAprieteG_Min = table.Column<double>(nullable: true),
                    FuerzaAprieteG_Max = table.Column<double>(nullable: true),
                    FuerzaAprieteG_Unidad = table.Column<string>(nullable: true),
                    DiametroInicialG = table.Column<int>(nullable: true),
                    DiametroFinalG = table.Column<int>(nullable: true),
                    PresionBalancinEmbobinadorE_Std = table.Column<double>(nullable: true),
                    PresionBalancinEmbobinadorE_Min = table.Column<double>(nullable: true),
                    PresionBalancinEmbobinadorE_Max = table.Column<double>(nullable: true),
                    PresionBalancinEmbobinadorE_Unidad = table.Column<string>(nullable: true),
                    PresionBalancinDesbobinadorE_Std = table.Column<double>(nullable: true),
                    PresionBalancinDesbobinadorE_Min = table.Column<double>(nullable: true),
                    PresionBalancinDesbobinadorE_Max = table.Column<double>(nullable: true),
                    PresionBalancinDesbobinadorE_Unidad = table.Column<string>(nullable: true),
                    OffsetE_Std = table.Column<string>(nullable: true),
                    OffsetE_Min = table.Column<string>(nullable: true),
                    OffsetE_Max = table.Column<string>(nullable: true),
                    OffsetE_Unidad = table.Column<string>(nullable: true),
                    TemperaturaResina_Std = table.Column<double>(nullable: true),
                    TemperaturaResina_Min = table.Column<double>(nullable: true),
                    TemperaturaResina_Max = table.Column<double>(nullable: true),
                    TemperaturaResina_Unidad = table.Column<string>(nullable: true),
                    TemperaturaCatalizador_Std = table.Column<double>(nullable: true),
                    TemperaturaCatalizador_Min = table.Column<double>(nullable: true),
                    TemperaturaCatalizador_Max = table.Column<double>(nullable: true),
                    TemperaturaCatalizador_Unidad = table.Column<string>(nullable: true),
                    TemperaturaRodilloAplicador_Std = table.Column<double>(nullable: true),
                    TemperaturaRodilloAplicador_Min = table.Column<double>(nullable: true),
                    TemperaturaRodilloAplicador_Max = table.Column<double>(nullable: true),
                    TemperaturaRodilloAplicador_Unidad = table.Column<string>(nullable: true),
                    TemperaturaRodilloLaminador_Std = table.Column<double>(nullable: true),
                    TemperaturaRodilloLaminador_Min = table.Column<double>(nullable: true),
                    TemperaturaRodilloLaminador_Max = table.Column<double>(nullable: true),
                    TemperaturaRodilloLaminador_Unidad = table.Column<string>(nullable: true),
                    PresionRodilloMangas_Std = table.Column<double>(nullable: true),
                    PresionRodilloMangas_Min = table.Column<double>(nullable: true),
                    PresionRodilloMangas_Max = table.Column<double>(nullable: true),
                    PresionRodilloMangas_Unidad = table.Column<string>(nullable: true),
                    RodilloLaminadorPresionIzquierda_Std = table.Column<double>(nullable: true),
                    RodilloLaminadorPresionIzquierda_Min = table.Column<double>(nullable: true),
                    RodilloLaminadorPresionIzquierda_Max = table.Column<double>(nullable: true),
                    RodilloLaminadorPresionIzquierda_Unidad = table.Column<string>(nullable: true),
                    RodilloPresorPresionIzquierda_Std = table.Column<double>(nullable: true),
                    RodilloPresorPresionIzquierda_Min = table.Column<double>(nullable: true),
                    RodilloPresorPresionIzquierda_Max = table.Column<double>(nullable: true),
                    RodilloPresorPresionIzquierda_Unidad = table.Column<string>(nullable: true),
                    GalgaRodilloAplicacionIzquierda_Std = table.Column<double>(nullable: true),
                    GalgaRodilloAplicacionIzquierda_Min = table.Column<double>(nullable: true),
                    GalgaRodilloAplicacionIzquierda_Max = table.Column<double>(nullable: true),
                    GalgaRodilloAplicacionIzquierda_Unidad = table.Column<string>(nullable: true),
                    TensionDesbobinadorUno_Std = table.Column<double>(nullable: true),
                    TensionDesbobinadorUno_Min = table.Column<double>(nullable: true),
                    TensionDesbobinadorUno_Max = table.Column<double>(nullable: true),
                    TensionDesbobinadorUno_Unidad = table.Column<string>(nullable: true),
                    TensionDesbobinadorDos_Std = table.Column<double>(nullable: true),
                    TensionDesbobinadorDos_Min = table.Column<double>(nullable: true),
                    TensionDesbobinadorDos_Max = table.Column<double>(nullable: true),
                    TensionDesbobinadorDos_Unidad = table.Column<string>(nullable: true),
                    TensionBobinador_Std = table.Column<double>(nullable: true),
                    TensionBobinador_Min = table.Column<double>(nullable: true),
                    TensionBobinador_Max = table.Column<double>(nullable: true),
                    TensionBobinador_Unidad = table.Column<string>(nullable: true),
                    TensionPuente_Std = table.Column<double>(nullable: true),
                    TensionPuente_Min = table.Column<double>(nullable: true),
                    TensionPuente_Max = table.Column<double>(nullable: true),
                    TensionPuente_Unidad = table.Column<string>(nullable: true),
                    PresionRodilloAplicador_Std = table.Column<double>(nullable: true),
                    PresionRodilloAplicador_Min = table.Column<double>(nullable: true),
                    PresionRodilloAplicador_Max = table.Column<double>(nullable: true),
                    PresionRodilloAplicador_Unidad = table.Column<string>(nullable: true),
                    RodilloLaminadorPresionDerecha_Std = table.Column<double>(nullable: true),
                    RodilloLaminadorPresionDerecha_Min = table.Column<double>(nullable: true),
                    RodilloLaminadorPresionDerecha_Max = table.Column<double>(nullable: true),
                    RodilloLaminadorPresionDerecha_Unidad = table.Column<string>(nullable: true),
                    RodilloPresorPresionDerecha_Std = table.Column<double>(nullable: true),
                    RodilloPresorPresionDerecha_Min = table.Column<double>(nullable: true),
                    RodilloPresorPresionDerecha_Max = table.Column<double>(nullable: true),
                    RodilloPresorPresionDerecha_Unidad = table.Column<string>(nullable: true),
                    GalgaRodilloAplicacionDerecha_Std = table.Column<double>(nullable: true),
                    GalgaRodilloAplicacionDerecha_Min = table.Column<double>(nullable: true),
                    GalgaRodilloAplicacionDerecha_Max = table.Column<double>(nullable: true),
                    GalgaRodilloAplicacionDerecha_Unidad = table.Column<string>(nullable: true),
                    TensionDesbobinador_Std = table.Column<double>(nullable: true),
                    TensionDesbobinador_Min = table.Column<double>(nullable: true),
                    TensionDesbobinador_Max = table.Column<double>(nullable: true),
                    TensionDesbobinador_Unidad = table.Column<string>(nullable: true),
                    TensionEnbobinadorSuperior_Std = table.Column<double>(nullable: true),
                    TensionEnbobinadorSuperior_Min = table.Column<double>(nullable: true),
                    TensionEnbobinadorSuperior_Max = table.Column<double>(nullable: true),
                    TensionEnbobinadorSuperior_Unidad = table.Column<string>(nullable: true),
                    TensionEnbobinadorInferior_Std = table.Column<double>(nullable: true),
                    TensionEnbobinadorInferior_Min = table.Column<double>(nullable: true),
                    TensionEnbobinadorInferior_Max = table.Column<double>(nullable: true),
                    TensionEnbobinadorInferior_Unidad = table.Column<string>(nullable: true),
                    PresionRodilloSuperior_Std = table.Column<double>(nullable: true),
                    PresionRodilloSuperior_Min = table.Column<double>(nullable: true),
                    PresionRodilloSuperior_Max = table.Column<double>(nullable: true),
                    PresionRodilloSuperior_Unidad = table.Column<string>(nullable: true),
                    PresionRodilloInferior_Std = table.Column<double>(nullable: true),
                    PresionRodilloInferior_Min = table.Column<double>(nullable: true),
                    PresionRodilloInferior_Max = table.Column<double>(nullable: true),
                    PresionRodilloInferior_Unidad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vc_parametros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vc_parametros_vc_procesos_BaseProcesoId",
                        column: x => x.BaseProcesoId,
                        principalTable: "vc_procesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vc_parametros_Maquinas_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "Maquinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VC_DecksImpresion",
                columns: table => new
                {
                    ParametrosId = table.Column<int>(nullable: false),
                    unidad = table.Column<int>(nullable: false),
                    Color = table.Column<int>(nullable: false),
                    Pantone = table.Column<string>(nullable: true),
                    Anilox = table.Column<string>(nullable: true),
                    StickyBack = table.Column<string>(nullable: true),
                    L = table.Column<string>(nullable: true),
                    A = table.Column<string>(nullable: true),
                    B = table.Column<string>(nullable: true),
                    Densidad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VC_DecksImpresion", x => new { x.ParametrosId, x.unidad });
                    table.ForeignKey(
                        name: "FK_VC_DecksImpresion_vc_parametros_ParametrosId",
                        column: x => x.ParametrosId,
                        principalTable: "vc_parametros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TORDENTRABAJO_ClaveDiseno",
                table: "TORDENTRABAJO",
                column: "ClaveDiseno");

            migrationBuilder.CreateIndex(
                name: "IX_vc_parametros_MaquinaId",
                table: "vc_parametros",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IndexParametrosProcesoMaquina",
                table: "vc_parametros",
                columns: new[] { "BaseProcesoId", "MaquinaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vc_procesos_ClaveDiseno",
                table: "vc_procesos",
                column: "ClaveDiseno");

            migrationBuilder.CreateIndex(
                name: "IndexProcesoDiseno",
                table: "vc_procesos",
                columns: new[] { "ProcesoId", "ClaveDiseno" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TORDENTRABAJO_vc_diseno_ClaveDiseno",
                table: "TORDENTRABAJO",
                column: "ClaveDiseno",
                principalTable: "vc_diseno",
                principalColumn: "ClaveDiseno",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TORDENTRABAJO_vc_diseno_ClaveDiseno",
                table: "TORDENTRABAJO");

            migrationBuilder.DropTable(
                name: "VC_DecksImpresion");

            migrationBuilder.DropTable(
                name: "vc_estructuras");

            migrationBuilder.DropTable(
                name: "vc_parametros");

            migrationBuilder.DropTable(
                name: "vc_procesos");

            migrationBuilder.DropTable(
                name: "vc_diseno");

            migrationBuilder.DropIndex(
                name: "IX_TORDENTRABAJO_ClaveDiseno",
                table: "TORDENTRABAJO");

            migrationBuilder.DropColumn(
                name: "ClaveDiseno",
                table: "TORDENTRABAJO");
        }
    }
}
