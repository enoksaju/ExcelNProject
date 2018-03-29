using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unvell.ReoGrid;
using unvell.ReoGrid.CellTypes;

namespace EstacionPesaje.Pages.MainPages.CapturaOrdenes {
	public partial class CapturaWorkSheetPage : Base.DocumentPageBase {

		public CapturaWorkSheetPage () {
			InitializeComponent ( );

			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder );

			KP.ImageSmall = Properties.Resources.shipment1;

			PageTitleText = "Embarques";

			//var wb = ReoGridControl.CreateMemoryWorkbook ( );
			//reoGridControl1.Load ( @"\\192.168.1.253\Temp\Henoc\CapturaOt\Nueva carpeta\cAPTURA MANUAL.xlsx", unvell.ReoGrid.IO.FileFormat.Excel2007 );

		}
	}
}
