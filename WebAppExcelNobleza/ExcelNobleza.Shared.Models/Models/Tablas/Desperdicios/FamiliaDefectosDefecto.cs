using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.Desperdicios
{
	[Table(" TFamiliaDefectosTDefectos")]
	public class TFamiliaDefectosTDefecto
	{
		public int Id { get; set; }
		public int TFamiliaDefectosID { get; set; }
		public int TDefectoID { get; set; }

		[Required]
		public int ProcesoID { get; set; }
		public virtual TFamiliaDefectos FamiliaDefectos { get; set; }
		public virtual TDefecto Defecto { get; set; }
		public virtual Produccion.Proceso Proceso { get; set; }

		public override string ToString()
		{
			return this.Defecto.ToString();
		}
	}
}
