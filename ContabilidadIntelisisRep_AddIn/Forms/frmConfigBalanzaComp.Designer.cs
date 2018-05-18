namespace ContabilidadIntelisisRep_AddIn.Forms {
	partial class frmConfigBalanzaComp {
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Label conMovimientosLabel;
			System.Windows.Forms.Label ejercicioLabel;
			System.Windows.Forms.Label nivelLabel;
			System.Windows.Forms.Label periodoALabel;
			System.Windows.Forms.Label periodoDLabel;
			System.Windows.Forms.Label cuentaDLabel;
			System.Windows.Forms.Label cuentaALabel;
			this.conMovimientosComboBox = new System.Windows.Forms.ComboBox();
			this.frmContResultados_ConfigContBalanzaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ejercicioNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.nivelComboBox = new System.Windows.Forms.ComboBox();
			this.periodoANumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.periodoDNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.cuentaDTextBox = new System.Windows.Forms.TextBox();
			this.cuentaATextBox = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			conMovimientosLabel = new System.Windows.Forms.Label();
			ejercicioLabel = new System.Windows.Forms.Label();
			nivelLabel = new System.Windows.Forms.Label();
			periodoALabel = new System.Windows.Forms.Label();
			periodoDLabel = new System.Windows.Forms.Label();
			cuentaDLabel = new System.Windows.Forms.Label();
			cuentaALabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.frmContResultados_ConfigContBalanzaBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ejercicioNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.periodoANumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.periodoDNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// conMovimientosLabel
			// 
			conMovimientosLabel.AutoSize = true;
			conMovimientosLabel.Location = new System.Drawing.Point(7, 120);
			conMovimientosLabel.Name = "conMovimientosLabel";
			conMovimientosLabel.Size = new System.Drawing.Size(91, 13);
			conMovimientosLabel.TabIndex = 1;
			conMovimientosLabel.Text = "Con Movimientos:";
			// 
			// ejercicioLabel
			// 
			ejercicioLabel.AutoSize = true;
			ejercicioLabel.Location = new System.Drawing.Point(48, 14);
			ejercicioLabel.Name = "ejercicioLabel";
			ejercicioLabel.Size = new System.Drawing.Size(50, 13);
			ejercicioLabel.TabIndex = 3;
			ejercicioLabel.Text = "Ejercicio:";
			// 
			// nivelLabel
			// 
			nivelLabel.AutoSize = true;
			nivelLabel.Location = new System.Drawing.Point(64, 93);
			nivelLabel.Name = "nivelLabel";
			nivelLabel.Size = new System.Drawing.Size(34, 13);
			nivelLabel.TabIndex = 5;
			nivelLabel.Text = "Nivel:";
			// 
			// periodoALabel
			// 
			periodoALabel.AutoSize = true;
			periodoALabel.Location = new System.Drawing.Point(27, 66);
			periodoALabel.Name = "periodoALabel";
			periodoALabel.Size = new System.Drawing.Size(71, 13);
			periodoALabel.TabIndex = 7;
			periodoALabel.Text = "Periodo Final:";
			// 
			// periodoDLabel
			// 
			periodoDLabel.AutoSize = true;
			periodoDLabel.Location = new System.Drawing.Point(22, 40);
			periodoDLabel.Name = "periodoDLabel";
			periodoDLabel.Size = new System.Drawing.Size(76, 13);
			periodoDLabel.TabIndex = 9;
			periodoDLabel.Text = "Periodo Inicial:";
			// 
			// cuentaDLabel
			// 
			cuentaDLabel.AutoSize = true;
			cuentaDLabel.Location = new System.Drawing.Point(24, 162);
			cuentaDLabel.Name = "cuentaDLabel";
			cuentaDLabel.Size = new System.Drawing.Size(74, 13);
			cuentaDLabel.TabIndex = 12;
			cuentaDLabel.Text = "Cuenta Inicial:";
			// 
			// cuentaALabel
			// 
			cuentaALabel.AutoSize = true;
			cuentaALabel.Location = new System.Drawing.Point(29, 188);
			cuentaALabel.Name = "cuentaALabel";
			cuentaALabel.Size = new System.Drawing.Size(69, 13);
			cuentaALabel.TabIndex = 14;
			cuentaALabel.Text = "Cuenta Final:";
			// 
			// conMovimientosComboBox
			// 
			this.conMovimientosComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.frmContResultados_ConfigContBalanzaBindingSource, "ConMovimientos", true));
			this.conMovimientosComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.conMovimientosComboBox.FormattingEnabled = true;
			this.conMovimientosComboBox.Location = new System.Drawing.Point(104, 117);
			this.conMovimientosComboBox.Name = "conMovimientosComboBox";
			this.conMovimientosComboBox.Size = new System.Drawing.Size(121, 21);
			this.conMovimientosComboBox.TabIndex = 2;
			// 
			// frmContResultados_ConfigContBalanzaBindingSource
			// 
			this.frmContResultados_ConfigContBalanzaBindingSource.DataSource = typeof(ContabilidadIntelisisRep_AddIn.Forms.frmContResultados.ConfigContBalanza);
			// 
			// ejercicioNumericUpDown
			// 
			this.ejercicioNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.frmContResultados_ConfigContBalanzaBindingSource, "Ejercicio", true));
			this.ejercicioNumericUpDown.Location = new System.Drawing.Point(104, 12);
			this.ejercicioNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.ejercicioNumericUpDown.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.ejercicioNumericUpDown.Name = "ejercicioNumericUpDown";
			this.ejercicioNumericUpDown.Size = new System.Drawing.Size(121, 20);
			this.ejercicioNumericUpDown.TabIndex = 4;
			this.ejercicioNumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			// 
			// nivelComboBox
			// 
			this.nivelComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.frmContResultados_ConfigContBalanzaBindingSource, "Nivel", true));
			this.nivelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.nivelComboBox.FormattingEnabled = true;
			this.nivelComboBox.Location = new System.Drawing.Point(104, 90);
			this.nivelComboBox.Name = "nivelComboBox";
			this.nivelComboBox.Size = new System.Drawing.Size(121, 21);
			this.nivelComboBox.TabIndex = 6;
			// 
			// periodoANumericUpDown
			// 
			this.periodoANumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.frmContResultados_ConfigContBalanzaBindingSource, "PeriodoA", true));
			this.periodoANumericUpDown.Location = new System.Drawing.Point(104, 64);
			this.periodoANumericUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.periodoANumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.periodoANumericUpDown.Name = "periodoANumericUpDown";
			this.periodoANumericUpDown.Size = new System.Drawing.Size(121, 20);
			this.periodoANumericUpDown.TabIndex = 8;
			this.periodoANumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// periodoDNumericUpDown
			// 
			this.periodoDNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.frmContResultados_ConfigContBalanzaBindingSource, "PeriodoD", true));
			this.periodoDNumericUpDown.Location = new System.Drawing.Point(104, 38);
			this.periodoDNumericUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.periodoDNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.periodoDNumericUpDown.Name = "periodoDNumericUpDown";
			this.periodoDNumericUpDown.Size = new System.Drawing.Size(121, 20);
			this.periodoDNumericUpDown.TabIndex = 10;
			this.periodoDNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(10, 233);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = "Continuar";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(184, 233);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 12;
			this.button2.Text = "Cancelar";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// cuentaDTextBox
			// 
			this.cuentaDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.frmContResultados_ConfigContBalanzaBindingSource, "CuentaD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cuentaDTextBox.Location = new System.Drawing.Point(104, 159);
			this.cuentaDTextBox.Name = "cuentaDTextBox";
			this.cuentaDTextBox.Size = new System.Drawing.Size(121, 20);
			this.cuentaDTextBox.TabIndex = 13;
			// 
			// cuentaATextBox
			// 
			this.cuentaATextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.frmContResultados_ConfigContBalanzaBindingSource, "CuentaA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cuentaATextBox.Location = new System.Drawing.Point(104, 185);
			this.cuentaATextBox.Name = "cuentaATextBox";
			this.cuentaATextBox.Size = new System.Drawing.Size(121, 20);
			this.cuentaATextBox.TabIndex = 15;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(225, 159);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(26, 20);
			this.button3.TabIndex = 16;
			this.button3.Text = "...";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(225, 185);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(26, 20);
			this.button4.TabIndex = 17;
			this.button4.Text = "...";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// frmConfigBalanzaComp
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(265, 262);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(cuentaALabel);
			this.Controls.Add(this.cuentaATextBox);
			this.Controls.Add(cuentaDLabel);
			this.Controls.Add(this.cuentaDTextBox);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(conMovimientosLabel);
			this.Controls.Add(this.conMovimientosComboBox);
			this.Controls.Add(ejercicioLabel);
			this.Controls.Add(this.ejercicioNumericUpDown);
			this.Controls.Add(nivelLabel);
			this.Controls.Add(this.nivelComboBox);
			this.Controls.Add(periodoALabel);
			this.Controls.Add(this.periodoANumericUpDown);
			this.Controls.Add(periodoDLabel);
			this.Controls.Add(this.periodoDNumericUpDown);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmConfigBalanzaComp";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Balanza Comprobacion";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfigBalanzaComp_FormClosing);
			this.Load += new System.EventHandler(this.frmConfigBalanzaComp_Load);
			((System.ComponentModel.ISupportInitialize)(this.frmContResultados_ConfigContBalanzaBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ejercicioNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.periodoANumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.periodoDNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.BindingSource frmContResultados_ConfigContBalanzaBindingSource;
		private System.Windows.Forms.ComboBox conMovimientosComboBox;
		private System.Windows.Forms.NumericUpDown ejercicioNumericUpDown;
		private System.Windows.Forms.ComboBox nivelComboBox;
		private System.Windows.Forms.NumericUpDown periodoANumericUpDown;
		private System.Windows.Forms.NumericUpDown periodoDNumericUpDown;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox cuentaDTextBox;
		private System.Windows.Forms.TextBox cuentaATextBox;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
	}
}