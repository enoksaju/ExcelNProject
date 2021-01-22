using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace excelnobleza.shared.Models.Tablas.Produccion
{
	[Table("TiposProducto")]
	public class TipoProducto
	{
		// private List<Receta> _Recetas = new List<Receta>();

		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "El nombre para el tipo de producto es requerido")]
		public string NombreTipoProducto { get; set; }

		//[InverseProperty("TipoProducto")]
		//public List<Receta> Recetas { get { return _Recetas; } }

		public override string ToString()
		{
			//return base.ToString();
			return this.NombreTipoProducto;
		}
	}
}
