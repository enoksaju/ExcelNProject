

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using libProduccionDataBase.Tablas;
using libBascula;
using ComponentFactory.Krypton.Toolkit;
using libControlesPersonalizados;
using libProduccionDataBase.Contexto;
using Z.EntityFramework.Plus;
using System.Data.Entity.Infrastructure;

namespace EstacionPesaje.Pages.MainPages {
	public partial class ProduccionPage : Base.DocumentPageBase, Base.IUsaBascula {

		private int _AcumuladoBajada = 0;
		private int AcumuladoBajada {
			get {
				return _AcumuladoBajada;
			}
			set {
				_AcumuladoBajada = ( _AcumuladoBajada < int.Parse ( repEje_txt.Text ) ? value : 0 );
			}
		}
		private string OT;
		private KryptonTaskDialog td = new KryptonTaskDialog ( ) {
			CommonButtons = TaskDialogButtons.Yes | TaskDialogButtons.No ,
			DefaultButton = TaskDialogButtons.No ,
			Icon = MessageBoxIcon.Question ,
			Content = "" ,
			WindowTitle = "Confirmación de Captura" ,
			MainInstruction = "Continuar?"

		};
		private InformacionInicialCaptura valuesCaptura;
		public ControlBascula Bascula { get; set; }



		public ProduccionPage ( string OT , libBascula.ControlBascula Bascula_ ) {

			InitializeComponent ( );
			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder );

			DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );
			//DB.Configuration.LazyLoadingEnabled = false;
			//DB.Database.Log = Console.Write;


			if ( !DB.tempOt.Any ( o => o.OT == OT.Trim ( ) ) )
				throw new Exception ( "No existe la orden solicitada" );

			this.OT = OT;
			this.PageTitleText = String.Format ( "Produccion[{0}]" , this.OT );
			KP.ImageSmall = Properties.Resources.worker1;

			DB.tempOt.Where ( o => o.OT == OT.Trim ( ) ).Load ( );

			temporalOrdenTrabajoBindingSource.DataSource = DB.tempOt.Local.ToBindingList ( );

			this.Bascula = Bascula_;
			this.Bascula.CambioValor += Bascula_CambioValor;
			this.Bascula.CambioEstado += Bascula_CambioEstado;

			setEnableStatusBascula ( this.Bascula.Estatus == EstadoConexion.Conectado ? true : false );

			kryptonNavigator1.SelectedPage = kryptonPageInstrucciones;


		}


		private async void ProduccionPage_Load ( object sender , EventArgs e ) {
			await DB.Procesos.LoadAsync ( );
			procesoBindingSource.DataSource = DB.Procesos.Local.ToBindingList ( );
			ProcesosFilterToolBar.ComboBox.DataSource = procesoBindingSource;
			ProcesosFilterToolBar.ComboBox.DisplayMember = "NombreProceso";
			ProcesosFilterToolBar.ComboBox.ValueMember = "ID";
		}
		protected override void Dispose ( bool disposing ) {
			if ( disposing && ( components != null ) ) {

				Bascula.CambioValor -= Bascula_CambioValor;
				this.Bascula.CambioEstado -= Bascula_CambioEstado;
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}


		/// <summary>
		/// Controla las acciones de cambio de pestaña
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void kryptonNavigator1_Selecting ( object sender , ComponentFactory.Krypton.Navigator.KryptonPageCancelEventArgs e ) {

			if ( e.Item == kryptonPageCaptura ) {

				var frm = new IniciarCaptura_frm ( );

				if ( frm.ShowDialog ( ) == DialogResult.OK ) {
					valuesCaptura = frm.response;

					OperadorLabel.Text = valuesCaptura.Operador;
					TurnoLabel.Text = ( valuesCaptura.Turno == 1 ? "Primero" : ( valuesCaptura.Turno == 2 ? "Segundo" : ( valuesCaptura.Turno == 3 ? "Tercero" : "Mixto" ) ) );
					MaquinaLabel.Text = valuesCaptura.Maquina.NombreMaquina;
					ProcesoLabel.Text = valuesCaptura.Proceso.NombreProceso;

					var t = from produccion in DB.TempProduccion
							where produccion.OT == this.OT && produccion.TIPOPROCESO == valuesCaptura.Proceso.ID
							orderby produccion.NUMERO descending
							select new { produccion.NUMERO , produccion.PESOCORE , produccion.USUARIO , produccion.EXTRUSION_ID };

					var myNumber = t.Where ( u => u.USUARIO == Environment.MachineName ).OrderByDescending ( i => i.NUMERO ).FirstOrDefault ( );

					var num = ( myNumber != null ? myNumber.NUMERO : ( t.FirstOrDefault ( ) != null ? t.FirstOrDefault ( ).NUMERO : 0 ) );
					var PesoCore = ( myNumber != null ? myNumber.PESOCORE : ( t.FirstOrDefault ( ) != null ? t.FirstOrDefault ( ).PESOCORE : 0 ) );

					nUMEROKryptonTextBox.Value = num + 1;
					pESOCOREKryptonTextBox.Value = ( decimal ) PesoCore;
					idExtrusion_txt.Text = valuesCaptura.Proceso.ID == 9 ? ( myNumber != null ? myNumber.EXTRUSION_ID : "1A" ) : "";

					Optional1_rdbtn.Text = valuesCaptura.Options.Optional1;
					Optional2_rdbtn.Text = valuesCaptura.Options.Optional2;
					Optional3_rdbtn.Text = valuesCaptura.Options.Optional3;
					Optional4_rdbtn.Text = valuesCaptura.Options.Optional4;
					Optional5_rdbtn.Text = valuesCaptura.Options.Optional5;
					Extrusion_Panel.Visible = valuesCaptura.Proceso.ID == 9 ? true : false;

					this.PageTitleText = $"Captura [{this.OT}] [{valuesCaptura.Proceso.NombreProceso}] ";

				} else {
					e.Cancel = true;
				}

				frm.Dispose ( );

			} else if ( e.Item == kryptonPageLista ) {
				RefreshListItems ( );
			} else {
				this.PageTitleText = String.Format ( "Produccion[{0}]" , this.OT );
			}

		}
		
		/// <summary>
		/// Retorna el ItemOptional seleccionado
		/// </summary>
		/// <returns></returns>
		private int GetItemSelected ( ) {
			if ( Optional1_rdbtn.Checked ) {
				return 1;
			} else if ( Optional2_rdbtn.Checked ) {
				return 2;
			} else if ( Optional3_rdbtn.Checked ) {
				return 3;
			} else if ( Optional4_rdbtn.Checked ) {
				return 4;
			} else if ( Optional5_rdbtn.Checked ) {
				return 5;
			} else {
				return 1;
			}
		}

		/// <summary>
		/// Guarda e imprime la informacion de la captura
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void kryptonButton1_Click ( object sender , EventArgs e ) {
			try {
				td.Content = "Realmente desea Imprimir y guardar?";
				if ( td.ShowDialog ( ) == DialogResult.No )
					return;

				if ( Properties.Settings.Default.enabledImpresionMultiple ) {
					ProgressBar.Visible = true;
					ProgressBar.Maximum = ( int ) multipleQuantity_num.Value;


					for ( int i = 1; i <= ( int ) multipleQuantity_num.Value; i++ ) {
						try {
							var t = SaveCapturaProduccion ( );
							this.replaceAndPrintZPLProduccion1.PrintZPL ( valuesCaptura.Etiqueta.ZPLCode , t , valuesCaptura.Options ); // TODO: faltan Acciones par impresion de etquetas de Extrusion
						} catch { } finally {
							ProgressBar.Value = i;
						}
					}

					ProgressBar.Visible = false;

				} else {
					var t = SaveCapturaProduccion ( );
					this.replaceAndPrintZPLProduccion1.PrintZPL ( valuesCaptura.Etiqueta.ZPLCode , t , valuesCaptura.Options );
				}

			} catch ( Exception ex ) {
				HandledException ( new Exception ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB , ex ) ) );
			}

		}

		/// <summary>
		/// Guarda la informacion de la captura en la BD y no imprime ninguna etiqueta
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void kryptonButton2_Click ( object sender , EventArgs e ) {

			try {
				td.Content = "Realmente desea solo guardar?";
				if ( td.ShowDialog ( ) == DialogResult.No )
					return;

				if ( Properties.Settings.Default.enabledImpresionMultiple ) {
					ProgressBar.Visible = true;
					ProgressBar.Maximum = ( int ) multipleQuantity_num.Value;

					for ( int i = 1; i <= ( int ) multipleQuantity_num.Value; i++ ) {
						try {
							var t = SaveCapturaProduccion ( );
						} catch { } finally {
							ProgressBar.Value = i;
						}
					}

					ProgressBar.Visible = false;
				} else {
					var t = SaveCapturaProduccion ( );
				}
			} catch ( Exception ex ) {
				System.Diagnostics.Debug.WriteLine ( $"Tipo: {ex.GetType ( ).Name} => Message:{ex.Message }" );
				HandledException ( new Exception ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB , ex ) ) );
			}
		}


		/// <summary>
		/// Procedimiento de almacenamiento de la captura en la Base de datos.
		/// </summary>
		/// <returns></returns>
		private TempProduccion SaveCapturaProduccion ( ) {

			TempProduccion ToRet = null;

			using ( var DBLocal = new DataBaseContexto ( ) ) {

				if ( valuesCaptura.Proceso.ID == 9 && idExtrusion_txt.Text.Trim ( ) != string.Empty ) {

					if ( valuesCaptura.Proceso.ID == 9 && !System.Text.RegularExpressions.Regex.IsMatch ( idExtrusion_txt.Text.Trim ( ) , @"^[0-9]+([A-Z]{1})$" ) )
						throw new Exception ( $"El Id de extrusión debe tener el siguiente formato:\n\t[numero de bajada][letra de la bajada] => '1A'" );

					if ( valuesCaptura.Proceso.ID == 9 &&
						DBLocal.TempProduccion.Any (
							o =>
							o.EXTRUSION_ID == idExtrusion_txt.Text &&
							o.OT == this.OT
							) )
						throw new Exception ( $"El Id de Extrusion {idExtrusion_txt.Text} ya esta siendo usado o es incorrecto" );

				} else if ( valuesCaptura.Proceso.ID == 9 && idExtrusion_txt.Text.Trim ( ) == string.Empty ) {
					if ( KryptonTaskDialog.Show ( "Extrusion Id" , "Confirme" , "El Id de Extrusion se encuentra vacio, desea continuar?" , MessageBoxIcon.Question , TaskDialogButtons.Yes | TaskDialogButtons.No ) == DialogResult.No )
						throw new Exception ( "Operación Cancelada" );
				}



				var t = new TempProduccion ( ) {
					BANDERAS = ( int ) bANDERASKryptonTextBox.Value ,
					OT = this.OT ,

					MAQUINA = valuesCaptura.Maquina.Id ,
					TIPOPROCESO = valuesCaptura.Proceso.ID ,

					PESOBRUTO = ( double ) pESOBRUTOKryptonTextBox.Value ,
					PESOCORE = ( double ) pESOCOREKryptonTextBox.Value ,
					NUMERO = ( int ) nUMEROKryptonTextBox.Value ,
					PIEZAS = ( int ) pIEZASKryptonTextBox.Value ,
					TURNO = valuesCaptura.Turno ,
					ORIGEN = oRIGENKryptonTextBox.Text ,
					FECHA = DateTime.Now ,
					OPERADOR = valuesCaptura.Operador ,
					REPETICION = GetItemSelected ( ) ,
					USUARIO = Environment.MachineName ,
					INDICE = this.OT + "-" + valuesCaptura.Proceso.ID + "-" + ( int ) nUMEROKryptonTextBox.Value ,
					ENSANEO = ( short ) ( saneo_chk.Checked ? -1 : 0 ) ,
					FUEEDITADA = 0 ,
					FUESANEADA = 0 ,
					ESRECHAZADA = 0 ,
					EXTRUSION_ID = ( valuesCaptura.Proceso.ID == 9 ? idExtrusion_txt.Text : "" )
				};

				DBLocal.TempProduccion.Add ( t );
				DBLocal.SaveChanges ( );
				nUMEROKryptonTextBox.Value += 1;

				ToRet = DB.TempProduccion.Include ( r => r.Maquina_ )
					.Include ( r => r.Proceso_ )
					.Where ( r => r.Id == t.Id )
					.FirstOrDefault ( );

				saneo_chk.Checked = false;

				if ( valuesCaptura.Proceso.ID == 3 ) {
					++AcumuladoBajada;
					bajadaActual_txt.Text = ( AcumuladoBajada ).ToString ( );

					if ( AcumuladoBajada == 0 ) {
						var org = oRIGENKryptonTextBox.Text.Split ( ( oRIGENKryptonTextBox.Text.Contains ( '-' ) ? '-' : ( oRIGENKryptonTextBox.Text.Contains ( '.' ) ? '.' : ' ' ) ) );
						oRIGENKryptonTextBox.Text = ( org.Count ( ) >= 2 ? org [ 1 ] : org [ 0 ] );
						bANDERASKryptonTextBox.Value = 0;
					}
				} else {
					bANDERASKryptonTextBox.Value = 0;
				}
			}

			return ToRet;
		}

		/// <summary>
		/// guarda los cambios del datagirdview en la base de datos
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripButton1_Click ( object sender , EventArgs e ) {
			try {
				td.Content = "Realmente desea guardar?";
				if ( td.ShowDialog ( ) == DialogResult.No )
					return;

				foreach ( var t in DB.TempProduccion.Local.ToList ( ) ) {
					if ( t.OrdenTrabajo == null ) {
						DB.TempProduccion.Remove ( t );
					}

					if ( t.TIPOPROCESO == 9 && t.EXTRUSION_ID != string.Empty && DB.TempProduccion.Local.Any ( o => o.EXTRUSION_ID == t.EXTRUSION_ID && o.OT == t.OT && o.Id != t.Id ) ) {
						throw new Exception ( "Existe algun id de extrusion duplicado, no se pueden guardar los cambio" );
					}
				}

				DB.SaveChanges ( );
			} catch ( Exception ex ) {

				HandledException ( new Exception ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB , ex ) ) );
			} finally {
				DB.Entry ( temporalOrdenTrabajoBindingSource.Current ).Reload ( );
				temporalOrdenTrabajoBindingSource.ResetBindings ( false );
				produccionBindingSource.ResetBindings ( false );
				produccionKryptonDataGridView.Refresh ( );
			}
		}

		/// <summary>
		/// Imprime los elementos seleccionados en el DataGridView
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void toolStripButton2_Click ( object sender , EventArgs e ) {

			var frm = new IniciarCaptura_frm ( );
			frm.InfoCapturaLayout.Visible = false;

			if ( frm.ShowDialog ( ) == DialogResult.OK ) {

				foreach ( DataGridViewRow rw in produccionKryptonDataGridView.SelectedRows ) {

					try {

						var y = await DB.TempProduccion.Include ( r => r.Maquina_ ).Include ( r => r.Proceso_ ).Where ( r => r.Id == ( ( TempProduccion ) rw.DataBoundItem ).Id ).FirstOrDefaultAsync ( );
						this.replaceAndPrintZPLProduccion1.PrintZPL ( frm.response.Etiqueta.ZPLCode , y , frm.response.Options );
					} catch ( Exception ex ) {
						HandledException ( new Exception ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB , ex ) ) );
					}

				}
			}
			frm.Dispose ( );
		}

		private bool CoreEditing = false;
		private void pESOCOREKryptonTextBox_Enter ( object sender , EventArgs e ) {
			CoreEditing = true;
		}
		private void pESOCOREKryptonTextBox_Leave ( object sender , EventArgs e ) {
			CoreEditing = false;
		}
		private void pESOBRUTOKryptonTextBox_ValueChanged ( object sender , EventArgs e ) {
			PesoNetokryptonNumericUpDown.Value = pESOBRUTOKryptonTextBox.Value - pESOCOREKryptonTextBox.Value;
		}

		#region Bascula

		/// <summary>
		/// Controla lo que sucede cuando el estado de la bascula cambia.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void Bascula_CambioEstado ( object sender , EstadoConexion e ) {

			await Task.Run ( ( ) => {
				setEnableStatusBascula ( e == EstadoConexion.Conectado ? true : false );
			} );
		}


		/// <summary>
		/// Deshabilita el TextBox del peso Bruto si la bascula se encuentra conectada
		/// </summary>
		/// <param name="Value"></param>
		private void setEnableStatusBascula ( bool Value ) {

			if ( this.InvokeRequired ) {
				this.Invoke ( new Action<bool> ( setEnableStatusBascula ) , Value );
				return;
			}

			pESOBRUTOKryptonTextBox.Enabled = !Value;
		}

		/// <summary>
		/// Controla lo que sucede cuando el valor de la bascula cambia
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void Bascula_CambioValor ( object sender , CambioValorEventArgs e ) {
			await Task.Run ( ( ) => {
				try {
					if ( !CoreEditing )
						setValuePesoBruto ( e.NuevoValor );
				} catch ( Exception EX ) {
					Console.WriteLine ( EX );
				}

			} );
		}

		/// <summary>
		/// Asigna el valor del peso bruto al Textbox
		/// </summary>
		/// <param name="Value"></param>
		private void setValuePesoBruto ( double Value ) {
			if ( pESOBRUTOKryptonTextBox.InvokeRequired ) {
				pESOBRUTOKryptonTextBox.Invoke ( new Action<double> ( setValuePesoBruto ) , Value );
				return;
			}
			pESOBRUTOKryptonTextBox.Value = ( decimal ) Value;
		}

		#endregion


		public class InformacionInicialCaptura {
			public string Operador { get; set; } = "";
			public Maquina Maquina { get; set; } = null;
			public int Turno { get; set; } = 0;
			public Etiqueta Etiqueta { get; set; } = null;
			public Proceso Proceso { get; set; } = null;
			public Optionals Options { get; set; } = new Optionals ( );

		}

		private void produccionKryptonDataGridView_SelectionChanged ( object sender , EventArgs e ) {
			try {

				List<TempProduccion> t = ( from DataGridViewRow rw in produccionKryptonDataGridView.SelectedRows
										   select ( TempProduccion ) rw.DataBoundItem ).ToList ( );

				PB_lbl.Text = String.Format ( "{0:0.00}" , t.Sum ( u => u.PESOBRUTO ) );
				PN_lbl.Text = String.Format ( "{0:0.00}" , t.Sum ( u => u.PESONETO ) );
				PZ_lbl.Text = String.Format ( "{0:N0}" , t.Sum ( u => u.PIEZAS ) );
				SEL_lbl.Text = String.Format ( "{0:N0}" , t.Count ( ) );

			} catch ( Exception ) {

			}
		}

		#region FilterDataGridView
		private void RefreshListItems ( ) {


			int sp = ( int ) ProcesosFilterToolBar.ComboBox.SelectedValue;

			DB.TempProduccion
				.Local
				.ToList ( )
				.ForEach ( y => {
					DB.Entry ( y ).State = EntityState.Detached;
					y = null;
				} );

			DB.tempOt.Where ( OT => OT.OT == this.OT )
				.IncludeFilter ( u => u.Produccion.Where ( o => o.TIPOPROCESO == sp ) ).Load ( );

			temporalOrdenTrabajoBindingSource.DataSource = DB.tempOt.Local.ToBindingList ( );

			temporalOrdenTrabajoBindingSource.ResetBindings ( false );
			produccionBindingSource.ResetBindings ( false );
			produccionKryptonDataGridView.Refresh ( );

			this.PageTitleText = $"Lista [{this.OT }] [{ProcesosFilterToolBar.ComboBox.SelectedItem }]";
		}

		private void toolStripButton3_Click ( object sender , EventArgs e ) => RefreshListItems ( );
		//	{
		//	int sp = ( int ) ProcesosFilterToolBar.ComboBox.SelectedValue;

		//	DB.TempProduccion
		//		.Local
		//		.ToList ( )
		//		.ForEach ( y => {
		//			DB.Entry ( y ).State = EntityState.Detached;
		//			y = null;
		//		} );

		//	DB.tempOt.Where ( OT => OT.OT == this.OT )
		//		.IncludeFilter ( u => u.Produccion.Where ( o => o.TIPOPROCESO == sp ) )
		//		.Load ( );

		//	temporalOrdenTrabajoBindingSource.DataSource = DB.tempOt.Local.ToBindingList ( );
		//}

		#endregion



		private void toolStripButton4_Click ( object sender , EventArgs e ) {

			if ( produccionKryptonDataGridView.SelectedRows.Count > 0 ) {
				td.Content = "Desea Eliminar los elementos seleccionados?";
				if ( td.ShowDialog ( ) == DialogResult.No )
					return;

				foreach ( DataGridViewRow row in produccionKryptonDataGridView.SelectedRows ) {
					produccionKryptonDataGridView.Rows.Remove ( row );
				}
			}


		}
		private void setBajadaActual_btn_Click ( object sender , EventArgs e ) {
			var val = KryptonInputBox.Show ( this , "Ingrese el valor de la bajada siguiente" , "Cambiar valor de bajada" , "1" );
			try {

				int valor;
				bool num = int.TryParse ( val , out valor );
				if ( !num )
					throw new Exception ( "No es un numero o valor valido" );
				if ( valor - 1 >= int.Parse ( repEje_txt.Text ) )
					throw new Exception ( "El valor debe ser menor al numero de repeticiones al eje de la OT" );

				AcumuladoBajada = valor - 1;
				bajadaActual_txt.Text = ( AcumuladoBajada ).ToString ( );
			} catch ( Exception ex ) {
				HandledException ( ex );
			}
		}


		private async void simularEtiqueta_Lista_chk_Click ( object sender , EventArgs e ) {
			var frm = new IniciarCaptura_frm ( );
			frm.InfoCapturaLayout.Visible = false;

			if ( frm.ShowDialog ( ) == DialogResult.OK ) {
				try {
					if ( produccionKryptonDataGridView.SelectedRows.Count <= 0 )
						throw new Exception ( "No se selecciono ningun elemento." );

					var t = produccionKryptonDataGridView.SelectedRows [ 0 ];

					var y = await DB.TempProduccion.Include ( r => r.Maquina_ ).Include ( r => r.Proceso_ ).Where ( r => r.Id == ( ( TempProduccion ) t.DataBoundItem ).Id ).FirstOrDefaultAsync ( );


					using ( var frm2 = new tools.PreviewLabel_frm<TempProduccion> ( y , frm.response.Etiqueta.ZPLCode , frm.response.Options ) ) {
						frm2.ShowDialog ( );
					}


					//this.replaceAndPrintZPLProduccion1.PrintZPL ( frm.response.Etiqueta.ZPLCode , y , frm.response.Options , true );

				} catch ( Exception ex ) {
					HandledException ( new Exception ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB , ex ) ) );
				}


			}
			frm.Dispose ( );
		}
	}
}
