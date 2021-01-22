using ExcelNobleza.Shared.Models.ComplexObjects;
using ExcelNobleza.Shared.Models.Tablas.Produccion;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Bases;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Parametros;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Procesos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExcelNobleza.Shared.Models.Reportes
{
	public class VC_ProcesoReportData
	{
		#region private
		private Tablas.Produccion.OrdenTrabajo OT { get; set; }
		private BaseParametros BaseParametros { get; set; }
		private Tablas.VariablesCriticas.Procesos.ProcesoImpresion ProcImp
		{
			get
			{
				return BaseParametros?.Proceso as Tablas.VariablesCriticas.Procesos.ProcesoImpresion;
			}
		}
		private Tablas.VariablesCriticas.Procesos.ProcesoLaminacion ProcLam
		{
			get
			{
				return BaseParametros?.Proceso as Tablas.VariablesCriticas.Procesos.ProcesoLaminacion;
			}
		}
		private Tablas.VariablesCriticas.Procesos.ProcesoRefinadoEmbobinado ProcRef
		{
			get
			{
				return BaseParametros?.Proceso as Tablas.VariablesCriticas.Procesos.ProcesoRefinadoEmbobinado;
			}
		}

		private ParametrosImpresion parametrosImpresion { get => this.BaseParametros as ParametrosImpresion; }
		private ParametrosLaminacion parametrosLaminacion { get => this.BaseParametros as ParametrosLaminacion; }
		private ParametrosRefinadoEmbobinado parametrosRefinadoEmbobinado { get => this.BaseParametros as ParametrosRefinadoEmbobinado; }
		private object[] HeaderData
		{
			get
			{
				if (ProcImp != null)
				{
					return new object[4] { 1, $"Aprobación de Inicio de Impresion", "CV-FR-02-02", "Edición 3" };
				}
				else if (ProcLam != null)
				{
					return new object[4] { 2, $"Reporte de Proceso de Laminación", "CV-FR-03-01", "Edición 3" };
				}
				else if (ProcRef != null)
				{
					return new object[4] { 3, $"Inspección de Refinado/Emobinado/Corte", "CV-FR-04-01", "Edición 3" };
				}
				else
				{
					return new object[4] { 999, "", "", "" };
				}
			}
		}
		#endregion

		public string Reporte_Nombre { get => $"{HeaderData[1]}"; }
		public string Reporte_Version { get => $"{HeaderData[3]}"; }
		public string Reporte_Clave { get => $"{HeaderData[2]}"; }
		public int TipoReporte { get => (int)HeaderData[0]; }


		public string OT_OT { get => $"{OT.OT}"; }
		public string OT_Cliente { get => $"{OT.CLIENTE}"; }
		public string OT_Producto { get => $"{OT.PRODUCTO}"; }
		public string OT_TipoTrabajo { get => $"{OT.TipoTrabajoString}"; }
		public string OT_ClaveDiseño { get => $"{OT.Diseño?.ClaveDiseño}"; }
		public string OT_Cantidad { get => $"{OT.CANTIDAD:N1} {OT.UNIDAD}"; }
		public string OT_ClaveIntelisis { get => $"{OT.CLAVEINTELISIS}"; }
		public string OT_NumeroSobre { get => $"{OT.Diseño?.SobreViajero}"; }
		public string OT_CodigoBarras { get => $"{OT.Diseño?.CodigoBarras}"; }
		public string OT_Estructura
		{
			get
			{
				var ret = "";
				if (OT.Diseño != null && OT.Diseño?.EstructuraItems?.Count > 0)
				{

					OT.Diseño.EstructuraItems.OrderBy(i => i.Posicion).ToList().ForEach(o =>
					{
						ret += $"{o}\n";
					});
				}
				return ret;
			}
		}


		public string ProcCom_Comentarios { get => $"{BaseParametros?.Proceso?.Comentarios} {BaseParametros?.Comentarios}"; }
		public string ProcCom_NombreProceso { get => $"{BaseParametros?.Proceso?.Proceso?.NombreProceso}"; }
		public string ProcCom_FiguraEmbobinado { get => BaseParametros?.Proceso?.FiguraEmbobinado > 0 ? $"{BaseParametros?.Proceso?.FiguraEmbobinado}" : ""; }
		public string ProcCom_DisAltoStd { get => BaseParametros?.Proceso?.TamañoDiseño?.Alto.Std == 0 ? "" : $"{BaseParametros?.Proceso?.TamañoDiseño?.Alto.Std:N1}"; }
		public string ProcCom_DisAltoMin { get => BaseParametros?.Proceso?.TamañoDiseño?.Alto.Min == 0 ? "" : $"{BaseParametros?.Proceso?.TamañoDiseño?.Alto.Min:N1}"; }
		public string ProcCom_DisAltoMax { get => BaseParametros?.Proceso?.TamañoDiseño?.Alto.Max == 0 ? "" : $"{BaseParametros?.Proceso?.TamañoDiseño?.Alto.Max:N1}"; }
		public string ProcCom_DisAnchoStd { get => BaseParametros?.Proceso?.TamañoDiseño?.Ancho.Std == 0 ? "" : $"{BaseParametros?.Proceso?.TamañoDiseño?.Ancho.Std:N1}"; }
		public string ProcCom_DisAnchoMin { get => BaseParametros?.Proceso?.TamañoDiseño?.Ancho.Min == 0 ? "" : $"{BaseParametros?.Proceso?.TamañoDiseño?.Ancho.Min:N1}"; }
		public string ProcCom_DisAnchoMax { get => BaseParametros?.Proceso?.TamañoDiseño?.Ancho.Max == 0 ? "" : $"{BaseParametros?.Proceso?.TamañoDiseño?.Ancho.Max:N1}"; }


		public string ParamCom_Maquina { get => $"{BaseParametros?.Maquina}"; }
		public string ParamCom_FechaActualizacion { get => $"{BaseParametros?.FechaActualizacion}"; }
		public string ParamCom_FechaCaptura { get => $"{BaseParametros?.FechaCaptura}"; }
		public object[] ParamCom_Velocidad { get => BaseParametros?.Velocidad.GetValues(); }
		public object[] ParamCom_Taper { get => BaseParametros?.TaperTension.GetValues(); }


		#region ProcesoImpresion
		public string ProcImp_ProveedorTinta { get => $"{ProcImp?.ProveedorTinta}"; }
		public bool ProcImp_EsGearless { get => (bool)parametrosImpresion?.IsGearless; }
		public string ProcImp_TipoTinta { get => $"{ProcImp?.TipoTinta}"; }
		public string ProcImp_ReferenciaEntonacion { get => $"{ProcImp?.ReferenciaEntonacion}"; }
		public string ProcImp_TipoImpresion { get => $"{ProcImp?.TipoImpresion}"; }
		public string ProcImp_DurezaStd { get => $"{ProcImp?.Dureza?.Std:N0}"; }
		public string ProcImp_DurezaMin { get => $"{ProcImp?.Dureza?.Min:N0}"; }
		public string ProcImp_DurezaMax { get => $"{ProcImp?.Dureza?.Max:N0}"; }
		public byte[] ProcImp_ImagenFiguraSalida
		{
			get
			{
				if (ProcImp?.ImagenFiguraSalida != null) return ProcImp?.ImagenFiguraSalida;
				return GetFigFromInstructions(ProcImp_Instrucciones);

			}
		}
		public string ProcImp_Rodillo { get => $"{OT.RODILLO * 10:N0}"; }
		public string ProcImp_RepEje { get => $"{OT.REPEJE}"; }
		public string ProcImp_RepDes { get => $"{OT.REPDES}"; }
		public string ProcImp_Instrucciones { get => $"{OT.INSTIMPRESION.ToUpper()}"; }
		public string ProcImp_Material { get => $"{OT?.MATBASE} {OT?.MATBASEAMU:N1}/{OT?.MATBASECALIBRE:N0}"; }

		public object[] ProcImpP_TensionArrastre_Desbobinador { get => parametrosImpresion?.TensionArrastre_Desbobinador.GetValues(); }
		public object[] ProcImpP_TensionEmbobinador { get => parametrosImpresion?.Tension_Embobinador.GetValues(); }
		public object[] ProcImpP_TensionRodilloRefrigeranteG { get => parametrosImpresion?.TensionRodilloRefrigeranteG.GetValues(); }
		public object[] ProcImpP_TensionBanda_Puente { get => parametrosImpresion?.TensionBanda_Puente.GetValues(); }
		public object[] ProcImpP_FuerzaAprieteG { get => parametrosImpresion?.FuerzaAprieteG.GetValues(); }
		public object[] ProcImpP_TemperaturaIntergrupos { get => parametrosImpresion?.TemperaturaIntergrupos.GetValues(); }
		public object[] ProcImpP_TemperaturaPuente { get => parametrosImpresion?.TemperaturaPuente.GetValues(); }
		public string ProcImpP_DiametroinicialG { get => $"{parametrosImpresion?.DiametroInicialG}"; }
		public string ProcImpP_DiametroFinalG { get => $"{parametrosImpresion?.DiametroFinalG}"; }
		public object[] ProcImpP_PresionRodilloPisorCalandra { get => parametrosImpresion?.PresionRodilloPisorCalandra.GetValues(); }
		public object[] ProcImpP_PresionRodilloPisorTambor { get => parametrosImpresion?.PresionRodilloPisorTambor.GetValues(); }
		public object[] ProcImpP_PresionRodilloPisorEmbobinador { get => parametrosImpresion?.PresionRodilloPisorEmbobinador.GetValues(); }
		public object[] ProcImpP_PotenciaTratador { get => parametrosImpresion?.PotenciaTratador.GetValues(); }
		public object[] ProcImpP_PresionBalancinEmbobinadorE { get => parametrosImpresion?.PresionBalancinEmbobinadorE.GetValues(); }
		public object[] ProcImpP_PresionBalancinDesbobinadorE { get => parametrosImpresion?.PresionBalancinDesbobinadorE.GetValues(); }
		public object[] ProcImpP_OffsetE { get => parametrosImpresion?.OffsetE.GetValues(); }

		//public object[] ProcImpP_ { get => parametrosImpresion?  .GetValues(); }

		//public string ProcImpP_ { get => $"{ parametrosImpresion ?.TensionBanda_Embobinador}"; }

		#region UnidadesDeImpresión
		public string[] ProcImp_U1
		{
			get
			{
				var unidad = 1;
				if (!parametrosImpresion?.Decks?.Any(O => O.unidad == unidad) == true)
					return new string[] { "", "", "", "", "", "", "", "" };

				return new string[] {
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Color}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Pantone}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Anilox}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).StickyBack}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).L}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).A}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).B}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Densidad}"
					};


			}
		}

		public string[] ProcImp_U2
		{
			get
			{
				var unidad = 2;
				if (!parametrosImpresion?.Decks?.Any(O => O.unidad == unidad) == true)
					return new string[] { "", "", "", "", "", "", "", "" };
				return new string[] {
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Color}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Pantone}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Anilox}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).StickyBack}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).L}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).A}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).B}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Densidad}"
					};
			}
		}

		public string[] ProcImp_U3
		{
			get
			{
				var unidad = 3;
				if (!parametrosImpresion?.Decks?.Any(O => O.unidad == unidad) == true)
					return new string[] { "", "", "", "", "", "", "", "" };
				return new string[] {
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Color}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Pantone}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Anilox}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).StickyBack}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).L}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).A}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).B}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Densidad}"
					};
			}
		}

		public string[] ProcImp_U4
		{
			get
			{
				var unidad = 4;
				if (!parametrosImpresion?.Decks?.Any(O => O.unidad == unidad) == true)
					return new string[] { "", "", "", "", "", "", "", "" };
				return new string[] {
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Color}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Pantone}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Anilox}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).StickyBack}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).L}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).A}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).B}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Densidad}"
					};
			}
		}

		public string[] ProcImp_U5
		{
			get
			{
				var unidad = 5;
				if (!parametrosImpresion?.Decks?.Any(O => O.unidad == unidad) == true)
					return new string[] { "", "", "", "", "", "", "", "" };
				return new string[] {
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Color}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Pantone}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Anilox}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).StickyBack}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).L}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).A}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).B}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Densidad}"
					};
			}
		}

		public string[] ProcImp_U6
		{
			get
			{
				var unidad = 6;
				if (!parametrosImpresion?.Decks?.Any(O => O.unidad == unidad) == true)
					return new string[] { "", "", "", "", "", "", "", "" };
				return new string[] {
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Color}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Pantone}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Anilox}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).StickyBack}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).L}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).A}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).B}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Densidad}"
					};
			}
		}

		public string[] ProcImp_U7
		{
			get
			{
				var unidad = 7;
				if (!parametrosImpresion?.Decks?.Any(O => O.unidad == unidad) == true)
					return new string[] { "", "", "", "", "", "", "", "" };
				return new string[] {
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Color}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Pantone}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Anilox}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).StickyBack}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).L}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).A}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).B}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Densidad}"
					};
			}
		}

		public string[] ProcImp_U8
		{
			get
			{
				var unidad = 8;
				if (!parametrosImpresion?.Decks?.Any(O => O.unidad == unidad) == true)
					return new string[] { "", "", "", "", "", "", "", "" };
				return new string[] {
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Color}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Pantone}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Anilox}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).StickyBack}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).L}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).A}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).B}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Densidad}"
					};
			}
		}

		public string[] ProcImp_U9
		{
			get
			{
				var unidad = 9;
				if (!parametrosImpresion?.Decks?.Any(O => O.unidad == unidad) == true)
					return new string[] { "", "", "", "", "", "", "", "" };
				return new string[] {
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Color}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Pantone}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Anilox}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).StickyBack}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).L}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).A}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).B}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Densidad}"
					};
			}
		}

		public string[] ProcImp_U10
		{
			get
			{
				var unidad = 10;
				if (!parametrosImpresion?.Decks?.Any(O => O.unidad == unidad) == true)
					return new string[] { "", "", "", "", "", "", "", "" };
				return new string[] {
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Color}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Pantone}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Anilox}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).StickyBack}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).L}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).A}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).B}",
					$"{parametrosImpresion?.Decks?.FirstOrDefault(o => o.unidad == unidad).Densidad}"
					};
			}
		}

		#endregion

		#endregion

		#region ProcesoRefinado
		public string ProcRef_DiametroCore { get => (this.ProcRef?.MedidaCore == Cores.Tres ? "3\"" : "6\""); }
		public string ProcRef_TipoCore { get => $"{this.ProcRef?.MarcaCore}"; }
		public string ProcRef_Instrucciones
		{
			get
			{
				Console.WriteLine(ProcRef?.ProcesoId);
				if (ProcRef?.ProcesoId == 3) return this.OT.INSTREFINADO.ToUpper();
				if (ProcRef?.ProcesoId == 5) return this.OT.INSTCORTE.ToUpper();
				if (ProcRef?.ProcesoId == 6) return this.OT.INSTEMBOBINADO.ToUpper();

				return $"{this.OT.INSTCORTE} {this.OT.INSTEMBOBINADO} {this.OT.INSTREFINADO}";
			}
		}
		public byte[] ProcRef_ImagenFiguraSalida
		{
			get
			{
				if (ProcRef?.ImagenFiguraSalida != null) return ProcRef?.ImagenFiguraSalida;
				return GetFigFromInstructions(ProcRef_Instrucciones);

			}
		}
		#endregion


		private byte[] GetFigFromInstructions(string Instructions)
		{
			var reg = new Regex("(FIGURA )[1-8]");
			var fig = reg.Match(Instructions.ToUpper()).Value;
			fig = fig.Substring(fig.Length - 1, 1);

			var fig_ = ProcImp?.FiguraEmbobinado > 0 ? ProcImp?.FiguraEmbobinado : int.Parse(fig);

			switch (fig_)
			{
				case 1:
					return Properties.Resources.fig1;
				case 2:
					return Properties.Resources.fig2;
				case 3:
					return Properties.Resources.fig3;
				case 4:
					return Properties.Resources.fig4;
				case 5:
					return Properties.Resources.fig5;
				case 6:
					return Properties.Resources.fig6;
				case 7:
					return Properties.Resources.fig7;
				case 8:
					return Properties.Resources.fig8;
				default:
					return null;
			}
		}
		public VC_ProcesoReportData(OrdenTrabajo ordenTrabajo, BaseParametros baseParametros)
		{
			this.OT = ordenTrabajo;
			this.BaseParametros = baseParametros;
		}


		public static List<VC_ProcesoReportData> GetData(Tablas.Produccion.OrdenTrabajo OT)
		{
			var ret = new List<VC_ProcesoReportData>();

			if (OT.Diseño != null && OT.Diseño?.Procesos?.Count > 0)
			{
				OT.Diseño?.Procesos?.ForEach(
					i => i.Parametros.ForEach(o =>
					{
						ret.Add(new VC_ProcesoReportData(OT, o));

						if (o.Proceso?.ProcesoId == 3 || o.Proceso?.ProcesoId == 5 || o.Proceso?.ProcesoId == 6)
						{
							for (int cnt = 0; cnt < 39; cnt++)
							{
								ret.Add(new VC_ProcesoReportData(OT, o));
							}
						}

						Console.WriteLine($"Added Params of: {o.Maquina.NombreMaquina}");
					}));
			}
			else
			{
				ret.Add(new VC_ProcesoReportData(OT, new ParametrosImpresion() { Proceso = new ProcesoImpresion() }));
				ret.Add(new VC_ProcesoReportData(OT, new ParametrosLaminacion() { Proceso = new ProcesoLaminacion() }));
				ret.Add(new VC_ProcesoReportData(OT, new ParametrosRefinadoEmbobinado() { Proceso = new ProcesoRefinadoEmbobinado() }));
			}
			return ret;
		}
	}
}
