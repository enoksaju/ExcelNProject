using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas
{

	[Table ( "cat_tintas" )]
	public class Tinta
	{
		public int TintaId { get; set; }
		[Required]
		public string Nombre { get; set; }
		public string Tipo { get; set; }
		[Required]
		public double Precio { get; set; }
		[Required]
		public double Costo { get; set; }
	}

	[Table ( "cat_otros" )]
	public class Otro
	{
		public int OtroId { get; set; }
		[Required]
		public string Nombre { get; set; }
		[Required]
		public double Precio { get; set; }
		[Required]
		public double Costo { get; set; }
	}

}
