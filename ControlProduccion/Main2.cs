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
using ComponentFactory.Krypton.Toolkit;
using libProduccionDataBase.Contexto;

namespace ControlProduccion
{
    public partial class Main2 : KryptonForm
    {

        DataBaseContexto DB;
        Catalogos.ClientesCatalogoForm ClientesCatalogForm;
        Catalogos .MaterialesCatalogoForm MaterialesCatalogForm;


        ConfiguracionForms.BasculaConfigForm BasculaConfigForm;


        /// <summary>
        /// Inicializa el formulario principal
        /// </summary>
        public Main2()
        {
            InitializeComponent();
            DB = new DataBaseContexto();
            //this.visualStudioToolStripExtender1.SetStyle( statusStrip1, WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender.VsVersion.Vs2012, this.VS2012LightTheme );
            DB.Database.Log = Console.WriteLine;
        }
        private void Main2_Load( object sender, EventArgs e )
        {

        }

        #region OpenForms Catalogos

        private void kryptonRibbonGroupButton1_Click( object sender, EventArgs e )
        {
            if (ClientesCatalogForm == null)
            {
                DB.Clientes.Load();
                ClientesCatalogForm = new Catalogos.ClientesCatalogoForm( DB );
                ClientesCatalogForm.StatusStringChanged += CatalogosStatusStringChanged;
            }

            // TODO: Falta agregar los roles para inhabiliar funciones
            ClientesCatalogForm.Show( dockPanel1, Catalogos.CatalogosBaseForm.FlagActiveFunctions.Todas );
        }

        private void kryptonRibbonGroupButton2_Click( object sender, EventArgs e )
        {
            if (MaterialesCatalogForm == null)
            {
                DB.FamiliasMateriales.Include(H=> H.Materiales).Load();
                MaterialesCatalogForm = new Catalogos.MaterialesCatalogoForm( DB );
                MaterialesCatalogForm.StatusStringChanged += CatalogosStatusStringChanged;
            }

            // TODO: Falta agregar los roles para inhabiliar funciones
            MaterialesCatalogForm.Show( dockPanel1, Catalogos.CatalogosBaseForm.FlagActiveFunctions.Todas );
        }        


        /// <summary>
        /// Handle que se dispara cuando un formulario envia un string de cambio de estado
        /// </summary>
        /// <param name="sender">objeto que disparó el evento</param>
        /// <param name="e">argumentos del evento</param>

        private void CatalogosStatusStringChanged( object sender, Catalogos.ChangeStatusMessageEventArgs e )
        {
            Task.Run( () =>
            {
                setStatusMessage( e.Message );
                System.Threading.Thread.Sleep( 5000 );
                setStatusMessage( "Listo" );
            } );

        }
        /// <summary>
        /// Asigna el valor del mensaje al status label.
        /// </summary>
        /// <param name="value">Mensaje a mostrar</param>
        private void setStatusMessage( string value )
        {
            if (statusStrip1.InvokeRequired)
            {
                statusStrip1.Invoke( new Action<string>( setStatusMessage ), value );
                return;
            }

            StatusToolStripStatusLabel.Text = value;
        }

        #endregion



        #region Bascula

        /// <summary>
        /// Controla el evento de cambio de estado de una bascula 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void controlBascula_CambioEstado( object sender, libBascula.EstadoConexion e )
        {
            buttonSpecAny1.Image = (e == libBascula.EstadoConexion.Conectado ? Properties.Resources.ScalesConnected_green : Properties.Resources.ScalesConnected_red);
            ConectarBasculaKryptonRibbonGroupButton.KryptonCommand = e == libBascula.EstadoConexion.Conectado ? this.SetConectedImageToKrypton : null;
        }

        /// <summary>
        /// Cambia la conexion de una bascula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toogleConnection_Click( object sender, EventArgs e )
        {
            controlBascula.toogleConection();
        }

        /// <summary>
        /// Abre la ventana de configuracion de la bascula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kryptonRibbonGroupButton5_Click( object sender, EventArgs e )
        {
            if (BasculaConfigForm == null)
            {
                BasculaConfigForm = new ConfiguracionForms.BasculaConfigForm( this.controlBascula );
            }

            BasculaConfigForm.Show( dockPanel1 );
        }

        #endregion

        private void kryptonRibbonGroupButton3_Click( object sender, EventArgs e )
        {
            var f= new Form1();
            f.Show( dockPanel1);
            
        }
    }
}
