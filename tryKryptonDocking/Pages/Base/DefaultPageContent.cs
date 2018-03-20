using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;

namespace EstacionPesaje.Pages.Base
{
    [ToolboxItem(false)]
    public partial class DefaultPageContent : UserControl, IToKryptonPage
    {
        #region Delegates

        public delegate void ChangeStatusMessage(object sender, ChangeStatusMessageEventArgs e);

        #endregion


        #region Private Properties

        private IPalette _palette;
        private ComponentFactory.Krypton.Toolkit.PaletteBackStyle _BackStyle = PaletteBackStyle.ControlGroupBox;
        private ComponentFactory.Krypton.Toolkit.PaletteBorderStyle _BorderStyle = PaletteBorderStyle.ControlGroupBox;
        private LeavePageEventArgs LeavePageEventArgs = new LeavePageEventArgs();
        private EnterPageEventArgs EnterPageEventArgs = new EnterPageEventArgs();
        #endregion

        #region events

        /// <summary>
        /// Se desencadena cuando el estado del formulario ha cambiado.
        /// </summary>
        [Description("Se desencadena cuando el estado del formulario ha cambiado")]
        [Category("DefaultPageContent")]
        //public event ChangeStatusMessage StatusStringChanged;
        public event EventHandler<ChangeStatusMessageEventArgs> StatusStringChanged;
        /// <summary>
        /// Se desencadena cuando el estado del formulario ha cambiado.
        /// </summary>
        [Description("Se desencadena cuando el usuario entra a la Pagina")]
        [Category("DefaultPageContent")]
        public event EventHandler<EnterPageEventArgs> EnterPage;
        /// <summary>
        /// Se desencadena cuando el estado del formulario ha cambiado.
        /// </summary>
        [Description("Se desencadena cuando el usuario sale a la Pagina")]
        [Category("DefaultPageContent")]
        public event EventHandler<LeavePageEventArgs> LeavePage;

		#endregion

		#region Public Properties
		/// <summary>
		/// Contextos a los que esta ligada la Pagina
		/// </summary>
		[Description("Contextos a los que esta ligada la Pagina")]
        [Category("KryptonRibbon")]
        public string RibbonContext { get; set; }

        /// <summary>
        /// Indica si el evento EntePage tiene asignaciones
        /// </summary>
        [Description("Indica si el evento EntePage tiene asignaciones")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsAssignedEnterPage
        {
            get
            {
                var handlers = this.EnterPage?.GetInvocationList();
                return handlers != null;
            }
        }
        /// <summary>
        /// Indica si el evento EntePage tiene asignaciones
        /// </summary>
        [Description("Indica si el evento LeavePage tiene asignaciones")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsAssignedLeavePage
        {
            get
            {
                var handlers = this.LeavePage?.GetInvocationList();
                return handlers != null;
            }
        }

        /// <summary>
        /// Indica si el evento EntePage tiene asignaciones
        /// </summary>
        [Description("Indica si el evento StatusStringChanged tiene asignaciones")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsAssignedStatusStringChanged
        {
            get
            {
                var handlers = this.StatusStringChanged?.GetInvocationList();
                return handlers != null;
            }
        }

        /// <summary>
        /// Configura el estylo de fondo
        /// </summary>
        [Category("Krypton")]
        public ComponentFactory.Krypton.Toolkit.PaletteBackStyle BackStyle
        {
            get
            {
                return _BackStyle;
            }
            set
            {
                _BackStyle = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Configura el estylo de fondo
        /// </summary>
        [Category("Krypton")]
        public new ComponentFactory.Krypton.Toolkit.PaletteBorderStyle BorderStyle
        {
            get
            {
                return _BorderStyle;
            }
            set
            {
                _BorderStyle = value;
                this.Invalidate();
            }
        }
        public KryptonPage KP { get; set; }

		public string PageTitleText {
			get { return KP.TextTitle; }
			set { KP.TextTitle = value; KP.Text = value; }
		}
		public string PageDescriptionText {
			get { return KP.TextDescription; }
			set { KP.TextDescription = value; }
		}

		#endregion

		#region Private Void
		private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }

        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            // (5) Unhook events from old palette
            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            // (6) Cache the new IPalette that is the global palette
            _palette = KryptonManager.CurrentGlobalPalette;

            // (7) Hook into events for the new palette
            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            // (8) Change of palette means we should repaint to show any changes
            Invalidate();
        }

        /// <summary>
        /// Invoka al evento StatusStringChanged
        /// </summary>
        /// <param name="e"></param>
        protected void OnStatusStringChanged(ChangeStatusMessageEventArgs e)
        {
            StatusStringChanged?.Invoke(this, e);
        }
        /// <summary>
        /// Invoka al evento StatusStringChanged
        /// </summary>
        /// <param name="Message">Message to send</param>
        protected void OnStatusStringChanged(string message, string title="***")
        {
            StatusStringChanged?.Invoke(this, new ChangeStatusMessageEventArgs { Title = title, Message = message });
        }

        #endregion
        
        #region Protected void

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // (10) Unhook from the palette events
                if (_palette != null)
                {
                    _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                    _palette = null;
                }

                // (11) Unhook from the static events, otherwise we cannot be garbage collected
                KryptonManager.GlobalPaletteChanged -= new EventHandler(OnGlobalPaletteChanged);
            }

            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            if (_palette != null)
            {
                // (12) Calculate the palette state to use in calls to IPalette
                PaletteState state = Enabled ? PaletteState.Normal : PaletteState.Disabled;

                // (13) Get the background, border and text colors along with the text font
                Color backColor = _palette.GetBackColor1(BackStyle, state);
                Color borderColor = _palette.GetBorderColor1(_BorderStyle, state);
                // Color textColor = _palette.GetContentShortTextColor1(TextStyle, state);
                //Font textFont = _palette.GetContentShortTextFont(TextStyle, state);

                // Fill the entire background of the control
                using (SolidBrush backBrush = new SolidBrush(backColor))
                    e.Graphics.FillRectangle(backBrush, e.ClipRectangle);

                //System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                //path.AddRectangle( ClientRectangle );//.AddEllipse( 0, 0, 200, 100 );

                // Draw a single pixel border around the control edge
                //using (Pen borderPen = new Pen( borderColor ))
                //    e.Graphics.DrawPath( borderPen, path );

                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, borderColor, ButtonBorderStyle.Solid);

                // ControlPaint.DrawBorder3D()
                // Draw control Text at a fixed position
                // using (SolidBrush textBrush = new SolidBrush( textColor ))
                //    e.Graphics.DrawString( "Click me!", textFont, textBrush, Width / 2, Height / 2 );
            }

            base.OnPaint(e);

        }


        /// <summary>
        /// Controla lo que sucede con las excepciones
        /// </summary>
        /// <param name="ex">Excepcion a analizar</param>
        protected virtual void HandledException(Exception ex)
        {
            KryptonTaskDialog.Show("Algo va mal...", "Error al procesar la acción", ex.Message, MessageBoxIcon.Error, TaskDialogButtons.OK);


            //MessageBox.Show( this, ex.Message, "Algo va mal...", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }

        #endregion

        public DefaultPageContent()
        {
            InitializeComponent();

            // (1) To remove flicker we use double buffering for drawing
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            // (2) Cache the current global palette setting
            _palette = KryptonManager.CurrentGlobalPalette;

            // (3) Hook into palette events
            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            // (4) We want to be notified whenever the global palette changes
            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            KP = new KryptonPage();
            KP.Enter += KP_Enter;
            KP.Leave += KP_Leave;
        }
        /// <summary>
        /// Dispara el evento LeavePage AL entrar en KP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KP_Leave(object sender, EventArgs e)
        {
            this.LeavePageEventArgs.Item = KP;
            this.LeavePageEventArgs.ContextNames = RibbonContext;
            LeavePage?.Invoke(this, this.LeavePageEventArgs);
        }
        /// <summary>
        /// Dispara el evento LeavePage AL entrar en KP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KP_Enter(object sender, EventArgs e)
        {
            this.EnterPageEventArgs.Item = KP;
            this.EnterPageEventArgs.ContextNames = RibbonContext;
            EnterPage?.Invoke(this, this.EnterPageEventArgs);
        }
        public KryptonPage GetKryptonPage()
        {
            if (!this.KP.Controls.Contains(this))
            {
                this.Dock = DockStyle.Fill;
                this.KP.Controls.Add(this);
            }

            return this.KP;
        }

    }
}
