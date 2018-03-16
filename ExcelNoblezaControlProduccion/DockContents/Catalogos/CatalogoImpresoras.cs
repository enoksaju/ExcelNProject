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

namespace EstacionesPesaje.DockContents.Catalogos
{
    public partial class CatalogoImpresoras : BaseForm.BaseFormCatalogos
    {
        public CatalogoImpresoras( DataBaseContexto DB ) : base( DB )
        {
            InitializeComponent();           
        }

        private async void CatalogoImpresoras_Load( object sender, EventArgs e )
        {
            LoaderPicktureBox.Visible = true;
            OnStatusStringChanged( new ChangeStatusMessageEventArgs { Title = "Cargando..", Message = "Cargando Impresoras..." } );


                if (!Program.IsChangingTheme) await DB.Maquinas
                    //.Include( r => r.Rodillos )
                    .LoadAsync();


            maquinaBindingSource.DataSource = this.DB.Maquinas.Local.Where( t => t.TipoMaquina_Id == 1 ).OrderBy( y => y.NombreMaquina ).ToList();//.ToBindingList();

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

            var frm= new CatalogosAddEdit.AgregarEditarImpresora(this, (Maquina)maquinaBindingSource.Current);

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
            var frm= new CatalogosAddEdit.AgregarEditarImpresora(this);

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
            HandledException( new Exception( "Una Impresora no se puede 'Eliminar' desde la aplicación.\n¡Contacte al Administrador del la Base de Datos para procesar la acción!." ) );
        }

        /// <summary>
        /// Refresca los elementos de la coleccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async override void Actualizar( object sender, EventArgs e )
        {
            LoaderPicktureBox.Visible = true;
            kryptonDataGridView1.Enabled = false;
            OnStatusStringChanged( new ChangeStatusMessageEventArgs { Title = "Cargando..", Message = "Cargando Maquinas..." } );

            //await Task.Run( () =>
            //{

            //    ((System.Data.Entity.Infrastructure.IObjectContextAdapter)this.DB)
            //   .ObjectContext
            //   .Refresh( System.Data.Entity.Core.Objects.RefreshMode.StoreWins, DB.Maquinas.Include(r=> r.Rodillos) );



            //} );

            await DB.Maquinas.Include( r => r.Rodillos ).LoadAsync();

            maquinaBindingSource.DataSource = this.DB.Maquinas.Local.Where( t => t.TipoMaquina_Id == 1 ).OrderBy( y => y.NombreMaquina ).ToList();//.ToBindingList();

            maquinaBindingSource.ResetBindings( false );
            kryptonDataGridView1.Invalidate(); ;

            LoaderPicktureBox.Visible = false;
            kryptonDataGridView1.Enabled = true;
            OnStatusStringChanged( new ChangeStatusMessageEventArgs { Title = "Listo", Message = "Listo" } );
        }

        /// <summary>
        /// Filtra la coleccion y busca lo elementos que contengal un valor parecido al string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="SearchString"></param>
        public override void Buscar( object sender, string SearchString )
        {
            double Number;

            bool IsNumber= Double.TryParse( SearchString,out Number );


            if (!IsNumber)
            {
                maquinaBindingSource.DataSource = this.DB.Maquinas.Local.Where( t => t.TipoMaquina_Id == 1 ).OrderBy( y => y.NombreMaquina ).ToList();
               
            }
            else
            {

                var _q= DB.Rodillos.Include(nameof(Rodillo.Maquina))
                .Where(i=> i.Medida == Number)
                .Select(_item=> new { _item, _item.Maquina} );//.Apariencia.ToLower().Contains(SearchString.ToLower())

                var Fam= from _fam in _q.ToArray()
                         group _fam
                     by _fam.Maquina.Id
                     into _coll
                         select Maquina.AttachRodillos(_coll.First().Maquina, _coll.Select(a=> a._item).ToList());

                maquinaBindingSource.DataSource = Fam;
            }


            maquinaBindingSource.ResetBindings(false);
            rodillosBindingSource.ResetBindings( false );

            kryptonDataGridView1.Invalidate();
            kryptonDataGridView2.Invalidate();



        }
    }

}
