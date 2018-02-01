using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas
{
    [Table("Clientes")]
    public class Cliente
    {
        private List<Receta> _Recetas = new List<Receta>();
        public int Id { get; set; }
        [Required(ErrorMessage ="EL Nombre del cliente es requerido"), MaxLength(250)]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage ="La Clave del Cliente es Requerida"), 
         MaxLength(10, ErrorMessage ="El largo maximo para la clave del Cliente es de 10 caracteres"),
         MinLength(10, ErrorMessage ="El largo minimo para la clave del cliente es de 10 caracteres"),
         Index("ClaveCliente_IDX", IsUnique = true)]
        public string ClaveCliente { get; set; }
        [InverseProperty("Cliente")]
        public List<Receta> Recetas { get { return _Recetas; } }
        public override string ToString()
        {
            return this.NombreCliente;
        }
    }
}
