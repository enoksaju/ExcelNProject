namespace EstacionesPesaje.Pages.MainPages.MaquinasForms {
	partial class AddMaquinaFrm {
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
			this.kryptonComboBox1 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.lineaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tipoMaquinaKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.tipoMaquinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.velocidadKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.nombreMaquinaKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tipoMaquinaKryptonComboBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tipoMaquinaBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// kryptonComboBox1
			// 
			this.kryptonComboBox1.DataSource = this.lineaBindingSource;
			this.kryptonComboBox1.DisplayMember = "Nombre";
			this.kryptonComboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.kryptonComboBox1.DropDownWidth = 198;
			this.kryptonComboBox1.Location = new System.Drawing.Point(77, 3);
			this.kryptonComboBox1.Name = "kryptonComboBox1";
			this.kryptonComboBox1.Size = new System.Drawing.Size(198, 21);
			this.kryptonComboBox1.TabIndex = 0;
			this.kryptonComboBox1.ValueMember = "Id";
			// 
			// lineaBindingSource
			// 
			this.lineaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Linea);
			// 
			// tipoMaquinaKryptonComboBox
			// 
			this.tipoMaquinaKryptonComboBox.DataSource = this.tipoMaquinaBindingSource;
			this.tipoMaquinaKryptonComboBox.DisplayMember = "Tipo_Maquina";
			this.tipoMaquinaKryptonComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tipoMaquinaKryptonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tipoMaquinaKryptonComboBox.DropDownWidth = 198;
			this.tipoMaquinaKryptonComboBox.Location = new System.Drawing.Point(77, 93);
			this.tipoMaquinaKryptonComboBox.Name = "tipoMaquinaKryptonComboBox";
			this.tipoMaquinaKryptonComboBox.Size = new System.Drawing.Size(198, 21);
			this.tipoMaquinaKryptonComboBox.TabIndex = 2;
			this.tipoMaquinaKryptonComboBox.ValueMember = "Tipo_Maquina";
			// 
			// tipoMaquinaBindingSource
			// 
			this.tipoMaquinaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.TipoMaquina);
			// 
			// velocidadKryptonTextBox
			// 
			this.velocidadKryptonTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.velocidadKryptonTextBox.Location = new System.Drawing.Point(77, 123);
			this.velocidadKryptonTextBox.Name = "velocidadKryptonTextBox";
			this.velocidadKryptonTextBox.Size = new System.Drawing.Size(198, 23);
			this.velocidadKryptonTextBox.TabIndex = 3;
			// 
			// nombreMaquinaKryptonTextBox
			// 
			this.nombreMaquinaKryptonTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nombreMaquinaKryptonTextBox.Location = new System.Drawing.Point(77, 63);
			this.nombreMaquinaKryptonTextBox.Name = "nombreMaquinaKryptonTextBox";
			this.nombreMaquinaKryptonTextBox.Size = new System.Drawing.Size(198, 23);
			this.nombreMaquinaKryptonTextBox.TabIndex = 4;
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 153);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(278, 33);
			this.kryptonPanel1.TabIndex = 5;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.kryptonButton1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.kryptonButton2, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(82, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(196, 33);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// kryptonButton1
			// 
			this.kryptonButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.kryptonButton1.Location = new System.Drawing.Point(5, 3);
			this.kryptonButton1.Margin = new System.Windows.Forms.Padding(5, 3, 3, 5);
			this.kryptonButton1.Name = "kryptonButton1";
			this.kryptonButton1.Size = new System.Drawing.Size(90, 25);
			this.kryptonButton1.TabIndex = 0;
			this.kryptonButton1.Values.Text = "Cancelar";
			// 
			// kryptonButton2
			// 
			this.kryptonButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.kryptonButton2.Location = new System.Drawing.Point(103, 3);
			this.kryptonButton2.Margin = new System.Windows.Forms.Padding(5, 3, 3, 5);
			this.kryptonButton2.Name = "kryptonButton2";
			this.kryptonButton2.Size = new System.Drawing.Size(90, 25);
			this.kryptonButton2.TabIndex = 1;
			this.kryptonButton2.Values.Text = "Agregar";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.61871F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.38129F));
			this.tableLayoutPanel2.Controls.Add(this.kryptonComboBox1, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.nombreMaquinaKryptonTextBox, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.velocidadKryptonTextBox, 1, 4);
			this.tableLayoutPanel2.Controls.Add(this.tipoMaquinaKryptonComboBox, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.kryptonLabel1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.kryptonLabel4, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.kryptonLabel3, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.kryptonLabel2, 0, 2);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 5;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(278, 153);
			this.tableLayoutPanel2.TabIndex = 6;
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel1.Location = new System.Drawing.Point(32, 3);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(39, 24);
			this.kryptonLabel1.TabIndex = 5;
			this.kryptonLabel1.Values.Text = "Linea";
			// 
			// kryptonLabel4
			// 
			this.kryptonLabel4.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel4.Location = new System.Drawing.Point(7, 123);
			this.kryptonLabel4.Name = "kryptonLabel4";
			this.kryptonLabel4.Size = new System.Drawing.Size(64, 27);
			this.kryptonLabel4.TabIndex = 8;
			this.kryptonLabel4.Values.Text = "Velocidad";
			// 
			// kryptonLabel3
			// 
			this.kryptonLabel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel3.Location = new System.Drawing.Point(37, 93);
			this.kryptonLabel3.Name = "kryptonLabel3";
			this.kryptonLabel3.Size = new System.Drawing.Size(34, 24);
			this.kryptonLabel3.TabIndex = 7;
			this.kryptonLabel3.Values.Text = "Tipo";
			// 
			// kryptonLabel2
			// 
			this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.kryptonLabel2.Location = new System.Drawing.Point(15, 63);
			this.kryptonLabel2.Name = "kryptonLabel2";
			this.kryptonLabel2.Size = new System.Drawing.Size(56, 24);
			this.kryptonLabel2.TabIndex = 6;
			this.kryptonLabel2.Values.Text = "Nombre";
			// 
			// AddMaquinaFrm
			// 
			this.AcceptButton = this.kryptonButton1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(278, 186);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Controls.Add(this.kryptonPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AddMaquinaFrm";
			this.Opacity = 0.9D;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Agregar Maquina";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddMaquinaFrm_FormClosing);
			this.Load += new System.EventHandler(this.AddMaquinaFrm_Load);
			((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tipoMaquinaKryptonComboBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tipoMaquinaBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonComboBox kryptonComboBox1;
		private System.Windows.Forms.BindingSource lineaBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox tipoMaquinaKryptonComboBox;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox velocidadKryptonTextBox;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox nombreMaquinaKryptonTextBox;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
		private System.Windows.Forms.BindingSource tipoMaquinaBindingSource;
	}
}