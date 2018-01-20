namespace tryEntity
{
    partial class frmListaMateriales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaMateriales));
            this.materialesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.familiaMaterialesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.familiaMaterialesListBox = new System.Windows.Forms.ListBox();
            this.materialesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddFam = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.materialesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.familiaMaterialesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialesBindingSource
            // 
            this.materialesBindingSource.DataMember = "Materiales";
            this.materialesBindingSource.DataSource = this.familiaMaterialesBindingSource;
            // 
            // familiaMaterialesBindingSource
            // 
            this.familiaMaterialesBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.FamiliaMateriales);
            // 
            // familiaMaterialesListBox
            // 
            this.familiaMaterialesListBox.DataSource = this.familiaMaterialesBindingSource;
            this.familiaMaterialesListBox.DisplayMember = "NombreFamilia";
            this.familiaMaterialesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.familiaMaterialesListBox.FormattingEnabled = true;
            this.familiaMaterialesListBox.Location = new System.Drawing.Point(0, 13);
            this.familiaMaterialesListBox.Name = "familiaMaterialesListBox";
            this.familiaMaterialesListBox.Size = new System.Drawing.Size(165, 394);
            this.familiaMaterialesListBox.TabIndex = 7;
            this.familiaMaterialesListBox.ValueMember = "Id";
            // 
            // materialesDataGridView
            // 
            this.materialesDataGridView.AllowUserToAddRows = false;
            this.materialesDataGridView.AllowUserToDeleteRows = false;
            this.materialesDataGridView.AutoGenerateColumns = false;
            this.materialesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4});
            this.materialesDataGridView.DataSource = this.materialesBindingSource;
            this.materialesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialesDataGridView.Location = new System.Drawing.Point(0, 13);
            this.materialesDataGridView.Name = "materialesDataGridView";
            this.materialesDataGridView.ReadOnly = true;
            this.materialesDataGridView.Size = new System.Drawing.Size(405, 419);
            this.materialesDataGridView.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Apariencia";
            this.dataGridViewTextBoxColumn3.HeaderText = "Apariencia";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Formula";
            this.dataGridViewTextBoxColumn2.HeaderText = "Formula";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Densidad";
            this.dataGridViewTextBoxColumn4.HeaderText = "Densidad";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(10, 10);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.familiaMaterialesListBox);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.materialesDataGridView);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(574, 432);
            this.splitContainer1.SplitterDistance = 165;
            this.splitContainer1.TabIndex = 8;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddFam,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 407);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(165, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddFam
            // 
            this.btnAddFam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddFam.Image = global::tryEntity.Properties.Resources.plus;
            this.btnAddFam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddFam.Name = "btnAddFam";
            this.btnAddFam.Size = new System.Drawing.Size(23, 22);
            this.btnAddFam.Text = "Agregar Familia";
            this.btnAddFam.Click += new System.EventHandler(this.btnAddFam_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::tryEntity.Properties.Resources.pencil;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Editar Familia";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::tryEntity.Properties.Resources.delete;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Eliminar Familia";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Familias de Materiales:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Materiales:";
            // 
            // frmListaMateriales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 452);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaMateriales";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Lista de Materiales";
            this.Load += new System.EventHandler(this.frmListaMateriales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.materialesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.familiaMaterialesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialesDataGridView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource familiaMaterialesBindingSource;
        private System.Windows.Forms.BindingSource materialesBindingSource;
        private System.Windows.Forms.ListBox familiaMaterialesListBox;
        private System.Windows.Forms.DataGridView materialesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddFam;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}