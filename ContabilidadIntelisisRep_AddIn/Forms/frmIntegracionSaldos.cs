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
	public partial class frmIntegracionSaldos : Form {
		public enum Datos { cxc, cxp }
		private Datos dt;
		public frmIntegracionSaldos ( Datos dt ) {
			InitializeComponent ( );
			this.dt = dt;
			this.Text = $"Integración de saldos { ( this.dt == Datos.cxc ? "Cxc" : "Cxp" ) }";// this.dt == Datos.cxc ? $"Integracion de saldos Cxc[{}]": $"Integracion de saldos Cxp[{}]";

			this.TipoBusqueda_cmb.DataSource = Enum.GetValues ( typeof ( Modelos.Tipos ) );
			this.dateTimePicker1.Value = DateTime.Now.Date;


			if ( dt == Datos.cxp ) {
				PorcRetISR.Visible = true;
				SaldoRetISR.Visible = true;
				RetencionISR.Visible = true;
			}
		}

		private async void button1_Click ( object sender , EventArgs e ) {
			this.Text = $"Integración de saldos { ( this.dt == Datos.cxc ? "Cxc" : "Cxp" ) }[{ String.Format ( "{0:dd/MM/yyyy}" , dateTimePicker1.Value ) }] - Cargando...";
			this.dateTimePicker1.Enabled = false;
			this.button1.Enabled = false;
			SetValue ( this.dt == Datos.cxc ? await Modelos.IntegracionSaldos.getCxcAsync ( dateTimePicker1.Value , ( Modelos.Tipos ) TipoBusqueda_cmb.SelectedItem ) : await Modelos.IntegracionSaldos.getCxpAsync ( dateTimePicker1.Value , ( Modelos.Tipos ) TipoBusqueda_cmb.SelectedItem ) );
		}

		private void SetValue ( List<Modelos.IntegracionSaldos> value ) {
			if ( this.integracionSaldosDataGridView.InvokeRequired ) {
				this.integracionSaldosDataGridView.Invoke ( new Action<List<Modelos.IntegracionSaldos>> ( SetValue ) , value );
				return;
			}
			this.integracionSaldosBindingSource.DataSource = value;
			this.Text = $"Integración de saldos { ( this.dt == Datos.cxc ? "Cxc" : "Cxp" ) }[{String.Format ( "{0:dd/MM/yyyy}" , dateTimePicker1.Value )}]";
			this.dateTimePicker1.Enabled = true;
			this.button1.Enabled = true;
		}

		private void dateTimePicker1_KeyUp ( object sender , KeyEventArgs e ) {
			if ( e.KeyCode == Keys.Enter ) {
				button1_Click ( sender , null );
			}
		}

		private void copiarToolStripMenuItem_Click ( object sender , EventArgs e ) {
			DataObject dt = integracionSaldosDataGridView.GetClipboardContent ( );
			if ( dt != null )
				Clipboard.SetDataObject ( dt );
		}

		private void button2_Click ( object sender , EventArgs e ) {
			if ( textBox1.Text.Trim ( ) != "" ) {
				var y = ( ( List<Modelos.IntegracionSaldos> ) this.integracionSaldosBindingSource.DataSource )
					.FirstOrDefault ( o => o.MovId.Contains( textBox1.Text.Trim ( ) ));
				if ( y != null ) {
					this.integracionSaldosBindingSource.Position = ( ( List<Modelos.IntegracionSaldos> ) this.integracionSaldosBindingSource.DataSource ).IndexOf ( y );
				}
			}
		}
	}
}
