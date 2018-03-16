namespace EstacionesPesaje {
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
			if (disposing && ( components != null )) {
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent () {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			this.Ribbon = new ComponentFactory.Krypton.Ribbon.KryptonRibbon();
			this.ProduccionRibbonTab = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
			this.kryptonRibbonGroup1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
			this.kryptonRibbonGroupTriple1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
			this.CapturaProduccionRbnBtn = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
			this.CapturaDesperdicoRbnBtn = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
			this.OrdenTrabajoExplorerRbnBtn = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
			this.EtiquetasRibbonTab = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
			this.kryptonRibbonGroup4 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
			this.kryptonRibbonGroupTriple4 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
			this.kryptonRibbonGroupButton4 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
			this.kryptonRibbonGroupButton5 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
			this.kryptonRibbonGroupButton6 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
			this.EmbarquesRibbonTab = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
			this.kryptonRibbonTab1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
			this.kryptonRibbonGroup2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
			this.kryptonRibbonGroupTriple2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
			this.kryptonRibbonGroupButton1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
			this.kryptonRibbonGroupButton2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
			this.kryptonRibbonTab2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
			this.kryptonRibbonGroup3 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
			this.kryptonRibbonGroupLines1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines();
			this.kryptonRibbonGroupLabel1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel();
			this.ImpresoraComboBox = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupComboBox();
			this.kryptonRibbonGroupTriple3 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
			this.kryptonRibbonGroupButton3 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
			this.MainPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.kryptonDockableWorkspace = new ComponentFactory.Krypton.Docking.KryptonDockableWorkspace();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.BasculaText = new System.Windows.Forms.ToolStripStatusLabel();
			this.kryptonDockingManager = new ComponentFactory.Krypton.Docking.KryptonDockingManager();
			this.controlBascula1 = new libBascula.ControlBascula(this.components);
			this.ConnectBasculaSpectButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
			((System.ComponentModel.ISupportInitialize)(this.Ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
			this.MainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonDockableWorkspace)).BeginInit();
			this.statusStrip1.SuspendLayout();
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
			// Ribbon
			// 
			this.Ribbon.AllowFormIntegrate = false;
			this.Ribbon.InDesignHelperMode = true;
			this.Ribbon.Name = "Ribbon";
			this.Ribbon.RibbonTabs.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab[] {
            this.ProduccionRibbonTab,
            this.EtiquetasRibbonTab,
            this.EmbarquesRibbonTab,
            this.kryptonRibbonTab1,
            this.kryptonRibbonTab2});
			this.Ribbon.SelectedTab = this.ProduccionRibbonTab;
			this.Ribbon.Size = new System.Drawing.Size(902, 115);
			this.Ribbon.TabIndex = 0;
			// 
			// ProduccionRibbonTab
			// 
			this.ProduccionRibbonTab.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup1});
			this.ProduccionRibbonTab.Text = "Produccion";
			// 
			// kryptonRibbonGroup1
			// 
			this.kryptonRibbonGroup1.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple1});
			this.kryptonRibbonGroup1.TextLine1 = "Control";
			// 
			// kryptonRibbonGroupTriple1
			// 
			this.kryptonRibbonGroupTriple1.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.CapturaProduccionRbnBtn,
            this.CapturaDesperdicoRbnBtn,
            this.OrdenTrabajoExplorerRbnBtn});
			// 
			// CapturaProduccionRbnBtn
			// 
			this.CapturaProduccionRbnBtn.ImageLarge = global::EstacionesPesaje.Properties.Resources.worker;
			this.CapturaProduccionRbnBtn.ImageSmall = global::EstacionesPesaje.Properties.Resources.worker1;
			this.CapturaProduccionRbnBtn.TextLine1 = "Produccion";
			this.CapturaProduccionRbnBtn.Click += new System.EventHandler(this.CapturaProduccionRbnBtn_Click);
			// 
			// CapturaDesperdicoRbnBtn
			// 
			this.CapturaDesperdicoRbnBtn.TextLine1 = "Desperdicio";
			// 
			// OrdenTrabajoExplorerRbnBtn
			// 
			this.OrdenTrabajoExplorerRbnBtn.ImageLarge = global::EstacionesPesaje.Properties.Resources.report_open;
			this.OrdenTrabajoExplorerRbnBtn.ImageSmall = global::EstacionesPesaje.Properties.Resources.report_open1;
			this.OrdenTrabajoExplorerRbnBtn.TextLine1 = "Ordenes de ";
			this.OrdenTrabajoExplorerRbnBtn.TextLine2 = "Trabajo";
			this.OrdenTrabajoExplorerRbnBtn.Click += new System.EventHandler(this.OrdenTrabajoExplorerRbnBtn_Click);
			// 
			// EtiquetasRibbonTab
			// 
			this.EtiquetasRibbonTab.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup4});
			this.EtiquetasRibbonTab.Text = "Etiquetas";
			// 
			// kryptonRibbonGroup4
			// 
			this.kryptonRibbonGroup4.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple4});
			// 
			// kryptonRibbonGroupTriple4
			// 
			this.kryptonRibbonGroupTriple4.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupButton4,
            this.kryptonRibbonGroupButton5,
            this.kryptonRibbonGroupButton6});
			// 
			// kryptonRibbonGroupButton4
			// 
			this.kryptonRibbonGroupButton4.ImageLarge = global::EstacionesPesaje.Properties.Resources.barcode_new;
			this.kryptonRibbonGroupButton4.ImageSmall = global::EstacionesPesaje.Properties.Resources.barcode_new;
			this.kryptonRibbonGroupButton4.TextLine1 = "Nueva";
			this.kryptonRibbonGroupButton4.TextLine2 = "Etiqueta";
			this.kryptonRibbonGroupButton4.Click += new System.EventHandler(this.kryptonRibbonGroupButton4_Click);
			// 
			// kryptonRibbonGroupButton5
			// 
			this.kryptonRibbonGroupButton5.ImageLarge = global::EstacionesPesaje.Properties.Resources.barcode_edit;
			this.kryptonRibbonGroupButton5.ImageSmall = global::EstacionesPesaje.Properties.Resources.barcode_edit1;
			this.kryptonRibbonGroupButton5.TextLine1 = "Editar";
			this.kryptonRibbonGroupButton5.TextLine2 = "Etiqueta";
			this.kryptonRibbonGroupButton5.Click += new System.EventHandler(this.kryptonRibbonGroupButton5_Click);
			// 
			// kryptonRibbonGroupButton6
			// 
			this.kryptonRibbonGroupButton6.TextLine1 = "Borrar";
			this.kryptonRibbonGroupButton6.TextLine2 = "Etiqueta";
			this.kryptonRibbonGroupButton6.Visible = false;
			// 
			// EmbarquesRibbonTab
			// 
			this.EmbarquesRibbonTab.Text = "Embarques";
			// 
			// kryptonRibbonTab1
			// 
			this.kryptonRibbonTab1.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup2});
			this.kryptonRibbonTab1.Text = "Bascula";
			// 
			// kryptonRibbonGroup2
			// 
			this.kryptonRibbonGroup2.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple2});
			// 
			// kryptonRibbonGroupTriple2
			// 
			this.kryptonRibbonGroupTriple2.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupButton1,
            this.kryptonRibbonGroupButton2});
			// 
			// kryptonRibbonGroupButton1
			// 
			this.kryptonRibbonGroupButton1.ImageLarge = global::EstacionesPesaje.Properties.Resources.connect;
			this.kryptonRibbonGroupButton1.ImageSmall = global::EstacionesPesaje.Properties.Resources.connect1;
			this.kryptonRibbonGroupButton1.TextLine1 = "Conectar";
			this.kryptonRibbonGroupButton1.Click += new System.EventHandler(this.kryptonRibbonGroupButton1_Click);
			// 
			// kryptonRibbonGroupButton2
			// 
			this.kryptonRibbonGroupButton2.ImageLarge = global::EstacionesPesaje.Properties.Resources.gear;
			this.kryptonRibbonGroupButton2.ImageSmall = global::EstacionesPesaje.Properties.Resources.gear1;
			this.kryptonRibbonGroupButton2.TextLine1 = "Configurar";
			this.kryptonRibbonGroupButton2.Click += new System.EventHandler(this.OpenConfigBasculaPage_Click);
			// 
			// kryptonRibbonTab2
			// 
			this.kryptonRibbonTab2.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup3});
			this.kryptonRibbonTab2.Text = "Configuracion";
			// 
			// kryptonRibbonGroup3
			// 
			this.kryptonRibbonGroup3.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupLines1,
            this.kryptonRibbonGroupTriple3});
			// 
			// kryptonRibbonGroupLines1
			// 
			this.kryptonRibbonGroupLines1.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupLabel1,
            this.ImpresoraComboBox});
			// 
			// kryptonRibbonGroupLabel1
			// 
			this.kryptonRibbonGroupLabel1.TextLine1 = "Impresora Etiquetas:";
			// 
			// ImpresoraComboBox
			// 
			this.ImpresoraComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ImpresoraComboBox.DropDownWidth = 121;
			this.ImpresoraComboBox.FormattingEnabled = false;
			this.ImpresoraComboBox.ItemHeight = 15;
			this.ImpresoraComboBox.MaximumSize = new System.Drawing.Size(300, 0);
			this.ImpresoraComboBox.MinimumSize = new System.Drawing.Size(200, 0);
			this.ImpresoraComboBox.Text = global::EstacionesPesaje.Properties.Settings.Default.ImpresoraEtiquetas;
			this.ImpresoraComboBox.SelectedValueChanged += new System.EventHandler(this.ImpresoraComboBox_SelectedValueChanged);
			// 
			// kryptonRibbonGroupTriple3
			// 
			this.kryptonRibbonGroupTriple3.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupButton3});
			// 
			// kryptonRibbonGroupButton3
			// 
			this.kryptonRibbonGroupButton3.ImageLarge = global::EstacionesPesaje.Properties.Resources.Process_32x;
			this.kryptonRibbonGroupButton3.TextLine1 = "Lineas";
			this.kryptonRibbonGroupButton3.Click += new System.EventHandler(this.kryptonRibbonGroupButton3_Click);
			// 
			// MainPanel
			// 
			this.MainPanel.Controls.Add(this.kryptonDockableWorkspace);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(0, 115);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(902, 428);
			this.MainPanel.TabIndex = 1;
			// 
			// kryptonDockableWorkspace
			// 
			this.kryptonDockableWorkspace.AutoHiddenHost = false;
			this.kryptonDockableWorkspace.CompactFlags = ComponentFactory.Krypton.Workspace.CompactFlags.None;
			this.kryptonDockableWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonDockableWorkspace.Location = new System.Drawing.Point(0, 0);
			this.kryptonDockableWorkspace.Name = "kryptonDockableWorkspace";
			// 
			// 
			// 
			this.kryptonDockableWorkspace.Root.UniqueName = "29BE4441919B4BCA4695A9184B0660DE";
			this.kryptonDockableWorkspace.Root.WorkspaceControl = this.kryptonDockableWorkspace;
			this.kryptonDockableWorkspace.ShowMaximizeButton = false;
			this.kryptonDockableWorkspace.Size = new System.Drawing.Size(902, 428);
			this.kryptonDockableWorkspace.TabIndex = 0;
			this.kryptonDockableWorkspace.TabStop = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.BasculaText});
			this.statusStrip1.Location = new System.Drawing.Point(0, 543);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			this.statusStrip1.Size = new System.Drawing.Size(902, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(837, 17);
			this.toolStripStatusLabel1.Spring = true;
			this.toolStripStatusLabel1.Text = "Listo...";
			this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BasculaText
			// 
			this.BasculaText.Name = "BasculaText";
			this.BasculaText.Size = new System.Drawing.Size(50, 17);
			this.BasculaText.Text = "00.00 kg";
			// 
			// controlBascula1
			// 
			this.controlBascula1.ActivarEnvio = global::EstacionesPesaje.Properties.Settings.Default.ActivarEnvio;
			this.controlBascula1.BaudRate = global::EstacionesPesaje.Properties.Settings.Default.BasculaBaudRate;
			this.controlBascula1.CaracterFinLinea = global::EstacionesPesaje.Properties.Settings.Default.BasculaCaracterFinLinea;
			this.controlBascula1.ConectarAlIniciar = global::EstacionesPesaje.Properties.Settings.Default.BasculaConectarAlIniciar;
			this.controlBascula1.ConnectedImage = ((System.Drawing.Image)(resources.GetObject("controlBascula1.ConnectedImage")));
			this.controlBascula1.DataBindings.Add(new System.Windows.Forms.Binding("ActivarEnvio", global::EstacionesPesaje.Properties.Settings.Default, "ActivarEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.controlBascula1.DataBindings.Add(new System.Windows.Forms.Binding("BaudRate", global::EstacionesPesaje.Properties.Settings.Default, "BasculaBaudRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.controlBascula1.DataBindings.Add(new System.Windows.Forms.Binding("CaracterFinLinea", global::EstacionesPesaje.Properties.Settings.Default, "BasculaCaracterFinLinea", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.controlBascula1.DataBindings.Add(new System.Windows.Forms.Binding("ConectarAlIniciar", global::EstacionesPesaje.Properties.Settings.Default, "BasculaConectarAlIniciar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.controlBascula1.DataBindings.Add(new System.Windows.Forms.Binding("Fin", global::EstacionesPesaje.Properties.Settings.Default, "BasculaFin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.controlBascula1.DataBindings.Add(new System.Windows.Forms.Binding("Inicio", global::EstacionesPesaje.Properties.Settings.Default, "BasculaInicio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.controlBascula1.DataBindings.Add(new System.Windows.Forms.Binding("Intervalo", global::EstacionesPesaje.Properties.Settings.Default, "BasculaIntervalo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.controlBascula1.DataBindings.Add(new System.Windows.Forms.Binding("Puerto", global::EstacionesPesaje.Properties.Settings.Default, "BasculaPuerto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.controlBascula1.DataBindings.Add(new System.Windows.Forms.Binding("ReadTimeOut", global::EstacionesPesaje.Properties.Settings.Default, "BasculaReadTimeOut", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.controlBascula1.DataBindings.Add(new System.Windows.Forms.Binding("StatusLabelShowUnidad", global::EstacionesPesaje.Properties.Settings.Default, "BasculaShowUnidad", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.controlBascula1.DataBindings.Add(new System.Windows.Forms.Binding("TextoAEnviar", global::EstacionesPesaje.Properties.Settings.Default, "BasculaTextoAEnviar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.controlBascula1.DataBindings.Add(new System.Windows.Forms.Binding("Unidad", global::EstacionesPesaje.Properties.Settings.Default, "BasculaUnidad", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.controlBascula1.DisconnectedImage = ((System.Drawing.Image)(resources.GetObject("controlBascula1.DisconnectedImage")));
			this.controlBascula1.Fin = global::EstacionesPesaje.Properties.Settings.Default.BasculaFin;
			this.controlBascula1.Inicio = global::EstacionesPesaje.Properties.Settings.Default.BasculaInicio;
			this.controlBascula1.Intervalo = global::EstacionesPesaje.Properties.Settings.Default.BasculaIntervalo;
			this.controlBascula1.Puerto = global::EstacionesPesaje.Properties.Settings.Default.BasculaPuerto;
			this.controlBascula1.ReadTimeOut = global::EstacionesPesaje.Properties.Settings.Default.BasculaReadTimeOut;
			this.controlBascula1.StatusLabel = this.BasculaText;
			this.controlBascula1.StatusLabelShowUnidad = global::EstacionesPesaje.Properties.Settings.Default.BasculaShowUnidad;
			this.controlBascula1.StatusPicture = null;
			this.controlBascula1.TextoAEnviar = global::EstacionesPesaje.Properties.Settings.Default.BasculaTextoAEnviar;
			this.controlBascula1.Unidad = global::EstacionesPesaje.Properties.Settings.Default.BasculaUnidad;
			this.controlBascula1.CambioEstado += new libBascula.CambioEstadoEventHandler(this.controlBascula1_CambioEstado);
			// 
			// ConnectBasculaSpectButton
			// 
			this.ConnectBasculaSpectButton.Image = global::EstacionesPesaje.Properties.Resources.connect1;
			this.ConnectBasculaSpectButton.UniqueName = "7107AEAA4BBD4DD69DAF3390BC180482";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.ConnectBasculaSpectButton});
			this.ClientSize = new System.Drawing.Size(902, 565);
			this.Controls.Add(this.MainPanel);
			this.Controls.Add(this.Ribbon);
			this.Controls.Add(this.statusStrip1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.Ribbon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
			this.MainPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonDockableWorkspace)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbon Ribbon;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanel;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab ProduccionRibbonTab;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup1;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple1;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton CapturaProduccionRbnBtn;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton CapturaDesperdicoRbnBtn;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton OrdenTrabajoExplorerRbnBtn;
		private ComponentFactory.Krypton.Docking.KryptonDockableWorkspace kryptonDockableWorkspace;
		private ComponentFactory.Krypton.Docking.KryptonDockingManager kryptonDockingManager;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab EtiquetasRibbonTab;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab EmbarquesRibbonTab;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab1;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup2;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple2;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton1;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton2;
		private libBascula.ControlBascula controlBascula1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel BasculaText;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab2;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup3;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines kryptonRibbonGroupLines1;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel kryptonRibbonGroupLabel1;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupComboBox ImpresoraComboBox;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny ConnectBasculaSpectButton;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple3;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton3;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup4;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple4;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton4;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton5;
		private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton6;
	}
}

