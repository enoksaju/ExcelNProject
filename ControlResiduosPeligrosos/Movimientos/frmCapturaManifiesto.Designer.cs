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
			ComponentFactory.Krypton.Toolkit.KryptonLabel noManifiestoLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel fechaLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel transportistaLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel nombreChoferLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel cargoChoferLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel nombreReceptorLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel cargoReceptorLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel proveedorLabel;
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
			this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.nombreRPDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.unidadRPDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pesoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.countDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnAddDetalle = new System.Windows.Forms.ToolStripButton();
			this.proveedorKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.proveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			noManifiestoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			fechaLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			transportistaLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			nombreChoferLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			cargoChoferLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			nombreReceptorLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			cargoReceptorLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			proveedorLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			((System.ComponentModel.ISupportInitialize)(this.manifiestoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.transportistaKryptonComboBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.transportistaBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.manifiestoDetalleBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
			this.kryptonGroupBox1.Panel.SuspendLayout();
			this.kryptonGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.proveedorKryptonComboBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// noManifiestoLabel
			// 
			noManifiestoLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			noManifiestoLabel.Location = new System.Drawing.Point(32, 12);
			noManifiestoLabel.Name = "noManifiestoLabel";
			noManifiestoLabel.Size = new System.Drawing.Size(97, 20);
			noManifiestoLabel.TabIndex = 1;
			noManifiestoLabel.Values.Text = "No Manifiesto:";
			// 
			// fechaLabel
			// 
			fechaLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			fechaLabel.Location = new System.Drawing.Point(77, 39);
			fechaLabel.Name = "fechaLabel";
			fechaLabel.Size = new System.Drawing.Size(47, 20);
			fechaLabel.TabIndex = 2;
			fechaLabel.Values.Text = "Fecha:";
			// 
			// transportistaLabel
			// 
			transportistaLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			transportistaLabel.Location = new System.Drawing.Point(38, 66);
			transportistaLabel.Name = "transportistaLabel";
			transportistaLabel.Size = new System.Drawing.Size(91, 20);
			transportistaLabel.TabIndex = 4;
			transportistaLabel.Values.Text = "Transportista:";
			// 
			// nombreChoferLabel
			// 
			nombreChoferLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			nombreChoferLabel.Location = new System.Drawing.Point(24, 95);
			nombreChoferLabel.Name = "nombreChoferLabel";
			nombreChoferLabel.Size = new System.Drawing.Size(104, 20);
			nombreChoferLabel.TabIndex = 6;
			nombreChoferLabel.Values.Text = "Nombre Chofer:";
			// 
			// cargoChoferLabel
			// 
			cargoChoferLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			cargoChoferLabel.Location = new System.Drawing.Point(374, 95);
			cargoChoferLabel.Name = "cargoChoferLabel";
			cargoChoferLabel.Size = new System.Drawing.Size(48, 20);
			cargoChoferLabel.TabIndex = 8;
			cargoChoferLabel.Values.Text = "Cargo:";
			// 
			// nombreReceptorLabel
			// 
			nombreReceptorLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			nombreReceptorLabel.Location = new System.Drawing.Point(11, 148);
			nombreReceptorLabel.Name = "nombreReceptorLabel";
			nombreReceptorLabel.Size = new System.Drawing.Size(117, 20);
			nombreReceptorLabel.TabIndex = 10;
			nombreReceptorLabel.Values.Text = "Nombre Receptor:";
			// 
			// cargoReceptorLabel
			// 
			cargoReceptorLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			cargoReceptorLabel.Location = new System.Drawing.Point(374, 151);
			cargoReceptorLabel.Name = "cargoReceptorLabel";
			cargoReceptorLabel.Size = new System.Drawing.Size(48, 20);
			cargoReceptorLabel.TabIndex = 12;
			cargoReceptorLabel.Values.Text = "Cargo:";
			// 
			// proveedorLabel
			// 
			proveedorLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			proveedorLabel.Location = new System.Drawing.Point(53, 122);
			proveedorLabel.Name = "proveedorLabel";
			proveedorLabel.Size = new System.Drawing.Size(74, 20);
			proveedorLabel.TabIndex = 15;
			proveedorLabel.Values.Text = "Proveedor:";
			// 
			// manifiestoBindingSource
			// 
			this.manifiestoBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Manifiesto);
			// 
			// noManifiestoKryptonTextBox
			// 
			this.noManifiestoKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.manifiestoBindingSource, "NoManifiesto", true));
			this.noManifiestoKryptonTextBox.Location = new System.Drawing.Point(128, 9);
			this.noManifiestoKryptonTextBox.Name = "noManifiestoKryptonTextBox";
			this.noManifiestoKryptonTextBox.Size = new System.Drawing.Size(100, 23);
			this.noManifiestoKryptonTextBox.TabIndex = 2;
			this.noManifiestoKryptonTextBox.Text = "kryptonTextBox1";
			// 
			// fechaKryptonDateTimePicker
			// 
			this.fechaKryptonDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.manifiestoBindingSource, "Fecha", true));
			this.fechaKryptonDateTimePicker.Location = new System.Drawing.Point(128, 38);
			this.fechaKryptonDateTimePicker.Name = "fechaKryptonDateTimePicker";
			this.fechaKryptonDateTimePicker.Size = new System.Drawing.Size(240, 21);
			this.fechaKryptonDateTimePicker.TabIndex = 3;
			// 
			// transportistaKryptonComboBox
			// 
			this.transportistaKryptonComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.manifiestoBindingSource, "ClaveT", true));
			this.transportistaKryptonComboBox.DataSource = this.transportistaBindingSource;
			this.transportistaKryptonComboBox.DisplayMember = "Denominacion";
			this.transportistaKryptonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.transportistaKryptonComboBox.DropDownWidth = 240;
			this.transportistaKryptonComboBox.Location = new System.Drawing.Point(128, 65);
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
			this.nombreChoferKryptonTextBox.Location = new System.Drawing.Point(128, 92);
			this.nombreChoferKryptonTextBox.Name = "nombreChoferKryptonTextBox";
			this.nombreChoferKryptonTextBox.Size = new System.Drawing.Size(240, 23);
			this.nombreChoferKryptonTextBox.TabIndex = 7;
			this.nombreChoferKryptonTextBox.Text = "kryptonTextBox1";
			// 
			// cargoChoferKryptonTextBox
			// 
			this.cargoChoferKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.manifiestoBindingSource, "CargoChofer", true));
			this.cargoChoferKryptonTextBox.Location = new System.Drawing.Point(426, 95);
			this.cargoChoferKryptonTextBox.Name = "cargoChoferKryptonTextBox";
			this.cargoChoferKryptonTextBox.Size = new System.Drawing.Size(173, 23);
			this.cargoChoferKryptonTextBox.TabIndex = 9;
			this.cargoChoferKryptonTextBox.Text = "kryptonTextBox1";
			// 
			// nombreReceptorKryptonTextBox
			// 
			this.nombreReceptorKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.manifiestoBindingSource, "NombreReceptor", true));
			this.nombreReceptorKryptonTextBox.Location = new System.Drawing.Point(128, 148);
			this.nombreReceptorKryptonTextBox.Name = "nombreReceptorKryptonTextBox";
			this.nombreReceptorKryptonTextBox.Size = new System.Drawing.Size(240, 23);
			this.nombreReceptorKryptonTextBox.TabIndex = 11;
			this.nombreReceptorKryptonTextBox.Text = "kryptonTextBox1";
			// 
			// cargoReceptorKryptonTextBox
			// 
			this.cargoReceptorKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.manifiestoBindingSource, "CargoReceptor", true));
			this.cargoReceptorKryptonTextBox.Location = new System.Drawing.Point(426, 148);
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
			// kryptonGroupBox1
			// 
			this.kryptonGroupBox1.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.SeparatorLowProfile;
			this.kryptonGroupBox1.Location = new System.Drawing.Point(14, 177);
			this.kryptonGroupBox1.Name = "kryptonGroupBox1";
			// 
			// kryptonGroupBox1.Panel
			// 
			this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonDataGridView1);
			this.kryptonGroupBox1.Panel.Controls.Add(this.toolStrip1);
			this.kryptonGroupBox1.Size = new System.Drawing.Size(582, 257);
			this.kryptonGroupBox1.TabIndex = 15;
			this.kryptonGroupBox1.Values.Heading = "Detalle de Manifiesto";
			// 
			// kryptonDataGridView1
			// 
			this.kryptonDataGridView1.AllowUserToAddRows = false;
			this.kryptonDataGridView1.AutoGenerateColumns = false;
			this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreRPDataGridViewTextBoxColumn1,
            this.unidadRPDataGridViewTextBoxColumn1,
            this.pesoDataGridViewTextBoxColumn1,
            this.countDataGridViewTextBoxColumn1});
			this.kryptonDataGridView1.DataSource = this.manifiestoDetalleBindingSource;
			this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 25);
			this.kryptonDataGridView1.Name = "kryptonDataGridView1";
			this.kryptonDataGridView1.ReadOnly = true;
			this.kryptonDataGridView1.Size = new System.Drawing.Size(578, 208);
			this.kryptonDataGridView1.TabIndex = 16;
			// 
			// nombreRPDataGridViewTextBoxColumn1
			// 
			this.nombreRPDataGridViewTextBoxColumn1.DataPropertyName = "NombreRP";
			this.nombreRPDataGridViewTextBoxColumn1.HeaderText = "NombreRP";
			this.nombreRPDataGridViewTextBoxColumn1.Name = "nombreRPDataGridViewTextBoxColumn1";
			this.nombreRPDataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// unidadRPDataGridViewTextBoxColumn1
			// 
			this.unidadRPDataGridViewTextBoxColumn1.DataPropertyName = "UnidadRP";
			this.unidadRPDataGridViewTextBoxColumn1.HeaderText = "UnidadRP";
			this.unidadRPDataGridViewTextBoxColumn1.Name = "unidadRPDataGridViewTextBoxColumn1";
			this.unidadRPDataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// pesoDataGridViewTextBoxColumn1
			// 
			this.pesoDataGridViewTextBoxColumn1.DataPropertyName = "Peso";
			this.pesoDataGridViewTextBoxColumn1.HeaderText = "Peso";
			this.pesoDataGridViewTextBoxColumn1.Name = "pesoDataGridViewTextBoxColumn1";
			this.pesoDataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// countDataGridViewTextBoxColumn1
			// 
			this.countDataGridViewTextBoxColumn1.DataPropertyName = "Count";
			this.countDataGridViewTextBoxColumn1.HeaderText = "Count";
			this.countDataGridViewTextBoxColumn1.Name = "countDataGridViewTextBoxColumn1";
			this.countDataGridViewTextBoxColumn1.ReadOnly = true;
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
			this.btnAddDetalle.Image = global::ControlResiduosPeligrosos.Properties.Resources.add;
			this.btnAddDetalle.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddDetalle.Name = "btnAddDetalle";
			this.btnAddDetalle.Size = new System.Drawing.Size(23, 22);
			this.btnAddDetalle.Text = "Agregar Detalle";
			this.btnAddDetalle.Click += new System.EventHandler(this.btnAddDetalle_Click);
			// 
			// proveedorKryptonComboBox
			// 
			this.proveedorKryptonComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.manifiestoBindingSource, "ClaveP", true));
			this.proveedorKryptonComboBox.DataSource = this.proveedorBindingSource;
			this.proveedorKryptonComboBox.DisplayMember = "Denominacion";
			this.proveedorKryptonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.proveedorKryptonComboBox.DropDownWidth = 240;
			this.proveedorKryptonComboBox.Location = new System.Drawing.Point(128, 121);
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
			this.kryptonButton1.Location = new System.Drawing.Point(481, 440);
			this.kryptonButton1.Name = "kryptonButton1";
			this.kryptonButton1.Size = new System.Drawing.Size(115, 31);
			this.kryptonButton1.TabIndex = 17;
			this.kryptonButton1.Values.Text = "Guardar";
			this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(noManifiestoLabel);
			this.kryptonPanel1.Controls.Add(this.kryptonButton1);
			this.kryptonPanel1.Controls.Add(this.noManifiestoKryptonTextBox);
			this.kryptonPanel1.Controls.Add(proveedorLabel);
			this.kryptonPanel1.Controls.Add(this.fechaKryptonDateTimePicker);
			this.kryptonPanel1.Controls.Add(this.proveedorKryptonComboBox);
			this.kryptonPanel1.Controls.Add(fechaLabel);
			this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
			this.kryptonPanel1.Controls.Add(this.transportistaKryptonComboBox);
			this.kryptonPanel1.Controls.Add(cargoReceptorLabel);
			this.kryptonPanel1.Controls.Add(transportistaLabel);
			this.kryptonPanel1.Controls.Add(this.cargoReceptorKryptonTextBox);
			this.kryptonPanel1.Controls.Add(this.nombreChoferKryptonTextBox);
			this.kryptonPanel1.Controls.Add(nombreReceptorLabel);
			this.kryptonPanel1.Controls.Add(nombreChoferLabel);
			this.kryptonPanel1.Controls.Add(this.nombreReceptorKryptonTextBox);
			this.kryptonPanel1.Controls.Add(this.cargoChoferKryptonTextBox);
			this.kryptonPanel1.Controls.Add(cargoChoferLabel);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(610, 483);
			this.kryptonPanel1.TabIndex = 18;
			// 
			// frmCapturaManifiesto
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(610, 483);
			this.Controls.Add(this.kryptonPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmCapturaManifiesto";
			this.Text = "Captura de Manifiesto";
			((System.ComponentModel.ISupportInitialize)(this.manifiestoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.transportistaKryptonComboBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.transportistaBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.manifiestoDetalleBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
			this.kryptonGroupBox1.Panel.ResumeLayout(false);
			this.kryptonGroupBox1.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
			this.kryptonGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.proveedorKryptonComboBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			this.ResumeLayout(false);

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
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnAddDetalle;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox proveedorKryptonComboBox;
		private System.Windows.Forms.BindingSource proveedorBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn nombreRPDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn unidadRPDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn pesoDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn1;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
	}
}