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
		private libProduccionDataBase.Contexto.DataBaseContexto DB;
		public CrearPapeletaTarima ( ) {
			InitializeComponent ( );
		}

		private async void CrearPapeletaTarima_Load ( object sender , EventArgs e ) {
			if ( !DesignMode ) {
				if ( this.OT != "" ) {
					DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );
					DB.Database.Log = Console.Write;
					await DB.tempOt.Where ( o => o.OT == this.OT ).LoadAsync ( );
					temporalOrdenTrabajoBindingSource.DataSource = DB.tempOt.Local.ToBindingList ( );

				} else {
					KryptonTaskDialog.Show ( "Algo va mal..." , "Error" , "La orden de trabajo no se ha indicado o es incorrecta." , MessageBoxIcon.Error , TaskDialogButtons.OK );
				}


				reportViewer1.RefreshReport ( );
			}
		}

		private void kryptonListBox1_SelectedValueChanged ( object sender , EventArgs e ) {
			if ( !DesignMode && kryptonListBox1.SelectedItem != null ) {

				using ( var barcode = new BarcodeLib.Barcode ( ) ) {
					barcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
					barcode.IncludeLabel = true;
					barcode.BarWidth = 2;

					pictureBox1.Image = barcode.Encode ( BarcodeLib.TYPE.CODE39 , ( ( NaveCuatro_Tarima ) kryptonListBox1.SelectedItem ).Id.ToString ( "*0000000000*" ) , 280 , 80 );
				}

				ReportModelBindingSource.DataSource = Models.ReportModel.fromContext ( DB , ( ( NaveCuatro_Tarima ) kryptonListBox1.SelectedItem ).Id ).ToList ( );
				reportViewer1.RefreshReport ( );
			}
		}
	}
}
