using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace ControlNominasAddIn {
	public partial class MainRibbon {
		private void MainRibbon_Load ( object sender , RibbonUIEventArgs e ) {

		}


		private void btnImportarReloj_Click ( object sender , RibbonControlEventArgs e ) {
			new Forms.frmImportarReloj ( ).Show ( );
		}

		private void btnImportarPermisos_Click ( object sender , RibbonControlEventArgs e ) {
			new Forms.frmImportarPermisos ( ).Show ( );
		}

		private void btnReporteVacaciones_Click ( object sender , RibbonControlEventArgs e ) {
			new Forms.frmVacaciones ( ).Show ( );
		}

		private void btnCustomSQL_Click ( object sender , RibbonControlEventArgs e ) {
			new Forms.frmSQL ( ).Show ( );
		}

		private void btnConfiguracion_Click ( object sender , RibbonControlEventArgs e ) {

		}
	}
}
