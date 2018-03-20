namespace EstacionPesaje.Pages.MainPages {
	partial class MaquinasPage {
		/// <summary> 
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose ( bool disposing ) {
			if (disposing && ( components != null )) {
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Código generado por el Diseñador de componentes

		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent () {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaquinasPage));
			this.lineaBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
			this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.kryptonDataGridView2 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.TipoMaquina = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.nombreMaquinaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.velocidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tipoMaquinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.maquinasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.lineaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.lineaBindingNavigator)).BeginInit();
			this.lineaBindingNavigator.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
			this.kryptonGroupBox1.Panel.SuspendLayout();
			this.kryptonGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
			this.kryptonGroupBox2.Panel.SuspendLayout();
			this.kryptonGroupBox2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tipoMaquinaBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.maquinasBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// lineaBindingNavigator
			// 
			this.lineaBindingNavigator.AddNewItem = null;
			this.lineaBindingNavigator.BindingSource = this.lineaBindingSource;
			this.lineaBindingNavigator.CountItem = this.bindingNavigatorCountItem;
			this.lineaBindingNavigator.DeleteItem = null;
			this.lineaBindingNavigator.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lineaBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.lineaBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolStripSeparator1});
			this.lineaBindingNavigator.Location = new System.Drawing.Point(5, 5);
			this.lineaBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.lineaBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.lineaBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.lineaBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.lineaBindingNavigator.Name = "lineaBindingNavigator";
			this.lineaBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
			this.lineaBindingNavigator.Size = new System.Drawing.Size(662, 25);
			this.lineaBindingNavigator.TabIndex = 0;
			this.lineaBindingNavigator.Text = "bindingNavigator1";
			// 
			// bindingNavigatorCountItem
			// 
			this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
			this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
			this.bindingNavigatorCountItem.Text = "de {0}";
			this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
			// 
			// bindingNavigatorSeparator
			// 
			this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
			this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
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
			// bindingNavigatorSeparator2
			// 
			this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
			this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// kryptonDataGridView1
			// 
			this.kryptonDataGridView1.AllowUserToAddRows = false;
			this.kryptonDataGridView1.AllowUserToDeleteRows = false;
			this.kryptonDataGridView1.AllowUserToResizeRows = false;
			this.kryptonDataGridView1.AutoGenerateColumns = false;
			this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn});
			this.kryptonDataGridView1.DataSource = this.lineaBindingSource;
			this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonDataGridView1.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
			this.kryptonDataGridView1.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
			this.kryptonDataGridView1.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.kryptonDataGridView1.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.kryptonDataGridView1.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 0);
			this.kryptonDataGridView1.Name = "kryptonDataGridView1";
			this.kryptonDataGridView1.Size = new System.Drawing.Size(213, 434);
			this.kryptonDataGridView1.TabIndex = 1;
			// 
			// kryptonDataGridView2
			// 
			this.kryptonDataGridView2.AllowUserToAddRows = false;
			this.kryptonDataGridView2.AllowUserToDeleteRows = false;
			this.kryptonDataGridView2.AllowUserToResizeRows = false;
			this.kryptonDataGridView2.AutoGenerateColumns = false;
			this.kryptonDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.kryptonDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreMaquinaDataGridViewTextBoxColumn,
            this.velocidadDataGridViewTextBoxColumn,
            this.TipoMaquina});
			this.kryptonDataGridView2.DataSource = this.maquinasBindingSource;
			this.kryptonDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonDataGridView2.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
			this.kryptonDataGridView2.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
			this.kryptonDataGridView2.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.kryptonDataGridView2.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.kryptonDataGridView2.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.kryptonDataGridView2.Location = new System.Drawing.Point(0, 0);
			this.kryptonDataGridView2.Name = "kryptonDataGridView2";
			this.kryptonDataGridView2.Size = new System.Drawing.Size(427, 434);
			this.kryptonDataGridView2.TabIndex = 2;
			// 
			// TipoMaquina
			// 
			this.TipoMaquina.DataPropertyName = "TipoMaquina_Id";
			this.TipoMaquina.DataSource = this.tipoMaquinaBindingSource;
			this.TipoMaquina.DisplayMember = "Tipo_Maquina";
			this.TipoMaquina.HeaderText = "TipoMaquina";
			this.TipoMaquina.Name = "TipoMaquina";
			this.TipoMaquina.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.TipoMaquina.ValueMember = "Id";
			// 
			// kryptonGroupBox1
			// 
			this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonGroupBox1.Location = new System.Drawing.Point(3, 3);
			this.kryptonGroupBox1.Name = "kryptonGroupBox1";
			// 
			// kryptonGroupBox1.Panel
			// 
			this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonDataGridView1);
			this.kryptonGroupBox1.Size = new System.Drawing.Size(217, 458);
			this.kryptonGroupBox1.TabIndex = 3;
			this.kryptonGroupBox1.Values.Heading = "Lineas";
			// 
			// kryptonGroupBox2
			// 
			this.kryptonGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonGroupBox2.Location = new System.Drawing.Point(228, 3);
			this.kryptonGroupBox2.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
			this.kryptonGroupBox2.Name = "kryptonGroupBox2";
			// 
			// kryptonGroupBox2.Panel
			// 
			this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonDataGridView2);
			this.kryptonGroupBox2.Size = new System.Drawing.Size(431, 458);
			this.kryptonGroupBox2.TabIndex = 4;
			this.kryptonGroupBox2.Values.Heading = "Maquinas";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 223F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.kryptonGroupBox2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.kryptonGroupBox1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 30);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(662, 464);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// nombreMaquinaDataGridViewTextBoxColumn
			// 
			this.nombreMaquinaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.nombreMaquinaDataGridViewTextBoxColumn.DataPropertyName = "NombreMaquina";
			this.nombreMaquinaDataGridViewTextBoxColumn.HeaderText = "NombreMaquina";
			this.nombreMaquinaDataGridViewTextBoxColumn.Name = "nombreMaquinaDataGridViewTextBoxColumn";
			// 
			// velocidadDataGridViewTextBoxColumn
			// 
			this.velocidadDataGridViewTextBoxColumn.DataPropertyName = "Velocidad";
			this.velocidadDataGridViewTextBoxColumn.HeaderText = "Velocidad";
			this.velocidadDataGridViewTextBoxColumn.Name = "velocidadDataGridViewTextBoxColumn";
			// 
			// tipoMaquinaBindingSource
			// 
			this.tipoMaquinaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.TipoMaquina);
			// 
			// maquinasBindingSource
			// 
			this.maquinasBindingSource.DataMember = "Maquinas";
			this.maquinasBindingSource.DataSource = this.lineaBindingSource;
			// 
			// lineaBindingSource
			// 
			this.lineaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Linea);
			// 
			// nombreDataGridViewTextBoxColumn
			// 
			this.nombreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
			this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
			this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
			// 
			// bindingNavigatorMoveFirstItem
			// 
			this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
			this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
			this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
			// 
			// bindingNavigatorMovePreviousItem
			// 
			this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
			this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
			this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
			// 
			// bindingNavigatorMoveNextItem
			// 
			this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
			this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
			this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
			// 
			// bindingNavigatorMoveLastItem
			// 
			this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
			this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
			this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveLastItem.Text = "Mover último";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.Image = global::EstacionPesaje.Properties.Resources.item_disable;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(92, 22);
			this.toolStripButton2.Text = "Nueva Linea";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Image = global::EstacionPesaje.Properties.Resources.gear1;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(111, 22);
			this.toolStripButton1.Text = "Nueva Maquina";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// MaquinasPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.lineaBindingNavigator);
			this.Name = "MaquinasPage";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.PageDescriptionText = "";
			this.PageTitleText = "Lineas y Maquinas";
			this.Size = new System.Drawing.Size(672, 499);
			this.Load += new System.EventHandler(this.MaquinasPage_Load);
			((System.ComponentModel.ISupportInitialize)(this.lineaBindingNavigator)).EndInit();
			this.lineaBindingNavigator.ResumeLayout(false);
			this.lineaBindingNavigator.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
			this.kryptonGroupBox1.Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
			this.kryptonGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
			this.kryptonGroupBox2.Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
			this.kryptonGroupBox2.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tipoMaquinaBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.maquinasBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lineaBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.BindingSource lineaBindingSource;
		private System.Windows.Forms.BindingNavigator lineaBindingNavigator;
		private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
		private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
		private System.Windows.Forms.BindingSource maquinasBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView2;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
		private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource tipoMaquinaBindingSource;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.DataGridViewTextBoxColumn nombreMaquinaDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn velocidadDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewComboBoxColumn TipoMaquina;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}
