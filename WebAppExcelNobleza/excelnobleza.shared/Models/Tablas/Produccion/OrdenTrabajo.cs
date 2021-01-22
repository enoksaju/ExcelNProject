using excelnobleza.shared.Models.Tablas.Produccion.Desperdicios;
using excelnobleza.shared.Models.Tablas.Produccion.NaveCuatro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace excelnobleza.shared.Models.Tablas.Produccion
{
	[Table("TORDENTRABAJO")]
	public class OrdenTrabajo
	{
		private string _OT = "";
		[Key]
		public string OT { get { return _OT; } set { _OT = value.Trim(); } }
		public Enums.DataBaseEnums.TiposProductos TIPO { get; set; }
		public string TIPOINSTRING { get { return Regex.Replace(this.TIPO.ToString(), "([^A-Z ])([A-Z])", "$1 $2"); } }
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
		public int ENABLED { get { return (int)TempCapt?.ENABLED; } }

		public virtual List<Produccion> Produccion { get; set; } = new List<Produccion>();
		public virtual List<Desperdicio> Desperdicios { get; set; } = new List<Desperdicio>();
		public virtual List<NaveCuatro_Tarima> TarimasNCuatro { get; set; } = new List<NaveCuatro_Tarima>();

		public override string ToString() => $"{OT};{CLIENTE};{PRODUCTO}";

		[ForeignKey("OT")]
		public virtual InfoExtra TempCapt { get; set; }

		//public virtual Planeacion Planeacion { get; set; }
		//[ForeignKey("VariablesCriticas")]
		//[Column("vc_clave_Diseno")]
		//[MaxLength(50)]
		//public string ClaveDiseño_VariablesCriticas { get; set; }
		// public virtual Root VariablesCriticas { get; set; }

		[ForeignKey("Diseño")]
		[Column("ClaveDiseno"), DataType("varchar(200)")]
		[MaxLength(200)]
		public string ClaveDiseño { get; set; }
		public virtual VarCriticas.Diseño Diseño { get; set; }

		[NotMapped]
		public string TipoTrabajoString
		{
			get
			{
				switch (this.TIPOTRABAJO)
				{
					case 1:
						return "";
					case 2:
						return "Modificado";
					case 3:
						return "Repetido";
					case 4:
						return "Nuevo";
					default:
						return "";
				}
			}
		}
	}

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
