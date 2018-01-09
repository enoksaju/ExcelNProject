using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas
{
    [Table("TiposProducto")]
    public class TipoProducto
    {
        private List<Receta> _Recetas = new List<Receta>();
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre para el tipo de producto es requerido")]
        public string NombreTipoProducto { get; set; }
        [InverseProperty("TipoProducto")]
        public List<Receta> Recetas { get { return _Recetas; } }
    }
}
