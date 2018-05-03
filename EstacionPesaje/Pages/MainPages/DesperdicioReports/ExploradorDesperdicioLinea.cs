using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas;
using System.Data.Entity;

namespace EstacionPesaje.Pages.MainPages.DesperdicioReports {
	public partial class ExploradorDesperdicioLinea : Base.DocumentPageBase {
		private DateTime FI, FF;
		private int Linea_Id;
		public ExploradorDesperdicioLinea ( int Linea_Id_ , DateTime FechaInicial , DateTime FechaFinal  ) {
			InitializeComponent ( );

			DB = new DataBaseContexto ( );

			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowFloating );

			//var LineaName = DB.Lineas.Where ( o => o.Id == Linea_Id_ ).FirstOrDefault ( ).Nombre.ToLower ( );

			FI = FechaInicial.AddHours ( 8 ).AddMinutes ( 51 );
			FF = FechaFinal.AddDays ( 1 ).AddHours ( 8 ).AddMinutes ( 50 );
			this.Linea_Id = Linea_Id_;

		}

		private async void ExploradorDesperdicioLinea_Load ( object sender , EventArgs e ) {
			await DB.TDesperdicios.Where ( o => (o.FECHA >= FI & o.FECHA <= FF) & o.Maquina_.Linea_Id== Linea_Id  )
				.OrderBy(o=> o.OPERADOR ).LoadAsync ( );

			tempDesperdiciosBindingSource.DataSource = DB.TDesperdicios.Local.ToBindingList ( );

		}
	}
}
