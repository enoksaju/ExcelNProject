using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace excelnobleza.shared.Models.Tablas.VariablesCriticas
{
	public class DecksImpresion
	{
		public int Id { get; set; }
		// [Index("UniqueDeck", IsUnique = true, Order = 0)]
		public int IdProceso { get; set; }
		// [Index("UniqueDeck", IsUnique = true, Order = 1)]
		public int Unidad { get; set; }
		public string Color { get; set; }
		public string Descripcion { get; set; }
		public string AniloxLPI { get; set; }
		public string BCM { get; set; }
		public string Stickyback { get; set; }
		public double? L { get; set; }
		public double? A { get; set; }
		public double? B { get; set; }
		public double? Densidad { get; set; }
		public double? Secado { get; set; }
		public double? Viscosidad { get; set; }

		//[ForeignKey("IdProceso")]
		public virtual DatosImpresion DatosImpresion { get; set; }
	}
}
