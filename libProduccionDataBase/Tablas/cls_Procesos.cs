using System;
using System.Collections.Generic;
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
        public int NombreProceso { get; set; }        
        public List<Produccion> Produccion { get { return _Produccion; } }
    }
}
