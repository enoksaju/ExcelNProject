using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContabilidadIntelisisRep_AddIn.Forms {

	public partial class frmContResultados : Form {
		public Context.dataBaseContext db { get; set; } = new Context.dataBaseContext ( );
		public ConfigContBalanza config = new ConfigContBalanza ( );

		public frmContResultados ( ConfigContBalanza input ) {
			InitializeComponent ( );

			config = input;
		}

		private async void frmContResultados_Load ( object sender , EventArgs e ) {
			try {

			
			List<Modelos.spVerContBalanza_Mod> ret = new List<Modelos.spVerContBalanza_Mod> ( );


			for ( int i = config.PeriodoD; i <= config.PeriodoA; i++ ) {

				statusMessage_lbl.Text = $"Obteniendo información del periodo {i} del ejercicio {config.Ejercicio }.";

				var res = await db.Database.SqlQuery<Modelos.spVerContBalanza> ( $"EXEC spVerContBalanza 'gral',{config.Ejercicio },{i},{i},'{config.ConMovimientos.ToString ( )}','{config.Nivel.ToString ( )}' ,'{config.CuentaD }', '{config.CuentaA }';" ).ToListAsync ( );
				if ( res.Count > 0 ) {

					var auxs = res.Where ( o => o.Tipo.Trim ( ).ToUpper ( ) == "AUXILIAR" ).ToList ( );

					if ( auxs.Count <= 0 )
						throw new Exception ("En este reporte solo se pueden visualizar datos a nivel auxiliar");
				
					toolStripProgressBar1.Maximum = auxs.Count - 1;
					toolStripProgressBar1.Value = 0;

					//var dt = from aux in auxs
					//		 select new Modelos.spVerContBalanza_Mod {
					//			 Abonos = aux.Abonos ?? 0 ,
					//			 Cargos = aux.Cargos ?? 0 ,
					//			 Inicio = aux.Inicio ?? 0 ,
					//			 Final = aux.Final ?? 0 ,
					//			 Cuenta = aux.Cuenta ,
					//			 Descripcion = aux.Descripcion ,
					//			 ClaveSubCuenta = aux.Cuenta.Substring ( 0 , 7 ) + "-000000" ,
					//			 ClaveMayor = aux.Cuenta.Substring ( 0 , 3 ) + "-000-000000" ,
					//			 Periodo = i ,
					//			 Ejercicio = config.Ejercicio ,

					//			 Familia = res.FirstOrDefault ( o => o.Tipo.Trim ( ).ToUpper ( ) == "SUBCUENTA" & o.Cuenta.Trim ( ) == aux.Cuenta.Substring ( 0 , 7 ) + "-000000" )?.Familia ,
					//			 SubCuenta = res.FirstOrDefault ( o => o.Tipo.Trim ( ).ToUpper ( ) == "SUBCUENTA" & o.Cuenta.Trim ( ) == aux.Cuenta.Substring ( 0 , 7 ) + "-000000" )?.Descripcion ,
					//			 Mayor = res.FirstOrDefault ( o => o.Tipo.Trim ( ).ToUpper ( ) == "MAYOR" & o.Cuenta.Trim ( ) == aux.Cuenta.Substring ( 0 , 3 ) + "-000-000000" )?.Descripcion
					//		 };
					//ret.AddRange ( dt );

					for ( int iaux = 0; iaux < auxs.Count; iaux++ ) {
						var aux = auxs [ iaux ];
						Modelos.spVerContBalanza_Mod tmp = new Modelos.spVerContBalanza_Mod ( );

						tmp.Abonos = aux.Abonos ?? 0;
						tmp.Cargos = aux.Cargos ?? 0;
						tmp.Inicio = aux.Inicio ?? 0;
						tmp.Final = aux.Final ?? 0;
						tmp.Cuenta = aux.Cuenta;
						tmp.Descripcion = aux.Descripcion;
						tmp.ClaveSubCuenta = aux.Cuenta.Substring ( 0 , 7 ) + "-000000";
						tmp.ClaveMayor = aux.Cuenta.Substring ( 0 , 3 ) + "-000-000000";
						tmp.Periodo = i;
						tmp.Ejercicio = config.Ejercicio;


						var scta = res.FirstOrDefault ( o => o.Tipo.Trim ( ).ToUpper ( ) == "SUBCUENTA" & o.Cuenta.Trim ( ) == tmp.ClaveSubCuenta )?.Descripcion;
						var my = res.FirstOrDefault ( o => o.Tipo.Trim ( ).ToUpper ( ) == "MAYOR" & o.Cuenta.Trim ( ) == tmp.ClaveMayor )?.Descripcion;
						var fam = res.FirstOrDefault ( o => o.Tipo.Trim ( ).ToUpper ( ) == "SUBCUENTA" & o.Cuenta.Trim ( ) == tmp.ClaveSubCuenta )?.Familia;

						tmp.Familia = fam;
						tmp.SubCuenta = scta;
						tmp.Mayor = my;

						ret.Add ( tmp );

						toolStripProgressBar1.Value = iaux;
					}

					}
					else{
						throw new Exception ( "La consulta no devolvio datos" );
					}
			}

			spVerContBalanza_ModBindingSource.DataSource = ret;
			statusMessage_lbl.Text = "Listo";
			toolStripProgressBar1.Visible = false;
			} catch ( Exception ex) {

				MessageBox.Show (this, ex.Message , "Algo val mal..." , MessageBoxButtons.OK , MessageBoxIcon.Error );
			}
		}

		public class ConfigContBalanza {
			public enum Niveles { MAYOR, SUBCUENTA, AUXILIAR }
			public enum SiNo { SI, NO }


			public int Ejercicio { get; set; } = DateTime.Now.Year;
			public int PeriodoD { get; set; } = 1;
			public int PeriodoA { get; set; } = 12;
			public SiNo ConMovimientos { get; set; } = SiNo.SI;
			public Niveles Nivel { get; set; } = Niveles.AUXILIAR;

			public string CuentaD { get; set; } = "101-000-000000";
			public string CuentaA { get; set; } = "999-004-000001";
		}

		private void copiarToolStripMenuItem_Click ( object sender , EventArgs e ) {
			DataObject dt = spVerContBalanza_ModDataGridView.GetClipboardContent ( );
			if ( dt != null )
				Clipboard.SetDataObject ( dt );
		}
	}
}
