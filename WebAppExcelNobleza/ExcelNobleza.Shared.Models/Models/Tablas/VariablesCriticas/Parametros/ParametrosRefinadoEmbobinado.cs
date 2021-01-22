using ExcelNobleza.Shared.Models.ComplexObjects;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Parametros
{
	public class ParametrosRefinadoEmbobinado : BaseParametros
	{
		public virtual ParameterType<double> TensionDesbobinador { get; set; }
		public virtual ParameterType<double> TensionEnbobinadorSuperior { get; set; }
		public virtual ParameterType<double> TensionEnbobinadorInferior { get; set; }
		public virtual ParameterType<double> PresionRodilloSuperior { get; set; }
		public virtual ParameterType<double> PresionRodilloInferior { get; set; }

	}
}
