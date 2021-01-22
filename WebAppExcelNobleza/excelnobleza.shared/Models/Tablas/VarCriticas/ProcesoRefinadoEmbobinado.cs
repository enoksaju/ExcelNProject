using excelnobleza.shared.Auxiliares.VariablesCriticas;
using System;
using System.Collections.Generic;
using System.Text;
using static excelnobleza.shared.Enums.DataBaseEnums;

namespace excelnobleza.shared.Models.Tablas.VarCriticas
{
	public class ProcesoRefinadoEmbobinado : BaseProceso
	{
		public Cores MedidaCore { get; set; } = Cores.Tres;
		public string MarcaCore { get; set; } = "Otro";
		public virtual ParameterType<double> Dureza { get; set; }
		public string ControlPrincipal { get; set; }
		public virtual ParameterType<double> ControlPrincipalTolerancia { get; set; } = new ParameterType<double>();
		public string ControlSecundario { get; set; }
		public bool PistaDoble { get; set; }
	}
}
