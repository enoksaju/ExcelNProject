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

        [Required(ErrorMessage = "El numero del embarque es requerido")]
        [Index("EmbarqueNumero", IsUnique = true, Order = 2)]
        public int Numero { get; set; }

        [Required(ErrorMessage = "La orden de trabajo es requerida")]
        [Index("EmbarqueNumero", IsUnique = true, Order = 1)]
        [MaxLength(10)]
        public string OT { get; set; }
        [ForeignKey("OT")]
        public OrdenTrabajo OrdenTrabajo { get; set; }
        public DateTime FechaEmpaque { get; set; }
        public string Usuario { get; set; }
        [InverseProperty("Embarque")]
        public List<Tarima> Tarimas { get { return _Tarimas; } }

        [Key, MaxLength(250, ErrorMessage = "La clave del empaque es incorrecta")]
        public string claveEmbarque { get { return OT + "-" + Numero + "-" + FechaEmpaque.Day + FechaEmpaque.Year; } private set { } }
    }
    [Table("Tarimas")]
    public class Tarima
    {
        private List<Produccion> _Items = new List<Produccion>();

        [Index("TarimaNumero", IsUnique = true, Order = 1)]
        public int numero { get; set; }
        [Required(ErrorMessage = "El embarque al que pertenece la tarima es requerido")]

        [MaxLength(250, ErrorMessage = "La clave del empaque es incorrecta")]
        public string claveEmbarque { get; set; }
        
        [Key, MaxLength(250, ErrorMessage = "La clave del empaque es incorrecta")]
        public string claveTarima { get { return claveEmbarque.Trim() + numero.ToString(); } private set { } }
        
        [ForeignKey("claveEmbarque ")]
        public Embarque Embarque { get; set; }
        private List<Produccion> Items { get { return _Items; } }
    }
}
