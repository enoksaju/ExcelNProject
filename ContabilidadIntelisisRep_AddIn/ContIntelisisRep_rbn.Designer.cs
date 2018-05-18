namespace ContabilidadIntelisisRep_AddIn {
	partial class ContIntelisisRep_rbn : Microsoft.Office.Tools.Ribbon.RibbonBase {
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public ContIntelisisRep_rbn ( )
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
			this.ContabilidadExcelIntelisi = this.Factory.CreateRibbonTab();
			this.group1 = this.Factory.CreateRibbonGroup();
			this.button1 = this.Factory.CreateRibbonButton();
			this.group2 = this.Factory.CreateRibbonGroup();
			this.IntegracionSaldosCxc_btn = this.Factory.CreateRibbonButton();
			this.button3 = this.Factory.CreateRibbonButton();
			this.group3 = this.Factory.CreateRibbonGroup();
			this.button2 = this.Factory.CreateRibbonButton();
			this.button4 = this.Factory.CreateRibbonButton();
			this.ContabilidadExcelIntelisi.SuspendLayout();
			this.group1.SuspendLayout();
			this.group2.SuspendLayout();
			this.group3.SuspendLayout();
			this.SuspendLayout();
			// 
			// ContabilidadExcelIntelisi
			// 
			this.ContabilidadExcelIntelisi.Groups.Add(this.group1);
			this.ContabilidadExcelIntelisi.Groups.Add(this.group2);
			this.ContabilidadExcelIntelisi.Groups.Add(this.group3);
			this.ContabilidadExcelIntelisi.Label = "Contabilidad Intelisis";
			this.ContabilidadExcelIntelisi.Name = "ContabilidadExcelIntelisi";
			// 
			// group1
			// 
			this.group1.Items.Add(this.button1);
			this.group1.Label = "Controles";
			this.group1.Name = "group1";
			// 
			// button1
			// 
			this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.button1.Image = global::ContabilidadIntelisisRep_AddIn.Properties.Resources.business_report;
			this.button1.Label = "Balanza Comp";
			this.button1.Name = "button1";
			this.button1.ShowImage = true;
			this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
			// 
			// group2
			// 
			this.group2.Items.Add(this.IntegracionSaldosCxc_btn);
			this.group2.Items.Add(this.button3);
			this.group2.Label = "Cxc";
			this.group2.Name = "group2";
			// 
			// IntegracionSaldosCxc_btn
			// 
			this.IntegracionSaldosCxc_btn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.IntegracionSaldosCxc_btn.Image = global::ContabilidadIntelisisRep_AddIn.Properties.Resources.data_table;
			this.IntegracionSaldosCxc_btn.Label = "Integración de Saldos Cxc";
			this.IntegracionSaldosCxc_btn.Name = "IntegracionSaldosCxc_btn";
			this.IntegracionSaldosCxc_btn.ShowImage = true;
			this.IntegracionSaldosCxc_btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.IntegracionSaldosCxc_btn_Click);
			// 
			// button3
			// 
			this.button3.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.button3.Image = global::ContabilidadIntelisisRep_AddIn.Properties.Resources.chart_stock;
			this.button3.Label = "Perdida/Ganancia Cambiaria Cxc";
			this.button3.Name = "button3";
			this.button3.ShowImage = true;
			this.button3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button3_Click);
			// 
			// group3
			// 
			this.group3.Items.Add(this.button2);
			this.group3.Items.Add(this.button4);
			this.group3.Label = "Cxp";
			this.group3.Name = "group3";
			// 
			// button2
			// 
			this.button2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.button2.Image = global::ContabilidadIntelisisRep_AddIn.Properties.Resources.data_table;
			this.button2.Label = "Integración de Saldos Cxp";
			this.button2.Name = "button2";
			this.button2.ShowImage = true;
			this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
			// 
			// button4
			// 
			this.button4.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.button4.Image = global::ContabilidadIntelisisRep_AddIn.Properties.Resources.chart_stock;
			this.button4.Label = "Perdida/Ganancia Cambiaria Cxp";
			this.button4.Name = "button4";
			this.button4.ShowImage = true;
			this.button4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button4_Click);
			// 
			// ContIntelisisRep_rbn
			// 
			this.Name = "ContIntelisisRep_rbn";
			this.RibbonType = "Microsoft.Excel.Workbook";
			this.Tabs.Add(this.ContabilidadExcelIntelisi);
			this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ContIntelisisRep_rbn_Load);
			this.ContabilidadExcelIntelisi.ResumeLayout(false);
			this.ContabilidadExcelIntelisi.PerformLayout();
			this.group1.ResumeLayout(false);
			this.group1.PerformLayout();
			this.group2.ResumeLayout(false);
			this.group2.PerformLayout();
			this.group3.ResumeLayout(false);
			this.group3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		internal Microsoft.Office.Tools.Ribbon.RibbonTab ContabilidadExcelIntelisi;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton IntegracionSaldosCxc_btn;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton button4;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
	}

	partial class ThisRibbonCollection {
		internal ContIntelisisRep_rbn ContIntelisisRep_rbn {
			get { return this.GetRibbon<ContIntelisisRep_rbn> ( ); }
		}
	}
}
