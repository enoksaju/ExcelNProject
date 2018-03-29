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
	public partial class CierreOrdenesPage : Base.DocumentPageBase {
		public CierreOrdenesPage () {
			InitializeComponent ( );

			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder );

			KP.ImageSmall = Properties.Resources.mailbox_info1;
			PageTitleText = "Cierre de Ordenes";

		}

		private void movimientosOT1_changedOT ( object sender, string e ) {
			PageTitleText = "Cierre de Ordenes[" + e + "]";
		}
	}
}
