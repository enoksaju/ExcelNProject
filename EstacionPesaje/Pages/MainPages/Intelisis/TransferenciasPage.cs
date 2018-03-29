using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstacionPesaje.Pages.MainPages.Intelisis {
	public partial class TransferenciasPage :  Base.DocumentPageBase {
		public TransferenciasPage () {
			InitializeComponent ( );

			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder );

			KP.ImageSmall = Properties.Resources.Report_16x;
			PageTitleText = "Transferencias";
		}

		private void ctlMoviminetosFechaLinea1_changedLinea ( object sender, string e ) {
			PageTitleText = "Transferencias["+ e + "]";
		}
	}
}
