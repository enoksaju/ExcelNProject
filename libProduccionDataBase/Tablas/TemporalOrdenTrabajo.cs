using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace libProduccionDataBase.Tablas {
	[Table ( "TORDENTRABAJO" )]
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

		public virtual ObservableListSource<TempProduccion> Produccion { get; private set; }
		public virtual ObservableListSource<TempDesperdicios> Desperdicios { get; private set; }
		public virtual ObservableListSource<NaveCuatro_Tarima> TarimasNCuatro { get; private set; }
		public TemporalOrdenTrabajo ( ) {
			this.Produccion = new ObservableListSource<TempProduccion> ( );//new ICollection<TempProduccion> ( );
			this.Desperdicios = new ObservableListSource<TempDesperdicios> ( );
			this.TarimasNCuatro = new ObservableListSource<NaveCuatro_Tarima> ( );
		}

		public override string ToString ( ) => this.OT;
	}

	[Table ( "TEMPCAPT" )]
	public class TEMPCAPT {
		private string _OT = "";
		public int Id { get; set; }

		[Key]
		public string OT { get { return _OT; } set { _OT = value.Trim ( ); } }

		[ForeignKey ( "OT" )]
		public virtual TemporalOrdenTrabajo OrdenTrabajo { get; set; }
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
	}
	[Table ( "TPRODUCCION" )]
	public class TempProduccion {

		[Key]
		public int Id { get; set; }

		[Required ( ErrorMessage = "El numero de orden de trabajo es requerido" )]
		public string OT { get; set; }


		[Required ( ErrorMessage = "El tipo de proceso es requerido" )]
		public int TIPOPROCESO { get; set; }

		public int NUMERO { get; set; }

		public double PESOBRUTO { get; set; }

		[NotMapped]
		public double PESONETO { get { try { return PESOBRUTO - PESOCORE; } catch { return 0; } } }

		public double PESOCORE { get; set; }

		public int PIEZAS { get; set; }

		public int BANDERAS { get; set; }

		public int MAQUINA { get; set; }

		public string ORIGEN { get; set; }

		public string OPERADOR { get; set; }

		public int TURNO { get; set; }

		public DateTime FECHA { get; set; }

		public short ENSANEO { get; set; }

		public short FUESANEADA { get; set; }

		public short FUEEDITADA { get; set; }

		public short ESRECHAZADA { get; set; }

		public string USUARIO { get; set; }

		[Index ( IsUnique = true ), MaxLength ( 128 )]
		public string INDICE { get; set; }

		public int REPETICION { get; set; }

		public string EXTRUSION_ID { get; set; }

		[ForeignKey ( "TIPOPROCESO" )]
		public virtual Proceso Proceso_ { get; set; }

		[ForeignKey ( "MAQUINA" )]
		public virtual Maquina Maquina_ { get; set; }

		[ForeignKey ( "OT" )]
		public virtual TemporalOrdenTrabajo OrdenTrabajo { get; set; }
	}


	#region Desperdicios

	[Table ( "TDESPERDICIOS" )]
	public class TempDesperdicios {

		public int Id { get; set; }
		[Required ( ErrorMessage = "El numero de orden de trabajo es requerido" )]
		public string OT { get; set; }
		[Required ( ErrorMessage = "EL operador es requerido" )]
		public string OPERADOR { get; set; }
		public int TURNO { get; set; }
		public int MAQUINA { get; set; }
		public int NUMERO { get; set; }
		public double PESO { get; set; }
		public int DEFECTO { get; set; }
		public string DESCRIPCION { get; set; }
		public DateTime FECHA { get; set; }
		public string USUARIO { get; set; }
		public string ESTRUCTURA { get; set; }
		[ForeignKey ( "DEFECTO" )]
		public virtual TFamiliaDefectosTDefecto FamiliaDefectosDefecto { get; set; }

		[ForeignKey ( "OT" )]
		public virtual TemporalOrdenTrabajo OrdenTrabajo { get; set; }

		[ForeignKey ( "MAQUINA" )]
		public virtual Maquina Maquina_ { get; set; }

		[NotMapped]
		public virtual TFamiliaDefectos FamiliaDefecto { get { return FamiliaDefectosDefecto?.FamiliaDefectos; } }
	}

	[Table ( "TFamiliasDefectos" )]
	public class TFamiliaDefectos {
		public int Id { get; set; }

		[Required]
		public string NombreFamiliaDefecto { get; set; }

		public virtual ObservableListSource<TFamiliaDefectosTDefecto> TFamiliaDefectosTDefecto { get; private set; }
		public TFamiliaDefectos ( ) {
			TFamiliaDefectosTDefecto = new ObservableListSource<TFamiliaDefectosTDefecto> ( );
		}
		public override string ToString ( ) {
			return this.NombreFamiliaDefecto;
		}
	}

	[Table ( "TDefectos" )]
	public class TDefecto {
		public int Id { get; set; }
		[Required]
		public string NombreDefecto { get; set; }
		public virtual ObservableListSource<TFamiliaDefectosTDefecto> TFamiliaDefectosTDefecto { get; private set; }
		public TDefecto ( ) {
			TFamiliaDefectosTDefecto = new ObservableListSource<TFamiliaDefectosTDefecto> ( );
		}

		public override string ToString ( ) {
			return this.NombreDefecto;
		}
	}
	[Table ( " TFamiliaDefectosTDefectos" )]
	public class TFamiliaDefectosTDefecto {
		public int Id { get; set; }

		public int TFamiliaDefectosID { get; set; }

		public int TDefectoID { get; set; }

		[Required]
		public int ProcesoID { get; set; }
		public virtual TFamiliaDefectos FamiliaDefectos { get; set; }
		public virtual TDefecto Defecto { get; set; }

		public virtual Proceso Proceso { get; set; }

		public override string ToString ( ) {
			return this.Defecto.ToString ( );
		}
	}

	#endregion

}

