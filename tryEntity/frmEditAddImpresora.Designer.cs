namespace tryEntity
{
    partial class frmEditAddImpresora
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
            System.Windows.Forms.Label nombreMaquinaLabel;
            System.Windows.Forms.Label velocidadLabel;
            System.Windows.Forms.Label decksLabel;
            this.nombreMaquinaTextBox = new System.Windows.Forms.TextBox();
            this.rodillosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.velocidadTextBox = new System.Windows.Forms.TextBox();
            this.decksTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.maquinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rodillosDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            nombreMaquinaLabel = new System.Windows.Forms.Label();
            velocidadLabel = new System.Windows.Forms.Label();
            decksLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rodillosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maquinaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rodillosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // nombreMaquinaLabel
            // 
            nombreMaquinaLabel.AutoSize = true;
            nombreMaquinaLabel.Location = new System.Drawing.Point(12, 9);
            nombreMaquinaLabel.Name = "nombreMaquinaLabel";
            nombreMaquinaLabel.Size = new System.Drawing.Size(91, 13);
            nombreMaquinaLabel.TabIndex = 5;
            nombreMaquinaLabel.Text = "Nombre Maquina:";
            // 
            // velocidadLabel
            // 
            velocidadLabel.AutoSize = true;
            velocidadLabel.Location = new System.Drawing.Point(46, 35);
            velocidadLabel.Name = "velocidadLabel";
            velocidadLabel.Size = new System.Drawing.Size(57, 13);
            velocidadLabel.TabIndex = 10;
            velocidadLabel.Text = "Velocidad:";
            // 
            // decksLabel
            // 
            decksLabel.AutoSize = true;
            decksLabel.Location = new System.Drawing.Point(213, 35);
            decksLabel.Name = "decksLabel";
            decksLabel.Size = new System.Drawing.Size(41, 13);
            decksLabel.TabIndex = 11;
            decksLabel.Text = "Decks:";
            // 
            // nombreMaquinaTextBox
            // 
            this.nombreMaquinaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.maquinaBindingSource, "NombreMaquina", true));
            this.nombreMaquinaTextBox.Location = new System.Drawing.Point(109, 6);
            this.nombreMaquinaTextBox.Name = "nombreMaquinaTextBox";
            this.nombreMaquinaTextBox.Size = new System.Drawing.Size(251, 20);
            this.nombreMaquinaTextBox.TabIndex = 6;
            // 
            // rodillosBindingSource
            // 
            this.rodillosBindingSource.DataMember = "Rodillos";
            this.rodillosBindingSource.DataSource = this.maquinaBindingSource;
            // 
            // velocidadTextBox
            // 
            this.velocidadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.maquinaBindingSource, "Velocidad", true));
            this.velocidadTextBox.Location = new System.Drawing.Point(109, 32);
            this.velocidadTextBox.Name = "velocidadTextBox";
            this.velocidadTextBox.Size = new System.Drawing.Size(100, 20);
            this.velocidadTextBox.TabIndex = 11;
            // 
            // decksTextBox
            // 
            this.decksTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.maquinaBindingSource, "Decks", true));
            this.decksTextBox.Location = new System.Drawing.Point(260, 32);
            this.decksTextBox.Name = "decksTextBox";
            this.decksTextBox.Size = new System.Drawing.Size(100, 20);
            this.decksTextBox.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rodillosDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 271);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rodillos";
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Image = global::tryEntity.Properties.Resources.accept_button;
            this.btnAceptar.Location = new System.Drawing.Point(138, 339);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(107, 44);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = global::tryEntity.Properties.Resources.cancel;
            this.btnCancelar.Location = new System.Drawing.Point(251, 339);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 44);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // maquinaBindingSource
            // 
            this.maquinaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Maquina);
            // 
            // rodillosDataGridView
            // 
            this.rodillosDataGridView.AutoGenerateColumns = false;
            this.rodillosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rodillosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.rodillosDataGridView.DataSource = this.rodillosBindingSource;
            this.rodillosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rodillosDataGridView.Location = new System.Drawing.Point(3, 16);
            this.rodillosDataGridView.Name = "rodillosDataGridView";
            this.rodillosDataGridView.Size = new System.Drawing.Size(358, 252);
            this.rodillosDataGridView.TabIndex = 0;
            this.rodillosDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.rodillosDataGridView_DataError);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Medida";
            this.dataGridViewTextBoxColumn2.HeaderText = "Medida";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Cantidad";
            this.dataGridViewTextBoxColumn3.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // frmEditAddImpresora
            // 
            this.AcceptButton = this.btnCancelar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 388);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(decksLabel);
            this.Controls.Add(this.decksTextBox);
            this.Controls.Add(velocidadLabel);
            this.Controls.Add(this.velocidadTextBox);
            this.Controls.Add(nombreMaquinaLabel);
            this.Controls.Add(this.nombreMaquinaTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditAddImpresora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddEditImpresora";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditAddImpresora_FormClosing);
            this.Load += new System.EventHandler(this.frmEditAddImpresora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rodillosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.maquinaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rodillosDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource maquinaBindingSource;
        private System.Windows.Forms.TextBox nombreMaquinaTextBox;
        private System.Windows.Forms.BindingSource rodillosBindingSource;
        private System.Windows.Forms.TextBox velocidadTextBox;
        private System.Windows.Forms.TextBox decksTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView rodillosDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}