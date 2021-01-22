using excelnobleza.shared.Auxiliares.VariablesCriticas;
using System;
using System.Collections.Generic;
using System.Text;
using static excelnobleza.shared.Enums.DataBaseEnums;

namespace excelnobleza.shared.Models.Tablas.VariablesCriticas
{
	public class DatosRefinado : BaseProcesos
	{
		public Cores Core { get; set; } = Cores.Tres;
		public string Marca { get; set; }
		public string VariableSecundaria { get; set; }
		public string VariablePrincipal { get; set; }		
		public bool EsPistaDoble { get; set; }
		public ParameterType<string> VariablePrincipalTolerancias { get; set; }
		public ParameterType<double> ParTenDesbobinador { get; set; }
		public ParameterType<double> ParTenBobinadorSuperior { get; set; }
		public ParameterType<double> ParTenBobinadorInferior { get; set; }
		public ParameterType<double> ParPresRodPisorSuperior { get; set; }
		public ParameterType<double> ParPresRodPisorInferior { get; set; }
	}
}
