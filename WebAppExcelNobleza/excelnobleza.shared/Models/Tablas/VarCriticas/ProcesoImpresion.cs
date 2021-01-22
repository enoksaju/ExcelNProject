using excelnobleza.shared.Auxiliares.VariablesCriticas;
using System;
using System.Collections.Generic;
using System.Text;

namespace excelnobleza.shared.Models.Tablas.VarCriticas
{
	public class ProcesoImpresion : BaseProceso
	{
		public string ProveedorTinta { get; set; }
		public string TipoTinta { get; set; }
		public string ReferenciaEntonacion { get; set; }
		public string TipoImpresion { get; set; }
		public virtual ParameterType<double> Dureza { get; set; }

	}
}
