using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.Produccion
{
	[Table("Procesos")]
	public class Proceso
	{
		public int ID { get; set; }
		[MaxLength(250, ErrorMessage = "El Nombre del Proceso es Requerido.")]
		public string NombreProceso { get; set; }
		public virtual List<Produccion> Produccion { get; set; } = new List<Produccion>();

		public override string ToString()
		{
			return this.NombreProceso;
		}
	}
}
