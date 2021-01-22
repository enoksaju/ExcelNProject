using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.Desperdicios
{
	[Table("TFamiliasDefectos")]
	public class TFamiliaDefectos
	{
		public int Id { get; set; }
		[Required]
		public string NombreFamiliaDefecto { get; set; }
		public virtual List<TFamiliaDefectosTDefecto> TFamiliaDefectosTDefecto { get; set; } = new List<TFamiliaDefectosTDefecto>();
		public override string ToString()
		{
			return this.NombreFamiliaDefecto;
		}
	}
}
