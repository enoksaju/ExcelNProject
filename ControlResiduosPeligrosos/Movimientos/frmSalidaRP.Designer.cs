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
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.components = new System.ComponentModel.Container();
			ComponentFactory.Krypton.Toolkit.KryptonLabel cantidadLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel claveLLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel claveRPLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel fechaEnvasadoLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel fechaIngresoLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalidaRP));
			this.salidaRPBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.cantidadKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.fechaEnvasadoDateTimePicker = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
			this.fechaIngresoDateTimePicker = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
			this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.lineaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.lineaKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.tipoRPBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tipoRPKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			cantidadLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			claveLLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			claveRPLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			fechaEnvasadoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			fechaIngresoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			((System.ComponentModel.ISupportInitialize)(this.salidaRPBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lineaKryptonComboBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tipoRPBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tipoRPKryptonComboBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cantidadLabel
			// 
			cantidadLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			cantidadLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			cantidadLabel.Location = new System.Drawing.Point(72, 67);
			cantidadLabel.Name = "cantidadLabel";
			cantidadLabel.Size = new System.Drawing.Size(41, 20);
			cantidadLabel.TabIndex = 1;
			cantidadLabel.Values.Text = "Peso:";
			// 
			// claveLLabel
			// 
			claveLLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			claveLLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			claveLLabel.Location = new System.Drawing.Point(69, 14);
			claveLLabel.Name = "claveLLabel";
			claveLLabel.Size = new System.Drawing.Size(44, 20);
			claveLLabel.TabIndex = 3;
			claveLLabel.Values.Text = "Linea:";
			// 
			// claveRPLabel
			// 
			claveRPLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			claveRPLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			claveRPLabel.Location = new System.Drawing.Point(56, 41);
			claveRPLabel.Name = "claveRPLabel";
			claveRPLabel.Size = new System.Drawing.Size(59, 20);
			claveRPLabel.TabIndex = 5;
			claveRPLabel.Values.Text = "Tipo RP:";
			// 
			// fechaEnvasadoLabel
			// 
			fechaEnvasadoLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			fechaEnvasadoLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			fechaEnvasadoLabel.Location = new System.Drawing.Point(11, 96);
			fechaEnvasadoLabel.Name = "fechaEnvasadoLabel";
			fechaEnvasadoLabel.Size = new System.Drawing.Size(105, 20);
			fechaEnvasadoLabel.TabIndex = 7;
			fechaEnvasadoLabel.Values.Text = "Fecha Envasado:";
			// 
			// fechaIngresoLabel
			// 
			fechaIngresoLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			fechaIngresoLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			fechaIngresoLabel.Location = new System.Drawing.Point(22, 123);
			fechaIngresoLabel.Name = "fechaIngresoLabel";
			fechaIngresoLabel.Size = new System.Drawing.Size(94, 20);
			fechaIngresoLabel.TabIndex = 9;
			fechaIngresoLabel.Values.Text = "Fecha Ingreso:";
			// 
			// salidaRPBindingSource
			// 
			this.salidaRPBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.SalidaRP);
			// 
			// cantidadKryptonTextBox
			// 
			this.cantidadKryptonTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cantidadKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salidaRPBindingSource, "Cantidad", true));
			this.cantidadKryptonTextBox.Location = new System.Drawing.Point(117, 67);
			this.cantidadKryptonTextBox.Name = "cantidadKryptonTextBox";
			this.cantidadKryptonTextBox.Size = new System.Drawing.Size(236, 23);
			this.cantidadKryptonTextBox.TabIndex = 2;
			this.cantidadKryptonTextBox.Text = "kryptonTextBox1";
			// 
			// fechaEnvasadoDateTimePicker
			// 
			this.fechaEnvasadoDateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.fechaEnvasadoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.salidaRPBindingSource, "FechaEnvasado", true));
			this.fechaEnvasadoDateTimePicker.Location = new System.Drawing.Point(117, 96);
			this.fechaEnvasadoDateTimePicker.Name = "fechaEnvasadoDateTimePicker";
			this.fechaEnvasadoDateTimePicker.Size = new System.Drawing.Size(236, 21);
			this.fechaEnvasadoDateTimePicker.TabIndex = 8;
			// 
			// fechaIngresoDateTimePicker
			// 
			this.fechaIngresoDateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.fechaIngresoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.salidaRPBindingSource, "FechaIngreso", true));
			this.fechaIngresoDateTimePicker.Location = new System.Drawing.Point(117, 122);
			this.fechaIngresoDateTimePicker.Name = "fechaIngresoDateTimePicker";
			this.fechaIngresoDateTimePicker.Size = new System.Drawing.Size(236, 21);
			this.fechaIngresoDateTimePicker.TabIndex = 10;
			// 
			// kryptonButton1
			// 
			this.kryptonButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.kryptonButton1.Location = new System.Drawing.Point(263, 165);
			this.kryptonButton1.Name = "kryptonButton1";
			this.kryptonButton1.Size = new System.Drawing.Size(90, 25);
			this.kryptonButton1.TabIndex = 11;
			this.kryptonButton1.Values.Text = "Guardar";
			this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
			// 
			// kryptonButton2
			// 
			this.kryptonButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.kryptonButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.kryptonButton2.Location = new System.Drawing.Point(37, 165);
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
			this.lineaKryptonComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lineaKryptonComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.salidaRPBindingSource, "ClaveL", true));
			this.lineaKryptonComboBox.DataSource = this.lineaBindingSource;
			this.lineaKryptonComboBox.DisplayMember = "Nombre";
			this.lineaKryptonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lineaKryptonComboBox.DropDownWidth = 200;
			this.lineaKryptonComboBox.Location = new System.Drawing.Point(117, 13);
			this.lineaKryptonComboBox.Name = "lineaKryptonComboBox";
			this.lineaKryptonComboBox.Size = new System.Drawing.Size(236, 21);
			this.lineaKryptonComboBox.TabIndex = 12;
			this.lineaKryptonComboBox.ValueMember = "Id";
			// 
			// tipoRPBindingSource
			// 
			this.tipoRPBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.TipoRP);
			// 
			// tipoRPKryptonComboBox
			// 
			this.tipoRPKryptonComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tipoRPKryptonComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.salidaRPBindingSource, "ClaveRP", true));
			this.tipoRPKryptonComboBox.DataSource = this.tipoRPBindingSource;
			this.tipoRPKryptonComboBox.DisplayMember = "Descripcion";
			this.tipoRPKryptonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tipoRPKryptonComboBox.DropDownWidth = 200;
			this.tipoRPKryptonComboBox.Location = new System.Drawing.Point(117, 40);
			this.tipoRPKryptonComboBox.Name = "tipoRPKryptonComboBox";
			this.tipoRPKryptonComboBox.Size = new System.Drawing.Size(236, 21);
			this.tipoRPKryptonComboBox.TabIndex = 12;
			this.tipoRPKryptonComboBox.ValueMember = "ClaveRP";
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(claveLLabel);
			this.kryptonPanel1.Controls.Add(this.tipoRPKryptonComboBox);
			this.kryptonPanel1.Controls.Add(this.fechaIngresoDateTimePicker);
			this.kryptonPanel1.Controls.Add(this.lineaKryptonComboBox);
			this.kryptonPanel1.Controls.Add(fechaIngresoLabel);
			this.kryptonPanel1.Controls.Add(this.kryptonButton2);
			this.kryptonPanel1.Controls.Add(this.fechaEnvasadoDateTimePicker);
			this.kryptonPanel1.Controls.Add(this.kryptonButton1);
			this.kryptonPanel1.Controls.Add(fechaEnvasadoLabel);
			this.kryptonPanel1.Controls.Add(cantidadLabel);
			this.kryptonPanel1.Controls.Add(claveRPLabel);
			this.kryptonPanel1.Controls.Add(this.cantidadKryptonTextBox);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(370, 201);
			this.kryptonPanel1.TabIndex = 13;
			// 
			// frmSalidaRP
			// 
			this.AcceptButton = this.kryptonButton1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.kryptonButton2;
			this.ClientSize = new System.Drawing.Size(370, 201);
			this.Controls.Add(this.kryptonPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(386, 240);
			this.Name = "frmSalidaRP";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Salida Residuos Peligrosos";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalidaRP_FormClosing);
			this.Load += new System.EventHandler(this.frmSalidaRP_Load_1);
			((System.ComponentModel.ISupportInitialize)(this.salidaRPBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lineaKryptonComboBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tipoRPBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tipoRPKryptonComboBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.BindingSource salidaRPBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox cantidadKryptonTextBox;
		private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker fechaEnvasadoDateTimePicker;
		private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker fechaIngresoDateTimePicker;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
		private System.Windows.Forms.BindingSource lineaBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox lineaKryptonComboBox;
		private System.Windows.Forms.BindingSource tipoRPBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox tipoRPKryptonComboBox;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
	}
}