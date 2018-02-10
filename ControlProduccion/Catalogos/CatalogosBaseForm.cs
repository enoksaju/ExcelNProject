using libProduccionDataBase.Contexto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ControlProduccion.Catalogos
{

    /// <summary>
    /// <para>Clase Base para los formularios de Catalogos</para>
    /// <para>Los Formularios de catalogo deben heredarse de esta clase y sobreescribir los metodos virtuales</para>
    /// </summary>
    public partial class CatalogosBaseForm : DockContent
    {
        public delegate void ChangeStatusMessage( object sender, ChangeStatusMessageEventArgs e );

        private FlagActiveFunctions _ActiveFunctions = FlagActiveFunctions.Ninguno;

        /// <summary>
        /// Se desencadena cuando el estado del formulario ha cambiado.
        /// </summary>
        [Description("Se desencadena cuando el estado del formulario ha cambiado")]
        [Category("CatalogBaseForm")]
        public event ChangeStatusMessage StatusStringChanged;

        /// <summary>
        /// Banderas para identificar la funcion del formulario
        /// </summary>
        [Flags]
        public enum FlagActiveFunctions
        {
            Ninguno = 0x0,
            Editar = 0x1,
            Buscar = 0x2,
            Detalles = 0x4,
            EditarYDetalles = Editar | Detalles,
            EditarYBuscar = Editar | Buscar,
            BuscarYDetalles = Buscar | Detalles,
            Todas = Editar | Detalles | Buscar
        }

        /// <summary>
        /// <para>Contexto de la Base de datos que contiene los metodos para conexion a ala base de datos y las colecciones de las entidades</para>
        /// <para>Requiere <code>Using System.Data.Entity</code></para>
        /// </summary>
        public DataBaseContexto DB { get; set; }

        /// <summary>
        /// Funciones que estaran activas en el formulario
        /// </summary>
        public FlagActiveFunctions ActiveFunctions
        {
            get
            {
                return _ActiveFunctions;
            }
            set
            {
                _ActiveFunctions = value;
                ConfigureUse();
            }
        }



        public CatalogosBaseForm()
        {
            // Inicializa los Componentes
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            // Agreagar Manejo de Eventos de los controles comunes
            SetHandledButtons();
            // Configura el estilo de los toolstrip para el tema del control Dock donde se aloja el control
            ConfigureToolStripStyle();
        }
        public CatalogosBaseForm( DataBaseContexto DB )
        {
            // Inicializa los Componentes
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            // Le da valores a los parametros
            this.DB = DB;
            this.ActiveFunctions = ActiveFunctions;

            // Agreagar Manejo de Eventos de los controles comunes
            SetHandledButtons();
            // Configura el estilo de los toolstrip para el tema del control Dock donde se aloja el control
            ConfigureToolStripStyle();
        }

        /// <summary>
        /// Agrega las acciones que deben tomar los Controles al ser usados por el Cliente
        /// </summary>
        private void SetHandledButtons()
        {
            RefreshToolStripButton.Click += Actualizar;
            AddNewToolStripButton.Click += Agregar;
            DeleteCurrentToolStripButton.Click += Eliminar;
            EditCurrentToolStripButton.Click += Editar;
            SearchToolStripButton.Click += Search;
            ToSearchTextBox.KeyDown += ToSearchTextBox_KeyDown;
            showDetallesToolStripButton.Click += showDetails;
        }

        /// <summary>
        /// Configura el aspecto visual de los toolstrip
        /// </summary>
        private void ConfigureToolStripStyle()
        {
            //this.visualStudioToolStripExtender1.SetStyle(toolStrip1, VisualStudioToolStripExtender.VsVersion.Vs2015, this.VS2015Theme);
           // this.visualStudioToolStripExtender1.SetStyle(toolStrip2, VisualStudioToolStripExtender.VsVersion.Vs2015, this.VS2015Theme);
        }

        private void CatalogosBaseForm_Load( object sender, EventArgs e ) { }

        /// <summary>
        /// Configura los controles que se desactivaran con base al modo de apertura del formulario
        /// </summary>
        private void ConfigureUse()
        {
            toolStrip2.Visible = this.ActiveFunctions.HasFlag(FlagActiveFunctions.Buscar);

            AddNewToolStripButton.Enabled = this.ActiveFunctions.HasFlag(FlagActiveFunctions.Editar);
            EditCurrentToolStripButton.Enabled = this.ActiveFunctions.HasFlag(FlagActiveFunctions.Editar);
            DeleteCurrentToolStripButton.Enabled = this.ActiveFunctions.HasFlag(FlagActiveFunctions.Editar);

            showDetallesToolStripButton.Enabled = this.ActiveFunctions.HasFlag(FlagActiveFunctions.Detalles);
            OnStatusStringChanged(new ChangeStatusMessageEventArgs { Title = "Modo de Apertura", Message = String.Format("Abriendo {1} con las funciones: {0}", this.ActiveFunctions.ToString(), this.TabText) });
        }

        /// <summary>
        /// <para>Controla lo que sucede cuando se presiona una tecla en el TextBox de busqueda.</para>
        /// <para>Si se presiona la tecla Enter(Return) se llama al metodo virtual Buscar</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToSearchTextBox_KeyDown( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                Buscar(sender, ToSearchTextBox.Text);
            }
        }

        /// <summary>
        /// Controla lo que sucede al presionar el Boton de Busqueda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search( object sender, EventArgs e )
        {
            Buscar(sender, ToSearchTextBox.Text);
        }

        /// <summary>
        /// <para>Controla lo que sucede al presionar el botón Actualizar</para>
        /// <para>El metodo debe sobreescribirse en el formulario que Hereda</para>
        /// </summary>
        /// <param name="sender">Control que generó el evento</param>
        /// <param name="e"></param>
        public virtual void Actualizar( object sender, EventArgs e ) { HandledException(new NotImplementedException()); }

        /// <summary>
        /// <para>Controla lo que sucede al presionar el botón Agregar</para>
        /// <para>El metodo debe sobreescribirse en el formulario que Hereda</para>
        /// </summary>
        /// <param name="sender">Control que generó el evento</param>
        /// <param name="e"></param>
        public virtual void Agregar( object sender, EventArgs e ) { HandledException(new NotImplementedException()); }

        /// <summary>
        /// <para>Controla lo que sucede al presionar el botón Eliminar</para>
        /// <para>El metodo debe sobreescribirse en el formulario que Hereda</para>
        /// </summary>
        /// <param name="sender">Control que generó el evento</param>
        /// <param name="e"></param>
        public virtual void Eliminar( object sender, EventArgs e ) { HandledException(new NotImplementedException()); }

        /// <summary>
        /// <para>Controla lo que sucede al presionar el botón Editar</para>
        /// <para>El metodo debe sobreescribirse en el formulario que Hereda</para>
        /// </summary>
        /// <param name="sender">Control que generó el evento</param>
        /// <param name="e"></param>
        public virtual void Editar( object sender, EventArgs e ) { HandledException(new NotImplementedException()); }

        /// <summary>
        /// <para>Controla lo que sucede al Ejecutarse la accion de Busqueda</para>
        /// <para>El metodo debe sobreescribirse en el formulario que Hereda</para>
        /// </summary>
        /// <param name="sender">Control que generó el evento</param>
        /// <param name="SearchString">Cadena que se intenta buscar</param>
        public virtual void Buscar( object sender, string SearchString ) { HandledException(new NotImplementedException()); }

        /// <summary>
        /// <para>Controla lo que sucede al presionar el botón ShowDetails</para>
        /// <para>El metodo debe sobreescribirse en el formulario que Hereda</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void showDetails( object sender, EventArgs e ) { HandledException(new NotImplementedException()); }

        /// <summary>
        /// Controla lo que sucede con las excepciones
        /// </summary>
        /// <param name="ex">Excepcion a analizar</param>
        public virtual void HandledException( Exception ex )
        {
            MessageBox.Show(this, ex.Message, "Algo va mal...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        

        public void Show( DockPanel Panel, FlagActiveFunctions Functions )
        {
            this.Show(Panel);
            this.ActiveFunctions = Functions;
        }

        /// <summary>
        /// Invoka al evento StatusStringChanged
        /// </summary>
        /// <param name="e"></param>
        private void OnStatusStringChanged( ChangeStatusMessageEventArgs e )
        {
            StatusStringChanged?.Invoke(this, e);
        }
    }

    /// <summary>
    /// Clase que contiene los argumentos del evento de cambio del mensaje de estado
    /// </summary>
    public class ChangeStatusMessageEventArgs : EventArgs
    {
        public string Message { get; set; }
        public string Title { get; set; }
    }
}
