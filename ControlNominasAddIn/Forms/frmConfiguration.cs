using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ControlNominasAddIn.Forms {
	public partial class frmConfiguration : KryptonForm {
		OleDbConnectionStringBuilder PermisosStringBulder;
		OleDbConnectionStringBuilder Reloj1StringBulder;
		OleDbConnectionStringBuilder Reloj2StringBulder;
		public frmConfiguration ( ) {
			InitializeComponent ( );

			PermisosStringBulder = new OleDbConnectionStringBuilder ( Properties.Settings.Default.PermisosConnectionString );
			Reloj1StringBulder = new OleDbConnectionStringBuilder ( Properties.Settings.Default.Reloj1ConnectionString );
			Reloj2StringBulder = new OleDbConnectionStringBuilder ( Properties.Settings.Default.Reloj2ConnectionString );

			txtPermisosFileName.Text = PermisosStringBulder.DataSource;
			txtPermisosPassword.Text = PermisosStringBulder [ "Jet OLEDB:Database Password" ].ToString ( );

			txtReloj1File.Text = Reloj1StringBulder.DataSource;
			txtReloj1Password.Text = Reloj1StringBulder [ "Jet OLEDB:Database Password" ].ToString ( );

			txtReloj2File.Text = Reloj2StringBulder.DataSource;
			txtReloj2Password.Text = Reloj2StringBulder [ "Jet OLEDB:Database Password" ].ToString ( );
		}

		private void toolStripButton1_Click ( object sender , EventArgs e ) {
			PermisosStringBulder.DataSource = txtPermisosFileName.Text;
			PermisosStringBulder [ "Jet OLEDB:Database Password" ] = txtPermisosPassword.Text;

			Reloj1StringBulder.DataSource = txtReloj1File.Text;
			Reloj1StringBulder [ "Jet OLEDB:Database Password" ] = txtReloj1Password.Text;

			Reloj2StringBulder.DataSource = txtReloj2File.Text;
			Reloj2StringBulder [ "Jet OLEDB:Database Password" ] = txtReloj2Password.Text;


			var cf = ConfigurationManager.OpenExeConfiguration ( ConfigurationUserLevel.None );

			var constr = cf.ConnectionStrings.ConnectionStrings;

			constr [ "ControlNominasAddIn.Properties.Settings.PermisosConnectionString" ].ConnectionString = PermisosStringBulder.ConnectionString;
			constr [ "ControlNominasAddIn.Properties.Settings.Reloj1ConnectionString" ].ConnectionString = Reloj1StringBulder.ConnectionString;
			constr [ "ControlNominasAddIn.Properties.Settings.Reloj2ConnectionString" ].ConnectionString = Reloj2StringBulder.ConnectionString;

			ConfigurationManager.RefreshSection ( "connectionStrings" );
			Properties.Settings.Default.Save ( );
		}

		private void txtClaveChofer_Validating ( object sender , CancelEventArgs e ) {

			bool valid = System.Text.RegularExpressions.Regex.IsMatch ( txtClaveChofer.Text , @"^((?![A-Za-z .!""'%$/(){}[\]@\|&,;:¬°]).)*$" );

			if ( !valid ) {
				if ( KryptonTaskDialog.Show ( "Algo va mal..." , "Valor No Valido" , "La clave del chofer debe ser un valor numerico\nquiere reintentar editar el valor?" , MessageBoxIcon.Asterisk , TaskDialogButtons.Retry | TaskDialogButtons.Cancel ) == DialogResult.Retry ) {
					e.Cancel = true;
				} else {
					e.Cancel = false;
					Properties.Settings.Default.Reload ( );
				}
			};
		}

		private void frmConfiguration_Load ( object sender , EventArgs e ) {
			var themes = ( from PaletteModeManager tm in Enum.GetValues ( typeof ( PaletteModeManager ) )
						   select new { key = tm.ToString ( ) , value = tm } ).ToList ( );

			this.kpSelectTheme.DataSource = themes;
			this.kpSelectTheme.DisplayMember = "key";
			this.kpSelectTheme.ValueMember = "value";

			this.kpSelectTheme.DataBindings.Add ( new Binding ( "SelectedValue" , Properties.Settings.Default , "Theme" , true , DataSourceUpdateMode.OnPropertyChanged ) );
			this.kpSelectTheme.SelectedValueChanged += KpSelectTheme_SelectedValueChanged;

		}

		private void KpSelectTheme_SelectedValueChanged ( object sender , EventArgs e ) {
			this.kryptonManager1.GlobalPaletteMode = Properties.Settings.Default.Theme;
		}

		private void btnSearchFilePermisos_Click ( object sender , EventArgs e ) {

			string common = "Archivo de base de Datos para {0}";

			if ( sender == this.btnSearchFilePermisos || sender == this.seleccionarBaseDeDatosDePermisosToolStripMenuItem ) {
				openFileDialog1.FileName = txtPermisosFileName.Text;
				openFileDialog1.Title = String.Format ( common , "Permisos" );
			} else if ( sender == this.btnSearchFileReloj1 || sender == this.seleccionarBaseDeDatosDelReloj1ToolStripMenuItem ) {
				openFileDialog1.FileName = txtReloj1File.Text;
				openFileDialog1.Title = String.Format ( common , "Reloj1" );
			} else if ( sender == this.btnSearchFileReloj2 || sender == this.seleccionarBaseDeDatosDelReloj2ToolStripMenuItem ) {
				openFileDialog1.FileName = txtReloj2File.Text;
				openFileDialog1.Title = String.Format ( common , "Reloj2" );
			}


			if ( openFileDialog1.ShowDialog ( ) != DialogResult.OK )
				return;


			if ( sender == this.btnSearchFilePermisos || sender == this.seleccionarBaseDeDatosDePermisosToolStripMenuItem ) {
				txtPermisosFileName.Text = openFileDialog1.FileName;
			} else if ( sender == this.btnSearchFileReloj1 || sender == this.seleccionarBaseDeDatosDelReloj1ToolStripMenuItem ) {
				txtReloj1File.Text = openFileDialog1.FileName;
			} else if ( sender == this.btnSearchFileReloj2 || sender == this.seleccionarBaseDeDatosDelReloj2ToolStripMenuItem ) {
				txtReloj2File.Text = openFileDialog1.FileName;
			}

		}

		private void salirToolStripMenuItem_Click ( object sender , EventArgs e ) {
			this.Close ( );
		}
	}
}
