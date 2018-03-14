using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Workspace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryKryptonDocking {
	/// <summary>
	/// Formulario Principal de la Aplicación
	/// </summary>
	public partial class MainForm : KryptonForm {
		#region Identity
		public MainForm () {
			InitializeComponent ( );
		}
		#endregion

		#region Implements
		private void Form1_Load ( object sender, EventArgs e ) {

			// Configuracion del Administrador de Docking
			KryptonDockingWorkspace w = kryptonDockingManager1.ManageWorkspace ( kryptonDockableWorkspace1 );
			kryptonDockingManager1.ManageControl ( "Catalogos", MainPanel, w );
			kryptonDockingManager1.ManageFloating ( this );
			kryptonDockingManager1.DockspaceCellAdding += KryptonDockingManager1_DockspaceCellAdding;

			// Handle y configuracion para el Timer del administrador de mensajes de estado
			this.TimerStatus.Elapsed += TimerStatus_Tick;
			this.TimerStatus.AutoReset = false;
		}

		#endregion

		#region PrivateFields

		#region Catalogos
		private Pages.Catalogos.Page1 pg1;
		private Pages.Catalogos.Clientes CatalogoClientes;
		#endregion

		#region Docking		
		private KryptonWorkspaceCell _wc;
		#endregion

		private System.Timers.Timer TimerStatus = new System.Timers.Timer ( 3000 );
		#endregion

		#region DockingControl
		/// <summary>
		/// Se desencadena cuando se agrega una celda al DockingManager
		/// <para>Crea la celda predeterminada para las paginas Catalogos</para>
		/// <para>Asigna el Handle al evento <c>CloseAction</c> del CellControl agregado</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void KryptonDockingManager1_DockspaceCellAdding ( object sender, DockspaceCellEventArgs e ) {

			if (( _wc == null || _wc.IsDisposed ) && System.Text.RegularExpressions.Regex.IsMatch ( e.DockspaceElement.Path, "(Catalogos)" )) {
				_wc = e.CellControl;
			}
			e.CellControl.CloseAction += Cell_CloseAction;
		}

		/// <summary>
		/// Configura la accion al cerrar la pagina o la celda a solo ocultar
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Cell_CloseAction ( object sender, CloseActionEventArgs e ) {
			e.Action = CloseButtonAction.HidePage;
		}

		#endregion

		#region Apertura Catalogos
		private void kryptonButton1_Click ( object sender, EventArgs e ) {
			Pages.Base.PageCreator.CreateAndShowCatalog (
				ref pg1,
				Pages.Base.FlagActiveFormFunctions.Todas,
				kryptonDockingManager1,
				_wc,
				null,//SetVisibleContext,
				SetInvisibleContext,
				SetStatusMessage
				);
		}

		private void kryptonButton2_Click ( object sender, EventArgs e ) {
			Pages.Base.PageCreator.CreateAndShowCatalog (
				ref CatalogoClientes,
				Pages.Base.FlagActiveFormFunctions.Todas,
				kryptonDockingManager1,
				_wc,
				null,//SetVisibleContext,
				SetInvisibleContext,
				SetStatusMessage
				);
		}

		#endregion

		#region Manejo de Eventos Page
		//private void SetVisibleContext ( object sender, Pages.Base.EnterPageEventArgs e ) {			
		//	this.kryptonRibbon1.SelectedContext = e.ContextNames;
		//}
		private void SetInvisibleContext ( object sender, Pages.Base.LeavePageEventArgs e ) {
			//this.kryptonRibbon1.SelectedContext = "";
		}
		#endregion

		#region Mensajes de Estado
		/// <summary>
		/// Cambia el Mensaje de estado en segundo plano
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SetStatusMessage ( object sender, Pages.Base.ChangeStatusMessageEventArgs e ) {
			Task.Run ( () => {
				TimerStatus.Stop ( );
				setStatusMessage ( e.Message );
				TimerStatus.Start ( );
			} );
		}
		/// <summary>
		/// Regresa el Status Message su forma original.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TimerStatus_Tick ( object sender, EventArgs e ) {
			Task.Run ( () => { setStatusMessage ( "Listo" ); } );
		}

		/// <summary>
		/// Asigna el valor del mensaje al status label.
		/// </summary>
		/// <param name="value">Mensaje a mostrar</param>
		private void setStatusMessage ( string value ) {
			if (statusStrip1.InvokeRequired) {
				statusStrip1.Invoke ( new Action<string> ( setStatusMessage ), value );
				return;
			}

			StatusLabel.Text = value;
		}

		#endregion

		private void MainForm_FormClosing ( object sender, FormClosingEventArgs e ) {

		}
	}
}
