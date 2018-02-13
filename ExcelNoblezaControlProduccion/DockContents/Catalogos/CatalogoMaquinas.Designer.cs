namespace ExcelNoblezaControlProduccion.DockContents.Catalogos
{
    partial class CatalogoMaquinas
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
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.TipoMaquina_Id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tipoMaquinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nombreMaquinaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea_Id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lineaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.velocidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maquinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LoaderPicktureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMaquinaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maquinaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoaderPicktureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToAddRows = false;
            this.kryptonDataGridView1.AllowUserToDeleteRows = false;
            this.kryptonDataGridView1.AutoGenerateColumns = false;
            this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoMaquina_Id,
            this.nombreMaquinaDataGridViewTextBoxColumn,
            this.Linea_Id,
            this.velocidadDataGridViewTextBoxColumn});
            this.kryptonDataGridView1.DataSource = this.maquinaBindingSource;
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.kryptonDataGridView1.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.kryptonDataGridView1.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kryptonDataGridView1.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kryptonDataGridView1.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(1, 51);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.ReadOnly = true;
            this.kryptonDataGridView1.RowHeadersWidth = 30;
            this.kryptonDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.kryptonDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(274, 433);
            this.kryptonDataGridView1.TabIndex = 5;
            this.kryptonDataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.kryptonDataGridView1_DataError);
            // 
            // TipoMaquina_Id
            // 
            this.TipoMaquina_Id.DataPropertyName = "TipoMaquina_Id";
            this.TipoMaquina_Id.DataSource = this.tipoMaquinaBindingSource;
            this.TipoMaquina_Id.DisplayMember = "Tipo_Maquina";
            this.TipoMaquina_Id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.TipoMaquina_Id.HeaderText = "Tipo";
            this.TipoMaquina_Id.Name = "TipoMaquina_Id";
            this.TipoMaquina_Id.ReadOnly = true;
            this.TipoMaquina_Id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TipoMaquina_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TipoMaquina_Id.ValueMember = "Id";
            // 
            // tipoMaquinaBindingSource
            // 
            this.tipoMaquinaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.TipoMaquina);
            // 
            // nombreMaquinaDataGridViewTextBoxColumn
            // 
            this.nombreMaquinaDataGridViewTextBoxColumn.DataPropertyName = "NombreMaquina";
            this.nombreMaquinaDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreMaquinaDataGridViewTextBoxColumn.Name = "nombreMaquinaDataGridViewTextBoxColumn";
            this.nombreMaquinaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Linea_Id
            // 
            this.Linea_Id.DataPropertyName = "Linea_Id";
            this.Linea_Id.DataSource = this.lineaBindingSource;
            this.Linea_Id.DisplayMember = "Nombre";
            this.Linea_Id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Linea_Id.HeaderText = "Linea";
            this.Linea_Id.Name = "Linea_Id";
            this.Linea_Id.ReadOnly = true;
            this.Linea_Id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Linea_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Linea_Id.ValueMember = "Id";
            // 
            // lineaBindingSource
            // 
            this.lineaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Linea);
            // 
            // velocidadDataGridViewTextBoxColumn
            // 
            this.velocidadDataGridViewTextBoxColumn.DataPropertyName = "Velocidad";
            this.velocidadDataGridViewTextBoxColumn.HeaderText = "Velocidad";
            this.velocidadDataGridViewTextBoxColumn.Name = "velocidadDataGridViewTextBoxColumn";
            this.velocidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // maquinaBindingSource
            // 
            this.maquinaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Maquina);
            // 
            // LoaderPicktureBox
            // 
            this.LoaderPicktureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LoaderPicktureBox.BackColor = System.Drawing.Color.Transparent;
            this.LoaderPicktureBox.Image = global::ExcelNoblezaControlProduccion.Properties.Resources.loading;
            this.LoaderPicktureBox.Location = new System.Drawing.Point(103, 88);
            this.LoaderPicktureBox.Name = "LoaderPicktureBox";
            this.LoaderPicktureBox.Size = new System.Drawing.Size(90, 90);
            this.LoaderPicktureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LoaderPicktureBox.TabIndex = 7;
            this.LoaderPicktureBox.TabStop = false;
            // 
            // CatalogoMaquinas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 485);
            this.Controls.Add(this.LoaderPicktureBox);
            this.Controls.Add(this.kryptonDataGridView1);
            this.Name = "CatalogoMaquinas";
            this.Text = "CatalogoMaquinas";
            this.Load += new System.EventHandler(this.CatalogoMaquinas_Load);
            this.Controls.SetChildIndex(this.kryptonDataGridView1, 0);
            this.Controls.SetChildIndex(this.LoaderPicktureBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMaquinaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maquinaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoaderPicktureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource maquinaBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.PictureBox LoaderPicktureBox;
        private System.Windows.Forms.BindingSource tipoMaquinaBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn TipoMaquina_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreMaquinaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Linea_Id;
        private System.Windows.Forms.BindingSource lineaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn velocidadDataGridViewTextBoxColumn;
    }
}