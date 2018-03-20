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
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas;

namespace EstacionPesaje.Pages.MainPages.DesperdicioReports.forms {
	public partial class LineaFecha_frm : KryptonForm {
		public class ResponseDialog {
			private DateTime _FechaInicial;
			public enum Rangos { Diario, Mensual, Anual }
			public DateTime FechaInicial {
				get {
					switch (Rango) {
						case Rangos.Diario:
							return _FechaInicial.Date;
						case Rangos.Mensual:
							return new DateTime ( _FechaInicial.Year, _FechaInicial.Month, 1 );
						case Rangos.Anual:
							return new DateTime ( _FechaInicial.Year, 1, 1 );
						default:
							return _FechaInicial;
					}
				}
				set { _FechaInicial = value; }
			}
			public DateTime FechaFinal {
				get {
					switch (Rango) {
						case Rangos.Diario:
							return _FechaInicial.Date;
						case Rangos.Mensual:
							return new DateTime ( _FechaInicial.Year, _FechaInicial.Month, DateTime.DaysInMonth ( _FechaInicial.Year, _FechaInicial.Month ) );
						case Rangos.Anual:
							return new DateTime ( _FechaInicial.Year, 12, 31 );
						default:
							return _FechaInicial;
					}
				}
			}
			public Linea Linea { get; set; }
			public Rangos Rango { get; set; }

			public ResponseDialog (Linea Linea_, DateTime FechaInicial_,  Rangos Rango_) {
				FechaInicial = FechaInicial_;
				Linea = Linea_;
				Rango = Rango_;
			}
		}

		public ResponseDialog Response;
		private DataBaseContexto DB;
		public LineaFecha_frm () {
			InitializeComponent ( );
			DB = new DataBaseContexto ( );
		}
		private async void LineaFecha_frm_Load ( object sender, EventArgs e ) {
			await DB.Lineas.LoadAsync ( );
			lineaBindingSource.DataSource = DB.Lineas.Local.ToBindingList ( );
			fecha_dp.Value = DateTime.Now.Date ;
			linea_cb.SelectedIndex = -1;
		}

		private void Rango_CheckedChanged ( object sender, EventArgs e ) {

			if (( ( KryptonRadioButton ) sender ).Checked) {
				if (sender == Diario_obtn) {
					fecha_dp.CustomFormat = "dd MMMM yyyy";
				} else if (sender == mensual_obtn) {
					fecha_dp.CustomFormat = "MMMM yyyy";
				} else if (sender == anual_obtn) {
					fecha_dp.CustomFormat = "yyyy";
				}
			}

		}

		private ResponseDialog.Rangos getRango () {
			if ( Diario_obtn.Checked ) {
				return ResponseDialog.Rangos.Diario;
			} else if (mensual_obtn.Checked ) {
				return ResponseDialog.Rangos.Mensual;
			} else if (anual_obtn.Checked ) {
				return ResponseDialog.Rangos.Anual;
			}else {
				return ResponseDialog.Rangos.Diario;
			}
		}
		private void LineaFecha_frm_FormClosing ( object sender, FormClosingEventArgs e ) {
			try {
				if (DialogResult == DialogResult.OK) {
					if (linea_cb.SelectedIndex == -1) throw new Exception ( "Debe seleccionar una linea" );
					this.Response = new ResponseDialog ((Linea)linea_cb .SelectedItem , fecha_dp .Value , getRango () );
				}
			}
			catch (Exception ex) {
				KryptonTaskDialog.Show ( "Algo va mal...", "Error", ex.Message, MessageBoxIcon.Asterisk, TaskDialogButtons.OK );
				e.Cancel = true;
			}
			
		}
	}
}
