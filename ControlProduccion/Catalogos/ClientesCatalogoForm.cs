using libProduccionDataBase.Contexto;
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
using libProduccionDataBase.Tablas;

namespace ControlProduccion.Catalogos
{    
    public partial class ClientesCatalogoForm : CatalogosBaseForm
    {
        /// <summary>
        /// Inicializa una nueva instancia de la ventana de catalogos de clientes
        /// </summary>
        /// <param name="DB_">Contexto de la Base de datos</param>
        public ClientesCatalogoForm(DataBaseContexto DB_):base(DB_)
        {
            InitializeComponent();
            clienteBindingSource.DataSource = this.DB.Clientes.Local.ToBindingList();
            DB.SavedChanges += Actualizar;
        }

        private void ClientesCatalogoForm_Load(object sender, EventArgs e)
        {
            
        }

        public override void Agregar( object sender, EventArgs e )
        {
            var frm= new AddOrEditForms.ClienteAddEditForm(DB);

            frm.FormClosed += Frm_FormClosed;

            frm.Show( this.DockPanel);
        }

        private void Frm_FormClosed( object sender, FormClosedEventArgs e )
        {
            this.clienteBindingSource.ResetBindings(false);
            this.clienteKryptonDataGridView.Invalidate();
        }

        public override void Editar( object sender, EventArgs e )
        {
            var frm= new AddOrEditForms.ClienteAddEditForm(DB, (Cliente)clienteBindingSource.Current );

            frm.FormClosed += Frm_FormClosed;

            frm.Show( this.DockPanel  );
        }

        public override void Eliminar( object sender, EventArgs e )
        {
            try
            {
                if (clienteBindingSource.Current != null &&  MessagesActionsAndForms.AskConfirmation(this) )
                {
                    this.clienteBindingSource.RemoveCurrent();
                    DB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( libProduccionDataBase.Auxiliares.GetInnerException( ex ) );
            }
        }
        public override void Actualizar( object sender, EventArgs e )
        {
            ((System.Data.Entity.Infrastructure.IObjectContextAdapter)this.DB)
               .ObjectContext
               .Refresh( System.Data.Entity.Core.Objects.RefreshMode.StoreWins, DB.Clientes );
            
            clienteBindingSource.ResetBindings(false);
            clienteKryptonDataGridView.Invalidate(); ;
        }

        public override void Buscar( object sender, string SearchString )
        {
            var filter = DB.Clientes.Local
                 .Where(x => x.NombreCliente.ToLower().Contains(SearchString.ToLower()) || x.ClaveCliente.ToLower().Contains(SearchString.ToLower()));
            clienteBindingSource.DataSource = filter;
        }


        private void clienteKryptonDataGridView_MouseDown( object sender, MouseEventArgs e )
        {
            clienteKryptonDataGridView.DoDragDrop( clienteKryptonDataGridView.SelectedRows, DragDropEffects.All );
        }

    }
}
