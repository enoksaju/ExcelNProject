using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Workspace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionPesaje.Pages.Base {
	public static class PageCreator {
		public static void CreateAndShowCatalog<V> ( ref V Catalog,
			FlagActiveFormFunctions Functions,
			KryptonDockingManager kryptonDockingManager,
			KryptonWorkspaceCell kryptonWorkspaceCell,
			EventHandler<EnterPageEventArgs> EnterEventHandler = null,
			EventHandler<LeavePageEventArgs> LeaveEventHandler = null,
			EventHandler<ChangeStatusMessageEventArgs> StatusStringChanged = null

			) where V : class, new() {
			if (Catalog == null) Catalog = new V ( );

			var y = Catalog as ICatalogPage;
			if (y != null) {
				if (EnterEventHandler != null && !y.IsAssignedEnterPage) y.EnterPage += EnterEventHandler;
				if (LeaveEventHandler != null && !y.IsAssignedLeavePage) y.LeavePage += LeaveEventHandler;
				if (StatusStringChanged != null && !y.IsAssignedStatusStringChanged) y.StatusStringChanged += StatusStringChanged;

				y.ShowCatalog ( Functions, kryptonDockingManager, kryptonWorkspaceCell );
			} else {
				throw new Exception ( "El tipo no implementa la interface ICatalogPage" );
			}

		}


		public static void CrateAndShowMainPage<V> ( ref V Page,
			KryptonDockingManager kryptonDockingManager,
			KryptonWorkspaceCell kryptonWorkspaceCell,
			EventHandler<EnterPageEventArgs> EnterEventHandler = null,
			EventHandler<LeavePageEventArgs> LeaveEventHandler = null,
			EventHandler<ChangeStatusMessageEventArgs> StatusStringChanged = null 
			) where V : class, new() {

			if (Page == null) Page = new V ( );

			var y = Page as IToKryptonPage;
			if (y != null) {
				if (EnterEventHandler != null && !y.IsAssignedEnterPage) y.EnterPage += EnterEventHandler;
				if (LeaveEventHandler != null && !y.IsAssignedLeavePage) y.LeavePage += LeaveEventHandler;

				y.Show ( kryptonDockingManager, kryptonWorkspaceCell );
			}
		}

		public static void CrateAndShowMainPage<V> (V Page,
			KryptonDockingManager kryptonDockingManager,
			KryptonWorkspaceCell kryptonWorkspaceCell,
			EventHandler<EnterPageEventArgs> EnterEventHandler = null,
			EventHandler<LeavePageEventArgs> LeaveEventHandler = null,
			EventHandler<ChangeStatusMessageEventArgs> StatusStringChanged = null
			) where V : class {			

			var y = Page as IToKryptonPage;
			if (y != null) {
				if (EnterEventHandler != null && !y.IsAssignedEnterPage) y.EnterPage += EnterEventHandler;
				if (LeaveEventHandler != null && !y.IsAssignedLeavePage) y.LeavePage += LeaveEventHandler;

				y.Show ( kryptonDockingManager, kryptonWorkspaceCell );
			}

		}
	}
}
