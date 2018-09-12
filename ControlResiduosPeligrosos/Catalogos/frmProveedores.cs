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
	public partial class frmProveedores : KryptonForm
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

				this.kryptonDataGridView1.Enabled = !value;
				bindingNavigatorAddNewItem.Enabled = !value;
				editToolStripButton.Enabled = proveedorBindingSource.Count >0 ? !value : false;	
				cancelToolStripButton.Enabled = value;

				bindingNavigatorPositionItem.Enabled = !value;
				bindingNavigatorDeleteItem.Enabled = proveedorBindingSource.Count > 0 ? !value : false;
			}
		}


		public frmProveedores ()
		{
			InitializeComponent ( );
			DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );
			DB.Database.Log = Console.Write;
			this.isAdding = false;
		}

		private async void frmProveedores_Load ( object sender, EventArgs e )
		{
			await DB.Proveedores.LoadAsync ( );
			proveedorBindingSource.DataSource = DB.Proveedores.Local.ToBindingList ( );
		}

		private async void proveedorBindingNavigatorSaveItem_Click ( object sender, EventArgs e )
		{
			try
			{
				this.proveedorBindingSource.EndEdit ( );
				await DB.SaveChangesAsync ( );
			}
			catch ( Exception ex )
			{
				MessageBox.Show ( ex.Message );
			}
			finally
			{
				this.isAdding = false;
			}

		}

		private void bindingNavigatorAddNewItem_Click ( object sender, EventArgs e )
		{
			this.isAdding = true;
		}

		private void editToolStripButton_Click ( object sender, EventArgs e )
		{
			this.isAdding = true;
		}

		private void toolStripButton1_Click ( object sender, EventArgs e )
		{
			this.proveedorBindingSource.CancelEdit ( );
			this.isAdding = false;
		}
	}
}
