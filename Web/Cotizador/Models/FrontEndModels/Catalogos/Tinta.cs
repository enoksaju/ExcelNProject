using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cotizador.Models.FrontEndModels.Catalogos
{
	public class Tinta
	{
		public int? TintaId { get; set; }
		[Required]
		public string Nombre { get; set; }
		public string Tipo { get; set; }
		[Required]
		public double? Precio { get; set; }
		[Required]
		public double? Costo { get; set; }

		public libProduccionDataBase.Tablas.Tinta ToNewTinta () => new libProduccionDataBase.Tablas.Tinta ( )
		{
			Nombre = this.Nombre,
			Tipo = this.Tipo,
			Costo = (double)this.Costo,
			Precio = (double)this.Precio
		};
	}

	public class Otro
	{
		public int? OtroId { get; set; }
		[Required]
		public string Nombre { get; set; }
		[Required]
		public double? Precio { get; set; }
		[Required]
		public double? Costo { get; set; }

		public libProduccionDataBase.Tablas.Otro toNewOtro () => new libProduccionDataBase.Tablas.Otro ( )
		{
			Nombre = this.Nombre,
			Precio = (double)this.Precio,
			Costo = (double)this.Costo
		};
	}

}