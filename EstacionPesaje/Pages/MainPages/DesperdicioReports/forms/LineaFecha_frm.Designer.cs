namespace EstacionPesaje.Pages.MainPages.DesperdicioReports.forms {
	partial class LineaFecha_frm {
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
			this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.anual_obtn = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.mensual_obtn = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.Diario_obtn = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.Cancel_btn = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.Accept_btn = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.fecha_dp = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.linea_cb = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.lineaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
			this.kryptonGroupBox1.Panel.SuspendLayout();
			this.kryptonGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.linea_cb)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// kryptonGroupBox1
			// 
			this.kryptonGroupBox1.Location = new System.Drawing.Point(3, 3);
			this.kryptonGroupBox1.Name = "kryptonGroupBox1";
			// 
			// kryptonGroupBox1.Panel
			// 
			this.kryptonGroupBox1.Panel.Controls.Add(this.anual_obtn);
			this.kryptonGroupBox1.Panel.Controls.Add(this.mensual_obtn);
			this.kryptonGroupBox1.Panel.Controls.Add(this.Diario_obtn);
			this.kryptonGroupBox1.Size = new System.Drawing.Size(112, 117);
			this.kryptonGroupBox1.TabIndex = 0;
			this.kryptonGroupBox1.Values.Heading = "Rango";
			// 
			// anual_obtn
			// 
			this.anual_obtn.Location = new System.Drawing.Point(20, 61);
			this.anual_obtn.Name = "anual_obtn";
			this.anual_obtn.Size = new System.Drawing.Size(71, 20);
			this.anual_obtn.TabIndex = 3;
			this.anual_obtn.Values.Image = global::EstacionPesaje.Properties.Resources.calendar_selection_year;
			this.anual_obtn.Values.Text = "Anual";
			this.anual_obtn.CheckedChanged += new System.EventHandler(this.Rango_CheckedChanged);
			// 
			// mensual_obtn
			// 
			this.mensual_obtn.Location = new System.Drawing.Point(20, 35);
			this.mensual_obtn.Name = "mensual_obtn";
			this.mensual_obtn.Size = new System.Drawing.Size(86, 20);
			this.mensual_obtn.TabIndex = 2;
			this.mensual_obtn.Values.Image = global::EstacionPesaje.Properties.Resources.calendar_selection_week;
			this.mensual_obtn.Values.Text = "Mensual";
			this.mensual_obtn.CheckedChanged += new System.EventHandler(this.Rango_CheckedChanged);
			// 
			// Diario_obtn
			// 
			this.Diario_obtn.Checked = true;
			this.Diario_obtn.Location = new System.Drawing.Point(20, 9);
			this.Diario_obtn.Name = "Diario_obtn";
			this.Diario_obtn.Size = new System.Drawing.Size(72, 20);
			this.Diario_obtn.TabIndex = 1;
			this.Diario_obtn.Values.Image = global::EstacionPesaje.Properties.Resources.calendar_selection_day;
			this.Diario_obtn.Values.Text = "Diario";
			this.Diario_obtn.CheckedChanged += new System.EventHandler(this.Rango_CheckedChanged);
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
			this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
			this.kryptonPanel1.Controls.Add(this.fecha_dp);
			this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
			this.kryptonPanel1.Controls.Add(this.linea_cb);
			this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(328, 164);
			this.kryptonPanel1.TabIndex = 1;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.Cancel_btn, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.Accept_btn, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(114, 128);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(208, 33);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// Cancel_btn
			// 
			this.Cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel_btn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Cancel_btn.Location = new System.Drawing.Point(5, 3);
			this.Cancel_btn.Margin = new System.Windows.Forms.Padding(5, 3, 10, 3);
			this.Cancel_btn.Name = "Cancel_btn";
			this.Cancel_btn.Size = new System.Drawing.Size(89, 27);
			this.Cancel_btn.TabIndex = 6;
			this.Cancel_btn.Values.Text = "Cancelar";
			// 
			// Accept_btn
			// 
			this.Accept_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Accept_btn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Accept_btn.Location = new System.Drawing.Point(109, 3);
			this.Accept_btn.Margin = new System.Windows.Forms.Padding(5, 3, 10, 3);
			this.Accept_btn.Name = "Accept_btn";
			this.Accept_btn.Size = new System.Drawing.Size(89, 27);
			this.Accept_btn.TabIndex = 7;
			this.Accept_btn.Values.Text = "Aceptar";
			// 
			// kryptonLabel2
			// 
			this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel2.Location = new System.Drawing.Point(121, 60);
			this.kryptonLabel2.Name = "kryptonLabel2";
			this.kryptonLabel2.Size = new System.Drawing.Size(47, 20);
			this.kryptonLabel2.TabIndex = 4;
			this.kryptonLabel2.Values.Text = "Fecha:";
			// 
			// fecha_dp
			// 
			this.fecha_dp.CustomFormat = "dd MMMM yyyy";
			this.fecha_dp.DropButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
			this.fecha_dp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.fecha_dp.Location = new System.Drawing.Point(121, 85);
			this.fecha_dp.Name = "fecha_dp";
			this.fecha_dp.Size = new System.Drawing.Size(201, 21);
			this.fecha_dp.TabIndex = 5;
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			this.kryptonLabel1.Location = new System.Drawing.Point(121, 12);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(44, 20);
			this.kryptonLabel1.TabIndex = 2;
			this.kryptonLabel1.Values.Text = "Linea:";
			// 
			// linea_cb
			// 
			this.linea_cb.DataSource = this.lineaBindingSource;
			this.linea_cb.DisplayMember = "Nombre";
			this.linea_cb.DropButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
			this.linea_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.linea_cb.DropDownWidth = 209;
			this.linea_cb.Location = new System.Drawing.Point(121, 33);
			this.linea_cb.Name = "linea_cb";
			this.linea_cb.Size = new System.Drawing.Size(201, 21);
			this.linea_cb.TabIndex = 4;
			this.linea_cb.ValueMember = "Id";
			// 
			// lineaBindingSource
			// 
			this.lineaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Linea);
			// 
			// LineaFecha_frm
			// 
			this.AcceptButton = this.Accept_btn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_btn;
			this.ClientSize = new System.Drawing.Size(328, 164);
			this.Controls.Add(this.kryptonPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "LineaFecha_frm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Seleccione Linea Fecha";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LineaFecha_frm_FormClosing);
			this.Load += new System.EventHandler(this.LineaFecha_frm_Load);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
			this.kryptonGroupBox1.Panel.ResumeLayout(false);
			this.kryptonGroupBox1.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
			this.kryptonGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.linea_cb)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton anual_obtn;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton mensual_obtn;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton Diario_obtn;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton Cancel_btn;
		private ComponentFactory.Krypton.Toolkit.KryptonButton Accept_btn;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
		private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker fecha_dp;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox linea_cb;
		private System.Windows.Forms.BindingSource lineaBindingSource;
	}
}