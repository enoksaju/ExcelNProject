using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace excelnobleza.shared.Models.Tablas.ResiduosPeligrosos
{
	[Table("res_Manif")]
	[Serializable]
	public class Manifiesto
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Required(ErrorMessage = "El numero de manifiesto es requerido y debe ser unico")]
		public string NoManifiesto { get; set; }
		[Required(ErrorMessage = "El proveedor es requerido")]
		public int ClaveP { get; set; }
		[Required(ErrorMessage = "El transportista es requerido")]
		public int ClaveT { get; set; }
		[Required(ErrorMessage = "El nombre del Chofer es Requerido")]
		public string NombreChofer { get; set; }
		public string CargoChofer { get; set; }
		[Required(ErrorMessage = "El nombre del Receptor es requerido")]
		public string NombreReceptor { get; set; }
		public string CargoReceptor { get; set; }
		[Required(ErrorMessage = "La fecha es Requerida")]
		public DateTime Fecha { get; set; }
		[ForeignKey("ClaveP")]
		public virtual Proveedor Proveedor { get; set; }
		[ForeignKey("ClaveT")]
		public virtual Transportista Transportista { get; set; }
		public virtual List<ManifiestoDetalle> ManifiestoDetalle { get; set; } = new List<ManifiestoDetalle>();
	}
}
