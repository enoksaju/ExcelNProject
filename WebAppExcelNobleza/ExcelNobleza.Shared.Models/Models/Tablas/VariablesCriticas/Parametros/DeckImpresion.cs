using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Parametros
{
	[Table("VC_DecksImpresion")]
	[Serializable]
	public class DeckImpresion
	{
		public int ParametrosId { get; set; }
		public int unidad { get; set; }
		public ColorType Color { get; set; }
		public string Pantone { get; set; } = "-";
		public string Anilox { get; set; } = "-";
		public string StickyBack { get; set; } = "-";
		public string L { get; set; } = "-";
		public string A { get; set; } = "-";
		public string B { get; set; } = "-";
		public string Densidad { get; set; } = "-";
		[ForeignKey("ParametrosId")]
		public virtual ParametrosImpresion ParametrosImpresion { get; set; }
	}

}
