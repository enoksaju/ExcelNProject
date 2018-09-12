namespace ControlResiduosPeligrosos.Catalogos
{
  partial class frmProveedores
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
			ComponentFactory.Krypton.Toolkit.KryptonLabel denominacionLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel domicilioLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel estadoLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel municipioLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel cPLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel autSEMARNATLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedores));
			this.proveedorBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
			this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
			this.proveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.cancelToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.proveedorBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.autSEMARNATKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.cPKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.municipioKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.estadoKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.domicilioKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.denominacionKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.denominacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.domicilioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.municipioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.autSEMARNATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			denominacionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			domicilioLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			estadoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			municipioLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			cPLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			autSEMARNATLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			((System.ComponentModel.ISupportInitialize)(this.proveedorBindingNavigator)).BeginInit();
			this.proveedorBindingNavigator.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// denominacionLabel
			// 
			denominacionLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			denominacionLabel.Location = new System.Drawing.Point(10, 18);
			denominacionLabel.Name = "denominacionLabel";
			denominacionLabel.Size = new System.Drawing.Size(98, 20);
			denominacionLabel.TabIndex = 0;
			denominacionLabel.Values.Text = "Denominacion:";
			// 
			// domicilioLabel
			// 
			domicilioLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			domicilioLabel.Location = new System.Drawing.Point(39, 73);
			domicilioLabel.Name = "domicilioLabel";
			domicilioLabel.Size = new System.Drawing.Size(69, 20);
			domicilioLabel.TabIndex = 2;
			domicilioLabel.Values.Text = "Domicilio:";
			// 
			// estadoLabel
			// 
			estadoLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			estadoLabel.Location = new System.Drawing.Point(55, 131);
			estadoLabel.Name = "estadoLabel";
			estadoLabel.Size = new System.Drawing.Size(53, 20);
			estadoLabel.TabIndex = 4;
			estadoLabel.Values.Text = "Estado:";
			// 
			// municipioLabel
			// 
			municipioLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			municipioLabel.Location = new System.Drawing.Point(341, 111);
			municipioLabel.Name = "municipioLabel";
			municipioLabel.Size = new System.Drawing.Size(72, 20);
			municipioLabel.TabIndex = 6;
			municipioLabel.Values.Text = "Municipio:";
			// 
			// cPLabel
			// 
			cPLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			cPLabel.Location = new System.Drawing.Point(79, 102);
			cPLabel.Name = "cPLabel";
			cPLabel.Size = new System.Drawing.Size(29, 20);
			cPLabel.TabIndex = 8;
			cPLabel.Values.Text = "CP:";
			// 
			// autSEMARNATLabel
			// 
			autSEMARNATLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			autSEMARNATLabel.Location = new System.Drawing.Point(2, 47);
			autSEMARNATLabel.Name = "autSEMARNATLabel";
			autSEMARNATLabel.Size = new System.Drawing.Size(106, 20);
			autSEMARNATLabel.TabIndex = 10;
			autSEMARNATLabel.Values.Text = "Aut SEMARNAT:";
			// 
			// proveedorBindingNavigator
			// 
			this.proveedorBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
			this.proveedorBindingNavigator.BindingSource = this.proveedorBindingSource;
			this.proveedorBindingNavigator.CountItem = this.bindingNavigatorCountItem;
			this.proveedorBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
			this.proveedorBindingNavigator.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.proveedorBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.proveedorBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorAddNewItem,
            this.editToolStripButton,
            this.cancelToolStripButton,
            this.proveedorBindingNavigatorSaveItem,
            this.toolStripSeparator1,
            this.bindingNavigatorDeleteItem});
			this.proveedorBindingNavigator.Location = new System.Drawing.Point(0, 0);
			this.proveedorBindingNavigator.MoveFirstItem = null;
			this.proveedorBindingNavigator.MoveLastItem = null;
			this.proveedorBindingNavigator.MoveNextItem = null;
			this.proveedorBindingNavigator.MovePreviousItem = null;
			this.proveedorBindingNavigator.Name = "proveedorBindingNavigator";
			this.proveedorBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
			this.proveedorBindingNavigator.Size = new System.Drawing.Size(667, 25);
			this.proveedorBindingNavigator.TabIndex = 0;
			this.proveedorBindingNavigator.Text = "bindingNavigator1";
			// 
			// bindingNavigatorAddNewItem
			// 
			this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
			this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
			this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorAddNewItem.Text = "Agregar nuevo";
			this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
			// 
			// proveedorBindingSource
			// 
			this.proveedorBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Proveedor);
			// 
			// bindingNavigatorCountItem
			// 
			this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
			this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
			this.bindingNavigatorCountItem.Text = "de {0}";
			this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
			// 
			// bindingNavigatorDeleteItem
			// 
			this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
			this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
			this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorDeleteItem.Text = "Eliminar";
			// 
			// bindingNavigatorPositionItem
			// 
			this.bindingNavigatorPositionItem.AccessibleName = "Posición";
			this.bindingNavigatorPositionItem.AutoSize = false;
			this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
			this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
			this.bindingNavigatorPositionItem.Text = "0";
			this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
			// 
			// bindingNavigatorSeparator1
			// 
			this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
			this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// editToolStripButton
			// 
			this.editToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.editToolStripButton.Image = global::ControlResiduosPeligrosos.Properties.Resources.table_edit;
			this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.editToolStripButton.Name = "editToolStripButton";
			this.editToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.editToolStripButton.Text = "Editar Elemento";
			this.editToolStripButton.ToolTipText = "Editar Elemento";
			this.editToolStripButton.Click += new System.EventHandler(this.editToolStripButton_Click);
			// 
			// cancelToolStripButton
			// 
			this.cancelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cancelToolStripButton.Image = global::ControlResiduosPeligrosos.Properties.Resources.cancel;
			this.cancelToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cancelToolStripButton.Name = "cancelToolStripButton";
			this.cancelToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.cancelToolStripButton.Text = "Cancelar Edición";
			this.cancelToolStripButton.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// proveedorBindingNavigatorSaveItem
			// 
			this.proveedorBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.proveedorBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("proveedorBindingNavigatorSaveItem.Image")));
			this.proveedorBindingNavigatorSaveItem.Name = "proveedorBindingNavigatorSaveItem";
			this.proveedorBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
			this.proveedorBindingNavigatorSaveItem.Text = "Guardar datos";
			this.proveedorBindingNavigatorSaveItem.Click += new System.EventHandler(this.proveedorBindingNavigatorSaveItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(autSEMARNATLabel);
			this.kryptonPanel1.Controls.Add(this.autSEMARNATKryptonTextBox);
			this.kryptonPanel1.Controls.Add(cPLabel);
			this.kryptonPanel1.Controls.Add(this.cPKryptonTextBox);
			this.kryptonPanel1.Controls.Add(municipioLabel);
			this.kryptonPanel1.Controls.Add(this.municipioKryptonTextBox);
			this.kryptonPanel1.Controls.Add(estadoLabel);
			this.kryptonPanel1.Controls.Add(this.estadoKryptonTextBox);
			this.kryptonPanel1.Controls.Add(domicilioLabel);
			this.kryptonPanel1.Controls.Add(this.domicilioKryptonTextBox);
			this.kryptonPanel1.Controls.Add(denominacionLabel);
			this.kryptonPanel1.Controls.Add(this.denominacionKryptonTextBox);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 268);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(667, 177);
			this.kryptonPanel1.TabIndex = 2;
			// 
			// autSEMARNATKryptonTextBox
			// 
			this.autSEMARNATKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "AutSEMARNAT", true));
			this.autSEMARNATKryptonTextBox.Location = new System.Drawing.Point(114, 44);
			this.autSEMARNATKryptonTextBox.Name = "autSEMARNATKryptonTextBox";
			this.autSEMARNATKryptonTextBox.Size = new System.Drawing.Size(181, 23);
			this.autSEMARNATKryptonTextBox.TabIndex = 2;
			this.autSEMARNATKryptonTextBox.Text = "kryptonTextBox1";
			// 
			// cPKryptonTextBox
			// 
			this.cPKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "CP", true));
			this.cPKryptonTextBox.Location = new System.Drawing.Point(114, 102);
			this.cPKryptonTextBox.Name = "cPKryptonTextBox";
			this.cPKryptonTextBox.Size = new System.Drawing.Size(181, 23);
			this.cPKryptonTextBox.TabIndex = 4;
			this.cPKryptonTextBox.Text = "kryptonTextBox1";
			// 
			// municipioKryptonTextBox
			// 
			this.municipioKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "Municipio", true));
			this.municipioKryptonTextBox.Location = new System.Drawing.Point(416, 108);
			this.municipioKryptonTextBox.Name = "municipioKryptonTextBox";
			this.municipioKryptonTextBox.Size = new System.Drawing.Size(183, 23);
			this.municipioKryptonTextBox.TabIndex = 5;
			this.municipioKryptonTextBox.Text = "kryptonTextBox1";
			// 
			// estadoKryptonTextBox
			// 
			this.estadoKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "Estado", true));
			this.estadoKryptonTextBox.Location = new System.Drawing.Point(114, 131);
			this.estadoKryptonTextBox.Name = "estadoKryptonTextBox";
			this.estadoKryptonTextBox.Size = new System.Drawing.Size(181, 23);
			this.estadoKryptonTextBox.TabIndex = 6;
			this.estadoKryptonTextBox.Text = "kryptonTextBox1";
			// 
			// domicilioKryptonTextBox
			// 
			this.domicilioKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "Domicilio", true));
			this.domicilioKryptonTextBox.Location = new System.Drawing.Point(114, 73);
			this.domicilioKryptonTextBox.Name = "domicilioKryptonTextBox";
			this.domicilioKryptonTextBox.Size = new System.Drawing.Size(485, 23);
			this.domicilioKryptonTextBox.TabIndex = 3;
			this.domicilioKryptonTextBox.Text = "kryptonTextBox1";
			// 
			// denominacionKryptonTextBox
			// 
			this.denominacionKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "Denominacion", true));
			this.denominacionKryptonTextBox.Location = new System.Drawing.Point(114, 15);
			this.denominacionKryptonTextBox.Name = "denominacionKryptonTextBox";
			this.denominacionKryptonTextBox.Size = new System.Drawing.Size(181, 23);
			this.denominacionKryptonTextBox.TabIndex = 1;
			this.denominacionKryptonTextBox.Text = "kryptonTextBox1";
			// 
			// kryptonDataGridView1
			// 
			this.kryptonDataGridView1.AllowUserToAddRows = false;
			this.kryptonDataGridView1.AllowUserToDeleteRows = false;
			this.kryptonDataGridView1.AutoGenerateColumns = false;
			this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.denominacionDataGridViewTextBoxColumn,
            this.domicilioDataGridViewTextBoxColumn,
            this.municipioDataGridViewTextBoxColumn,
            this.cPDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.autSEMARNATDataGridViewTextBoxColumn});
			this.kryptonDataGridView1.DataSource = this.proveedorBindingSource;
			this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 25);
			this.kryptonDataGridView1.Name = "kryptonDataGridView1";
			this.kryptonDataGridView1.ReadOnly = true;
			this.kryptonDataGridView1.Size = new System.Drawing.Size(667, 243);
			this.kryptonDataGridView1.TabIndex = 3;
			// 
			// denominacionDataGridViewTextBoxColumn
			// 
			this.denominacionDataGridViewTextBoxColumn.DataPropertyName = "Denominacion";
			this.denominacionDataGridViewTextBoxColumn.HeaderText = "Denominacion";
			this.denominacionDataGridViewTextBoxColumn.Name = "denominacionDataGridViewTextBoxColumn";
			this.denominacionDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// domicilioDataGridViewTextBoxColumn
			// 
			this.domicilioDataGridViewTextBoxColumn.DataPropertyName = "Domicilio";
			this.domicilioDataGridViewTextBoxColumn.HeaderText = "Domicilio";
			this.domicilioDataGridViewTextBoxColumn.Name = "domicilioDataGridViewTextBoxColumn";
			this.domicilioDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// municipioDataGridViewTextBoxColumn
			// 
			this.municipioDataGridViewTextBoxColumn.DataPropertyName = "Municipio";
			this.municipioDataGridViewTextBoxColumn.HeaderText = "Municipio";
			this.municipioDataGridViewTextBoxColumn.Name = "municipioDataGridViewTextBoxColumn";
			this.municipioDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// cPDataGridViewTextBoxColumn
			// 
			this.cPDataGridViewTextBoxColumn.DataPropertyName = "CP";
			this.cPDataGridViewTextBoxColumn.HeaderText = "CP";
			this.cPDataGridViewTextBoxColumn.Name = "cPDataGridViewTextBoxColumn";
			this.cPDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// estadoDataGridViewTextBoxColumn
			// 
			this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
			this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
			this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
			this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// autSEMARNATDataGridViewTextBoxColumn
			// 
			this.autSEMARNATDataGridViewTextBoxColumn.DataPropertyName = "AutSEMARNAT";
			this.autSEMARNATDataGridViewTextBoxColumn.HeaderText = "AutSEMARNAT";
			this.autSEMARNATDataGridViewTextBoxColumn.Name = "autSEMARNATDataGridViewTextBoxColumn";
			this.autSEMARNATDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// frmProveedores
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(667, 445);
			this.Controls.Add(this.kryptonDataGridView1);
			this.Controls.Add(this.proveedorBindingNavigator);
			this.Controls.Add(this.kryptonPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmProveedores";
			this.Text = "Catalogo Proveedores";
			this.Load += new System.EventHandler(this.frmProveedores_Load);
			((System.ComponentModel.ISupportInitialize)(this.proveedorBindingNavigator)).EndInit();
			this.proveedorBindingNavigator.ResumeLayout(false);
			this.proveedorBindingNavigator.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.BindingSource proveedorBindingSource;
    private System.Windows.Forms.BindingNavigator proveedorBindingNavigator;
    private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
    private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
    private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
    private System.Windows.Forms.ToolStripButton proveedorBindingNavigatorSaveItem;
    private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox cPKryptonTextBox;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox municipioKryptonTextBox;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox estadoKryptonTextBox;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox domicilioKryptonTextBox;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox denominacionKryptonTextBox;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox autSEMARNATKryptonTextBox;
		private System.Windows.Forms.ToolStripButton editToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton cancelToolStripButton;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn denominacionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn domicilioDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn municipioDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn cPDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn autSEMARNATDataGridViewTextBoxColumn;
	}
}