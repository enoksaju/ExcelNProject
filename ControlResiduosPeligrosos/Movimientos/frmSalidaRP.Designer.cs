namespace ControlResiduosPeligrosos.Movimientos
{
  partial class frmSalidaRP
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
      System.Windows.Forms.Label cantidadLabel;
      System.Windows.Forms.Label claveLLabel;
      System.Windows.Forms.Label claveRPLabel;
      System.Windows.Forms.Label fechaEnvasadoLabel;
      System.Windows.Forms.Label fechaIngresoLabel;
      this.salidaRPBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.cantidadKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
      this.fechaEnvasadoDateTimePicker = new System.Windows.Forms.DateTimePicker();
      this.fechaIngresoDateTimePicker = new System.Windows.Forms.DateTimePicker();
      this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
      this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
      this.lineaBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.lineaKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
      this.tipoRPBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tipoRPKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
      cantidadLabel = new System.Windows.Forms.Label();
      claveLLabel = new System.Windows.Forms.Label();
      claveRPLabel = new System.Windows.Forms.Label();
      fechaEnvasadoLabel = new System.Windows.Forms.Label();
      fechaIngresoLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.salidaRPBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lineaKryptonComboBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.tipoRPBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.tipoRPKryptonComboBox)).BeginInit();
      this.SuspendLayout();
      // 
      // salidaRPBindingSource
      // 
      this.salidaRPBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.SalidaRP);
      // 
      // cantidadLabel
      // 
      cantidadLabel.AutoSize = true;
      cantidadLabel.Location = new System.Drawing.Point(73, 73);
      cantidadLabel.Name = "cantidadLabel";
      cantidadLabel.Size = new System.Drawing.Size(34, 13);
      cantidadLabel.TabIndex = 1;
      cantidadLabel.Text = "Peso:";
      // 
      // cantidadKryptonTextBox
      // 
      this.cantidadKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salidaRPBindingSource, "Cantidad", true));
      this.cantidadKryptonTextBox.Location = new System.Drawing.Point(115, 63);
      this.cantidadKryptonTextBox.Name = "cantidadKryptonTextBox";
      this.cantidadKryptonTextBox.Size = new System.Drawing.Size(200, 23);
      this.cantidadKryptonTextBox.TabIndex = 2;
      this.cantidadKryptonTextBox.Text = "kryptonTextBox1";
      // 
      // claveLLabel
      // 
      claveLLabel.AutoSize = true;
      claveLLabel.Location = new System.Drawing.Point(73, 17);
      claveLLabel.Name = "claveLLabel";
      claveLLabel.Size = new System.Drawing.Size(36, 13);
      claveLLabel.TabIndex = 3;
      claveLLabel.Text = "Linea:";
      // 
      // claveRPLabel
      // 
      claveRPLabel.AutoSize = true;
      claveRPLabel.Location = new System.Drawing.Point(60, 44);
      claveRPLabel.Name = "claveRPLabel";
      claveRPLabel.Size = new System.Drawing.Size(49, 13);
      claveRPLabel.TabIndex = 5;
      claveRPLabel.Text = "Tipo RP:";
      // 
      // fechaEnvasadoLabel
      // 
      fechaEnvasadoLabel.AutoSize = true;
      fechaEnvasadoLabel.Location = new System.Drawing.Point(18, 96);
      fechaEnvasadoLabel.Name = "fechaEnvasadoLabel";
      fechaEnvasadoLabel.Size = new System.Drawing.Size(91, 13);
      fechaEnvasadoLabel.TabIndex = 7;
      fechaEnvasadoLabel.Text = "Fecha Envasado:";
      // 
      // fechaEnvasadoDateTimePicker
      // 
      this.fechaEnvasadoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.salidaRPBindingSource, "FechaEnvasado", true));
      this.fechaEnvasadoDateTimePicker.Location = new System.Drawing.Point(115, 92);
      this.fechaEnvasadoDateTimePicker.Name = "fechaEnvasadoDateTimePicker";
      this.fechaEnvasadoDateTimePicker.Size = new System.Drawing.Size(200, 20);
      this.fechaEnvasadoDateTimePicker.TabIndex = 8;
      // 
      // fechaIngresoLabel
      // 
      fechaIngresoLabel.AutoSize = true;
      fechaIngresoLabel.Location = new System.Drawing.Point(18, 122);
      fechaIngresoLabel.Name = "fechaIngresoLabel";
      fechaIngresoLabel.Size = new System.Drawing.Size(78, 13);
      fechaIngresoLabel.TabIndex = 9;
      fechaIngresoLabel.Text = "Fecha Ingreso:";
      // 
      // fechaIngresoDateTimePicker
      // 
      this.fechaIngresoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.salidaRPBindingSource, "FechaIngreso", true));
      this.fechaIngresoDateTimePicker.Location = new System.Drawing.Point(115, 118);
      this.fechaIngresoDateTimePicker.Name = "fechaIngresoDateTimePicker";
      this.fechaIngresoDateTimePicker.Size = new System.Drawing.Size(200, 20);
      this.fechaIngresoDateTimePicker.TabIndex = 10;
      // 
      // kryptonButton1
      // 
      this.kryptonButton1.Location = new System.Drawing.Point(225, 173);
      this.kryptonButton1.Name = "kryptonButton1";
      this.kryptonButton1.Size = new System.Drawing.Size(90, 25);
      this.kryptonButton1.TabIndex = 11;
      this.kryptonButton1.Values.Text = "Guardar";
      this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
      // 
      // kryptonButton2
      // 
      this.kryptonButton2.Location = new System.Drawing.Point(21, 172);
      this.kryptonButton2.Name = "kryptonButton2";
      this.kryptonButton2.Size = new System.Drawing.Size(90, 25);
      this.kryptonButton2.TabIndex = 12;
      this.kryptonButton2.Values.Text = "Cancelar";
      this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
      // 
      // lineaBindingSource
      // 
      this.lineaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Linea);
      // 
      // lineaKryptonComboBox
      // 
      this.lineaKryptonComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.salidaRPBindingSource, "ClaveL", true));
      this.lineaKryptonComboBox.DataSource = this.lineaBindingSource;
      this.lineaKryptonComboBox.DisplayMember = "Nombre";
      this.lineaKryptonComboBox.DropDownWidth = 200;
      this.lineaKryptonComboBox.Location = new System.Drawing.Point(115, 9);
      this.lineaKryptonComboBox.Name = "lineaKryptonComboBox";
      this.lineaKryptonComboBox.Size = new System.Drawing.Size(200, 21);
      this.lineaKryptonComboBox.TabIndex = 12;
      this.lineaKryptonComboBox.Text = "kryptonComboBox1";
      this.lineaKryptonComboBox.ValueMember = "Id";
      // 
      // tipoRPBindingSource
      // 
      this.tipoRPBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.TipoRP);
      // 
      // tipoRPKryptonComboBox
      // 
      this.tipoRPKryptonComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.salidaRPBindingSource, "ClaveRP", true));
      this.tipoRPKryptonComboBox.DataSource = this.tipoRPBindingSource;
      this.tipoRPKryptonComboBox.DisplayMember = "Descripcion";
      this.tipoRPKryptonComboBox.DropDownWidth = 200;
      this.tipoRPKryptonComboBox.Location = new System.Drawing.Point(115, 36);
      this.tipoRPKryptonComboBox.Name = "tipoRPKryptonComboBox";
      this.tipoRPKryptonComboBox.Size = new System.Drawing.Size(200, 21);
      this.tipoRPKryptonComboBox.TabIndex = 12;
      this.tipoRPKryptonComboBox.Text = "kryptonComboBox1";
      this.tipoRPKryptonComboBox.ValueMember = "ClaveRP";
      // 
      // frmSalidaRP
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(345, 218);
      this.Controls.Add(this.tipoRPKryptonComboBox);
      this.Controls.Add(this.lineaKryptonComboBox);
      this.Controls.Add(this.kryptonButton2);
      this.Controls.Add(this.kryptonButton1);
      this.Controls.Add(cantidadLabel);
      this.Controls.Add(this.cantidadKryptonTextBox);
      this.Controls.Add(claveLLabel);
      this.Controls.Add(claveRPLabel);
      this.Controls.Add(fechaEnvasadoLabel);
      this.Controls.Add(this.fechaEnvasadoDateTimePicker);
      this.Controls.Add(fechaIngresoLabel);
      this.Controls.Add(this.fechaIngresoDateTimePicker);
      this.Name = "frmSalidaRP";
      this.Text = "Salida Residuos Peligrosos";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalidaRP_FormClosing);
      this.Load += new System.EventHandler(this.frmSalidaRP_Load_1);
      ((System.ComponentModel.ISupportInitialize)(this.salidaRPBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lineaKryptonComboBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.tipoRPBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.tipoRPKryptonComboBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.BindingSource salidaRPBindingSource;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox cantidadKryptonTextBox;
    private System.Windows.Forms.DateTimePicker fechaEnvasadoDateTimePicker;
    private System.Windows.Forms.DateTimePicker fechaIngresoDateTimePicker;
    private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
    private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
    private System.Windows.Forms.BindingSource lineaBindingSource;
    private ComponentFactory.Krypton.Toolkit.KryptonComboBox lineaKryptonComboBox;
    private System.Windows.Forms.BindingSource tipoRPBindingSource;
    private ComponentFactory.Krypton.Toolkit.KryptonComboBox tipoRPKryptonComboBox;
  }
}