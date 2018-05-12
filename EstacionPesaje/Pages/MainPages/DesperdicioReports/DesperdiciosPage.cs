using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libBascula;
using ComponentFactory.Krypton.Toolkit;
using System.Data.Entity;
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas;
using Z.EntityFramework.Plus;

namespace EstacionPesaje.Pages.MainPages {
	public partial class DesperdiciosPage : Base.DocumentPageBase, Base.IUsaBascula {

		private string OT;

		private KryptonTaskDialog td = new KryptonTaskDialog ( ) {
			CommonButtons = TaskDialogButtons.Yes | TaskDialogButtons.No ,
			DefaultButton = TaskDialogButtons.No ,
			Icon = MessageBoxIcon.Question ,
			Content = "" ,
			WindowTitle = "Confirmación de Captura" ,
			MainInstruction = "Continuar?"
		};

		public DesperdiciosPage ( string OT , libBascula.ControlBascula Bascula_ ) {
			InitializeComponent ( );
			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder );

			DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );
			if ( !DB.tempOt.Any ( o => o.OT == OT.Trim ( ) ) )
				throw new Exception ( "No existe la orden solicitada" );

			this.OT = OT;
			this.PageTitleText = String.Format ( "Captura Desperdicio[{0}]" , this.OT );
			KP.ImageSmall = Properties.Resources.bin1;

			DB.tempOt.Where ( o => o.OT == OT.Trim ( ) ).Load ( );

			temporalOrdenTrabajoBindingSource.DataSource = DB.tempOt.Local.ToBindingList ( );

			this.Bascula = Bascula_;
			this.Bascula.CambioValor += Bascula_CambioValor;
			;
			this.Bascula.CambioEstado += Bascula_CambioEstado;
			;

			setEnableStatusBascula ( this.Bascula.Estatus == EstadoConexion.Conectado ? true : false );

			td.MainInstruction = $"Continuar la captura para la Orden {OT}";
			td.WindowTitle = $"Confirmación de Captura para la Orden {OT}";

		}

		private async void DesperdiciosPage_Load ( object sender , EventArgs e ) {
			await DB.Lineas.LoadAsync ( );
			await DB.TFamiliasDefectos.LoadAsync ( );

			lineaBindingSource.DataSource = DB.Lineas.Local.ToBindingList ( );
			tFamiliaDefectosBindingSource.DataSource = DB.TFamiliasDefectos.Local.ToBindingList ( );


			lineaKryptonComboBox.SelectedIndex = -1;
			maquinasKryptonComboBox.SelectedIndex = -1;
			tFamiliaDefectosKryptonComboBox.SelectedIndex = -1;
			tFamiliaDefectosTDefectoKryptonComboBox.SelectedIndex = -1;

			var t = await DB.tempOt.Where ( o => o.OT == OT.Trim ( ) ).FirstOrDefaultAsync ( );
			MaterialesDisponibles_listBox.Items.AddRange ( new string [ ] { t.MATBASE , t.MATLAMINACION , t.MATTRILAMINACION , "OTRO" } );


			var LastDesperdicio = await DB.TDesperdicios.Where ( u => u.OT == this.OT ).OrderByDescending ( u => u.NUMERO ).FirstOrDefaultAsync ( );
			nUMEROTextBox.Text = ( ( LastDesperdicio != null ? LastDesperdicio.NUMERO : 0 ) + 1 ).ToString ( );

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

			pESOTextBox.Enabled = !Value;
		}

		/// <summary>
		/// Asigna el valor del peso bruto al Textbox
		/// </summary>
		/// <param name="Value"></param>
		private void setValuePesoBruto ( double Value ) {
			if ( pESOTextBox.InvokeRequired ) {
				pESOTextBox.Invoke ( new Action<double> ( setValuePesoBruto ) , Value );
				return;
			}
			pESOTextBox.Text = Value.ToString ( );
		}


		private async void Bascula_CambioEstado ( object sender , EstadoConexion e ) {
			await Task.Run ( ( ) => {
				setEnableStatusBascula ( e == EstadoConexion.Conectado ? true : false );
			} );
		}

		private async void Bascula_CambioValor ( object sender , CambioValorEventArgs e ) {
			await Task.Run ( ( ) => {
				try {
					setValuePesoBruto ( e.NuevoValor );
				} catch ( Exception EX ) {
					Console.WriteLine ( EX );
				}

			} );
		}

		public ControlBascula Bascula { get; set; }

		private void lineaBindingSource_PositionChanged ( object sender , EventArgs e ) {
			maquinasKryptonComboBox.SelectedIndex = -1;
		}

		private void tFamiliaDefectosBindingSource_PositionChanged ( object sender , EventArgs e ) {
			tFamiliaDefectosTDefectoKryptonComboBox.SelectedIndex = -1;
		}


		private void MaterialesDisponibles_listBox_ItemChecked ( object sender , ItemCheckEventArgs e ) {
			eSTRUCTURAKryptonTextBox.Text = "";

			foreach ( var items in MaterialesDisponibles_listBox.CheckedItems ) {
				eSTRUCTURAKryptonTextBox.Text += items + "\r\n";
			};
		}

		private void GuardarEImprimir_Click ( object sender , EventArgs e ) {

			using ( DataBaseContexto DBLocal = new DataBaseContexto ( ) ) {
				try {

					if ( maquinasKryptonComboBox.SelectedValue == null )
						throw new Exception ( "Debe Seleccionar una Maquina" );

					if ( TurnoComboBox.SelectedIndex <= 0 )
						throw new Exception ( "Debe Seleccionar un Turno" );

					if ( tFamiliaDefectosTDefectoKryptonComboBox.SelectedValue == null )
						throw new Exception ( "Debe Seleccionar un Defecto" );

					if ( eSTRUCTURAKryptonTextBox.Text.Trim ( ) == String.Empty )
						throw new Exception ( "Debe Seleccionar un Material para la Estructura" );

					td.Content = "Realmente desea guardar?";
					if ( td.ShowDialog ( ) == DialogResult.No )
						throw new Exception ( "El usuario cancelo la captura." );

					var LastDesperdicio = DBLocal.TDesperdicios
						.Where ( u => u.OT == this.OT )
						.OrderByDescending ( u => u.NUMERO )
						.FirstOrDefault ( );

					var numero = ( ( LastDesperdicio != null ? LastDesperdicio.NUMERO : 0 ) + 1 );

					TempDesperdicios TD = new TempDesperdicios ( ) {
						DEFECTO = int.Parse ( tFamiliaDefectosTDefectoKryptonComboBox.SelectedValue.ToString ( ) ) ,
						DESCRIPCION = dESCRIPCIONKryptonTextBox.Text ,
						ESTRUCTURA = eSTRUCTURAKryptonTextBox.Text ,
						FECHA = DateTime.Now ,
						MAQUINA = int.Parse ( maquinasKryptonComboBox.SelectedValue.ToString ( ) ) ,
						NUMERO = numero ,
						OPERADOR = oPERADORTextBox.Text ,
						USUARIO = Environment.MachineName ,
						TURNO = TurnoComboBox.SelectedIndex ,
						OT = this.OT ,
						PESO = double.Parse ( pESOTextBox.Text )
					};

					if ( DBLocal.TDesperdicios.Any ( o => o.OT == this.OT & o.NUMERO == TD.NUMERO ) )
						throw new Exception ( "El elemento ya existe." );


					DBLocal.TDesperdicios.Add ( TD );
					DBLocal.SaveChanges ( );

					var xd = DBLocal.TDesperdicios.Where ( o => o.Id == TD.Id )
						.Include ( o => o.OrdenTrabajo )
						.Include ( o => o.FamiliaDefectosDefecto )
						.Include ( o => o.Maquina_ ).FirstOrDefault ( );

					nUMEROTextBox.Text = ( numero + 1 ).ToString ( );


					if ( !SimularEtiqueta_chk.Checked ) {
						PrintZPL.PrintDesperdicio ( xd );
					} else {

						using ( var frm = new tools.PreviewLabel_frm<TempDesperdicios> ( xd ) ) {
							frm.ShowDialog ( );
						}
					}


					if ( KryptonTaskDialog.Show ( "Confirme..." ,
						"Correcto, Otra Captura?" ,
						$"Se agrego el elemento correctamente\nDesea generar otra captura de desperdicio en la OT {this.OT}?" ,
						MessageBoxIcon.Question ,
						TaskDialogButtons.Yes | TaskDialogButtons.No , TaskDialogButtons.No ) == DialogResult.No ) {

						ComponentFactory.Krypton.Docking.IDockingElement t = this.kryptonDockingManager_.FindPageElement ( this.GetKryptonPage ( ) );
						if ( t.GetType ( ) == typeof ( ComponentFactory.Krypton.Docking.KryptonDockingWorkspace ) ) {
							var ds = ( ComponentFactory.Krypton.Docking.KryptonDockingWorkspace ) t;
							ds.HidePage ( this.GetKryptonPage ( ).UniqueName );
						}
						return;
					}

					//KryptonTaskDialog.Show ( "Muy bien..." , "Correcto" , "Se agrego el elemento correctamente" , MessageBoxIcon.Information , TaskDialogButtons.OK );
					CleanForm ( );
					CleanForm ( );
				} catch ( Exception ex ) {
					HandledException ( new Exception ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DBLocal , ex ) ) );
				}
			}				

		}

		private void LimpiarFormulario_Click ( object sender , EventArgs e ) {
			td.Content = "Realmente desea limpiar el formulario?";
			if ( td.ShowDialog ( ) == DialogResult.No )
				return;
			CleanForm ( );
			CleanForm ( );
		}

		private void CleanForm ( ) {
			lineaKryptonComboBox.SelectedIndex = -1;
			maquinasKryptonComboBox.SelectedIndex = -1;
			TurnoComboBox.SelectedIndex = 0;
			tFamiliaDefectosKryptonComboBox.SelectedIndex = -1;
			tFamiliaDefectosTDefectoKryptonComboBox.SelectedIndex = -1;
			oPERADORTextBox.Text = "";
			dESCRIPCIONKryptonTextBox.Text = "";

			foreach ( int item in MaterialesDisponibles_listBox.CheckedIndices ) {
				MaterialesDisponibles_listBox.SetItemChecked ( item , false );
			}

			var LastDesperdicio = DB.TDesperdicios.Where ( u => u.OT == this.OT ).OrderByDescending ( u => u.NUMERO ).FirstOrDefault ( );
			nUMEROTextBox.Text = ( ( LastDesperdicio != null ? LastDesperdicio.NUMERO : 0 ) + 1 ).ToString ( );

		}

		private void kryptonNavigator1_Selecting ( object sender , ComponentFactory.Krypton.Navigator.KryptonPageCancelEventArgs e ) {

			if ( e.Item == kryptonPageLista ) {

				DB.tempOt.Where ( OT => OT.OT == this.OT ).Include ( o => o.Desperdicios ).Load ( );

				temporalOrdenTrabajoBindingSource.DataSource = DB.tempOt.Local.ToBindingList ( );
				temporalOrdenTrabajoBindingSource.ResetBindings ( false );
				kryptonDataGridView1.Refresh ( );

				this.PageTitleText = String.Format ( "Lista Desperdicio [{0}]" , this.OT );
			} else {
				this.PageTitleText = String.Format ( "Captura Desperdicio [{0}]" , this.OT );
			}

		}

		private async void toolStripButton2_Click ( object sender , EventArgs e ) {



			foreach ( DataGridViewRow rw in kryptonDataGridView1.SelectedRows ) {

				try {

					var y = await DB
					.TDesperdicios
					.Include ( r => r.Maquina_ )
					.Include ( r => r.FamiliaDefectosDefecto )
					.Where ( r => r.Id == ( ( TempDesperdicios ) rw.DataBoundItem ).Id )
					.FirstOrDefaultAsync ( );
					this.PrintZPL.PrintDesperdicio ( y );
				} catch ( Exception ex ) {
					HandledException ( new Exception ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB , ex ) ) );
				}

			}
		}

		private void toolStripButton1_Click ( object sender , EventArgs e ) {
			try {
				td.Content = "Realmente desea guardar?";
				if ( td.ShowDialog ( ) == DialogResult.No )
					return;

				foreach ( var t in DB.TDesperdicios.Local.ToList ( ) ) {
					if ( t.OrdenTrabajo == null ) {
						DB.TDesperdicios.Remove ( t );
					}
				}

				DB.SaveChanges ( );
			} catch ( Exception ex ) {

				HandledException ( new Exception ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB , ex ) ) );
			} finally {

				DB.tempOt.Where ( OT => OT.OT == this.OT ).Include ( o => o.Desperdicios ).Load ( );
				temporalOrdenTrabajoBindingSource.DataSource = DB.tempOt.Local.ToBindingList ( );
				temporalOrdenTrabajoBindingSource.ResetBindings ( false );
				kryptonDataGridView1.Refresh ( );

			}
		}

		private async void simularEtiqueta_Lista_chk_Click ( object sender , EventArgs e ) {

			try {
				if ( kryptonDataGridView1.SelectedRows.Count <= 0 )
					throw new Exception ( "No se selecciono ningun elemento." );
				var t = kryptonDataGridView1.SelectedRows [ 0 ];

				var y = await DB
					.TDesperdicios
					.Include ( r => r.Maquina_ )
					.Include ( r => r.FamiliaDefectosDefecto )
					.Where ( r => r.Id == ( ( TempDesperdicios ) t.DataBoundItem ).Id )
					.FirstOrDefaultAsync ( );

				using ( var frm = new tools.PreviewLabel_frm<TempDesperdicios> ( y ) ) {
					frm.ShowDialog ( );
				}

			} catch ( Exception ex ) {
				HandledException ( new Exception ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB , ex ) ) );
			}



			//foreach (DataGridViewRow rw in kryptonDataGridView1.SelectedRows) {

			//	try {

			//		var y = await DB
			//		.TDesperdicios
			//		.Include ( r => r.Maquina_ )
			//		.Include ( r => r.FamiliaDefectosDefecto )
			//		.Where ( r => r.Id == ( ( TempDesperdicios ) rw.DataBoundItem ).Id )
			//		.FirstOrDefaultAsync ( );

			//		using (var frm = new tools.PreviewLabel_frm<TempDesperdicios> ( y )) {
			//			frm.ShowDialog ( );
			//		}

			//	}
			//	catch (Exception ex) {
			//		HandledException ( new Exception ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) ) );
			//	}

			//}



		}

		private void kryptonNavigator1_SelectedPageChanged ( object sender , EventArgs e ) {

		}

		private void kryptonDataGridView1_SelectionChanged ( object sender , EventArgs e ) {
			try {

				List<TempDesperdicios> t = ( from DataGridViewRow rw in this.kryptonDataGridView1.SelectedRows
											 select ( TempDesperdicios ) rw.DataBoundItem ).ToList ( );

				PB_lbl.Text = String.Format ( "{0:0.00}" , t.Sum ( u => u.PESO ) );
				SEL_lbl.Text = String.Format ( "{0:N0}" , t.Count ( ) );

			} catch ( Exception ) {

			}
		}
	}
}
