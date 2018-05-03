using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadIntelisisRep_AddIn.Modelos {
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
		public decimal? Final { get { return Inicio ?? 0 + Cargos ?? 0 - Abonos ?? 0; } }
		[NotMapped]
		public int Periodo { get; set; }
		[NotMapped]
		public int Ejercicio { get; set; }
	}

	public class spVerContBalanza_Mod {

		public int Periodo { get; set; }
		public string Mes { get { return String.Format ( "{0:MMMM}" , new DateTime ( 1990 , Periodo > 0 ? Periodo : 1 , 1 ) ); } }
		public int Ejercicio { get; set; }
		public string ClaveMayor { get; set; }
		public string Mayor { get; set; }
		public string ClaveSubCuenta { get; set; }
		public string SubCuenta { get; set; }
		public string Cuenta { get; set; }
		public string Descripcion { get; set; }
		public decimal? Inicio { get; set; }
		public decimal? Cargos { get; set; }
		public decimal? Abonos { get; set; }
		public decimal? Final { get; set; }
		public string Familia { get; set; }
	}
}

