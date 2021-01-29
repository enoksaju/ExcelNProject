using excelnobleza.shared;
using ExcelNobleza.Shared.Models;
using ExcelNobleza.Shared.Models.ComplexObjects;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Parametros;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Procesos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			var contextOptions = new DbContextOptionsBuilder<ApplicationDbContextCore>()
				.UseLazyLoadingProxies(true)
				.Options;

			using var db = new ApplicationDbContextCore(contextOptions);

			//TryInsert(db);
			TryUpdate(db);
			//PrintValues(db);

		}
		static void TryInsert(ApplicationDbContextCore db)
		{
			Diseno dis = new Diseno()
			{
				ClaveDiseño = "SC-51383",
				ClaveIntelisis = "SCPTPL-00958-71",
				CodigoBarras = "4 122018 2275",
				FiguraFinal = 2,
				SobreViajero = "00958-71",
				TamañoDiseño = new ParameterSize("mm", 667.7, 460, 1, 2),
				TamañoFotocelda = new ParameterSize("mm", 19, 6, 1, 1)
			};

			ProcesoImpresion pimp = new ProcesoImpresion()
			{
				Dureza = new ParameterType<double>("", 36, 26, 46),
				FiguraEmbobinado = 2,
				ProcesoId = 1,
				ProveedorTinta = "Flint",
				ReferenciaEntonacion = "Triptico",
				TipoImpresion = "Reverso",
				TipoTinta = "FlexoLam",
				TamañoDiseño = new ParameterSize("mm", 667.7, 460, 1, 2),
				Comentarios = ""
			};

			ProcesoRefinadoEmbobinado procRef = new ProcesoRefinadoEmbobinado()
			{
				ControlPrincipal = "Peso Neto",
				ControlSecundario = "",
				ControlPrincipalTolerancia = new ParameterType<double>("Kg", 35.5, 35, 36),
				Dureza = new ParameterType<double>("", 36, 26, 46),
				FiguraEmbobinado = 2,
				MarcaCore = "Otro",
				MedidaCore = ExcelNobleza.Shared.Models.Cores.Tres,
				PistaDoble = false,
				ProcesoId = 3,
				TamañoDiseño = new ParameterSize("cm", 66.7, 46, 0.2, 0.2),
				Comentarios = ""
			};

			ProcesoLaminacion procLam = new ProcesoLaminacion()
			{
				AplicacionAdhesivo = new ParameterType<double>("g", 2.25, 2.1, 2.4),
				ClaveCatalizador = "CA-5500",
				ClaveResina = "SF-5480",
				FiguraEmbobinado = 1,
				RelacionAdhesivo = new ParameterType<double>("%", 72, 71.5, 72.5),
				TamañoDiseño = new ParameterSize("mm", 667.7, 460, 2, 2),
				ElementoUno = "Pet Transparente Impreso",
				ElementoDos = "PEBD L-2100",
				ElementoTrilaminacion = ""
			};

			ParametrosImpresion parImp = new ParametrosImpresion()
			{
				FechaActualizacion = DateTime.Now,
				FechaCaptura = DateTime.Now,
				IsGearless = true,
				MaquinaId = 1,

				Velocidad = new ParameterType<double>("m/min", 200, 190, 210),
				TensionArrastre_Desbobinador = new ParameterType<double>("N", 100, 95, 105),
				Tension_Embobinador = new ParameterType<double>("N", 60, 55, 65),
				TensionRodilloRefrigeranteG = new ParameterType<double>("N", 110, 100, 120),
				TensionBanda_Puente = new ParameterType<double>("N", 110, 100, 120),
				FuerzaAprieteG = new ParameterType<double>("N", 2, 1.5, 2.5),
				TemperaturaIntergrupos = new ParameterType<string>("°C", "35/50", "25/40", "45/60"),
				TemperaturaPuente = new ParameterType<string>("°C", "45/80", "35/70", "55/90"),
				TaperTension = new ParameterType<double>("%", 40, 38, 48),
				DiametroFinalG = 500,
				DiametroInicialG = 250,
				PresionRodilloPisorCalandra = new ParameterType<double>("", 3, 2.5, 3.5),
				PresionRodilloPisorTambor = new ParameterType<double>("", 3, 2.5, 3.5),
				PresionRodilloPisorEmbobinador = new ParameterType<double>(""),
				PotenciaTratador = new ParameterType<double>("%", 0, 0, 0)
			};


			ParametrosRefinadoEmbobinado parRef = new ParametrosRefinadoEmbobinado()
			{
				MaquinaId = 2,
				FechaActualizacion = DateTime.Now,
				FechaCaptura = DateTime.Now,

				TensionDesbobinador = new ParameterType<double>("%", 8, 6, 10),
				Velocidad = new ParameterType<double>("m/min", 100, 90, 110),
				TensionEnbobinadorInferior = new ParameterType<double>("%", 6.8, 5, 8),
				PresionRodilloInferior = new ParameterType<double>("", 1.5, 1, 3),
				TaperTension = new ParameterType<double>("%", 7, 5, 9)
			};

			ParametrosLaminacion parLam = new ParametrosLaminacion()
			{
				MaquinaId = 3,
				FechaActualizacion = DateTime.Now,
				FechaCaptura = DateTime.Now,

				MangaAncho = 690,
				MangaUtilAdhesivo = 670,
				MangaTotalLaminado = 680,
				TemperaturaResina = new ParameterType<double>("°C", 33, 28, 38),
				TemperaturaCatalizador = new ParameterType<double>("°C", 34, 29, 39),
				TemperaturaRodilloAplicador = new ParameterType<double>("°C", 44, 39, 49),
				TemperaturaRodilloLaminador = new ParameterType<double>("°C", 42, 37, 47),
				PresionRodilloMangas = new ParameterType<double>("Bar", 5, 4.5, 5.5),
				RodilloLaminadorPresionIzquierda = new ParameterType<double>("", 3, 2.5, 3.5),
				RodilloPresorPresionIzquierda = new ParameterType<double>("", 0.1, 0.1, 0.6),
				GalgaRodilloAplicacionIzquierda = new ParameterType<double>("", 0, 0, 0),

				Velocidad = new ParameterType<double>("m/min", 130, 120, 140),
				PotenciaTratador = new ParameterType<double>("%", 0, 0, 0),
				TensionDesbobinadorUno = new ParameterType<double>("", 30, 28, 32),
				TensionDesbobinadorDos = new ParameterType<double>("", 30, 28, 32),
				TensionBobinador = new ParameterType<double>("", 50, 48, 52),
				TaperTension = new ParameterType<double>("%", 50, 48, 52),
				TensionPuente = new ParameterType<double>("", 25, 23, 27),
				PresionRodilloAplicador = new ParameterType<double>("", 3, 2.5, 3.5),
				RodilloLaminadorPresionDerecha = new ParameterType<double>("", 3, 2.5, 3.5),
				RodilloPresorPresionDerecha = new ParameterType<double>("", 0, 0, 0),
				GalgaRodilloAplicacionDerecha = new ParameterType<double>("", 0, 0, 0)
			};

			parImp.Decks.AddRange(new DeckImpresion[]{
				new DeckImpresion()
				{
					unidad = 1,
					Color = ColorType.Negro,
					Pantone = "Solido",
					Anilox = "550/4.21",
					StickyBack = "15/20",
					Densidad = "2.18"
				},
				new DeckImpresion()
				{
					unidad=2,
					Color= ColorType.Negro,
					Pantone= "Process",
					Anilox="900/2.65",
					StickyBack= "19/20",
					Densidad= "1.47"
				},
				new DeckImpresion()
				{
					unidad=3,
					Color= ColorType.Pantone,
					Pantone= "293",
					Anilox="400/5.2",
					StickyBack= "10/20",
					L="27.44",
					A="5.12",
					B="-57.73"
				},
				new DeckImpresion()
				{
					unidad= 4,
					Color= ColorType.Cyan,
					Pantone= "Process",
					Anilox= "900/2.18",
					StickyBack= "900/2.18",
					Densidad= "1.12"
				},
				new DeckImpresion()
				{
					unidad= 5,
					Color= ColorType.Pantone,
					Anilox= "400/5.35",
					StickyBack= "15/20",
					L="39.43", A="-15.5",B="-55.72"
				},
				new DeckImpresion()
				{
					unidad= 6,
					Color= ColorType.Magenta,
					Pantone="Process",
					Anilox= "900/2.62",
					StickyBack= "19/20",
					Densidad= "1.14"
				},
				new DeckImpresion()
				{
					unidad=7,
					Color= ColorType.Pantone,
					Pantone= "485",
					Anilox= "440/5.15",
					StickyBack= "15/20",
					L="50.16",A="69.90",B="56.91"
				},
				new DeckImpresion()
				{
					unidad=8,
					Color= ColorType.Pantone,
					Pantone="1225",
					Anilox="550/4.3",
					StickyBack= "10/20",
					L="78.7", A="10.68",B="84.16"
				},
				new DeckImpresion()
				{
					unidad=9,
					Color= ColorType.Amarillo,
					Pantone= "Process",
					Anilox= "900/2.42",
					StickyBack= "19/20",
					Densidad= "1.05"
				},
				new DeckImpresion()
				{
					unidad=10,
					Color= ColorType.Blanco,
					Pantone= "Cama",
					Anilox= "360/6.24",
					StickyBack = "15/20",
					Densidad= "Visual"
				}
			});


			dis.EstructuraItems.Add(new EstructuraItem()
			{
				Posicion = 1,
				Elemento = "Pet Transparente 69.7/12",
				EsImpreso = true,
			});
			dis.EstructuraItems.Add(new EstructuraItem()
			{
				Posicion = 2,
				Elemento = "Tratado Quimico",
				Caracteristicas = ">= 42 Dinas",
			});
			dis.EstructuraItems.Add(new EstructuraItem()
			{
				Posicion = 3,
				Elemento = "Tinta",
				Caracteristicas = "Flexolam",
			});
			dis.EstructuraItems.Add(new EstructuraItem()
			{
				Posicion = 4,
				Elemento = "Adhesivo SF5480/CA5500",
				Caracteristicas = "Novacote",
			});
			dis.EstructuraItems.Add(new EstructuraItem()
			{
				Posicion = 5,
				Elemento = "Tratado Corona",
				Caracteristicas = ">= 38 Dinas ",
			});
			dis.EstructuraItems.Add(new EstructuraItem()
			{
				Posicion = 6,
				Elemento = "Pebd L-2100 69/300",
				Caracteristicas = "Excel"
			});


			pimp.Parametros.Add(parImp);
			procRef.Parametros.Add(parRef);

			dis.Procesos.Add(pimp);
			dis.Procesos.Add(procRef);

			db.VC_Diseño.Add(dis);

			db.SaveChanges();
		}

		static void TryUpdate(ApplicationDbContextCore db)
		{
			Diseno dis = db.VC_Diseño.FirstOrDefault(i => i.ClaveDiseño == "SC-51383");
			
			ProcesoLaminacion procLam = new ProcesoLaminacion()
			{
				AplicacionAdhesivo = new ParameterType<double>("g", 2.25, 2.1, 2.4),
				ClaveCatalizador = "CA-5500",
				ClaveResina = "SF-5480",
				FiguraEmbobinado = 1,
				RelacionAdhesivo = new ParameterType<double>("%", 72, 71.5, 72.5),
				TamañoDiseño = new ParameterSize("mm", 667.7, 460, 2, 2),
				ElementoUno = "Pet Transparente Impreso",
				ElementoDos = "PEBD L-2100",
				ElementoTrilaminacion = ""
			};
			ParametrosLaminacion parLam = new ParametrosLaminacion()
			{
				MaquinaId = 3,
				FechaActualizacion = DateTime.Now,
				FechaCaptura = DateTime.Now,

				MangaAncho = 690,
				MangaUtilAdhesivo = 670,
				MangaTotalLaminado = 680,
				TemperaturaResina = new ParameterType<double>("°C", 33, 28, 38),
				TemperaturaCatalizador = new ParameterType<double>("°C", 34, 29, 39),
				TemperaturaRodilloAplicador = new ParameterType<double>("°C", 44, 39, 49),
				TemperaturaRodilloLaminador = new ParameterType<double>("°C", 42, 37, 47),
				PresionRodilloMangas = new ParameterType<double>("Bar", 5, 4.5, 5.5),
				RodilloLaminadorPresionIzquierda = new ParameterType<double>("", 3, 2.5, 3.5),
				RodilloPresorPresionIzquierda = new ParameterType<double>("", 0.1, 0.1, 0.6),
				GalgaRodilloAplicacionIzquierda = new ParameterType<double>("", 0, 0, 0),

				Velocidad = new ParameterType<double>("m/min", 130, 120, 140),
				PotenciaTratador = new ParameterType<double>("%", 0, 0, 0),
				TensionDesbobinadorUno = new ParameterType<double>("", 30, 28, 32),
				TensionDesbobinadorDos = new ParameterType<double>("", 30, 28, 32),
				TensionBobinador = new ParameterType<double>("", 50, 48, 52),
				TaperTension = new ParameterType<double>("%", 50, 48, 52),
				TensionPuente = new ParameterType<double>("", 25, 23, 27),
				PresionRodilloAplicador = new ParameterType<double>("", 3, 2.5, 3.5),
				RodilloLaminadorPresionDerecha = new ParameterType<double>("", 3, 2.5, 3.5),
				RodilloPresorPresionDerecha = new ParameterType<double>("", 0, 0, 0),
				GalgaRodilloAplicacionDerecha = new ParameterType<double>("", 0, 0, 0)
			};

			procLam.Parametros.Add(parLam);
			dis.Procesos.Add(procLam);
			db.SaveChanges();
		}
		static void PrintValues(ApplicationDbContextCore db)
		{
			var Ot = db.OrdenesTrabajo.FirstOrDefault(o => o.OT.Equals("63486"));
			Ot.ClaveDiseño = "SC-51383";
			db.SaveChanges();

			Console.WriteLine($"      OT: {Ot.OT}");
			Console.WriteLine($" Cliente: {Ot.CLIENTE}");
			Console.WriteLine($"Producto: {Ot.PRODUCTO}");
			Console.WriteLine($"{new string('*', 80)}\n");
			if (Ot.Diseño != null)
			{
				Console.WriteLine($"\t          Diseño: {Ot.Diseño.ClaveDiseño}");
				Console.WriteLine($"\t  ClaveIntelisis: {Ot.Diseño.ClaveIntelisis}");
				Console.WriteLine($"\tCódigo de Barras: {Ot.Diseño.CodigoBarras}");
				Console.WriteLine($"{new string('*', 80)}\n");

				if (Ot.Diseño.Procesos.Count > 0)
				{

					foreach (var pi in Ot.Diseño.Procesos.OfType<ProcesoImpresion>())
					{
						Console.WriteLine($"\t         Proceso: {pi.Proceso.NombreProceso}");
						Console.WriteLine($"\t  Tipo Impresión: {pi.TipoImpresion}");
						Console.WriteLine($"\t     Prov. Tinta: {pi.ProveedorTinta}");
						Console.WriteLine($"\t      Tipo Tinta: {pi.TipoTinta}");
						Console.WriteLine($"\t           Tonos: {pi.ReferenciaEntonacion}");
						Console.WriteLine($"\t          Figura: {pi.FiguraEmbobinado}");
						Console.WriteLine($"\t     Comentarios: {pi.Comentarios}");

						if (pi.Parametros.Count > 0)
						{
							foreach (var parI in pi.Parametros.OfType<ParametrosImpresion>())
							{
								PrintParamTitle(parI.Maquina.NombreMaquina);
								PrintParam(parI.Velocidad, "Velocidad");
								PrintParam(parI.PresionRodilloPisorTambor, "Pre. Pis. Tambor");
							}
						}
					}
				}

			}
		}



		public static void PrintParamTitle(string Maquina, int tabs = 2)
		{
			var tbs = "";

			for (int i = 1; i < tabs; i++)
			{
				tbs += "\t";
			}

			var lg = (int)((50 - Maquina.Length) / 2);
			Console.WriteLine($"\n{tbs}{new string('_', lg)}{Maquina}{new string('_', lg)}");
			Console.WriteLine($"{tbs}{"Parametro    ",17} {"      Min",-12} {"      Std",-12} {"      Max",-12}");

		}
		public static void PrintParam<T>(ParameterType<T> param, string Name, int tabs = 2)
		{
			var tbs = "";

			for (int i = 1; i < tabs; i++)
			{
				tbs += "\t";
			}
			Console.WriteLine($"{tbs}{Name,16}: {param.Min,6} {param.Unidad,-5} {param.Std,6} {param.Unidad,-5} {param.Max,6} {param.Unidad,-5}");
		}
	}
}
