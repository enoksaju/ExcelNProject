using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using ExcelNoblezaControlProduccion.DockContents.ICatalogFormEnums;
using libProduccionDataBase.Contexto;
using WeifenLuo.WinFormsUI.Docking;

namespace ExcelNoblezaControlProduccion.DockContents.Catalogos.BaseForm
{
    public partial class BaseFormCatalogos : KryptonDockContentFormBase, ICatalogForm
    {
        private FlagActiveFunctions _ActiveFunctions= FlagActiveFunctions.Todas;             

        #region Public Properties
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

        /// <summary>
        /// <para>Contexto de la Base de datos que contiene los metodos para conexion a ala base de datos y las colecciones de las entidades</para>
        /// <para>Requiere <code>Using System.Data.Entity</code></para>
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable( EditorBrowsableState.Never)]
        public DataBaseContexto DB { get; set; }


        #endregion
                
        public BaseFormCatalogos()
        {
          
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            // Agreagar Manejo de Eventos de los controles comunes
            SetHandledButtons();
        }

        public BaseFormCatalogos( DataBaseContexto DB )
        {           
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            // Le da valores a los parametros

            this.DB = DB;

            DB.SavedChanges += RefreshBindingSource;

            //this.ActiveFunctions = ActiveFunctions;

            // Agreagar Manejo de Eventos de los controles comunes
            SetHandledButtons();
        }

        #region Public void
        /// <summary>
        /// <para>Controla lo que sucede al presionar el botón Actualizar</para>
        /// <para>El metodo debe sobreescribirse en el formulario que Hereda</para>
        /// </summary>
        /// <param name="sender">Control que generó el evento</param>
        /// <param name="e"></param>
        public virtual void Actualizar( object sender, EventArgs e ) { HandledException( new NotImplementedException() ); }

        /// <summary>
        /// <para>Controla lo que sucede al presionar el botón Agregar</para>
        /// <para>El metodo debe sobreescribirse en el formulario que Hereda</para>
        /// </summary>
        /// <param name="sender">Control que generó el evento</param>
        /// <param name="e"></param>
        public virtual void Agregar( object sender, EventArgs e ) { HandledException( new NotImplementedException() ); }

        /// <summary>
        /// <para>Controla lo que sucede al presionar el botón Eliminar</para>
        /// <para>El metodo debe sobreescribirse en el formulario que Hereda</para>
        /// </summary>
        /// <param name="sender">Control que generó el evento</param>
        /// <param name="e"></param>
        public virtual void Eliminar( object sender, EventArgs e ) { HandledException( new NotImplementedException() ); }

        /// <summary>
        /// <para>Controla lo que sucede al presionar el botón Editar</para>
        /// <para>El metodo debe sobreescribirse en el formulario que Hereda</para>
        /// </summary>
        /// <param name="sender">Control que generó el evento</param>
        /// <param name="e"></param>
        public virtual void Editar( object sender, EventArgs e ) { HandledException( new NotImplementedException() ); }

        /// <summary>
        /// <para>Controla lo que sucede al Ejecutarse la accion de Busqueda</para>
        /// <para>El metodo debe sobreescribirse en el formulario que Hereda</para>
        /// </summary>
        /// <param name="sender">Control que generó el evento</param>
        /// <param name="SearchString">Cadena que se intenta buscar</param>
        public virtual void Buscar( object sender, string SearchString ) { HandledException( new NotImplementedException() ); }

        /// <summary>
        /// <para>Controla lo que sucede al presionar el botón ShowDetails</para>
        /// <para>El metodo debe sobreescribirse en el formulario que Hereda</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void showDetails( object sender, EventArgs e ) { HandledException( new NotImplementedException() ); }
        /// <summary>
        /// Refresca que se desencadenara al actualizar la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void RefreshBindingSource( object sender, EventArgs e )
        {
            Console.WriteLine( sender );
            if (sender.GetType() == this.GetType())
                Actualizar( sender, e );
        }
        public void Show( DockPanel Panel, FlagActiveFunctions Functions )
        {
            base.OnStatusStringChanged( new ChangeStatusMessageEventArgs { Title = "Modo de Apertura", Message = String.Format( "Abriendo {1} con las funciones: {0}", Functions.ToString(), this.TabText ) } );

            this.Show( Panel );
            this.ActiveFunctions = Functions;
           
        }



        #endregion



        #region Private Void
        /// <summary>
        /// Agrega las acciones que deben tomar los Controles al ser usados por el Cliente
        /// </summary>
        private void SetHandledButtons()
        {
            RefreshToolStripButton.Click += Actualizar;
            AddNewToolStripButton.Click += Agregar;
            DeleteCurrentToolStripButton.Click += Eliminar;
            EditCurrentToolStripButton.Click += Editar;
            showDetallesToolStripButton.Click += showDetails;

            SearchToolStripButton.Click += Search;
            ToSearchTextBox.KeyDown += ToSearchTextBox_KeyDown;
            
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
                Buscar( sender, ToSearchTextBox.Text );
            }
        }

        /// <summary>
        /// Controla lo que sucede al presionar el Boton de Busqueda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search( object sender, EventArgs e )
        {
            Buscar( sender, ToSearchTextBox.Text );
        }

        /// <summary>
        /// Configura los controles que se desactivaran con base al modo de apertura del formulario
        /// </summary>
        private void ConfigureUse()
        {
            CatalogSearchToolStrip.Visible = this.ActiveFunctions.HasFlag( FlagActiveFunctions.Buscar );

            AddNewToolStripButton.Enabled = this.ActiveFunctions.HasFlag( FlagActiveFunctions.Editar );
            EditCurrentToolStripButton.Enabled = this.ActiveFunctions.HasFlag( FlagActiveFunctions.Editar );
            DeleteCurrentToolStripButton.Enabled = this.ActiveFunctions.HasFlag( FlagActiveFunctions.Editar );

            showDetallesToolStripButton.Enabled = this.ActiveFunctions.HasFlag( FlagActiveFunctions.Detalles );
        }
        
        #endregion

    }
}
