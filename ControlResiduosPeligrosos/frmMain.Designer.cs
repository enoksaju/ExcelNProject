namespace ControlResiduosPeligrosos
{
  partial class frmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.catalogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.transportistasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tiposDeResiduosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.movimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.salidasDeResiduosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.manifiestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bitacoraResiduosPeligrososToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configuracionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.temaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.azulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.plataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.negroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.purpuraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.naranjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.catalogosToolStripMenuItem,
            this.movimientosToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.configuracionesToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(757, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// archivoToolStripMenuItem
			// 
			this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
			this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
			this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.archivoToolStripMenuItem.Text = "Archivo";
			// 
			// catalogosToolStripMenuItem
			// 
			this.catalogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proveedoresToolStripMenuItem,
            this.transportistasToolStripMenuItem,
            this.tiposDeResiduosToolStripMenuItem});
			this.catalogosToolStripMenuItem.Image = global::ControlResiduosPeligrosos.Properties.Resources.report_green;
			this.catalogosToolStripMenuItem.Name = "catalogosToolStripMenuItem";
			this.catalogosToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
			this.catalogosToolStripMenuItem.Text = "Catalogos";
			// 
			// kryptonManager1
			// 
			this.kryptonManager1.GlobalPaletteMode = global::ControlResiduosPeligrosos.Properties.Settings.Default.Tema;
			// 
			// salirToolStripMenuItem
			// 
			this.salirToolStripMenuItem.Image = global::ControlResiduosPeligrosos.Properties.Resources.cross;
			this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
			this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.salirToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.salirToolStripMenuItem.Text = "Salir";
			this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
			// 
			// proveedoresToolStripMenuItem
			// 
			this.proveedoresToolStripMenuItem.Image = global::ControlResiduosPeligrosos.Properties.Resources.group;
			this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
			this.proveedoresToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.P)));
			this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.proveedoresToolStripMenuItem.Text = "Proveedores";
			this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
			// 
			// transportistasToolStripMenuItem
			// 
			this.transportistasToolStripMenuItem.Image = global::ControlResiduosPeligrosos.Properties.Resources.lorry;
			this.transportistasToolStripMenuItem.Name = "transportistasToolStripMenuItem";
			this.transportistasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.T)));
			this.transportistasToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.transportistasToolStripMenuItem.Text = "Transportistas";
			this.transportistasToolStripMenuItem.Click += new System.EventHandler(this.transportistasToolStripMenuItem_Click);
			// 
			// tiposDeResiduosToolStripMenuItem
			// 
			this.tiposDeResiduosToolStripMenuItem.Image = global::ControlResiduosPeligrosos.Properties.Resources.warning;
			this.tiposDeResiduosToolStripMenuItem.Name = "tiposDeResiduosToolStripMenuItem";
			this.tiposDeResiduosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.R)));
			this.tiposDeResiduosToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.tiposDeResiduosToolStripMenuItem.Text = "Tipos de Residuos";
			this.tiposDeResiduosToolStripMenuItem.Click += new System.EventHandler(this.tiposDeResiduosToolStripMenuItem_Click);
			// 
			// movimientosToolStripMenuItem
			// 
			this.movimientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salidasDeResiduosToolStripMenuItem,
            this.manifiestosToolStripMenuItem});
			this.movimientosToolStripMenuItem.Image = global::ControlResiduosPeligrosos.Properties.Resources.document_move;
			this.movimientosToolStripMenuItem.Name = "movimientosToolStripMenuItem";
			this.movimientosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
			this.movimientosToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
			this.movimientosToolStripMenuItem.Text = "Movimientos";
			// 
			// salidasDeResiduosToolStripMenuItem
			// 
			this.salidasDeResiduosToolStripMenuItem.Image = global::ControlResiduosPeligrosos.Properties.Resources.door_out;
			this.salidasDeResiduosToolStripMenuItem.Name = "salidasDeResiduosToolStripMenuItem";
			this.salidasDeResiduosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
			this.salidasDeResiduosToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
			this.salidasDeResiduosToolStripMenuItem.Text = "Salidas de Residuos";
			this.salidasDeResiduosToolStripMenuItem.Click += new System.EventHandler(this.salidasDeResiduosToolStripMenuItem_Click);
			// 
			// manifiestosToolStripMenuItem
			// 
			this.manifiestosToolStripMenuItem.Image = global::ControlResiduosPeligrosos.Properties.Resources.script_text;
			this.manifiestosToolStripMenuItem.Name = "manifiestosToolStripMenuItem";
			this.manifiestosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.M)));
			this.manifiestosToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
			this.manifiestosToolStripMenuItem.Text = "Manifiestos";
			this.manifiestosToolStripMenuItem.Click += new System.EventHandler(this.manifiestosToolStripMenuItem_Click);
			// 
			// reportesToolStripMenuItem
			// 
			this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitacoraResiduosPeligrososToolStripMenuItem});
			this.reportesToolStripMenuItem.Image = global::ControlResiduosPeligrosos.Properties.Resources.reports;
			this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
			this.reportesToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
			this.reportesToolStripMenuItem.Text = "Reportes";
			// 
			// bitacoraResiduosPeligrososToolStripMenuItem
			// 
			this.bitacoraResiduosPeligrososToolStripMenuItem.Image = global::ControlResiduosPeligrosos.Properties.Resources.blank_report;
			this.bitacoraResiduosPeligrososToolStripMenuItem.Name = "bitacoraResiduosPeligrososToolStripMenuItem";
			this.bitacoraResiduosPeligrososToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.B)));
			this.bitacoraResiduosPeligrososToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
			this.bitacoraResiduosPeligrososToolStripMenuItem.Text = "Bitacora Residuos Peligrosos";
			this.bitacoraResiduosPeligrososToolStripMenuItem.Click += new System.EventHandler(this.bitacoraResiduosPeligrososToolStripMenuItem_Click);
			// 
			// configuracionesToolStripMenuItem
			// 
			this.configuracionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temaToolStripMenuItem});
			this.configuracionesToolStripMenuItem.Image = global::ControlResiduosPeligrosos.Properties.Resources.gear_in;
			this.configuracionesToolStripMenuItem.Name = "configuracionesToolStripMenuItem";
			this.configuracionesToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
			this.configuracionesToolStripMenuItem.Text = "Configuraciones";
			// 
			// temaToolStripMenuItem
			// 
			this.temaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.azulToolStripMenuItem,
            this.plataToolStripMenuItem,
            this.negroToolStripMenuItem,
            this.purpuraToolStripMenuItem,
            this.naranjaToolStripMenuItem});
			this.temaToolStripMenuItem.Image = global::ControlResiduosPeligrosos.Properties.Resources.palette;
			this.temaToolStripMenuItem.Name = "temaToolStripMenuItem";
			this.temaToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.temaToolStripMenuItem.Text = "Temas";
			// 
			// azulToolStripMenuItem
			// 
			this.azulToolStripMenuItem.Name = "azulToolStripMenuItem";
			this.azulToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
			this.azulToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.azulToolStripMenuItem.Text = "Azul";
			this.azulToolStripMenuItem.Click += new System.EventHandler(this.themeSelector_Click);
			// 
			// plataToolStripMenuItem
			// 
			this.plataToolStripMenuItem.Name = "plataToolStripMenuItem";
			this.plataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
			this.plataToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.plataToolStripMenuItem.Text = "Plata";
			this.plataToolStripMenuItem.Click += new System.EventHandler(this.themeSelector_Click);
			// 
			// negroToolStripMenuItem
			// 
			this.negroToolStripMenuItem.Name = "negroToolStripMenuItem";
			this.negroToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
			this.negroToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.negroToolStripMenuItem.Text = "Negro";
			this.negroToolStripMenuItem.Click += new System.EventHandler(this.themeSelector_Click);
			// 
			// purpuraToolStripMenuItem
			// 
			this.purpuraToolStripMenuItem.Name = "purpuraToolStripMenuItem";
			this.purpuraToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
			this.purpuraToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.purpuraToolStripMenuItem.Text = "Purpura";
			this.purpuraToolStripMenuItem.Click += new System.EventHandler(this.themeSelector_Click);
			// 
			// naranjaToolStripMenuItem
			// 
			this.naranjaToolStripMenuItem.Name = "naranjaToolStripMenuItem";
			this.naranjaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
			this.naranjaToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.naranjaToolStripMenuItem.Text = "Naranja";
			this.naranjaToolStripMenuItem.Click += new System.EventHandler(this.themeSelector_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(757, 468);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmMain";
			this.Text = "Control Residuos";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem catalogosToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem transportistasToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tiposDeResiduosToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem movimientosToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem salidasDeResiduosToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem manifiestosToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem configuracionesToolStripMenuItem;
    private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
    private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem bitacoraResiduosPeligrososToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem temaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem azulToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem plataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem negroToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem purpuraToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem naranjaToolStripMenuItem;
	}
}

