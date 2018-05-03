using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace ContabilidadIntelisisRep_AddIn {
	public partial class ContIntelisisRep_rbn {
		private void ContIntelisisRep_rbn_Load ( object sender , RibbonUIEventArgs e ) {

		}

		private void button1_Click ( object sender , RibbonControlEventArgs e ) {

			using (var frmConfig= new Forms .frmConfigBalanzaComp() ) {
				if ( frmConfig.ShowDialog ( ) != System.Windows.Forms.DialogResult.OK )
					return;

				var frm = new Forms.frmContResultados (frmConfig.response );
				frm.Show ( );
			}
				
		}

		private void IntegracionSaldosCxc_btn_Click ( object sender , RibbonControlEventArgs e ) {
			 new Forms.frmIntegracionSaldos ( Forms.frmIntegracionSaldos.Datos.cxc ).Show();
		}

		private void button2_Click ( object sender , RibbonControlEventArgs e ) {
			new Forms.frmIntegracionSaldos ( Forms.frmIntegracionSaldos.Datos.cxp).Show ( );
		}

		private void button3_Click ( object sender , RibbonControlEventArgs e ) {
			new Forms.frmPerdidaGanaciaCambiaria (  Forms.frmPerdidaGanaciaCambiaria.Tipos.cxc).Show();
		}

		private void button4_Click ( object sender , RibbonControlEventArgs e ) {
			new Forms.frmPerdidaGanaciaCambiaria ( Forms.frmPerdidaGanaciaCambiaria.Tipos.cxp ).Show ( );
		}
	}
}
