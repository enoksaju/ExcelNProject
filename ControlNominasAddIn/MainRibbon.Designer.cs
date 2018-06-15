namespace ControlNominasAddIn {
	partial class MainRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase {
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public MainRibbon ( )
			: base ( Globals.Factory.GetRibbonFactory ( ) ) {
			InitializeComponent ( );
		}

		/// <summary> 
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose ( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Código generado por el Diseñador de componentes

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent ( ) {
			this.components = new System.ComponentModel.Container();
			this.tbNominasExcelNobleza = this.Factory.CreateRibbonTab();
			this.gpNominas = this.Factory.CreateRibbonGroup();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			this.mnuNominasExcel = this.Factory.CreateRibbonMenu();
			this.btnImportarReloj = this.Factory.CreateRibbonButton();
			this.btnImportarPermisos = this.Factory.CreateRibbonButton();
			this.btnReporteVacaciones = this.Factory.CreateRibbonButton();
			this.separator1 = this.Factory.CreateRibbonSeparator();
			this.btnCustomSQL = this.Factory.CreateRibbonButton();
			this.separator2 = this.Factory.CreateRibbonSeparator();
			this.btnConfiguracion = this.Factory.CreateRibbonButton();
			this.tbNominasExcelNobleza.SuspendLayout();
			this.gpNominas.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbNominasExcelNobleza
			// 
			this.tbNominasExcelNobleza.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
			this.tbNominasExcelNobleza.ControlId.OfficeId = "TabData";
			this.tbNominasExcelNobleza.Groups.Add(this.gpNominas);
			this.tbNominasExcelNobleza.Label = "TabData";
			this.tbNominasExcelNobleza.Name = "tbNominasExcelNobleza";
			// 
			// gpNominas
			// 
			this.gpNominas.Items.Add(this.mnuNominasExcel);
			this.gpNominas.Label = "Nominas Excel";
			this.gpNominas.Name = "gpNominas";
			this.gpNominas.Position = this.Factory.RibbonPosition.BeforeOfficeId("GroupSortFilter");
			// 
			// kryptonManager1
			// 
			this.kryptonManager1.GlobalPaletteMode = global::ControlNominasAddIn.Properties.Settings.Default.Theme;
			// 
			// mnuNominasExcel
			// 
			this.mnuNominasExcel.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.mnuNominasExcel.Description = "Importar datos del reloj, permisos";
			this.mnuNominasExcel.Image = global::ControlNominasAddIn.Properties.Resources.logo32x32;
			this.mnuNominasExcel.Items.Add(this.btnImportarReloj);
			this.mnuNominasExcel.Items.Add(this.btnImportarPermisos);
			this.mnuNominasExcel.Items.Add(this.btnReporteVacaciones);
			this.mnuNominasExcel.Items.Add(this.separator1);
			this.mnuNominasExcel.Items.Add(this.btnCustomSQL);
			this.mnuNominasExcel.Items.Add(this.separator2);
			this.mnuNominasExcel.Items.Add(this.btnConfiguracion);
			this.mnuNominasExcel.Label = "Nominas";
			this.mnuNominasExcel.Name = "mnuNominasExcel";
			this.mnuNominasExcel.ShowImage = true;
			// 
			// btnImportarReloj
			// 
			this.btnImportarReloj.KeyTip = "RC";
			this.btnImportarReloj.Label = "Importar Datos del Reloj";
			this.btnImportarReloj.Name = "btnImportarReloj";
			this.btnImportarReloj.OfficeImageId = "AnimationDuration";
			this.btnImportarReloj.ScreenTip = "Importar Datos del Reloj Checador";
			this.btnImportarReloj.ShowImage = true;
			this.btnImportarReloj.SuperTip = "Importar desde la base de datos del reloj checador y generar el reporte de entrad" +
    "as y salidas de los trabajadores";
			this.btnImportarReloj.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnImportarReloj_Click);
			// 
			// btnImportarPermisos
			// 
			this.btnImportarPermisos.Label = "Importar Permisos";
			this.btnImportarPermisos.Name = "btnImportarPermisos";
			this.btnImportarPermisos.OfficeImageId = "ImportAccess";
			this.btnImportarPermisos.ScreenTip = "Importar Permisos";
			this.btnImportarPermisos.ShowImage = true;
			this.btnImportarPermisos.SuperTip = "Importar los permisos solicitados desde la base de datos de permisos";
			this.btnImportarPermisos.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnImportarPermisos_Click);
			// 
			// btnReporteVacaciones
			// 
			this.btnReporteVacaciones.Label = "Reporte de Vacaciones";
			this.btnReporteVacaciones.Name = "btnReporteVacaciones";
			this.btnReporteVacaciones.OfficeImageId = "CalendarToolExportSelectedAppointment";
			this.btnReporteVacaciones.ScreenTip = "Reporte de Vacaciones";
			this.btnReporteVacaciones.ShowImage = true;
			this.btnReporteVacaciones.SuperTip = "Genera informes sobre las bitacoras de vacaciones.";
			this.btnReporteVacaciones.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnReporteVacaciones_Click);
			// 
			// separator1
			// 
			this.separator1.Name = "separator1";
			// 
			// btnCustomSQL
			// 
			this.btnCustomSQL.Label = "Importar con SQL";
			this.btnCustomSQL.Name = "btnCustomSQL";
			this.btnCustomSQL.OfficeImageId = "SqlSpecificMenu2";
			this.btnCustomSQL.ScreenTip = "Importar con SQL";
			this.btnCustomSQL.ShowImage = true;
			this.btnCustomSQL.SuperTip = "Permite ejecutar comandos SQL para importar datos de manera personalizada.";
			this.btnCustomSQL.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCustomSQL_Click);
			// 
			// separator2
			// 
			this.separator2.Name = "separator2";
			// 
			// btnConfiguracion
			// 
			this.btnConfiguracion.Label = "Configuración";
			this.btnConfiguracion.Name = "btnConfiguracion";
			this.btnConfiguracion.OfficeImageId = "GroupContTypeManage";
			this.btnConfiguracion.ScreenTip = "Configuración";
			this.btnConfiguracion.ShowImage = true;
			this.btnConfiguracion.SuperTip = "Permite cambiar los ajustes de conexión a las bases de datos y ajustar los datos " +
    "del chofer.";
			this.btnConfiguracion.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnConfiguracion_Click);
			// 
			// MainRibbon
			// 
			this.Name = "MainRibbon";
			this.RibbonType = "Microsoft.Excel.Workbook";
			this.Tabs.Add(this.tbNominasExcelNobleza);
			this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.MainRibbon_Load);
			this.tbNominasExcelNobleza.ResumeLayout(false);
			this.tbNominasExcelNobleza.PerformLayout();
			this.gpNominas.ResumeLayout(false);
			this.gpNominas.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		internal Microsoft.Office.Tools.Ribbon.RibbonTab tbNominasExcelNobleza;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup gpNominas;
		internal Microsoft.Office.Tools.Ribbon.RibbonMenu mnuNominasExcel;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnImportarReloj;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnImportarPermisos;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnReporteVacaciones;
		internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCustomSQL;
		internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnConfiguracion;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
	}

	partial class ThisRibbonCollection {
		internal MainRibbon MainRibbon {
			get { return this.GetRibbon<MainRibbon> ( ); }
		}
	}
}
