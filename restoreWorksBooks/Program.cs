using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas;
using Microsoft.Office.Interop.Excel;

namespace restoreWorksBooks {
	class Program {
		static void Main ( string [] args ) {
			Application excel = new Application ( );

			Workbook wb= null;
			Worksheet ws= null;
			int Count = 0;
			int Total = Directory.EnumerateFiles (
				"T:\\HECTOR HERNANDEZ\\OTS",
				"*.xlsx"
				).Count ( );
			//excel.Visible = true;

			foreach (string file in Directory.EnumerateFiles (
				"T:\\HECTOR HERNANDEZ\\OTS", 
				"*.xlsx"
				).OrderBy(y=>y)) {


				try {
					
					wb = excel.Workbooks.Open ( file, Editable:true);
					ws = wb.ActiveSheet;

					if(ws.Range["A2"].Value == "captura pedidos2") {
						using (var DB= new DataBaseContexto ( )) {
							TemporalOrdenTrabajo newOT = new TemporalOrdenTrabajo ( );
							newOT.TIPO = Convert.ToInt32 ( ws.Range[ "A1" ].Value );
							newOT.FECHARECIBIDO = ws.Range [ "A6" ].Value ;
							newOT.OT = Convert.ToString ( ws.Range [ "A5" ].Value );
							newOT.FECHAENTREGASOL = ws.Range [ "A7" ].Value ;
							newOT.CLIENTE = Convert.ToString ( ws.Range [ "A11" ].Value );
							newOT.PRODUCTO = Convert.ToString ( ws.Range [ "A44" ].Value );
							newOT.CANTIDAD =  ws.Range [ "A19" ].Value ;
							newOT.UNIDAD = Convert.ToString ( ws.Range [ "A12" ].Value );
							newOT.ANCHO = Convert.ToDouble ( ws.Range [ "A32" ].Value );
							newOT.ALTO = Convert.ToDouble ( ws.Range [ "A33" ].Value) ;
							newOT.SOLAPA = Convert.ToDouble ( ws.Range [ "A68" ].Value) ;
							newOT.FUELLELATERAL = Convert.ToDouble ( ws.Range [ "A69" ].Value) ;
							newOT.FUELLEFONDO = Convert.ToDouble ( ws.Range [ "A70" ].Value) ;
							newOT.COPETE = Convert.ToDouble ( ws.Range [ "A71" ].Value) ;
							newOT.AREASELLOREV = Convert.ToDouble ( ws.Range [ "A72" ].Value) ;
							newOT.AREASELLOFONDO = Convert.ToDouble ( ws.Range [ "A73" ].Value );
							newOT.TIPOIMPRESION = (int)ws.Range [ "A14" ].Value ;
							newOT.TIPOTRABAJO =(int)ws.Range [ "A15" ].Value ;
							newOT.REPEJE =ws.Range [ "A9" ].Value ;
							newOT.REPDES =  ws.Range [ "A10" ].Value ;
							newOT.MATBASE = Convert.ToString ( ws.Range [ "A26" ].Value );
							newOT.MATBASECALIBRE = Convert.ToDouble ( ws.Range [ "A23" ].Value) ;
							newOT.MATBASEKG = Convert.ToDouble ( ws.Range [ "A29" ].Value) ;
							newOT.MATLAMINACION = Convert.ToString ( ws.Range [ "A27" ].Value );
							newOT.MATLAMINACIONCALIBRE = Convert.ToDouble ( ws.Range [ "A24" ].Value) ;
							newOT.MATLAMINACIONKG = Convert.ToDouble ( ws.Range [ "A30" ].Value );
							newOT.MATTRILAMINACION = Convert.ToString ( ws.Range [ "A28" ].Value );
							newOT.MATTRILAMINACIONCALIBRE = Convert.ToDouble ( ws.Range [ "A25" ].Value) ;
							newOT.MATTRILAMINACIONKG = Convert.ToDouble ( ws.Range [ "A31" ].Value );
							newOT.CLAVEINTELISIS = Convert.ToString ( ws.Range [ "A3" ].Value );
							newOT.ORDENCOMPRA = Convert.ToString ( ws.Range [ "A4" ].Value );
							newOT.CLAVEPRODUCTO = "-";
							newOT.IMPRESORA = Convert.ToString ( ws.Range [ "A16" ].Value );
							newOT.RODILLO = Convert.ToDouble ( ws.Range [ "A17" ].Value) ;
							newOT.FIGURASALIDAFINAL =  (int)ws.Range [ "A8" ].Value ;
							newOT.EMPATES = "";
							newOT.INSTCORTE = Convert.ToString ( ws.Range [ "A34" ].Value) ;
							newOT.INSTDOBLADO = Convert.ToString ( ws.Range [ "A35" ].Value );
							newOT.INSTEMBOBINADO = Convert.ToString ( ws.Range [ "A36" ].Value );
							newOT.INSTEXTRUSION = ( ws.Range [ "A53" ].Value );
							newOT.INSTIMPRESION = Convert.ToString ( ws.Range [ "A38" ].Value );
							newOT.INSTLAMINACION = Convert.ToString ( ws.Range [ "A39" ].Value );
							newOT.INSTMANGAS = Convert.ToString ( ws.Range [ "A40" ].Value );
							newOT.INSTREFINADO = Convert.ToString ( ws.Range [ "A41" ].Value );
							newOT.INSTSELLADO = Convert.ToString ( ws.Range [ "A42" ].Value );
							newOT.OBSERVACIONES = Convert.ToString ( ws.Range [ "A43" ].Value );
							newOT.ESIMPRESO = Convert.ToString ( ws.Range [ "A13" ].Value );
							newOT.KGXMILL = ws.Range [ "A18" ].Value ;
							newOT.MATBASEAMU = Convert.ToDouble( ws.Range [ "A20" ].Value );
							newOT.EXTIPO = Convert.ToString ( ws.Range [ "A45" ].Value );
							newOT.EXCOLOR = Convert.ToString ( ws.Range [ "A46" ].Value );
							newOT.EXTRATADO = Convert.ToString ( ws.Range [ "A47" ].Value );
							newOT.EXDINAS = Convert.ToString ( ws.Range [ "A48" ].Value );
							newOT.EXDESLIZ = Convert.ToString ( ws.Range [ "A49" ].Value );
							newOT.EXANTIESTATICA = Convert.ToString ( ws.Range [ "A50" ].Value );
							newOT.MATLAMINACIONAMU = Convert.ToDouble ( ws.Range [ "A21" ].Value) ;
							newOT.MATTRILAMINACIONAMU = Convert.ToDouble ( ws.Range [ "A22" ].Value) ;
							newOT.EXKG = Convert.ToString ( ws.Range [ "A51" ].Value );
							newOT.EXANCHO = Convert.ToString ( ws.Range [ "A52" ].Value );

							DB.tempOt.AddOrUpdate ( o => o.OT, newOT );
							DB.SaveChanges ( );


							TEMPCAPT MyTempData = new TEMPCAPT ( );
							MyTempData.OT = Convert.ToString ( ws.Range [ "A5" ].Value );
							MyTempData.DISENIOAUT = Convert.ToString ( ws.Range [ "A54" ].Value );
							MyTempData.CENTROS =  (int)ws.Range [ "A55" ].Value ;
							MyTempData.TINTA = Convert.ToDouble ( ws.Range [ "A56" ].Value) ;
							MyTempData.ADH1 = Convert.ToDouble ( ws.Range [ "A57" ].Value) ;
							MyTempData.ADH2 = Convert.ToDouble ( ws.Range [ "A58" ].Value) ;
							MyTempData.AJUIMP = Convert.ToDouble ( ws.Range [ "A59" ].Value);
							MyTempData.LAMIMP = Convert.ToDouble ( ws.Range [ "A60" ].Value );
							MyTempData.TRIIMP = Convert.ToDouble ( ws.Range [ "A61" ].Value) ;
							MyTempData.AJULAM = Convert.ToDouble ( ws.Range [ "A62" ].Value );
							MyTempData.LAMLAM = Convert.ToDouble ( ws.Range [ "A63" ].Value );
							MyTempData.TRILAM = Convert.ToDouble ( ws.Range [ "A64" ].Value );
							MyTempData.AJUTRI = Convert.ToDouble ( ws.Range [ "A65" ].Value );
							MyTempData.TRITRI = Convert.ToDouble ( ws.Range [ "A66" ].Value );
							MyTempData.ESPECIAL = Convert.ToInt32 ( ws.Range [ "X4" ].Value) ;
							MyTempData.ESPECIALLAM = Convert.ToInt32 ( ws.Range [ "X3" ].Value) ;
							MyTempData.ESPECIALREF = Convert.ToInt32 ( ws.Range [ "X2" ].Value) ;
							MyTempData.PORCTOLERANCIA = Convert.ToDouble ( ws.Range [ "E21" ].Value );
							MyTempData.ZIPPER = Convert.ToInt32 ( ws.Range [ "F19" ].Value) ;
							MyTempData.ADHPERM = Convert.ToInt32 ( ws.Range [ "F20" ].Value) ;
							MyTempData.ADHREM = Convert.ToInt32 ( ws.Range [ "F21" ].Value) ;
							MyTempData.EX1 = Convert.ToInt32 ( ws.Range [ "I49" ].Value) ;
							MyTempData.EX2 = Convert.ToInt32 ( ws.Range [ "I50" ].Value) ;
							MyTempData.EX3 = Convert.ToInt32 ( ws.Range [ "I51" ].Value) ;
							MyTempData.ML = Convert.ToInt32 ( ws.Range [ "A74" ].Value) ;
							MyTempData.ZIPPER_TYPE = Convert.ToInt32 ( ws.Range [ "G18" ].Value) ;
							MyTempData.MERMAPROCESO =  Convert.ToDouble(ws.Range [ "A75" ].Value) ;
							MyTempData.ENABLED = 1;

							DB.TEMPCAPT.AddOrUpdate ( O=> O.OT, MyTempData );
							DB.SaveChanges ( );


						}

						++Count;
						File.AppendAllText ( "T:\\HECTOR HERNANDEZ\\OTS\\log.txt", String.Format( "{0}/{1} => {2}\r\n", Count, Total,  file) );

						Console.WriteLine ( "{0}/{1} => {2}", Count, Total, file );

					}else {
						throw new Exception ( "Libro incorrecto" );
					}


				}

				catch (Exception ex) {

					Console.WriteLine ( ex );
					File.AppendAllText ( "T:\\HECTOR HERNANDEZ\\OTS\\log.txt", String.Format ( "{0}/{1} => {2} \r\nError: {3}\r\n", Count, Total, file, ex ) );

				}
				finally {
					wb?.Close ( );
				}
				


			}

		}
	}
}
