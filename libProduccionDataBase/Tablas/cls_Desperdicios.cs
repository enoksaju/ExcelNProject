using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas
{
   public  class Desperdicio
    {
        [Key, Column(Order = 1)]
        [Required(ErrorMessage = "La orden de trabajo es requerida")]
        [ForeignKey("OrdenTrabajo")]
        [MaxLength(10)]
        public string OT { get; set; }
        public OrdenTrabajo OrdenTrabajo { get; set; }

        [Key, Column(Order = 2)]
        [Required(ErrorMessage = "El proceso es requerido")]
        [ForeignKey("Proceso")]
        public int Proceso_Id { get; set; }
        public Proceso Proceso { get; set; }

        [Key, Column(Order = 3)]
        [Required(ErrorMessage = "El numero del Elemento es requerido")]
        public int? Numero { get; set; }
        public CapturaDesp_ Captura { get; set; }
        [Required(ErrorMessage = "La maquina que proceso el elemento debe ser seleccionada")]
        public int Maquina_Id { get; set; }
        [ForeignKey("Maquina_Id")]
        public Maquina Maquina { get; set; }
        public Material Material1 { get; set; }
        public Material Material2 { get; set; }
        public Material Material3 { get; set; }
        [Required(ErrorMessage ="El Defecto es Requerido")]
        public Defecto Defecto { get; set; }

        [ComplexType]
        public class CapturaDesp_
        {
            public enum TurnosDesp { Primero, Segundo, Tercero, Mixto }
            public enum EstatusDesp_ {enLinea, Transferido  }
            [Required]
            public double? Peso { get; set; }
            [Required, MaxLength(10)]
            public string Operador { get; set; }
            public TurnosDesp Turno { get; set; }
            public DateTime FechaCaptura { get; set; } = DateTime.Now;
            public DateTime UltimaEdicion { get; set; } = DateTime.Now;

            [NotMapped, Required]
            public EstatusDesp_ EstatusEn { get; set; }
            [Required]
            public string Estatus { get { return EstatusEn.ToString(); } set { Auxiliares.SetEnumProp(EstatusEn, value); } }
        }
    }

    [Table("FamiliasDefectos")]
    public class FamiliaDefectos
    {
        private List<Defecto> _Defectos = new List<Defecto>();
        public int Id { get; set; }
        [MaxLength(500, ErrorMessage = "EL tamaño maximo para el nombre de la Familia de Defectos es de 500 caracteres")]
        public string NombreFamiliaDefecto { get; set; }
        [InverseProperty("FamiliaDefectos")]
        public List<Defecto> Defectos { get { return _Defectos; } }
    }

    [Table("Defectos")]
    public class Defecto
    {
        public int Id { get; set; }
        [MaxLength(500, ErrorMessage ="EL tamaño maximo para el nombre del defecto es de 500 caracteres")]
        public string NombreDefecto { get; set; } 
        [Required(ErrorMessage ="La Familia de Defectos es Requerida")]       
        public FamiliaDefectos FamiliaDefectos { get; set; }
    }
}
