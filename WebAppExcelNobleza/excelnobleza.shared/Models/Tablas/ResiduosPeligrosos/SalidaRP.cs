using excelnobleza.shared.Models.Tablas.Produccion;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace excelnobleza.shared.Models.Tablas.ResiduosPeligrosos
{
	[Table("res_SalidaRP")]
	[Serializable]
	public class SalidaRP
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int FolioRP { get; set; }
		public int ClaveRP { get; set; }
		public int ClaveL { get; set; }
		public double Cantidad { get; set; }
		public DateTime FechaEnvasado { get; set; }
		public DateTime FechaIngreso { get; set; }
		[ForeignKey("ManifiestoDetalle")]
		public int? FolioDM { get; set; }
		public virtual ManifiestoDetalle ManifiestoDetalle { get; set; }
		[ForeignKey("ClaveRP")]
		public virtual TipoRP TipoRP { get; set; }
		[ForeignKey("ClaveL")]
		public virtual Linea Linea { get; set; }
	}
}
