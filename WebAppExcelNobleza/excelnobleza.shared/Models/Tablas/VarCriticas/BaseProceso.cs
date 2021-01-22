using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace excelnobleza.shared.Models.Tablas.VarCriticas
{
	public abstract class BaseProceso
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Comentarios { get; set; }
		public virtual Auxiliares.VariablesCriticas.ParameterSize TamañoDiseño { get; set; } = new Auxiliares.VariablesCriticas.ParameterSize();
		public int FiguraEmbobinado { get; set; }

		public int ProcesoId { get; set; }
		[ForeignKey("ProcesoId")]
		public virtual Produccion.Proceso Proceso { get; set; }

		[Column("ClaveDiseno")]
		[ForeignKey("Diseño")]
		[Required]
		public string ClaveDiseño { get; set; }

		
		[JsonIgnore]
		public virtual Diseño Diseño { get; set; }
		public virtual List<BaseParametros> Parametros { get; set; } = new List<BaseParametros>();
	}
}
