using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using libIntelisisReports.ExcelNoblezaDataSetTableAdapters;
using Microsoft.Reporting.WinForms;

namespace libIntelisisReports.Controles
{
	partial class ctlCierreOrdenes
	{


		/// <summary> 
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Código generado por el Diseñador de componentes

		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent ()
		{
			this.components = new System.ComponentModel.Container();
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
			this.MovOtBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.CapacitaExcelNDataSet = new libIntelisisReports.ExcelNoblezaDataSet();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.MovOtTableAdapter = new libIntelisisReports.ExcelNoblezaDataSetTableAdapters.CierreOrdenesTableAdapter();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.MovOtBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CapacitaExcelNDataSet)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// MovOtBindingSource
			// 
			this.MovOtBindingSource.DataMember = "CierreOrdenes";
			this.MovOtBindingSource.DataSource = this.CapacitaExcelNDataSet;
			// 
			// CapacitaExcelNDataSet
			// 
			this.CapacitaExcelNDataSet.DataSetName = "CapacitaExcelNDataSet";
			this.CapacitaExcelNDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// reportViewer1
			// 
			this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			reportDataSource2.Name = "DataSet1";
			reportDataSource2.Value = this.MovOtBindingSource;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
			this.reportViewer1.LocalReport.DisplayName = "Cierre de Orden de Trabajo";
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "libIntelisisReports.Reportes.rptCierreOrdenes.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(0, 54);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ShowBackButton = false;
			this.reportViewer1.ShowFindControls = false;
			this.reportViewer1.ShowRefreshButton = false;
			this.reportViewer1.ShowStopButton = false;
			this.reportViewer1.Size = new System.Drawing.Size(635, 372);
			this.reportViewer1.TabIndex = 3;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(635, 29);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(3, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(163, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button1.Location = new System.Drawing.Point(172, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(98, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Ver";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MovOtTableAdapter
			// 
			this.MovOtTableAdapter.ClearBeforeFill = true;
			// 
			// progressBar1
			// 
			this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.progressBar1.Location = new System.Drawing.Point(0, 29);
			this.progressBar1.MarqueeAnimationSpeed = 50;
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(635, 25);
			this.progressBar1.TabIndex = 2;
			this.progressBar1.UseWaitCursor = true;
			this.progressBar1.Value = 100;
			this.progressBar1.Visible = false;
			// 
			// ctlCierreOrdenes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.reportViewer1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "ctlCierreOrdenes";
			this.Size = new System.Drawing.Size(635, 426);
			((System.ComponentModel.ISupportInitialize)(this.MovOtBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CapacitaExcelNDataSet)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
				
		
		private ReportViewer reportViewer1;
		private BindingSource MovOtBindingSource;
		private ExcelNoblezaDataSet CapacitaExcelNDataSet;
		private CierreOrdenesTableAdapter MovOtTableAdapter;
		private TableLayoutPanel tableLayoutPanel1;
		private TextBox textBox1;
		private Button button1;
		private ProgressBar progressBar1;
	}
}
