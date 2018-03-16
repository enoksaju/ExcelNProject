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

namespace EstacionesPesaje.Pages.MainPages {
	public partial class ProduccionPage : Base.DocumentPageBase, Base.IUsaBascula {

		private string OT;
		private KryptonTaskDialog td = new KryptonTaskDialog ( ) {
			CommonButtons = TaskDialogButtons.Yes | TaskDialogButtons.No,
			DefaultButton = TaskDialogButtons.No,
			Icon = MessageBoxIcon.Question,
			Content = "",
			WindowTitle = "Confirmación de Captura",
			MainInstruction = "Continuar?"

		};
		private InformacionInicialCaptura valuesCaptura;
		public ControlBascula Bascula { get; set; }



		public ProduccionPage ( string OT, libBascula.ControlBascula Bascula_ ) {

			InitializeComponent ( );
			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder );

			DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );


			if (!DB.tempOt.Any ( o => o.OT == OT.Trim ( ) )) throw new Exception ( "No existe la orden solicitada" );

			this.OT = OT;
			this.PageTitleText = String.Format ( "Produccion[{0}]", this.OT );

			DB.tempOt.Where ( o => o.OT == OT.Trim ( ) ).Load ( );
			temporalOrdenTrabajoBindingSource.DataSource = DB.tempOt.Local.ToBindingList ( );

			this.Bascula = Bascula_;
			this.Bascula.CambioValor += Bascula_CambioValor;
			this.Bascula.CambioEstado += Bascula_CambioEstado;

			setEnableStatusBascula ( this.Bascula.Estatus == EstadoConexion.Conectado ? true : false );

			kryptonNavigator1.SelectedPage = kryptonPageInstrucciones;
		}
		protected override void Dispose ( bool disposing ) {
			if (disposing && ( components != null )) {

				Bascula.CambioValor -= Bascula_CambioValor;

				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}



		/// <summary>
		/// Controla las acciones de cambio de pestaña
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void kryptonNavigator1_Selecting ( object sender, ComponentFactory.Krypton.Navigator.KryptonPageCancelEventArgs e ) {

			if (e.Item == kryptonPageCaptura) {

				var frm = new IniciarCaptura_frm ( );

				if (frm.ShowDialog ( ) == DialogResult.OK) {
					valuesCaptura = frm.response;
					this.PageTitleText = String.Format ( "Captura Produccion[{0}]", this.OT );


					OperadorLabel.Text = valuesCaptura.Operador;
					TurnoLabel.Text = ( valuesCaptura.Turno == 1 ? "Primero" : ( valuesCaptura.Turno == 2 ? "Segundo" : ( valuesCaptura.Turno == 3 ? "Tercero" : "Mixto" ) ) );
					MaquinaLabel.Text = valuesCaptura.Maquina.NombreMaquina;
					ProcesoLabel.Text = valuesCaptura.Proceso.NombreProceso;

					var t = from produccion in DB.TempProduccion
							where produccion.OT == this.OT && produccion.TIPOPROCESO == valuesCaptura.Proceso.ID
							orderby produccion.NUMERO descending
							select new { produccion.NUMERO, produccion.PESOCORE };

					var num = t.FirstOrDefault ( )!=null? t.FirstOrDefault ( ).NUMERO: 0;
					var PesoCore = t.FirstOrDefault ( ) != null ? t.FirstOrDefault ( ).PESOCORE : 0;

					nUMEROKryptonTextBox.Value = num + 1;
					pESOCOREKryptonTextBox.Value = ( decimal ) PesoCore;

					Optional1_rdbtn.Text = valuesCaptura.Options.Optional1;
					Optional2_rdbtn.Text = valuesCaptura.Options.Optional2;
					Optional3_rdbtn.Text = valuesCaptura.Options.Optional3;
					Optional4_rdbtn.Text = valuesCaptura.Options.Optional4;
					Optional5_rdbtn.Text = valuesCaptura.Options.Optional5;


				} else {
					e.Cancel = true;
				}

				frm.Dispose ( );

			} else {
				this.PageTitleText = String.Format ( "Produccion[{0}]", this.OT );
			}

		}
			
		/// <summary>
		/// Retorna el ItemOptional seleccionado
		/// </summary>
		/// <returns></returns>
		private int GetItemSelected () {
			if (Optional1_rdbtn.Checked) {
				return 1;
			} else if (Optional2_rdbtn.Checked) {
				return 2;
			} else if (Optional3_rdbtn.Checked) {
				return 3;
			} else if (Optional4_rdbtn.Checked) {
				return 4;
			} else if (Optional5_rdbtn.Checked) {
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
		private void kryptonButton1_Click ( object sender, EventArgs e ) {
			try {
				td.Content = "Realmente desea Imprimir y guardar?";

				if (td.ShowDialog ( ) == DialogResult.No) return;

				var t = SaveCapturaProduccion ( );

				var y=DB.TempProduccion.Include ( r => r.Maquina_ ).Include ( r => r.Proceso_ ).Where ( r => r.Id == t.Id ).FirstOrDefault ();

				this.replaceAndPrintZPLProduccion1.PrintZPL ( valuesCaptura.Etiqueta.ZPLCode, y, valuesCaptura.Options, GetItemSelected ( ) );
			}
			catch (Exception ex) {
				HandledException ( new Exception ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) ) );
			}

		}

		/// <summary>
		/// Guarda la informacion de la captura en la BD y no imprime ninguna etiqueta
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void kryptonButton2_Click ( object sender, EventArgs e ) {

			try {
				td.Content = "Realmente desea solo guardar?";
				if (td.ShowDialog ( ) == DialogResult.No) return;

				SaveCapturaProduccion ( );
			}
			catch (Exception ex) {

				HandledException ( new Exception ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) ) );
			}
		}


		/// <summary>
		/// Procedimiento de almacenamiento de la captura en la Base de datos.
		/// </summary>
		/// <returns></returns>
		private TempProduccion SaveCapturaProduccion () {
			var t = new TempProduccion ( ) {
				BANDERAS = ( int ) bANDERASKryptonTextBox.Value,
				OT = this.OT,

				MAQUINA = valuesCaptura.Maquina.Id,
				TIPOPROCESO = valuesCaptura.Proceso.ID,

				PESOBRUTO = ( double ) pESOBRUTOKryptonTextBox.Value,
				PESOCORE = ( double ) pESOCOREKryptonTextBox.Value,
				NUMERO = ( int ) nUMEROKryptonTextBox.Value,
				PIEZAS = ( int ) pIEZASKryptonTextBox.Value,
				TURNO = valuesCaptura.Turno,
				ORIGEN = oRIGENKryptonTextBox.Text,
				FECHA = DateTime.Now,
				OPERADOR = valuesCaptura.Operador,
				REPETICION = 1,
				USUARIO = Environment.MachineName,
				INDICE = this.OT + "-" + valuesCaptura.Proceso.ID + "-" + ( int ) nUMEROKryptonTextBox.Value,
				ENSANEO = 0,
				FUEEDITADA = 0,
				FUESANEADA = 0,
				ESRECHAZADA = 0,
				EXTRUSION_ID = ""
			};

			DB.TempProduccion.Add ( t );
			DB.SaveChanges ( );
			DB.Entry ( t ).Reload ( );
			nUMEROKryptonTextBox.Value += 1;

			DB.Entry ( temporalOrdenTrabajoBindingSource.Current ).Reload ( );
			temporalOrdenTrabajoBindingSource.ResetBindings ( false );
			produccionBindingSource.ResetBindings ( false );
			produccionKryptonDataGridView.Refresh ( );

			return t;
		}		

		/// <summary>
		/// guarda los cambios del datagirdview en la base de datos
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripButton1_Click ( object sender, EventArgs e ) {
			try {
				td.Content = "Realmente desea guardar?";
				if (td.ShowDialog ( ) == DialogResult.No) return;
				DB.SaveChanges ( );
			}
			catch (Exception ex) {

				HandledException ( new Exception ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) ) );
			}
			finally {
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
		private void toolStripButton2_Click ( object sender, EventArgs e ) {

			var frm = new IniciarCaptura_frm ( );
			frm.InfoCapturaLayout.Visible = false;

			if (frm.ShowDialog ( ) == DialogResult.OK) {

				foreach (DataGridViewRow rw in produccionKryptonDataGridView.SelectedRows) {

					try {
						this.replaceAndPrintZPLProduccion1.PrintZPL ( frm.response.Etiqueta.ZPLCode, ( TempProduccion ) rw.DataBoundItem, frm.response.Options );
					}
					catch (Exception ex) {
						HandledException ( new Exception ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) ) );
					}

				}
			}
			frm.Dispose ( );
		}

		private bool CoreEditing = false;
		private void pESOCOREKryptonTextBox_Enter ( object sender, EventArgs e ) {
			CoreEditing = true;
		}
		private void pESOCOREKryptonTextBox_Leave ( object sender, EventArgs e ) {
			CoreEditing = false;
		}
		private void pESOBRUTOKryptonTextBox_ValueChanged ( object sender, EventArgs e ) {
			PesoNetokryptonNumericUpDown.Value = pESOBRUTOKryptonTextBox.Value - pESOCOREKryptonTextBox.Value;
		}

		#region Bascula

		/// <summary>
		/// Controla lo que sucede cuando el estado de la bascula cambia.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void Bascula_CambioEstado ( object sender, EstadoConexion e ) {

			await Task.Run ( () => {
				setEnableStatusBascula ( e == EstadoConexion.Conectado ? true : false );
			} );
		}


		/// <summary>
		/// Deshabilita el TextBox del peso Bruto si la bascula se encuentra conectada
		/// </summary>
		/// <param name="Value"></param>
		private void setEnableStatusBascula ( bool Value ) {

			if (this.InvokeRequired) {
				this.Invoke ( new Action<bool> ( setEnableStatusBascula ), Value );
				return;
			}

			pESOBRUTOKryptonTextBox.Enabled = !Value;
		}

		/// <summary>
		/// Controla lo que sucede cuando el valor de la bascula cambia
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void Bascula_CambioValor ( object sender, CambioValorEventArgs e ) {
			await Task.Run ( () => {
				try {
					if(!CoreEditing) setValuePesoBruto ( e.NuevoValor );
				}
				catch (Exception EX) {
					Console.WriteLine ( EX );
				}

			} );
		}

		/// <summary>
		/// Asigna el valor del peso bruto al Textbox
		/// </summary>
		/// <param name="Value"></param>
		private void setValuePesoBruto ( double Value ) {
			if (pESOBRUTOKryptonTextBox.InvokeRequired) {
				pESOBRUTOKryptonTextBox.Invoke ( new Action<double> ( setValuePesoBruto ), Value );
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

		
	}
}
