using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstacionPesaje.Pages.MainPages.Intelisis
{
	public partial class CierreOrdenesLinea : Base.DocumentPageBase
	{

		public delegate void OnChengeMsg ( object sender, string e );
		public event OnChengeMsg ChangedMsg;

		public CierreOrdenesLinea ()
		{
			InitializeComponent ( ); KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder );

			KP.ImageSmall = Properties.Resources.mailbox_info1;
			PageTitleText = "Cierre de Ordenes";
		}

		private void transferenciasOT1_ChangedOT ( object sender, libIntelisisReports.Controles.TransferenciasOT.OTEventArgs e )
		{
			PageTitleText = "Cierre por Linea[" + e.OT + "]";
		}

		private void transferenciasOT1_ChangedMsg ( object sender, libIntelisisReports.Controles.TransferenciasOT.OTEventArgs e )
		{
			try
			{
				ChangedMsg?.Invoke ( this, e.Message );
			}
			catch ( Exception ex )
			{
				MessageBox.Show ( e.Message );
			}		

		}
	}
}
