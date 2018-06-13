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
			this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.nuevoToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.abrirToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.guardarToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
			this.tvSchema = new ComponentFactory.Krypton.Toolkit.KryptonTreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.cmbSchemas = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
			this.kryptonNavigator1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
			this.kryptonSplitContainer1.Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
			this.kryptonSplitContainer1.Panel2.SuspendLayout();
			this.kryptonSplitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.kryptonSplitContainer1);
			this.kryptonPanel1.Controls.Add(this.toolStrip1);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(711, 410);
			this.kryptonPanel1.TabIndex = 1;
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
			this.kryptonNavigator1.Size = new System.Drawing.Size(545, 385);
			this.kryptonNavigator1.TabIndex = 4;
			this.kryptonNavigator1.Text = "kryptonNavigator1";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripButton,
            this.abrirToolStripButton,
            this.guardarToolStripButton,
            this.toolStripSeparator1,
            this.cmbSchemas,
            this.toolStripSeparator2});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(711, 25);
			this.toolStrip1.Stretch = true;
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// nuevoToolStripButton
			// 
			this.nuevoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.nuevoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripButton.Image")));
			this.nuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.nuevoToolStripButton.Name = "nuevoToolStripButton";
			this.nuevoToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.nuevoToolStripButton.Text = "&Nuevo";
			this.nuevoToolStripButton.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// abrirToolStripButton
			// 
			this.abrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.abrirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripButton.Image")));
			this.abrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.abrirToolStripButton.Name = "abrirToolStripButton";
			this.abrirToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.abrirToolStripButton.Text = "&Abrir";
			// 
			// guardarToolStripButton
			// 
			this.guardarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.guardarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("guardarToolStripButton.Image")));
			this.guardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.guardarToolStripButton.Name = "guardarToolStripButton";
			this.guardarToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.guardarToolStripButton.Text = "&Guardar";
			// 
			// kryptonSplitContainer1
			// 
			this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
			this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 25);
			this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
			// 
			// kryptonSplitContainer1.Panel1
			// 
			this.kryptonSplitContainer1.Panel1.Controls.Add(this.tvSchema);
			// 
			// kryptonSplitContainer1.Panel2
			// 
			this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonNavigator1);
			this.kryptonSplitContainer1.Size = new System.Drawing.Size(711, 385);
			this.kryptonSplitContainer1.SplitterDistance = 161;
			this.kryptonSplitContainer1.TabIndex = 6;
			// 
			// tvSchema
			// 
			this.tvSchema.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvSchema.ImageIndex = 0;
			this.tvSchema.ImageList = this.imageList1;
			this.tvSchema.Location = new System.Drawing.Point(0, 0);
			this.tvSchema.Name = "tvSchema";
			this.tvSchema.SelectedImageIndex = 0;
			this.tvSchema.Size = new System.Drawing.Size(161, 385);
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
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// cmbSchemas
			// 
			this.cmbSchemas.Name = "cmbSchemas";
			this.cmbSchemas.Size = new System.Drawing.Size(140, 25);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// frmSQL
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(711, 410);
			this.Controls.Add(this.kryptonPanel1);
			this.Name = "frmSQL";
			this.Text = "frmSQL";
			this.Load += new System.EventHandler(this.frmSQL_Load);
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
			this.kryptonNavigator1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
			this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
			this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
			this.kryptonSplitContainer1.ResumeLayout(false);
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
	}
}