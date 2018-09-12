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
	public partial class frmTiposResiduo : KryptonForm
	{
		private bool _isAdding = false;
		private bool isAdding
		{
			get { return _isAdding; }
			set
			{
				_isAdding = value;
				riesgoKryptonComboBox.Enabled = value;
				unidadKryptonComboBox.Enabled = value;
				descripcionKryptonTextBox.Enabled = value;


				this.tipoRPKryptonDataGridView.Enabled = !value;
				bindingNavigatorAddNewItem.Enabled = !value;
				editToolStripButton.Enabled = tipoRPBindingSource.Count > 0 ? !value : false;
				cancelToolStripButton.Enabled = value;
				bindingNavigatorPositionItem.Enabled = !value;
				bindingNavigatorDeleteItem.Enabled = tipoRPBindingSource.Count > 0 ? !value : false;
			}
		}
		private libProduccionDataBase.Contexto.DataBaseContexto DB;
		public frmTiposResiduo ()
		{
			InitializeComponent ( );
			DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );
			riesgoKryptonComboBox.DataSource = Enum.GetValues ( typeof ( libProduccionDataBase.Tablas.TipoRP.Riesgos ) );
			unidadKryptonComboBox.DataSource = Enum.GetValues ( typeof ( libProduccionDataBase.Tablas.TipoRP.Unidades ) );
			this.isAdding = false;
		}

		private void frmTiposResiduo_Load ( object sender, EventArgs e )
		{
			DB.TiposRP.LoadAsync ( );
			this.tipoRPBindingSource.DataSource = DB.TiposRP.Local.ToBindingList ( );
		}

		private void tipoRPBindingNavigatorSaveItem_Click ( object sender, EventArgs e )
		{
			try
			{
				this.tipoRPBindingSource.EndEdit ( );
				DB.SaveChanges ( );
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

		private void isAdding_Click ( object sender, EventArgs e )
		{
			this.isAdding = true;
		}

		private void toolStripButton2_Click ( object sender, EventArgs e )
		{
			this.tipoRPBindingSource.CancelEdit ( );
			this.isAdding = false;
		}
	}
}
