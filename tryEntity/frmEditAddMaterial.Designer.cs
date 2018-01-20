namespace tryEntity
{
    partial class frmEditAddMaterial
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
            System.Windows.Forms.Label aparienciaLabel;
            System.Windows.Forms.Label formulaLabel;
            System.Windows.Forms.Label densidadLabel;
            this.aparienciaTextBox = new System.Windows.Forms.TextBox();
            this.materialesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formulaTextBox = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.densidadTextBox = new System.Windows.Forms.TextBox();
            aparienciaLabel = new System.Windows.Forms.Label();
            formulaLabel = new System.Windows.Forms.Label();
            densidadLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.materialesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // aparienciaLabel
            // 
            aparienciaLabel.AutoSize = true;
            aparienciaLabel.Location = new System.Drawing.Point(4, 15);
            aparienciaLabel.Name = "aparienciaLabel";
            aparienciaLabel.Size = new System.Drawing.Size(60, 13);
            aparienciaLabel.TabIndex = 1;
            aparienciaLabel.Text = "Apariencia:";
            // 
            // formulaLabel
            // 
            formulaLabel.AutoSize = true;
            formulaLabel.Location = new System.Drawing.Point(16, 41);
            formulaLabel.Name = "formulaLabel";
            formulaLabel.Size = new System.Drawing.Size(47, 13);
            formulaLabel.TabIndex = 5;
            formulaLabel.Text = "Formula:";
            // 
            // aparienciaTextBox
            // 
            this.aparienciaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.materialesBindingSource, "Apariencia", true));
            this.aparienciaTextBox.Location = new System.Drawing.Point(70, 12);
            this.aparienciaTextBox.Name = "aparienciaTextBox";
            this.aparienciaTextBox.Size = new System.Drawing.Size(221, 20);
            this.aparienciaTextBox.TabIndex = 2;
            // 
            // materialesBindingSource
            // 
            this.materialesBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Material);
            // 
            // formulaTextBox
            // 
            this.formulaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.materialesBindingSource, "Formula", true));
            this.formulaTextBox.Location = new System.Drawing.Point(70, 38);
            this.formulaTextBox.Name = "formulaTextBox";
            this.formulaTextBox.Size = new System.Drawing.Size(221, 20);
            this.formulaTextBox.TabIndex = 6;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = global::tryEntity.Properties.Resources.cancel;
            this.btnCancelar.Location = new System.Drawing.Point(184, 96);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 44);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Image = global::tryEntity.Properties.Resources.accept_button;
            this.btnAceptar.Location = new System.Drawing.Point(69, 96);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(107, 44);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // densidadLabel
            // 
            densidadLabel.AutoSize = true;
            densidadLabel.Location = new System.Drawing.Point(8, 67);
            densidadLabel.Name = "densidadLabel";
            densidadLabel.Size = new System.Drawing.Size(55, 13);
            densidadLabel.TabIndex = 17;
            densidadLabel.Text = "Densidad:";
            // 
            // densidadTextBox
            // 
            this.densidadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.materialesBindingSource, "Densidad", true));
            this.densidadTextBox.Location = new System.Drawing.Point(69, 64);
            this.densidadTextBox.Name = "densidadTextBox";
            this.densidadTextBox.Size = new System.Drawing.Size(100, 20);
            this.densidadTextBox.TabIndex = 18;
            // 
            // frmEditAddMaterial
            // 
            this.AcceptButton = this.btnCancelar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 160);
            this.Controls.Add(densidadLabel);
            this.Controls.Add(this.densidadTextBox);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(aparienciaLabel);
            this.Controls.Add(this.aparienciaTextBox);
            this.Controls.Add(formulaLabel);
            this.Controls.Add(this.formulaTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditAddMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmEditAddMaterial";
            this.Load += new System.EventHandler(this.frmEditAddMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.materialesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource materialesBindingSource;
        private System.Windows.Forms.TextBox aparienciaTextBox;
        private System.Windows.Forms.TextBox formulaTextBox;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox densidadTextBox;
    }
}