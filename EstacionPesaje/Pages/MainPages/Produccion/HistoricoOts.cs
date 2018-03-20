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
using Z.EntityFramework.Plus;
using ComponentFactory.Krypton.Toolkit;

namespace EstacionPesaje.Pages.MainPages {
	public partial class HistoricoOts : Base.DocumentPageBase {

		private string ToSearch = "";
		private bool AsOT = true;
		public HistoricoOts ( string Tosearch_, bool AsOT_ = true ) {
			InitializeComponent ( );
			DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );

			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder );

			PageTitleText = "Historico[" + Tosearch_ + "]";
			ToSearch = Tosearch_;
			this.AsOT = AsOT_;


		}

		private async void HistoricoOts_Load ( object sender, EventArgs e ) {

			if (AsOT) {
				try {
					var localOT = await DB.TEMPCAPT.Include ( o => o.OrdenTrabajo ).Where ( o => o.OT == ToSearch ).FirstOrDefaultAsync ( );

					await DB.TEMPCAPT
						.Where ( o => o.OrdenTrabajo.PRODUCTO.Contains ( localOT.OrdenTrabajo.PRODUCTO ) )
						.OrderBy ( O => O.DISENIOAUT )
						.LoadAsync ( );
				}
				catch (Exception ex) {
					KryptonTaskDialog.Show ( "Algo va mal...", "Error", "No se encontro el historico: \n" + ex.Message, MessageBoxIcon.Error, TaskDialogButtons.OK );
				}

			} else {

				await DB.TEMPCAPT
					.Where ( o => o.OrdenTrabajo.PRODUCTO.Contains ( ToSearch ) )
					.OrderBy ( O => O.DISENIOAUT )
					.LoadAsync ( );

			}

			tEMPCAPTBindingSource.DataSource = DB.TEMPCAPT.Local.ToBindingList ( );

		}
	}
}
