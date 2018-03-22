
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Workspace;


// TODO: CAmbiar los botones de las etiquetas a la pestaña de configuracion
namespace EstacionPesaje {
	public partial class Form1 : KryptonForm {

		private KryptonWorkspaceCell _wc;
		private KryptonWorkspaceCell _dc;

		private Pages.Config.ConfigBasculaPage ConfigBascula;

		public Form1 () {
			InitializeComponent ( );
		}

		private void Form1_Load ( object sender, EventArgs e ) {

			// Configuracion del Administrador de Docking
			KryptonDockingWorkspace w = kryptonDockingManager.ManageWorkspace ( kryptonDockableWorkspace );
			kryptonDockingManager.ManageControl ( "Catalogos", MainPanel, w );
			kryptonDockingManager.ManageFloating ( "Floating", this );
			kryptonDockingManager.DockspaceCellAdding += KryptonDockingManager_DockspaceCellAdding;
			kryptonDockingManager.DockableWorkspaceCellAdding += KryptonDockingManager_DockableWorkspaceCellAdding;

			this.controlBascula1.Initialize ( );

			foreach (var imp in System.Drawing.Printing.PrinterSettings.InstalledPrinters) {
				ImpresoraComboBox.Items.Add ( imp );
			}

			ImpresoraComboBox.SelectedItem = Properties.Settings.Default.ImpresoraEtiquetas;
			Ribbon.SelectedTab = ProduccionRibbonTab;
		}

		private void KryptonDockingManager_DockableWorkspaceCellAdding ( object sender, DockableWorkspaceCellEventArgs e ) {
			if (( _dc == null || _dc.IsDisposed ) && System.Text.RegularExpressions.Regex.IsMatch ( e.WorkspaceElement.Path, "(Workspace)" )) {
				_dc = e.CellControl;
			}

			e.CellControl.CloseAction += CellControl_CloseAction; ;
		}

		private void KryptonDockingManager_DockspaceCellAdding ( object sender, DockspaceCellEventArgs e ) {

			if (( _wc == null || _wc.IsDisposed ) && System.Text.RegularExpressions.Regex.IsMatch ( e.DockspaceElement.Path, "(Catalogos)" )) {
				_wc = e.CellControl;
			}

			e.CellControl.CloseAction += CellControl_CloseAction; ;
		}

		private void CellControl_CloseAction ( object sender, ComponentFactory.Krypton.Navigator.CloseActionEventArgs e ) {
			e.Action = CloseButtonAction.HidePage;
		}

		private void CapturaProduccionRbnBtn_Click ( object sender, EventArgs e ) {
			try {
				string OT = KryptonInputBox.Show ( this, "Ingrese el numero de orden que desea abrir", "Abrir OT Produccion", "*****" );

				if (OT != "" && OT != "*****") {

					Pages.Base.PageCreator.CrateAndShowMainPage (
						new Pages.MainPages.ProduccionPage ( OT, controlBascula1 ),
						kryptonDockingManager, _dc );
				}
			}
			catch (Exception ex) {
				KryptonTaskDialog.Show ( "Algo va mal...", "Error", ex.Message, MessageBoxIcon.Error, TaskDialogButtons.OK );
			}

		}

		private void ToogleBasculaConnection_Click ( object sender, EventArgs e ) {
			controlBascula1.toogleConection ( );
		}

		private void OpenConfigBasculaPage_Click ( object sender, EventArgs e ) {
			if (ConfigBascula == null) ConfigBascula = new Pages.Config.ConfigBasculaPage ( controlBascula1 );

			ConfigBascula.Show ( kryptonDockingManager, _wc );
		}

		private void ImpresoraComboBox_SelectedValueChanged ( object sender, EventArgs e ) {
			libControlesPersonalizados.ReplaceAndPrintZPLProduccion.PrinterNameGlobal = ImpresoraComboBox.Text;
			Properties.Settings.Default.ImpresoraEtiquetas = ImpresoraComboBox.Text;
		}

		private void controlBascula1_CambioEstado ( object sender, libBascula.EstadoConexion e ) {

			Image img = new Bitmap ( e == libBascula.EstadoConexion.Conectado ? controlBascula1.ConnectedImage : controlBascula1.DisconnectedImage, new Size ( 16, 16 ) );
			ConnectBasculaSpectButton.Image = img;
			ToogleBascula_btn.TextLine1 = e == libBascula.EstadoConexion.Conectado ? "Desconectar" : "Conectar";
			ToogleBascula_btn.ImageLarge = new Bitmap ( e == libBascula.EstadoConexion.Conectado ? controlBascula1.ConnectedImage : controlBascula1.DisconnectedImage, new Size ( 32, 32 ) );
			ToogleBascula_btn.ImageSmall = img;
		}

		private void kryptonRibbonGroupButton3_Click ( object sender, EventArgs e ) {
			Pages.Base.PageCreator.CrateAndShowMainPage (
				new Pages.MainPages.MaquinasPage ( ),
				kryptonDockingManager, _dc );
		}

		private void kryptonRibbonGroupButton4_Click ( object sender, EventArgs e ) {
			Pages.Base.PageCreator.CrateAndShowMainPage (
				new Pages.MainPages.AddEditLabelPage ( ),
				kryptonDockingManager, _dc );
		}

		private void kryptonRibbonGroupButton5_Click ( object sender, EventArgs e ) {
			using (var frm = new IniciarCaptura_frm ( )) {
				frm.InfoCapturaLayout.Visible = false;
				if (frm.ShowDialog ( ) == DialogResult.OK) {

					Pages.Base.PageCreator.CrateAndShowMainPage (
						new Pages.MainPages.AddEditLabelPage ( frm.response.Etiqueta ),
						kryptonDockingManager, _dc
						);
				}
			}
		}

		private void OrdenTrabajoExplorerRbnBtn_Click ( object sender, EventArgs e ) {
			Pages.Base.PageCreator.CrateAndShowMainPage (
				new Pages.MainPages.ViewOTPage ( ),
				kryptonDockingManager, _dc );
		}

		private void kryptonRibbonGroupButton4_Click_1 ( object sender, EventArgs e ) {
			try {
				string OT = KryptonInputBox.Show ( this, "Ingrese el numero de orden que desea abrir", "Abrir OT Produccion", "*****" );

				if (OT != "" && OT != "*****") {

					Pages.Base.PageCreator.CrateAndShowMainPage (
						new Pages.MainPages.DesperdiciosPage ( OT, controlBascula1 ),
						kryptonDockingManager, _dc );
				}
			}
			catch (Exception ex) {
				KryptonTaskDialog.Show ( "Algo va mal...", "Error", ex.Message, MessageBoxIcon.Error, TaskDialogButtons.OK );
			}
		}

		private void kryptonRibbonGroupButton1_Click ( object sender, EventArgs e ) {
			this.kryptonDockableWorkspace
				.AllPages ( )
				.ToList ( )
				.ForEach ( o => this.kryptonDockableWorkspace.ClosePage ( o ) );
		}

		private void kryptonRibbonGroupButton5_Click_1 ( object sender, EventArgs e ) {
			using (var frm = new Pages.MainPages.DesperdicioReports.forms.LineaFecha_frm ( )) {
				if (frm.ShowDialog ( ) == DialogResult.OK) {
					Pages.Base.PageCreator.CrateAndShowMainPage (
					new Pages.MainPages.DesperdicioReports.IntelisisPage ( frm.Response.Linea.Id, frm.Response.FechaInicial, frm.Response.FechaFinal ),
					kryptonDockingManager, _dc );
				}
			}
		}

		private void kryptonRibbonGroupButton8_Click ( object sender, EventArgs e ) {
			using (var frm = new Pages.MainPages.DesperdicioReports.forms.LineaFecha_frm ( )) {
				if (frm.ShowDialog ( ) == DialogResult.OK) {
					Pages.Base.PageCreator.CrateAndShowMainPage (
					new Pages.MainPages.DesperdicioReports.FechasPage ( frm.Response.Linea.Id, frm.Response.FechaInicial, frm.Response.FechaFinal ),
					kryptonDockingManager, _dc );
				}
			}
		}

		private void kryptonRibbonGroupButton7_Click ( object sender, EventArgs e ) {
			try {
				string OT = KryptonInputBox.Show ( this, "Ingrese el numero de orden que desea abrir, separe por ',' si son varias ordenes.", "Abrir OT Produccion", "*****" );

				if (OT != "" && OT != "*****") {

					Pages.Base.PageCreator.CrateAndShowMainPage (
						new Pages.MainPages.DesperdicioReports.OrdenTrabajoPage ( OT ),
						kryptonDockingManager, _dc );
				}
			}
			catch (Exception ex) {
				KryptonTaskDialog.Show ( "Algo va mal...", "Error", ex.Message, MessageBoxIcon.Error, TaskDialogButtons.OK );
			}
		}

		private void showInstrucciones_btn_Click ( object sender, EventArgs e ) {
			try {
				string OT = KryptonInputBox.Show ( this, "Ingrese el numero de orden que desea abrir", "Abrir OT Produccion", "*****" );

				if (OT != "" && OT != "*****") {

					Pages.Base.PageCreator.CrateAndShowMainPage (
						new Pages.MainPages.InstruccionesPage ( OT ),
						kryptonDockingManager, _dc );

				}
			}
			catch (Exception ex) {
				KryptonTaskDialog.Show ( "Algo va mal...", "Error", ex.Message, MessageBoxIcon.Error, TaskDialogButtons.OK );
			}
		}

		private void kryptonRibbonGroupButton6_Click ( object sender, EventArgs e ) {
			try {
				string OT = KryptonInputBox.Show ( this, "Ingrese el numero de orden que desea abrir", "Abrir Historico", "*****" );

				if (OT != "" && OT != "*****") {

					Pages.Base.PageCreator.CrateAndShowMainPage (
						new Pages.MainPages.HistoricoOts ( OT ),
						kryptonDockingManager, _dc );

				}
			}
			catch (Exception ex) {
				KryptonTaskDialog.Show ( "Algo va mal...", "Error", ex.Message, MessageBoxIcon.Error, TaskDialogButtons.OK );
			}
		}

		private void kryptonRibbonGroupButton9_Click ( object sender, EventArgs e ) {
			try {
				string OT = KryptonInputBox.Show ( this, "Ingrese nombre total o parcial del producto a buscar", "Abrir Historico", "*****" );

				if (OT != "" && OT != "*****") {

					Pages.Base.PageCreator.CrateAndShowMainPage (
						new Pages.MainPages.HistoricoOts ( OT, false ),
						kryptonDockingManager, _dc );

				}
			}
			catch (Exception ex) {
				KryptonTaskDialog.Show ( "Algo va mal...", "Error", ex.Message, MessageBoxIcon.Error, TaskDialogButtons.OK );
			}
		}
		
		private void OpenReportEmbarque_Click ( object sender, EventArgs e ) {
			Pages.Base.PageCreator.CrateAndShowMainPage (
						new Pages.MainPages.Embarques.EmbarquesReportPage(),
						kryptonDockingManager, _dc );
		}

		private void kryptonRibbonGroupCheckBox1_CheckedChanged ( object sender, EventArgs e ) {
			Properties.Settings.Default.enabledImpresionMultiple = kryptonRibbonGroupCheckBox1.Checked;
		}
	}
}
