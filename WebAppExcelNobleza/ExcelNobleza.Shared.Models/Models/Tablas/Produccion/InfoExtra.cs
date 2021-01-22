using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.Produccion
{
	[Table("TEMPCAPT")]
	[Serializable]
	public class InfoExtra
	{
		private string _OT = "";
		public int Id { get; set; }

		[Key]
		[ForeignKey("OrdenTrabajo")]
		public string OT { get { return _OT; } set { _OT = value.Trim(); } }

		//[ForeignKey("OT")]
		public virtual OrdenTrabajo OrdenTrabajo { get; set; }
		public string DISENIOAUT { get; set; }
		public int CENTROS { get; set; }
		public double TINTA { get; set; }
		public double ADH1 { get; set; }
		public double ADH2 { get; set; }
		public double AJUIMP { get; set; }
		public double LAMIMP { get; set; }
		public double TRIIMP { get; set; }
		public double AJULAM { get; set; }
		public double LAMLAM { get; set; }
		public double TRILAM { get; set; }
		public double AJUTRI { get; set; }
		public double TRITRI { get; set; }
		public double PORCTOLERANCIA { get; set; }
		public int ZIPPER { get; set; }
		public int ADHPERM { get; set; }
		public int ADHREM { get; set; }
		public int ESPECIAL { get; set; }
		public int ESPECIALLAM { get; set; }
		public int ESPECIALREF { get; set; }
		public int ML { get; set; }
		public int EX1 { get; set; }
		public int EX2 { get; set; }
		public int EX3 { get; set; }
		public int ZIPPER_TYPE { get; set; }
		public double MERMAPROCESO { get; set; }
		public int ENABLED { get; set; }
		public DateTime FechaCaptura { get; set; }
		[Column("ref_fig")]
		public string ReferenciaFigura { get; set; }
	}
}
