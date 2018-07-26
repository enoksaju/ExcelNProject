namespace ControlResiduosPeligrosos.Movimientos
{
  partial class frmLigarSalidasRP_DetalleManifiesto
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
      System.Windows.Forms.Label claveRPLabel;
      this.claveRPKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
      this.manifiestoDetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tipoRPBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.salidaResiduosPeligrososBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.salidaResiduosPeligrososKryptonDataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
      this.Selector = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.FolioRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FechaEnvasado = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.folioRPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.claveRPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.claveLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.fechaEnvasadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.fechaIngresoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.folioDMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.manifiestoDetalleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tipoRPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.lineaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
      this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
      claveRPLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.claveRPKryptonComboBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.manifiestoDetalleBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.tipoRPBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.salidaResiduosPeligrososBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.salidaResiduosPeligrososKryptonDataGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // claveRPLabel
      // 
      claveRPLabel.AutoSize = true;
      claveRPLabel.Location = new System.Drawing.Point(12, 12);
      claveRPLabel.Name = "claveRPLabel";
      claveRPLabel.Size = new System.Drawing.Size(55, 13);
      claveRPLabel.TabIndex = 1;
      claveRPLabel.Text = "Clave RP:";
      // 
      // claveRPKryptonComboBox
      // 
      this.claveRPKryptonComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.manifiestoDetalleBindingSource, "ClaveRP", true));
      this.claveRPKryptonComboBox.DataSource = this.tipoRPBindingSource;
      this.claveRPKryptonComboBox.DisplayMember = "Descripcion";
      this.claveRPKryptonComboBox.DropDownWidth = 121;
      this.claveRPKryptonComboBox.Location = new System.Drawing.Point(73, 12);
      this.claveRPKryptonComboBox.Name = "claveRPKryptonComboBox";
      this.claveRPKryptonComboBox.Size = new System.Drawing.Size(248, 21);
      this.claveRPKryptonComboBox.TabIndex = 2;
      this.claveRPKryptonComboBox.ValueMember = "ClaveRP";
      // 
      // manifiestoDetalleBindingSource
      // 
      this.manifiestoDetalleBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.ObservableListSource<libProduccionDataBase.Tablas.ManifiestoDetalle>);
      // 
      // tipoRPBindingSource
      // 
      this.tipoRPBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.TipoRP);
      this.tipoRPBindingSource.CurrentItemChanged += new System.EventHandler(this.tipoRPBindingSource_CurrentItemChanged);
      // 
      // salidaResiduosPeligrososBindingSource
      // 
      this.salidaResiduosPeligrososBindingSource.DataMember = "SalidaResiduosPeligrosos";
      this.salidaResiduosPeligrososBindingSource.DataSource = this.manifiestoDetalleBindingSource;
      // 
      // salidaResiduosPeligrososKryptonDataGridView
      // 
      this.salidaResiduosPeligrososKryptonDataGridView.AllowUserToAddRows = false;
      this.salidaResiduosPeligrososKryptonDataGridView.AllowUserToDeleteRows = false;
      this.salidaResiduosPeligrososKryptonDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.salidaResiduosPeligrososKryptonDataGridView.AutoGenerateColumns = false;
      this.salidaResiduosPeligrososKryptonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.salidaResiduosPeligrososKryptonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selector,
            this.FolioRP,
            this.FechaEnvasado,
            this.Cantidad,
            this.Linea,
            this.folioRPDataGridViewTextBoxColumn,
            this.claveRPDataGridViewTextBoxColumn,
            this.claveLDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.fechaEnvasadoDataGridViewTextBoxColumn,
            this.fechaIngresoDataGridViewTextBoxColumn,
            this.folioDMDataGridViewTextBoxColumn,
            this.manifiestoDetalleDataGridViewTextBoxColumn,
            this.tipoRPDataGridViewTextBoxColumn,
            this.lineaDataGridViewTextBoxColumn});
      this.salidaResiduosPeligrososKryptonDataGridView.DataSource = this.salidaResiduosPeligrososBindingSource;
      this.salidaResiduosPeligrososKryptonDataGridView.Location = new System.Drawing.Point(12, 54);
      this.salidaResiduosPeligrososKryptonDataGridView.Name = "salidaResiduosPeligrososKryptonDataGridView";
      this.salidaResiduosPeligrososKryptonDataGridView.Size = new System.Drawing.Size(608, 305);
      this.salidaResiduosPeligrososKryptonDataGridView.TabIndex = 2;
      // 
      // Selector
      // 
      this.Selector.HeaderText = "Sel";
      this.Selector.Name = "Selector";
      // 
      // FolioRP
      // 
      this.FolioRP.DataPropertyName = "FolioRP";
      this.FolioRP.HeaderText = "FolioRP";
      this.FolioRP.Name = "FolioRP";
      this.FolioRP.ReadOnly = true;
      // 
      // FechaEnvasado
      // 
      this.FechaEnvasado.DataPropertyName = "FechaEnvasado";
      this.FechaEnvasado.HeaderText = "FechaEnvasado";
      this.FechaEnvasado.Name = "FechaEnvasado";
      this.FechaEnvasado.ReadOnly = true;
      // 
      // Cantidad
      // 
      this.Cantidad.DataPropertyName = "Cantidad";
      this.Cantidad.HeaderText = "Peso";
      this.Cantidad.Name = "Cantidad";
      this.Cantidad.ReadOnly = true;
      // 
      // Linea
      // 
      this.Linea.DataPropertyName = "Linea";
      this.Linea.HeaderText = "Linea";
      this.Linea.Name = "Linea";
      this.Linea.ReadOnly = true;
      // 
      // folioRPDataGridViewTextBoxColumn
      // 
      this.folioRPDataGridViewTextBoxColumn.DataPropertyName = "FolioRP";
      this.folioRPDataGridViewTextBoxColumn.HeaderText = "FolioRP";
      this.folioRPDataGridViewTextBoxColumn.Name = "folioRPDataGridViewTextBoxColumn";
      // 
      // claveRPDataGridViewTextBoxColumn
      // 
      this.claveRPDataGridViewTextBoxColumn.DataPropertyName = "ClaveRP";
      this.claveRPDataGridViewTextBoxColumn.HeaderText = "ClaveRP";
      this.claveRPDataGridViewTextBoxColumn.Name = "claveRPDataGridViewTextBoxColumn";
      // 
      // claveLDataGridViewTextBoxColumn
      // 
      this.claveLDataGridViewTextBoxColumn.DataPropertyName = "ClaveL";
      this.claveLDataGridViewTextBoxColumn.HeaderText = "ClaveL";
      this.claveLDataGridViewTextBoxColumn.Name = "claveLDataGridViewTextBoxColumn";
      // 
      // cantidadDataGridViewTextBoxColumn
      // 
      this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
      this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
      this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
      // 
      // fechaEnvasadoDataGridViewTextBoxColumn
      // 
      this.fechaEnvasadoDataGridViewTextBoxColumn.DataPropertyName = "FechaEnvasado";
      this.fechaEnvasadoDataGridViewTextBoxColumn.HeaderText = "FechaEnvasado";
      this.fechaEnvasadoDataGridViewTextBoxColumn.Name = "fechaEnvasadoDataGridViewTextBoxColumn";
      // 
      // fechaIngresoDataGridViewTextBoxColumn
      // 
      this.fechaIngresoDataGridViewTextBoxColumn.DataPropertyName = "FechaIngreso";
      this.fechaIngresoDataGridViewTextBoxColumn.HeaderText = "FechaIngreso";
      this.fechaIngresoDataGridViewTextBoxColumn.Name = "fechaIngresoDataGridViewTextBoxColumn";
      // 
      // folioDMDataGridViewTextBoxColumn
      // 
      this.folioDMDataGridViewTextBoxColumn.DataPropertyName = "FolioDM";
      this.folioDMDataGridViewTextBoxColumn.HeaderText = "FolioDM";
      this.folioDMDataGridViewTextBoxColumn.Name = "folioDMDataGridViewTextBoxColumn";
      // 
      // manifiestoDetalleDataGridViewTextBoxColumn
      // 
      this.manifiestoDetalleDataGridViewTextBoxColumn.DataPropertyName = "ManifiestoDetalle";
      this.manifiestoDetalleDataGridViewTextBoxColumn.HeaderText = "ManifiestoDetalle";
      this.manifiestoDetalleDataGridViewTextBoxColumn.Name = "manifiestoDetalleDataGridViewTextBoxColumn";
      // 
      // tipoRPDataGridViewTextBoxColumn
      // 
      this.tipoRPDataGridViewTextBoxColumn.DataPropertyName = "TipoRP";
      this.tipoRPDataGridViewTextBoxColumn.HeaderText = "TipoRP";
      this.tipoRPDataGridViewTextBoxColumn.Name = "tipoRPDataGridViewTextBoxColumn";
      // 
      // lineaDataGridViewTextBoxColumn
      // 
      this.lineaDataGridViewTextBoxColumn.DataPropertyName = "Linea";
      this.lineaDataGridViewTextBoxColumn.HeaderText = "Linea";
      this.lineaDataGridViewTextBoxColumn.Name = "lineaDataGridViewTextBoxColumn";
      // 
      // kryptonButton1
      // 
      this.kryptonButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.kryptonButton1.Location = new System.Drawing.Point(508, 389);
      this.kryptonButton1.Name = "kryptonButton1";
      this.kryptonButton1.Size = new System.Drawing.Size(111, 25);
      this.kryptonButton1.TabIndex = 3;
      this.kryptonButton1.Values.Text = "Asociar";
      // 
      // kryptonButton2
      // 
      this.kryptonButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.kryptonButton2.Location = new System.Drawing.Point(12, 389);
      this.kryptonButton2.Name = "kryptonButton2";
      this.kryptonButton2.Size = new System.Drawing.Size(126, 25);
      this.kryptonButton2.TabIndex = 4;
      this.kryptonButton2.Values.Text = "Cancelar";
      // 
      // frmLigarSalidasRP_DetalleManifiesto
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(632, 426);
      this.Controls.Add(this.kryptonButton2);
      this.Controls.Add(this.kryptonButton1);
      this.Controls.Add(this.salidaResiduosPeligrososKryptonDataGridView);
      this.Controls.Add(claveRPLabel);
      this.Controls.Add(this.claveRPKryptonComboBox);
      this.Name = "frmLigarSalidasRP_DetalleManifiesto";
      this.Text = "Nuevo Detalle Manifiesto";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLigarSalidasRP_DetalleManifiesto_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.claveRPKryptonComboBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.manifiestoDetalleBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.tipoRPBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.salidaResiduosPeligrososBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.salidaResiduosPeligrososKryptonDataGridView)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.BindingSource manifiestoDetalleBindingSource;
    private ComponentFactory.Krypton.Toolkit.KryptonComboBox claveRPKryptonComboBox;
    private System.Windows.Forms.BindingSource tipoRPBindingSource;
    private System.Windows.Forms.BindingSource salidaResiduosPeligrososBindingSource;
    private ComponentFactory.Krypton.Toolkit.KryptonDataGridView salidaResiduosPeligrososKryptonDataGridView;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Selector;
    private System.Windows.Forms.DataGridViewTextBoxColumn FolioRP;
    private System.Windows.Forms.DataGridViewTextBoxColumn FechaEnvasado;
    private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
    private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
    private System.Windows.Forms.DataGridViewTextBoxColumn folioRPDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn claveRPDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn claveLDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn fechaEnvasadoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn fechaIngresoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn folioDMDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn manifiestoDetalleDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn tipoRPDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn lineaDataGridViewTextBoxColumn;
    private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
    private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
  }
}