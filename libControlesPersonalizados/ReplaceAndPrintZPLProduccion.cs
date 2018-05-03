using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas;

namespace libControlesPersonalizados {
	public partial class ReplaceAndPrintZPLProduccion : Component, IBindableComponent {
		public ReplaceAndPrintZPLProduccion ( ) {
			InitializeComponent ( );
		}

		public ReplaceAndPrintZPLProduccion ( IContainer container ) {
			container.Add ( this );

			InitializeComponent ( );
		}

		public static string PrinterNameGlobal { get; set; } = "";

		public string PrinterName { get { return PrinterNameGlobal; } set { PrinterNameGlobal = value; } }

		public string PrintZPL ( string ZPL , libProduccionDataBase.Tablas.TempProduccion produccionElemet , Optionals optionals = null , bool simulate = false ) {

			Console.WriteLine ( produccionElemet.Proceso_.NombreProceso );
			if ( optionals == null )
				optionals = new Optionals ( );

			string OptionalValue;
			switch ( produccionElemet.REPETICION ) {
				case 1:
					OptionalValue = optionals.Optional1;
					break;
				case 2:
					OptionalValue = optionals.Optional2;
					break;
				case 3:
					OptionalValue = optionals.Optional3;
					break;
				case 4:
					OptionalValue = optionals.Optional4;
					break;
				case 5:
					OptionalValue = optionals.Optional5;
					break;
				default:
					OptionalValue = optionals.Optional1;
					break;
			}

			var produccionElementDictionary = new Dictionary<string , string> ( ) {

				{ "@OT", produccionElemet.OT },
				{ "@CLIENTE", produccionElemet.OrdenTrabajo.CLIENTE },
				{ "@PRODUCTO", produccionElemet.OrdenTrabajo.PRODUCTO },
				{ "@ANCHO", produccionElemet.OrdenTrabajo.ANCHO.ToString("#0.0") },
				{ "@ALTO", produccionElemet.OrdenTrabajo.ALTO.ToString("#0.0")},
				{ "@CLAVEPRODUCTO", produccionElemet.OrdenTrabajo.CLAVEPRODUCTO },
				{ "@IMPRESORA", produccionElemet.OrdenTrabajo.IMPRESORA},
				{ "@ORDENCOMPRA", produccionElemet.OrdenTrabajo.ORDENCOMPRA},
				{ "@MATBASE", produccionElemet.OrdenTrabajo.MATBASE},
				{ "@MATLAMINACION", produccionElemet.OrdenTrabajo.MATLAMINACION},
				{ "@MATTRILAMINACION", produccionElemet.OrdenTrabajo.MATTRILAMINACION},
				{ "@RODILLO", produccionElemet.OrdenTrabajo.RODILLO.ToString("#0.0")},

				{ "@EXTCOLOR", produccionElemet.OrdenTrabajo.EXCOLOR},
				{ "@EXTID", produccionElemet.EXTRUSION_ID},
				{ "@EXTTIPO", produccionElemet.OrdenTrabajo.EXTIPO},
				{ "@EXTANTIESTATICA", produccionElemet.OrdenTrabajo.EXANTIESTATICA },
				{ "@EXTTRATADO", produccionElemet.OrdenTrabajo.EXTRATADO},
				{ "@EXTFORMULA", produccionElemet.OrdenTrabajo.EXCOLOR},
				{ "@EXTANCHO", produccionElemet.OrdenTrabajo.EXANCHO},
				{ "@EXTCALIBRE", (new Func<string>(()=> {
					try
					{
						using(var calDB= new DataBaseContexto()) {
							var Temp= calDB.TEMPCAPT.FirstOrDefault(o=>o.OT== produccionElemet.OT );
							return Temp!=null? String.Concat(
								Temp.EX1!=0?(produccionElemet.OrdenTrabajo.MATBASECALIBRE  ).ToString("#.0, "):"",
								Temp.EX2!=0?(produccionElemet.OrdenTrabajo.MATLAMINACIONCALIBRE ).ToString("#.0, "):"",
								Temp.EX3!=0?(produccionElemet.OrdenTrabajo.MATTRILAMINACIONCALIBRE ).ToString("#.0"):""): "0";
						}
					}
					catch (Exception)
					{
						return "0";
					}
				} ))() },

				{ "@FECHA", String.Format("{0:ddd, dd 'de' MMMM 'de' yyyy}",produccionElemet.FECHA)},
				{ "@FECHACORTA", String.Format("{0:dd/MM/yyyy}",produccionElemet.FECHA)},
				{ "@FECHAINGLES", String.Format("{0:MM/dd/yyyy}",produccionElemet.FECHA)},
				{ "@FECHAHORA", String.Format("{0:ddd, dd 'de' MMMM 'de' yyyy, hh:mm tt}",produccionElemet.FECHA)},
				{ "@FECHAHORACORTA", String.Format("{0:dd-MM-yyyy, HH:mm}",produccionElemet.FECHA)},

				{ "@BANDERAS", produccionElemet.BANDERAS.ToString()},
				{ "@NUMERO", produccionElemet.NUMERO.ToString ()},
				{ "@OPERADOR", produccionElemet.OPERADOR},
				{ "@ORIGEN", produccionElemet.ORIGEN},
				{ "@PESOBRUTO", produccionElemet.PESOBRUTO.ToString("#0.00")},
				{ "@PESOCORE", produccionElemet.PESOCORE.ToString("#0.00") },
				{ "@PESONETO", (produccionElemet.PESOBRUTO-produccionElemet .PESOCORE).ToString("#0.00") },
				{ "@PIEZAS", produccionElemet.PIEZAS.ToString ()},
				{ "@EXTRUSIONID", produccionElemet.EXTRUSION_ID},
				{ "@PROCESO", produccionElemet.Proceso_.NombreProceso},
				{ "@REPETICION", produccionElemet.REPETICION.ToString ()},
				{ "@TURNO", produccionElemet.TURNO.ToString ()},
				{ "@USUARIO", produccionElemet.USUARIO},

				{ "@ID", produccionElemet.Id.ToString().PadLeft(10,'0')},//String.Format("000000000000",produccionElemet.Id)},
				{ "$ID",produccionElemet.Id.ToString().PadLeft(10,'0')},// String.Format("000000000000",produccionElemet.Id)},

				{ "@MAQUINA", produccionElemet .Maquina_ .NombreMaquina  },

				{ "@ITEMKB", (produccionElemet .OT.Substring(produccionElemet .OT.Length -3) + " " + produccionElemet .OPERADOR .Substring(produccionElemet .OPERADOR .Length -3)+" "+produccionElemet.ORIGEN + " " +produccionElemet .FECHA .Month .ToString ()).ToUpper ()},

				{ "@ITEMOPTIONAL", optionals .ItemOptional },
				{ "@OPTIONAL1",optionals.Optional1 },
				{ "@OPTIONAL2",optionals.Optional2 },
				{ "@OPTIONAL3",optionals.Optional3 },
				{ "@OPTIONAL4",optionals.Optional4 },
				{ "@OPTIONAL5",optionals.Optional5 },
				{ "@OPTIONALSEL", OptionalValue}
			};


			if ( produccionElemet.ENSANEO == 0 ) {
				ZPL = Regex.Replace ( ZPL , @"(\^FXENSANEO\^FS){1}[A-Z0-9a-z .,\^@\n\t\r\/+$-\\]+(\^FXENSANEO\^FS)+" , "" );
			} else {
				ZPL = Regex.Replace ( ZPL , @"(\^FXNOTENSANEO\^FS){1}[A-Z0-9a-z .,\^@\n\t\r\/+$-\\]+(\^FXNOTENSANEO\^FS)+" , "" );
			}

			StringBuilder stgBld = new StringBuilder ( ZPL );

			var T = Regex.Matches ( ZPL , @"([@$]{1})[A-Z0-9]*" );

			foreach ( Match res in T ) {

				if ( produccionElementDictionary.ContainsKey ( res.Value ) ) {

					stgBld.Replace ( res.Value , produccionElementDictionary [ res.Value ] );

				} else {
					stgBld.Replace ( res.Value , KryptonInputBox.Show ( "Ingrese el valor para el campo " + res.Value , "Campo no encontrado" , "" ) );
				}
			}


			var MakeOptionals = Regex.Matches ( ZPL , @"([@$]{1})[A-Z0-9]*" );

			foreach ( Match res in MakeOptionals ) {

				if ( produccionElementDictionary.ContainsKey ( res.Value ) ) {

					stgBld.Replace ( res.Value , produccionElementDictionary [ res.Value ] );

				} else {
					stgBld.Replace ( res.Value , KryptonInputBox.Show ( "Ingrese el valor para el campo " + res.Value , "Campo no encontrado" , "" ) );
				}
			}


			if ( !simulate ) {
				RAWPrinter.RawPrinter.SendStringToPrinter ( PrinterNameGlobal , stgBld.ToString ( ) , String.Format ( "{0}_{1}_{2}" , produccionElemet.OT , produccionElemet.Proceso_.NombreProceso , produccionElemet.NUMERO ) );
			}
			return stgBld.ToString ( );
		}


		public static string ZPLDesperdicio = @"
^XA

^FO5,10^GB380,250,1^FS
^FO5,142^GB380,119,1^FS
^FO5,142^GB200,119,1^FS

^FO53,17^A0N,19,20^FDTRAZABILIDAD DESPERDICIO^FS

^FO129,41^A0N,19,20^FDOT:^FS
    ^FO171,36^A0N,25,27^FD@OT^FS    
^FO36,65^A0N,14,13^FDCLIENTE:^FS
    ^FO100,65^A0N,16,15^FD@CLIENTE^FS
^FO19,84^A0N,14,13^FDPRODUCTO:^FS
    ^FO100,84^A0N,16,15^FD@PRODUCTO^FS
^FO17,100^A0N,14,13^FDOP:^FS
    ^FO40,100^A0N,16,15^FD@OPERADOR^FS
^FO120,100^A0N,14,13^FDTURNO:^FS
    ^FO165,100^A0N,15,16^FD@TURNO^FS
^FO210,100^A0N,14,13^FDMAQUINA:^FS
    ^FO275,100^A0N,15,16^FD@MAQUINA^FS
^FO96,120^A0N,25,20^FDPESO/#:^FS^
    ^FO176,120^A0N,28,23^FD@PESO Kg / @NUMERO^FS
^FO20,145^A0N,15,16^FDDESCRIPCION:^FS
    ^FO10,158^FB200,3,0,L,0^A0N,15,14^FD@FAMILIA - @DEFECTO: @DESCRIPCION^FS
^FO210,145^A0N,15,16^FDESTRUCTURA:^FS
    ^FO210,158^FB200,3,0,J,0^A0N,22,15^FD@ESTRUCTURA^FS
^FO20,232^A0N,14,15^FD@FECHAHORA^FS



^FO405,10^GB380,250,1^FS
^FO405,142^GB380,119,1^FS
^FO405,142^GB200,119,1^FS

^FO453,17^A0N,19,20^FDTRAZABILIDAD DESPERDICIO^FS

^FO529,41^A0N,19,20^FDOT:^FS
    ^FO571,36^A0N,25,27^FD@OT^FS    
^FO436,65^A0N,14,13^FDCLIENTE:^FS
    ^FO500,65^A0N,16,15^FD@CLIENTE^FS
^FO419,84^A0N,14,13^FDPRODUCTO:^FS
    ^FO500,84^A0N,16,15^FD@PRODUCTO^FS
^FO417,100^A0N,14,13^FDOP:^FS
    ^FO440,100^A0N,16,15^FD@OPERADOR^FS
^FO520,100^A0N,14,13^FDTURNO:^FS
    ^FO565,100^A0N,15,16^FD@TURNO^FS
^FO610,100^A0N,14,13^FDMAQUINA:^FS
    ^FO675,100^A0N,15,16^FD@MAQUINA^FS
^FO496,120^A0N,25,20^FDPESO/#:^FS^
    ^FO576,120^A0N,28,23^FD@PESO Kg / @NUMERO^FS
^FO420,145^A0N,15,16^FDDESCRIPCION:^FS
    ^FO410,158^FB200,3,0,L,0^A0N,15,14^FD @FAMILIA - @DEFECTO: @DESCRIPCION^FS
^FO610,145^A0N,15,16^FDESTRUCTURA:^FS
    ^FO610,158^FB200,3,0,J,0^A0N,22,15^FD@ESTRUCTURA^FS
^FO420,232^A0N,14,15^FD@FECHAHORA^FS

^XZ
";

		public string PrintDesperdicio ( libProduccionDataBase.Tablas.TempDesperdicios TempDesperdicio , bool simulate = false ) {



			var produccionElementDictionary = new Dictionary<string , string> ( ) {
				{ "@OT", TempDesperdicio.OT },
				{ "@CLIENTE", TempDesperdicio.OrdenTrabajo.CLIENTE },
				{ "@PRODUCTO", TempDesperdicio.OrdenTrabajo.PRODUCTO },
				{ "@ANCHO", TempDesperdicio.OrdenTrabajo.ANCHO.ToString("#0.0") },
				{ "@ALTO", TempDesperdicio.OrdenTrabajo.ALTO.ToString("#0.0")},
				{ "@CLAVEPRODUCTO", TempDesperdicio.OrdenTrabajo.CLAVEPRODUCTO },
				{ "@IMPRESORA", TempDesperdicio.OrdenTrabajo.IMPRESORA},
				{ "@ORDENCOMPRA", TempDesperdicio.OrdenTrabajo.ORDENCOMPRA},
				{ "@MATBASE", TempDesperdicio.OrdenTrabajo.MATBASE},
				{ "@MATLAMINACION", TempDesperdicio.OrdenTrabajo.MATLAMINACION},
				{ "@MATTRILAMINACION", TempDesperdicio.OrdenTrabajo.MATTRILAMINACION},
				{ "@RODILLO", TempDesperdicio.OrdenTrabajo.RODILLO.ToString("#0.0")},

				{ "@FECHA", String.Format("{0:ddd, dd 'de' MMMM 'de' yyyy}",TempDesperdicio.FECHA)},
				{ "@FECHACORTA", String.Format("{0:dd-MM-yyyy}",TempDesperdicio.FECHA)},
				{ "@FECHAINGLES", String.Format("{0:MM-dd-yyyy}",TempDesperdicio.FECHA)},
				{ "@FECHAHORA", String.Format("{0:ddd, dd 'de' MMMM 'de' yyyy, hh:mm tt}",TempDesperdicio.FECHA)},
				{ "@FECHAHORACORTA", String.Format("{0:dd-MM-yyyy, HH:mm}",TempDesperdicio.FECHA)},

				{ "@ESTRUCTURA", TempDesperdicio.ESTRUCTURA.ToString()},
				{ "@NUMERO", TempDesperdicio.NUMERO.ToString ()},
				{ "@OPERADOR", TempDesperdicio.OPERADOR},
				{ "@DEFECTO", TempDesperdicio.FamiliaDefectosDefecto.Defecto.NombreDefecto},
				{ "@PESO", TempDesperdicio.PESO.ToString("#0.00")},
				{ "@DESCRIPCION", TempDesperdicio.DESCRIPCION.ToString() },
				{ "@FAMILIA", TempDesperdicio.FamiliaDefectosDefecto.FamiliaDefectos.NombreFamiliaDefecto},
				{ "@PROCESO", TempDesperdicio.FamiliaDefectosDefecto.Proceso .NombreProceso  },
				{ "@MAQUINA", TempDesperdicio .Maquina_ .NombreMaquina },
				{ "@LINEA", TempDesperdicio .Maquina_ .Linea .Nombre },
				{ "@TURNO", TempDesperdicio .TURNO.ToString ()  },

			};

			StringBuilder stgBld = new StringBuilder ( ZPLDesperdicio );

			Regex rgx = new Regex ( @"(@)[A-Z0-9]*" );
			var T = rgx.Matches ( ZPLDesperdicio );

			foreach ( Match res in T ) {

				if ( produccionElementDictionary.ContainsKey ( res.Value ) ) {

					stgBld.Replace ( res.Value , produccionElementDictionary [ res.Value ] );

				} else {
					stgBld.Replace ( res.Value , KryptonInputBox.Show ( "Ingrese el valor para el campo " + res.Value , "Campo no encontrado" , "" ) );
				}
			}

			if ( !simulate ) {
				RAWPrinter.RawPrinter.SendStringToPrinter ( PrinterNameGlobal , stgBld.ToString ( ) , String.Format ( "{0}_Desperdicio_{1}" , TempDesperdicio.OT , TempDesperdicio.NUMERO ) );
			}

			return stgBld.ToString ( );
		}


		#region IBindableComponent Members

		private BindingContext bindingContext;
		private ControlBindingsCollection dataBindings;

		[Browsable ( false )]//, EditorBrowsable ( EditorBrowsableState.Never  )]
		public BindingContext BindingContext {
			get {
				if ( bindingContext == null ) {
					bindingContext = new BindingContext ( );
				}
				return bindingContext;
			}
			set {
				bindingContext = value;
			}
		}

		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		public ControlBindingsCollection DataBindings {
			get {
				if ( dataBindings == null ) {
					dataBindings = new ControlBindingsCollection ( this );
				}
				return dataBindings;
			}
		}


		#endregion
	}
	public class Optionals {
		public string ItemOptional { get; set; } = "";
		public string Optional1 { get; set; } = "";
		public string Optional2 { get; set; } = "";
		public string Optional3 { get; set; } = "";
		public string Optional4 { get; set; } = "";
		public string Optional5 { get; set; } = "";
	}
}
