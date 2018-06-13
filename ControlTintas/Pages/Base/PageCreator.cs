using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Workspace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTintas.Pages.Base {
	public static class PageCreator {

		public static void CrateAndShowMainPage<V> (
			KryptonDockingManager kryptonDockingManager ,
			KryptonWorkspaceCell kryptonWorkspaceCell ,
			EventHandler<EnterPageEventArgs> EnterEventHandler = null ,
			EventHandler<LeavePageEventArgs> LeaveEventHandler = null ,
			EventHandler<ChangeStatusMessageEventArgs> StatusStringChanged = null
			) where V : class, IToKryptonPage, new() {

			V Page = new V ( );

			if ( EnterEventHandler != null && !Page.IsAssignedEnterPage )
				Page.EnterPage += EnterEventHandler;
			if ( LeaveEventHandler != null && !Page.IsAssignedLeavePage )
				Page.LeavePage += LeaveEventHandler;

			Page.Show ( kryptonDockingManager , kryptonWorkspaceCell );

		}

		public static void CrateAndShowMainPage<V> ( V Page ,
			KryptonDockingManager kryptonDockingManager ,
			KryptonWorkspaceCell kryptonWorkspaceCell ,
			EventHandler<EnterPageEventArgs> EnterEventHandler = null ,
			EventHandler<LeavePageEventArgs> LeaveEventHandler = null ,
			EventHandler<ChangeStatusMessageEventArgs> StatusStringChanged = null
			) where V : class, IToKryptonPage {

			if ( EnterEventHandler != null && !Page.IsAssignedEnterPage )
				Page.EnterPage += EnterEventHandler;
			if ( LeaveEventHandler != null && !Page.IsAssignedLeavePage )
				Page.LeavePage += LeaveEventHandler;
			Page.Show ( kryptonDockingManager , kryptonWorkspaceCell );
		}
	}
}
