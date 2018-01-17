using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas
{
    [Table("Procesos")]
    public class Proceso
    {
        private List<Produccion> _Produccion = new List<Produccion>();
        public int ID { get; set; }
        [MaxLength(250,ErrorMessage ="El Nombre del Proceso es Requerido.")]
        public string NombreProceso { get; set; }        
        public List<Produccion> Produccion { get { return _Produccion; } }
    }
}
