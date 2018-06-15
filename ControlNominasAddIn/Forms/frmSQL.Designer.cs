namespace ControlNominasAddIn.Forms {
	partial class frmSQL {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( ) {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSQL));
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
			this.tvSchema = new ComponentFactory.Krypton.Toolkit.KryptonTreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.nuevoToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.abrirToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.guardarToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.cmbSchemas = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnExecute = new System.Windows.Forms.ToolStripButton();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ejecutarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
			this.kryptonSplitContainer1.Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
			this.kryptonSplitContainer1.Panel2.SuspendLayout();
			this.kryptonSplitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
			this.kryptonNavigator1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.kryptonSplitContainer1);
			this.kryptonPanel1.Controls.Add(this.toolStrip1);
			this.kryptonPanel1.Controls.Add(this.menuStrip1);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(711, 410);
			this.kryptonPanel1.TabIndex = 1;
			// 
			// kryptonSplitContainer1
			// 
			this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
			this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 49);
			this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
			// 
			// kryptonSplitContainer1.Panel1
			// 
			this.kryptonSplitContainer1.Panel1.Controls.Add(this.tvSchema);
			this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonLabel1);
			// 
			// kryptonSplitContainer1.Panel2
			// 
			this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonNavigator1);
			this.kryptonSplitContainer1.Size = new System.Drawing.Size(711, 361);
			this.kryptonSplitContainer1.SplitterDistance = 185;
			this.kryptonSplitContainer1.TabIndex = 6;
			// 
			// tvSchema
			// 
			this.tvSchema.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvSchema.ImageIndex = 0;
			this.tvSchema.ImageList = this.imageList1;
			this.tvSchema.Location = new System.Drawing.Point(0, 20);
			this.tvSchema.Name = "tvSchema";
			this.tvSchema.SelectedImageIndex = 0;
			this.tvSchema.Size = new System.Drawing.Size(185, 341);
			this.tvSchema.TabIndex = 0;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "icons8-sql.png");
			this.imageList1.Images.SetKeyName(1, "icons8-tabla.png");
			this.imageList1.Images.SetKeyName(2, "icons8-cifrado-de-datos.png");
			this.imageList1.Images.SetKeyName(3, "icons8-additional.png");
			this.imageList1.Images.SetKeyName(4, "icons8-hashtag-grande.png");
			this.imageList1.Images.SetKeyName(5, "icons8-verdadero-falso.png");
			this.imageList1.Images.SetKeyName(6, "icons8-calendario.png");
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ItalicPanel;
			this.kryptonLabel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(185, 20);
			this.kryptonLabel1.TabIndex = 5;
			this.kryptonLabel1.Values.Text = "Tablas y Vistas disponibles:";
			// 
			// kryptonNavigator1
			// 
			this.kryptonNavigator1.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.OneNote;
			this.kryptonNavigator1.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.ContextNextPrevious;
			this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonNavigator1.Group.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelClient;
			this.kryptonNavigator1.Group.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlGroupBox;
			this.kryptonNavigator1.Location = new System.Drawing.Point(0, 0);
			this.kryptonNavigator1.Name = "kryptonNavigator1";
			this.kryptonNavigator1.NavigatorMode = ComponentFactory.Krypton.Navigator.NavigatorMode.BarRibbonTabGroup;
			this.kryptonNavigator1.PageBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelClient;
			this.kryptonNavigator1.Size = new System.Drawing.Size(521, 361);
			this.kryptonNavigator1.TabIndex = 4;
			this.kryptonNavigator1.Text = "kryptonNavigator1";
			this.kryptonNavigator1.SelectedPageChanged += new System.EventHandler(this.kryptonNavigator1_SelectedPageChanged);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripButton,
            this.abrirToolStripButton,
            this.guardarToolStripButton,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.cmbSchemas,
            this.toolStripSeparator2,
            this.btnExecute});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(711, 25);
			this.toolStrip1.Stretch = true;
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// nuevoToolStripButton
			// 
			this.nuevoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.nuevoToolStripButton.Image = global::ControlNominasAddIn.Properties.Resources.document_empty;
			this.nuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.nuevoToolStripButton.Name = "nuevoToolStripButton";
			this.nuevoToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.nuevoToolStripButton.Text = "&Nuevo";
			this.nuevoToolStripButton.Click += new System.EventHandler(this.nuevoArchivo_Click);
			// 
			// abrirToolStripButton
			// 
			this.abrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.abrirToolStripButton.Image = global::ControlNominasAddIn.Properties.Resources.folder_vertical_open;
			this.abrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.abrirToolStripButton.Name = "abrirToolStripButton";
			this.abrirToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.abrirToolStripButton.Text = "&Abrir";
			this.abrirToolStripButton.Click += new System.EventHandler(this.abrirArchivo_Click);
			// 
			// guardarToolStripButton
			// 
			this.guardarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.guardarToolStripButton.Image = global::ControlNominasAddIn.Properties.Resources.diskette;
			this.guardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.guardarToolStripButton.Name = "guardarToolStripButton";
			this.guardarToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.guardarToolStripButton.Text = "&Guardar";
			this.guardarToolStripButton.Click += new System.EventHandler(this.guardarArchivo_Click);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = global::ControlNominasAddIn.Properties.Resources.save_as;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton2.Text = "Guardar Como";
			this.toolStripButton2.Click += new System.EventHandler(this.guardarComoArchivo_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(83, 22);
			this.toolStripLabel1.Text = "Base de Datos:";
			// 
			// cmbSchemas
			// 
			this.cmbSchemas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSchemas.Name = "cmbSchemas";
			this.cmbSchemas.Size = new System.Drawing.Size(140, 25);
			this.cmbSchemas.SelectedIndexChanged += new System.EventHandler(this.kryptonNavigator1_SelectedPageChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// btnExecute
			// 
			this.btnExecute.Enabled = false;
			this.btnExecute.Image = global::ControlNominasAddIn.Properties.Resources.control_play;
			this.btnExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(69, 22);
			this.btnExecute.Text = "Ejecutar";
			this.btnExecute.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnExecute.Click += new System.EventHandler(this.ExecuteQuery_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.consultaToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(711, 24);
			this.menuStrip1.TabIndex = 7;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// archivoToolStripMenuItem
			// 
			this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.toolStripSeparator3,
            this.salirToolStripMenuItem});
			this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
			this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.archivoToolStripMenuItem.Text = "Archivo";
			// 
			// nuevoToolStripMenuItem
			// 
			this.nuevoToolStripMenuItem.Image = global::ControlNominasAddIn.Properties.Resources.document_empty;
			this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
			this.nuevoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.nuevoToolStripMenuItem.Text = "Nuevo";
			this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoArchivo_Click);
			// 
			// abrirToolStripMenuItem
			// 
			this.abrirToolStripMenuItem.Image = global::ControlNominasAddIn.Properties.Resources.folder_vertical_open;
			this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
			this.abrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.abrirToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.abrirToolStripMenuItem.Text = "Abrir";
			this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirArchivo_Click);
			// 
			// guardarToolStripMenuItem
			// 
			this.guardarToolStripMenuItem.Image = global::ControlNominasAddIn.Properties.Resources.diskette;
			this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
			this.guardarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
			this.guardarToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.guardarToolStripMenuItem.Text = "Guardar";
			this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarArchivo_Click);
			// 
			// guardarComoToolStripMenuItem
			// 
			this.guardarComoToolStripMenuItem.Image = global::ControlNominasAddIn.Properties.Resources.save_as;
			this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
			this.guardarComoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.guardarComoToolStripMenuItem.Text = "Guardar Como";
			this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoArchivo_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(189, 6);
			// 
			// salirToolStripMenuItem
			// 
			this.salirToolStripMenuItem.Image = global::ControlNominasAddIn.Properties.Resources.cross;
			this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
			this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.salirToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.salirToolStripMenuItem.Text = "Salir";
			this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
			// 
			// consultaToolStripMenuItem
			// 
			this.consultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejecutarToolStripMenuItem});
			this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
			this.consultaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.consultaToolStripMenuItem.Text = "Consulta";
			// 
			// ejecutarToolStripMenuItem
			// 
			this.ejecutarToolStripMenuItem.Image = global::ControlNominasAddIn.Properties.Resources.control_play;
			this.ejecutarToolStripMenuItem.Name = "ejecutarToolStripMenuItem";
			this.ejecutarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.ejecutarToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.ejecutarToolStripMenuItem.Text = "Ejecutar";
			this.ejecutarToolStripMenuItem.Click += new System.EventHandler(this.ExecuteQuery_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "sql";
			this.saveFileDialog1.Filter = "SQL File(*.sql)|*.sql";
			this.saveFileDialog1.Title = "Guardar SQL";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "zpl";
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "SQL file(*.sql)|*.sql";
			this.openFileDialog1.Title = "Abrir SQL";
			// 
			// frmSQL
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(711, 410);
			this.Controls.Add(this.kryptonPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmSQL";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Consulta con SQL";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSQL_FormClosing);
			this.Load += new System.EventHandler(this.frmSQL_Load);
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
			this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
			this.kryptonSplitContainer1.Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
			this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
			this.kryptonSplitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
			this.kryptonNavigator1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
		private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton nuevoToolStripButton;
		private System.Windows.Forms.ToolStripButton abrirToolStripButton;
		private System.Windows.Forms.ToolStripButton guardarToolStripButton;
		private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
		private ComponentFactory.Krypton.Toolkit.KryptonTreeView tvSchema;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripComboBox cmbSchemas;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnExecute;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ejecutarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
	}
}