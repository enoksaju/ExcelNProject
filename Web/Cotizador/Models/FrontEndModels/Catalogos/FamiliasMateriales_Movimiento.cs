using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cotizador.Models.FrontEndModels.Catalogos
{
	public class Movimiento
	{
		public int Id { get; set; }
			
		public DateTime? FechaRegistro { get; set; }
		[Required]
		public DateTime? FechaOperacion { get; set; }

		[Required ( ErrorMessage = "El valor del movimiento es requerido" )]
		public double? Valor { get; set; }

		[Required]
		[Range ( 1, int.MaxValue, ErrorMessage = "Debe seleccionar un valor valido" )]
		public int? FamiliaMateriales_Id { get; set; }
	}
}