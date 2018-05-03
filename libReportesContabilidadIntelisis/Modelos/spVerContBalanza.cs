using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libReportesContabilidadIntelisis.Modelos {
	public class spVerContBalanza {
		public string Cuenta { get; set; }
		public string Descripcion { get; set; }
		public string Tipo { get; set; }
		public bool EsAcumulativa { get; set; }
		public bool EsAcreedora { get; set; }
		public decimal? Inicio { get; set; }
		public decimal? Cargos { get; set; }
		public decimal? Abonos { get; set; }
		public string Familia { get; set; }
		public decimal? Final { get { return Inicio??0 + Cargos??0 - Abonos??0; } }

		[NotMapped]
		public int Periodo { get; set; }
		[NotMapped]
		public int Ejercicio { get; set; }
	}
}
