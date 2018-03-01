namespace ExcelNoblezaControlProduccion.DockContents.CatalogosAddEdit
{
    partial class AgregarEditarImpresora
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
            this.lineaKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lineaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nombreMaquinaKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.rodillosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.medidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decksKryptonNumericUpDown = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.velocidadKryptonNumericUpDown = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonBorderEdge1 = new ComponentFactory.Krypton.Toolkit.KryptonBorderEdge();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.maquinaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineaKryptonComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rodillosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // maquinaBindingSource
            // 
            this.maquinaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Maquina);
            // 
            // lineaKryptonComboBox
            // 
            this.lineaKryptonComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.maquinaBindingSource, "Linea", true));
            this.lineaKryptonComboBox.DataSource = this.lineaBindingSource;
            this.lineaKryptonComboBox.DisplayMember = "Nombre";
            this.lineaKryptonComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineaKryptonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lineaKryptonComboBox.DropDownWidth = 121;
            this.lineaKryptonComboBox.Location = new System.Drawing.Point(100, 31);
            this.lineaKryptonComboBox.MaximumSize = new System.Drawing.Size(250, 0);
            this.lineaKryptonComboBox.Name = "lineaKryptonComboBox";
            this.lineaKryptonComboBox.Size = new System.Drawing.Size(161, 21);
            this.lineaKryptonComboBox.TabIndex = 2;
            this.lineaKryptonComboBox.ValueMember = "Id";
            // 
            // lineaBindingSource
            // 
            this.lineaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Linea);
            // 
            // nombreMaquinaKryptonTextBox
            // 
            this.nombreMaquinaKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.maquinaBindingSource, "NombreMaquina", true));
            this.nombreMaquinaKryptonTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nombreMaquinaKryptonTextBox.Location = new System.Drawing.Point(100, 3);
            this.nombreMaquinaKryptonTextBox.MaximumSize = new System.Drawing.Size(250, 0);
            this.nombreMaquinaKryptonTextBox.Name = "nombreMaquinaKryptonTextBox";
            this.nombreMaquinaKryptonTextBox.Size = new System.Drawing.Size(161, 23);
            this.nombreMaquinaKryptonTextBox.TabIndex = 1;
            // 
            // rodillosBindingSource
            // 
            this.rodillosBindingSource.DataMember = "Rodillos";
            this.rodillosBindingSource.DataSource = this.maquinaBindingSource;
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AutoGenerateColumns = false;
            this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.medidaDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn});
            this.kryptonDataGridView1.DataSource = this.rodillosBindingSource;
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.Size = new System.Drawing.Size(254, 302);
            this.kryptonDataGridView1.TabIndex = 5;
            // 
            // medidaDataGridViewTextBoxColumn
            // 
            this.medidaDataGridViewTextBoxColumn.DataPropertyName = "Medida";
            this.medidaDataGridViewTextBoxColumn.HeaderText = "Medida";
            this.medidaDataGridViewTextBoxColumn.Name = "medidaDataGridViewTextBoxColumn";
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            // 
            // decksKryptonNumericUpDown
            // 
            this.decksKryptonNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.maquinaBindingSource, "Decks", true));
            this.decksKryptonNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decksKryptonNumericUpDown.Location = new System.Drawing.Point(100, 59);
            this.decksKryptonNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.decksKryptonNumericUpDown.MaximumSize = new System.Drawing.Size(120, 0);
            this.decksKryptonNumericUpDown.Name = "decksKryptonNumericUpDown";
            this.decksKryptonNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.decksKryptonNumericUpDown.TabIndex = 3;
            // 
            // velocidadKryptonNumericUpDown
            // 
            this.velocidadKryptonNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.maquinaBindingSource, "Velocidad", true));
            this.velocidadKryptonNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.velocidadKryptonNumericUpDown.Location = new System.Drawing.Point(100, 87);
            this.velocidadKryptonNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.velocidadKryptonNumericUpDown.MaximumSize = new System.Drawing.Size(120, 0);
            this.velocidadKryptonNumericUpDown.Name = "velocidadKryptonNumericUpDown";
            this.velocidadKryptonNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.velocidadKryptonNumericUpDown.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.nombreMaquinaKryptonTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.velocidadKryptonNumericUpDown, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.decksKryptonNumericUpDown, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lineaKryptonComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.kryptonWrapLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonWrapLabel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.kryptonWrapLabel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.kryptonWrapLabel4, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(264, 112);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(3, 4);
            this.kryptonWrapLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(91, 20);
            this.kryptonWrapLabel1.Text = "Nombre:";
            this.kryptonWrapLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kryptonWrapLabel2
            // 
            this.kryptonWrapLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonWrapLabel2.Location = new System.Drawing.Point(3, 32);
            this.kryptonWrapLabel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            this.kryptonWrapLabel2.Size = new System.Drawing.Size(91, 20);
            this.kryptonWrapLabel2.Text = "Linea:";
            this.kryptonWrapLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kryptonWrapLabel3
            // 
            this.kryptonWrapLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonWrapLabel3.Location = new System.Drawing.Point(3, 60);
            this.kryptonWrapLabel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kryptonWrapLabel3.Name = "kryptonWrapLabel3";
            this.kryptonWrapLabel3.Size = new System.Drawing.Size(91, 20);
            this.kryptonWrapLabel3.Text = "Decks:";
            this.kryptonWrapLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kryptonWrapLabel4
            // 
            this.kryptonWrapLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonWrapLabel4.Location = new System.Drawing.Point(3, 88);
            this.kryptonWrapLabel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kryptonWrapLabel4.Name = "kryptonWrapLabel4";
            this.kryptonWrapLabel4.Size = new System.Drawing.Size(91, 20);
            this.kryptonWrapLabel4.Text = "Velocidad:";
            this.kryptonWrapLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(10, 10);
            this.kryptonGroupBox1.Margin = new System.Windows.Forms.Padding(10);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.tableLayoutPanel1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(268, 136);
            this.kryptonGroupBox1.TabIndex = 9;
            this.kryptonGroupBox1.Values.Heading = "Datos de la Impresora";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox2.Location = new System.Drawing.Point(15, 171);
            this.kryptonGroupBox2.Margin = new System.Windows.Forms.Padding(15);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonDataGridView1);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(258, 326);
            this.kryptonGroupBox2.TabIndex = 10;
            this.kryptonGroupBox2.Values.Heading = "Rodillos";
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(1, 37);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(1, 512);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.kryptonGroupBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.kryptonGroupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 37);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(288, 512);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // AgregarEditarImpresora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BindingSource = this.maquinaBindingSource;
            this.ClientSize = new System.Drawing.Size(291, 550);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.kryptonBorderEdge1);
            this.HeaderDescripcion = "";
            this.HeaderImage = global::ExcelNoblezaControlProduccion.Properties.Resources.Center_of_Gravity;
            this.HeaderText = "Impresora";
            this.Name = "AgregarEditarImpresora";
            this.Text = "AgregarEditarImpresora";
            this.Load += new System.EventHandler(this.AgregarEditarImpresora_Load);
            this.Controls.SetChildIndex(this.kryptonBorderEdge1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.maquinaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineaKryptonComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rodillosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource maquinaBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox lineaKryptonComboBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox nombreMaquinaKryptonTextBox;
        private System.Windows.Forms.BindingSource rodillosBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn medidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown decksKryptonNumericUpDown;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown velocidadKryptonNumericUpDown;
        private System.Windows.Forms.BindingSource lineaBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonBorderEdge kryptonBorderEdge1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}