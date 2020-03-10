namespace EstacionPesaje {
	partial class IniciarCaptura_frm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing ) {
			if (disposing && ( components != null )) {
				DB.Dispose ( );
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
			this.components = new System.ComponentModel.Container();
			this.procesoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.etiquetaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.etiquetaKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.zplImageConverter1 = new libControlesPersonalizados.ZPLCONVERTER.zplImageConverter();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.InfoCapturaLayout = new System.Windows.Forms.TableLayoutPanel();
			this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.TurnokryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.lineaKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.lineaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.maquinasKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.maquinasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.OperadorkryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.procesoKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.Optional6TextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.Optional5TextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.Optional4TextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.Optional3TextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.Optional2TextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.Optional1TextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.ItemOptionalTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.btnCancelButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.AceptButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			((System.ComponentModel.ISupportInitialize)(this.procesoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.etiquetaBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.etiquetaKryptonComboBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.InfoCapturaLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TurnokryptonComboBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lineaKryptonComboBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.maquinasKryptonComboBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.maquinasBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.procesoKryptonComboBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
			this.kryptonGroupBox1.Panel.SuspendLayout();
			this.kryptonGroupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
			this.kryptonPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// procesoBindingSource
			// 
			this.procesoBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Proceso);
			// 
			// etiquetaBindingSource
			// 
			this.etiquetaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Etiqueta);
			// 
			// etiquetaKryptonComboBox
			// 
			this.etiquetaKryptonComboBox.DataSource = this.etiquetaBindingSource;
			this.etiquetaKryptonComboBox.DisplayMember = "Nombre";
			this.etiquetaKryptonComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.etiquetaKryptonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.etiquetaKryptonComboBox.DropDownWidth = 254;
			this.etiquetaKryptonComboBox.Location = new System.Drawing.Point(3, 3);
			this.etiquetaKryptonComboBox.MaximumSize = new System.Drawing.Size(250, 0);
			this.etiquetaKryptonComboBox.Name = "etiquetaKryptonComboBox";
			this.etiquetaKryptonComboBox.Size = new System.Drawing.Size(250, 21);
			this.etiquetaKryptonComboBox.TabIndex = 6;
			this.etiquetaKryptonComboBox.ValueMember = "Id";
			this.etiquetaKryptonComboBox.SelectedIndexChanged += new System.EventHandler(this.etiquetaKryptonComboBox_SelectedIndexChanged);
			this.etiquetaKryptonComboBox.SelectionChangeCommitted += new System.EventHandler(this.etiquetaKryptonComboBox_SelectionChangeCommitted);
			this.etiquetaKryptonComboBox.SelectedValueChanged += new System.EventHandler(this.etiquetaKryptonComboBox_SelectedValueChanged);
			// 
			// zplImageConverter1
			// 
			this.zplImageConverter1.BlacknessLimitPercentage = 40;
			this.zplImageConverter1.CompressHex = true;
			this.zplImageConverter1.Image = null;
			this.zplImageConverter1.LengToSplit = 40;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(3, 30);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(412, 167);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.AutoSize = true;
			this.kryptonPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.kryptonPanel1.Controls.Add(this.flowLayoutPanel1);
			this.kryptonPanel1.Controls.Add(this.kryptonPanel2);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(443, 329);
			this.kryptonPanel1.TabIndex = 6;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.flowLayoutPanel1.Controls.Add(this.InfoCapturaLayout);
			this.flowLayoutPanel1.Controls.Add(this.kryptonGroupBox1);
			this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel2);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(443, 280);
			this.flowLayoutPanel1.TabIndex = 8;
			// 
			// InfoCapturaLayout
			// 
			this.InfoCapturaLayout.BackColor = System.Drawing.Color.Transparent;
			this.InfoCapturaLayout.ColumnCount = 2;
			this.InfoCapturaLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
			this.InfoCapturaLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.InfoCapturaLayout.Controls.Add(this.kryptonLabel5, 0, 2);
			this.InfoCapturaLayout.Controls.Add(this.TurnokryptonComboBox, 1, 5);
			this.InfoCapturaLayout.Controls.Add(this.lineaKryptonComboBox, 1, 2);
			this.InfoCapturaLayout.Controls.Add(this.maquinasKryptonComboBox, 1, 3);
			this.InfoCapturaLayout.Controls.Add(this.OperadorkryptonTextBox, 1, 1);
			this.InfoCapturaLayout.Controls.Add(this.procesoKryptonComboBox, 1, 4);
			this.InfoCapturaLayout.Controls.Add(this.kryptonLabel1, 0, 1);
			this.InfoCapturaLayout.Controls.Add(this.kryptonLabel2, 0, 3);
			this.InfoCapturaLayout.Controls.Add(this.kryptonLabel3, 0, 4);
			this.InfoCapturaLayout.Controls.Add(this.kryptonLabel4, 0, 5);
			this.InfoCapturaLayout.Location = new System.Drawing.Point(10, 3);
			this.InfoCapturaLayout.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
			this.InfoCapturaLayout.Name = "InfoCapturaLayout";
			this.InfoCapturaLayout.RowCount = 6;
			this.InfoCapturaLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.InfoCapturaLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.InfoCapturaLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.InfoCapturaLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.InfoCapturaLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.InfoCapturaLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.InfoCapturaLayout.Size = new System.Drawing.Size(422, 181);
			this.InfoCapturaLayout.TabIndex = 1;
			// 
			// kryptonLabel5
			// 
			this.kryptonLabel5.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel5.Location = new System.Drawing.Point(75, 60);
			this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(0);
			this.kryptonLabel5.Name = "kryptonLabel5";
			this.kryptonLabel5.Size = new System.Drawing.Size(41, 30);
			this.kryptonLabel5.TabIndex = 11;
			this.kryptonLabel5.Values.Text = "Linea";
			// 
			// TurnokryptonComboBox
			// 
			this.TurnokryptonComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TurnokryptonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TurnokryptonComboBox.DropDownWidth = 150;
			this.TurnokryptonComboBox.Items.AddRange(new object[] {
            "Ninguno",
            "Primero",
            "Segundo",
            "Tercero",
            "Mixto"});
			this.TurnokryptonComboBox.Location = new System.Drawing.Point(121, 152);
			this.TurnokryptonComboBox.Margin = new System.Windows.Forms.Padding(5, 2, 0, 0);
			this.TurnokryptonComboBox.MaximumSize = new System.Drawing.Size(250, 0);
			this.TurnokryptonComboBox.Name = "TurnokryptonComboBox";
			this.TurnokryptonComboBox.Size = new System.Drawing.Size(250, 21);
			this.TurnokryptonComboBox.TabIndex = 5;
			// 
			// lineaKryptonComboBox
			// 
			this.lineaKryptonComboBox.DataSource = this.lineaBindingSource;
			this.lineaKryptonComboBox.DisplayMember = "Nombre";
			this.lineaKryptonComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lineaKryptonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lineaKryptonComboBox.DropDownWidth = 250;
			this.lineaKryptonComboBox.Location = new System.Drawing.Point(121, 62);
			this.lineaKryptonComboBox.Margin = new System.Windows.Forms.Padding(5, 2, 0, 0);
			this.lineaKryptonComboBox.MaximumSize = new System.Drawing.Size(250, 0);
			this.lineaKryptonComboBox.Name = "lineaKryptonComboBox";
			this.lineaKryptonComboBox.Size = new System.Drawing.Size(250, 21);
			this.lineaKryptonComboBox.TabIndex = 2;
			this.lineaKryptonComboBox.ValueMember = "Id";
			// 
			// lineaBindingSource
			// 
			this.lineaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Linea);
			// 
			// maquinasKryptonComboBox
			// 
			this.maquinasKryptonComboBox.DataSource = this.maquinasBindingSource;
			this.maquinasKryptonComboBox.DisplayMember = "NombreMaquina";
			this.maquinasKryptonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.maquinasKryptonComboBox.DropDownWidth = 250;
			this.maquinasKryptonComboBox.Location = new System.Drawing.Point(121, 92);
			this.maquinasKryptonComboBox.Margin = new System.Windows.Forms.Padding(5, 2, 0, 0);
			this.maquinasKryptonComboBox.MaximumSize = new System.Drawing.Size(250, 0);
			this.maquinasKryptonComboBox.Name = "maquinasKryptonComboBox";
			this.maquinasKryptonComboBox.Size = new System.Drawing.Size(250, 21);
			this.maquinasKryptonComboBox.TabIndex = 3;
			this.maquinasKryptonComboBox.ValueMember = "Decks";
			// 
			// maquinasBindingSource
			// 
			this.maquinasBindingSource.DataMember = "Maquinas";
			this.maquinasBindingSource.DataSource = this.lineaBindingSource;
			// 
			// OperadorkryptonTextBox
			// 
			this.OperadorkryptonTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OperadorkryptonTextBox.Location = new System.Drawing.Point(121, 32);
			this.OperadorkryptonTextBox.Margin = new System.Windows.Forms.Padding(5, 2, 0, 0);
			this.OperadorkryptonTextBox.MaximumSize = new System.Drawing.Size(150, 0);
			this.OperadorkryptonTextBox.Name = "OperadorkryptonTextBox";
			this.OperadorkryptonTextBox.Size = new System.Drawing.Size(150, 23);
			this.OperadorkryptonTextBox.TabIndex = 1;
			// 
			// procesoKryptonComboBox
			// 
			this.procesoKryptonComboBox.DataSource = this.procesoBindingSource;
			this.procesoKryptonComboBox.DisplayMember = "NombreProceso";
			this.procesoKryptonComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.procesoKryptonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.procesoKryptonComboBox.DropDownWidth = 150;
			this.procesoKryptonComboBox.Location = new System.Drawing.Point(121, 122);
			this.procesoKryptonComboBox.Margin = new System.Windows.Forms.Padding(5, 2, 0, 0);
			this.procesoKryptonComboBox.MaximumSize = new System.Drawing.Size(250, 0);
			this.procesoKryptonComboBox.Name = "procesoKryptonComboBox";
			this.procesoKryptonComboBox.Size = new System.Drawing.Size(250, 21);
			this.procesoKryptonComboBox.TabIndex = 4;
			this.procesoKryptonComboBox.ValueMember = "ID";
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel1.Location = new System.Drawing.Point(50, 30);
			this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(0);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(66, 30);
			this.kryptonLabel1.TabIndex = 7;
			this.kryptonLabel1.Values.Text = "Operador";
			// 
			// kryptonLabel2
			// 
			this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel2.Location = new System.Drawing.Point(54, 90);
			this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(0);
			this.kryptonLabel2.Name = "kryptonLabel2";
			this.kryptonLabel2.Size = new System.Drawing.Size(62, 30);
			this.kryptonLabel2.TabIndex = 8;
			this.kryptonLabel2.Values.Text = "Maquina";
			// 
			// kryptonLabel3
			// 
			this.kryptonLabel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel3.Location = new System.Drawing.Point(60, 120);
			this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(0);
			this.kryptonLabel3.Name = "kryptonLabel3";
			this.kryptonLabel3.Size = new System.Drawing.Size(56, 30);
			this.kryptonLabel3.TabIndex = 9;
			this.kryptonLabel3.Values.Text = "Proceso";
			// 
			// kryptonLabel4
			// 
			this.kryptonLabel4.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel4.Location = new System.Drawing.Point(71, 150);
			this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(0);
			this.kryptonLabel4.Name = "kryptonLabel4";
			this.kryptonLabel4.Size = new System.Drawing.Size(45, 31);
			this.kryptonLabel4.TabIndex = 10;
			this.kryptonLabel4.Values.Text = "Turno";
			// 
			// kryptonGroupBox1
			// 
			this.kryptonGroupBox1.Location = new System.Drawing.Point(452, 3);
			this.kryptonGroupBox1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
			this.kryptonGroupBox1.Name = "kryptonGroupBox1";
			// 
			// kryptonGroupBox1.Panel
			// 
			this.kryptonGroupBox1.Panel.Controls.Add(this.tableLayoutPanel1);
			this.kryptonGroupBox1.Size = new System.Drawing.Size(422, 224);
			this.kryptonGroupBox1.TabIndex = 2;
			this.kryptonGroupBox1.Values.Heading = "Etiqueta";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 418F));
			this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.etiquetaKryptonComboBox, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(418, 200);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.kryptonLabel12, 0, 6);
			this.tableLayoutPanel2.Controls.Add(this.Optional6TextBox, 0, 6);
			this.tableLayoutPanel2.Controls.Add(this.Optional5TextBox, 1, 5);
			this.tableLayoutPanel2.Controls.Add(this.Optional4TextBox, 1, 4);
			this.tableLayoutPanel2.Controls.Add(this.Optional3TextBox, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.Optional2TextBox, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.Optional1TextBox, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.kryptonLabel6, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.kryptonLabel7, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.kryptonLabel8, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.kryptonLabel10, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.kryptonLabel11, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.kryptonLabel9, 0, 5);
			this.tableLayoutPanel2.Controls.Add(this.ItemOptionalTextBox, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(894, 3);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 7;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28816F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(388, 219);
			this.tableLayoutPanel2.TabIndex = 8;
			// 
			// kryptonLabel12
			// 
			this.kryptonLabel12.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel12.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel12.Location = new System.Drawing.Point(40, 189);
			this.kryptonLabel12.Name = "kryptonLabel12";
			this.kryptonLabel12.Size = new System.Drawing.Size(73, 27);
			this.kryptonLabel12.TabIndex = 15;
			this.kryptonLabel12.Values.Text = "Opcional 6";
			// 
			// Optional6TextBox
			// 
			this.Optional6TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EstacionPesaje.Properties.Settings.Default, "Optional6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Optional6TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Optional6TextBox.Location = new System.Drawing.Point(119, 189);
			this.Optional6TextBox.MaximumSize = new System.Drawing.Size(250, 0);
			this.Optional6TextBox.Name = "Optional6TextBox";
			this.Optional6TextBox.Size = new System.Drawing.Size(250, 23);
			this.Optional6TextBox.TabIndex = 14;
			this.Optional6TextBox.Text = global::EstacionPesaje.Properties.Settings.Default.Optional6;
			// 
			// Optional5TextBox
			// 
			this.Optional5TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EstacionPesaje.Properties.Settings.Default, "Optional5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Optional5TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Optional5TextBox.Location = new System.Drawing.Point(119, 158);
			this.Optional5TextBox.MaximumSize = new System.Drawing.Size(250, 0);
			this.Optional5TextBox.Name = "Optional5TextBox";
			this.Optional5TextBox.Size = new System.Drawing.Size(250, 23);
			this.Optional5TextBox.TabIndex = 12;
			this.Optional5TextBox.Text = global::EstacionPesaje.Properties.Settings.Default.Optional5;
			// 
			// Optional4TextBox
			// 
			this.Optional4TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EstacionPesaje.Properties.Settings.Default, "Optional4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Optional4TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Optional4TextBox.Location = new System.Drawing.Point(119, 127);
			this.Optional4TextBox.MaximumSize = new System.Drawing.Size(250, 0);
			this.Optional4TextBox.Name = "Optional4TextBox";
			this.Optional4TextBox.Size = new System.Drawing.Size(250, 23);
			this.Optional4TextBox.TabIndex = 11;
			this.Optional4TextBox.Text = global::EstacionPesaje.Properties.Settings.Default.Optional4;
			// 
			// Optional3TextBox
			// 
			this.Optional3TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EstacionPesaje.Properties.Settings.Default, "Optional3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Optional3TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Optional3TextBox.Location = new System.Drawing.Point(119, 96);
			this.Optional3TextBox.MaximumSize = new System.Drawing.Size(250, 0);
			this.Optional3TextBox.Name = "Optional3TextBox";
			this.Optional3TextBox.Size = new System.Drawing.Size(250, 23);
			this.Optional3TextBox.TabIndex = 10;
			this.Optional3TextBox.Text = global::EstacionPesaje.Properties.Settings.Default.Optional3;
			// 
			// Optional2TextBox
			// 
			this.Optional2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EstacionPesaje.Properties.Settings.Default, "Optional2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Optional2TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Optional2TextBox.Location = new System.Drawing.Point(119, 65);
			this.Optional2TextBox.MaximumSize = new System.Drawing.Size(250, 0);
			this.Optional2TextBox.Name = "Optional2TextBox";
			this.Optional2TextBox.Size = new System.Drawing.Size(250, 23);
			this.Optional2TextBox.TabIndex = 9;
			this.Optional2TextBox.Text = global::EstacionPesaje.Properties.Settings.Default.Optional2;
			// 
			// Optional1TextBox
			// 
			this.Optional1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EstacionPesaje.Properties.Settings.Default, "Optional1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Optional1TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Optional1TextBox.Location = new System.Drawing.Point(119, 34);
			this.Optional1TextBox.MaximumSize = new System.Drawing.Size(250, 0);
			this.Optional1TextBox.Name = "Optional1TextBox";
			this.Optional1TextBox.Size = new System.Drawing.Size(250, 23);
			this.Optional1TextBox.TabIndex = 8;
			this.Optional1TextBox.Text = global::EstacionPesaje.Properties.Settings.Default.Optional1;
			// 
			// kryptonLabel6
			// 
			this.kryptonLabel6.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel6.Location = new System.Drawing.Point(22, 3);
			this.kryptonLabel6.Name = "kryptonLabel6";
			this.kryptonLabel6.Size = new System.Drawing.Size(91, 25);
			this.kryptonLabel6.TabIndex = 0;
			this.kryptonLabel6.Values.Text = "Item Optional";
			// 
			// kryptonLabel7
			// 
			this.kryptonLabel7.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel7.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel7.Location = new System.Drawing.Point(40, 34);
			this.kryptonLabel7.Name = "kryptonLabel7";
			this.kryptonLabel7.Size = new System.Drawing.Size(73, 25);
			this.kryptonLabel7.TabIndex = 1;
			this.kryptonLabel7.Values.Text = "Opcional 1";
			// 
			// kryptonLabel8
			// 
			this.kryptonLabel8.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel8.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel8.Location = new System.Drawing.Point(40, 65);
			this.kryptonLabel8.Name = "kryptonLabel8";
			this.kryptonLabel8.Size = new System.Drawing.Size(73, 25);
			this.kryptonLabel8.TabIndex = 2;
			this.kryptonLabel8.Values.Text = "Opcional 2";
			// 
			// kryptonLabel10
			// 
			this.kryptonLabel10.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel10.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel10.Location = new System.Drawing.Point(40, 96);
			this.kryptonLabel10.Name = "kryptonLabel10";
			this.kryptonLabel10.Size = new System.Drawing.Size(73, 25);
			this.kryptonLabel10.TabIndex = 3;
			this.kryptonLabel10.Values.Text = "Opcional 3";
			// 
			// kryptonLabel11
			// 
			this.kryptonLabel11.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel11.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel11.Location = new System.Drawing.Point(40, 127);
			this.kryptonLabel11.Name = "kryptonLabel11";
			this.kryptonLabel11.Size = new System.Drawing.Size(73, 25);
			this.kryptonLabel11.TabIndex = 4;
			this.kryptonLabel11.Values.Text = "Opcional 4";
			// 
			// kryptonLabel9
			// 
			this.kryptonLabel9.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel9.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel9.Location = new System.Drawing.Point(40, 158);
			this.kryptonLabel9.Name = "kryptonLabel9";
			this.kryptonLabel9.Size = new System.Drawing.Size(73, 25);
			this.kryptonLabel9.TabIndex = 3;
			this.kryptonLabel9.Values.Text = "Opcional 5";
			// 
			// ItemOptionalTextBox
			// 
			this.ItemOptionalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EstacionPesaje.Properties.Settings.Default, "ItemOptional", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.ItemOptionalTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemOptionalTextBox.Location = new System.Drawing.Point(119, 3);
			this.ItemOptionalTextBox.MaximumSize = new System.Drawing.Size(250, 0);
			this.ItemOptionalTextBox.Name = "ItemOptionalTextBox";
			this.ItemOptionalTextBox.Size = new System.Drawing.Size(250, 23);
			this.ItemOptionalTextBox.TabIndex = 7;
			this.ItemOptionalTextBox.Text = global::EstacionPesaje.Properties.Settings.Default.ItemOptional;
			// 
			// kryptonPanel2
			// 
			this.kryptonPanel2.AutoSize = true;
			this.kryptonPanel2.Controls.Add(this.btnCancelButton);
			this.kryptonPanel2.Controls.Add(this.AceptButton);
			this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.kryptonPanel2.Location = new System.Drawing.Point(0, 280);
			this.kryptonPanel2.Name = "kryptonPanel2";
			this.kryptonPanel2.Size = new System.Drawing.Size(443, 49);
			this.kryptonPanel2.TabIndex = 11;
			// 
			// btnCancelButton
			// 
			this.btnCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelButton.Location = new System.Drawing.Point(3, 3);
			this.btnCancelButton.Name = "btnCancelButton";
			this.btnCancelButton.Size = new System.Drawing.Size(132, 43);
			this.btnCancelButton.TabIndex = 13;
			this.btnCancelButton.Values.Text = "&Cancelar";
			// 
			// AceptButton
			// 
			this.AceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.AceptButton.Location = new System.Drawing.Point(301, 3);
			this.AceptButton.Name = "AceptButton";
			this.AceptButton.Size = new System.Drawing.Size(132, 43);
			this.AceptButton.TabIndex = 14;
			this.AceptButton.Values.Text = "&Iniciar";
			// 
			// IniciarCaptura_frm
			// 
			this.AcceptButton = this.AceptButton;
			this.AutoScroll = true;
			this.CancelButton = this.btnCancelButton;
			this.ClientSize = new System.Drawing.Size(443, 329);
			this.Controls.Add(this.kryptonPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "IniciarCaptura_frm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Iniciar Captura";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IniciarCaptura_frm_FormClosing);
			this.Load += new System.EventHandler(this.IniciarCaptura_frm_Load);
			((System.ComponentModel.ISupportInitialize)(this.procesoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.etiquetaBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.etiquetaKryptonComboBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.InfoCapturaLayout.ResumeLayout(false);
			this.InfoCapturaLayout.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.TurnokryptonComboBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lineaKryptonComboBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.maquinasKryptonComboBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.maquinasBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.procesoKryptonComboBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
			this.kryptonGroupBox1.Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
			this.kryptonGroupBox1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
			this.kryptonPanel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.BindingSource procesoBindingSource;
		private System.Windows.Forms.BindingSource etiquetaBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox etiquetaKryptonComboBox;
		private libControlesPersonalizados.ZPLCONVERTER.zplImageConverter zplImageConverter1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelButton;
		private ComponentFactory.Krypton.Toolkit.KryptonButton AceptButton;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		public System.Windows.Forms.TableLayoutPanel InfoCapturaLayout;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox TurnokryptonComboBox;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox procesoKryptonComboBox;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox OperadorkryptonTextBox;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox lineaKryptonComboBox;
		private System.Windows.Forms.BindingSource lineaBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox maquinasKryptonComboBox;
		private System.Windows.Forms.BindingSource maquinasBindingSource;
		public System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox Optional5TextBox;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox Optional4TextBox;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox Optional3TextBox;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox Optional2TextBox;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox Optional1TextBox;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel11;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox ItemOptionalTextBox;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox Optional6TextBox;
	}
}