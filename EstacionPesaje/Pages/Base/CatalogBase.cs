using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libProduccionDataBase.Contexto;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Workspace;
using ComponentFactory.Krypton.Toolkit;

namespace EstacionPesaje.Pages.Base {
	[ToolboxItem ( false )]
	public partial class CatalogBase<T> : DefaultPageContent, ICatalogPage, IToKryptonPage where T : class {

		private BindingList<T> BindingList;
		public BindingSource BindingSource { get; set; }
		public DataGridView CatalogDataGridView { get; set; }
		public FlagActiveFormFunctions ActiveFunctions { get; set; }
		public DataBaseContexto DB { get; set; }

		public CatalogBase () {
			InitializeComponent ( );


			if (!DesignMode) {
				KP.ClearFlags ( KryptonPageFlags.All );
				KP.SetFlags (
					 KryptonPageFlags.DockingAllowDocked |
					 KryptonPageFlags.DockingAllowClose |
					 KryptonPageFlags.AllowPageDrag |
					 KryptonPageFlags.AllowConfigSave |
					 KryptonPageFlags.AllowPageReorder
					 );
				DB = new DataBaseContexto ( );
				DB.SavedChanges += DB_SavedChanges;
			}
		}

		public new void Show ( KryptonDockingManager kryptonDockingManager, KryptonWorkspaceCell kryptonWorkspaceCell ) {
			throw new NotImplementedException ( );
		}

		private async void CatalogBase_Load ( object sender, EventArgs e ) {
			if (!DesignMode) {
				await DB.Set<T> ( ).LoadAsync ( );
				this.BindingList = DB.Set<T> ( ).Local.ToBindingList ( );
				if (this.BindingSource != null) this.BindingSource.DataSource = BindingList;
			}
		}

		private void DB_SavedChanges ( object sender, EventArgs e ) {
			if (sender.GetType ( ) == this.GetType ( )) refreshCatalog ( );
		}



		public void addNew () {
			throw new NotImplementedException ( );
		}
		public void editCurrent () {
			throw new NotImplementedException ( );
		}
		public void viewDetailsOfCurrent () {
			throw new NotImplementedException ( );
		}

		public void deleteCurrent () {
			if (ActiveFunctions.HasFlag ( FlagActiveFormFunctions.Eliminar )) {
				if (KryptonTaskDialog.Show ( "Eliminar elemento", "Confirme", "¿Realmente desea eliminar el elemento seleccionado?", MessageBoxIcon.Question, TaskDialogButtons.Yes | TaskDialogButtons.No ) == DialogResult.No) return;

				this.BindingSource.RemoveCurrent ( );
			} else {
				HandledException ( new Exception ( "No tiene privilegios para ejecutar la acción solicitada" ) );
			}
		}


		public async void refreshCatalog () {
			LoaderPicktureBox.BringToFront ( );
			LoaderPicktureBox.Visible = true;

			if (CatalogDataGridView != null) CatalogDataGridView.Enabled = false;

			OnStatusStringChanged ( new ChangeStatusMessageEventArgs { Title = "Cargando..", Message = "Cargando Clientes..." } );

			await DB.Set<T> ( ).LoadAsync ( );

			this.BindingList = DB.Set<T> ( ).Local.ToBindingList ( );
			this.BindingSource.DataSource = BindingList;
			this.BindingSource.ResetBindings ( false );
			this.CatalogDataGridView?.Invalidate ( );

			if (CatalogDataGridView != null) CatalogDataGridView.Enabled = true;

			LoaderPicktureBox.Visible = false;

			OnStatusStringChanged ( new ChangeStatusMessageEventArgs { Title = "Listo", Message = "Listo" } );

		}

		public void searchElement ( string SearchString, params string [] Columns ) {
			var filter = DB
				.Set<T> ( )
				.Local
				.Where ( x => {
					bool T = false;
					foreach (var str in Columns) {
						T |= ( bool ) x.GetType ( ).GetProperty ( str )?.GetValue ( x ).ToString ( ).ToLower ( ).Contains ( SearchString.ToLower ( ) );
					}
					return T;
				} );

			BindingSource.DataSource = filter;
		}

		public void ShowCatalog ( FlagActiveFormFunctions Functions, KryptonDockingManager kryptonDockingManager, KryptonWorkspaceCell kryptonWorkspaceCell ) {
			OnStatusStringChanged ( "Abriendo " + KP.TextTitle );

			var t = kryptonDockingManager.FindPageElement ( this.GetKryptonPage ( ) );

			if (( kryptonWorkspaceCell == null || kryptonWorkspaceCell.IsDisposed ) && t == null) {
				kryptonDockingManager.AddDockspace ( "Catalogos", DockingEdge.Left, new KryptonPage [] { this.GetKryptonPage ( ) } );
			} else if (t == null & !kryptonWorkspaceCell.Pages.Contains ( this.GetKryptonPage ( ) )) {
				kryptonWorkspaceCell.Pages.Add ( this.GetKryptonPage ( ) );
			}
			kryptonDockingManager.ShowPage ( this.GetKryptonPage ( ) );

			var ds = t as KryptonDockingDockspace;
			ds?.SelectPage ( this.GetKryptonPage ( ).UniqueName );

		}


	}


}
