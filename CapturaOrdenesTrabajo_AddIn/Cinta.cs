using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.VisualBasic;

namespace CapturaOrdenesTrabajo_AddIn
{
	public partial class Cinta
	{
		private const string LIBRO_INCORRECTO = "El libro y la hoja que desea usar no corresponde al archivo relacionado con el Complemento";

		internal virtual Microsoft.Office.Interop.Excel.Application EXAPP { get; set; }
		private void Cinta_Load ( object sender, RibbonUIEventArgs e )
		{
			this.EXAPP = Globals.ThisAddIn.Application;
			//Globals.ThisAddIn.ntMSG.Visible = true;
		}
		private void chkCrearActualizar_Click ( object sender, RibbonControlEventArgs e )
		{
			Properties.Settings.Default.EnableCrear = ( (RibbonCheckBox)sender ).Checked;
			btnCrearActualizar.Enabled = ( (RibbonCheckBox)sender ).Checked;
			Properties.Settings.Default.Save ( );
		}
		private void chkGuardarALEnviar_Click ( object sender, RibbonControlEventArgs e )
		{
			Properties.Settings.Default.AutomaticSaveBook = ( (RibbonCheckBox)sender ).Checked;
			btnGuardarLibro.Enabled = ( (RibbonCheckBox)sender ).Checked;
			Properties.Settings.Default.Save ( );
		}
		private void btnAbrir_Click ( object sender, RibbonControlEventArgs e )
		{
			try
			{

				// ISSUE: variable of a compiler-generated type
				Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application ( );
				application.Visible = true;

				application.Workbooks.Open ( Properties.Settings.Default.Plantilla, ReadOnly: true );//, true );
				Globals.ThisAddIn.ntMSG.ShowBalloonTip ( 500, "Correcto..", "Se abrio correctamente la plantilla" + Properties.Settings.Default.Plantilla, System.Windows.Forms.ToolTipIcon.Info );
			}
			catch ( Exception ex )
			{
				Globals.ThisAddIn.ntMSG.ShowBalloonTip ( 500, "Error..", ex.Message, System.Windows.Forms.ToolTipIcon.Error );
			}
		}
		private void btnLimpiar_Click ( object sender, RibbonControlEventArgs e )
		{
			if ( MessageBox.Show ( "Realmente desea Limpiar?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No ) return;

			this.Limpiar ( );
		}
		private void btnConfigurar_Click ( object sender, RibbonControlEventArgs e )
		{
			using ( OpenFileDialog openFileDialog = new OpenFileDialog ( ) )
			{
				openFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
				openFileDialog.FilterIndex = 0;
				openFileDialog.Multiselect = false;
				if ( openFileDialog.ShowDialog ( ) == DialogResult.Cancel )
					return;
				Properties.Settings.Default.Plantilla = openFileDialog.FileName;
				Properties.Settings.Default.Save ( );
			}
		}
		private void btnGuardarLibro_Click ( object sender, RibbonControlEventArgs e )
		{
			this.GuardarLibro ( );
		}
		private void btnCrearActualizar_Click ( object sender, RibbonControlEventArgs e )
		{
			try
			{

				string OT_Number = this.EXAPP.Range[ "A5" ].Text.Trim ( );

				Microsoft.Office.Interop.Excel.Worksheet sh = this.EXAPP.ActiveWorkbook.ActiveSheet;

				if ( this.EXAPP.Range[ "A2" ].Value != "captura pedidos2" ) throw new Exception ( "El libro y la hoja que desea usar no corresponde al archivo relacionado con el Complemento" );

				if ( OT_Number == "" ) throw new Exception ( "No se ha indicado el numero de Orden de Trabajo" );

				if ( OT_Number.Length > 10 ) throw new Exception ( "El numero de Orden de trabajo es muy largo" );

				if ( sh.Range[ "A11" ].Text.Trim ( ) == "" || sh.Range[ "A44" ].Text.Trim ( ) == "" ) throw new Exception ( "El nombre del cliente o del producto es invalido o nulo" );

				if ( sh.Range[ "A13" ].Text == "True" && sh.Range[ "A54" ].Text.Trim ( ) == "" ) throw new Exception ( "Para los trabajos con impresión es necesario indicar el diseño autorizado" );

				if ( MessageBox.Show ( "¿Desea crear o actualizar la OT?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No ) return;

				this.EXAPP.StatusBar = (object)"Revisando si la OT existe...";
				using ( DataBaseContexto dataBaseContexto = new DataBaseContexto ( ) )
				{
					// dataBaseContexto.Database.Log = ( f ) => { System.Diagnostics.Debug.WriteLine ( f, "SAVE_DATABASE" ); };

					bool any_ = dataBaseContexto.tempOt.Any ( OT => OT.OT == OT_Number );

					if ( any_ && MessageBox.Show ( $"La orden de trabajo {OT_Number} ya existe,\r\nDesea que la información se modifique?", "OT existente", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2 ) == DialogResult.No ) throw new Exception ( $"Operación cancelada, no se realizó ningun cambio a la OT { OT_Number }" );


					this.EXAPP.StatusBar = $"Guardando informacion de la OT {OT_Number} en el servidor...";
					bool DisponibleConsulta = false;
					short FiguraSalida = 0;

					// Checo si es impreso
					if ( sh.Range[ "A13" ].Text == "True" )
					{
						bool isShort = short.TryParse ( sh.Range[ "A8" ].Value2.ToString ( ), out FiguraSalida );
						if ( isShort && FiguraSalida <= 0 ) throw new Exception ( "No se ha indicado ninguna figura valida" );
						if ( sh.Range[ "A76" ].Text.Trim ( ) == "" ) throw new Exception ( "No se indicó ninguna referencia para la figura de salida" );
					}

					if ( MessageBox.Show ( "La OT Estara disponible para consulta?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes ) DisponibleConsulta = true;

					TemporalOrdenTrabajo ot = new TemporalOrdenTrabajo ( );
					ot.TIPO = (TemporalOrdenTrabajo.Tipos)sh.Range[ "A1" ].Value2;
					ot.FECHARECIBIDO = DateTime.FromOADate ( sh.Range[ "A6" ].Value2 );
					ot.OT = OT_Number;
					ot.FECHAENTREGASOL = DateTime.FromOADate ( sh.Range[ "A7" ].Value2 );
					ot.CLIENTE = sh.Range[ "A11" ].Value2;
					ot.PRODUCTO = sh.Range[ "A44" ].Value2;
					ot.CANTIDAD = (double)sh.Range[ "A19" ].Value2;
					ot.UNIDAD = sh.Range[ "A12" ].Value2;
					ot.ANCHO = (double)sh.Range[ "A32" ].Value2;
					ot.ALTO = (double)sh.Range[ "A33" ].Value2;
					ot.SOLAPA = (double)sh.Range[ "A68" ].Value2;
					ot.FUELLELATERAL = (double)sh.Range[ "A69" ].Value2;
					ot.FUELLEFONDO = (double)sh.Range[ "A70" ].Value2;
					ot.COPETE = (double)sh.Range[ "A71" ].Value2;
					ot.AREASELLOREV = (double)sh.Range[ "A72" ].Value2;
					ot.AREASELLOFONDO = (double)sh.Range[ "A73" ].Value2;
					ot.TIPOIMPRESION = (int)sh.Range[ "A14" ].Value2;
					ot.TIPOTRABAJO = (int)sh.Range[ "A15" ].Value2;
					ot.REPEJE = (double)sh.Range[ "A9" ].Value2;
					ot.REPDES = (double)sh.Range[ "A10" ].Value2;
					ot.MATBASE = sh.Range[ "A26" ].Value2;
					ot.MATBASECALIBRE = (double)sh.Range[ "A23" ].Value2;
					ot.MATBASEKG = (double)sh.Range[ "A29" ].Value2;
					ot.MATLAMINACION = sh.Range[ "A27" ].Value2;
					ot.MATLAMINACIONCALIBRE = (double)sh.Range[ "A24" ].Value2;
					ot.MATLAMINACIONKG = (double)sh.Range[ "A30" ].Value2;
					ot.MATTRILAMINACION = sh.Range[ "A28" ].Value2;
					ot.MATTRILAMINACIONCALIBRE = sh.Range[ "A25" ].Value2;
					ot.MATTRILAMINACIONKG = (double)sh.Range[ "A31" ].Value2;
					ot.CLAVEINTELISIS = sh.Range[ "A3" ].Text.Trim();
					ot.ORDENCOMPRA = sh.Range[ "A4" ].Text;
					ot.IMPRESORA = sh.Range[ "A16" ].Text;
					ot.RODILLO = sh.Range[ "A17" ].Value2;
					ot.FIGURASALIDAFINAL = (int)sh.Range[ "A8" ].Value2;
					ot.INSTCORTE = sh.Range[ "A34" ].Value2;
					ot.INSTDOBLADO = sh.Range[ "A35" ].Value2;
					ot.INSTEMBOBINADO = sh.Range[ "A36" ].Value2;
					ot.INSTEXTRUSION = sh.Range[ "A53" ].Value2;
					ot.INSTIMPRESION = sh.Range[ "A38" ].Value2;
					ot.INSTLAMINACION = sh.Range[ "A39" ].Value2;
					ot.INSTMANGAS = sh.Range[ "A40" ].Value2;
					ot.INSTREFINADO = sh.Range[ "A41" ].Value2;
					ot.INSTSELLADO = sh.Range[ "A42" ].Value2;
					ot.OBSERVACIONES = sh.Range[ "A43" ].Value2;
					ot.ESIMPRESO = sh.Range[ "A13" ].Value2;
					ot.KGXMILL = (double)sh.Range[ "A18" ].Value2;
					ot.MATBASEAMU = (double)sh.Range[ "A20" ].Value2;
					ot.EXTIPO = sh.Range[ "A45" ].Value2;
					ot.EXCOLOR = sh.Range[ "A46" ].Value2;
					ot.EXTRATADO = sh.Range[ "A47" ].Value2;
					ot.EXDINAS = sh.Range[ "A48" ].Value2;
					ot.EXDESLIZ = sh.Range[ "A49" ].Value2;
					ot.EXANTIESTATICA = sh.Range[ "A50" ].Value2;
					ot.MATLAMINACIONAMU = (double)sh.Range[ "A21" ].Value2;
					ot.MATTRILAMINACIONAMU = (double)sh.Range[ "A22" ].Value2;
					ot.EXKG = sh.Range[ "A51" ].Value2;
					ot.EXANCHO = sh.Range[ "A52" ].Value2;
					ot.CLAVEPRODUCTO = "-";
					ot.EMPATES = "";

					dataBaseContexto.tempOt.AddOrUpdate ( o => o.OT, ot );

					TEMPCAPT tc = new TEMPCAPT ( );

					tc.OT = OT_Number;
					tc.DISENIOAUT = sh.Range[ "A54" ].Value2;
					tc.CENTROS = (int)sh.Range[ "A55" ].Value2;
					tc.TINTA = (double)sh.Range[ "A56" ].Value2;
					tc.ADH1 = (double)sh.Range[ "A57" ].Value2;
					tc.ADH2 = (double)sh.Range[ "A58" ].Value2;
					tc.AJUIMP = (double)sh.Range[ "A59" ].Value2;
					tc.LAMIMP = (double)sh.Range[ "A60" ].Value2;
					tc.TRIIMP = (double)sh.Range[ "A61" ].Value2;
					tc.AJULAM = (double)sh.Range[ "A62" ].Value2;
					tc.LAMLAM = (double)sh.Range[ "A63" ].Value2;
					tc.TRILAM = (double)sh.Range[ "A64" ].Value2;
					tc.AJUTRI = (double)sh.Range[ "A65" ].Value2;
					tc.TRITRI = (double)sh.Range[ "A66" ].Value2;
					tc.ESPECIAL = sh.Range[ "X4" ].Value == true ? 1 : 0;
					tc.ESPECIALLAM = sh.Range[ "X3" ].Value == true ? 1 : 0;
					tc.ESPECIALREF = (int)sh.Range[ "X2" ].Value2;
					tc.PORCTOLERANCIA = (double)sh.Range[ "E21" ].Value2;
					tc.ZIPPER = sh.Range[ "F19" ].Value == true ? 1 : 0;
					tc.ADHPERM = sh.Range[ "F20" ].Value == true ? 1 : 0;
					tc.ADHREM = sh.Range[ "F21" ].Value == true ? 1 : 0;
					tc.EX1 = sh.Range[ "I49" ].Value == true ? 1 : 0;
					tc.EX2 = sh.Range[ "I50" ].Value == true ? 1 : 0;
					tc.EX3 = sh.Range[ "I51" ].Value == true ? 1 : 0;
					tc.ML = (int)sh.Range[ "A74" ].Value2;
					tc.ZIPPER_TYPE = (int)sh.Range[ "G18" ].Value2;
					tc.MERMAPROCESO = (double)sh.Range[ "A75" ].Value2;
					tc.ENABLED = DisponibleConsulta ? 1 : 0;
					tc.FechaCaptura = DateTime.Now;
					tc.ReferenciaFigura = sh.Range[ "A76" ].Value2;

					dataBaseContexto.TEMPCAPT.AddOrUpdate ( O => O.OT, tc );
					dataBaseContexto.SaveChanges ( );
				}


				NotifyIcon ntMsg = Globals.ThisAddIn.ntMSG;
				ntMsg.BalloonTipIcon = ToolTipIcon.Info;
				ntMsg.BalloonTipText = "Correcto...";
				ntMsg.BalloonTipTitle = "Ok";
				ntMsg.ShowBalloonTip ( 500 );

				if ( !Properties.Settings.Default.AutomaticSaveBook )
				{
					this.EXAPP.StatusBar = (object)"Guardando Libro...";
					System.Threading.Thread.Sleep ( 1000 );
					this.GuardarLibro ( );
				}

			}
			catch ( Exception ex )
			{

				NotifyIcon ntMsg = Globals.ThisAddIn.ntMSG;
				ntMsg.BalloonTipIcon = ToolTipIcon.Error;
				ntMsg.BalloonTipText = ex.Message;
				ntMsg.BalloonTipTitle = "Error";
				ntMsg.ShowBalloonTip ( 500 );
			}
			finally
			{
				this.EXAPP.StatusBar = null;
			}
		}
		private void btnBuscar_Click ( object sender, RibbonControlEventArgs e )
		{
			try
			{
				if ( this.EXAPP.Range[ "A2" ].Value != "captura pedidos2" ) throw new Exception ( "El libro y la hoja que desea usar no corresponde al archivo relacionado con el Complemento" );
				if ( MessageBox.Show ( "Realmente desea Buscar una OT?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
					return;
				this.Limpiar ( );

				var Local_Ot = Interaction.InputBox ( "Ingrese la OT a Buscar...", "Buscar...", "", -1, -1 );
				if ( Local_Ot.Trim ( ) == "" ) throw new Exception ( "No se indicó ninguna orden" );

				using ( DataBaseContexto Db = new DataBaseContexto ( ) )
				{
					if ( !Db.TEMPCAPT.Any ( c => c.OT == Local_Ot.Trim ( ) ) ) throw new Exception ( "La orden no exite" );
					this.EXAPP.ScreenUpdating = false;
					Microsoft.Office.Interop.Excel.Worksheet sw = this.EXAPP.ActiveWorkbook.ActiveSheet;

					var temp = Db.TEMPCAPT.FirstOrDefault ( c => c.OT == Local_Ot.Trim ( ) );
					var ordenTrabajo = temp.OrdenTrabajo;



					sw.Range[ "C1" ].Value = getNameTipo ( (int)ordenTrabajo.TIPO );//System.Text.RegularExpressions.Regex.Replace ( ordenTrabajo.TIPO.ToString ( ), "[A-Z]", " $0" ).TrimStart().TrimEnd().ToUpper();//Regex.Replace( ordenTrabajo.TIPO.ToString ( ), "");
					sw.Range[ "C2" ].Value = Local_Ot; sw.Range[ "C4" ].Value = ordenTrabajo.CLIENTE;
					sw.Range[ "C5" ].Value = ordenTrabajo.PRODUCTO;
					sw.Range[ "C3" ].Value = ordenTrabajo.FECHARECIBIDO;
					sw.Range[ "F1" ].Value = ordenTrabajo.ORDENCOMPRA;
					sw.Range[ "F2" ].Value = ordenTrabajo.CLAVEINTELISIS;
					sw.Range[ "F3" ].Value = ordenTrabajo.FECHAENTREGASOL;
					sw.Range[ "C7" ].Value = ordenTrabajo.FIGURASALIDAFINAL;
					sw.Range[ "C8" ].Value = ordenTrabajo.ALTO;
					sw.Range[ "C9" ].Value = ordenTrabajo.SOLAPA;
					sw.Range[ "C10" ].Value = ordenTrabajo.FUELLELATERAL;
					sw.Range[ "C11" ].Value = ordenTrabajo.FUELLEFONDO;
					sw.Range[ "C12" ].Value = ordenTrabajo.COPETE;
					sw.Range[ "C13" ].Value = ordenTrabajo.AREASELLOREV;
					sw.Range[ "C14" ].Value = ordenTrabajo.AREASELLOFONDO;
					sw.Range[ "F8" ].Value = ordenTrabajo.ANCHO;
					sw.Range[ "F9" ].Value = (int)ordenTrabajo.REPEJE;
					sw.Range[ "F10" ].Value = (int)ordenTrabajo.REPDES;
					sw.Range[ "C16" ].Value = this.getNameTipoImpresion ( ordenTrabajo.TIPOIMPRESION );
					sw.Range[ "C17" ].Value = this.getNameTipoTrabajo ( ordenTrabajo.TIPOTRABAJO );
					sw.Range[ "F16" ].Value = ordenTrabajo.IMPRESORA;
					sw.Range[ "F17" ].Value = Math.Round ( ordenTrabajo.RODILLO, 2 );
					sw.Range[ "C19" ].Value = ordenTrabajo.CANTIDAD;
					sw.Range[ "C20" ].Value = ordenTrabajo.UNIDAD;

					// split MATBASE
					var MatBaseArr = ordenTrabajo.MATBASE.Split ( '_' );

					sw.Range[ "C26" ].Value = ordenTrabajo.MATBASE.Trim ( ) != "" ? MatBaseArr[ 0 ] : "NINGUNO";
					sw.Range[ "C25" ].Value = sw.Range[ "C26" ].Value == "PEBD" || sw.Range[ "C26" ].Value == "PEHD" ? ordenTrabajo.MATBASECALIBRE / 4.0 : ordenTrabajo.MATBASECALIBRE;
					sw.Range[ "C27" ].Value = MatBaseArr.Length > 1 ? MatBaseArr[ 1 ] : "";
					sw.Range[ "C28" ].Value = ordenTrabajo.MATBASEAMU.ToString ( "0.00" );

					// split MATLAMINACION
					var MatLamArr = ordenTrabajo.MATLAMINACION.Split ( '_' );
					sw.Range[ "F26" ].Value = ordenTrabajo.MATLAMINACION.Trim ( ) != "" ? MatLamArr[ 0 ] : "NINGUNO";
					sw.Range[ "F25" ].Value = sw.Range[ "F26" ].Value == "PEBD" || sw.Range[ "F26" ].Value == "PEHD" ? ordenTrabajo.MATLAMINACIONCALIBRE / 4.0 : ordenTrabajo.MATLAMINACIONCALIBRE;
					sw.Range[ "F27" ].Value = MatLamArr.Length > 1 ? MatLamArr[ 1 ] : "";
					sw.Range[ "F28" ].Value = ordenTrabajo.MATLAMINACIONAMU.ToString ( "0.00" );

					// split MATTRILAMINACION
					var MatTLamArr = ordenTrabajo.MATTRILAMINACION.Split ( '_' );
					sw.Range[ "H26" ].Value = ordenTrabajo.MATTRILAMINACION.Trim ( ) != "" ? MatTLamArr[ 0 ] : "NINGUNO";
					sw.Range[ "H25" ].Value = sw.Range[ "H26" ].Value == "PEBD" || sw.Range[ "H26" ].Value == "PEHD" ? ordenTrabajo.MATTRILAMINACIONCALIBRE / 4.0 : ordenTrabajo.MATTRILAMINACIONCALIBRE;
					sw.Range[ "H27" ].Value = MatTLamArr.Length > 1 ? MatTLamArr[ 1 ] : "";
					sw.Range[ "H28" ].Value = ordenTrabajo.MATTRILAMINACIONAMU.ToString ( "0.00" );


					sw.Range[ "K25" ].Value = ordenTrabajo.OBSERVACIONES;

					sw.Range[ "Q2" ].Value = ordenTrabajo.INSTIMPRESION.Split ( '_' ).Length > 1 ? ordenTrabajo.INSTIMPRESION.Split ( '_' )[ 1 ] : ".";
					sw.Range[ "Q4" ].Value = ordenTrabajo.INSTLAMINACION.Split ( '_' ).Length > 1 ? ordenTrabajo.INSTLAMINACION.Split ( '_' )[ 1 ] : ".";
					sw.Range[ "Q6" ].Value = ordenTrabajo.INSTREFINADO.Split ( '_' ).Length > 1 ? ordenTrabajo.INSTREFINADO.Split ( '_' )[ 1 ] : ".";


					sw.Range[ "I8" ].Value = ordenTrabajo.INSTDOBLADO;
					sw.Range[ "I10" ].Value = ordenTrabajo.INSTCORTE;
					sw.Range[ "I12" ].Value = ordenTrabajo.INSTEMBOBINADO;
					sw.Range[ "I14" ].Value = ordenTrabajo.INSTMANGAS;
					sw.Range[ "I16" ].Value = ordenTrabajo.INSTSELLADO;
					sw.Range[ "J35" ].Value = ordenTrabajo.EXTIPO;
					sw.Range[ "J36" ].Value = ordenTrabajo.EXCOLOR;
					sw.Range[ "J37" ].Value = ordenTrabajo.EXTRATADO;
					sw.Range[ "J38" ].Value = ordenTrabajo.EXDINAS;
					sw.Range[ "J39" ].Value = ordenTrabajo.EXDESLIZ;
					sw.Range[ "J40" ].Value = ordenTrabajo.EXANTIESTATICA;
					sw.Range[ "J41" ].Value = ordenTrabajo.EXKG;
					sw.Range[ "J42" ].Value = ordenTrabajo.EXANCHO;
					sw.Range[ "J43" ].Value = ordenTrabajo.INSTEXTRUSION;



					sw.Range[ "C6" ].Value = temp.DISENIOAUT;
					sw.Range[ "F11" ].Value = temp.CENTROS;
					sw.Range[ "D29" ].Value = temp.TINTA.ToString ( "0.00000" );
					sw.Range[ "E29" ].Value = temp.ADH1.ToString ( "0.00000" );
					sw.Range[ "G29" ].Value = temp.ADH2.ToString ( "0.00000" );
					sw.Range[ "C36" ].Value = temp.AJUIMP.ToString ( "0.00000" );
					sw.Range[ "C37" ].Value = temp.LAMIMP.ToString ( "0.00000" );
					sw.Range[ "C38" ].Value = temp.TRIIMP.ToString ( "0.00000" );
					sw.Range[ "C39" ].Value = temp.MERMAPROCESO.ToString ( "0.00000" );
					sw.Range[ "D36" ].Value = temp.AJULAM.ToString ( "0.00000" );
					sw.Range[ "D37" ].Value = temp.LAMLAM.ToString ( "0.00000" );
					sw.Range[ "D38" ].Value = temp.TRILAM.ToString ( "0.00000" );
					sw.Range[ "E36" ].Value = temp.AJUTRI.ToString ( "0.00000" );
					sw.Range[ "E38" ].Value = temp.TRITRI.ToString ( "0.00000" );
					sw.Range[ "X4" ].Value = temp.ESPECIAL != 0 ? true : false ;
					sw.Range[ "X3" ].Value = temp.ESPECIALLAM != 0 ? true : false;

					sw.Range[ "X2" ].Value = temp.ESPECIALREF;
					sw.Range[ "F19" ].Value = temp.ZIPPER != 0 ? true : false;
					sw.Range[ "F20" ].Value = temp.ADHPERM != 0 ? true : false;
					sw.Range[ "F21" ].Value = temp.ADHREM != 0 ? true : false;
					sw.Range[ "E21" ].Value = temp.PORCTOLERANCIA.ToString ( "0.00000" );
					sw.Range[ "I49" ].Value = temp.EX1 != 0 ? true : false;
					sw.Range[ "I50" ].Value = temp.EX2 != 0 ? true : false;
					sw.Range[ "I51" ].Value = temp.EX3 != 0 ? true : false;
					sw.Range[ "G18" ].Value = temp.ZIPPER_TYPE.ToString ( "0" );
					sw.Range[ "E7" ].Value = temp.ReferenciaFigura != null ? temp.ReferenciaFigura : "";
				}



			}
			catch ( Exception ex )
			{
				NotifyIcon ntMsg = Globals.ThisAddIn.ntMSG;
				ntMsg.BalloonTipIcon = ToolTipIcon.Error;
				ntMsg.BalloonTipText = ex.Message;
				ntMsg.BalloonTipTitle = "Error";
				ntMsg.ShowBalloonTip ( 500 );
			}
			finally
			{
				this.EXAPP.ScreenUpdating = true;
			}
		}
		private string getNameTipo ( int i )
		{
			string str;
			switch ( i )
			{
				case 0:
					str = "PELICULA";
					break;
				case 1:
					str = "PELICULA LAMINADA";
					break;
				case 2:
					str = "PELICULA TRILAMINADA";
					break;
				case 3:
					str = "FLOWPACK LAMINADA";
					break;
				case 4:
					str = "FLOWPACK TRILAMINADA";
					break;
				case 5:
					str = "SELLO LATERAL NO IMPRESA";
					break;
				case 6:
					str = "SELLO LATERAL IMPRESA";
					break;
				case 7:
					str = "SELLO LATERAL LAMINADA NO IMPRESA";
					break;
				case 8:
					str = "SELLO LATERAL LAMINADA IMPRESA";
					break;
				case 9:
					str = "SELLO LATERAL TRILAMINADA";
					break;
				case 11:
					str = "ETIQUETA";
					break;
				case 12:
					str = "PVC";
					break;
				case 13:
					str = "PROTOTIPOS";
					break;
				case 14:
					str = "PIEZAS";
					break;
				case 15:
					str = "ETIQUETA TIPO MANGA";
					break;
				case 16:
					str = "BOLSA TUBULAR";
					break;
				default:
					str = "PELICULA";
					break;
			}
			return str;
		}
		private string getNameTipoImpresion ( int i )
		{
			switch ( i )
			{
				case 1:
					return "PIE";
				case 2:
					return "CABEZA";
				case 3:
					return "POR DENTRO";
				case 4:
					return "POR FUERA";
				case 5:
					return "REPETICION";
				case 6:
					return "PIE DE IMPRESIÓN";
				default:
					return "POR DENTRO";
			}
		}
		private string getNameTipoTrabajo ( int i )
		{
			switch ( i )
			{
				case 3:
					return "REPETIDO";
				case 4:
					return "NUEVO";
				default:
					return "REPETIDO";
			}
		}
		private void Limpiar ()
		{
			try
			{
				Microsoft.Office.Interop.Excel.Worksheet sw = this.EXAPP.ActiveWorkbook.ActiveSheet;
				this.EXAPP.ScreenUpdating = false;
				sw.Range[ "C1" ].Value = "PELICULA";
				sw.Range[ "C2" ].Value = "";
				sw.Range[ "C4" ].Value = "";
				sw.Range[ "C5" ].Value = "";
				sw.Range[ "C3" ].Value = DateTime.Now.Date;
				sw.Range[ "C7" ].Value = "";
				sw.Range[ "F1" ].Value = "";
				sw.Range[ "F2" ].Value = "";
				sw.Range[ "F3" ].Value = DateTime.Now.Date;
				sw.Range[ "C8" ].Value = 0;
				sw.Range[ "C9" ].Value = 0;
				sw.Range[ "C10" ].Value = 0;
				sw.Range[ "C11" ].Value = 0;
				sw.Range[ "C12" ].Value = 0;
				sw.Range[ "C13" ].Value = 0;
				sw.Range[ "C14" ].Value = 0;
				sw.Range[ "F8" ].Value = 0;
				sw.Range[ "F9" ].Value = 1;
				sw.Range[ "F10" ].Value = 1;
				sw.Range[ "C16" ].Value = this.getNameTipoImpresion ( 3 );
				sw.Range[ "C17" ].Value = this.getNameTipoTrabajo ( 3 );
				sw.Range[ "F16" ].Value = "";
				sw.Range[ "F17" ].Value = "";
				sw.Range[ "C19" ].Value = 0;
				sw.Range[ "C20" ].Value = "KG";
				sw.Range[ "C26" ].Value = "NINGUNO";
				sw.Range[ "C25" ].Value = 0;
				sw.Range[ "C27" ].Value = "";
				sw.Range[ "C28" ].Value = 0;
				sw.Range[ "F26" ].Value = "NINGUNO";
				sw.Range[ "F25" ].Value = 0;
				sw.Range[ "F27" ].Value = "";
				sw.Range[ "F28" ].Value = 0;
				sw.Range[ "H26" ].Value = "NINGUNO";
				sw.Range[ "H25" ].Value = 0;
				sw.Range[ "H27" ].Value = "";
				sw.Range[ "H28" ].Value = 0;
				sw.Range[ "K25" ].Value = "";
				sw.Range[ "Q2" ].Value = ".";
				sw.Range[ "Q4" ].Value = ".";
				sw.Range[ "Q6" ].Value = ".";
				sw.Range[ "I8" ].Value = "";
				sw.Range[ "I10" ].Value = "";
				sw.Range[ "I12" ].Value = "";
				sw.Range[ "I14" ].Value = "";
				sw.Range[ "I16" ].Value = "";
				sw.Range[ "J35" ].Value = "";
				sw.Range[ "J36" ].Value = "";
				sw.Range[ "J37" ].Value = "";
				sw.Range[ "J38" ].Value = "";
				sw.Range[ "J39" ].Value = "";
				sw.Range[ "J40" ].Value = "";
				sw.Range[ "J41" ].Value = "";
				sw.Range[ "J42" ].Value = "";
				sw.Range[ "J43" ].Value = "";
				sw.Range[ "C6" ].Value = "";
				sw.Range[ "F11" ].Value = "3";
				sw.Range[ "D29" ].Value = 0;
				sw.Range[ "E29" ].Value = 0;
				sw.Range[ "G29" ].Value = 0;
				sw.Range[ "C36" ].Value = 0;
				sw.Range[ "C37" ].Value = 0;
				sw.Range[ "C38" ].Value = 0;
				sw.Range[ "C39" ].Value = 0;
				sw.Range[ "D36" ].Value = 0;
				sw.Range[ "D37" ].Value = 0;
				sw.Range[ "D38" ].Value = 0;
				sw.Range[ "E36" ].Value = 0;
				sw.Range[ "E38" ].Value = 0;
				sw.Range[ "X4" ].Value = false;
				sw.Range[ "X3" ].Value = false;
				sw.Range[ "X2" ].Value = 4;
				sw.Range[ "F19" ].Value = false;
				sw.Range[ "F20" ].Value = false;
				sw.Range[ "F21" ].Value = false;
				sw.Range[ "E21" ].Value = 0.06;
				sw.Range[ "E7" ].Value = "";
				sw.Range[ "I49" ].Value = false;
				sw.Range[ "I50" ].Value = false;
				sw.Range[ "I51" ].Value = false;
				sw.Range[ "G18" ].Value = 1;
			}
			catch ( Exception ex )
			{
				System.Diagnostics.Debug.WriteLine ( ex.Message, "LimpiarHoja" );
			}
			finally
			{
				this.EXAPP.ScreenUpdating = true;
			}
		}
		private void GuardarLibro ()
		{
			Microsoft.Office.Interop.Excel.Worksheet sh = this.EXAPP.ActiveWorkbook.ActiveSheet;


			string Version = DateTime.Now.ToString ( "yyyy" );

			if ( sh.Range[ "A2" ].Text == "captura pedidos2" )
			{
				try
				{
					if ( sh.Range[ "A5" ].Text.Trim ( ) == "" )
						throw new Exception ( "No se ha escrito ninguna OT" );
					string str1 = sh.Range[ "C5" ].Text.Length > 50 ? sh.Range[ "C5" ].Text.Substring ( 0, 50 ) : sh.Range[ "C5" ].Text;
					string directory = Path.Combine ( this.EXAPP.ActiveWorkbook.Path, Version );
					string str2 = Path.Combine ( directory, ( sh.Range[ "A5" ].Text + "_" + str1 + string.Format ( "_{0:ddMMyyyy}", DateTime.Now ) + "_.xlsx" ).Replace ( ",", "" ).Replace ( "-", "" ).Replace ( "/", "_" ).Replace ( "'", "" ).Replace ( "\\", "_" ).Replace ( "*", "" ).Replace ( " ", "_" ) );
					this.EXAPP.StatusBar = (object)str2.ToString ( );

					System.IO.Directory.CreateDirectory ( directory );
					this.EXAPP.ActiveWorkbook.SaveCopyAs ( str2 );
					Globals.ThisAddIn.ntMSG.ShowBalloonTip ( 500, "Se guardo el libro como...", str2.ToString ( ), ToolTipIcon.Info );
				}
				catch ( Exception ex )
				{
					Globals.ThisAddIn.ntMSG.ShowBalloonTip ( 500, "Error..", ex.Message, ToolTipIcon.Error );
				}
				finally
				{
					this.EXAPP.StatusBar = null;
				}
			}
			else
			{
				Globals.ThisAddIn.ntMSG.ShowBalloonTip ( 500, "Error..", "El libro y la hoja que desea usar no corresponde al archivo relacionado con el Complemento", ToolTipIcon.Error );
			}
		}


	}

}
