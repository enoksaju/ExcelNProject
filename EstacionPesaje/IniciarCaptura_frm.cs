using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using libControlesPersonalizados;
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas;
using static EstacionPesaje.Pages.MainPages.ProduccionPage;

namespace EstacionPesaje {
	public partial class IniciarCaptura_frm : KryptonForm {

		public InformacionInicialCaptura response = null;
		public DataBaseContexto DB = new DataBaseContexto ( );

		public IniciarCaptura_frm () {
			InitializeComponent ( );

		}

		private async void IniciarCaptura_frm_Load ( object sender, EventArgs e ) {
			await DB.Lineas.LoadAsync ( );
			await DB.Etiquetas.LoadAsync ( );
			await DB.Procesos.LoadAsync ( );

			lineaBindingSource.DataSource = DB.Lineas.Local.ToBindingList ( );
			//maquinaBindingSource.DataSource = DB.Maquinas.Local.ToBindingList ( );
			procesoBindingSource.DataSource = DB.Procesos.Local.ToBindingList ( );
			etiquetaBindingSource.DataSource = DB.Etiquetas.Local.ToBindingList ( );
		}


		private void etiquetaKryptonComboBox_SelectedValueChanged ( object sender, EventArgs e ) {
			try {
				pictureBox1.Image = zplImageConverter1.previewLabel ( ( ( Etiqueta )
					//etiquetaBindingSource.Current 
					etiquetaKryptonComboBox.SelectedItem
					).ZPLCode );
			}
			catch (Exception) {

			}
		}

		private void AceptButton_Click ( object sender, EventArgs e ) {

		}

		private void IniciarCaptura_frm_FormClosing ( object sender, FormClosingEventArgs e ) {
			if (DialogResult == DialogResult.OK) {
				if (InfoCapturaLayout.Visible && ( OperadorkryptonTextBox.Text.Trim ( ) == string.Empty || TurnokryptonComboBox.SelectedIndex <= 0 )) {
					KryptonTaskDialog.Show ( "Algo va mal...", "Error", "Por favor, Verifique que la informacion sea la correcta", MessageBoxIcon.Error, TaskDialogButtons.OK );
					e.Cancel = true;
				} else {

					response = new InformacionInicialCaptura ( ) {
						Maquina = ( Maquina ) maquinasBindingSource.Current,
						Turno = TurnokryptonComboBox.SelectedIndex,
						Proceso = ( Proceso ) procesoBindingSource.Current,
						Operador = OperadorkryptonTextBox.Text,
						Etiqueta = ( Etiqueta ) etiquetaBindingSource.Current,
						Options = new Optionals {
							ItemOptional = ItemOptionalTextBox .Text,
							Optional1 = Optional1TextBox .Text,
							Optional2 = Optional2TextBox.Text,
							Optional3 = Optional3TextBox.Text,
							Optional4 = Optional4TextBox.Text,
							Optional5 = Optional5TextBox.Text,
						}
						
					};

				}
			}
		}

		private void etiquetaKryptonComboBox_SelectionChangeCommitted ( object sender, EventArgs e ) {
			
		}

		private void etiquetaKryptonComboBox_SelectedIndexChanged ( object sender, EventArgs e ) {
			
		}
	}
}
