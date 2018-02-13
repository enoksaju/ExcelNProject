using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas
{
    /// <summary>
    /// Maquinas Existentes
    /// </summary>
    [Table( "Maquinas" )]
    public class Maquina
    {
        private List<Rodillo> _Rodillos;
        private List<Produccion> _Produccion;
        private List<Desperdicio> _Desperdicio;
        public int Id { get; set; }
        [Required( ErrorMessage = "El nombre de la Maquina es requerido" )]
        public string NombreMaquina { get; set; }
        [Required( ErrorMessage = "La velocidad de la Maquina es requerida" )]
        public double? Velocidad { get; set; }
        [Required( ErrorMessage = "El Numero de Decks de la Maquina es requerido" )]
        public int? Decks { get; set; }

        [InverseProperty( "Maquina" )]
        public virtual List<Rodillo> Rodillos { get { return _Rodillos; } private set { _Rodillos = value; } }
        public virtual List<Produccion> Produccion { get { return _Produccion; } private set { _Produccion = value; } }
        public virtual List<Desperdicio> Desperdicio { get { return _Desperdicio; } private set { _Desperdicio = value; } }

        [Required( ErrorMessage = "El Tipo de maquina es requerido" )]
        public int? TipoMaquina_Id { get; set; }
        [ForeignKey( "TipoMaquina_Id" )]
        public virtual TipoMaquina TipoMaquina { get; set; }

        [Required( ErrorMessage = "La Linea a la que pertenece la maquina es requerida" )]
        public int? Linea_Id { get; set; }
        [ForeignKey( "Linea_Id" )]
        public virtual Linea Linea { get; set; }

        public Maquina()
        {
            _Rodillos = new List<Rodillo>();
            _Produccion = new List<Produccion>();
            _Desperdicio = new List<Desperdicio>();
        }
        public static Maquina AttachRodillos(Maquina Impresora, List<Rodillo> Rodillos )
        {                        
            var ret=  new Maquina {
                Id = Impresora.Id,
                Linea_Id = Impresora.Linea_Id,
                 NombreMaquina= Impresora.NombreMaquina,
                 TipoMaquina_Id= Impresora.TipoMaquina_Id,
                 Velocidad= Impresora.Velocidad,
                  Decks= Impresora.Decks
            };

            ret._Rodillos = Rodillos;
            return ret;
        }

        public override string ToString()
        {
            return this.NombreMaquina;
        }

    }

    /// <summary>
    /// Un Rodillo debe pertenecer a una maquina de Tipo Impresora
    /// </summary>
    [Table( "Rodillos" )]
    public class Rodillo
    {
        private List<Receta> _Recetas = new List<Receta>();
        public int Id { get; set; }
        public double Medida { get; set; }
        public int Cantidad { get; set; }
        [Required]
        public virtual Maquina Maquina { get; set; }
        [InverseProperty( "Rodillo" )]
        public virtual List<Receta> Recetas { get { return _Recetas; } }

        public override string ToString()
        {
            return this.Medida.ToString( "#0.00" );
        }
    }

    /// <summary>
    /// Define los tipos de maquinas en la Base de Datos
    /// </summary>
    [Table( "TiposMaquina" )]
    [DefaultProperty("Id")]
    public class TipoMaquina
    {
        private List<Maquina> _Maquinas = new List<Maquina>();
        public int Id { get; set; }
        public string Tipo_Maquina { get; set; }
        public virtual List<Maquina> Maquinas { get { return _Maquinas; } }
        public override string ToString()
        {
            return this.Tipo_Maquina;
        }
    }

    [Table( "Lineas" )]
    public class Linea
    {
        private List<Maquina> _Maquinas = new List<Maquina>();
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual List<Maquina> Maquinas { get { return _Maquinas; } }

        public override string ToString()
        {
            return this.Nombre;
        }
    }

}
