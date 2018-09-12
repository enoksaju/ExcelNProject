using ComponentFactory.Krypton.Toolkit;
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

namespace ControlResiduosPeligrosos.Catalogos
{
	public partial class frmTransportistas : KryptonForm
	{
		private libProduccionDataBase.Contexto.DataBaseContexto DB;
		private bool _isAdding = false;
		private bool isAdding
		{
			get
			{
				return this._isAdding;
			}
			set
			{
				this._isAdding = value;
				denominacionKryptonTextBox.Enabled = value;
				autSEMARNATKryptonTextBox.Enabled = value;
				domicilioKryptonTextBox.Enabled = value;
				cPKryptonTextBox.Enabled = value;
				municipioKryptonTextBox.Enabled = value;
				estadoKryptonTextBox.Enabled = value;
				telefonoKryptonTextBox.Enabled = value;
				regSCTKryptonTextBox.Enabled = value;

				this.kryptonDataGridView1.Enabled = !value;
				bindingNavigatorAddNewItem.Enabled = !value;
				editToolStripButton.Enabled = trasportistaBindingSource.Count > 0 ? !value : false;
				cancelToolStripButton.Enabled = value;

				bindingNavigatorPositionItem.Enabled = !value;
				bindingNavigatorDeleteItem.Enabled = trasportistaBindingSource.Count > 0 ? !value : false;
			}
		}

		public frmTransportistas ()
		{
			InitializeComponent ( );
			DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );
			DB.Database.Log = Console.Write;
			this.isAdding = false;
		}

		private async void frmProveedores_Load ( object sender, EventArgs e )
		{
			await DB.Transportistas.LoadAsync ( );
			trasportistaBindingSource.DataSource = DB.Transportistas.Local.ToBindingList ( );
		}

		private async void proveedorBindingNavigatorSaveItem_Click ( object sender, EventArgs e )
		{
			try
			{
				this.trasportistaBindingSource.EndEdit ( );
				await DB.SaveChangesAsync ( );
			}
			catch ( Exception ex )
			{
				MessageBox.Show ( this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
			finally
			{
				this.isAdding = false;
			}

		}

		private void kryptonPanel1_Paint ( object sender, PaintEventArgs e )
		{

		}

		private void isAdding_Click ( object sender, EventArgs e )
		{
			this.isAdding = true;
		}

		private void cancelToolStripButton_Click ( object sender, EventArgs e )
		{
			this.trasportistaBindingSource.CancelEdit ( );
			this.isAdding = false;
		}
	}
}
