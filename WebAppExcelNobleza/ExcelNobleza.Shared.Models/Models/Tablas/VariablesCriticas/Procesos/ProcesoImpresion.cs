using ExcelNobleza.Shared.Models.ComplexObjects;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Procesos
{
	public class ProcesoImpresion : BaseProceso
	{
		public string ProveedorTinta { get; set; }
		public string TipoTinta { get; set; }
		public string ReferenciaEntonacion { get; set; }
		public string TipoImpresion { get; set; }
		public virtual ParameterType<double> Dureza { get; set; }

		public ProcesoImpresion()
		{
			this.ProcesoId = 1;
		}

	}
}
