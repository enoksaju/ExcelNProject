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
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas;

namespace EstacionPesaje.DockContents.Catalogos
{
    public partial class CatalogoClientes : BaseForm.BaseFormCatalogos, ICatalogForm
    {

        public CatalogoClientes( DataBaseContexto DB ) : base( DB )
        {
            InitializeComponent();         
        }

        /// <summary>
        /// Carga Asincronica del Formulario, muestra la imagen del preloader si es necesario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CatalogoClientes_Load( object sender, EventArgs e )
        {
            LoaderPicktureBox.Visible = true;
            OnStatusStringChanged( new ChangeStatusMessageEventArgs { Title = "Cargando..", Message = "Cargando Clientes..." } );


            if (!Program.IsChangingTheme) await DB.Clientes.LoadAsync();


            clienteBindingSource.DataSource = this.DB.Clientes.Local.ToBindingList();
            LoaderPicktureBox.Visible = false;
            OnStatusStringChanged( new ChangeStatusMessageEventArgs { Title = "Listo", Message = "Listo" } );
        }


        /// <summary>
        /// Abre el formulario de editar un Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Editar( object sender, EventArgs e )
        {

            var frm= new CatalogosAddEdit.AgregarEditarCliente(this, (Cliente)clienteBindingSource.Current);

            MainForm mainfrm= this.DockPanel.FindForm() as MainForm;
            frm.StatusStringChanged += mainfrm.CambioEstadoFormCatalog;


            frm.Show( this.DockPanel );
        }

        /// <summary>
        /// Abre el formulario para agregar un Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Agregar( object sender, EventArgs e )
        {
            var frm= new CatalogosAddEdit.AgregarEditarCliente(this);

            MainForm mainfrm= this.DockPanel.FindForm() as MainForm;
            frm.StatusStringChanged += mainfrm.CambioEstadoFormCatalog;

            frm.Show( this.DockPanel );
        }

        /// <summary>
        /// Elimina un Item de la coleccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Eliminar( object sender, EventArgs e )
        {
            try
            {
                if (clienteBindingSource.Current != null && MessagesActionsAndForms.AskConfirmation( this ))
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

        /// <summary>
        /// Refresca los elementos de la coleccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async override void Actualizar( object sender, EventArgs e )
        {
            LoaderPicktureBox.Visible = true;
            clienteKryptonDataGridView.Enabled = false;
            OnStatusStringChanged( new ChangeStatusMessageEventArgs { Title = "Cargando..", Message = "Cargando Clientes..." } );

            await DB.Clientes.LoadAsync();

            clienteBindingSource.DataSource = DB.Clientes.Local.ToBindingList();
            clienteBindingSource.ResetBindings( false );
            clienteKryptonDataGridView.Invalidate(); 

            LoaderPicktureBox.Visible = false;
            clienteKryptonDataGridView.Enabled = true;
            OnStatusStringChanged( new ChangeStatusMessageEventArgs { Title = "Listo", Message = "Listo" } );
        }

        /// <summary>
        /// Filtra la coleccion y busca lo elementos que contengal un valor parecido al string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="SearchString"></param>
        public override void Buscar( object sender, string SearchString )
        {
            var filter = DB.Clientes.Local
                 .Where(x => x.NombreCliente.ToLower().Contains(SearchString.ToLower()) || x.ClaveCliente.ToLower().Contains(SearchString.ToLower()));
            clienteBindingSource.DataSource = filter;
        }

        /// <summary>
        /// Habilita el arrastre de Items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clienteKryptonDataGridView_MouseDown( object sender, MouseEventArgs e )
        {
            clienteKryptonDataGridView.DoDragDrop( clienteKryptonDataGridView.SelectedRows, DragDropEffects.All );
        }


    }
}
