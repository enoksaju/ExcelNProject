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
	public partial class FechasPage : Base.DocumentPageBase {
		public FechasPage ( int Linea_Id_, DateTime FechaInicial, DateTime FechaFinal, bool todas= false ) {
			InitializeComponent ( );

			DB = new DataBaseContexto ( );

			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All );

			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowWorkspace
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageDrag
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.AllowPageReorder
				| ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowFloating  );

			var LineaName = DB.Lineas.Where ( o => o.Id == Linea_Id_ ).FirstOrDefault ( ).Nombre.ToLower ( );

			PageTitleText = String.Format ( "Desp[{0} {1:dd/MM/yy}]", LineaName, FechaInicial );
			KP.ToolTipBody = String.Format ( "{0} {1:dd MMM yyyy}", LineaName, FechaInicial );
			KP.ToolTipTitle = "Desperdicio";
			KP.ToolTipImage = Properties.Resources.calendar;
			KP.ImageSmall = Properties.Resources.calendar;


			DateTime FI = FechaInicial.AddHours ( 8 ).AddMinutes ( 51 );
			DateTime FF = FechaFinal.AddDays ( 1 ).AddHours ( 8 ).AddMinutes ( 50 );

			var y = from TempDesperdicios des in DB.TDesperdicios
					where des.Maquina_.Linea_Id == Linea_Id_ &
					( des.FECHA >= FI & des.FECHA <= FF )
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

			var XD = y.ToList ( );
			reportViewer1.LocalReport.DataSources.Clear ( );
			reportViewer1.LocalReport.DataSources.Add ( new Microsoft.Reporting.WinForms.ReportDataSource ( "DataSet1", y ) );

			ReportParameter ReportParam = new ReportParameter ( );

			ReportParam.Name = "Tabla";
			ReportParam.Values.Add ( "1" );
			ReportParameter [] parameters = { ReportParam };
			reportViewer1.LocalReport.DisplayName = "Reporte Linea";
			reportViewer1.LocalReport.SetParameters ( parameters );
			reportViewer1.RefreshReport ( );
		}
	}
}
