using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstacionPesaje.Pages.MainPages.Embarques {
	public partial class EmbarquesN4Page :  Base.DocumentPageBase {
		public EmbarquesN4Page (string OT ) {
			InitializeComponent ( );

			if ( !this.crearPapeletaTarima1.DB.tempOt.Any ( o => o.OT.TrimEnd() == OT.TrimEnd() ) )
				throw new Exception ( "La orden de trabajo no existe en la base de datos" );

			this.crearPapeletaTarima1.OT = OT;	

			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder );

			KP.ImageSmall = Properties.Resources.shipment1;
			PageTitleText = "Embarques N4";
		}
	}
}
