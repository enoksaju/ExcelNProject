using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace excelnobleza.shared.Models.Tablas.Produccion.Desperdicios
{
	[Table("TDefectos")]
	public class TDefecto
	{
		public int Id { get; set; }
		[Required]
		public string NombreDefecto { get; set; }
		public virtual List<TFamiliaDefectosTDefecto> TFamiliaDefectosTDefecto { get; set; } = new List<TFamiliaDefectosTDefecto>();

		public override string ToString()
		{
			return this.NombreDefecto;
		}
	}
}
