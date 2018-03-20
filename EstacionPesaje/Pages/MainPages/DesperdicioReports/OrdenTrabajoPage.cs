using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas;
using Microsoft.Reporting.WinForms;

namespace EstacionPesaje.Pages.MainPages.DesperdicioReports {
	public partial class OrdenTrabajoPage : Base.DocumentPageBase {
		public OrdenTrabajoPage ( string Ots ) {
			InitializeComponent ( );
			DB = new DataBaseContexto ( );


			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowFloating );


			PageTitleText = String.Format ( "Desp[{0}]", Ots );
			KP.ToolTipBody = String.Format ( "{0}", Ots );
			KP.ToolTipTitle = "Desperdicio";
			KP.ToolTipImage = Properties.Resources.intelisis;
			KP.ImageSmall = Properties.Resources.intelisis;


			var split_ = Ots.Split ( ',' );
			List<ReportData> toshow = new List<ReportData> ( );

			foreach (string ot_ in split_) {

				IQueryable<ReportData> y = from TempDesperdicios des in DB.TDesperdicios
										   where des.OT.Contains ( ot_ )
										   select new ReportData {
											   ID = des.Id,
											   OT = des.OT,
											   OPERADOR = des.OPERADOR,
											   TURNO = des.TURNO,
											   LINEA = des.Maquina_.Linea.Nombre,
											   MAQUINA = des.Maquina_.NombreMaquina,
											   NUMERO = des.NUMERO,
											   PESO = des.PESO,
											   FAMILIA = des.FamiliaDefectosDefecto.FamiliaDefectos.NombreFamiliaDefecto,
											   DEFECTO = des.FamiliaDefectosDefecto.Defecto.NombreDefecto,
											   DESCRIPCION = des.DESCRIPCION,
											   ESTRUCTURA = des.ESTRUCTURA,
											   FECHA = des.FECHA,
											   PROCESO = des.FamiliaDefectosDefecto.FamiliaDefectos.NombreFamiliaDefecto
										   };
				toshow.AddRange ( y );				
			}
			
			reportViewer1.LocalReport.DataSources.Clear ( );
			reportViewer1.LocalReport.DataSources.Add ( new Microsoft.Reporting.WinForms.ReportDataSource ( "DataSet1", toshow  ) );

			ReportParameter ReportParam = new ReportParameter ( );

			ReportParam.Name = "Tabla";
			ReportParam.Values.Add ( "2" );
			ReportParameter [] parameters = { ReportParam };
			reportViewer1.LocalReport.DisplayName = "Reporte OT";
			reportViewer1.LocalReport.SetParameters ( parameters );
			reportViewer1.RefreshReport ( );

		}
	}
}
