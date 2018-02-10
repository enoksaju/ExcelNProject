namespace ControlProduccion.Catalogos
{
    partial class ClientesCatalogoForm
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
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clienteKryptonDataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteKryptonDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Cliente);
            // 
            // clienteKryptonDataGridView
            // 
            this.clienteKryptonDataGridView.AllowUserToAddRows = false;
            this.clienteKryptonDataGridView.AllowUserToDeleteRows = false;
            this.clienteKryptonDataGridView.AutoGenerateColumns = false;
            this.clienteKryptonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clienteKryptonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2});
            this.clienteKryptonDataGridView.DataSource = this.clienteBindingSource;
            this.clienteKryptonDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clienteKryptonDataGridView.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.clienteKryptonDataGridView.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.clienteKryptonDataGridView.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.clienteKryptonDataGridView.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.clienteKryptonDataGridView.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.clienteKryptonDataGridView.Location = new System.Drawing.Point(0, 50);
            this.clienteKryptonDataGridView.Name = "clienteKryptonDataGridView";
            this.clienteKryptonDataGridView.ReadOnly = true;
            this.clienteKryptonDataGridView.RowHeadersWidth = 30;
            this.clienteKryptonDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.clienteKryptonDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clienteKryptonDataGridView.Size = new System.Drawing.Size(270, 389);
            this.clienteKryptonDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ClaveCliente";
            this.dataGridViewTextBoxColumn3.HeaderText = "ClaveCliente";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreCliente";
            this.dataGridViewTextBoxColumn2.HeaderText = "NombreCliente";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // ClientesCatalogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 439);
            this.Controls.Add(this.clienteKryptonDataGridView);
            this.Name = "ClientesCatalogoForm";
            this.TabText = "Catalogo de Clientes";
            this.Text = "ClientesCatalogoForm";
            this.Load += new System.EventHandler(this.ClientesCatalogoForm_Load);
            this.Controls.SetChildIndex(this.clienteKryptonDataGridView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteKryptonDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource clienteBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView clienteKryptonDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}