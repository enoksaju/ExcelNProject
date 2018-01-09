using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas
{
    [Table("Embarques")]
    public class Embarque
    {        
        private List<Tarima> _Tarimas = new List<Tarima>();
        public int Id { get; set; }
        
        [Required(ErrorMessage ="El numero del embarque es requerido")]
        [Index("EmbarqueNumero", IsUnique = true, Order =2)]
        public int Numero { get; set; }

        [Required(ErrorMessage ="La orden de trabajo es requerida")]
        [Index("EmbarqueNumero", IsUnique = true, Order = 1)]
        public OrdenTrabajo OrdenTrabajo { get; set; }
        
        public DateTime FechaEmpaque { get; set; }
        public string Usuario { get; set; }
        [InverseProperty("Embarque")]
        public List<Tarima> Tarimas { get { return _Tarimas; } }
    }
    [Table("Tarimas")]
    public class Tarima
    {
        private List<Produccion> _Items = new List<Produccion>();
        public int Id { get; set; }
        public Embarque Embarque { get; set; }
        [InverseProperty("Tarima")]
        private List<Produccion> Items { get { return _Items; } }
    }
}
