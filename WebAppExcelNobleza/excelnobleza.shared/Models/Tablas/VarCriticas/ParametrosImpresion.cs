using excelnobleza.shared.Auxiliares.VariablesCriticas;
using System;
using System.Collections.Generic;
using System.Text;

namespace excelnobleza.shared.Models.Tablas.VarCriticas
{
	public class ParametrosImpresion : BaseParametros
	{
		public bool IsGearless { get; set; }
		public virtual ParameterType<double> PresionRodilloPisorCalandra { get; set; }
		public virtual ParameterType<double> PresionRodilloPisorTambor { get; set; }
		public virtual ParameterType<double> PresionRodilloPisorEmbobinador { get; set; }
		public virtual ParameterType<double> PotenciaTratador { get; set; }
		public virtual ParameterType<double> TensionBanda_Puente { get; set; }
		public virtual ParameterType<string> TemperaturaPuente { get; set; }
		public virtual ParameterType<string> TemperaturaIntergrupos { get; set; }
		public virtual ParameterType<double> TensionArrastre_Desbobinador { get; set; }
		public virtual ParameterType<double> TensionRodilloRefrigeranteG { get; set; }
		public virtual ParameterType<double> FuerzaAprieteG { get; set; }
		public virtual ParameterType<double> IndiceReduccionG { get; set; }
		public int DiametroInicialG { get; set; }
		public int DiametroFinalG { get; set; }
		public virtual ParameterType<double> PresionBalancinEmbobinadorE { get; set; }
		public virtual ParameterType<double> PresionBalancinDesbobinadorE { get; set; }
		public virtual ParameterType<string> OffsetE { get; set; }
	}
}
