using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using libProduccionDataBase.Tablas;
using static libProduccionDataBase.Tablas.Material;

namespace Cotizador.Models.FrontEndModels.Catalogos
{
	public class Material
	{
		public int? Id { get; set; }
		[Required]
		public int FamiliaMateriales_Id { get; set; }
		[Required]
		public string Apariencia { get; set; }
		public string Caracteristicas { get; set; }
		public UnidadesMaterial Unidad { get; set; }
		[Required]
		public double FactorDensidad { get; set; }
		[Required]
		public double PrecioInicial { get; set; }
		[Required]
		public double CostoInicial { get; set; }
		public bool? Metalizado { get; set; }
		public bool? Convenio { get; set; }
		public DateTime FechaRegistro { get; set; }
		[Required]
		public DateTime FechaOperacion { get; set; }
		public virtual ICollection<Calibre> Calibres { get; set; }
		public double PrecioActual { get; set; }
		public string NombreFamilia { get; set; }
	}
}