using excelnobleza.shared.Auxiliares.VariablesCriticas;
using System;
using System.Collections.Generic;
using System.Text;

namespace excelnobleza.shared.Models.Tablas.VarCriticas
{
	public class ProcesoLaminacion:BaseProceso
	{
		public string ClaveResina { get; set; }
		public string ClaveCatalizador { get; set; }
		public virtual ParameterType<double> AplicacionAdhesivo { get; set; } = new ParameterType<double>("g/cm^2");
		public virtual ParameterType<double> RelacionAdhesivo { get; set; } = new ParameterType<double>("%");
		public virtual ParameterType<double> Curling { get; set; } = new ParameterType<double>("°");
		public virtual ParameterType<double> FuerzaLaminacionUno { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> FuerzaLaminacionDos { get; set; } = new ParameterType<double>();

	}
}
