using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using libProduccionDataBase.Tablas;

namespace EstacionesPesaje.Pages.MainPages.MaquinasForms {
	public partial class AddMaquinaFrm : KryptonForm {

		libProduccionDataBase.Contexto.DataBaseContexto DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );

		public AddMaquinaFrm () {
			InitializeComponent ( );

		}

		private async void AddMaquinaFrm_Load ( object sender, EventArgs e ) {
			await DB.Lineas.LoadAsync ( );
			await DB.TiposMaquina.LoadAsync ( );

			lineaBindingSource.DataSource = DB.Lineas.Local.ToBindingList ( );
			tipoMaquinaBindingSource.DataSource = DB.TiposMaquina.Local.ToBindingList ( );
		}

		Maquina mq; 
		private void AddMaquinaFrm_FormClosing ( object sender, FormClosingEventArgs e ) {


			if (DialogResult == DialogResult.OK) {
				try {

					double Vel;
					bool isDouble = Double.TryParse ( velocidadKryptonTextBox.Text, out Vel );

					if (isDouble) {

						if (mq == null) mq = new Maquina ( );

						mq.Linea = ( Linea ) lineaBindingSource.Current;
						mq.Linea_Id = ( ( Linea ) lineaBindingSource.Current ).Id;
						mq.TipoMaquina = ( TipoMaquina ) tipoMaquinaBindingSource.Current;
						mq.TipoMaquina_Id = ( ( TipoMaquina ) tipoMaquinaBindingSource.Current )?.Id;
						mq.Decks = 0;
						mq.NombreMaquina = nombreMaquinaKryptonTextBox.Text;
						mq.Velocidad = Vel;


						DB.Maquinas.AddOrUpdate ( m => new { m.NombreMaquina, m.Linea_Id }, mq );
						DB.SaveChanges ( );

					} else {
						throw new Exception ( "El valor de la velocidad no es valido" );
					}
				}
				catch (Exception ex) {
					KryptonTaskDialog.Show ( "Algo va mal...", "Error", libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ), MessageBoxIcon.Error, TaskDialogButtons.OK );
					e.Cancel = true;
				}


			}
		}
	}
}
