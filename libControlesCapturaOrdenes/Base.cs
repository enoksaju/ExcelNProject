using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace libControlesCapturaOrdenes {
	[ToolboxItem ( false )]
	public partial class Base : UserControl {
		private IPalette _palette;
		private ComponentFactory.Krypton.Toolkit.PaletteBackStyle _BackStyle = PaletteBackStyle.ControlGroupBox;
		private ComponentFactory.Krypton.Toolkit.PaletteBorderStyle _BorderStyle = PaletteBorderStyle.ControlGroupBox;

		/// <summary>
		/// Configura el estylo de fondo
		/// </summary>
		[Category ( "Krypton" )]
		public ComponentFactory.Krypton.Toolkit.PaletteBackStyle BackStyle {
			get {
				return _BackStyle;
			}
			set {
				_BackStyle = value;
				this.Invalidate ( );
			}
		}

		/// <summary>
		/// Configura el estylo de fondo
		/// </summary>
		[Category ( "Krypton" )]
		public new ComponentFactory.Krypton.Toolkit.PaletteBorderStyle BorderStyle {
			get {
				return _BorderStyle;
			}
			set {
				_BorderStyle = value;
				this.Invalidate ( );
			}
		}

		public Base () {
			InitializeComponent ( );
			SetStyle ( ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true );
			AutoScaleMode = AutoScaleMode.Dpi;

			// (2) Cache the current global palette setting
			_palette = KryptonManager.CurrentGlobalPalette;

			// (3) Hook into palette events
			if (_palette != null)
				_palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs> ( OnPalettePaint );

			// (4) We want to be notified whenever the global palette changes
			KryptonManager.GlobalPaletteChanged += new EventHandler ( OnGlobalPaletteChanged );
		}
		private void OnPalettePaint ( object sender, PaletteLayoutEventArgs e ) {
			Invalidate ( );
		}

		private void OnGlobalPaletteChanged ( object sender, EventArgs e ) {
			// (5) Unhook events from old palette
			if (_palette != null)
				_palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs> ( OnPalettePaint );

			// (6) Cache the new IPalette that is the global palette
			_palette = KryptonManager.CurrentGlobalPalette;

			// (7) Hook into events for the new palette
			if (_palette != null)
				_palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs> ( OnPalettePaint );

			// (8) Change of palette means we should repaint to show any changes
			Invalidate ( );
		}
		protected override void Dispose ( bool disposing ) {
			if (disposing) {
				// (10) Unhook from the palette events
				if (_palette != null) {
					_palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs> ( OnPalettePaint );
					_palette = null;
				}

				// (11) Unhook from the static events, otherwise we cannot be garbage collected
				KryptonManager.GlobalPaletteChanged -= new EventHandler ( OnGlobalPaletteChanged );
			}

			base.Dispose ( disposing );
		}
		protected override void OnPaint ( PaintEventArgs e ) {

			if (_palette != null) {
				// (12) Calculate the palette state to use in calls to IPalette
				PaletteState state = Enabled ? PaletteState.Normal : PaletteState.Disabled;

				// (13) Get the background, border and text colors along with the text font
				Color backColor = _palette.GetBackColor1 ( _BackStyle, state );
				Color borderColor = _palette.GetBorderColor1 ( _BorderStyle, state );
				// Color textColor = _palette.GetContentShortTextColor1(TextStyle, state);
				//Font textFont = _palette.GetContentShortTextFont(TextStyle, state);

				// Fill the entire background of the control
				using (SolidBrush backBrush = new SolidBrush ( backColor ))
					e.Graphics.FillRectangle ( backBrush, e.ClipRectangle );

				//System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
				//path.AddRectangle( ClientRectangle );//.AddEllipse( 0, 0, 200, 100 );

				// Draw a single pixel border around the control edge
				//using (Pen borderPen = new Pen( borderColor ))
				//    e.Graphics.DrawPath( borderPen, path );

				ControlPaint.DrawBorder ( e.Graphics, ClientRectangle, borderColor, ButtonBorderStyle.Solid );

				// ControlPaint.DrawBorder3D()
				// Draw control Text at a fixed position
				// using (SolidBrush textBrush = new SolidBrush( textColor ))
				//    e.Graphics.DrawString( "Click me!", textFont, textBrush, Width / 2, Height / 2 );
			}

			base.OnPaint ( e );

		}
	}
}
