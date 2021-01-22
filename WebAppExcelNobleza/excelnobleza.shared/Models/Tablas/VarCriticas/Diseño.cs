using excelnobleza.shared.Auxiliares.VariablesCriticas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace excelnobleza.shared.Models.Tablas.VarCriticas
{
	[Table("vc_diseno")]
	public class Diseño
	{
		[Key]
		[Column("ClaveDiseno"), DataType("varchar(200)")]
		[MaxLength(200)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]		
		public string ClaveDiseño { get; set; }
		public virtual ICollection<Produccion.OrdenTrabajo> OT { get; set; }
		public virtual ParameterSize TamañoFotocelda { get; set; } = new ParameterSize();
		public virtual ParameterSize TamañoDiseño { get; set; } = new ParameterSize();
		public string CodigoBarras { get; set; }
		public string SobreViajero { get; set; }
		public string ClaveIntelisis { get; set; }
		public int FiguraFinal { get; set; }
		public virtual List<BaseProceso> Procesos { get; set; } = new List<BaseProceso>();
	}
}
