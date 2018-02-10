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
using WeifenLuo.WinFormsUI.Docking;

namespace ExcelNoblezaControlProduccion
{
    public partial class MainForm : KryptonForm
    {
        private System.Timers.Timer TimerStatus = new System.Timers.Timer(3000);
        private DeserializeDockContent m_deserializeDockContent;

        DataBaseContexto DB;

        // Formularios de Configuracion
        ConfiguracionForms.BasculaConfigForm BasculaConfigForm;

        //Formularios de Catalogos
        DockContents.Catalogos.CatalogoClientes CatalogoClientes;
        DockContents.Catalogos.CatalogoMateriales CatalogoMateriales;

        public MainForm()
        {
            InitializeComponent();
            DB = new DataBaseContexto();
            DB.Database.Log = Console.WriteLine;
            this.TimerStatus.Elapsed += TimerStatus_Tick;

            this.TimerStatus.AutoReset = false;

            m_deserializeDockContent = new DeserializeDockContent( GetContentFromPersistString );

            // Lee la configuracion del tema y lo aplica.
            this.Theme_Blue_kryptonContextMenuRadioButton.Checked = global::ExcelNoblezaControlProduccion.Properties.Settings.Default.Theme_Blue_Active;
            this.Theme_Dark_kryptonContextMenuRadioButton.Checked = global::ExcelNoblezaControlProduccion.Properties.Settings.Default.Theme_Dark_Active;
            this.Theme_Silver_kryptonContextMenuRadioButton.Checked = global::ExcelNoblezaControlProduccion.Properties.Settings.Default.Theme_Silver_Active;

        }

        private void MainForm_Load( object sender, EventArgs e )
        {
            controlBascula.Initialize();
            DB.Database.CompatibleWithModel( true );
        }


        /// <summary>
        /// Controla lo que sucede cuando cambia el DockContent del dockPanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dockPanel1_ActiveContentChanged( object sender, EventArgs e )
        {
            DockContents.IActionsDockContent t=  dockPanel1.ActiveContent as DockContents.IActionsDockContent;

            if (t != null)
            {
                this.kryptonRibbon1.SelectedContext = "AddOrEditCatalogs";
                kryptonRibbon1.SelectedTab = AddOrEditCatalogsKryptonRibbonTab;
                return;
            };

            this.kryptonRibbon1.SelectedContext = "";
        }


        #region Apertura Catalogos

        /// <summary>
        /// Crea y muestra el Catalogo de Clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kryptonRibbonGroupButton1_Click( object sender, EventArgs e )
        {
            openAndShowFormCatalog(
                ref CatalogoClientes,
                b => new DockContents.Catalogos.CatalogoClientes( b ),
                DockContents.ICatalogFormEnums.FlagActiveFunctions.Todas
                );
        }
        /// <summary>
        /// Crea  y muestra el catalogo de Clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kryptonRibbonGroupButton2_Click( object sender, EventArgs e )
        {
            openAndShowFormCatalog(
                ref CatalogoMateriales,
                b => new DockContents.Catalogos.CatalogoMateriales( b ),
                DockContents.ICatalogFormEnums.FlagActiveFunctions.Todas
                );
        }

        /// <summary>
        /// Crea y muestra un Formulario de catalogo
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="CatalogForm">Formulario que se mostrara, debe declararce como variable o propiedad en el contenedor</param>
        /// <param name="New">Delegado para creacion de un formulario nuevo</param>
        /// <param name="ActiveFunctionsFlag">Forma de apertura del Formulario</param>
        /// <returns></returns>
        private void openAndShowFormCatalog<t>(ref t CatalogForm, Func<DataBaseContexto, t> New, DockContents.ICatalogFormEnums.FlagActiveFunctions ActiveFunctionsFlag )
        {
            Task.Run( () =>
            {
                setStatusMessage( "Cargando el Formulario..." );
            } );            

            if (CatalogForm == null)
            {
                CatalogForm = New( DB );

                DockContents.ICatalogForm ct = CatalogForm as DockContents.ICatalogForm;
                if (ct != null) ct.StatusStringChanged += CambioEstadoFormCatalog;
            }

            (CatalogForm as DockContents.ICatalogForm)?.Show( dockPanel1, ActiveFunctionsFlag );
        }


        #endregion

        #region Acciones Add or Edit Catalogs


        /// <summary>
        /// Dispara la accion Guardar para el IActionsDockContent seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatalogAction_Guardar_krb_Click( object sender, EventArgs e )
        {
            (dockPanel1.ActiveContent as DockContents.IActionsDockContent)?.Guardar();
        }

        /// <summary>
        /// Dispara la accion Cancelar para el IActionsDockContent seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatalogAction_Cancelar_krb_Click( object sender, EventArgs e )
        {
            (dockPanel1.ActiveContent as DockContents.IActionsDockContent)?.Cancelar();
        }

        /// <summary>
        /// Dispara la accion Agregar Nuevo para el IActionsDockContent seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatalogAction_Nuevo_krb_Click( object sender, EventArgs e )
        {
            (dockPanel1.ActiveContent as DockContents.IActionsDockContent)?.AgregarNuevo();
        }

        /// <summary>
        /// Dispara la accion Refrescar para el IActionsDockContent seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatalogAction_Refrescar_krb_Click( object sender, EventArgs e )
        {
            (dockPanel1.ActiveContent as DockContents.IActionsDockContent)?.Refrescar();
        }

        #endregion

        #region Tema y Persistencia del DockingPanel

        /// <summary>
        /// Cambia el tema del MainForm con base al RaddioButton que se encuentre marcado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Theme_CheckedChanged( object sender, EventArgs e )
        {
            var obj= sender as KryptonContextMenuRadioButton;

            Properties.Settings.Default.Theme_Blue_Active = false;
            Properties.Settings.Default.Theme_Dark_Active = false;
            Properties.Settings.Default.Theme_Silver_Active = false;

            if (obj.Checked)
            {
                if (sender == Theme_Blue_kryptonContextMenuRadioButton)
                {
                    this.kryptonManager1.GlobalPalette = this.kryptonPaletteBlue;
                    SetThemeDockPanel( 1 );
                    Properties.Settings.Default.Theme_Blue_Active = true;
                }
                else if (sender == Theme_Dark_kryptonContextMenuRadioButton)
                {
                    this.kryptonManager1.GlobalPalette = this.kryptonPaletteDark;
                    SetThemeDockPanel( 2 );
                    Properties.Settings.Default.Theme_Dark_Active = true;
                }
                else if (sender == Theme_Silver_kryptonContextMenuRadioButton)
                {
                    kryptonManager1.GlobalPalette = this.kryptonPaletteSilver;
                    SetThemeDockPanel( 1 );
                    Properties.Settings.Default.Theme_Silver_Active = true;
                }
                else
                {
                    kryptonManager1.GlobalPalette = this.kryptonPaletteSilver;
                    SetThemeDockPanel( 1 );
                    Properties.Settings.Default.Theme_Silver_Active = true;
                }
            }

        }

        /// <summary>
        /// Configura el tema del DockPanel
        /// </summary>
        /// <param name="val">Indica el tema que se configurara:{ [1] Light, [2] Dark }</param>
        private void SetThemeDockPanel( int val )
        {
            // Persist settings when rebuilding UI
            string configFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.temp.config");
            dockPanel1.SaveAsXml( configFile );

            Program.IsChangingTheme = true;
            CloseAllDocuments();

            switch (val)
            {
                case 1:
                    this.dockPanel1.Theme = this.VS2015Light;
                    break;

                case 2:
                    this.dockPanel1.Theme = this.VS2015Dark;
                    break;
                default:
                    this.dockPanel1.Theme = this.VS2015Light;
                    break;
            }

            if (System.IO.File.Exists( configFile )) dockPanel1.LoadFromXml( configFile, m_deserializeDockContent );
            Program.IsChangingTheme = false;

        }

        /// <summary>
        /// Cierra todos los Documentos Y DockContents del main form
        /// </summary>
        private void CloseAllDocuments()
        {
            foreach (IDockContent document in dockPanel1.DocumentsToArray())
            {
                // IMPORANT: dispose all panes.
                document.DockHandler.DockPanel = null;
                document.DockHandler.Close();
            }

            dockPanel1.Contents.ToList().ForEach( t =>
            {
                t.DockHandler.DockPanel = null;
                t.DockHandler.Close();
            } );
        }

        /// <summary>
        /// Obtiene el contenido del archivo de persistencia, y lo devuelve a la ventana.
        /// </summary>
        /// <param name="persistString"></param>
        /// <returns></returns>
        private IDockContent GetContentFromPersistString( string persistString )
        {
            // TODO: se debe agregar las acciones para cada tipo encontrado en el archivo

            if (persistString == typeof( DockContents.Catalogos.CatalogoClientes ).ToString())
            {
                this.CatalogoClientes?.Dispose();
                this.CatalogoClientes = new DockContents.Catalogos.CatalogoClientes( DB );
                return this.CatalogoClientes;
            }
            else if (persistString == typeof( DockContents.Catalogos.CatalogoMateriales ).ToString()) {
                this.CatalogoMateriales?.Dispose();
                this.CatalogoMateriales = new DockContents.Catalogos.CatalogoMateriales( DB );
                return this.CatalogoMateriales;
            }
            else if (persistString == typeof( ConfiguracionForms.BasculaConfigForm ).ToString())
            {
                this.BasculaConfigForm?.Dispose();
                this.BasculaConfigForm = new ConfiguracionForms.BasculaConfigForm( this.controlBascula );
                return this.BasculaConfigForm;
            }
            else
            {
                // DummyDoc overrides GetPersistString to add extra information into persistString.
                // Any DockContent may override this value to add any needed information for deserialization.

                //string[] parsedStrings = persistString.Split(new char[] { ',' });
                //if (parsedStrings.Length != 3)
                //    return null;

                //if (parsedStrings[0] != typeof( DummyDoc ).ToString())
                //    return null;

                //DummyDoc dummyDoc = new DummyDoc();
                //if (parsedStrings[1] != string.Empty)
                //    dummyDoc.FileName = parsedStrings[1];
                //if (parsedStrings[2] != string.Empty)
                //    dummyDoc.Text = parsedStrings[2];

                //return dummyDoc;
                return null;
            }
        }

        #endregion

        #region Control de Mensajes de estado

        public void CambioEstadoFormCatalog( object sender, DockContents.ChangeStatusMessageEventArgs e )
        {
            Task.Run( () =>
            {
                TimerStatus.Stop();
                setStatusMessage( e.Message );
                TimerStatus.Start();
            } );
        }
        private void TimerStatus_Tick( object sender, EventArgs e )
        {
            Task.Run( () => { setStatusMessage( "Listo" ); } );
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

            EstadoStatusLabelStrip.Text = value;
        }



        #endregion

        #region Control sobre la Bascula

        /// <summary>
        /// Cambia el estado actual de la bascula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasculaButtonSpecAny_Click( object sender, EventArgs e )
        {
            controlBascula.toogleConection();
        }

        /// <summary>
        /// Controla las acciones que se toman cuando el estado de conexion de la bascula cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void controlBascula_CambioEstado( object sender, libBascula.EstadoConexion e )
        {
            KryptonCommand cmd = e == libBascula.EstadoConexion.Conectado ? this.BasculaConectedkryptonCommand : null;
            KryptonCommand cmd2 = e == libBascula.EstadoConexion.Conectado ? this.BasculaFormKryptonCommand : null;
            BasculaFormButtonSpecAny.KryptonCommand = cmd2;
            BasculakryptonRibbonGroupButton.KryptonCommand = cmd;
            BasculaFormButtonSpecAny.Checked = e == libBascula.EstadoConexion.Conectado ? ButtonCheckState.Checked : ButtonCheckState.NotCheckButton;
        }

        /// <summary>
        /// Abre el formulario de configuracion de la bascula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bascula_ConfigurarkryptonRibbonGroupButton_Click( object sender, EventArgs e )
        {

            if (BasculaConfigForm == null)
            {
                BasculaConfigForm = new ConfiguracionForms.BasculaConfigForm( this.controlBascula );
            }

            BasculaConfigForm.Show( dockPanel1 );

        }

        #endregion

    }
}
