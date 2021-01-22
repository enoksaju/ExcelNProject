using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelNobleza.Shared.Models.Tablas.ResiduosPeligrosos
{
	[Table("res_Proved")]
	[Serializable]
	public class Proveedor
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ClaveP { get; set; }
		public string Denominacion { get; set; }
		public string Domicilio { get; set; }
		public string Municipio { get; set; }
		public int CP { get; set; }
		public string Estado { get; set; }
		public string AutSEMARNAT { get; set; }
		public virtual List<Manifiesto> Manifiestos { get; set; } = new List<Manifiesto>();
	}
}
