namespace tryEntity
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonContextListas = new System.Windows.Forms.RibbonContext();
            this.TabCatalogos = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.panelDatosLista = new System.Windows.Forms.RibbonPanel();
            this.ribbtnListaExportExcel = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.ribtxtListaSearch = new System.Windows.Forms.RibbonTextBox();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.tabControl1 = new MdiTabControl.TabControl();
            this.ribbonMnuBtnConfig = new System.Windows.Forms.RibbonOrbMenuItem();
            this.rbnbtnCatClientes = new System.Windows.Forms.RibbonButton();
            this.rbnbtnCatFamiliaMateriales = new System.Windows.Forms.RibbonButton();
            this.rbnbtnListaRefresh = new System.Windows.Forms.RibbonButton();
            this.rbbtnListaAdd = new System.Windows.Forms.RibbonButton();
            this.ribbtnListaEdit = new System.Windows.Forms.RibbonButton();
            this.ribbtnListaDel = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbtnListaSearch = new System.Windows.Forms.RibbonButton();
            this.ribbonDescriptionMenuItem1 = new System.Windows.Forms.RibbonDescriptionMenuItem();
            this.ribbonDescriptionMenuItem2 = new System.Windows.Forms.RibbonDescriptionMenuItem();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Contexts.Add(this.ribbonContextListas);
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonMnuBtnConfig);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 116);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbon1.OrbText = "Inicio";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(690, 143);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.TabCatalogos);
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(5, 26, 20, 0);
            this.ribbon1.TabSpacing = 4;
            // 
            // ribbonContextListas
            // 
            this.ribbonContextListas.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ribbonContextListas.Text = "Tablas";
            // 
            // TabCatalogos
            // 
            this.TabCatalogos.Name = "TabCatalogos";
            this.TabCatalogos.Panels.Add(this.ribbonPanel1);
            this.TabCatalogos.Text = "Catalogos";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.rbnbtnCatClientes);
            this.ribbonPanel1.Items.Add(this.rbnbtnCatFamiliaMateriales);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "ribbonPanel1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Context = this.ribbonContextListas;
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.panelDatosLista);
            this.ribbonTab1.Panels.Add(this.ribbtnListaExportExcel);
            this.ribbonTab1.Panels.Add(this.ribbonPanel4);
            this.ribbonTab1.Text = "Datos";
            this.ribbonTab1.Visible = false;
            // 
            // panelDatosLista
            // 
            this.panelDatosLista.Items.Add(this.rbnbtnListaRefresh);
            this.panelDatosLista.Items.Add(this.rbbtnListaAdd);
            this.panelDatosLista.Items.Add(this.ribbtnListaEdit);
            this.panelDatosLista.Items.Add(this.ribbtnListaDel);
            this.panelDatosLista.Name = "panelDatosLista";
            this.panelDatosLista.Text = "Datos";
            // 
            // ribbtnListaExportExcel
            // 
            this.ribbtnListaExportExcel.Items.Add(this.ribbonButton2);
            this.ribbtnListaExportExcel.Name = "ribbtnListaExportExcel";
            this.ribbtnListaExportExcel.Text = "Exportar";
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Items.Add(this.ribtxtListaSearch);
            this.ribbonPanel4.Items.Add(this.ribbtnListaSearch);
            this.ribbonPanel4.Name = "ribbonPanel4";
            this.ribbonPanel4.Text = "Busqueda";
            // 
            // ribtxtListaSearch
            // 
            this.ribtxtListaSearch.Name = "ribtxtListaSearch";
            this.ribtxtListaSearch.Text = "";
            this.ribtxtListaSearch.TextBoxText = "";
            this.ribtxtListaSearch.TextBoxWidth = 200;
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = null;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 143);
            this.tabControl1.MenuRenderer = null;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(690, 372);
            this.tabControl1.TabCloseButtonImage = null;
            this.tabControl1.TabCloseButtonImageDisabled = null;
            this.tabControl1.TabCloseButtonImageHot = null;
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedTabChanged += new System.EventHandler(this.tabControl1_SelectedTabChanged);
            // 
            // ribbonMnuBtnConfig
            // 
            this.ribbonMnuBtnConfig.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonMnuBtnConfig.Image = global::tryEntity.Properties.Resources.setting_tools;
            this.ribbonMnuBtnConfig.LargeImage = global::tryEntity.Properties.Resources.setting_tools;
            this.ribbonMnuBtnConfig.Name = "ribbonMnuBtnConfig";
            this.ribbonMnuBtnConfig.SmallImage = global::tryEntity.Properties.Resources.setting_tools;
            this.ribbonMnuBtnConfig.Text = "Configuraciones";
            // 
            // rbnbtnCatClientes
            // 
            this.rbnbtnCatClientes.Image = global::tryEntity.Properties.Resources.users_3;
            this.rbnbtnCatClientes.LargeImage = global::tryEntity.Properties.Resources.users_3;
            this.rbnbtnCatClientes.Name = "rbnbtnCatClientes";
            this.rbnbtnCatClientes.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnbtnCatClientes.SmallImage")));
            this.rbnbtnCatClientes.Text = "Clientes";
            this.rbnbtnCatClientes.Click += new System.EventHandler(this.ribbonButton1_Click);
            // 
            // rbnbtnCatFamiliaMateriales
            // 
            this.rbnbtnCatFamiliaMateriales.Image = global::tryEntity.Properties.Resources.gear_in;
            this.rbnbtnCatFamiliaMateriales.LargeImage = global::tryEntity.Properties.Resources.gear_in;
            this.rbnbtnCatFamiliaMateriales.Name = "rbnbtnCatFamiliaMateriales";
            this.rbnbtnCatFamiliaMateriales.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnbtnCatFamiliaMateriales.SmallImage")));
            this.rbnbtnCatFamiliaMateriales.Text = "Impresoras Y Rodillos";
            this.rbnbtnCatFamiliaMateriales.Click += new System.EventHandler(this.rbnbtnCatFamiliaMateriales_Click);
            // 
            // rbnbtnListaRefresh
            // 
            this.rbnbtnListaRefresh.Image = global::tryEntity.Properties.Resources.table_refresh;
            this.rbnbtnListaRefresh.LargeImage = global::tryEntity.Properties.Resources.table_refresh;
            this.rbnbtnListaRefresh.Name = "rbnbtnListaRefresh";
            this.rbnbtnListaRefresh.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnbtnListaRefresh.SmallImage")));
            this.rbnbtnListaRefresh.Text = "Actualizar";
            this.rbnbtnListaRefresh.Click += new System.EventHandler(this.rbnbtnListaRefresh_Click);
            // 
            // rbbtnListaAdd
            // 
            this.rbbtnListaAdd.Image = global::tryEntity.Properties.Resources.plus;
            this.rbbtnListaAdd.LargeImage = global::tryEntity.Properties.Resources.plus;
            this.rbbtnListaAdd.Name = "rbbtnListaAdd";
            this.rbbtnListaAdd.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbbtnListaAdd.SmallImage")));
            this.rbbtnListaAdd.Text = "Agregar";
            this.rbbtnListaAdd.Click += new System.EventHandler(this.rbbtnListaAdd_Click);
            // 
            // ribbtnListaEdit
            // 
            this.ribbtnListaEdit.Image = global::tryEntity.Properties.Resources.pencil;
            this.ribbtnListaEdit.LargeImage = global::tryEntity.Properties.Resources.pencil;
            this.ribbtnListaEdit.Name = "ribbtnListaEdit";
            this.ribbtnListaEdit.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnListaEdit.SmallImage")));
            this.ribbtnListaEdit.Text = "Editar";
            this.ribbtnListaEdit.Click += new System.EventHandler(this.rbnbtnListaEdit_Click);
            // 
            // ribbtnListaDel
            // 
            this.ribbtnListaDel.Image = global::tryEntity.Properties.Resources.delete;
            this.ribbtnListaDel.LargeImage = global::tryEntity.Properties.Resources.delete;
            this.ribbtnListaDel.Name = "ribbtnListaDel";
            this.ribbtnListaDel.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnListaDel.SmallImage")));
            this.ribbtnListaDel.Text = "Eliminar";
            this.ribbtnListaDel.Click += new System.EventHandler(this.ribbtnListaDel_Click);
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = global::tryEntity.Properties.Resources.export_excel;
            this.ribbonButton2.LargeImage = global::tryEntity.Properties.Resources.export_excel;
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "Excel";
            // 
            // ribbtnListaSearch
            // 
            this.ribbtnListaSearch.Image = global::tryEntity.Properties.Resources.table_tab_search;
            this.ribbtnListaSearch.LargeImage = global::tryEntity.Properties.Resources.table_tab_search;
            this.ribbtnListaSearch.Name = "ribbtnListaSearch";
            this.ribbtnListaSearch.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnListaSearch.SmallImage")));
            this.ribbtnListaSearch.Text = "Buscar";
            this.ribbtnListaSearch.Click += new System.EventHandler(this.ribbtnListaSearch_Click);
            // 
            // ribbonDescriptionMenuItem1
            // 
            this.ribbonDescriptionMenuItem1.DescriptionBounds = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ribbonDescriptionMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonDescriptionMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem1.Image")));
            this.ribbonDescriptionMenuItem1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem1.LargeImage")));
            this.ribbonDescriptionMenuItem1.Name = "ribbonDescriptionMenuItem1";
            this.ribbonDescriptionMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem1.SmallImage")));
            this.ribbonDescriptionMenuItem1.Text = "ribbonDescriptionMenuItem1";
            // 
            // ribbonDescriptionMenuItem2
            // 
            this.ribbonDescriptionMenuItem2.DescriptionBounds = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ribbonDescriptionMenuItem2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonDescriptionMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem2.Image")));
            this.ribbonDescriptionMenuItem2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem2.LargeImage")));
            this.ribbonDescriptionMenuItem2.Name = "ribbonDescriptionMenuItem2";
            this.ribbonDescriptionMenuItem2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem2.SmallImage")));
            this.ribbonDescriptionMenuItem2.Text = "ribbonDescriptionMenuItem2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 515);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab TabCatalogos;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton rbnbtnCatClientes;       
        private System.Windows.Forms.RibbonButton rbnbtnCatFamiliaMateriales;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonDescriptionMenuItem ribbonDescriptionMenuItem1;
        private System.Windows.Forms.RibbonDescriptionMenuItem ribbonDescriptionMenuItem2;
        private MdiTabControl.TabControl tabControl1;
        public System.Windows.Forms.RibbonContext ribbonContextListas;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel panelDatosLista;
        private System.Windows.Forms.RibbonButton rbnbtnListaRefresh;
        private System.Windows.Forms.RibbonButton rbbtnListaAdd;
        private System.Windows.Forms.RibbonButton ribbtnListaEdit;
        private System.Windows.Forms.RibbonPanel ribbtnListaExportExcel;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonButton ribbtnListaDel;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonTextBox ribtxtListaSearch;
        private System.Windows.Forms.RibbonButton ribbtnListaSearch;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonMnuBtnConfig;
    }
}

