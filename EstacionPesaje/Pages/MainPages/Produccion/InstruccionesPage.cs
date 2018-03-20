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
using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Workspace;
using ComponentFactory.Krypton.Navigator;

namespace EstacionPesaje.Pages.MainPages {
	public partial class InstruccionesPage : Base.DocumentPageBase  {
		string _OT = "";
		public InstruccionesPage (string OT_) {
			InitializeComponent ( );
			DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );

			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder);

			PageTitleText = "Instrucciones[" + OT_ + "]";

			_OT = OT_;
						
		}

		private async void InstruccionesPage_Load ( object sender, EventArgs e ) {
			await DB.TEMPCAPT.Where ( o => o.OT == _OT ).LoadAsync ( );

			tEMPCAPTBindingSource.DataSource = DB.TEMPCAPT.Local.ToBindingList ( );
		}
		//public override void Show ( KryptonDockingManager kryptonDockingManager, KryptonWorkspaceCell kryptonWorkspaceCell ) {


		//	OnStatusStringChanged ( "Abriendo " + KP.TextTitle );

		//	var t = kryptonDockingManager.FindPageElement ( this.GetKryptonPage ( ) );

		//	if (( kryptonWorkspaceCell == null || kryptonWorkspaceCell.IsDisposed ) && t == null) {

		//		try {
		//			kryptonDockingManager.AddDockspace ( "Catalogos", DockingEdge.Left, new KryptonPage [] { this.GetKryptonPage ( ) } );
		//		}
		//		catch (Exception) {

		//		}
		//	}

		//	kryptonDockingManager.ShowPage ( this.GetKryptonPage ( ) );
		//}
	}
}
