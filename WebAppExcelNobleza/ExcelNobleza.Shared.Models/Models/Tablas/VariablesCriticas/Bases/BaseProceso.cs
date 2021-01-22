using ExcelNobleza.Shared.Models.ComplexObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Bases
{
	public abstract class BaseProceso
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Comentarios { get; set; }
		public virtual ParameterSize TamañoDiseño { get; set; } = new ParameterSize();
		public int FiguraEmbobinado { get; set; }

		[Column(TypeName = "blob")]
		public byte[] ImagenFiguraSalida { get; set; }

		[ForeignKey("Proceso")]
		public int ProcesoId { get; set; }
		public virtual Produccion.Proceso Proceso { get; set; }

		[Column("ClaveDiseno")]
		[ForeignKey("Diseño")]
		[Required]
		public string ClaveDiseño { get; set; }
		public virtual Diseno Diseño { get; set; }
		public virtual List<BaseParametros> Parametros { get; set; } = new List<BaseParametros>();
	}
}
