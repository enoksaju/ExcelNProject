namespace ControlProduccion
{
    partial class Main2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main2));
            this.VS2015DarkTheme = new WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme();
            this.VS2015LightTheme = new WeifenLuo.WinFormsUI.Docking.VS2015LightTheme();
            this.VS2015BlueTheme = new WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme();
            this.VS2005Theme = new WeifenLuo.WinFormsUI.Docking.VS2005Theme();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BasculaStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.visualStudioToolStripExtender1 = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.kryptonRibbonTab1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonGroup1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.kryptonRibbonGroupButton1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton3 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbon1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbon();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonRibbonTab2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonGroup2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.ConectarBasculaKryptonRibbonGroupButton = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.ConfigurarBasculaKryptonRibbonGroupButton = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.controlBascula = new libBascula.ControlBascula(this.components);
            this.SetConectedImageToKrypton = new ComponentFactory.Krypton.Toolkit.KryptonCommand();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusToolStripStatusLabel,
            this.BasculaStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 483);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(787, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusToolStripStatusLabel
            // 
            this.StatusToolStripStatusLabel.Name = "StatusToolStripStatusLabel";
            this.StatusToolStripStatusLabel.Size = new System.Drawing.Size(722, 17);
            this.StatusToolStripStatusLabel.Spring = true;
            this.StatusToolStripStatusLabel.Text = "Listo...";
            this.StatusToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BasculaStatusLabel
            // 
            this.BasculaStatusLabel.Name = "BasculaStatusLabel";
            this.BasculaStatusLabel.Size = new System.Drawing.Size(50, 17);
            this.BasculaStatusLabel.Text = "00.00 kg";
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Black;
            // 
            // visualStudioToolStripExtender1
            // 
            this.visualStudioToolStripExtender1.DefaultRenderer = null;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dockPanel1.DockBottomPortion = 200D;
            this.dockPanel1.DockLeftPortion = 300D;
            this.dockPanel1.DockRightPortion = 300D;
            this.dockPanel1.DockTopPortion = 200D;
            this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel1.Location = new System.Drawing.Point(0, 127);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.dockPanel1.ShowAutoHideContentOnHover = false;
            this.dockPanel1.ShowDocumentIcon = true;
            this.dockPanel1.Size = new System.Drawing.Size(787, 356);
            this.dockPanel1.TabIndex = 1;
            this.dockPanel1.Theme = this.VS2015DarkTheme;
            // 
            // kryptonRibbonTab1
            // 
            this.kryptonRibbonTab1.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup1});
            this.kryptonRibbonTab1.KeyTip = "C";
            this.kryptonRibbonTab1.Text = "Catalogos";
            // 
            // kryptonRibbonGroup1
            // 
            this.kryptonRibbonGroup1.Image = global::ControlProduccion.Properties.Resources.Magazine_32px;
            this.kryptonRibbonGroup1.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple1});
            this.kryptonRibbonGroup1.TextLine1 = "Catalogos";
            // 
            // kryptonRibbonGroupTriple1
            // 
            this.kryptonRibbonGroupTriple1.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupButton1,
            this.kryptonRibbonGroupButton2,
            this.kryptonRibbonGroupButton3});
            // 
            // kryptonRibbonGroupButton1
            // 
            this.kryptonRibbonGroupButton1.ImageLarge = global::ControlProduccion.Properties.Resources.Management_32px;
            this.kryptonRibbonGroupButton1.ImageSmall = global::ControlProduccion.Properties.Resources.Management_16px;
            this.kryptonRibbonGroupButton1.KeyTip = "C";
            this.kryptonRibbonGroupButton1.TextLine1 = "Clientes";
            this.kryptonRibbonGroupButton1.Click += new System.EventHandler(this.kryptonRibbonGroupButton1_Click);
            // 
            // kryptonRibbonGroupButton2
            // 
            this.kryptonRibbonGroupButton2.ImageLarge = global::ControlProduccion.Properties.Resources.Sheet_Metal_32px;
            this.kryptonRibbonGroupButton2.ImageSmall = global::ControlProduccion.Properties.Resources.Sheet_Metal_16px;
            this.kryptonRibbonGroupButton2.TextLine1 = "Materiales";
            this.kryptonRibbonGroupButton2.Click += new System.EventHandler(this.kryptonRibbonGroupButton2_Click);
            // 
            // kryptonRibbonGroupButton3
            // 
            this.kryptonRibbonGroupButton3.Click += new System.EventHandler(this.kryptonRibbonGroupButton3_Click);
            // 
            // kryptonRibbon1
            // 
            this.kryptonRibbon1.AllowButtonSpecToolTips = true;
            this.kryptonRibbon1.AllowFormIntegrate = false;
            this.kryptonRibbon1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1});
            this.kryptonRibbon1.InDesignHelperMode = true;
            this.kryptonRibbon1.Name = "kryptonRibbon1";
            this.kryptonRibbon1.QATUserChange = false;
            this.kryptonRibbon1.RibbonStrings.CustomizeQuickAccessToolbar = "Personalizar accesos rapidos";
            this.kryptonRibbon1.RibbonStrings.Minimize = "Minimizar la cinta";
            this.kryptonRibbon1.RibbonStrings.MoreColors = "Mas colores";
            this.kryptonRibbon1.RibbonStrings.NoColor = "Sin color";
            this.kryptonRibbon1.RibbonStrings.RecentColors = "Colores Recientes";
            this.kryptonRibbon1.RibbonStrings.RecentDocuments = "Archivos Recientes";
            this.kryptonRibbon1.RibbonStrings.StandardColors = "Colores Estandar";
            this.kryptonRibbon1.RibbonStrings.ThemeColors = "Colores del Tema";
            this.kryptonRibbon1.RibbonTabs.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab[] {
            this.kryptonRibbonTab1,
            this.kryptonRibbonTab2});
            this.kryptonRibbon1.SelectedTab = this.kryptonRibbonTab2;
            this.kryptonRibbon1.Size = new System.Drawing.Size(787, 127);
            this.kryptonRibbon1.TabIndex = 4;
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.Image = global::ControlProduccion.Properties.Resources.ScalesConnected_red;
            this.buttonSpecAny1.ToolTipBody = "Conectar o desconectar la bascula";
            this.buttonSpecAny1.ToolTipImage = global::ControlProduccion.Properties.Resources.Industrial_Scales_16px;
            this.buttonSpecAny1.ToolTipTitle = "Bascula";
            this.buttonSpecAny1.UniqueName = "AA1F0A167B2D450B3E8D6484417FEA60";
            this.buttonSpecAny1.Click += new System.EventHandler(this.toogleConnection_Click);
            // 
            // kryptonRibbonTab2
            // 
            this.kryptonRibbonTab2.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup2});
            this.kryptonRibbonTab2.KeyTip = "B";
            this.kryptonRibbonTab2.Text = "Bascula";
            // 
            // kryptonRibbonGroup2
            // 
            this.kryptonRibbonGroup2.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple2});
            this.kryptonRibbonGroup2.TextLine1 = "Bascula";
            // 
            // kryptonRibbonGroupTriple2
            // 
            this.kryptonRibbonGroupTriple2.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.ConectarBasculaKryptonRibbonGroupButton,
            this.ConfigurarBasculaKryptonRibbonGroupButton});
            // 
            // ConectarBasculaKryptonRibbonGroupButton
            // 
            this.ConectarBasculaKryptonRibbonGroupButton.ImageLarge = global::ControlProduccion.Properties.Resources.Industrial_Scales_32px;
            this.ConectarBasculaKryptonRibbonGroupButton.ImageSmall = global::ControlProduccion.Properties.Resources.Industrial_Scales_16px;
            this.ConectarBasculaKryptonRibbonGroupButton.TextLine1 = "Conectar";
            this.ConectarBasculaKryptonRibbonGroupButton.Click += new System.EventHandler(this.toogleConnection_Click);
            // 
            // ConfigurarBasculaKryptonRibbonGroupButton
            // 
            this.ConfigurarBasculaKryptonRibbonGroupButton.ImageLarge = global::ControlProduccion.Properties.Resources.Gears_32px;
            this.ConfigurarBasculaKryptonRibbonGroupButton.ImageSmall = global::ControlProduccion.Properties.Resources.Gears_16px;
            this.ConfigurarBasculaKryptonRibbonGroupButton.TextLine1 = "Configurar";
            this.ConfigurarBasculaKryptonRibbonGroupButton.Click += new System.EventHandler(this.kryptonRibbonGroupButton5_Click);
            // 
            // controlBascula
            // 
            this.controlBascula.ActivarEnvio = global::ControlProduccion.Properties.Settings.Default.BasculaActivarEnvio;
            this.controlBascula.BaudRate = global::ControlProduccion.Properties.Settings.Default.BasculaBaudRate;
            this.controlBascula.CaracterFinLinea = global::ControlProduccion.Properties.Settings.Default.BasculaCaracterFinLinea;
            this.controlBascula.ConectarAlIniciar = global::ControlProduccion.Properties.Settings.Default.BasculaConectarAlIniciar;
            this.controlBascula.ConnectedImage = ((System.Drawing.Image)(resources.GetObject("controlBascula.ConnectedImage")));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("ActivarEnvio", global::ControlProduccion.Properties.Settings.Default, "BasculaActivarEnvio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("BaudRate", global::ControlProduccion.Properties.Settings.Default, "BasculaBaudRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("CaracterFinLinea", global::ControlProduccion.Properties.Settings.Default, "BasculaCaracterFinLinea", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("ConectarAlIniciar", global::ControlProduccion.Properties.Settings.Default, "BasculaConectarAlIniciar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("Fin", global::ControlProduccion.Properties.Settings.Default, "BasculaFin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("Inicio", global::ControlProduccion.Properties.Settings.Default, "BasculaInicio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("Intervalo", global::ControlProduccion.Properties.Settings.Default, "BasculaIntervalo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("Puerto", global::ControlProduccion.Properties.Settings.Default, "BasculaPuerto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("ReadTimeOut", global::ControlProduccion.Properties.Settings.Default, "BasculaTimeReadOut", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("StatusLabelShowUnidad", global::ControlProduccion.Properties.Settings.Default, "BasculaStatusLabelShowUnidad", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("TextoAEnviar", global::ControlProduccion.Properties.Settings.Default, "BasculaTextoAEnviar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("Unidad", global::ControlProduccion.Properties.Settings.Default, "BasculaUnidad", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DisconnectedImage = ((System.Drawing.Image)(resources.GetObject("controlBascula.DisconnectedImage")));
            this.controlBascula.Fin = global::ControlProduccion.Properties.Settings.Default.BasculaFin;
            this.controlBascula.Inicio = global::ControlProduccion.Properties.Settings.Default.BasculaInicio;
            this.controlBascula.Intervalo = global::ControlProduccion.Properties.Settings.Default.BasculaIntervalo;
            this.controlBascula.Puerto = global::ControlProduccion.Properties.Settings.Default.BasculaPuerto;
            this.controlBascula.ReadTimeOut = global::ControlProduccion.Properties.Settings.Default.BasculaTimeReadOut;
            this.controlBascula.StatusLabel = this.BasculaStatusLabel;
            this.controlBascula.StatusLabelShowUnidad = global::ControlProduccion.Properties.Settings.Default.BasculaStatusLabelShowUnidad;
            this.controlBascula.StatusPicture = null;
            this.controlBascula.TextoAEnviar = global::ControlProduccion.Properties.Settings.Default.BasculaTextoAEnviar;
            this.controlBascula.Unidad = global::ControlProduccion.Properties.Settings.Default.BasculaUnidad;
            this.controlBascula.CambioEstado += new libBascula.CambioEstadoEventHandler(this.controlBascula_CambioEstado);
            // 
            // SetConectedImageToKrypton
            // 
            this.SetConectedImageToKrypton.ImageLarge = global::ControlProduccion.Properties.Resources.ScalesConnected_green;
            this.SetConectedImageToKrypton.ImageSmall = global::ControlProduccion.Properties.Resources.Industrial_Scales_16px;
            this.SetConectedImageToKrypton.Text = "SetConectedImage";
            this.SetConectedImageToKrypton.TextLine1 = "Desconectar";
            // 
            // Main2
            // 
            this.AllowStatusStripMerge = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(787, 505);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.kryptonRibbon1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Main2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.Text = "Main2";
            this.Load += new System.EventHandler(this.Main2_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private WeifenLuo .WinFormsUI.Docking.VS2015BlueTheme VS2015BlueTheme;
        private WeifenLuo .WinFormsUI.Docking.VS2015LightTheme VS2015LightTheme;

        private WeifenLuo .WinFormsUI.Docking.VS2015DarkTheme VS2015DarkTheme;

        private WeifenLuo.WinFormsUI.Docking.VS2005Theme VS2005Theme;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusToolStripStatusLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender visualStudioToolStripExtender1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton3;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbon kryptonRibbon1;
        private System.Windows.Forms.ToolStripStatusLabel BasculaStatusLabel;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private libBascula.ControlBascula controlBascula;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton ConfigurarBasculaKryptonRibbonGroupButton;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton ConectarBasculaKryptonRibbonGroupButton;
        private ComponentFactory.Krypton.Toolkit.KryptonCommand SetConectedImageToKrypton;
    }
}