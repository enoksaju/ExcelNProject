using excelnobleza.shared.Auxiliares.VariablesCriticas;
using System;
using System.Collections.Generic;
using System.Text;

namespace excelnobleza.shared.Models.Tablas.VarCriticas
{
	public class ParametrosRefinadoEmbobinado:BaseParametros
	{
		public virtual ParameterType<double> TensionDesbobinador { get; set; }
		public virtual ParameterType<double> TensionEnbobinadorSuperior { get; set; }
		public virtual ParameterType<double> TensionEnbobinadorInferior { get; set; }
		public virtual ParameterType<double> PresionRodilloSuperior { get; set; }
		public virtual ParameterType<double> PresionRodilloInferior { get; set; }

	}
}
