using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas.VariablesCriticas;
using libProduccionDataBase.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace PruebasConsola
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var db = new DataBaseContexto())
			{
				//AddNew("00001", db);
				EditItem("00000", db);
				traySave(db);
			}

			Console.ReadLine();
		}

		static void traySave(DataBaseContexto db)
		{
			try
			{
				db.SaveChanges();

				Console.WriteLine("Save Ok...");
			}
			catch (DbEntityValidationException ex)
			{
				Console.WriteLine(ex);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		static void EditItem(string Clave, DataBaseContexto db)
		{

			var OT = db.VariablesCriticas.FirstOrDefault(c => c.ClaveDiseño == Clave);

			if (OT != null)
			{
				OT.Procesos.Add(new DatosLaminacion()
				{
					Alto = new VCNum("cm", 110, 105, 115),
					Ancho = new VCNum("cm", 110, 105, 115),
					Comentarios = "Laminación",
					DesbobinadorDosElemento = "Bopp Transparente Impreso",
					DesbobinadorUnoElemento = "PE Transparente",
					GomaAnchoTotal = 1020,
					GomaAnchoUtil = 1010,
					GomaMedida = 1030,
					FiguraSalida = 4,
					GomaComentarios = "",
					ParametroAdhesivoAplicacion = new VCNum("g/cm2", 2.2, 2.0, 2.4),
					ParametroAdhesivoCatalizadorRelacion = new VCNum("g/m2", 72, 72.5, 71.5),
					ParametroGalgaDerecha = new VCNum("", 0, 0, 0),
					ParametroGalgaIzquierda = new VCNum("", 0, 0, 0),
					ParametroPotenciaTratador = new VCNum("%", 48, 50, 52),
					ParametroPresionRodilloAplicador = new VCNum("N", 35, 30, 40),
					ParametroPresionRodilloLaminadorDerecho = new VCNum("N", 35, 30, 40),
					ParametroPresionRodilloLaminadorIzquierdo = new VCNum("N", 35, 30, 40),
					ParametroPresionRodilloMangas = new VCNum("N", 35, 30, 40),
					ParametroPresionRodilloPresorDerecho = new VCNum("N", 35, 30, 40),
					ParametroPresionRodilloPresorIzquierdo = new VCNum("N", 35, 30, 40),
					ParametroTemperaturaCatalizador = new VCNum("°C", 35, 30, 40),
					ParametroTemperaturaResina = new VCNum("°C", 35, 30, 40),
					ParametroTemperaturaRodilloAplicador = new VCNum("°C", 35, 30, 40),
					ParametroTemperaturaRodilloLaminador = new VCNum("°C", 35, 30, 40),
					ParametroTensionBobinador = new VCNum("N", 100, 95, 105),
					ParametroTensionDecreciente = new VCNum("%", 50, 48, 52),
					ParametroTensionDesbobinadorDos = new VCNum("N", 100, 95, 105),
					ParametroTensionDesbobinadorUno = new VCNum("N", 100, 95, 105),
					ParametroTensionPuente = new VCNum("N", 100, 95, 105),
					ParametroVelocidad = new VCNum("m/min", 180, 160, 200),
					AdhesivoCatalizadorClave = "CA-5500",
					AdhesivoResinaClave = "SF-5480",
					MaquinaId = 17,
					TipoProceso = 2,
					Curling = new VCNum("°", 5, 0, 10),


				});
			}
		}

		static void AddNew(string Clave, DataBaseContexto db)
		{
			var vc = new libProduccionDataBase.Tablas.VariablesCriticas.VariablesCriticasRoot();

			vc.ClaveDiseño = Clave;
			vc.CodigoBarras = "";
			vc.Fotocelda.Estandar = "11x11";
			vc.Fotocelda.Maximo = "13x13";
			vc.Fotocelda.Minimo = "9x9";
			vc.Fotocelda.Unidad = "mm";

			vc.NumeroSobre = "00001";
			vc.RutaImagenFigura = "\\\\192.168.1.253\\Temp\\VariablesCriticas de Control\\Figuras Diseño\\00000";

			vc.EstructuraItems.Add(new EstructuraItems() { Elemento = "PEDB Transparente", Descripcion = "", Ancho = "62.5", Calibre = "200", EsSustrato = true, SeImprime = true, Posicion = 0, UnidadCalibre = EstructuraItems.Unidades_Calibre.CI });

			vc.EstructuraItems.Add(new EstructuraItems() { Elemento = "Tratado Corona", Descripcion = ">38", Posicion = 1, });

			vc.EstructuraItems.Add(new EstructuraItems() { Elemento = "Tinta", Descripcion = "Polygloss", Posicion = 2, });

			var DI = new DatosImpresion()
			{
				Alto = new VCNum("cm", 120, 119, 121),
				Ancho = new VCNum("cm", 120, 119, 121),
				Comentarios = "",
				FiguraSalida = 6,
				MaquinaId = 5,
				ParametroGearlessDiametroFinal = 1000,
				ParametroGearlessDiametroInicial = 200,
				ParametroGearlessFuerzaApriete = new VCNum("N", 200, 195, 205),
				ParametroGearlessTensionRodilloRefrigerante = new VCNum("N", 60, 55, 65),
				ParametroPotenciaTratador = new VCNum("%", 60, 65, 70),
				ParametroPresionRodilloPisorCalandra = new VCNum("N", 3, 2.5, 3.5),
				ParametroPresionRodilloPisorEmbobinador = new VCNum("N", 3, 2.5, 3.5),
				ParametroPresionRodilloTamborCentral = new VCNum("N", 3, 2.5, 3.5),
				ParametroTemperaturaEntrecolores = new VCStr("°C", "30/50", "20/40", "40/60"),
				ParametroTemperaturaPuente = new VCStr("°C", "30/50", "20/40", "40/60"),
				ParametroTensionArrastreODesbobinador = new VCNum("N", 80, 75, 85),
				ParametroTensionBanda = new VCNum("N", 110, 100, 120),
				ParametroTensionDecreciente = new VCNum("%", 50, 48, 52),
				ParametroTensionEmbobinador = new VCNum("N", 50, 40, 60),
				ParametroVelocidad = new VCNum("m/min", 220, 200, 240),
				TipoImpresora = DatosImpresion.TiposImpresora.gearless,
				TipoTinta = "Flexiprint",
				TipoProceso = 1,
			};

			vc.Procesos.Add(DI);

			DI.Decks.Add(new DeckImpresion() { Color = "Negro", Descripcion = "Process", Anilox = "1100/2.4", Densidad = 1.6, Stickyback = "15", Unidad = 1 });
			DI.Decks.Add(new DeckImpresion() { Color = "Blanco", Descripcion = "Cama", Anilox = "360", Densidad = 1, Stickyback = "15", Unidad = 10 });

			db.VariablesCriticas.Add(vc);
		}
	}
}
