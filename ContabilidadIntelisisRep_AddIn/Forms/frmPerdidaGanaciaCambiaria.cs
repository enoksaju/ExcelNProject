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
	public partial class frmPerdidaGanaciaCambiaria : Form {
		public enum Tipos { cxc, cxp }
		private Tipos Tipo;
		public frmPerdidaGanaciaCambiaria ( Tipos tipo ) {
			InitializeComponent ( );
			//this.AutoValidate =AutoValidate.Disable;
			this.Tipo = tipo;
			this.Text = $"Pérdida/Ganancia Cambiaria { ( Tipo == Tipos.cxc ? "Cxc" : "Cxp" )}";

			this.TipoAnticipo_cmb.DataSource = Enum.GetValues ( typeof ( Modelos.Tipos ) );

		}
		private async void frmPerdidaGanaciaCambiaria_Load ( object sender , EventArgs e ) {
			using (var db= new Context.dataBaseContext ( ) ) {
				var list= await db.Database.SqlQuery<string> ( @"SELECT [Moneda] FROM [ExcelNobleza].[dbo].[Mon] order by [Orden]" ).ToListAsync();
				comboBox1.DataSource = list;
				comboBox1.SelectedIndex = 1;
			}
		}
		private void textBox1_Validating ( object sender , CancelEventArgs e ) {
			errorProvider1.SetError ( ( TextBox ) sender , isNumeric ( ( ( TextBox ) sender ).Text ) ? "" : "Debe ingresar un valor numérico" );
		}
		private void panel1_Validating ( object sender , CancelEventArgs e ) {
			errorProvider1.SetError ( panel1 , errorProvider1.GetError ( textBox1 ) != "" ? errorProvider1.GetError ( textBox1 ) : "" );
			e.Cancel = errorProvider1.GetError ( textBox1 ) != "" ? true : false;
		}
		private bool isNumeric ( string value ) {
			double ret;
			return double.TryParse ( value , out ret );
		}
		private async void button1_Click ( object sender , EventArgs e ) {
			try {
				if ( this.ValidateChildren ( ValidationConstraints.Enabled | ValidationConstraints.ImmediateChildren ) ) {
					this.Text = $"Pérdida/Ganancia Cambiaria { ( Tipo == Tipos.cxc ? "Cxc" : "Cxp" )} [{dateTimePicker1.Value.ToString ( "dd/MM/yyyy" )}] [{(( string ) comboBox1.SelectedValue).Trim()}] - Cargando...";
					dateTimePicker1.Enabled = false;
					textBox1.Enabled = false;
					button1.Enabled = false;
					setValueList ( Tipo == Tipos.cxc ? await Modelos.perdidaGananciaCambiaria.getCxcAsync ( dateTimePicker1.Value , double.Parse ( textBox1.Text ) ,( string )comboBox1.SelectedValue, ( Modelos.Tipos ) TipoAnticipo_cmb.SelectedItem ) : await Modelos.perdidaGananciaCambiaria.getCxpAsync ( dateTimePicker1.Value , double.Parse ( textBox1.Text ), (string)comboBox1.SelectedValue , (Modelos .Tipos ) TipoAnticipo_cmb .SelectedItem ) );
					return;
				}
				throw new Exception ( errorProvider1.GetError ( textBox1 ) );			
			} catch ( Exception ex) {
				MessageBox.Show ( this , ex.Message  , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error );
			}			
		}

		private void setValueList(List<Modelos.perdidaGananciaCambiaria> value ) {

			if(perdidaGananciaCambiariaDataGridView .InvokeRequired ) {
				perdidaGananciaCambiariaDataGridView.Invoke ( new Action<List<Modelos.perdidaGananciaCambiaria>> ( setValueList ) , value );
				return;
			}
			perdidaGananciaCambiariaBindingSource.DataSource = value;
			this.Text = $"Pérdida/Ganancia Cambiaria { ( Tipo == Tipos.cxc ? "Cxc" : "Cxp" )} [{dateTimePicker1.Value.ToString ( "dd/MM/yyyy" )}] [{( ( string ) comboBox1.SelectedValue ).Trim ( )}]";
			dateTimePicker1.Enabled = true;
			textBox1.Enabled = true;
			button1.Enabled = true;
		}		

		private void Control_KeyUp ( object sender , KeyEventArgs e ) {
			if ( e.KeyCode == Keys.Enter ) {
				button1_Click ( sender , null );
			}
		}

		
	}
}
