using ExcelNobleza.Shared.Models.ComplexObjects;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Procesos
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

		public ProcesoRefinadoEmbobinado(int procesoId = 3)
		{
			this.ProcesoId = procesoId;
		}
	}
}
