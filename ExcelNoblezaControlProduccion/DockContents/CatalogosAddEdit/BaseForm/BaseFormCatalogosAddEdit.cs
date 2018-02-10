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
using libProduccionDataBase;
using libProduccionDataBase.Contexto;
using WeifenLuo.WinFormsUI.Docking;

namespace ExcelNoblezaControlProduccion.DockContents.CatalogosAddEdit.BaseForm
{
    /// <summary>
    /// Clase Base para los formularios de edición o creación.
    /// <para>Los formularios que la heredan deben implementar la interfaz IActionsDockContent</para>
    /// </summary>
    public partial class BaseFormCatalogosAddEdit : KryptonDockContentFormBase, IActionsDockContent
    {
        private object Entity;             

        public BaseFormCatalogosAddEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicializa el Formulario Base, Agregue los parametros solicitados y ejecute despues de inicializar los componentes.
        /// </summary>
        /// <param name="DB"></param>
        /// <param name="BindingList"></param>
        /// <param name="Entidades"></param>
        /// <param name="Entity"></param>
        public virtual void Initialize( DataBaseContexto DB, IBindingList BindingList, DbSet Entidades, object Entity = null )
        {
            this.DB = DB;
            this.Entity = Entity;
            this.BindingList = BindingList;
            this.EntidadesCollection = Entidades;
            DB.SavedChanges += Catalogo.RefreshBindingSource;
        }

        #region Public Properties
        
        public ICatalogForm Catalogo { get; set; }

        /// <summary>
        /// Define el texto de la descripción del Encabezado del Formulario
        /// </summary>
        [Description( "Define el texto de la descripción del Encabezado del Formulario" )]
        [Category("KryptonHeader")]
        public string HeaderDescripcion
        {
            get { return this.HeaderForm.Values.Description; }
            set { this.HeaderForm.Values.Description = value; this.Invalidate(); }
        }

        /// <summary>
        /// Define el Texto del Encabezado del Formulario
        /// </summary>
        [Description( "Define el Texto del Encabezado del Formulario" )]
        [Category( "KryptonHeader" )]
        public string HeaderText
        {
            get { return this.HeaderForm.Values.Heading; }
            set { this.HeaderForm.Values.Heading = value; this.Invalidate();}
        }

        /// <summary>
        /// Define la Imagen que mostrara el Encabezado del Formulario
        /// </summary>
        [Description("Define la Imagen que mostrara el Encabezado del Formulario")]
        [Category( "KryptonHeader" )]
        public Image HeaderImage
        {
            get { return this.HeaderForm.Values.Image; }
            set { this.HeaderForm.Values.Image = value; this.Invalidate(); }
        }

        /// <summary>
        /// Define el estilo del Encabezado del Formulario
        /// </summary>
        [Description("Define el estilo del Encabezado del Formulario")]
        [Category( "KryptonHeader" )]
        public ComponentFactory.Krypton.Toolkit.HeaderStyle HeaderStyle
        {
            get { return this.HeaderForm.HeaderStyle; }
            set { this.HeaderForm.HeaderStyle = value; this.Invalidate(); }
        }

        /// <summary>
        /// Coleccion de Botones del Encabezado
        /// </summary>
        [Description("Coleccion de Botones del Encabezado")]
        [Category( "KryptonHeader" )]
        public ComponentFactory.Krypton.Toolkit.KryptonHeader.HeaderButtonSpecCollection HeaderButtonSpecs
        {
            get { return this.HeaderForm.ButtonSpecs; }
        }
        
        /// <summary>
        /// Contexto de la Base de datos
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable( EditorBrowsableState.Never )]
        public DataBaseContexto DB { get; set; }

        /// <summary>
        /// Binding Source que contiene la coleccion de elementos
        /// </summary>
        public BindingSource BindingSource { get; set; } = null;

        /// <summary>
        /// Binding List que contiene la coleccion de elementos
        /// </summary>
        [Browsable( false )]
        [EditorBrowsable( EditorBrowsableState.Never )]
        public IBindingList BindingList { get; private set; } = null;

        /// <summary>
        /// DbSet de la coleccion de elementos
        /// </summary>
        [Browsable( false )]
        [EditorBrowsable( EditorBrowsableState.Never )]
        public DbSet EntidadesCollection { get; private set; } = null;

        #endregion   

        #region Protected override Voids

        /// <summary>
        /// Revisa si el Formulario se puede cerrar o no, notifiac al usuario alguna advertencia sobre el cierre.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing( CancelEventArgs e )
        {

            if (!Program.IsChangingTheme) e.Cancel = cancelClosing();
            
        }

        protected void CrearForm<t>( Func<ICatalogForm, t> ActionToCreate ) where t : IActionsDockContent
        {
            var frm = ActionToCreate(this.Catalogo);
            MainForm mainfrm= this.DockPanel.FindForm() as MainForm;
            frm.StatusStringChanged += mainfrm.CambioEstadoFormCatalog;
            frm.Show( this.DockPanel );
        }

        #endregion

        #region Private Void

        /// <summary>
        /// carga el Formulario y determina como se ha abierto (Edicion, Creacion)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseFormCatalogosAddEdit_Load( object sender, EventArgs e )
        {
            if (this.DB != null && this.BindingList != null)
            {
                /* Posiciona el cursor del Bindingsource el el elemento ingresado, o
                 * agreaga un elemento nuevo al a coleccion.
                 */
                this.BindingSource.DataSource = this.BindingList;

                if (Entity != null && BindingSource.Contains( Entity ))
                {
                    BindingSource.Position = BindingSource.IndexOf( Entity );
                }
                else
                {
                    BindingSource.AddNew();                    
                }
            }

            try
            {
                // Revisa si existe una entidad o no y determina el icono a usar y el Texto del TabControl
                if (Entity != null)
                {                    
                    this.TabText = string.Format( "Editar {1} [{0}]", Entity, EntidadesCollection.ElementType.Name );
                    this.setIcon( Properties.Resources.Edit_16xMD );
                }
                else
                {
                    this.TabText = String.Format( "Agregar {1} {0:dd-MM-yy hh:mm tt}", DateTime.Now, EntidadesCollection.ElementType.Name );
                    this.setIcon( Properties.Resources.NewFile_16x );
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region private Functions

        /// <summary>
        /// Revisa el estado de la entidad y pregunta al usuario si procedera con la accion de cierre
        /// </summary>
        /// <returns>Determina la cancelacion del evento FormClosing</returns>
        private bool cancelClosing()
        {
            if (this.BindingList != null)
            {
                if (DB.Entry( this.BindingSource.Current ).State == EntityState.Unchanged) return false;

                if (!MessagesActionsAndForms.AskConfirmation( this )) return true;

                this.BindingSource.CancelEdit();   

                return false;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Extern static Functions

        [System.Runtime.InteropServices.DllImport( "user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto )]
        extern static bool DestroyIcon( IntPtr handle );

        #endregion

        #region Public Voids

        /// <summary>
        /// establece el icono del Formulario, procedente de un Bitmap
        /// </summary>
        /// <param name="Icon_"></param>
        public void setIcon( Bitmap Icon_ )
        {
            // Get an Hicon for myBitmap.
            IntPtr Hicon = Icon_.GetHicon();

            // Create a new icon from the handle. 
            Icon newIcon = Icon.FromHandle(Hicon);

            // Set the form Icon attribute to the new icon.
            this.Icon = newIcon;

            // You can now destroy the icon, since the form creates
            // its own copy of the icon accessible through the Form.Icon property.
            // DestroyIcon( newIcon.Handle );
        }

        #endregion

        #region Public Virtual Voids


        /// <summary>
        /// Guarda los cambios en la entidad que se está editando.
        /// </summary>
        public virtual void Guardar()
        {
            try
            {
                if (DB != null && this.BindingList != null && MessagesActionsAndForms.AskConfirmation( this ))
                {
                    this.OnStatusStringChanged( new ChangeStatusMessageEventArgs { Title = "Guardando", Message = "Guardando..." } );
                    BindingSource.EndEdit();
                    var t= DB.GetValidationErrors();
                    if (t.Count() > 0) throw new Exception( "Datos invalidados" );
                    DB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( Auxiliares.ValidationAndErrorMessages( DB, ex ), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

        }

        /// <summary>
        /// Cancela la la edicion o insercion de la entidad
        /// </summary>
        public virtual void Cancelar()
        {
            this.Close();
        }

        /// <summary>
        /// Refresca la entidad actual tras la confirmacion del usuario
        /// </summary>
        public virtual void Refrescar()
        {
            if (this.BindingList != null && MessagesActionsAndForms.AskConfirmation( this ))
            {
                DB.Entry( this.BindingSource.Current ).Reload();
                BindingSource.ResetCurrentItem();
            }
        }

        /// <summary>
        /// Actualiza la informacion de la entidad
        /// </summary>
        public  virtual void Actualizar()
        {
            HandledException( new NotImplementedException() );
        }


        /// <summary>
        /// Abre un formulario nuevo para agregar una nueva entidad
        /// </summary>
        public virtual void AgregarNuevo()
        {
            HandledException( new NotImplementedException() );
        }

        /// <summary>
        /// Abre una entidad
        /// </summary>
        public virtual void Abrir()
        {
            HandledException( new NotImplementedException() );
        }

        /// <summary>
        /// Guarda la entidad como
        /// </summary>
        public virtual void GuardarComo()
        {
            HandledException( new NotImplementedException() );
        }

        #endregion

       
    }
}
