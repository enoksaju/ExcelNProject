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

namespace EstacionPesaje.Pages.MainPages {
	public partial class MaquinasPage : Base.DocumentPageBase {
		public MaquinasPage () {
			InitializeComponent ( );
			DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );
		}

		private async void MaquinasPage_Load ( object sender, EventArgs e ) {
			await DB.Lineas.LoadAsync ( );
			await DB.TiposMaquina.LoadAsync ( );

			lineaBindingSource.DataSource = DB.Lineas.Local.ToBindingList ( );
			tipoMaquinaBindingSource.DataSource = DB.TiposMaquina.Local.ToBindingList ( );

		}

		private void toolStripButton1_Click ( object sender, EventArgs e ) {
			using (var frm = new MaquinasForms.AddMaquinaFrm ( )) {
				frm.ShowDialog ( );

				DB.Lineas.Load ( );
				DB.Maquinas.Load ( );

				lineaBindingSource.DataSource = DB.Lineas.Local.ToBindingList ( );

				lineaBindingSource.ResetBindings ( false );
				maquinasBindingSource.ResetBindings ( false );

				kryptonDataGridView1.Refresh ( );
				kryptonDataGridView2.Refresh ( );
			}
		}
	}
}
