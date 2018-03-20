using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libProduccionDataBase.Tablas;
using System.Data.Entity;
using ComponentFactory.Krypton.Toolkit;

namespace EstacionPesaje.Pages.MainPages {
	public partial class AddEditLabelPage : Base.DefaultPageContent {

		libProduccionDataBase.Contexto.DataBaseContexto DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );
		Etiqueta Et;
		public AddEditLabelPage (Etiqueta Etiqueta_ = null) {
			InitializeComponent ( );
			Et = Etiqueta_;
		}

		private async void AddEditLabelPage_Load ( object sender, EventArgs e ) {

			if (Et != null) await DB.Etiquetas.Where ( t => t.Id == Et.Id ).LoadAsync ( );

			var Entity = DB.Etiquetas.Local.FirstOrDefault ( p => p.Id == Et?.Id );

			etiquetaBindingSource.DataSource = DB.Etiquetas.Local.ToBindingList ( );

			if(Entity != null) {
				etiquetaBindingSource.Position = etiquetaBindingSource.IndexOf ( Entity );
				PageTitleText = "Etiqueta "+ Entity.Nombre;
				KP.ImageSmall = Properties.Resources.barcode_edit1;
			} else {
				etiquetaBindingSource.AddNew ( );
				PageTitleText = "Nueva Etiqueta ";
				KP.ImageSmall = Properties.Resources.barcode_new1;
			}
			
		}

		private void toolStripButton1_Click ( object sender, EventArgs e ) {
			try {
				if (KryptonTaskDialog.Show ( "confirmacion de acción", "Continuar?", "Realmente desea guardar el elemento?", MessageBoxIcon.Question, TaskDialogButtons.Yes | TaskDialogButtons.No ) == DialogResult.No) return;
				if (nombreKryptonTextBox.Text.Trim ( ) == String.Empty) throw new Exception ( "No se ha indicado un nombre valido" );

				etiquetaBindingSource.EndEdit ( );
				DB.SaveChanges ( );
			}
			catch (Exception ex) {
				HandledException ( new Exception ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) ) );
			}
		}
	}
}
