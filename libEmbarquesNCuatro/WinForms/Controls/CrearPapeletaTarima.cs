using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Data.Entity;
using libProduccionDataBase.Tablas;

namespace libEmbarquesNCuatro.WinForms.Controls {
	public partial class CrearPapeletaTarima : UserControl {
		public string OT { get; set; } = "";
		public libProduccionDataBase.Contexto.DataBaseContexto DB { get; set; }
		public CrearPapeletaTarima ( ) {
			InitializeComponent ( );
			if ( !DesignMode ) {
				DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );
			}
		}

		private async void CrearPapeletaTarima_Load ( object sender , EventArgs e ) {
			if ( !DesignMode && this.OT != "" && DB.tempOt.Any ( o => o.OT == this.OT ) ) {				
				//DB.Database.Log = Console.Write;
				await DB.tempOt.Where ( o => o.OT == this.OT ).LoadAsync ( );
				temporalOrdenTrabajoBindingSource.DataSource = DB.tempOt.Local.ToBindingList ( );
				reportViewer1.RefreshReport ( );

				tarimasNCuatroKryptonDataGridView.Focus ( );
				tarimasNCuatroKryptonDataGridView.Select ( );

			} else if ( !DesignMode ) {
				throw new Exception ( "La orden de trabajo no exite en la base de datos." );
			}
		}

		private void reportViewer1_ReportRefresh ( object sender , CancelEventArgs e ) => RefreshReport ( false );
		private void RefreshReport ( bool refresh ) {
			if ( !DesignMode && tarimasNCuatroBindingSource.Current != null ) {
				reportViewer1.SetDisplayMode ( Microsoft.Reporting.WinForms.DisplayMode.PrintLayout );
				reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
				reportViewer1.ZoomPercent = 100;
				ReportModelBindingSource.DataSource = Models.ReportModel.fromContext ( DB , ( ( NaveCuatro_Tarima ) tarimasNCuatroBindingSource.Current ).Id ).ToList ( );
				if ( refresh )
					reportViewer1.RefreshReport ( );
			}
		}

		private void AddTarima_btn_Click ( object sender , EventArgs e ) {
			using ( var frm = new frmCrearTarimaNueva ( this.OT ) ) {
				if ( frm.ShowDialog ( this.FindForm ( ) ) == DialogResult.OK ) {
					DB.Entry ( temporalOrdenTrabajoBindingSource.Current ).Reload ( );
					DB.Entry ( ( TemporalOrdenTrabajo ) temporalOrdenTrabajoBindingSource.Current )
						.Collection ( o => o.TarimasNCuatro ).Load ( );
					temporalOrdenTrabajoBindingSource.ResetCurrentItem ( );
					tarimasNCuatroBindingSource.ResetBindings ( false );
					tarimasNCuatroBindingSource.MoveLast ( );
				}
			}
		}

		private void tarimasNCuatroBindingSource_CurrentChanged ( object sender , EventArgs e ) {
			RefreshReport ( true );
		}
	}
}