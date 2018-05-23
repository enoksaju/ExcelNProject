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

namespace ControlTintas {
	public partial class Form1 : KryptonForm {
		private KryptonWorkspaceCell _dc;
		public Form1 ( ) {
			InitializeComponent ( );
		}

		private void Form1_Load ( object sender , EventArgs e ) {
			KryptonDockingWorkspace w = kryptonDockingManager.ManageWorkspace ( DockableWorkspace );
			kryptonDockingManager.ManageControl ( MainPanel , w );
			kryptonDockingManager.ManageFloating ( this );

			//kryptonDockingManager.DockspaceCellAdding += KryptonDockingManager_DockspaceCellAdding;
			kryptonDockingManager.DockableWorkspaceCellAdding += KryptonDockingManager_DockableWorkspaceCellAdding;
		}
		private void KryptonDockingManager_DockableWorkspaceCellAdding ( object sender , DockableWorkspaceCellEventArgs e ) {
			if ( ( _dc == null || _dc.IsDisposed ) && System.Text.RegularExpressions.Regex.IsMatch ( e.WorkspaceElement.Path , "(Workspace)" ) ) {
				_dc = e.CellControl;
			}
			e.CellControl.CloseAction += CellControl_CloseAction;			
		}
		private void CellControl_CloseAction ( object sender , ComponentFactory.Krypton.Navigator.CloseActionEventArgs e ) {
			e.Action = CloseButtonAction.HidePage;
		}
		
		private void kryptonRibbonGroupButton1_Click ( object sender , EventArgs e ) {
			Pages.Base.PageCreator.CrateAndShowMainPage<Pages.Pages.CatalogoArticulo> ( kryptonDockingManager , _dc );
		}
	}
}
