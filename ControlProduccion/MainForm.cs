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
using WeifenLuo.WinFormsUI.Docking;

namespace ControlProduccion
{
    public partial class MainForm : Form
    {
        DataBaseContexto DB;
        Catalogos.ClientesCatalogoForm ClientesCatalogForm;
        Catalogos .MaterialesCatalogoForm MaterialesCatalogForm;


        ConfiguracionForms.BasculaConfigForm BasculaConfigForm;
        

        public MainForm()
        {

            InitializeComponent();
            DB = new DataBaseContexto();
            this.visualStudioToolStripExtender1.SetStyle( statusStrip1, WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender.VsVersion.Vs2015, this.VS2015Theme );
            DB.Database.Log = Console.WriteLine;          

        }        

        private void Form1_Load( object sender, EventArgs e )
        {            
            controlBascula.Initialize();
        }

        #region AperturadeCatalogos

        private void ClientesCatalogRibbonButton_Click( object sender, EventArgs e )
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
        private void MaterialesCatalogRibbonButton_Click( object sender, EventArgs e )
        {
            if(MaterialesCatalogForm == null)
            {
                DB.FamiliasMateriales.Include( t => t.Materiales ).Load();
                MaterialesCatalogForm = new Catalogos.MaterialesCatalogoForm(DB);
                MaterialesCatalogForm.StatusStringChanged += CatalogosStatusStringChanged;
            }

            // TODO: Falta agregar los roles para inhabiliar funciones
            MaterialesCatalogForm.Show( dockPanel1, Catalogos.CatalogosBaseForm.FlagActiveFunctions.Todas );
        }

        #endregion

        private void CatalogosStatusStringChanged( object sender, Catalogos.ChangeStatusMessageEventArgs e )
        {
            Task.Run( () =>
            {
                setStatusMessage( e.Message );
                System.Threading.Thread.Sleep( 5000 );
                setStatusMessage( "Listo" );
            } );

        }

        private void setStatusMessage( string value )
        {
            if (statusStrip1.InvokeRequired)
            {
                statusStrip1.Invoke( new Action<string>( setStatusMessage ), value );
                return;
            }

            StatusToolStripStatusLabel.Text = value;
        }

        private void ConectarBasculaRibbonButton_Click( object sender, EventArgs e )
        {
            controlBascula.toogleConection();
        }
        private void controlBascula_CambioValor( object sender, libBascula.CambioValorEventArgs e )
        {
            // BasculaToolStripStatusLabel.Text = String.Format("{0:N2} kg", e.NuevoValor);
        }

        private void ConfigurarBasculaRibbonButton_Click( object sender, EventArgs e )
        {
            if (BasculaConfigForm == null)
            {
                BasculaConfigForm = new ConfiguracionForms.BasculaConfigForm( this.controlBascula );
            }

            BasculaConfigForm.Show( dockPanel1 );
        }

        private void button1_Click( object sender, EventArgs e )
        {
            controlBascula.CaracterFinLinea = "0A";
        }

        private void controlBascula_CambioEstado( object sender, libBascula.EstadoConexion e )
        {
            switch (e)
            {
                case libBascula.EstadoConexion.Conectado:
                    ConectarBasculaRibbonButton.Text = "Desconectar";
                    break;
                case libBascula.EstadoConexion.Desconectado:
                    ConectarBasculaRibbonButton.Text = "Conectar";
                    break;
                default:
                    break;
            }
        }

        private void GuardarRibbonButton_Click( object sender, EventArgs e )
        {
            IActionsDockContent actionForm= dockPanel1.ActiveContent as IActionsDockContent;
            if (actionForm!= null) actionForm.Guardar();
        }

        private void CerrarRibbonButton_Click( object sender, EventArgs e )
        {
            IActionsDockContent actionForm= dockPanel1.ActiveContent as IActionsDockContent;
            if (actionForm != null) actionForm.Cancelar();
        }

        private void ribbonButton2_Click( object sender, EventArgs e )
        {
            var frm= new TryDocument();
            frm.Show( dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.Document );
        }


    }
}
