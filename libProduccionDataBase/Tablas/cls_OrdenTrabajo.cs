using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas
{
    [Table("OrdenesTrabajo")]
    public class OrdenTrabajo
    {
        private List<Produccion> _Produccion = new List<Produccion>();
        private List<Embarque> _Embarques = new List<Embarque>();
        [Key(), Index(IsUnique = true), MaxLength(10)]
        public string OT { get; set; }
        [Required(ErrorMessage ="La receta es Requerida")]
        public int Receta_Id { get; set; }
        [ForeignKey("Receta_Id")]
        public Receta Receta { get; set; }
        public DateTime FechaCaptura { get; set; }
        public Pedido_ Pedido { get; set; }
        public Ajustes_ Ajustes { get; set; }
        public Instrucciones_ Instrucciones { get; set; }
        public string Comentarios { get; set; }
        public List<Produccion> Produccion { get { return _Produccion; } }
        public List<Embarque> Embarques { get { return _Embarques; } }

        [ComplexType]
        public class Pedido_
        {
            public double CantidadPedido { get; set; }
            [Required(ErrorMessage = "El ancho del material base es requerido")]
            public double? AnchoMaterialBase { get; set; }
            public double? AnchoMaterialLaminacion { get; set; }
            public double? AnchoMaterialTrilaminacion { get; set; }
        }
        [ComplexType]
        public class Ajustes_
        {
            public double AjusteImpresion { get; set; } = 0;
            public double AjusteLaminacion { get; set; } = 0;
            public double AjusteTrilaminacion { get; set; } = 0;
            public double MermaProceso { get; set; } = 0;
        }
        [ComplexType]
        public class Instrucciones_
        {
            public string Impresion { get; set; }
            public bool UsarEspecialImpresion { get; set; }
            public bool HabilitarImpresion { get; set; }
            public string Laminacion { get; set; }
            public bool UsarEspecialLaminacion { get; set; }
            public bool HabilitarLaminacion { get; set; }
            public string Refinado { get; set; }
            public bool UsarEspecialRefinado { get; set; }
            public bool HabilitarRefinado { get; set; }
            public string Doblado { get; set; }
            public bool HabilitarDoblado { get; set; }
            public string Corte { get; set; }
            public bool HabilitarCorte { get; set; }
            public string Embobinado { get; set; }
            public bool HabilitarEmbobinado { get; set; }
            public string Mangas { get; set; }
            public bool HabilitarMangas { get; set; }
            public string Sellado { get; set; }
            public bool HabilitarSellado { get; set; }
            public string Extrusion { get; set; }
            public bool HabilitarExtrusion { get; set; }
        }
    }
}
