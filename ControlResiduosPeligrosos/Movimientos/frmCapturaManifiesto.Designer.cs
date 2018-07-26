namespace ControlResiduosPeligrosos.Movimientos
{
  partial class frmCapturaManifiesto
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
      System.Windows.Forms.Label noManifiestoLabel;
      System.Windows.Forms.Label fechaLabel;
      System.Windows.Forms.Label transportistaLabel;
      System.Windows.Forms.Label nombreChoferLabel;
      System.Windows.Forms.Label cargoChoferLabel;
      System.Windows.Forms.Label nombreReceptorLabel;
      System.Windows.Forms.Label cargoReceptorLabel;
      System.Windows.Forms.Label proveedorLabel;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapturaManifiesto));
      this.manifiestoBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.noManifiestoKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
      this.fechaKryptonDateTimePicker = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
      this.transportistaKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
      this.transportistaBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.nombreChoferKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
      this.cargoChoferKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
      this.nombreReceptorKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
      this.cargoReceptorKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
      this.manifiestoDetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.manifiestoDetalleDataGridView = new System.Windows.Forms.DataGridView();
      this.NombreRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.UnidadRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.noManifiestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.manifiestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.claveRPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tipoRPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.nombreRPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.unidadRPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.btnAddDetalle = new System.Windows.Forms.ToolStripButton();
      this.proveedorKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
      this.proveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
      noManifiestoLabel = new System.Windows.Forms.Label();
      fechaLabel = new System.Windows.Forms.Label();
      transportistaLabel = new System.Windows.Forms.Label();
      nombreChoferLabel = new System.Windows.Forms.Label();
      cargoChoferLabel = new System.Windows.Forms.Label();
      nombreReceptorLabel = new System.Windows.Forms.Label();
      cargoReceptorLabel = new System.Windows.Forms.Label();
      proveedorLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.manifiestoBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.transportistaKryptonComboBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.transportistaBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.manifiestoDetalleBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.manifiestoDetalleDataGridView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
      this.kryptonGroupBox1.Panel.SuspendLayout();
      this.kryptonGroupBox1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.proveedorKryptonComboBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // noManifiestoLabel
      // 
      noManifiestoLabel.AutoSize = true;
      noManifiestoLabel.Location = new System.Drawing.Point(32, 9);
      noManifiestoLabel.Name = "noManifiestoLabel";
      noManifiestoLabel.Size = new System.Drawing.Size(75, 13);
      noManifiestoLabel.TabIndex = 1;
      noManifiestoLabel.Text = "No Manifiesto:";
      // 
      // fechaLabel
      // 
      fechaLabel.AutoSize = true;
      fechaLabel.Location = new System.Drawing.Point(67, 38);
      fechaLabel.Name = "fechaLabel";
      fechaLabel.Size = new System.Drawing.Size(40, 13);
      fechaLabel.TabIndex = 2;
      fechaLabel.Text = "Fecha:";
      // 
      // transportistaLabel
      // 
      transportistaLabel.AutoSize = true;
      transportistaLabel.Location = new System.Drawing.Point(36, 65);
      transportistaLabel.Name = "transportistaLabel";
      transportistaLabel.Size = new System.Drawing.Size(71, 13);
      transportistaLabel.TabIndex = 4;
      transportistaLabel.Text = "Transportista:";
      // 
      // nombreChoferLabel
      // 
      nombreChoferLabel.AutoSize = true;
      nombreChoferLabel.Location = new System.Drawing.Point(26, 92);
      nombreChoferLabel.Name = "nombreChoferLabel";
      nombreChoferLabel.Size = new System.Drawing.Size(81, 13);
      nombreChoferLabel.TabIndex = 6;
      nombreChoferLabel.Text = "Nombre Chofer:";
      // 
      // cargoChoferLabel
      // 
      cargoChoferLabel.AutoSize = true;
      cargoChoferLabel.Location = new System.Drawing.Point(368, 92);
      cargoChoferLabel.Name = "cargoChoferLabel";
      cargoChoferLabel.Size = new System.Drawing.Size(38, 13);
      cargoChoferLabel.TabIndex = 8;
      cargoChoferLabel.Text = "Cargo:";
      // 
      // nombreReceptorLabel
      // 
      nombreReceptorLabel.AutoSize = true;
      nombreReceptorLabel.Location = new System.Drawing.Point(13, 148);
      nombreReceptorLabel.Name = "nombreReceptorLabel";
      nombreReceptorLabel.Size = new System.Drawing.Size(94, 13);
      nombreReceptorLabel.TabIndex = 10;
      nombreReceptorLabel.Text = "Nombre Receptor:";
      // 
      // cargoReceptorLabel
      // 
      cargoReceptorLabel.AutoSize = true;
      cargoReceptorLabel.Location = new System.Drawing.Point(368, 148);
      cargoReceptorLabel.Name = "cargoReceptorLabel";
      cargoReceptorLabel.Size = new System.Drawing.Size(38, 13);
      cargoReceptorLabel.TabIndex = 12;
      cargoReceptorLabel.Text = "Cargo:";
      // 
      // proveedorLabel
      // 
      proveedorLabel.AutoSize = true;
      proveedorLabel.Location = new System.Drawing.Point(48, 121);
      proveedorLabel.Name = "proveedorLabel";
      proveedorLabel.Size = new System.Drawing.Size(59, 13);
      proveedorLabel.TabIndex = 15;
      proveedorLabel.Text = "Proveedor:";
      // 
      // manifiestoBindingSource
      // 
      this.manifiestoBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Manifiesto);
      // 
      // noManifiestoKryptonTextBox
      // 
      this.noManifiestoKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.manifiestoBindingSource, "NoManifiesto", true));
      this.noManifiestoKryptonTextBox.Location = new System.Drawing.Point(113, 9);
      this.noManifiestoKryptonTextBox.Name = "noManifiestoKryptonTextBox";
      this.noManifiestoKryptonTextBox.Size = new System.Drawing.Size(100, 23);
      this.noManifiestoKryptonTextBox.TabIndex = 2;
      this.noManifiestoKryptonTextBox.Text = "kryptonTextBox1";
      // 
      // fechaKryptonDateTimePicker
      // 
      this.fechaKryptonDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.manifiestoBindingSource, "Fecha", true));
      this.fechaKryptonDateTimePicker.Location = new System.Drawing.Point(113, 38);
      this.fechaKryptonDateTimePicker.Name = "fechaKryptonDateTimePicker";
      this.fechaKryptonDateTimePicker.Size = new System.Drawing.Size(240, 21);
      this.fechaKryptonDateTimePicker.TabIndex = 3;
      // 
      // transportistaKryptonComboBox
      // 
      this.transportistaKryptonComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.manifiestoBindingSource, "ClaveT", true));
      this.transportistaKryptonComboBox.DataSource = this.transportistaBindingSource;
      this.transportistaKryptonComboBox.DisplayMember = "Denominacion";
      this.transportistaKryptonComboBox.DropDownWidth = 240;
      this.transportistaKryptonComboBox.Location = new System.Drawing.Point(113, 65);
      this.transportistaKryptonComboBox.Name = "transportistaKryptonComboBox";
      this.transportistaKryptonComboBox.Size = new System.Drawing.Size(240, 21);
      this.transportistaKryptonComboBox.TabIndex = 5;
      this.transportistaKryptonComboBox.ValueMember = "ClaveT";
      // 
      // transportistaBindingSource
      // 
      this.transportistaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Transportista);
      // 
      // nombreChoferKryptonTextBox
      // 
      this.nombreChoferKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.manifiestoBindingSource, "NombreChofer", true));
      this.nombreChoferKryptonTextBox.Location = new System.Drawing.Point(113, 92);
      this.nombreChoferKryptonTextBox.Name = "nombreChoferKryptonTextBox";
      this.nombreChoferKryptonTextBox.Size = new System.Drawing.Size(240, 23);
      this.nombreChoferKryptonTextBox.TabIndex = 7;
      this.nombreChoferKryptonTextBox.Text = "kryptonTextBox1";
      // 
      // cargoChoferKryptonTextBox
      // 
      this.cargoChoferKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.manifiestoBindingSource, "CargoChofer", true));
      this.cargoChoferKryptonTextBox.Location = new System.Drawing.Point(412, 92);
      this.cargoChoferKryptonTextBox.Name = "cargoChoferKryptonTextBox";
      this.cargoChoferKryptonTextBox.Size = new System.Drawing.Size(173, 23);
      this.cargoChoferKryptonTextBox.TabIndex = 9;
      this.cargoChoferKryptonTextBox.Text = "kryptonTextBox1";
      // 
      // nombreReceptorKryptonTextBox
      // 
      this.nombreReceptorKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.manifiestoBindingSource, "NombreReceptor", true));
      this.nombreReceptorKryptonTextBox.Location = new System.Drawing.Point(113, 148);
      this.nombreReceptorKryptonTextBox.Name = "nombreReceptorKryptonTextBox";
      this.nombreReceptorKryptonTextBox.Size = new System.Drawing.Size(240, 23);
      this.nombreReceptorKryptonTextBox.TabIndex = 11;
      this.nombreReceptorKryptonTextBox.Text = "kryptonTextBox1";
      // 
      // cargoReceptorKryptonTextBox
      // 
      this.cargoReceptorKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.manifiestoBindingSource, "CargoReceptor", true));
      this.cargoReceptorKryptonTextBox.Location = new System.Drawing.Point(412, 148);
      this.cargoReceptorKryptonTextBox.Name = "cargoReceptorKryptonTextBox";
      this.cargoReceptorKryptonTextBox.Size = new System.Drawing.Size(173, 23);
      this.cargoReceptorKryptonTextBox.TabIndex = 13;
      this.cargoReceptorKryptonTextBox.Text = "kryptonTextBox1";
      // 
      // manifiestoDetalleBindingSource
      // 
      this.manifiestoDetalleBindingSource.DataMember = "ManifiestoDetalle";
      this.manifiestoDetalleBindingSource.DataSource = this.manifiestoBindingSource;
      // 
      // manifiestoDetalleDataGridView
      // 
      this.manifiestoDetalleDataGridView.AllowUserToAddRows = false;
      this.manifiestoDetalleDataGridView.AutoGenerateColumns = false;
      this.manifiestoDetalleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.manifiestoDetalleDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreRP,
            this.UnidadRP,
            this.Count,
            this.Peso,
            this.idDataGridViewTextBoxColumn,
            this.noManifiestoDataGridViewTextBoxColumn,
            this.manifiestoDataGridViewTextBoxColumn,
            this.claveRPDataGridViewTextBoxColumn,
            this.tipoRPDataGridViewTextBoxColumn,
            this.pesoDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.nombreRPDataGridViewTextBoxColumn,
            this.unidadRPDataGridViewTextBoxColumn});
      this.manifiestoDetalleDataGridView.DataSource = this.manifiestoDetalleBindingSource;
      this.manifiestoDetalleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.manifiestoDetalleDataGridView.Location = new System.Drawing.Point(0, 25);
      this.manifiestoDetalleDataGridView.Name = "manifiestoDetalleDataGridView";
      this.manifiestoDetalleDataGridView.Size = new System.Drawing.Size(578, 208);
      this.manifiestoDetalleDataGridView.TabIndex = 14;
      // 
      // NombreRP
      // 
      this.NombreRP.DataPropertyName = "NombreRP";
      this.NombreRP.HeaderText = "NombreRP";
      this.NombreRP.Name = "NombreRP";
      this.NombreRP.ReadOnly = true;
      // 
      // UnidadRP
      // 
      this.UnidadRP.DataPropertyName = "UnidadRP";
      this.UnidadRP.HeaderText = "UnidadRP";
      this.UnidadRP.Name = "UnidadRP";
      this.UnidadRP.ReadOnly = true;
      // 
      // Count
      // 
      this.Count.DataPropertyName = "Count";
      this.Count.HeaderText = "Cantidad";
      this.Count.Name = "Count";
      this.Count.ReadOnly = true;
      // 
      // Peso
      // 
      this.Peso.DataPropertyName = "Peso";
      this.Peso.HeaderText = "Peso";
      this.Peso.Name = "Peso";
      this.Peso.ReadOnly = true;
      // 
      // idDataGridViewTextBoxColumn
      // 
      this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
      this.idDataGridViewTextBoxColumn.HeaderText = "Id";
      this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
      // 
      // noManifiestoDataGridViewTextBoxColumn
      // 
      this.noManifiestoDataGridViewTextBoxColumn.DataPropertyName = "NoManifiesto";
      this.noManifiestoDataGridViewTextBoxColumn.HeaderText = "NoManifiesto";
      this.noManifiestoDataGridViewTextBoxColumn.Name = "noManifiestoDataGridViewTextBoxColumn";
      // 
      // manifiestoDataGridViewTextBoxColumn
      // 
      this.manifiestoDataGridViewTextBoxColumn.DataPropertyName = "Manifiesto";
      this.manifiestoDataGridViewTextBoxColumn.HeaderText = "Manifiesto";
      this.manifiestoDataGridViewTextBoxColumn.Name = "manifiestoDataGridViewTextBoxColumn";
      // 
      // claveRPDataGridViewTextBoxColumn
      // 
      this.claveRPDataGridViewTextBoxColumn.DataPropertyName = "ClaveRP";
      this.claveRPDataGridViewTextBoxColumn.HeaderText = "ClaveRP";
      this.claveRPDataGridViewTextBoxColumn.Name = "claveRPDataGridViewTextBoxColumn";
      // 
      // tipoRPDataGridViewTextBoxColumn
      // 
      this.tipoRPDataGridViewTextBoxColumn.DataPropertyName = "TipoRP";
      this.tipoRPDataGridViewTextBoxColumn.HeaderText = "TipoRP";
      this.tipoRPDataGridViewTextBoxColumn.Name = "tipoRPDataGridViewTextBoxColumn";
      // 
      // pesoDataGridViewTextBoxColumn
      // 
      this.pesoDataGridViewTextBoxColumn.DataPropertyName = "Peso";
      this.pesoDataGridViewTextBoxColumn.HeaderText = "Peso";
      this.pesoDataGridViewTextBoxColumn.Name = "pesoDataGridViewTextBoxColumn";
      this.pesoDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // countDataGridViewTextBoxColumn
      // 
      this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
      this.countDataGridViewTextBoxColumn.HeaderText = "Count";
      this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
      this.countDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // nombreRPDataGridViewTextBoxColumn
      // 
      this.nombreRPDataGridViewTextBoxColumn.DataPropertyName = "NombreRP";
      this.nombreRPDataGridViewTextBoxColumn.HeaderText = "NombreRP";
      this.nombreRPDataGridViewTextBoxColumn.Name = "nombreRPDataGridViewTextBoxColumn";
      this.nombreRPDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // unidadRPDataGridViewTextBoxColumn
      // 
      this.unidadRPDataGridViewTextBoxColumn.DataPropertyName = "UnidadRP";
      this.unidadRPDataGridViewTextBoxColumn.HeaderText = "UnidadRP";
      this.unidadRPDataGridViewTextBoxColumn.Name = "unidadRPDataGridViewTextBoxColumn";
      this.unidadRPDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // kryptonGroupBox1
      // 
      this.kryptonGroupBox1.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.SeparatorLowProfile;
      this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 177);
      this.kryptonGroupBox1.Name = "kryptonGroupBox1";
      // 
      // kryptonGroupBox1.Panel
      // 
      this.kryptonGroupBox1.Panel.Controls.Add(this.manifiestoDetalleDataGridView);
      this.kryptonGroupBox1.Panel.Controls.Add(this.toolStrip1);
      this.kryptonGroupBox1.Size = new System.Drawing.Size(582, 257);
      this.kryptonGroupBox1.TabIndex = 15;
      this.kryptonGroupBox1.Values.Heading = "Detalla de Manifiesto";
      // 
      // toolStrip1
      // 
      this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddDetalle});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(578, 25);
      this.toolStrip1.TabIndex = 15;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // btnAddDetalle
      // 
      this.btnAddDetalle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnAddDetalle.Image = ((System.Drawing.Image)(resources.GetObject("btnAddDetalle.Image")));
      this.btnAddDetalle.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnAddDetalle.Name = "btnAddDetalle";
      this.btnAddDetalle.Size = new System.Drawing.Size(23, 22);
      this.btnAddDetalle.Text = "toolStripButton1";
      this.btnAddDetalle.Click += new System.EventHandler(this.btnAddDetalle_Click);
      // 
      // proveedorKryptonComboBox
      // 
      this.proveedorKryptonComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.manifiestoBindingSource, "ClaveP", true));
      this.proveedorKryptonComboBox.DataSource = this.proveedorBindingSource;
      this.proveedorKryptonComboBox.DisplayMember = "Denominacion";
      this.proveedorKryptonComboBox.DropDownWidth = 240;
      this.proveedorKryptonComboBox.Location = new System.Drawing.Point(113, 121);
      this.proveedorKryptonComboBox.Name = "proveedorKryptonComboBox";
      this.proveedorKryptonComboBox.Size = new System.Drawing.Size(240, 21);
      this.proveedorKryptonComboBox.TabIndex = 16;
      this.proveedorKryptonComboBox.ValueMember = "ClaveP";
      // 
      // proveedorBindingSource
      // 
      this.proveedorBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Proveedor);
      // 
      // kryptonButton1
      // 
      this.kryptonButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.kryptonButton1.Location = new System.Drawing.Point(479, 440);
      this.kryptonButton1.Name = "kryptonButton1";
      this.kryptonButton1.Size = new System.Drawing.Size(115, 31);
      this.kryptonButton1.TabIndex = 17;
      this.kryptonButton1.Values.Text = "Guardar";
      this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
      // 
      // frmCapturaManifiesto
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(606, 483);
      this.Controls.Add(this.kryptonButton1);
      this.Controls.Add(proveedorLabel);
      this.Controls.Add(this.proveedorKryptonComboBox);
      this.Controls.Add(this.kryptonGroupBox1);
      this.Controls.Add(cargoReceptorLabel);
      this.Controls.Add(this.cargoReceptorKryptonTextBox);
      this.Controls.Add(nombreReceptorLabel);
      this.Controls.Add(this.nombreReceptorKryptonTextBox);
      this.Controls.Add(cargoChoferLabel);
      this.Controls.Add(this.cargoChoferKryptonTextBox);
      this.Controls.Add(nombreChoferLabel);
      this.Controls.Add(this.nombreChoferKryptonTextBox);
      this.Controls.Add(transportistaLabel);
      this.Controls.Add(this.transportistaKryptonComboBox);
      this.Controls.Add(fechaLabel);
      this.Controls.Add(this.fechaKryptonDateTimePicker);
      this.Controls.Add(noManifiestoLabel);
      this.Controls.Add(this.noManifiestoKryptonTextBox);
      this.Name = "frmCapturaManifiesto";
      this.Text = "Captura de Manifiesto";
      ((System.ComponentModel.ISupportInitialize)(this.manifiestoBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.transportistaKryptonComboBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.transportistaBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.manifiestoDetalleBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.manifiestoDetalleDataGridView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
      this.kryptonGroupBox1.Panel.ResumeLayout(false);
      this.kryptonGroupBox1.Panel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
      this.kryptonGroupBox1.ResumeLayout(false);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.proveedorKryptonComboBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.BindingSource manifiestoBindingSource;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox noManifiestoKryptonTextBox;
    private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker fechaKryptonDateTimePicker;
    private ComponentFactory.Krypton.Toolkit.KryptonComboBox transportistaKryptonComboBox;
    private System.Windows.Forms.BindingSource transportistaBindingSource;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox nombreChoferKryptonTextBox;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox cargoChoferKryptonTextBox;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox nombreReceptorKryptonTextBox;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox cargoReceptorKryptonTextBox;
    private System.Windows.Forms.BindingSource manifiestoDetalleBindingSource;
    private System.Windows.Forms.DataGridView manifiestoDetalleDataGridView;
    private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton btnAddDetalle;
    private ComponentFactory.Krypton.Toolkit.KryptonComboBox proveedorKryptonComboBox;
    private System.Windows.Forms.BindingSource proveedorBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn NombreRP;
    private System.Windows.Forms.DataGridViewTextBoxColumn UnidadRP;
    private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    private System.Windows.Forms.DataGridViewTextBoxColumn Peso;
    private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn noManifiestoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn manifiestoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn claveRPDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn tipoRPDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn pesoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn nombreRPDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn unidadRPDataGridViewTextBoxColumn;
    private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
  }
}