using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.VariablesCriticas
{
	[Table("vc_estructuras")]
	public class EstructuraItem
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Key, Column(Order = 1)]
		public int Posicion { get; set; }


		[MaxLength(200)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Key, Column("ClaveDiseno", Order = 0)]
		[ForeignKey("Diseno")]
		public string ClaveDiseño { get; set; }

		public virtual Diseno Diseno { get; set; }

		public string Elemento { get; set; } = "";
		public string Caracteristicas { get; set; } = "";
		public string Comentarios { get; set; } = "";
		public bool EsImpreso { get; set; } = false;

		public override string ToString()
		{
			return $"»{Elemento} - {Caracteristicas} {Comentarios}{(EsImpreso ? "[Impresión]" : "")}";
		}

	}
}
