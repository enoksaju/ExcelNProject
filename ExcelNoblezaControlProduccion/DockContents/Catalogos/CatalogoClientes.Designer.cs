namespace EstacionesPesaje.DockContents.Catalogos
{
    partial class CatalogoClientes
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
            this.clienteKryptonDataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.claveClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LoaderPicktureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.clienteKryptonDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoaderPicktureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // clienteKryptonDataGridView
            // 
            this.clienteKryptonDataGridView.AllowUserToAddRows = false;
            this.clienteKryptonDataGridView.AllowUserToDeleteRows = false;
            this.clienteKryptonDataGridView.AutoGenerateColumns = false;
            this.clienteKryptonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clienteKryptonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.claveClienteDataGridViewTextBoxColumn,
            this.nombreClienteDataGridViewTextBoxColumn});
            this.clienteKryptonDataGridView.DataSource = this.clienteBindingSource;
            this.clienteKryptonDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clienteKryptonDataGridView.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.clienteKryptonDataGridView.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.clienteKryptonDataGridView.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.clienteKryptonDataGridView.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.clienteKryptonDataGridView.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.clienteKryptonDataGridView.Location = new System.Drawing.Point(1, 51);
            this.clienteKryptonDataGridView.MultiSelect = false;
            this.clienteKryptonDataGridView.Name = "clienteKryptonDataGridView";
            this.clienteKryptonDataGridView.ReadOnly = true;
            this.clienteKryptonDataGridView.RowHeadersWidth = 30;
            this.clienteKryptonDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.clienteKryptonDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clienteKryptonDataGridView.Size = new System.Drawing.Size(250, 382);
            this.clienteKryptonDataGridView.TabIndex = 5;
            // 
            // claveClienteDataGridViewTextBoxColumn
            // 
            this.claveClienteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.claveClienteDataGridViewTextBoxColumn.DataPropertyName = "ClaveCliente";
            this.claveClienteDataGridViewTextBoxColumn.Frozen = true;
            this.claveClienteDataGridViewTextBoxColumn.HeaderText = "ClaveCliente";
            this.claveClienteDataGridViewTextBoxColumn.Name = "claveClienteDataGridViewTextBoxColumn";
            this.claveClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.claveClienteDataGridViewTextBoxColumn.Width = 102;
            // 
            // nombreClienteDataGridViewTextBoxColumn
            // 
            this.nombreClienteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nombreClienteDataGridViewTextBoxColumn.DataPropertyName = "NombreCliente";
            this.nombreClienteDataGridViewTextBoxColumn.HeaderText = "NombreCliente";
            this.nombreClienteDataGridViewTextBoxColumn.Name = "nombreClienteDataGridViewTextBoxColumn";
            this.nombreClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreClienteDataGridViewTextBoxColumn.Width = 117;
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Cliente);
            // 
            // LoaderPicktureBox
            // 
            this.LoaderPicktureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LoaderPicktureBox.BackColor = System.Drawing.Color.Transparent;
            this.LoaderPicktureBox.Image = global::EstacionesPesaje.Properties.Resources.loading;
            this.LoaderPicktureBox.Location = new System.Drawing.Point(84, 181);
            this.LoaderPicktureBox.Name = "LoaderPicktureBox";
            this.LoaderPicktureBox.Size = new System.Drawing.Size(90, 90);
            this.LoaderPicktureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LoaderPicktureBox.TabIndex = 6;
            this.LoaderPicktureBox.TabStop = false;
            // 
            // CatalogoClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 434);
            this.Controls.Add(this.LoaderPicktureBox);
            this.Controls.Add(this.clienteKryptonDataGridView);
            this.Name = "CatalogoClientes";
            this.TabText = "Catalogo de Clientes";
            this.Text = "CatalogoClientes";
            this.Load += new System.EventHandler(this.CatalogoClientes_Load);
            this.Controls.SetChildIndex(this.clienteKryptonDataGridView, 0);
            this.Controls.SetChildIndex(this.LoaderPicktureBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.clienteKryptonDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoaderPicktureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource clienteBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView clienteKryptonDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn claveClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.PictureBox LoaderPicktureBox;
    }
}