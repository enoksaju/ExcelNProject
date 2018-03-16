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
using libProduccionDataBase.Tablas;

namespace libControlesPersonalizados {
	public partial class ReplaceAndPrintZPLProduccion : Component, IBindableComponent {
		public ReplaceAndPrintZPLProduccion () {
			InitializeComponent ( );
		}

		public ReplaceAndPrintZPLProduccion ( IContainer container ) {
			container.Add ( this );

			InitializeComponent ( );
		}

		public static string PrinterNameGlobal { get; set; } = "";

		public string PrinterName { get { return PrinterNameGlobal; } set { PrinterNameGlobal = value; } }


		public void PrintZPL ( string ZPL, libProduccionDataBase.Tablas.TempProduccion produccionElemet, Optionals optionals = null, int usedOptional = 1 ) {

			Console.WriteLine ( produccionElemet.Proceso_.NombreProceso );
			if (optionals == null) optionals = new Optionals ( );

			string OptionalValue;
			switch (usedOptional) {
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

			var produccionElementDictionary = new Dictionary<string, string> ( ) {

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

				{ "@FECHA", String.Format("{0:ddd, dd 'de' MMMM 'de' yyyy}",produccionElemet.FECHA)},
				{ "@FECHACORTA", String.Format("{0:dd-MM-yyyy}",produccionElemet.FECHA)},
				{ "@FECHAINGLES", String.Format("{0:MM-dd-yyyy}",produccionElemet.FECHA)},
				{ "@FECHAHORA", String.Format("{0:ddd, dd 'de' MMMM 'de' yyyy, hh:mm tt}",produccionElemet.FECHA)},
				{ "@FECHAHORACORTA", String.Format("{0:dd-MM-yyyy, HH:mm}",produccionElemet.FECHA)},

				{ "@BANDERAS", produccionElemet.BANDERAS.ToString()},
				{ "@NUMERO", produccionElemet.NUMERO.ToString ()},
				{ "@OPERADOR", produccionElemet.OPERADOR},
				{ "@ORIGEN", produccionElemet.ORIGEN},
				{ "@PESOBRUTO", produccionElemet.PESOBRUTO.ToString("#0.00")},
				{ "@PESOCORE", produccionElemet.PESOCORE.ToString("#0.00") },
				{ "@PESONETO", (produccionElemet.PESOBRUTO-produccionElemet .PESOCORE).ToString("#0.0") },
				{ "@PIEZAS", produccionElemet.PIEZAS.ToString ()},
				{ "@EXTRUSIONID", produccionElemet.EXTRUSION_ID},
				{ "@PROCESO", produccionElemet.Proceso_.NombreProceso},
				{ "@REPETICION", produccionElemet.REPETICION.ToString ()},
				{ "@TURNO", produccionElemet.TURNO.ToString ()},
				{ "@USUARIO", produccionElemet.USUARIO},
				{ "@ID", String.Format("000000000000",produccionElemet.Id)},
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


			//var t = obj.GetType ( ).GetProperties ( );
			StringBuilder stgBld = new StringBuilder ( ZPL );

			Regex rgx = new Regex ( @"(@)[A-Z0-9]*" );
			var T = rgx.Matches ( ZPL );

			foreach (Match res in T) {

				if (produccionElementDictionary.ContainsKey ( res.Value )) {

					stgBld.Replace ( res.Value, produccionElementDictionary [ res.Value ] );

				} else {
					stgBld.Replace ( res.Value, KryptonInputBox.Show ( "Ingrese el valor para el campo " + res.Value, "Campo no encontrado", "" ) );
				}
			}

			RAWPrinter.RawPrinter.SendStringToPrinter ( PrinterNameGlobal, stgBld.ToString ( ), String.Format ( "{0}_{1}_{2}", produccionElemet.OT, produccionElemet.Proceso_.NombreProceso, produccionElemet.NUMERO ) );
		}

		#region IBindableComponent Members

		private BindingContext bindingContext;
		private ControlBindingsCollection dataBindings;

		[Browsable ( false )]//, EditorBrowsable ( EditorBrowsableState.Never  )]
		public BindingContext BindingContext {
			get {
				if (bindingContext == null) {
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
				if (dataBindings == null) {
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
