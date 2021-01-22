using ExcelNobleza.Shared.Models.ComplexObjects;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.VariablesCriticas
{
	[Table("vc_diseno")]
	public class Diseno
	{
		[Key]
		[Column("ClaveDiseno")]
		[MaxLength(200)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public string ClaveDiseño { get; set; }
		public virtual List<Produccion.OrdenTrabajo> OT { get; set; } = new List<Produccion.OrdenTrabajo>();
		public virtual ParameterSize TamañoFotocelda { get; set; } = new ParameterSize();
		public virtual ParameterSize TamañoDiseño { get; set; } = new ParameterSize();
		public string CodigoBarras { get; set; }
		public string SobreViajero { get; set; }
		public string ClaveIntelisis { get; set; }
		public int FiguraFinal { get; set; }
		public virtual List<BaseProceso> Procesos { get; set; } = new List<BaseProceso>();
		public virtual List<EstructuraItem> EstructuraItems { get; set; } = new List<EstructuraItem>();

	}
}
