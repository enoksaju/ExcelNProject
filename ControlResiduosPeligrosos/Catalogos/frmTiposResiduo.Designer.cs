namespace ControlResiduosPeligrosos.Catalogos
{
  partial class frmTiposResiduo
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
			ComponentFactory.Krypton.Toolkit.KryptonLabel descripcionLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel riesgoLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel unidadLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTiposResiduo));
			this.tipoRPBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tipoRPBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
			this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.cancelToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.tipoRPBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tipoRPKryptonDataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.unidadKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.riesgoKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.descripcionKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			descripcionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			riesgoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			unidadLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			((System.ComponentModel.ISupportInitialize)(this.tipoRPBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tipoRPBindingNavigator)).BeginInit();
			this.tipoRPBindingNavigator.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tipoRPKryptonDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.unidadKryptonComboBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riesgoKryptonComboBox)).BeginInit();
			this.SuspendLayout();
			// 
			// descripcionLabel
			// 
			descripcionLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			descripcionLabel.Location = new System.Drawing.Point(9, 17);
			descripcionLabel.Name = "descripcionLabel";
			descripcionLabel.Size = new System.Drawing.Size(82, 20);
			descripcionLabel.TabIndex = 0;
			descripcionLabel.Values.Text = "Descripcion:";
			// 
			// riesgoLabel
			// 
			riesgoLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			riesgoLabel.Location = new System.Drawing.Point(36, 46);
			riesgoLabel.Name = "riesgoLabel";
			riesgoLabel.Size = new System.Drawing.Size(53, 20);
			riesgoLabel.TabIndex = 2;
			riesgoLabel.Values.Text = "Riesgo:";
			// 
			// unidadLabel
			// 
			unidadLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
			unidadLabel.Location = new System.Drawing.Point(34, 73);
			unidadLabel.Name = "unidadLabel";
			unidadLabel.Size = new System.Drawing.Size(56, 20);
			unidadLabel.TabIndex = 4;
			unidadLabel.Values.Text = "Unidad:";
			// 
			// tipoRPBindingSource
			// 
			this.tipoRPBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.TipoRP);
			// 
			// tipoRPBindingNavigator
			// 
			this.tipoRPBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
			this.tipoRPBindingNavigator.BindingSource = this.tipoRPBindingSource;
			this.tipoRPBindingNavigator.CountItem = this.bindingNavigatorCountItem;
			this.tipoRPBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
			this.tipoRPBindingNavigator.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.tipoRPBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tipoRPBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorAddNewItem,
            this.editToolStripButton,
            this.cancelToolStripButton,
            this.tipoRPBindingNavigatorSaveItem,
            this.toolStripSeparator1,
            this.bindingNavigatorDeleteItem});
			this.tipoRPBindingNavigator.Location = new System.Drawing.Point(0, 0);
			this.tipoRPBindingNavigator.MoveFirstItem = null;
			this.tipoRPBindingNavigator.MoveLastItem = null;
			this.tipoRPBindingNavigator.MoveNextItem = null;
			this.tipoRPBindingNavigator.MovePreviousItem = null;
			this.tipoRPBindingNavigator.Name = "tipoRPBindingNavigator";
			this.tipoRPBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
			this.tipoRPBindingNavigator.Size = new System.Drawing.Size(591, 25);
			this.tipoRPBindingNavigator.TabIndex = 0;
			this.tipoRPBindingNavigator.Text = "bindingNavigator1";
			// 
			// bindingNavigatorAddNewItem
			// 
			this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
			this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
			this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorAddNewItem.Text = "Agregar nuevo";
			this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.isAdding_Click);
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
			this.editToolStripButton.Click += new System.EventHandler(this.isAdding_Click);
			// 
			// cancelToolStripButton
			// 
			this.cancelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cancelToolStripButton.Image = global::ControlResiduosPeligrosos.Properties.Resources.cancel;
			this.cancelToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cancelToolStripButton.Name = "cancelToolStripButton";
			this.cancelToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.cancelToolStripButton.Text = "Cancelar Edición";
			this.cancelToolStripButton.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// tipoRPBindingNavigatorSaveItem
			// 
			this.tipoRPBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tipoRPBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tipoRPBindingNavigatorSaveItem.Image")));
			this.tipoRPBindingNavigatorSaveItem.Name = "tipoRPBindingNavigatorSaveItem";
			this.tipoRPBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
			this.tipoRPBindingNavigatorSaveItem.Text = "Guardar datos";
			this.tipoRPBindingNavigatorSaveItem.Click += new System.EventHandler(this.tipoRPBindingNavigatorSaveItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tipoRPKryptonDataGridView
			// 
			this.tipoRPKryptonDataGridView.AllowUserToAddRows = false;
			this.tipoRPKryptonDataGridView.AllowUserToDeleteRows = false;
			this.tipoRPKryptonDataGridView.AutoGenerateColumns = false;
			this.tipoRPKryptonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tipoRPKryptonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
			this.tipoRPKryptonDataGridView.DataSource = this.tipoRPBindingSource;
			this.tipoRPKryptonDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tipoRPKryptonDataGridView.Location = new System.Drawing.Point(0, 25);
			this.tipoRPKryptonDataGridView.Name = "tipoRPKryptonDataGridView";
			this.tipoRPKryptonDataGridView.ReadOnly = true;
			this.tipoRPKryptonDataGridView.Size = new System.Drawing.Size(591, 219);
			this.tipoRPKryptonDataGridView.TabIndex = 1;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Descripcion";
			this.dataGridViewTextBoxColumn2.HeaderText = "Descripcion";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "Riesgo";
			this.dataGridViewTextBoxColumn3.HeaderText = "Riesgo";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "Unidad";
			this.dataGridViewTextBoxColumn4.HeaderText = "Unidad";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(unidadLabel);
			this.kryptonPanel1.Controls.Add(this.unidadKryptonComboBox);
			this.kryptonPanel1.Controls.Add(riesgoLabel);
			this.kryptonPanel1.Controls.Add(this.riesgoKryptonComboBox);
			this.kryptonPanel1.Controls.Add(descripcionLabel);
			this.kryptonPanel1.Controls.Add(this.descripcionKryptonTextBox);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 244);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(591, 121);
			this.kryptonPanel1.TabIndex = 2;
			// 
			// unidadKryptonComboBox
			// 
			this.unidadKryptonComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tipoRPBindingSource, "Unidad", true));
			this.unidadKryptonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.unidadKryptonComboBox.DropDownWidth = 227;
			this.unidadKryptonComboBox.Location = new System.Drawing.Point(92, 73);
			this.unidadKryptonComboBox.Name = "unidadKryptonComboBox";
			this.unidadKryptonComboBox.Size = new System.Drawing.Size(227, 21);
			this.unidadKryptonComboBox.TabIndex = 3;
			// 
			// riesgoKryptonComboBox
			// 
			this.riesgoKryptonComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tipoRPBindingSource, "Riesgo", true));
			this.riesgoKryptonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.riesgoKryptonComboBox.DropDownWidth = 227;
			this.riesgoKryptonComboBox.Location = new System.Drawing.Point(92, 46);
			this.riesgoKryptonComboBox.Name = "riesgoKryptonComboBox";
			this.riesgoKryptonComboBox.Size = new System.Drawing.Size(227, 21);
			this.riesgoKryptonComboBox.TabIndex = 3;
			// 
			// descripcionKryptonTextBox
			// 
			this.descripcionKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tipoRPBindingSource, "Descripcion", true));
			this.descripcionKryptonTextBox.Location = new System.Drawing.Point(92, 17);
			this.descripcionKryptonTextBox.Name = "descripcionKryptonTextBox";
			this.descripcionKryptonTextBox.Size = new System.Drawing.Size(453, 23);
			this.descripcionKryptonTextBox.TabIndex = 1;
			this.descripcionKryptonTextBox.Text = "kryptonTextBox1";
			// 
			// frmTiposResiduo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(591, 365);
			this.Controls.Add(this.tipoRPKryptonDataGridView);
			this.Controls.Add(this.tipoRPBindingNavigator);
			this.Controls.Add(this.kryptonPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmTiposResiduo";
			this.Text = "Catalogo Tipos Residuo";
			this.Load += new System.EventHandler(this.frmTiposResiduo_Load);
			((System.ComponentModel.ISupportInitialize)(this.tipoRPBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tipoRPBindingNavigator)).EndInit();
			this.tipoRPBindingNavigator.ResumeLayout(false);
			this.tipoRPBindingNavigator.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tipoRPKryptonDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.unidadKryptonComboBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riesgoKryptonComboBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.BindingSource tipoRPBindingSource;
    private System.Windows.Forms.BindingNavigator tipoRPBindingNavigator;
    private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
    private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
    private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
    private System.Windows.Forms.ToolStripButton tipoRPBindingNavigatorSaveItem;
    private ComponentFactory.Krypton.Toolkit.KryptonDataGridView tipoRPKryptonDataGridView;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
    private ComponentFactory.Krypton.Toolkit.KryptonComboBox unidadKryptonComboBox;
    private ComponentFactory.Krypton.Toolkit.KryptonComboBox riesgoKryptonComboBox;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox descripcionKryptonTextBox;
		private System.Windows.Forms.ToolStripButton editToolStripButton;
		private System.Windows.Forms.ToolStripButton cancelToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}