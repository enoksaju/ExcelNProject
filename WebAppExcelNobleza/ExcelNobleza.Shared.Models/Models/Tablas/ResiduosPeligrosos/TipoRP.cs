using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelNobleza.Shared.Models.Tablas.ResiduosPeligrosos
{
	[Table("res_TiposRP")]
	[Serializable]
	public class TipoRP
	{
		public enum Riesgos { Corrosivo, Reactivo, Toxico, Inflamable }
		public enum Unidades { Tambo, Caja }
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ClaveRP { get; set; }
		public string Descripcion { get; set; }
		public Riesgos Riesgo { get; set; }
		public Unidades Unidad { get; set; }
	}
}
