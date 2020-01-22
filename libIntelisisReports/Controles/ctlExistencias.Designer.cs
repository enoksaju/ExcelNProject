namespace libIntelisisReports.Controles
{
	partial class ctlExistencias
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
			this.existenciasLineasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.excelNoblezaDataSet = new libIntelisisReports.ExcelNoblezaDataSet();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.existenciasLineasTableAdapter = new libIntelisisReports.ExcelNoblezaDataSetTableAdapters.ExistenciasLineasTableAdapter();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.existenciasLineasBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.excelNoblezaDataSet)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// existenciasLineasBindingSource
			// 
			this.existenciasLineasBindingSource.DataMember = "ExistenciasLineas";
			this.existenciasLineasBindingSource.DataSource = this.excelNoblezaDataSet;
			// 
			// excelNoblezaDataSet
			// 
			this.excelNoblezaDataSet.DataSetName = "ExcelNoblezaDataSet";
			this.excelNoblezaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// reportViewer1
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.reportViewer1, 4);
			this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.reportViewer1.DocumentMapWidth = 49;
			reportDataSource1.Name = "ExistenciasDataSet";
			reportDataSource1.Value = this.existenciasLineasBindingSource;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "libIntelisisReports.Reportes.rptExistencias.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(3, 30);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.Size = new System.Drawing.Size(513, 292);
			this.reportViewer1.TabIndex = 0;
			// 
			// existenciasLineasTableAdapter
			// 
			this.existenciasLineasTableAdapter.ClearBeforeFill = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.reportViewer1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.comboBox1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(519, 325);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// comboBox1
			// 
			this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "TRANSITO)",
            "AVIOS     ",
            "BOLCIMP",
            "BOLSAS ",
            "BOLSIMP",
            "CALIDAD",
            "CARNEVA",
            "DESPER    ",
            "DEV-CONVER",
            "EXTRU  ",
            "LAMXEST",
            "LAMXEXT",
            "MANGA  ",
            "MANYPVC",
            "Maquila",
            "MATPRIMA  ",
            "METAL  ",
            "MI   ",
            "MPTRANSITO",
            "N8   ",
            "PENAVE7",
            "PEXTRUS",
            "PPXTRUS",
            "PREPREN",
            "PROYECT",
            "PVC   ",
            "RCALMACEN ",
            "RECHAZADOS",
            "RECORTE",
            "REVISION  ",
            "SCHIAVI",
            "SERVICIOS ",
            "TACHIS ",
            "TERMINADO ",
            "TINTAS    ",
            "UTECO1 ",
            "UTECO2 ",
            "UTECO3 ",
            "VANGUAR",
            "VENTAS ",
            "WH   "});
			this.comboBox1.Location = new System.Drawing.Point(3, 3);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(145, 21);
			this.comboBox1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button1.Location = new System.Drawing.Point(154, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(76, 21);
			this.button1.TabIndex = 2;
			this.button1.Text = "Llenar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ctlExistencias
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "ctlExistencias";
			this.Size = new System.Drawing.Size(519, 325);
			((System.ComponentModel.ISupportInitialize)(this.existenciasLineasBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.excelNoblezaDataSet)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private System.Windows.Forms.BindingSource existenciasLineasBindingSource;
		private ExcelNoblezaDataSet excelNoblezaDataSet;
		private ExcelNoblezaDataSetTableAdapters.ExistenciasLineasTableAdapter existenciasLineasTableAdapter;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button1;
	}
}
