using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas
{
    [Table("Recetas")]
    public class Receta
    {
        private List<OrdenTrabajo> _OrdenesTrabajo = new List<OrdenTrabajo>();
        private string _ClaveIntelisis;
        public int Id { get; set; }

        [Required(ErrorMessage = "La clave de Intelisis es requerida"), Index(IsUnique = true)]
        [MaxLength(250, ErrorMessage = "El tamaño maximo para la clave de intelisis es de 250 caracteres")]

        public string ClaveIntelisis
        {
            get { return _ClaveIntelisis; }
            set { _ClaveIntelisis = value.Trim().ToUpper(); }
        }
        [MaxLength(500), Required(ErrorMessage = "El nombre del producto es requerido"), Index()]
        public string Producto { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Tipo de Producto")]
        public TipoProducto TipoProducto { get; set; }

        [MaxLength(500), Required(ErrorMessage = "El Diseño Autorizado que se utilizara en la receta es requerido"), Index()]
        [Column("DisenoAutorizado")]
        public string DiseñoAutorizado { get; set; }
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Cliente")]
        public int Cliente_Id { get; set; }
        [ForeignKey("Cliente_Id")]
        public Cliente Cliente { get; set; }
        public int Rodillo_Id { get; set; }
        [ForeignKey("Rodillo_Id")]
        public Rodillo Rodillo { get; set; }


        /// <summary>
        /// Determina el material Base, el valor es requerido
        /// </summary>
        [Required(ErrorMessage = "La Receta debe contener al menos el material Base")]
        public int? MaterialBase_Id { get; set; }
        [ForeignKey("MaterialBase_Id")]
        public Material MaterialBase { get; set; }
        [Required(ErrorMessage = "El calibre del material base es requerido")]
        public double? CalibreMaterialBase { get; set; }

        /// <summary>
        /// Determina el material para laminacion, el valor puede ser nulo
        /// </summary>
        public int? MaterialLaminacion_Id { get; set; }
        [ForeignKey("MaterialLaminacion_Id")]
        public Material MaterialLaminacion { get; set; }
        public double CalibreMaterialLaminacion { get; set; }

        /// <summary>
        /// Determina el material para trilaminacion, el valor puede ser nulo
        /// </summary>
        public int? MaterialTrilaminacion_Id { get; set; }
        [ForeignKey("MaterialTrilaminacion_Id")]
        public Material MaterialTrilaminacion { get; set; }
        public double CalibreMaterialTrilaminacion { get; set; }


        public double GramosTinta { get; set; }
        public double GramosAdhesivoLaminacion { get; set; }
        public double GramosAdhesivoTrilaminacion { get; set; }
        public DatosDiseño Diseño { get; set; }
        public string Descripcion { get; set; }
        public List<OrdenTrabajo> OrdenesTrabajo { get { return _OrdenesTrabajo; } }

        [ComplexType]
        public class DatosDiseño
        {
            public enum FigurasSalida { Figura_1, Figura_2, Figura_3, Figura_4, Figura_5, Figura_6, Figura_7, Figura_8 }
            public enum Zippers { No, Pouch, Delgado }
            public enum Copetes { Sencillo, Reforzado }
            public enum Adhesivos { Permanente, Removible }
            public enum TiposImpresion { Dentro, Fuera }

            [Required(ErrorMessage = "El Alto del diseño es Requerido")]
            public double? Alto { get; set; }
            [Required(ErrorMessage = "El Ancho del diseño es Requerido")]
            public double? Ancho { get; set; }
            public double? Solapa { get; set; }
            public double? Copete { get; set; }
            public double? FuelleLateral { get; set; }
            public double? FuelleFondo { get; set; }
            public double? AreaSelloReverso { get; set; }
            public double? AreaSelloFondo { get; set; }
            public int RepeticionesEje { get; set; } = 1;
            public int RepeticionesDesarrollo { get; set; } = 1;
            public Zippers Zipper { get; set; }
            public Copetes TipoCopete { get; set; }
            public Adhesivos Adhesivo { get; set; }
            public FigurasSalida FiguraFinal { get; set; }
            public FigurasSalida FiguraImpresion { get; set; }
            [NotMapped, Required]
            public TiposImpresion Tipo_Impresion { get; set; }
            [Display(AutoGenerateField = false)]
            public string TipoImpresion { get { return Tipo_Impresion.ToString(); } set { Auxiliares.SetEnumProp(Tipo_Impresion, value); } }
        }
    }
}
