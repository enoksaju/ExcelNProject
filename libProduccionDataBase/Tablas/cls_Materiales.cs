using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas
{
    [Table("FamiliasMaterial")]
    public class FamiliaMateriales
    {
        private List<Material> _Materiales = new List<Material>();
        public int Id { get; set; }
        [MaxLength(250)]
        public string NombreFamilia { get; set; }
        [InverseProperty("FamiliaMateriales")]
        public List<Material> Materiales { get { return _Materiales; }private set { _Materiales = value; } }
        public override string ToString()
        {
            return this.NombreFamilia;
        }

        public static FamiliaMateriales AttachMateriales(FamiliaMateriales Familia, List<Material> Materiales )
        {
          var ret=  new FamiliaMateriales { Id = Familia.Id, NombreFamilia = Familia.NombreFamilia };
            ret._Materiales = Materiales;
            return ret;
        }
    }
    [Table("Material")]
    public class Material
    {
        public int Id { get; set; }
        [MaxLength( 250 )]
        public string Formula { get; set; } = "";

        [Required(ErrorMessage ="La Apariencia del Material es Requerida"),  MaxLength(250)]
        public string Apariencia { get; set; }

        [Required(ErrorMessage ="La densidad del Material es Requerida")]
        public double? Densidad { get; set; }

        [Required(ErrorMessage ="La Familia de Material es requerida")]
        public FamiliaMateriales FamiliaMateriales { get; set; }
        public override string ToString()
        {
            return String.Format( "{0} {1}: {2:#0.000} g/cm³", this.Apariencia, this.Formula, this.Densidad );  //this.Apariencia + " " + this.Formula + ": " + ;
        }
    }
}
