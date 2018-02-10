namespace ControlProduccion.Catalogos
{
    partial class MaterialesCatalogoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialesCatalogoForm));
            this.familiaMaterialesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materialesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.AgregarFamiliaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.EditarFamiliaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EliminarFamiliaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.kryptonListBox1 = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.materialesKryptonDataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.familiaMaterialesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialesBindingSource)).BeginInit();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialesKryptonDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // familiaMaterialesBindingSource
            // 
            this.familiaMaterialesBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.FamiliaMateriales);
            // 
            // materialesBindingSource
            // 
            this.materialesBindingSource.DataMember = "Materiales";
            this.materialesBindingSource.DataSource = this.familiaMaterialesBindingSource;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgregarFamiliaToolStripButton,
            this.toolStripSeparator1,
            this.EditarFamiliaToolStripButton,
            this.EliminarFamiliaToolStripButton});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(123, 25);
            this.toolStrip3.TabIndex = 4;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // AgregarFamiliaToolStripButton
            // 
            this.AgregarFamiliaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AgregarFamiliaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AgregarFamiliaToolStripButton.Image")));
            this.AgregarFamiliaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AgregarFamiliaToolStripButton.Name = "AgregarFamiliaToolStripButton";
            this.AgregarFamiliaToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.AgregarFamiliaToolStripButton.Text = "Agregar Familia";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // EditarFamiliaToolStripButton
            // 
            this.EditarFamiliaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditarFamiliaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EditarFamiliaToolStripButton.Image")));
            this.EditarFamiliaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditarFamiliaToolStripButton.Name = "EditarFamiliaToolStripButton";
            this.EditarFamiliaToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.EditarFamiliaToolStripButton.Text = "Editar Familia";
            // 
            // EliminarFamiliaToolStripButton
            // 
            this.EliminarFamiliaToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.EliminarFamiliaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EliminarFamiliaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EliminarFamiliaToolStripButton.Image")));
            this.EliminarFamiliaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EliminarFamiliaToolStripButton.Name = "EliminarFamiliaToolStripButton";
            this.EliminarFamiliaToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.EliminarFamiliaToolStripButton.Text = "Eliminar Familia";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.kryptonListBox1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.materialesKryptonDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(331, 459);
            this.splitContainer1.SplitterDistance = 123;
            this.splitContainer1.TabIndex = 5;
            // 
            // kryptonListBox1
            // 
            this.kryptonListBox1.DataSource = this.familiaMaterialesBindingSource;
            this.kryptonListBox1.DisplayMember = "NombreFamilia";
            this.kryptonListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonListBox1.Location = new System.Drawing.Point(0, 25);
            this.kryptonListBox1.Name = "kryptonListBox1";
            this.kryptonListBox1.Size = new System.Drawing.Size(123, 434);
            this.kryptonListBox1.TabIndex = 5;
            this.kryptonListBox1.ValueMember = "Id";
            // 
            // materialesKryptonDataGridView
            // 
            this.materialesKryptonDataGridView.AllowUserToAddRows = false;
            this.materialesKryptonDataGridView.AllowUserToDeleteRows = false;
            this.materialesKryptonDataGridView.AutoGenerateColumns = false;
            this.materialesKryptonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialesKryptonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7});
            this.materialesKryptonDataGridView.DataSource = this.materialesBindingSource;
            this.materialesKryptonDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialesKryptonDataGridView.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.materialesKryptonDataGridView.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.materialesKryptonDataGridView.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.materialesKryptonDataGridView.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.materialesKryptonDataGridView.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.materialesKryptonDataGridView.Location = new System.Drawing.Point(0, 0);
            this.materialesKryptonDataGridView.MultiSelect = false;
            this.materialesKryptonDataGridView.Name = "materialesKryptonDataGridView";
            this.materialesKryptonDataGridView.ReadOnly = true;
            this.materialesKryptonDataGridView.RowHeadersVisible = false;
            this.materialesKryptonDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.materialesKryptonDataGridView.Size = new System.Drawing.Size(204, 459);
            this.materialesKryptonDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Apariencia";
            this.dataGridViewTextBoxColumn6.Frozen = true;
            this.dataGridViewTextBoxColumn6.HeaderText = "Apariencia";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Formula";
            this.dataGridViewTextBoxColumn5.HeaderText = "Formula";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Densidad";
            this.dataGridViewTextBoxColumn7.HeaderText = "Densidad";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Formula";
            this.dataGridViewTextBoxColumn2.HeaderText = "Formula";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Apariencia";
            this.dataGridViewTextBoxColumn3.HeaderText = "Apariencia";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Densidad";
            this.dataGridViewTextBoxColumn4.HeaderText = "Densidad";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // MaterialesCatalogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 509);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MaterialesCatalogoForm";
            this.TabText = "Catalogo de Materiales";
            this.Text = "Catalogo de Materiales";
            this.Load += new System.EventHandler(this.MaterialesCatalogoForm_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.familiaMaterialesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialesBindingSource)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.materialesKryptonDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource familiaMaterialesBindingSource;
        private System.Windows.Forms.BindingSource materialesBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton AgregarFamiliaToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton EditarFamiliaToolStripButton;
        private System.Windows.Forms.ToolStripButton EliminarFamiliaToolStripButton;
        private System.Windows.Forms.SplitContainer splitContainer1;       
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView materialesKryptonDataGridView;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox kryptonListBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}