using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionPesaje.Pages.MainPages.DesperdicioReports {
	public class ReportData {
		private DateTime _Fecha = DateTime.Now;
		public int ID { get; set; }
		public string OT { get; set; }
		public string OPERADOR { get; set; }
		public int TURNO { get; set; }
		public string LINEA { get; set; }
		public string MAQUINA { get; set; }
		public int NUMERO { get; set; }
		public double PESO { get; set; }
		public string FAMILIA { get; set; }
		public string DEFECTO { get; set; }
		public string DESCRIPCION { get; set; }
		public string ESTRUCTURA { get; set; }
		public DateTime FECHA { get { return _Fecha; } set { _Fecha = value; } }
		public string PROCESO { get; set; }
	}
}
