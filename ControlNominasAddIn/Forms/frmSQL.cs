using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;

namespace ControlNominasAddIn.Forms {
	public partial class frmSQL : KryptonForm {

		private class ItemElement {
			public string Display { get; set; }
			public string Value { get; set; }
		}
		public frmSQL ( ) {
			InitializeComponent ( );

			List<ItemElement> source = new List<ItemElement> ( );

			OleDbConnectionStringBuilder cn = new OleDbConnectionStringBuilder ( Properties.Settings.Default.PermisosConnectionString );
			source.Add ( new ItemElement ( ) { Display = System.IO.Path.GetFileNameWithoutExtension ( cn.DataSource ) , Value = cn.ConnectionString } );
			cn.ConnectionString = Properties.Settings.Default.Reloj1ConnectionString;
			source.Add ( new ItemElement ( ) { Display = System.IO.Path.GetFileNameWithoutExtension ( cn.DataSource ) , Value = cn.ConnectionString } );
			cn.ConnectionString = Properties.Settings.Default.Reloj2ConnectionString;
			source.Add ( new ItemElement ( ) { Display = System.IO.Path.GetFileNameWithoutExtension ( cn.DataSource ) , Value = cn.ConnectionString } );

			cmbSchemas.ComboBox.DataSource = source;
			cmbSchemas.ComboBox.DisplayMember = "Display";
			cmbSchemas.ComboBox.ValueMember = "Value";

			cmbSchemas.ComboBox.SelectedValueChanged += ComboBox_SelectedValueChanged;

			cmbSchemas.SelectedIndex = -1;
		}

		private async void ComboBox_SelectedValueChanged ( object sender , EventArgs e ) {
			if ( cmbSchemas.ComboBox.SelectedValue != null )
				await FillTreeView ( cmbSchemas.ComboBox.SelectedValue.ToString ( ) );
		}

		private void toolStripButton1_Click ( object sender , EventArgs e ) {
			var t = new Forms.SQLPage ( );
			this.kryptonNavigator1.Pages.Add ( t.GetKryptonPage ( ) );
		}

		private void frmSQL_Load ( object sender , EventArgs e ) {

		}

		private async Task FillTreeView ( string stringConnection ) {
			try {
				tvSchema.Nodes.Clear ( );
				using ( var cnn = new OleDbConnection ( stringConnection ) ) {
					await cnn.OpenAsync ( );
					string [ ] restrictions = new string [ 4 ];
					restrictions [ 3 ] = "Table";
					var t = cnn.GetSchema ( "Tables" , restrictions );

					tvSchema.Nodes.Add ( this.makeNode ( t , cnn , "Tables" , 1 , 0 ) );

					restrictions [ 3 ] = "View";
					t = cnn.GetSchema ( "Tables" , restrictions );
					tvSchema.Nodes.Add ( this.makeNode ( t , cnn , "Vistas" , 2 , 0 ) );
					cnn.Close ( );
				}
			} catch ( Exception ex ) {
				KryptonTaskDialog.Show ( "Algo va mal..." , "Error" , ex.Message , MessageBoxIcon.Error , TaskDialogButtons.OK );
			}
		}
		private TreeNode makeNode ( DataTable tb , OleDbConnection cnn , string mainName , int childImageIndex , int? Imageindex = null ) {

			TreeNode mainTablesNode = Imageindex.HasValue ? new TreeNode ( mainName , Imageindex.Value , Imageindex.Value ) : new TreeNode ( mainName );

			foreach ( DataRow rw in tb.Rows ) {
				TreeNode TableNode = new TreeNode ( rw [ 2 ].ToString ( ) , childImageIndex , childImageIndex );
				string [ ] restrictionsTable = new string [ 4 ];
				restrictionsTable [ 2 ] = rw [ 2 ].ToString ( );

				var u = from DataRow dt in cnn.GetSchema ( "Columns" , restrictionsTable ).Rows
						orderby dt [ 6 ]
						select dt;

				foreach ( DataRow col in u ) {

					var Type_ = ( OleDbType ) col [ 11 ];
					int icon;
					switch ( Type_ ) {
						case OleDbType.WChar:
							icon = 3;
							break;
						case OleDbType.Integer:
						case OleDbType.SmallInt:
						case OleDbType.Numeric:
						case OleDbType.TinyInt:
						case OleDbType.BigInt:
						case OleDbType.Double:
						case OleDbType.Decimal:
						case OleDbType.Single:
							icon = 4;
							break;
						case OleDbType.Boolean:
							icon = 5;
							break;
						case OleDbType.Date:
						case OleDbType.DBDate:
						case OleDbType.DBTime:
						case OleDbType.DBTimeStamp:
							icon = 6;
							break;
						default:
							icon = 3;
							break;
					}

					TreeNode ColumnNode = new TreeNode ( col [ 3 ].ToString ( ) , icon , icon );

					ColumnNode.Tag = rw [ 2 ].ToString ( ) + "." + col [ 3 ].ToString ( );
					TableNode.Nodes.Add ( ColumnNode );


				}
				mainTablesNode.Nodes.Add ( TableNode );
			}

			return mainTablesNode;

		}
	}
}
