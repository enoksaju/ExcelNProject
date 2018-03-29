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
	public partial class ExistenciasAlmacenPage : Base.DocumentPageBase {
		public ExistenciasAlmacenPage () {
			InitializeComponent ( );

			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder );

			KP.ImageSmall = Properties.Resources.Report_16x;
			PageTitleText = "Existencias Almacen";
		}

		private void ctlExistencias1_changeAlamacen ( object sender, string e ) {
			PageTitleText = "Existencias Almacen["+ e + "]";
		}
	}
}
