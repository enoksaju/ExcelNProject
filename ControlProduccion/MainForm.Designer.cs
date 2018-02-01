namespace ControlProduccion
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.CatalogosRibbonTab = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ClientesCatalogRibbonButton = new System.Windows.Forms.RibbonButton();
            this.MaterialesCatalogRibbonButton = new System.Windows.Forms.RibbonButton();
            this.ImpresorasCatalogRibbonButton = new System.Windows.Forms.RibbonButton();
            this.MaquinasCatalogRibbonButton = new System.Windows.Forms.RibbonButton();
            this.UsuariosCatalogRibbonButton = new System.Windows.Forms.RibbonButton();
            this.EtiquetasCatalogRibbonButton = new System.Windows.Forms.RibbonButton();
            this.BasculaRibbonTab = new System.Windows.Forms.RibbonTab();
            this.BasculaRibbonPanel = new System.Windows.Forms.RibbonPanel();
            this.ConectarBasculaRibbonButton = new System.Windows.Forms.RibbonButton();
            this.ConfigurarBasculaRibbonButton = new System.Windows.Forms.RibbonButton();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.VS2015Theme = new WeifenLuo.WinFormsUI.Docking.VS2015LightTheme();
            this.visualStudioToolStripExtender1 = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BasculaToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.controlBascula = new libBascula.ControlBascula(this.components);
            this.StatusBasculaConectionPicture = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBasculaConectionPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // CatalogosRibbonTab
            // 
            this.CatalogosRibbonTab.Name = "CatalogosRibbonTab";
            this.CatalogosRibbonTab.Panels.Add(this.ribbonPanel1);
            this.CatalogosRibbonTab.Text = "Catalogos";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Image = global::ControlProduccion.Properties.Resources.Magazine_32px;
            this.ribbonPanel1.Items.Add(this.ClientesCatalogRibbonButton);
            this.ribbonPanel1.Items.Add(this.MaterialesCatalogRibbonButton);
            this.ribbonPanel1.Items.Add(this.ImpresorasCatalogRibbonButton);
            this.ribbonPanel1.Items.Add(this.MaquinasCatalogRibbonButton);
            this.ribbonPanel1.Items.Add(this.UsuariosCatalogRibbonButton);
            this.ribbonPanel1.Items.Add(this.EtiquetasCatalogRibbonButton);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "Catalogos";
            // 
            // ClientesCatalogRibbonButton
            // 
            this.ClientesCatalogRibbonButton.Image = global::ControlProduccion.Properties.Resources.Management_32px;
            this.ClientesCatalogRibbonButton.LargeImage = global::ControlProduccion.Properties.Resources.Management_32px;
            this.ClientesCatalogRibbonButton.Name = "ClientesCatalogRibbonButton";
            this.ClientesCatalogRibbonButton.SmallImage = global::ControlProduccion.Properties.Resources.Management_16px;
            this.ClientesCatalogRibbonButton.Text = "Clientes";
            this.ClientesCatalogRibbonButton.Click += new System.EventHandler(this.ClientesCatalogRibbonButton_Click);
            // 
            // MaterialesCatalogRibbonButton
            // 
            this.MaterialesCatalogRibbonButton.Image = global::ControlProduccion.Properties.Resources.Sheet_Metal_32px;
            this.MaterialesCatalogRibbonButton.LargeImage = global::ControlProduccion.Properties.Resources.Sheet_Metal_32px;
            this.MaterialesCatalogRibbonButton.Name = "MaterialesCatalogRibbonButton";
            this.MaterialesCatalogRibbonButton.SmallImage = global::ControlProduccion.Properties.Resources.Sheet_Metal_16px;
            this.MaterialesCatalogRibbonButton.Text = "Materiales";
            // 
            // ImpresorasCatalogRibbonButton
            // 
            this.ImpresorasCatalogRibbonButton.Image = global::ControlProduccion.Properties.Resources.Center_of_Gravity_32px;
            this.ImpresorasCatalogRibbonButton.LargeImage = global::ControlProduccion.Properties.Resources.Center_of_Gravity_32px;
            this.ImpresorasCatalogRibbonButton.Name = "ImpresorasCatalogRibbonButton";
            this.ImpresorasCatalogRibbonButton.SmallImage = global::ControlProduccion.Properties.Resources.Center_of_Gravity_16px;
            this.ImpresorasCatalogRibbonButton.Text = "Impresoras";
            // 
            // MaquinasCatalogRibbonButton
            // 
            this.MaquinasCatalogRibbonButton.Image = global::ControlProduccion.Properties.Resources.Gears_32px;
            this.MaquinasCatalogRibbonButton.LargeImage = global::ControlProduccion.Properties.Resources.Gears_32px;
            this.MaquinasCatalogRibbonButton.Name = "MaquinasCatalogRibbonButton";
            this.MaquinasCatalogRibbonButton.SmallImage = global::ControlProduccion.Properties.Resources.Gears_16px;
            this.MaquinasCatalogRibbonButton.Text = "Maquinas";
            // 
            // UsuariosCatalogRibbonButton
            // 
            this.UsuariosCatalogRibbonButton.Image = global::ControlProduccion.Properties.Resources.User_Account_32px;
            this.UsuariosCatalogRibbonButton.LargeImage = global::ControlProduccion.Properties.Resources.User_Account_32px;
            this.UsuariosCatalogRibbonButton.Name = "UsuariosCatalogRibbonButton";
            this.UsuariosCatalogRibbonButton.SmallImage = global::ControlProduccion.Properties.Resources.User_Account_16px;
            this.UsuariosCatalogRibbonButton.Text = "Usuarios";
            // 
            // EtiquetasCatalogRibbonButton
            // 
            this.EtiquetasCatalogRibbonButton.Image = global::ControlProduccion.Properties.Resources.Barcode_32px;
            this.EtiquetasCatalogRibbonButton.LargeImage = global::ControlProduccion.Properties.Resources.Barcode_32px;
            this.EtiquetasCatalogRibbonButton.Name = "EtiquetasCatalogRibbonButton";
            this.EtiquetasCatalogRibbonButton.SmallImage = global::ControlProduccion.Properties.Resources.Barcode_16px;
            this.EtiquetasCatalogRibbonButton.Text = "Etiquetas";
            // 
            // BasculaRibbonTab
            // 
            this.BasculaRibbonTab.Name = "BasculaRibbonTab";
            this.BasculaRibbonTab.Panels.Add(this.BasculaRibbonPanel);
            this.BasculaRibbonTab.Text = "Bascula";
            // 
            // BasculaRibbonPanel
            // 
            this.BasculaRibbonPanel.Image = global::ControlProduccion.Properties.Resources.Industrial_Scales_16px;
            this.BasculaRibbonPanel.Items.Add(this.ConectarBasculaRibbonButton);
            this.BasculaRibbonPanel.Items.Add(this.ConfigurarBasculaRibbonButton);
            this.BasculaRibbonPanel.Name = "BasculaRibbonPanel";
            this.BasculaRibbonPanel.Text = "Bascula";
            // 
            // ConectarBasculaRibbonButton
            // 
            this.ConectarBasculaRibbonButton.Image = global::ControlProduccion.Properties.Resources.Industrial_Scales_32px;
            this.ConectarBasculaRibbonButton.LargeImage = global::ControlProduccion.Properties.Resources.Industrial_Scales_32px;
            this.ConectarBasculaRibbonButton.Name = "ConectarBasculaRibbonButton";
            this.ConectarBasculaRibbonButton.SmallImage = global::ControlProduccion.Properties.Resources.Industrial_Scales_16px;
            this.ConectarBasculaRibbonButton.Text = "Conectar";
            this.ConectarBasculaRibbonButton.Click += new System.EventHandler(this.ConectarBasculaRibbonButton_Click);
            // 
            // ConfigurarBasculaRibbonButton
            // 
            this.ConfigurarBasculaRibbonButton.Image = global::ControlProduccion.Properties.Resources.básculas_industriales_32;
            this.ConfigurarBasculaRibbonButton.LargeImage = global::ControlProduccion.Properties.Resources.básculas_industriales_32;
            this.ConfigurarBasculaRibbonButton.Name = "ConfigurarBasculaRibbonButton";
            this.ConfigurarBasculaRibbonButton.SmallImage = global::ControlProduccion.Properties.Resources.básculas_industriales_161;
            this.ConfigurarBasculaRibbonButton.Text = "Configurar";
            this.ConfigurarBasculaRibbonButton.Click += new System.EventHandler(this.ConfigurarBasculaRibbonButton_Click);
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = global::ControlProduccion.Properties.Resources.Menu_White_16px;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1043, 145);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.CatalogosRibbonTab);
            this.ribbon1.Tabs.Add(this.BasculaRibbonTab);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(5, 26, 20, 0);
            this.ribbon1.TabSpacing = 4;
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Halloween;
            // 
            // visualStudioToolStripExtender1
            // 
            this.visualStudioToolStripExtender1.DefaultRenderer = null;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.dockPanel1.DockBottomPortion = 200D;
            this.dockPanel1.DockLeftPortion = 300D;
            this.dockPanel1.DockRightPortion = 300D;
            this.dockPanel1.DockTopPortion = 200D;
            this.dockPanel1.DocumentTabStripLocation = WeifenLuo.WinFormsUI.Docking.DocumentTabStripLocation.Bottom;
            this.dockPanel1.Location = new System.Drawing.Point(0, 145);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.dockPanel1.ShowAutoHideContentOnHover = false;
            this.dockPanel1.Size = new System.Drawing.Size(1043, 390);
            this.dockPanel1.TabIndex = 1;
            this.dockPanel1.Theme = this.VS2015Theme;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusToolStripStatusLabel,
            this.BasculaToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1043, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusToolStripStatusLabel
            // 
            this.StatusToolStripStatusLabel.Name = "StatusToolStripStatusLabel";
            this.StatusToolStripStatusLabel.Size = new System.Drawing.Size(928, 17);
            this.StatusToolStripStatusLabel.Spring = true;
            this.StatusToolStripStatusLabel.Text = "Listo";
            this.StatusToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BasculaToolStripStatusLabel
            // 
            this.BasculaToolStripStatusLabel.AutoSize = false;
            this.BasculaToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.BasculaToolStripStatusLabel.Image = global::ControlProduccion.Properties.Resources.IndustrialScales_White_Lines16px;
            this.BasculaToolStripStatusLabel.Name = "BasculaToolStripStatusLabel";
            this.BasculaToolStripStatusLabel.Size = new System.Drawing.Size(100, 17);
            this.BasculaToolStripStatusLabel.Text = "00.00 kg";
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
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("ReadTimeOut", global::ControlProduccion.Properties.Settings.Default, "BasculaTimeReadOut", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("StatusLabelShowUnidad", global::ControlProduccion.Properties.Settings.Default, "BasculaStatusLabelShowUnidad", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("TextoAEnviar", global::ControlProduccion.Properties.Settings.Default, "BasculaTextoAEnviar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("Puerto", global::ControlProduccion.Properties.Settings.Default, "BasculaPuerto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DataBindings.Add(new System.Windows.Forms.Binding("Unidad", global::ControlProduccion.Properties.Settings.Default, "BasculaUnidad", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlBascula.DisconnectedImage = ((System.Drawing.Image)(resources.GetObject("controlBascula.DisconnectedImage")));
            this.controlBascula.Fin = global::ControlProduccion.Properties.Settings.Default.BasculaFin;
            this.controlBascula.Inicio = global::ControlProduccion.Properties.Settings.Default.BasculaInicio;
            this.controlBascula.Intervalo = global::ControlProduccion.Properties.Settings.Default.BasculaIntervalo;
            this.controlBascula.Puerto = global::ControlProduccion.Properties.Settings.Default.BasculaPuerto;
            this.controlBascula.ReadTimeOut = global::ControlProduccion.Properties.Settings.Default.BasculaTimeReadOut;
            this.controlBascula.StatusLabel = this.BasculaToolStripStatusLabel;
            this.controlBascula.StatusLabelShowUnidad = global::ControlProduccion.Properties.Settings.Default.BasculaStatusLabelShowUnidad;
            this.controlBascula.StatusPicture = this.StatusBasculaConectionPicture;
            this.controlBascula.TextoAEnviar = global::ControlProduccion.Properties.Settings.Default.BasculaTextoAEnviar;
            this.controlBascula.Unidad = global::ControlProduccion.Properties.Settings.Default.BasculaUnidad;
            this.controlBascula.CambioValor += new libBascula.CambioValorEvenHandler(this.controlBascula_CambioValor);
            this.controlBascula.CambioEstado += new libBascula.CambioEstadoEventHandler(this.controlBascula_CambioEstado);
            // 
            // StatusBasculaConectionPicture
            // 
            this.StatusBasculaConectionPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusBasculaConectionPicture.BackColor = System.Drawing.Color.Gainsboro;
            this.StatusBasculaConectionPicture.Image = ((System.Drawing.Image)(resources.GetObject("StatusBasculaConectionPicture.Image")));
            this.StatusBasculaConectionPicture.Location = new System.Drawing.Point(1006, 0);
            this.StatusBasculaConectionPicture.Name = "StatusBasculaConectionPicture";
            this.StatusBasculaConectionPicture.Size = new System.Drawing.Size(30, 30);
            this.StatusBasculaConectionPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StatusBasculaConectionPicture.TabIndex = 4;
            this.StatusBasculaConectionPicture.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 557);
            this.Controls.Add(this.StatusBasculaConectionPicture);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Control de Produccion";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBasculaConectionPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab CatalogosRibbonTab;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton ClientesCatalogRibbonButton;
        private System.Windows.Forms.RibbonButton MaterialesCatalogRibbonButton;
        private System.Windows.Forms.RibbonButton ImpresorasCatalogRibbonButton;
        private System.Windows.Forms.RibbonButton MaquinasCatalogRibbonButton;
        private System.Windows.Forms.RibbonButton UsuariosCatalogRibbonButton;
        private System.Windows.Forms.RibbonButton EtiquetasCatalogRibbonButton;
        private System.Windows.Forms.RibbonTab BasculaRibbonTab;
        private System.Windows.Forms.RibbonPanel BasculaRibbonPanel;
        private System.Windows.Forms.RibbonButton ConectarBasculaRibbonButton;
        private System.Windows.Forms.RibbonButton ConfigurarBasculaRibbonButton;
        private WeifenLuo.WinFormsUI.Docking.VS2015LightTheme VS2015Theme;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender visualStudioToolStripExtender1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel BasculaToolStripStatusLabel;
        private libBascula.ControlBascula controlBascula;
        private System.Windows.Forms.PictureBox StatusBasculaConectionPicture;
    }
}

