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
      this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.catalogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.transportistasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tiposDeResiduosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.movimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.salidasDeResiduosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.manifiestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.bitacoraResiduosPeligrososToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.configuracionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
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
      // salirToolStripMenuItem
      // 
      this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
      this.salirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.salirToolStripMenuItem.Text = "Salir";
      this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
      // 
      // catalogosToolStripMenuItem
      // 
      this.catalogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proveedoresToolStripMenuItem,
            this.transportistasToolStripMenuItem,
            this.tiposDeResiduosToolStripMenuItem});
      this.catalogosToolStripMenuItem.Name = "catalogosToolStripMenuItem";
      this.catalogosToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
      this.catalogosToolStripMenuItem.Text = "Catalogos";
      // 
      // proveedoresToolStripMenuItem
      // 
      this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
      this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.proveedoresToolStripMenuItem.Text = "Proveedores";
      this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
      // 
      // transportistasToolStripMenuItem
      // 
      this.transportistasToolStripMenuItem.Name = "transportistasToolStripMenuItem";
      this.transportistasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.transportistasToolStripMenuItem.Text = "Transportistas";
      this.transportistasToolStripMenuItem.Click += new System.EventHandler(this.transportistasToolStripMenuItem_Click);
      // 
      // tiposDeResiduosToolStripMenuItem
      // 
      this.tiposDeResiduosToolStripMenuItem.Name = "tiposDeResiduosToolStripMenuItem";
      this.tiposDeResiduosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.tiposDeResiduosToolStripMenuItem.Text = "Tipos de Residuos";
      this.tiposDeResiduosToolStripMenuItem.Click += new System.EventHandler(this.tiposDeResiduosToolStripMenuItem_Click);
      // 
      // movimientosToolStripMenuItem
      // 
      this.movimientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salidasDeResiduosToolStripMenuItem,
            this.manifiestosToolStripMenuItem});
      this.movimientosToolStripMenuItem.Name = "movimientosToolStripMenuItem";
      this.movimientosToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
      this.movimientosToolStripMenuItem.Text = "Movimientos";
      // 
      // salidasDeResiduosToolStripMenuItem
      // 
      this.salidasDeResiduosToolStripMenuItem.Name = "salidasDeResiduosToolStripMenuItem";
      this.salidasDeResiduosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
      this.salidasDeResiduosToolStripMenuItem.Text = "Salidas de Residuos";
      this.salidasDeResiduosToolStripMenuItem.Click += new System.EventHandler(this.salidasDeResiduosToolStripMenuItem_Click);
      // 
      // manifiestosToolStripMenuItem
      // 
      this.manifiestosToolStripMenuItem.Name = "manifiestosToolStripMenuItem";
      this.manifiestosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
      this.manifiestosToolStripMenuItem.Text = "Manifiestos";
      this.manifiestosToolStripMenuItem.Click += new System.EventHandler(this.manifiestosToolStripMenuItem_Click);
      // 
      // reportesToolStripMenuItem
      // 
      this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitacoraResiduosPeligrososToolStripMenuItem});
      this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
      this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
      this.reportesToolStripMenuItem.Text = "Reportes";
      // 
      // bitacoraResiduosPeligrososToolStripMenuItem
      // 
      this.bitacoraResiduosPeligrososToolStripMenuItem.Name = "bitacoraResiduosPeligrososToolStripMenuItem";
      this.bitacoraResiduosPeligrososToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
      this.bitacoraResiduosPeligrososToolStripMenuItem.Text = "Bitacora Residuos Peligrosos";
      this.bitacoraResiduosPeligrososToolStripMenuItem.Click += new System.EventHandler(this.bitacoraResiduosPeligrososToolStripMenuItem_Click);
      // 
      // configuracionesToolStripMenuItem
      // 
      this.configuracionesToolStripMenuItem.Name = "configuracionesToolStripMenuItem";
      this.configuracionesToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
      this.configuracionesToolStripMenuItem.Text = "Configuraciones";
      // 
      // kryptonManager1
      // 
      this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
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
  }
}

