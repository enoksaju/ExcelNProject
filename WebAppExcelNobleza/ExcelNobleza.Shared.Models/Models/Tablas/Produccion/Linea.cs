using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.Produccion
{
	[Table("Lineas")]
	public class Linea
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Responsable { get; set; }
		public string EmailResponsable { get; set; }
		public virtual List<Maquina> Maquinas { get; set; } = new List<Maquina>();
		public override string ToString() => this.Nombre;
	}
}
