using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace excelnobleza.shared.Models.Tablas.ResiduosPeligrosos
{
	[Table("res_dmanif")]
	[Serializable]
	public class ManifiestoDetalle
	{
		public int Id { get; set; }
		[ForeignKey("Manifiesto")]
		public string NoManifiesto { get; set; }
		public virtual Manifiesto Manifiesto { get; set; }
		[ForeignKey("TipoRP")]
		public int ClaveRP { get; set; }
		public virtual TipoRP TipoRP { get; set; }
		public virtual List<SalidaRP> SalidaResiduosPeligrosos { get; set; } = new List<SalidaRP>();
		public double Peso => this.SalidaResiduosPeligrosos.Sum(o => o.Cantidad);
		public int Count => this.SalidaResiduosPeligrosos.Count();
		public string NombreRP => this.TipoRP.Descripcion;
		public string UnidadRP => this.TipoRP.Unidad.ToString();
	}
}
