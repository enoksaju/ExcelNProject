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
using Microsoft.Reporting.WinForms;

namespace EstacionPesaje.Pages.MainPages.Embarques {
	public partial class EmbarquesReportPage : Base.DocumentPageBase {
		Microsoft.Reporting.WinForms.ReportDataSource ReportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource ( );

		public EmbarquesReportPage () {
			InitializeComponent ( );


			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder );

			KP.ImageSmall = Properties.Resources.shipment1;

			PageTitleText = "Embarques";

			ReportDataSource1.Name = "DataSet1";
			ReportDataSource1.Value = this.dataPackingListBindingSource;
			reportViewer1.LocalReport.DataSources.Add ( ReportDataSource1 );
		}

		private async void EmbarquesReportPage_Load ( object sender, EventArgs e ) {

			DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );
			await DB.Procesos.LoadAsync ( );
			procesoBindingSource.DataSource = DB.Procesos.Local.ToBindingList ( );
			proceso_cbx.SelectedValue = 3;

			reportViewer1.LocalReport.SetParameters ( new ReportParameter ( "LOGO", logo_chk.Checked.ToString ( ) ) );
			reportViewer1.RefreshReport ( );

		}

		private void reportViewer1_ReportRefresh ( object sender, CancelEventArgs e ) {
			try {
				System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo ( ( ingles_chk.Checked ? "en-US" : "es-MX" ) );
				reportViewer1.LocalReport.SetParameters ( new ReportParameter ( "LOGO", logo_chk.Checked.ToString ( ) ) );
				PageTitleText = "Embarques["+ ot_txt.Text  + "]";

				dataPackingListBindingSource .DataSource  = Embarques.DataPackingList.getList (
					ot_txt.Text,
					( int ) proceso_cbx.SelectedValue,
					DataPackingList.getFilter ( todasSaneadas_chk.Checked, rechazadas_chk.Checked, saneadas_chk.Checked, enSaneo_chk.Checked ),
					( int ) inicio_num.Value,
					( int ) fin_num.Value,
					( int ) tarimaInicial_num.Value,
					( int ) porTarima_num.Value,
					unirPaginas_chk.Checked,
					( filas_txt.Text.Trim ( ) == String.Empty ? "[0-9]*" : filas_txt.Text.Trim ( ) )

					);
			}
			catch (Exception ex) {
				HandledException ( ex );
			}
		}
	}
}
