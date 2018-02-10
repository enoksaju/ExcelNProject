using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libProduccionDataBase.Contexto;
using WeifenLuo.WinFormsUI.Docking;
using System.Data.Entity;
using libProduccionDataBase;

namespace ControlProduccion.Catalogos.AddOrEditForms
{
    public partial class BaseAddOrEditForms : DockContent, IActionsDockContent
    {
        private object Entity;
        private Image _ImageForm = Properties .Resources.Admin_40px;
        private Color _HeadColor= Color.FromArgb( 255, 223, 235, 247 );
        private Color _HeadForeColor= Color.FromArgb( 255, 100, 100, 100 );
        private string _TitleText= "";
        private ContentAlignment _HeaderTextAlign= ContentAlignment.MiddleCenter;

        //private Label lblTitle= new Label { Location= new Point(42,5),
        //    AutoSize = false,
        //    AutoEllipsis = true,
        //    TextAlign = ContentAlignment.MiddleCenter,
        //    Text= "Formulario Agregar o Editar",
        //    Anchor= AnchorStyles.Top| AnchorStyles.Left | AnchorStyles.Right,
        //    BackColor= Color.Transparent ,
        //    Font= new Font("Arial", 12, FontStyle.Bold),
        //    ForeColor= Color.WhiteSmoke            
        //};

        public DataBaseContexto DB { get; set; }

        public Image ImageForm { get; set; }

        public Color HeadColor { get { return _HeadColor; } set { _HeadColor = value; this.Invalidate(); } }
        public Color HeadForeColor { get { return _HeadForeColor; } set { _HeadForeColor = value; this.Invalidate(); } }

        public ContentAlignment HeaderTextAlign { get { return _HeaderTextAlign; } set { _HeaderTextAlign = value; this.Invalidate(); } } 

        public Image ImageBackgroundForm { get; set; } = Properties.Resources.Magazine_100px;

        public BindingSource BindingSource { get; set; } = null;

        public IBindingList BindingList { get; private set; } = null;
        public DbSet EntidadesCollection { get; private set; } = null;

        public bool IsAddingNew { get; private set; } = false;

        public string TitleText { get { return _TitleText; } set { _TitleText = value; this.Invalidate(); } }//{ get { return lblTitle.Text; } set { lblTitle.Text = value; } } 

        public new Padding Padding
        {
            get { return base.Padding; }
            set
            {
                base.Padding = value;
                this.Invalidate();
            }

        }
        
        public BaseAddOrEditForms()
        {
            InitializeComponent();
            initialize();
        }

        public BaseAddOrEditForms( DataBaseContexto DB, IBindingList BindingList, DbSet Entidades, object Entity = null )
        {
            InitializeComponent();
            this.DB = DB;
            this.Entity = Entity;
            this.BindingList = BindingList;
            this.EntidadesCollection = Entidades;
            initialize();

        }

        private void initialize()
        {
            try
            {
                this.Resize += BaseAddOrEditForms_Resize;
                
            }
            catch (Exception)
            {
            }

        }

        private void BaseAddOrEditForms_Resize( object sender, EventArgs e )
        {
            this.Invalidate();
        }

        protected override void OnClosing( CancelEventArgs e )
        {
            e.Cancel = cancelClosing();
            base.OnClosing( e );
        }

        private void BaseAddOrEditForms_Load( object sender, EventArgs e )
        {
            if (this.DB != null && this.BindingList != null)
            {
                this.BindingSource.DataSource = this.BindingList;

                if (Entity != null && BindingSource.Contains( Entity ))
                {
                    BindingSource.Position = BindingSource.IndexOf( Entity );
                }
                else
                {
                    BindingSource.AddNew();
                    IsAddingNew = true;
                }
            }

            try
            {                

                if (Entity != null)
                {
                    this.TitleText = string.Format( "Editar: {0}", Entity );
                    this.TabText = string.Format( "Editar[{0}]", Entity );
                    this.setIcon( Properties.Resources.Edit_16xMD );
                }
                else
                {
                    this.TitleText = EntidadesCollection.ElementType.Name;
                    this.TabText = String.Format( "{1} {0:dd-MM-yy hh:mm tt}", DateTime.Now, EntidadesCollection.ElementType.Name );
                    this.setIcon( Properties.Resources.NewFile_16x );
                }
            }
            catch (Exception)
            {
            }

        }
        
        private bool cancelClosing()
        {
            if (this.BindingList != null)
            {
                if (DB.Entry( this.BindingSource.Current ).State == EntityState.Unchanged) return false;

                if (!MessagesActionsAndForms.AskConfirmation( this )) return true;

                this.BindingSource.CancelEdit();
                switch (DB.Entry( this.BindingSource.Current ).State)
                {
                    case EntityState.Added:
                        EntidadesCollection.Local.Remove( this.BindingSource.Current );
                        break;
                    case EntityState.Modified:
                        DB.Entry( this.BindingSource.Current ).Reload();
                        break;
                    default:
                        break;
                }
                BindingSource.ResetCurrentItem();

                return false;

            }
            else
            {
                return false;
            }
        }



        [System.Runtime.InteropServices.DllImport( "user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto )]
        extern static bool DestroyIcon( IntPtr handle );

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

        /// <summary>
        /// Controla lo que sucede con las excepciones
        /// </summary>
        /// <param name="ex">Excepcion a analizar</param>
        public virtual void HandledException( Exception ex )
        {
            MessageBox.Show( this, ex.Message, "Algo va mal...", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }

        private void BaseAddOrEditForms_Paint( object sender, PaintEventArgs e )
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.DrawImage( this.ImageBackgroundForm, new Point( this.Width - this.ImageBackgroundForm.Width - 30, this.Height - this.ImageBackgroundForm.Height - 50 ) );


            e.Graphics.FillRectangle( new SolidBrush( this._HeadColor ), 0, 0, this.Width, this.Padding.Top-10 );


            var rect= new Rectangle(new Point(42,5), new Size( this.Width - 55 , this.Padding.Top-15) );

            if (this.ImageForm != null) e.Graphics.DrawImage( this.ImageForm, 5, (rect.Height -32+5) /2, 32, 32 );


            StringFormat sf = new StringFormat();

            switch (HeaderTextAlign)
            {
                case ContentAlignment.BottomCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.TopCenter:
                    sf.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.TopLeft:
                    sf.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.TopRight:
                    sf.Alignment = StringAlignment.Far;
                    break;
                default:
                    sf.Alignment = StringAlignment.Center;
                    break;
            }

            switch (HeaderTextAlign)
            {
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomRight:
                    sf.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleRight:
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopRight:
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                default:
                    sf.LineAlignment = StringAlignment.Center;
                    break;
            }

            var fnt= new Font( "Arial", 14, FontStyle.Bold );
            var txt= ellipsisString( this.TitleText, e.Graphics, fnt, rect );

            using (var bsForeColor = new SolidBrush( this._HeadForeColor ))
            {
                e.Graphics.DrawString( String.Format( "{0}{1}", txt, txt != this.TitleText ? "..." : "" ), fnt, bsForeColor, rect, sf );
            }

            e.Graphics.DrawLine( new Pen( new SolidBrush( Color.FromArgb( 255, 248, 180, 45 ) ), 3 ), new Point( 0, this.Padding.Top - 10 ), new Point( this.Width, this.Padding.Top - 10 ) );




        }

        private string ellipsisString( string value, Graphics g, Font f, Rectangle rect )
        {
            var sizestr= g.MeasureString(value,f).Width+60;
            try
            {
                return sizestr > rect.Width ? ellipsisString( value.Substring( 0, value.Length - 1 ), g, f, rect ) : value;
            }
            catch (Exception)
            {

                return "";
            }

        }



        public virtual void Guardar()
        {
            try
            {
                if (DB != null && this.BindingList != null && MessagesActionsAndForms.AskConfirmation( this ))
                {
                    BindingSource.EndEdit();
                    var t= DB.GetValidationErrors();
                    if (t.Count() > 0) throw new Exception( "Datos invalidados" );
                    DB.SaveChanges();
                    this.IsAddingNew = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( Auxiliares.ValidationAndErrorMessages( DB, ex ), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

        }
        public virtual void Cancelar()
        {
            this.Close();
        }

        public virtual void Refrescar()
        {
            if (this.BindingList != null && MessagesActionsAndForms.AskConfirmation( this ))
            {
                DB.Entry( this.BindingSource.Current ).Reload();
                BindingSource.ResetCurrentItem();
            }
        }
        public void Actualizar()
        {
            HandledException( new NotImplementedException() );
        }

        public void AgregarNuevo()
        {
            HandledException( new NotImplementedException() );
        }

        public void Abrir()
        {
            HandledException( new NotImplementedException() );
        }

        public void GuardarComo()
        {
            HandledException( new NotImplementedException() );
        }
    }
}
