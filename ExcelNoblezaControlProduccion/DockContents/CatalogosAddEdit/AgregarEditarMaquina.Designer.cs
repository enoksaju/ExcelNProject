namespace EstacionPesaje.DockContents.CatalogosAddEdit
{
    partial class AgregarEditarMaquina
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.maquinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nombreMaquinaKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tipoMaquinaKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tipoMaquinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lineaKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lineaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.velocidadKryptonNumericUpDown = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            ((System.ComponentModel.ISupportInitialize)(this.maquinaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMaquinaKryptonComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMaquinaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineaKryptonComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // maquinaBindingSource
            // 
            this.maquinaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Maquina);
            // 
            // nombreMaquinaKryptonTextBox
            // 
            this.nombreMaquinaKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.maquinaBindingSource, "NombreMaquina", true));
            this.nombreMaquinaKryptonTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nombreMaquinaKryptonTextBox.Location = new System.Drawing.Point(118, 19);
            this.nombreMaquinaKryptonTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.nombreMaquinaKryptonTextBox.Name = "nombreMaquinaKryptonTextBox";
            this.nombreMaquinaKryptonTextBox.Size = new System.Drawing.Size(200, 23);
            this.nombreMaquinaKryptonTextBox.TabIndex = 3;
            // 
            // tipoMaquinaKryptonComboBox
            // 
            this.tipoMaquinaKryptonComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.maquinaBindingSource, "TipoMaquina", true));
            this.tipoMaquinaKryptonComboBox.DataSource = this.tipoMaquinaBindingSource;
            this.tipoMaquinaKryptonComboBox.DisplayMember = "Tipo_Maquina";
            this.tipoMaquinaKryptonComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tipoMaquinaKryptonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoMaquinaKryptonComboBox.DropDownWidth = 150;
            this.tipoMaquinaKryptonComboBox.Location = new System.Drawing.Point(118, 49);
            this.tipoMaquinaKryptonComboBox.MaximumSize = new System.Drawing.Size(150, 0);
            this.tipoMaquinaKryptonComboBox.Name = "tipoMaquinaKryptonComboBox";
            this.tipoMaquinaKryptonComboBox.Size = new System.Drawing.Size(150, 21);
            this.tipoMaquinaKryptonComboBox.TabIndex = 4;
            this.tipoMaquinaKryptonComboBox.ValueMember = "Id";
            // 
            // tipoMaquinaBindingSource
            // 
            this.tipoMaquinaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.TipoMaquina);
            // 
            // lineaKryptonComboBox
            // 
            this.lineaKryptonComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.maquinaBindingSource, "Linea", true));
            this.lineaKryptonComboBox.DataSource = this.lineaBindingSource;
            this.lineaKryptonComboBox.DisplayMember = "Nombre";
            this.lineaKryptonComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineaKryptonComboBox.DropDownWidth = 150;
            this.lineaKryptonComboBox.Location = new System.Drawing.Point(118, 79);
            this.lineaKryptonComboBox.MaximumSize = new System.Drawing.Size(150, 0);
            this.lineaKryptonComboBox.Name = "lineaKryptonComboBox";
            this.lineaKryptonComboBox.Size = new System.Drawing.Size(150, 21);
            this.lineaKryptonComboBox.TabIndex = 6;
            this.lineaKryptonComboBox.ValueMember = "Id";
            // 
            // lineaBindingSource
            // 
            this.lineaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Linea);
            // 
            // velocidadKryptonNumericUpDown
            // 
            this.velocidadKryptonNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.maquinaBindingSource, "Velocidad", true));
            this.velocidadKryptonNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.velocidadKryptonNumericUpDown.Location = new System.Drawing.Point(118, 109);
            this.velocidadKryptonNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.velocidadKryptonNumericUpDown.MaximumSize = new System.Drawing.Size(100, 0);
            this.velocidadKryptonNumericUpDown.Name = "velocidadKryptonNumericUpDown";
            this.velocidadKryptonNumericUpDown.Size = new System.Drawing.Size(100, 22);
            this.velocidadKryptonNumericUpDown.TabIndex = 8;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(1, 37);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonPanel1.Size = new System.Drawing.Size(375, 432);
            this.kryptonPanel1.TabIndex = 9;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(5, 5);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.tableLayoutPanel1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(365, 187);
            this.kryptonGroupBox1.TabIndex = 9;
            this.kryptonGroupBox1.Values.Heading = "Datos de la Maquina";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.velocidadKryptonNumericUpDown, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lineaKryptonComboBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.nombreMaquinaKryptonTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tipoMaquinaKryptonComboBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.kryptonWrapLabel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.kryptonWrapLabel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.kryptonWrapLabel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.kryptonWrapLabel4, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(361, 136);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(5, 21);
            this.kryptonWrapLabel1.Margin = new System.Windows.Forms.Padding(5);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(105, 20);
            this.kryptonWrapLabel1.Text = "Nombre:";
            this.kryptonWrapLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kryptonWrapLabel2
            // 
            this.kryptonWrapLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonWrapLabel2.Location = new System.Drawing.Point(5, 51);
            this.kryptonWrapLabel2.Margin = new System.Windows.Forms.Padding(5);
            this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            this.kryptonWrapLabel2.Size = new System.Drawing.Size(105, 20);
            this.kryptonWrapLabel2.Text = "Tipo:";
            this.kryptonWrapLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kryptonWrapLabel3
            // 
            this.kryptonWrapLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonWrapLabel3.Location = new System.Drawing.Point(5, 81);
            this.kryptonWrapLabel3.Margin = new System.Windows.Forms.Padding(5);
            this.kryptonWrapLabel3.Name = "kryptonWrapLabel3";
            this.kryptonWrapLabel3.Size = new System.Drawing.Size(105, 20);
            this.kryptonWrapLabel3.Text = "Linea:";
            this.kryptonWrapLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kryptonWrapLabel4
            // 
            this.kryptonWrapLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonWrapLabel4.Location = new System.Drawing.Point(5, 111);
            this.kryptonWrapLabel4.Margin = new System.Windows.Forms.Padding(5);
            this.kryptonWrapLabel4.Name = "kryptonWrapLabel4";
            this.kryptonWrapLabel4.Size = new System.Drawing.Size(105, 20);
            this.kryptonWrapLabel4.Text = "Velocidad:";
            this.kryptonWrapLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AgregarEditarMaquina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BindingSource = this.maquinaBindingSource;
            this.ClientSize = new System.Drawing.Size(377, 470);
            this.Controls.Add(this.kryptonPanel1);
            this.HeaderDescripcion = "";
            this.HeaderImage = global::EstacionPesaje.Properties.Resources.gears;
            this.HeaderText = "Maquina";
            this.Name = "AgregarEditarMaquina";
            this.Text = "AgregarEditarMaquina";
            this.Controls.SetChildIndex(this.kryptonPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.maquinaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMaquinaKryptonComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMaquinaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineaKryptonComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource maquinaBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox nombreMaquinaKryptonTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox tipoMaquinaKryptonComboBox;
        private System.Windows.Forms.BindingSource tipoMaquinaBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox lineaKryptonComboBox;
        private System.Windows.Forms.BindingSource lineaBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown velocidadKryptonNumericUpDown;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel4;
    }
}