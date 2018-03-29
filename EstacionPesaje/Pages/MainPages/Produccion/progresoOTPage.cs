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

namespace EstacionPesaje.Pages.MainPages.Produccion {
	public partial class progresoOTPage : Base.DocumentPageBase {
		Microsoft.Reporting.WinForms.ReportDataSource ReportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource ( );
		private string OT = "";
		public progresoOTPage ( string OT ) {
			InitializeComponent ( );
			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder );

			PageTitleText = "Progreso[" + OT + "]";
			ReportDataSource1.Name = "DataSet1";
			ReportDataSource1.Value = this.dataProduccionBindingSource;
			reportViewer1.LocalReport.DataSources.Add ( ReportDataSource1 );
			this.OT = OT;
		}

		private async void progresoOTPage_Load ( object sender, EventArgs e ) {
			DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );
			dataProduccionBindingSource.DataSource = Produccion.dataProduccion.ProgresoList ( await DB.tempOt.FirstOrDefaultAsync ( u => u.OT == this.OT ) );
			reportViewer1.RefreshReport ( );
		}

		private async void reportViewer1_ReportRefresh ( object sender, CancelEventArgs e ) {
			try {				
				dataProduccionBindingSource.DataSource = Produccion.dataProduccion.ProgresoList (await DB.tempOt.FirstOrDefaultAsync ( u => u.OT == this.OT ) );
			}
			catch (Exception ex) {
				HandledException ( ex );
			}
		}
	}
}
