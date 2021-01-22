using ExcelNobleza.Shared.Models.ComplexObjects;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Parametros
{
	public class ParametrosImpresion : BaseParametros
	{
		public bool IsGearless { get; set; }
		public virtual ParameterType<double> PresionRodilloPisorCalandra { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> PresionRodilloPisorTambor { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> PresionRodilloPisorEmbobinador { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> PotenciaTratador { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> TensionBanda_Puente { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> Tension_Embobinador { get; set; } = new ParameterType<double>();
		public virtual ParameterType<string> TemperaturaPuente { get; set; } = new ParameterType<string>();
		public virtual ParameterType<string> TemperaturaIntergrupos { get; set; } = new ParameterType<string>();
		public virtual ParameterType<double> TensionArrastre_Desbobinador { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> TensionRodilloRefrigeranteG { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> FuerzaAprieteG { get; set; } = new ParameterType<double>();
		public int DiametroInicialG { get; set; }
		public int DiametroFinalG { get; set; }
		public virtual ParameterType<double> PresionBalancinEmbobinadorE { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> PresionBalancinDesbobinadorE { get; set; } = new ParameterType<double>();
		public virtual ParameterType<string> OffsetE { get; set; } = new ParameterType<string>();
		public virtual List<DeckImpresion> Decks { get; set; } = new List<DeckImpresion>();
	}
}
