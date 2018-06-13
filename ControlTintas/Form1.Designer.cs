namespace ControlTintas {
	partial class Form1 {
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose ( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent ( ) {
			this.components = new System.ComponentModel.Container();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			this.MainPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.DockableWorkspace = new ComponentFactory.Krypton.Docking.KryptonDockableWorkspace();
			this.kryptonDockingManager = new ComponentFactory.Krypton.Docking.KryptonDockingManager();
			this.kryptonRibbon1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbon();
			this.kryptonRibbonTab1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
			this.CatalogosKRG = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
			this.kryptonRibbonGroupTriple1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
			this.kryptonRibbonGroupButton1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
			this.kryptonRibbonTab2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
			this.kryptonRibbonTab3 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
			this.MovimientosKRG = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
			this.kryptonRibbonGroupTriple2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
			this.kryptonRibbonGroupButton2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
			this.kryptonRibbonGroupButton3 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
			this.kryptonRibbonGroupButton4 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
			((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
			this.MainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DockableWorkspace)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).BeginInit();
			this.SuspendLayout();
			// 
			// kryptonManager1
			// 
			this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
			this.kryptonManager1.GlobalStrings.Abort = "Abortar";
			this.kryptonManager1.GlobalStrings.Cancel = "Cancelar";
			this.kryptonManager1.GlobalStrings.Close = "Cerrar";
			this.kryptonManager1.GlobalStrings.Ignore = "Ignorar";
			this.kryptonManager1.GlobalStrings.Retry = "Reintentar";
			this.kryptonManager1.GlobalStrings.Today = "Hoy";
			this.kryptonManager1.GlobalStrings.Yes = "Si";
			// 
			// MainPanel
			// 
			this.MainPanel.Controls.Add(this.DockableWorkspace);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(0, 115);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(734, 487);
			this.MainPanel.StateCommon.Image = global::ControlTintas.Properties.Resources.logopl;
			this.MainPanel.StateCommon.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.BottomRight;
			this.MainPanel.TabIndex = 1;
			// 
			// DockableWorkspace
			// 
			this.DockableWorkspace.AutoHiddenHost = false;
			this.DockableWorkspace.CompactFlags = ((ComponentFactory.Krypton.Workspace.CompactFlags)(((ComponentFactory.Krypton.Workspace.CompactFlags.RemoveEmptyCells | ComponentFactory.Krypton.Workspace.CompactFlags.RemoveEmptySequences) 
            | ComponentFactory.Krypton.Workspace.CompactFlags.PromoteLeafs)));
			this.DockableWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DockableWorkspace.Location = new System.Drawing.Point(0, 0);
			this.DockableWorkspace.Name = "DockableWorkspace";
			// 
			// 
			// 
			this.DockableWorkspace.Root.UniqueName = "276E7CC3EC2949BBA3A522CB9314EE01";
			this.DockableWorkspace.Root.WorkspaceControl = this.DockableWorkspace;
			this.DockableWorkspace.ShowMaximizeButton = false;
			this.DockableWorkspace.Size = new System.Drawing.Size(734, 487);
			this.DockableWorkspace.StateCommon.Back.Image = global::ControlTintas.Properties.Resources.logopl;
			this.DockableWorkspace.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.BottomRight;
			this.DockableWorkspace.TabIndex = 0;
			this.DockableWorkspace.TabStop = true;
			// 
			// kryptonRibbon1
			// 
			this.kryptonRibbon1.AllowFormIntegrate = false;
			this.kryptonRibbon1.InDesignHelperMode = true;
			this.kryptonRibbon1.Name = "kryptonRibbon1";
			this.kryptonRibbon1.RibbonAppButton.AppButtonVisible = false;
			this.kryptonRibbon1.RibbonTabs.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab[] {
            this.kryptonRibbonTab1,
            this.kryptonRibbonTab2,
            this.kryptonRibbonTab3});
			this.kryptonRibbon1.SelectedTab = this.kryptonRibbonTab1;
			this.kryptonRibbon1.ShowMinimizeButton = false;
			this.kryptonRibbon1.Size = new System.Drawing.Size(734, 115);
			this.kryptonRibbon1.TabIndex = 0;
			// 
			// kryptonRibbonTab1
			// 
			this.kryptonRibbonTab1.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.MovimientosKRG,
            this.CatalogosKRG});
			this.kryptonRibbonTab1.KeyTip = "C";
			this.kryptonRibbonTab1.Text = "Control";
			// 
			// CatalogosKRG
			// 
			this.CatalogosKRG.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple1});
			this.CatalogosKRG.TextLine1 = "Catalogos";
			// 
			// kryptonRibbonGroupTriple1
			// 
			this.kryptonRibbonGroupTriple1.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupButton1});
			// 
			// kryptonRibbonGroupButton1
			// 
			this.kryptonRibbonGroupButton1.ImageLarge = global::ControlTintas.Properties.Resources.colors_info;
			this.kryptonRibbonGroupButton1.ImageSmall = global::ControlTintas.Properties.Resources.colors_info1;
			this.kryptonRibbonGroupButton1.KeyTip = "A";
			this.kryptonRibbonGroupButton1.TextLine1 = "A r t i c u l o s ";
			this.kryptonRibbonGroupButton1.Click += new System.EventHandler(this.kryptonRibbonGroupButton1_Click);
			// 
			// kryptonRibbonTab2
			// 
			this.kryptonRibbonTab2.KeyTip = "R";
			this.kryptonRibbonTab2.Text = "Reportes";
			// 
			// kryptonRibbonTab3
			// 
			this.kryptonRibbonTab3.KeyTip = "C";
			this.kryptonRibbonTab3.Text = "Configuracion";
			// 
			// MovimientosKRG
			// 
			this.MovimientosKRG.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple2});
			this.MovimientosKRG.TextLine1 = "Movimientos";
			// 
			// kryptonRibbonGroupTriple2
			// 
			this.kryptonRibbonGroupTriple2.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupButton2,
            this.kryptonRibbonGroupButton3,
            this.kryptonRibbonGroupButton4});
			// 
			// kryptonRibbonGroupButton2
			// 
			this.kryptonRibbonGroupButton2.TextLine1 = "Entrada";
			// 
			// kryptonRibbonGroupButton3
			// 
			this.kryptonRibbonGroupButton3.TextLine1 = "Devolucion";
			// 
			// kryptonRibbonGroupButton4
			// 
			this.kryptonRibbonGroupButton4.TextLine1 = "Salida";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(734, 602);
			this.Controls.Add(this.MainPanel);
			this.Controls.Add(this.kryptonRibbon1);
			this.CustomCaptionArea = new System.Drawing.Rectangle(274, 0, 460, 26);
			this.Name = "Form1";
			this.Text = "Control Almacen Tintas";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
			this.MainPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DockableWorkspace)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanel;
		private ComponentFactory.Krypton.Docking.KryptonDockableWorkspace DockableWorkspace;
		private ComponentFactory.Krypton.Docking.KryptonDockingManager kryptonDockingManager;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbon kryptonRibbon1;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab1;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab2;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab3;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup CatalogosKRG;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple1;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton1;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup MovimientosKRG;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple2;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton2;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton3;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton4;
	}
}

