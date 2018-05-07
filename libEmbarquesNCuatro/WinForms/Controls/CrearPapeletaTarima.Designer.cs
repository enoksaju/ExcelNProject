namespace libEmbarquesNCuatro.WinForms.Controls {
	partial class CrearPapeletaTarima {
		/// <summary> 
		/// Variable del diseñador necesaria.decimal
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			ComponentFactory.Krypton.Toolkit.KryptonLabel oTLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel pRODUCTOLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel cLIENTELabel;
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
			this.ReportModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.temporalOrdenTrabajoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.kryptonListBox1 = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
			this.tarimasNCuatroBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.cLIENTEKryptonLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			oTLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			pRODUCTOLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			cLIENTELabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			((System.ComponentModel.ISupportInitialize)(this.ReportModelBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.temporalOrdenTrabajoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tarimasNCuatroBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
			this.kryptonGroupBox1.Panel.SuspendLayout();
			this.kryptonGroupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// oTLabel
			// 
			oTLabel.Dock = System.Windows.Forms.DockStyle.Right;
			oTLabel.Location = new System.Drawing.Point(61, 3);
			oTLabel.Name = "oTLabel";
			oTLabel.Size = new System.Drawing.Size(29, 23);
			oTLabel.TabIndex = 1;
			oTLabel.Values.Text = "OT:";
			// 
			// pRODUCTOLabel
			// 
			pRODUCTOLabel.Dock = System.Windows.Forms.DockStyle.Right;
			pRODUCTOLabel.Location = new System.Drawing.Point(13, 61);
			pRODUCTOLabel.Name = "pRODUCTOLabel";
			pRODUCTOLabel.Size = new System.Drawing.Size(77, 23);
			pRODUCTOLabel.TabIndex = 2;
			pRODUCTOLabel.Values.Text = "PRODUCTO:";
			// 
			// cLIENTELabel
			// 
			cLIENTELabel.Dock = System.Windows.Forms.DockStyle.Right;
			cLIENTELabel.Location = new System.Drawing.Point(32, 32);
			cLIENTELabel.Name = "cLIENTELabel";
			cLIENTELabel.Size = new System.Drawing.Size(58, 23);
			cLIENTELabel.TabIndex = 4;
			cLIENTELabel.Values.Text = "CLIENTE:";
			// 
			// ReportModelBindingSource
			// 
			this.ReportModelBindingSource.DataSource = typeof(libEmbarquesNCuatro.Models.ReportModel);
			// 
			// temporalOrdenTrabajoBindingSource
			// 
			this.temporalOrdenTrabajoBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.TemporalOrdenTrabajo);
			// 
			// kryptonListBox1
			// 
			this.kryptonListBox1.DataSource = this.tarimasNCuatroBindingSource;
			this.kryptonListBox1.DisplayMember = "Id";
			this.kryptonListBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.kryptonListBox1.Location = new System.Drawing.Point(5, 116);
			this.kryptonListBox1.Name = "kryptonListBox1";
			this.kryptonListBox1.Size = new System.Drawing.Size(120, 341);
			this.kryptonListBox1.TabIndex = 6;
			this.kryptonListBox1.SelectedValueChanged += new System.EventHandler(this.kryptonListBox1_SelectedValueChanged);
			// 
			// tarimasNCuatroBindingSource
			// 
			this.tarimasNCuatroBindingSource.DataMember = "TarimasNCuatro";
			this.tarimasNCuatroBindingSource.DataSource = this.temporalOrdenTrabajoBindingSource;
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.reportViewer1);
			this.kryptonPanel1.Controls.Add(this.kryptonListBox1);
			this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Padding = new System.Windows.Forms.Padding(5);
			this.kryptonPanel1.Size = new System.Drawing.Size(665, 462);
			this.kryptonPanel1.TabIndex = 8;
			// 
			// reportViewer1
			// 
			this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			reportDataSource1.Name = "ReportModelDataSet";
			reportDataSource1.Value = this.ReportModelBindingSource;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.EnableExternalImages = true;
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "libEmbarquesNCuatro.WinForms.Controls.Report1.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(131, 122);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.Size = new System.Drawing.Size(529, 337);
			this.reportViewer1.TabIndex = 8;
			// 
			// kryptonGroupBox1
			// 
			this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.kryptonGroupBox1.Location = new System.Drawing.Point(5, 5);
			this.kryptonGroupBox1.Name = "kryptonGroupBox1";
			// 
			// kryptonGroupBox1.Panel
			// 
			this.kryptonGroupBox1.Panel.Controls.Add(this.tableLayoutPanel1);
			this.kryptonGroupBox1.Size = new System.Drawing.Size(655, 111);
			this.kryptonGroupBox1.TabIndex = 7;
			this.kryptonGroupBox1.Values.Heading = "Datos de la Orden de Trabajo";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoScroll = true;
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(pRODUCTOLabel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(oTLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(cLIENTELabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.cLIENTEKryptonLabel, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(651, 87);
			this.tableLayoutPanel1.TabIndex = 6;
			// 
			// cLIENTEKryptonLabel
			// 
			this.cLIENTEKryptonLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.temporalOrdenTrabajoBindingSource, "CLIENTE", true));
			this.cLIENTEKryptonLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cLIENTEKryptonLabel.Location = new System.Drawing.Point(96, 32);
			this.cLIENTEKryptonLabel.Name = "cLIENTEKryptonLabel";
			this.cLIENTEKryptonLabel.Size = new System.Drawing.Size(552, 23);
			this.cLIENTEKryptonLabel.TabIndex = 5;
			this.cLIENTEKryptonLabel.Values.Text = "kryptonLabel1";
			// 
			// CrearPapeletaTarima
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.kryptonPanel1);
			this.Name = "CrearPapeletaTarima";
			this.Size = new System.Drawing.Size(665, 462);
			this.Load += new System.EventHandler(this.CrearPapeletaTarima_Load);
			((System.ComponentModel.ISupportInitialize)(this.ReportModelBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.temporalOrdenTrabajoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tarimasNCuatroBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
			this.kryptonGroupBox1.Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
			this.kryptonGroupBox1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.BindingSource temporalOrdenTrabajoBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonListBox kryptonListBox1;
		private System.Windows.Forms.BindingSource tarimasNCuatroBindingSource;
		private System.Windows.Forms.BindingSource itemsBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private System.Windows.Forms.BindingSource ReportModelBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel cLIENTEKryptonLabel;
	}
}
