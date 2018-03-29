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
using libProduccionDataBase.Tablas;

namespace EstacionPesaje.Pages.tools {
	public partial class PreviewLabel_frm<t> : KryptonForm  {
		private string ZPL = "";
		private libControlesPersonalizados.Optionals Opt = null;



		private double _ScaleLabel = 1;
		public double ScaleLabel {
			get {
				return _ScaleLabel;
			} set {
				_ScaleLabel = value;
				refreshImage ( );					

			}
		}

		//public SimulateTypes SimulateType { get; set; }
		public t objToSimulate { get; set; }

		public PreviewLabel_frm ( t obj, string ZPL= "", libControlesPersonalizados.Optionals Opt= null) {
			InitializeComponent ( );			
			objToSimulate = obj;
			this.Opt = Opt;
			this.ZPL = ZPL;
			refreshImage ( );
		}
		private void zoomToolStripMenuItem_Click ( object sender, EventArgs e ) {
			this.ScaleLabel = double.Parse ( ( ( ToolStripMenuItem ) sender ).Tag.ToString ( ) );
		}
		private void refreshImage () {
			PreviewPictureBox.Image?.Dispose ( );




			if ((objToSimulate as TempDesperdicios )!= null) {
				PreviewPictureBox.Image = zplImageConverter.previewLabel ( PrintZPL.PrintDesperdicio ( objToSimulate as TempDesperdicios, true ), _ScaleLabel  );
			} else if ((objToSimulate as TempProduccion )!=null) {
				PreviewPictureBox.Image = zplImageConverter.previewLabel ( PrintZPL.PrintZPL ( ZPL, objToSimulate as TempProduccion, Opt, true ), _ScaleLabel );
			} else {
				throw new Exception ( "Typo de objeto no soportado" );
			}

		}
	}
}
