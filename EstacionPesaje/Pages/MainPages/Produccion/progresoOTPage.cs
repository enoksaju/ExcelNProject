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

namespace EstacionPesaje.Pages.MainPages.Produccion
{
	public partial class progresoOTPage : Base.DocumentPageBase
	{
		//private libProduccionDataBase.Reportes.OrdenTrabajo_ReportViewer rpt;
		public progresoOTPage ( string OT )
		{
			InitializeComponent ( );
			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder );

			PageTitleText = "Progreso[" + OT + "]";
			this.ordenTrabajo_ReportViewer1.OT = OT;

		}

		private async void progresoOTPage_Load ( object sender, EventArgs e )
		{
			try
			{
				await this.ordenTrabajo_ReportViewer1.initializeReport ( );
			}
			catch ( Exception ex )
			{
				ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show ( KP.FindForm ( ), ex.Message, "Algo va mal...", MessageBoxButtons.OK, MessageBoxIcon.Error );
				KP.Hide ( );
				KP.Dispose ( );
			}
			finally
			{

			}

		}
	}
}
