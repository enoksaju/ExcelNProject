using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProduccionDataBase.Tablas;

namespace EstacionPesaje.Pages.MainPages.Produccion {
	public class dataProduccion {
		public string TIPOINSTRING { get; set; }
		public int TIPOPROCESO { get; set; }
		public int ID { get; set; }

		public string OT { get; set; }

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
		public int? P_NUMERO { get; set; }

		public double? P_PESOBRUTO { get; set; }

		public double? P_PESOCORE { get; set; }

		public int? P_PIEZAS { get; set; }

		public string P_ORIGEN { get; set; }

		public int? P_BANDERAS { get; set; }

		public short? P_ENSANEO { get; set; }

		public short? P_ESRECHAZADA { get; set; }

		public short? P_FUEEDITADA { get; set; }

		public short? P_FUESANEADA { get; set; }

		public string P_OPERADOR { get; set; }

		public int? P_TURNO { get; set; }

		public DateTime? P_FECHA { get; set; }

		public string P_USUARIO { get; set; }

		public string M_MAQUINA { get; set; }

		public short ENABLED { get; set; }

		public dataProduccion () {

		}
		public dataProduccion ( TemporalOrdenTrabajo T, int PROCESO, int index ) {
			ID = index;
			TIPOINSTRING = "";
			TIPOPROCESO = PROCESO;
			OT = T.OT;
			TIPO = T.TIPO;
			FECHARECIBIDO = T.FECHARECIBIDO;
			FECHAENTREGASOL = T.FECHAENTREGASOL;
			CLIENTE = T.CLIENTE;
			PRODUCTO = T.PRODUCTO;
			CANTIDAD = T.CANTIDAD;
			UNIDAD = T.UNIDAD;
			ANCHO = T.ANCHO;
			ALTO = T.ALTO;
			SOLAPA = T.SOLAPA;
			FUELLELATERAL = T.FUELLELATERAL;
			FUELLEFONDO = T.FUELLEFONDO;
			COPETE = T.COPETE;
			AREASELLOREV = T.AREASELLOREV;
			AREASELLOFONDO = T.AREASELLOFONDO;
			TIPOIMPRESION = T.TIPOIMPRESION;
			TIPOTRABAJO = T.TIPOTRABAJO;
			REPEJE = T.REPEJE;
			REPDES = T.REPDES;
			MATBASE = T.MATBASE;
			MATBASECALIBRE = T.MATBASECALIBRE;
			MATBASEKG = T.MATBASEKG;
			MATBASEAMU = T.MATBASEAMU;
			MATLAMINACION = T.MATLAMINACION;
			MATLAMINACIONCALIBRE = T.MATLAMINACIONCALIBRE;
			MATLAMINACIONKG = T.MATLAMINACIONKG;
			MATLAMINACIONAMU = T.MATLAMINACIONAMU;
			MATTRILAMINACION = T.MATTRILAMINACION;
			MATTRILAMINACIONCALIBRE = T.MATTRILAMINACIONCALIBRE;
			MATTRILAMINACIONKG = T.MATTRILAMINACIONKG;
			MATTRILAMINACIONAMU = T.MATTRILAMINACIONAMU;
			CLAVEINTELISIS = T.CLAVEINTELISIS;
			ORDENCOMPRA = T.ORDENCOMPRA;
			CLAVEPRODUCTO = T.CLAVEPRODUCTO;
			IMPRESORA = T.IMPRESORA;
			RODILLO = T.RODILLO;
			FIGURASALIDAFINAL = T.FIGURASALIDAFINAL;
			EMPATES = T.EMPATES;
			INSTCORTE = T.INSTCORTE;
			INSTDOBLADO = T.INSTDOBLADO;
			INSTEMBOBINADO = T.INSTEMBOBINADO;
			INSTEXTRUSION = T.INSTEXTRUSION;
			INSTIMPRESION = T.INSTIMPRESION;
			INSTLAMINACION = T.INSTLAMINACION;
			INSTMANGAS = T.INSTMANGAS;
			INSTREFINADO = T.INSTREFINADO;
			INSTSELLADO = T.INSTSELLADO;
			OBSERVACIONES = T.OBSERVACIONES;
			ESIMPRESO = T.ESIMPRESO;
			KGXMILL = T.KGXMILL;
			EXTIPO = T.EXTIPO;
			EXCOLOR = T.EXCOLOR;
			EXTRATADO = T.EXTRATADO;
			EXDINAS = T.EXDINAS;
			EXDESLIZ = T.EXDESLIZ;
			EXANTIESTATICA = T.EXANTIESTATICA;
			EXKG = T.EXKG;
			EXANCHO = T.EXANCHO;
			P_NUMERO = null;
			P_PESOBRUTO = null;
			P_PESOCORE = null;
			P_PIEZAS = null;
			P_ORIGEN = null;
			P_BANDERAS = null;
			P_ENSANEO = null;
			P_ESRECHAZADA = null;
			P_FUEEDITADA = null;
			P_FUESANEADA = null;
			P_OPERADOR = "";
			P_TURNO = null;
			P_FECHA = null;
			P_USUARIO = "";
			M_MAQUINA = "";
			ENABLED = 1;
		}

		public static List<dataProduccion> ProgresoList ( TemporalOrdenTrabajo OT ) {

			List<dataProduccion> ret = new List<dataProduccion> ( );

			OT.Produccion.ToList ( ).ForEach ( prod => {
				var y = new dataProduccion ( prod.OrdenTrabajo,CorrectProceso ( prod.TIPOPROCESO), prod.Id );
				y.P_BANDERAS = prod.BANDERAS;
				y.P_ENSANEO = prod.ENSANEO;
				y.P_ESRECHAZADA = prod.ESRECHAZADA;
				y.P_FECHA = prod.FECHA;
				y.P_FUEEDITADA = prod.FUEEDITADA;
				y.P_FUESANEADA = prod.FUESANEADA;
				y.P_NUMERO = prod.NUMERO;
				y.P_OPERADOR = prod.OPERADOR;
				y.P_ORIGEN = prod.ORIGEN;
				y.P_PESOBRUTO = prod.PESOBRUTO;
				y.P_PESOCORE = prod.PESOCORE;
				y.P_PIEZAS = prod.PIEZAS;
				y.P_TURNO = prod.TURNO;
				y.P_USUARIO = prod.USUARIO;
				ret.Add ( y );
			} );

			return ret.OrderBy ( u => u.TIPOPROCESO ).ThenBy ( u => u.P_NUMERO ).ToList ( );
		}

		private static int CorrectProceso ( int proceso ) {
			switch (proceso) {
				case 1:
					return 4;
				case 2:
					return 5;
				case 3:
					return 7;
				case 4:
					return 1;
				case 5:
					return 0;
				case 6:
					return 2;
				case 7:
					return 6;
				case 8:
					return 8;
				case 9:
					return 3;
				default:
					return 9999;
			}

		}
	}
}
