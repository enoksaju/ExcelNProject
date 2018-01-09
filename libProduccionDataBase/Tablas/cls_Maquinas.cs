using System;
using System.Collections.Generic;
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
    [Table("Maquinas")]
    public class Maquina
    {
        private List<Rodillo> _Rodillos = new List<Rodillo>();
        private List<Produccion> _Produccion = new List<Produccion>();
        private List<Desperdicio> _Desperdicio = new List<Desperdicio>();
        public int Id { get; set; }
        public string NombreMaquina { get; set; }
        public double Velocidad { get; set; }
        public ushort Decks { get; set; }

        [InverseProperty("Maquina")]
        public List<Rodillo> Rodillos { get { return _Rodillos; } }

        [InverseProperty("Maquina")]
        public List<Produccion> Produccion { get { return _Produccion; } }

        [InverseProperty("Maquina")]
        public List<Desperdicio> Desperdicio { get { return _Desperdicio; } }

        [Required(ErrorMessage ="El Tipo de maquina es requerido")]
        public TipoMaquina TipoMaquina { get; set; }

    }

    /// <summary>
    /// Un Rodillo debe pertenecer a una maquina de Tipo Impresora
    /// </summary>
    [Table("Rodillos")]
    public class Rodillo
    {
        private List<Receta> _Recetas = new List<Receta>();
        public int Id { get; set; }
        public double Medida { get; set; }
        public int Cantidad { get; set; }
        [Required]
        public Maquina Maquina {get;set;}
        [InverseProperty("Rodillo")]
        public List<Receta> Recetas { get { return _Recetas; } }
    }

    /// <summary>
    /// Define los tipos de maquinas en la Base de Datos
    /// </summary>
    [Table("TiposMaquina")]
    public class TipoMaquina
    {
       private List<Maquina> _Maquinas = new List<Maquina>();
        public int Id { get; set; }
        public string Tipo_Maquina { get; set; }

        [InverseProperty("TipoMaquina")]
        public List<Maquina> Maquinas { get { return _Maquinas; } }
    }

}
