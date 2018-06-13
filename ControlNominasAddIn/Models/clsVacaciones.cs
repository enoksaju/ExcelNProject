using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlNominasAddIn.Models {
	public class Vacaciones {
		public int ID { get; set; }
		public int CLAVE { get; set; }
		public DateTime DIAINICIO { get; set; }
		public DateTime DIAFIN { get; set; }
		public int DOMFER { get; set; }
		public string TIPO { get; set; }
		public string MOTIVO { get; set; }
		public string OBSERVACIONES { get; set; }
		public bool EN_BITACORA { get; set; }
		public int DIAS => ( DIAFIN - DIAINICIO ).Days + 1 - DOMFER;
	}
}
