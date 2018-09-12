namespace ControlResiduosPeligrosos.Reportes
{
  partial class frmBitacora
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
			this.components = new System.ComponentModel.Container();
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBitacora));
			this.VstSalidaRPBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.btnMostrar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txtNoManifiesto = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.dtFechaFinal = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
			this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.dtFechaInicial = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			((System.ComponentModel.ISupportInitialize)(this.VstSalidaRPBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
			this.kryptonGroupBox1.Panel.SuspendLayout();
			this.kryptonGroupBox1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// VstSalidaRPBindingSource
			// 
			this.VstSalidaRPBindingSource.DataSource = typeof(ControlResiduosPeligrosos.Reportes.Vistas.VstSalidaRP);
			// 
			// kryptonGroupBox1
			// 
			this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonGroupBox1.Location = new System.Drawing.Point(3, 3);
			this.kryptonGroupBox1.Name = "kryptonGroupBox1";
			// 
			// kryptonGroupBox1.Panel
			// 
			this.kryptonGroupBox1.Panel.Controls.Add(this.tableLayoutPanel2);
			this.kryptonGroupBox1.Panel.Controls.Add(this.txtNoManifiesto);
			this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel3);
			this.kryptonGroupBox1.Panel.Controls.Add(this.dtFechaFinal);
			this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel2);
			this.kryptonGroupBox1.Panel.Controls.Add(this.dtFechaInicial);
			this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
			this.kryptonGroupBox1.Panel.Padding = new System.Windows.Forms.Padding(3);
			this.kryptonGroupBox1.Size = new System.Drawing.Size(155, 444);
			this.kryptonGroupBox1.TabIndex = 1;
			this.kryptonGroupBox1.Values.Heading = "Opciones";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.24138F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.75862F));
			this.tableLayoutPanel2.Controls.Add(this.btnMostrar, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 128);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(145, 33);
			this.tableLayoutPanel2.TabIndex = 6;
			// 
			// btnMostrar
			// 
			this.btnMostrar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnMostrar.Location = new System.Drawing.Point(56, 3);
			this.btnMostrar.Name = "btnMostrar";
			this.btnMostrar.Size = new System.Drawing.Size(86, 27);
			this.btnMostrar.TabIndex = 0;
			this.btnMostrar.Values.Text = "Mostrar";
			this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
			// 
			// txtNoManifiesto
			// 
			this.txtNoManifiesto.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtNoManifiesto.Location = new System.Drawing.Point(3, 105);
			this.txtNoManifiesto.Name = "txtNoManifiesto";
			this.txtNoManifiesto.Size = new System.Drawing.Size(145, 23);
			this.txtNoManifiesto.TabIndex = 5;
			// 
			// kryptonLabel3
			// 
			this.kryptonLabel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel3.Location = new System.Drawing.Point(3, 85);
			this.kryptonLabel3.Name = "kryptonLabel3";
			this.kryptonLabel3.Size = new System.Drawing.Size(145, 20);
			this.kryptonLabel3.TabIndex = 4;
			this.kryptonLabel3.Values.Text = "No. Manifiesto:";
			// 
			// dtFechaFinal
			// 
			this.dtFechaFinal.CustomFormat = "dd MM yyyy";
			this.dtFechaFinal.Dock = System.Windows.Forms.DockStyle.Top;
			this.dtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtFechaFinal.Location = new System.Drawing.Point(3, 64);
			this.dtFechaFinal.Name = "dtFechaFinal";
			this.dtFechaFinal.Size = new System.Drawing.Size(145, 21);
			this.dtFechaFinal.TabIndex = 3;
			// 
			// kryptonLabel2
			// 
			this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel2.Location = new System.Drawing.Point(3, 44);
			this.kryptonLabel2.Name = "kryptonLabel2";
			this.kryptonLabel2.Size = new System.Drawing.Size(145, 20);
			this.kryptonLabel2.TabIndex = 2;
			this.kryptonLabel2.Values.Text = "Fecha Fin:";
			// 
			// dtFechaInicial
			// 
			this.dtFechaInicial.CustomFormat = "dd MM yyyy";
			this.dtFechaInicial.Dock = System.Windows.Forms.DockStyle.Top;
			this.dtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtFechaInicial.Location = new System.Drawing.Point(3, 23);
			this.dtFechaInicial.Name = "dtFechaInicial";
			this.dtFechaInicial.Size = new System.Drawing.Size(145, 21);
			this.dtFechaInicial.TabIndex = 1;
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel1.Location = new System.Drawing.Point(3, 3);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(145, 20);
			this.kryptonLabel1.TabIndex = 0;
			this.kryptonLabel1.Values.Text = "Fecha Inicial:";
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(800, 450);
			this.kryptonPanel1.TabIndex = 2;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.125F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.875F));
			this.tableLayoutPanel1.Controls.Add(this.kryptonGroupBox1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.reportViewer1, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// reportViewer1
			// 
			this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			reportDataSource1.Name = "DataSet1";
			reportDataSource1.Value = this.VstSalidaRPBindingSource;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "ControlResiduosPeligrosos.Reportes.repBitacora.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(164, 3);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.Size = new System.Drawing.Size(633, 444);
			this.reportViewer1.TabIndex = 2;
			// 
			// frmBitacora
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.kryptonPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmBitacora";
			this.Text = "Bitacora";
			this.Load += new System.EventHandler(this.frmBitacora_Load);
			((System.ComponentModel.ISupportInitialize)(this.VstSalidaRPBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
			this.kryptonGroupBox1.Panel.ResumeLayout(false);
			this.kryptonGroupBox1.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
			this.kryptonGroupBox1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.BindingSource VstSalidaRPBindingSource;
    private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
    private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
    private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtFechaFinal;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
    private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtFechaInicial;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNoManifiesto;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private ComponentFactory.Krypton.Toolkit.KryptonButton btnMostrar;
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
	}
}