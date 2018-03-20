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
    public partial class CatalogoMaquinas : BaseForm.BaseFormCatalogos, ICatalogForm
    {
        public CatalogoMaquinas( DataBaseContexto DB ) : base( DB )
        {
            InitializeComponent();           
        }

        private async void CatalogoMaquinas_Load( object sender, EventArgs e )
        {
            LoaderPicktureBox.Visible = true;
            OnStatusStringChanged( new ChangeStatusMessageEventArgs { Title = "Cargando..", Message = "Cargando Clientes..." } );


                if (!Program.IsChangingTheme)
                {
                    await DB.TiposMaquina.LoadAsync();
                    await DB.Maquinas.LoadAsync();
                    await DB.Lineas.LoadAsync();
                }


            lineaBindingSource.DataSource = DB.Lineas.Local.ToBindingList();
            tipoMaquinaBindingSource.DataSource = DB.TiposMaquina.Local.ToBindingList();
            maquinaBindingSource.DataSource = this.DB.Maquinas.Local.ToBindingList();
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
            // base.Editar( sender, e );

            var frm= new CatalogosAddEdit.AgregarEditarMaquina(this, (Maquina)maquinaBindingSource.Current);

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
            var frm= new CatalogosAddEdit.AgregarEditarMaquina(this);

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
            HandledException( new Exception( "Una maquina no se puede eliminar desde la aplicación.\nContacte al Administrador de la Base de Datos para procesar la acción." ) );
        }

        /// <summary>
        /// Refresca los elementos de la coleccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async override void Actualizar( object sender, EventArgs e )
        {
            LoaderPicktureBox.Visible = true;
            this.kryptonDataGridView1.Enabled = false;
            OnStatusStringChanged( new ChangeStatusMessageEventArgs { Title = "Cargando..", Message = "Cargando Clientes..." } );

            //await Task.Run( () =>
            //{

            //    ((System.Data.Entity.Infrastructure.IObjectContextAdapter)this.DB)
            //   .ObjectContext
            //   .Refresh( System.Data.Entity.Core.Objects.RefreshMode.StoreWins, DB.Maquinas );

            //} );

            await DB.Maquinas.LoadAsync();

            maquinaBindingSource.DataSource = DB.Maquinas.Local.ToBindingList();
            maquinaBindingSource.ResetBindings( false );
            this.kryptonDataGridView1.Invalidate(); ;

            LoaderPicktureBox.Visible = false;
            this.kryptonDataGridView1.Enabled = true;
            OnStatusStringChanged( new ChangeStatusMessageEventArgs { Title = "Listo", Message = "Listo" } );
        }

        /// <summary>
        /// Filtra la coleccion y busca lo elementos que contengal un valor parecido al string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="SearchString"></param>
        public override void Buscar( object sender, string SearchString )
        {
            if (SearchString.Trim() == String.Empty) { Actualizar( this, null ); return; }

            var filter = DB.Maquinas.Local
                 .Where(x => x.NombreMaquina.ToLower().Contains(SearchString.ToLower()) || x.Linea.Nombre.ToLower().Contains(SearchString.ToLower()));
            maquinaBindingSource.DataSource = filter;
        }

        private void kryptonDataGridView1_DataError( object sender, DataGridViewDataErrorEventArgs e )
        {
            Console.WriteLine( e.Exception.Message );
        }
    }
}
