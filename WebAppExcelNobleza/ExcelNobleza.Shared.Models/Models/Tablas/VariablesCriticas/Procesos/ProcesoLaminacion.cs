using ExcelNobleza.Shared.Models.ComplexObjects;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Procesos
{
	public class ProcesoLaminacion : BaseProceso
	{
		public string ClaveResina { get; set; }
		public string ClaveCatalizador { get; set; }
		public virtual ParameterType<double> AplicacionAdhesivo { get; set; } = new ParameterType<double>("g/cm^2");
		public virtual ParameterType<double> RelacionAdhesivo { get; set; } = new ParameterType<double>("%");
		public virtual ParameterType<double> Curling { get; set; } = new ParameterType<double>("°");
		public virtual ParameterType<double> FuerzaLaminacionUno { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> FuerzaLaminacionDos { get; set; } = new ParameterType<double>();

		[Column("Lam_ElemUno")]
		public string ElementoUno { get; set; }
		[Column("Lam_ElemDos")]
		public string ElementoDos { get; set; }
		[Column("Lam_ElemTrilam")]
		public string ElementoTrilaminacion { get; set; }

		public ProcesoLaminacion()
		{
			this.ProcesoId = 2;
		}

	}
}
