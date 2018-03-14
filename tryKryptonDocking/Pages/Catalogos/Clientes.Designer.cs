namespace tryKryptonDocking.Pages.Catalogos
{
    partial class Clientes
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.nombreClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.claveClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// clienteBindingSource
			// 
			this.clienteBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Cliente);
			// 
			// kryptonDataGridView1
			// 
			this.kryptonDataGridView1.AllowUserToAddRows = false;
			this.kryptonDataGridView1.AllowUserToDeleteRows = false;
			this.kryptonDataGridView1.AutoGenerateColumns = false;
			this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreClienteDataGridViewTextBoxColumn,
            this.claveClienteDataGridViewTextBoxColumn});
			this.kryptonDataGridView1.DataSource = this.clienteBindingSource;
			this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonDataGridView1.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
			this.kryptonDataGridView1.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
			this.kryptonDataGridView1.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.kryptonDataGridView1.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.kryptonDataGridView1.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.kryptonDataGridView1.Location = new System.Drawing.Point(5, 5);
			this.kryptonDataGridView1.Name = "kryptonDataGridView1";
			this.kryptonDataGridView1.ReadOnly = true;
			this.kryptonDataGridView1.RowHeadersVisible = false;
			this.kryptonDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.kryptonDataGridView1.Size = new System.Drawing.Size(232, 383);
			this.kryptonDataGridView1.TabIndex = 1;
			// 
			// nombreClienteDataGridViewTextBoxColumn
			// 
			this.nombreClienteDataGridViewTextBoxColumn.DataPropertyName = "NombreCliente";
			this.nombreClienteDataGridViewTextBoxColumn.HeaderText = "NombreCliente";
			this.nombreClienteDataGridViewTextBoxColumn.Name = "nombreClienteDataGridViewTextBoxColumn";
			this.nombreClienteDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// claveClienteDataGridViewTextBoxColumn
			// 
			this.claveClienteDataGridViewTextBoxColumn.DataPropertyName = "ClaveCliente";
			this.claveClienteDataGridViewTextBoxColumn.HeaderText = "ClaveCliente";
			this.claveClienteDataGridViewTextBoxColumn.Name = "claveClienteDataGridViewTextBoxColumn";
			this.claveClienteDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// Clientes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BindingSource = this.clienteBindingSource;
			this.CatalogDataGridView = this.kryptonDataGridView1;
			this.Controls.Add(this.kryptonDataGridView1);
			this.Name = "Clientes";
			this.PageDescriptionText = "";
			this.PageTitleText = "Catalogo Clientes";
			this.RibbonContext = "Catalogos";
			this.Size = new System.Drawing.Size(242, 393);
			this.Controls.SetChildIndex(this.kryptonDataGridView1, 0);
			((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource clienteBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn claveClienteDataGridViewTextBoxColumn;
    }
}
