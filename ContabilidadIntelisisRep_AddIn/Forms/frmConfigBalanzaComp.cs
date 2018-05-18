using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContabilidadIntelisisRep_AddIn.Forms {
	public partial class frmConfigBalanzaComp : Form {
		public frmConfigBalanzaComp ( ) {
			InitializeComponent ( );
		}

		public frmContResultados.ConfigContBalanza response;

		private void frmConfigBalanzaComp_Load ( object sender , EventArgs e ) {

			nivelComboBox.DataSource = Enum.GetNames ( typeof ( frmContResultados.ConfigContBalanza.Niveles ) );
			conMovimientosComboBox.DataSource = Enum.GetNames ( typeof (frmContResultados .ConfigContBalanza .SiNo ) );


			frmContResultados_ConfigContBalanzaBindingSource.Add ( new frmContResultados.ConfigContBalanza ( ) );
		}

		private void frmConfigBalanzaComp_FormClosing ( object sender , FormClosingEventArgs e ) {
			if(this.DialogResult == DialogResult.OK ) {

				response = ( frmContResultados.ConfigContBalanza ) frmContResultados_ConfigContBalanzaBindingSource.Current ;

			}
		}

		private void button3_Click ( object sender , EventArgs e ) {
			using (var frm = new Forms .frmSelectorCuentas ( ) ) {
				if(frm.ShowDialog() ==  DialogResult.OK ) {
					(( frmContResultados.ConfigContBalanza ) frmContResultados_ConfigContBalanzaBindingSource.Current).CuentaD = frm.response;
					this.frmContResultados_ConfigContBalanzaBindingSource.ResetCurrentItem ( );
				}
			}
		}

		private void button4_Click ( object sender , EventArgs e ) {
			using ( var frm = new Forms.frmSelectorCuentas ( ) ) {
				if ( frm.ShowDialog ( ) == DialogResult.OK ) {
					( ( frmContResultados.ConfigContBalanza ) frmContResultados_ConfigContBalanzaBindingSource.Current ).CuentaA = frm.response;
					this.frmContResultados_ConfigContBalanzaBindingSource.ResetCurrentItem ( );
				}
			}
		}
	}
}
