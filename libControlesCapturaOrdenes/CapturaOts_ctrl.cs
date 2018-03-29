using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using unvell.ReoGrid.CellTypes;
using unvell.ReoGrid.Rendering;

namespace libControlesCapturaOrdenes {

	[ToolboxItem ( true )]
	public partial class CapturaOts_ctrl : Base {


		private System.IO.MemoryStream plant = new System.IO.MemoryStream ( Properties.Resources.plantilla );
		public CapturaOts_ctrl () {
			InitializeComponent ( );
			this.Dock = DockStyle.Fill;
			
		}

		private void Rb_CheckChanged ( object sender, EventArgs e ) {
			reoGridControl1.CurrentWorksheet.RecalcCell ( "B59" );
		}

		private void CapturaOts_ctrl_Load ( object sender, EventArgs e ) {
			if (!DesignMode) {
				reoGridControl1.Reset ( );

				reoGridControl1.Load (
					plant,
					unvell.ReoGrid.IO.FileFormat.ReoGridFormat, Encoding.Default );
				reoGridControl1.CurrentWorksheet [ "A56" ] = new object [] { new MyCheckBox ( "Especial" ) };
				reoGridControl1.CurrentWorksheet [ "A58" ] = new object [] { new MyCheckBox ( "Especial" ) };

				var radioGroup = new RadioButtonGroup ( );

				reoGridControl1.CurrentWorksheet [ "A60" ] = new object [,] {
				{ new MyRadioButton("Especial") { RadioGroup = radioGroup },"" },
				{ new MyRadioButton("Sencilla") { RadioGroup = radioGroup },"" } ,
				{ new MyRadioButton("Doble") { RadioGroup = radioGroup },"" },
				{ new MyRadioButton("Ninguno") { RadioGroup = radioGroup },"" }
			};

				radioGroup.RadioButtons.ForEach ( rb => {
					rb.CheckChanged += Rb_CheckChanged;
				} );

				reoGridControl1.RunScript ( );
				reoGridControl1.CurrentWorksheet.Recalculate ( );
			}
		}
	}



	public class MyCheckBox : CheckBoxCell {
		Image checkedImage, uncheckedImage;
		string _Label = "";
		public MyCheckBox ( string Label ) {
			checkedImage = Properties.Resources.CheckBox_16x;
			uncheckedImage = Properties.Resources.CheckboxUncheck_16x;
			this._Label = Label;
		}

		protected override void OnContentPaint ( CellDrawingContext dc ) {


			dc.Graphics.DrawImage ( ( this.IsChecked ? checkedImage : uncheckedImage ), this.ContentBounds );

			dc.Graphics.DrawText ( _Label, "Arial", 10, unvell.ReoGrid.Graphics.SolidColor.Black,
				new unvell.ReoGrid.Graphics.Rectangle ( this.ContentBounds.X + 20, this.ContentBounds.Y, 60, ContentBounds.Height ) );

		}
	}

	public class MyRadioButton : RadioButtonCell {
		string _Label = "";
		public MyRadioButton ( string Label ) {
			this._Label = Label;
		}
		protected override void OnContentPaint ( CellDrawingContext dc ) {
			base.OnContentPaint ( dc );

			dc.Graphics.DrawText ( _Label, "Arial", 10, unvell.ReoGrid.Graphics.SolidColor.Black,
				new unvell.ReoGrid.Graphics.Rectangle ( this.ContentBounds.X + 20, this.ContentBounds.Y, 50, ContentBounds.Height ) );

		}
	}
}
