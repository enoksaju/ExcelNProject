namespace libIntelisisReports.Controles
{
	partial class TransferenciasOT
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
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
			this.itmCvBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.ot_txt = new System.Windows.Forms.ToolStripTextBox();
			this.fill_btn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.progress_pb = new System.Windows.Forms.ToolStripProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.itmCvBindingSource)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// itmCvBindingSource
			// 
			this.itmCvBindingSource.DataSource = typeof(libIntelisisReports.Models.CierreOrdenesItmObj.itmCv);
			// 
			// reportViewer1
			// 
			this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.reportViewer1.DocumentMapWidth = 250;
			reportDataSource1.Name = "transferencias";
			reportDataSource1.Value = this.itmCvBindingSource;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "libIntelisisReports.Reportes.rptCierreOrdenesLineas.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(0, 25);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ShowBackButton = false;
			this.reportViewer1.Size = new System.Drawing.Size(584, 355);
			this.reportViewer1.TabIndex = 0;
			this.reportViewer1.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.reportViewer1_ReportRefresh);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ot_txt,
            this.fill_btn,
            this.toolStripSeparator1,
            this.progress_pb});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(584, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// ot_txt
			// 
			this.ot_txt.Name = "ot_txt";
			this.ot_txt.Size = new System.Drawing.Size(100, 25);
			this.ot_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ot_txt_KeyDown);
			// 
			// fill_btn
			// 
			this.fill_btn.Image = global::libIntelisisReports.Properties.Resources.blank_report;
			this.fill_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fill_btn.Name = "fill_btn";
			this.fill_btn.Size = new System.Drawing.Size(59, 22);
			this.fill_btn.Text = "Llenar";
			this.fill_btn.Click += new System.EventHandler(this.fill_btn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// progress_pb
			// 
			this.progress_pb.Name = "progress_pb";
			this.progress_pb.Size = new System.Drawing.Size(100, 22);
			this.progress_pb.Visible = false;
			// 
			// TransferenciasOT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.reportViewer1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "TransferenciasOT";
			this.Size = new System.Drawing.Size(584, 380);
			this.Load += new System.EventHandler(this.TransferenciasOT_Load);
			((System.ComponentModel.ISupportInitialize)(this.itmCvBindingSource)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private System.Windows.Forms.BindingSource itmCvBindingSource;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripTextBox ot_txt;
		private System.Windows.Forms.ToolStripButton fill_btn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripProgressBar progress_pb;
	}
}
