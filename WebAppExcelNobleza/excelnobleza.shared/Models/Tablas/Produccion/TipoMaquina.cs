using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace excelnobleza.shared.Models.Tablas.Produccion
{
	/// <summary>
	/// Define los tipos de maquinas en la Base de Datos
	/// </summary>
	[Table("TiposMaquina")]
	[DefaultProperty("Id")]
	public class TipoMaquina
	{
		public int Id { get; set; }
		public string Tipo_Maquina { get; set; }
		public virtual List<Maquina> Maquinas { get; set; } = new List<Maquina>();
		public override string ToString() => this.Tipo_Maquina;
	}
}
