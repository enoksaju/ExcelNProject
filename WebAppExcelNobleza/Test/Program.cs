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
			//TryUpdate(db);
			PrintValues(db);
			
		}
		static void TryInsert(ApplicationDbContextCore db)
		{
			Diseno dis = new Diseno()
			{
				ClaveDiseño = "U1-47008",
				ClaveIntelisis = "U1PTPL-01102-10",
				CodigoBarras = "7 501055 311712",
				FiguraFinal = 5,
				SobreViajero = "00204-43",
				TamañoDiseño = new ParameterSize("mm", 290, 890, 1, 1),
				TamañoFotocelda = new ParameterSize("mm", 20, 20, 1, 1)
			};



			ProcesoImpresion pimp = new ProcesoImpresion()
			{
				Dureza = new ParameterType<double>("", 36, 26, 46),
				FiguraEmbobinado = 6,
				ProcesoId = 1,
				ProveedorTinta = "Flint Group",
				ReferenciaEntonacion = "Triptico",
				TipoImpresion = "Reverso",
				TipoTinta = "Poligloss",
				TamañoDiseño = new ParameterSize("mm", 290, 890, 1, 1),
				Comentarios = "Primera Prueba",
				ImagenFiguraSalida = System.IO.File.ReadAllBytes("T:\\VariablesCriticas de Control\\Figuras Diseño\\62448\\figuras\\fig6.jpg")
			};

			ProcesoRefinadoEmbobinado procRef = new ProcesoRefinadoEmbobinado()
			{
				ControlPrincipal = "Peso Neto",
				ControlSecundario = "",
				ControlPrincipalTolerancia = new ParameterType<double>("Kg", 50, 49, 51),
				Dureza = new ParameterType<double>("", 36, 26, 46),
				FiguraEmbobinado = 5,
				MarcaCore = "Otro",
				MedidaCore = ExcelNobleza.Shared.Models.Cores.Tres,
				PistaDoble = true,
				ProcesoId = 3,
				TamañoDiseño = new ParameterSize("mm", 290, 890, 1, 1),
				Comentarios = "Primera Prueba"
			};


			ParametrosImpresion parImp = new ParametrosImpresion()
			{
				FechaActualizacion = DateTime.Now,
				FechaCaptura = DateTime.Now,
				IsGearless = true,
				MaquinaId = 1,
				OffsetE = new ParameterType<string>("", "0", "0", "0"),
				PotenciaTratador = new ParameterType<double>("%", 0, 0, 0),
				DiametroFinalG = 600,
				DiametroInicialG = 180,
				Tension_Embobinador = new ParameterType<double>("N", 70, 60, 80),
				TensionRodilloRefrigeranteG = new ParameterType<double>("N", 120, 110, 130),
				PresionRodilloPisorCalandra = new ParameterType<double>("N", 120, 110, 130),
				PresionRodilloPisorEmbobinador = new ParameterType<double>("N", 60, 50, 70),
				PresionRodilloPisorTambor = new ParameterType<double>("N", 40, 35, 45),
				TemperaturaIntergrupos = new ParameterType<string>("°C", "30/40", "20/30", "40/50"),
				TemperaturaPuente = new ParameterType<string>("°C", "50/70", "40/60", "60/80"),
				TensionArrastre_Desbobinador = new ParameterType<double>("N", 60, 50, 70),
				TensionBanda_Puente = new ParameterType<double>("N", 160, 150, 170),
				Velocidad = new ParameterType<double>("m/min", 300, 250, 350)
			};
			ParametrosRefinadoEmbobinado parRef = new ParametrosRefinadoEmbobinado()
			{
				MaquinaId = 2,
				PresionRodilloInferior = new ParameterType<double>("Kg", 0, 0, 0),
				PresionRodilloSuperior = new ParameterType<double>("Kg", 0, 0, 0),
				TensionDesbobinador = new ParameterType<double>("N", 60, 50, 70),
				TensionEnbobinadorInferior = new ParameterType<double>("N", 60, 50, 70),
				TensionEnbobinadorSuperior = new ParameterType<double>("Kg", 0, 0, 0),
				Velocidad = new ParameterType<double>("m/min", 350, 300, 400),
				TaperTension = new ParameterType<double>("%", 20, 10, 30),
				FechaActualizacion = DateTime.Now,
				FechaCaptura = DateTime.Now
			};
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 2,
				Color = ColorType.Negro,
				Pantone = "Solido",
				Anilox = "440",
				StickyBack = "10/20",
				Densidad = "2.08"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 1,
				Color = ColorType.Negro,
				Pantone = "Process",
				Anilox = "900",
				StickyBack = "10/20",
				Densidad = "1.35"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 3,
				Color = ColorType.Pantone,
				Pantone = "704",
				Anilox = "550",
				StickyBack = "",
				L = "35.41",
				A = "50.07",
				B = "30.45"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 4,
				Color = ColorType.Cyan,
				Pantone = "Process",
				Anilox = "1100",
				StickyBack = "10/20",
				Densidad = "1.24"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 5,
				Color = ColorType.Pantone,
				Pantone = "485",
				Anilox = "440",
				StickyBack = "",
				L = "49.02",
				A = "64.92",
				B = "54.49"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 6,
				Color = ColorType.Magenta,
				Pantone = "Fondo",
				Anilox = "1100",
				StickyBack = "10/20",
				Densidad = "1.75"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 7,
				Color = ColorType.Magenta,
				Pantone = "Process",
				Anilox = "1100",
				StickyBack = "10/20",
				Densidad = "1.71"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 9,
				Color = ColorType.Amarillo,
				Pantone = "Fondo",
				Anilox = "1100",
				StickyBack = "10/20",
				Densidad = "1.08"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 8,
				Color = ColorType.Amarillo,
				Pantone = "Process",
				Anilox = "1100",
				StickyBack = "10/20",
				Densidad = "1.19"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 10,
				Color = ColorType.Blanco,
				Pantone = "Cama",
				Anilox = "360",
				StickyBack = "-",
				Densidad = "Visual"
			});


			dis.EstructuraItems.Add(new EstructuraItem()
			{
				Posicion = 1,
				Elemento = "Pet Transparente 115.9/12",
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
				Caracteristicas = "Flexiprint",
			});
			dis.EstructuraItems.Add(new EstructuraItem()
			{
				Posicion = 4,
				Elemento = "Adhesivo SF5480/CA5500",
				Caracteristicas = "Globocoim",
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
				Elemento = "Pebd Transparente L-1100 115.7/450",
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
			Diseno dis = db.VC_Diseño.FirstOrDefault(i => i.ClaveDiseño == "U1-47008");

			ProcesoImpresion pimp = db.VC_BaseProcesos
				.OfType<ProcesoImpresion>()
				.FirstOrDefault(i => i.ProcesoId == 1 && i.ClaveDiseño == dis.ClaveDiseño);

			ProcesoRefinadoEmbobinado procRef =
				db.VC_BaseProcesos
				.OfType<ProcesoRefinadoEmbobinado>()
				.FirstOrDefault(i => i.ProcesoId == 3 && i.ClaveDiseño == dis.ClaveDiseño);

			ParametrosImpresion parImp = new ParametrosImpresion()
			{
				FechaActualizacion = DateTime.Now,
				FechaCaptura = DateTime.Now,
				IsGearless = false,
				MaquinaId = 14,
				OffsetE = new ParameterType<string>("", "0", "0", "0"),
				PotenciaTratador = new ParameterType<double>("%", 0, 0, 0),
				PresionBalancinDesbobinadorE = new ParameterType<double>("Kg", 0, 0, 0),
				PresionBalancinEmbobinadorE = new ParameterType<double>("Kg", 0, 0, 0),
				PresionRodilloPisorCalandra = new ParameterType<double>("Kg", 0, 0, 0),
				PresionRodilloPisorEmbobinador = new ParameterType<double>("KG", 3, 2.5, 3.5),
				PresionRodilloPisorTambor = new ParameterType<double>("Kg", 4, 3.5, 4.5),
				TemperaturaIntergrupos = new ParameterType<string>("°C", "30/40", "20/30", "40/50"),
				TemperaturaPuente = new ParameterType<string>("°C", "50/70", "40/60", "60/80"),
				TensionArrastre_Desbobinador = new ParameterType<double>("Bar", 1, 0.5, 1.5),
				TensionBanda_Puente = new ParameterType<double>("Bar", 0, 0, 0),
				Velocidad = new ParameterType<double>("m/min", 250, 200, 300)
			};
			ParametrosRefinadoEmbobinado parRef = new ParametrosRefinadoEmbobinado()
			{
				MaquinaId = 7,
				PresionRodilloInferior = new ParameterType<double>("Kg", 0, 0, 0),
				PresionRodilloSuperior = new ParameterType<double>("Kg", 0, 0, 0),
				TensionDesbobinador = new ParameterType<double>("N", 60, 50, 70),
				TensionEnbobinadorInferior = new ParameterType<double>("N", 60, 50, 70),
				TensionEnbobinadorSuperior = new ParameterType<double>("Kg", 0, 0, 0),
				Velocidad = new ParameterType<double>("m/min", 350, 300, 400),
				TaperTension = new ParameterType<double>("%", 20, 10, 30),
				FechaActualizacion = DateTime.Now,
				FechaCaptura = DateTime.Now
			};
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 1,
				Color = ColorType.Negro,
				Pantone = "Solido",
				Anilox = "440",
				StickyBack = "10/20",
				Densidad = "2.08"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 2,
				Color = ColorType.Negro,
				Pantone = "Process",
				Anilox = "900",
				StickyBack = "10/20",
				Densidad = "1.35"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 3,
				Color = ColorType.Pantone,
				Pantone = "704",
				Anilox = "550",
				StickyBack = "",
				L = "35.41",
				A = "50.07",
				B = "30.45"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 5,
				Color = ColorType.Pantone,
				Pantone = "485",
				Anilox = "440",
				StickyBack = "",
				L = "49.02",
				A = "64.92",
				B = "54.49"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 6,
				Color = ColorType.Magenta,
				Pantone = "Fondo",
				Anilox = "1100",
				StickyBack = "10/20",
				Densidad = "1.75"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 7,
				Color = ColorType.Magenta,
				Pantone = "Process",
				Anilox = "1100",
				StickyBack = "10/20",
				Densidad = "1.71"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 8,
				Color = ColorType.Amarillo,
				Pantone = "Fondo",
				Anilox = "1100",
				StickyBack = "10/20",
				Densidad = "1.08"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 9,
				Color = ColorType.Amarillo,
				Pantone = "Process",
				Anilox = "1100",
				StickyBack = "10/20",
				Densidad = "1.19"
			});
			parImp.Decks.Add(new DeckImpresion()
			{
				unidad = 10,
				Color = ColorType.Blanco,
				Pantone = "Cama",
				Anilox = "360",
				StickyBack = "-",
				Densidad = "Visual"
			});

			pimp.Parametros.Add(parImp);
			procRef.Parametros.Add(parRef);

			db.SaveChanges();
		}
		static void PrintValues(ApplicationDbContextCore db)
		{
			var Ot = db.OrdenesTrabajo.FirstOrDefault(o => o.OT.Equals("63618"));
			Ot.ClaveDiseño = "U1-47008";
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
