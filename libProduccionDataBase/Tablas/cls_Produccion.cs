using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas
{
    [Table("Produccion")]
    public class Produccion
    {
        public int Id { get; set; }

        [Index("Unique_for_OT_Produccion",Order = 1, IsUnique =true)]
        [Required(ErrorMessage ="La orden de trabajo es requerida")]
        [MaxLength(10)]
        public string OT { get; set; }       
        [ForeignKey("OT")]
        public OrdenTrabajo OrdenTrabajo { get; set; }

        [Index("Unique_for_OT_Produccion", Order = 2, IsUnique = true)]
        [Required(ErrorMessage ="El proceso es requerido")]
        public int ProcesoId { get; set; }
        [ForeignKey("ProcesoId")]
        public Proceso Proceso { get; set; }

        [Index("Unique_for_OT_Produccion", Order = 3, IsUnique = true)]
        [Required(ErrorMessage ="El numero del Elemento es requerido")]
        public int? Numero { get; set; }
        
        public CapturaProd_ Captura { get; set; }
        [Required(ErrorMessage = "La maquina que proceso el elemento debe ser seleccionada")]
        public int Maquina_Id { get; set; }
        [ForeignKey("Maquina_Id")]
        public Maquina Maquina { get; set; }

        [MaxLength(250, ErrorMessage = "La clave del empaque es incorrecta")]
        public string claveTarima { get; set; }
        [ForeignKey("claveTarima")]
        public Tarima Tarima { get; set; }

        [ComplexType]
        public class CapturaProd_
        {
            public enum TurnosProd { Primero, Segundo, Tercero, Mixto}
            public enum EstatusProd_ { Correcto, En_Saneo, Saneada, Rechazada, Enviada}
            [Required]
            public double? PesoBruto { get; set; }
            [Required]
            public double? PesoTara { get; set; }
            public int Piezas { get; set; }
            public int Banderas { get; set; }
            [Required, MaxLength(10)]
            public string Operador { get; set; }
            public TurnosProd Turno { get; set; }
            public int Repeticion { get; set; }
            [MaxLength(20, ErrorMessage = "El tamaño maximo para es campo es de 20 Caracteres")]
            public string ExtrusionId { get; set; }           
            public DateTime FechaCaptura { get; set; } = DateTime.Now;
            public DateTime UltimaEdicion { get; set; } = DateTime.Now;

            [NotMapped, Required]
            public EstatusProd_ EstatusEn { get; set; }
            [Required]
            public string Estatus { get { return EstatusEn.ToString(); } set { Auxiliares.SetEnumProp(EstatusEn, value); } }
        }
    }
}
