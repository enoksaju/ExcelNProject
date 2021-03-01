namespace ControlNominasAddIn.Forms {
	partial class frmVacaciones {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( ) {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVacaciones));
            this.vacacionesKryptonDataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.CLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIAINICIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOMFER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIAFIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EN_BITACORA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnGetData = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.clFechaIni = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.clFechaFin = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.btnSaveChanges = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCheckAll = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.vacacionesKryptonDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // vacacionesKryptonDataGridView
            // 
            this.vacacionesKryptonDataGridView.AllowUserToAddRows = false;
            this.vacacionesKryptonDataGridView.AllowUserToDeleteRows = false;
            this.vacacionesKryptonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vacacionesKryptonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLAVE,
            this.DIAINICIO,
            this.DOMFER,
            this.DIAFIN,
            this.DIAS,
            this.EN_BITACORA});
            this.tableLayoutPanel2.SetColumnSpan(this.vacacionesKryptonDataGridView, 3);
            this.vacacionesKryptonDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vacacionesKryptonDataGridView.Location = new System.Drawing.Point(3, 33);
            this.vacacionesKryptonDataGridView.Name = "vacacionesKryptonDataGridView";
            this.vacacionesKryptonDataGridView.Size = new System.Drawing.Size(649, 155);
            this.vacacionesKryptonDataGridView.TabIndex = 1;
            this.vacacionesKryptonDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.vacacionesKryptonDataGridView_CellEndEdit);
            this.vacacionesKryptonDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.vacacionesKryptonDataGridView_CellFormatting);
            // 
            // CLAVE
            // 
            this.CLAVE.DataPropertyName = "CLAVE";
            this.CLAVE.HeaderText = "CLAVE";
            this.CLAVE.Name = "CLAVE";
            this.CLAVE.ReadOnly = true;
            // 
            // DIAINICIO
            // 
            this.DIAINICIO.DataPropertyName = "DIAINICIO";
            this.DIAINICIO.HeaderText = "DIAINICIO";
            this.DIAINICIO.Name = "DIAINICIO";
            this.DIAINICIO.ReadOnly = true;
            // 
            // DOMFER
            // 
            this.DOMFER.DataPropertyName = "DOMFER";
            this.DOMFER.HeaderText = "DOMFER";
            this.DOMFER.Name = "DOMFER";
            this.DOMFER.ReadOnly = true;
            // 
            // DIAFIN
            // 
            this.DIAFIN.DataPropertyName = "DIAFIN";
            this.DIAFIN.HeaderText = "DIAFIN";
            this.DIAFIN.Name = "DIAFIN";
            this.DIAFIN.ReadOnly = true;
            // 
            // DIAS
            // 
            this.DIAS.DataPropertyName = "DIAS";
            this.DIAS.HeaderText = "DIAS";
            this.DIAS.Name = "DIAS";
            this.DIAS.ReadOnly = true;
            // 
            // EN_BITACORA
            // 
            this.EN_BITACORA.DataPropertyName = "EN_BITACORA";
            this.EN_BITACORA.HeaderText = "EN_BITACORA";
            this.EN_BITACORA.Name = "EN_BITACORA";
            // 
            // btnGetData
            // 
            this.btnGetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetData.Location = new System.Drawing.Point(31, 130);
            this.btnGetData.Margin = new System.Windows.Forms.Padding(10);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(151, 59);
            this.btnGetData.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnGetData.TabIndex = 3;
            this.btnGetData.Values.Image = global::ControlNominasAddIn.Properties.Resources.database_export;
            this.btnGetData.Values.Text = "Importar Registros";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // clFechaIni
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.clFechaIni, 2);
            this.clFechaIni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clFechaIni.Location = new System.Drawing.Point(3, 33);
            this.clFechaIni.Name = "clFechaIni";
            this.clFechaIni.Size = new System.Drawing.Size(186, 21);
            this.clFechaIni.TabIndex = 4;
            // 
            // clFechaFin
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.clFechaFin, 2);
            this.clFechaFin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clFechaFin.Location = new System.Drawing.Point(3, 93);
            this.clFechaFin.Name = "clFechaFin";
            this.clFechaFin.Size = new System.Drawing.Size(186, 21);
            this.clFechaFin.TabIndex = 5;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveChanges.Location = new System.Drawing.Point(3, 3);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(89, 24);
            this.btnSaveChanges.TabIndex = 6;
            this.btnSaveChanges.Values.Image = global::ControlNominasAddIn.Properties.Resources.database_save;
            this.btnSaveChanges.Values.Text = "Guardar";
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheckAll.Location = new System.Drawing.Point(554, 3);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(98, 24);
            this.btnCheckAll.TabIndex = 7;
            this.btnCheckAll.Values.Image = global::ControlNominasAddIn.Properties.Resources.check_box;
            this.btnCheckAll.Values.Text = "Marcar Todo";
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.tableLayoutPanel1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(196, 223);
            this.kryptonGroupBox1.TabIndex = 8;
            this.kryptonGroupBox1.Values.Heading = "Traer Datos";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel1.Controls.Add(this.btnGetData, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.clFechaIni, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.clFechaFin, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(192, 199);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // kryptonLabel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.kryptonLabel1, 2);
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ItalicPanel;
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 7);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(186, 20);
            this.kryptonLabel1.TabIndex = 6;
            this.kryptonLabel1.Values.Text = "Fecha Inicial:";
            // 
            // kryptonLabel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.kryptonLabel2, 2);
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ItalicPanel;
            this.kryptonLabel2.Location = new System.Drawing.Point(3, 67);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(186, 20);
            this.kryptonLabel2.TabIndex = 7;
            this.kryptonLabel2.Values.Text = "Fecha Final:";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel3);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(877, 231);
            this.kryptonPanel1.TabIndex = 9;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.kryptonGroupBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.kryptonGroupBox2, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(877, 231);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox2.Location = new System.Drawing.Point(205, 3);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.tableLayoutPanel2);
            this.kryptonGroupBox2.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(669, 225);
            this.kryptonGroupBox2.TabIndex = 9;
            this.kryptonGroupBox2.Values.Heading = "Datos Devueltos";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel2.Controls.Add(this.btnSaveChanges, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.vacacionesKryptonDataGridView, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnCheckAll, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(655, 191);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // frmVacaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(877, 231);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(580, 270);
            this.Name = "frmVacaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vacaciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVacaciones_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.vacacionesKryptonDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView vacacionesKryptonDataGridView;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnGetData;
		private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker clFechaIni;
		private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker clFechaFin;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnSaveChanges;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnCheckAll;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.DataGridViewTextBoxColumn CLAVE;
		private System.Windows.Forms.DataGridViewTextBoxColumn DIAINICIO;
		private System.Windows.Forms.DataGridViewTextBoxColumn DOMFER;
		private System.Windows.Forms.DataGridViewTextBoxColumn DIAFIN;
		private System.Windows.Forms.DataGridViewTextBoxColumn DIAS;
		private System.Windows.Forms.DataGridViewCheckBoxColumn EN_BITACORA;
	}
}