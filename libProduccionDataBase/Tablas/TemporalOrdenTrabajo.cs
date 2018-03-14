using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas {
	[Table("TORDENTRABAJO")]
	public class TemporalOrdenTrabajo {
		private string _OT = "";		
		
		[Key]
		public string OT { get { return _OT; } set { _OT = value.Trim ( ); } }
		public int TIPO { get; set; }
		public DateTime FECHARECIBIDO { get; set; }
		public DateTime FECHAENTREGASOL { get; set; }
		public string CLIENTE { get; set; }
		public string PRODUCTO { get; set; }
		public double CANTIDAD { get; set; }
		public string UNIDAD { get; set; }
		public double ANCHO { get; set; }
		public double ALTO { get; set; }
		public double SOLAPA { get; set; }
		public double FUELLELATERAL { get; set; }
		public double FUELLEFONDO { get; set; }
		public double COPETE { get; set; }
		public double AREASELLOREV { get; set; }
		public double AREASELLOFONDO { get; set; }
		public int TIPOIMPRESION { get; set; }
		public int TIPOTRABAJO { get; set; }
		public double REPEJE { get; set; }
		public double REPDES { get; set; }
		public string MATBASE { get; set; }
		public double MATBASECALIBRE { get; set; }
		public double MATBASEKG { get; set; }
		public double MATBASEAMU { get; set; }
		public string MATLAMINACION { get; set; }
		public double MATLAMINACIONCALIBRE { get; set; }
		public double MATLAMINACIONKG { get; set; }
		public double MATLAMINACIONAMU { get; set; }
		public string MATTRILAMINACION { get; set; }
		public double MATTRILAMINACIONCALIBRE { get; set; }
		public double MATTRILAMINACIONKG { get; set; }
		public double MATTRILAMINACIONAMU { get; set; }
		public string CLAVEINTELISIS { get; set; }
		public string ORDENCOMPRA { get; set; }
		public string CLAVEPRODUCTO { get; set; }
		public string IMPRESORA { get; set; }
		public double RODILLO { get; set; }
		public int FIGURASALIDAFINAL { get; set; }
		public string EMPATES { get; set; }
		public string INSTCORTE { get; set; }
		public string INSTDOBLADO { get; set; }
		public string INSTEMBOBINADO { get; set; }
		public string INSTEXTRUSION { get; set; }
		public string INSTIMPRESION { get; set; }
		public string INSTLAMINACION { get; set; }
		public string INSTMANGAS { get; set; }
		public string INSTREFINADO { get; set; }
		public string INSTSELLADO { get; set; }
		public string OBSERVACIONES { get; set; }
		public string ESIMPRESO { get; set; }
		public double KGXMILL { get; set; }
		public string EXTIPO { get; set; }
		public string EXCOLOR { get; set; }
		public string EXTRATADO { get; set; }
		public string EXDINAS { get; set; }
		public string EXDESLIZ { get; set; }
		public string EXANTIESTATICA { get; set; }
		public string EXKG { get; set; }
		public string EXANCHO { get; set; }
	}

	[Table("TEMPCAPT")]

	public class TEMPCAPT {
		private string _OT = "";
		public int Id { get; set; }

		[Key]
		public string OT { get { return _OT; } set { _OT = value.Trim ( ); } }

		[ForeignKey("OT")]
		public virtual TemporalOrdenTrabajo OrdenTrabajo{get;set;}
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
	}
}
