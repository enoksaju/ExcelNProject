namespace ControlNominasAddIn.Forms {
	partial class frmConfiguration {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguration));
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.pgDBPermisos = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.txtPermisosPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtPermisosFileName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchFilePermisos = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pgReloj1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.txtReloj1Password = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtReloj1File = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchFileReloj1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnSearchFileReloj2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.txtReloj2Password = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtReloj2File = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPage4 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kpSelectTheme = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtClaveChofer = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarBaseDeDatosDePermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarBaseDeDatosDelReloj1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarBaseDeDatosDelReloj2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pgDBPermisos)).BeginInit();
            this.pgDBPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pgReloj1)).BeginInit();
            this.pgReloj1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchFileReloj2)).BeginInit();
            this.btnSearchFileReloj2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).BeginInit();
            this.kryptonPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpSelectTheme)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.kryptonNavigator1.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(0, 49);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.NavigatorMode = ComponentFactory.Krypton.Navigator.NavigatorMode.HeaderBarCheckButtonHeaderGroup;
            this.kryptonNavigator1.PageBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.pgDBPermisos,
            this.pgReloj1,
            this.btnSearchFileReloj2,
            this.kryptonPage4});
            this.kryptonNavigator1.SelectedIndex = 1;
            this.kryptonNavigator1.Size = new System.Drawing.Size(445, 178);
            this.kryptonNavigator1.TabIndex = 0;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // pgDBPermisos
            // 
            this.pgDBPermisos.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pgDBPermisos.Controls.Add(this.txtPermisosPassword);
            this.pgDBPermisos.Controls.Add(this.txtPermisosFileName);
            this.pgDBPermisos.Controls.Add(this.kryptonLabel2);
            this.pgDBPermisos.Controls.Add(this.kryptonLabel1);
            this.pgDBPermisos.Flags = 65534;
            this.pgDBPermisos.LastVisibleSet = true;
            this.pgDBPermisos.MinimumSize = new System.Drawing.Size(50, 50);
            this.pgDBPermisos.Name = "pgDBPermisos";
            this.pgDBPermisos.Size = new System.Drawing.Size(443, 90);
            this.pgDBPermisos.Text = "Permisos";
            this.pgDBPermisos.TextDescription = "Muestra todas las configuraciones de la base de datos de permisos";
            this.pgDBPermisos.TextTitle = "Configurar Base de Datos de Permisos";
            this.pgDBPermisos.ToolTipTitle = "Page ToolTip";
            this.pgDBPermisos.UniqueName = "FD498693AD09466949BF22EC121EA2F0";
            // 
            // txtPermisosPassword
            // 
            this.txtPermisosPassword.Location = new System.Drawing.Point(77, 35);
            this.txtPermisosPassword.Name = "txtPermisosPassword";
            this.txtPermisosPassword.PasswordChar = '●';
            this.txtPermisosPassword.Size = new System.Drawing.Size(133, 20);
            this.txtPermisosPassword.TabIndex = 3;
            this.txtPermisosPassword.UseSystemPasswordChar = true;
            // 
            // txtPermisosFileName
            // 
            this.txtPermisosFileName.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchFilePermisos});
            this.txtPermisosFileName.Location = new System.Drawing.Point(77, 6);
            this.txtPermisosFileName.Name = "txtPermisosFileName";
            this.txtPermisosFileName.Size = new System.Drawing.Size(296, 24);
            this.txtPermisosFileName.TabIndex = 2;
            // 
            // btnSearchFilePermisos
            // 
            this.btnSearchFilePermisos.Image = global::ControlNominasAddIn.Properties.Resources.database_black;
            this.btnSearchFilePermisos.Tag = "permisos";
            this.btnSearchFilePermisos.UniqueName = "661F52CC6148412FED9FF6F24C04D39C";
            this.btnSearchFilePermisos.Click += new System.EventHandler(this.btnSearchFilePermisos_Click);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ItalicPanel;
            this.kryptonLabel2.Location = new System.Drawing.Point(8, 39);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Password:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ItalicPanel;
            this.kryptonLabel1.Location = new System.Drawing.Point(18, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Archivo:";
            // 
            // pgReloj1
            // 
            this.pgReloj1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pgReloj1.Controls.Add(this.txtReloj1Password);
            this.pgReloj1.Controls.Add(this.txtReloj1File);
            this.pgReloj1.Controls.Add(this.kryptonLabel3);
            this.pgReloj1.Controls.Add(this.kryptonLabel4);
            this.pgReloj1.Flags = 65534;
            this.pgReloj1.LastVisibleSet = true;
            this.pgReloj1.MinimumSize = new System.Drawing.Size(50, 50);
            this.pgReloj1.Name = "pgReloj1";
            this.pgReloj1.Size = new System.Drawing.Size(443, 90);
            this.pgReloj1.Text = "Reloj 1";
            this.pgReloj1.TextDescription = "Configurar Base de Datos del Reloj 1, debe ser NAC";
            this.pgReloj1.TextTitle = "Configurar Base de Datos del Reloj 1";
            this.pgReloj1.ToolTipTitle = "Page ToolTip";
            this.pgReloj1.UniqueName = "44485CEDB3224B4844897870ECF66221";
            // 
            // txtReloj1Password
            // 
            this.txtReloj1Password.Location = new System.Drawing.Point(77, 38);
            this.txtReloj1Password.Name = "txtReloj1Password";
            this.txtReloj1Password.PasswordChar = '●';
            this.txtReloj1Password.Size = new System.Drawing.Size(133, 20);
            this.txtReloj1Password.TabIndex = 7;
            this.txtReloj1Password.UseSystemPasswordChar = true;
            // 
            // txtReloj1File
            // 
            this.txtReloj1File.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchFileReloj1});
            this.txtReloj1File.Location = new System.Drawing.Point(77, 9);
            this.txtReloj1File.Name = "txtReloj1File";
            this.txtReloj1File.Size = new System.Drawing.Size(296, 24);
            this.txtReloj1File.TabIndex = 6;
            // 
            // btnSearchFileReloj1
            // 
            this.btnSearchFileReloj1.Image = global::ControlNominasAddIn.Properties.Resources.database_black;
            this.btnSearchFileReloj1.Tag = "reloj1";
            this.btnSearchFileReloj1.UniqueName = "661F52CC6148412FED9FF6F24C04D39C";
            this.btnSearchFileReloj1.Click += new System.EventHandler(this.btnSearchFilePermisos_Click);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ItalicPanel;
            this.kryptonLabel3.Location = new System.Drawing.Point(8, 41);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Password:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ItalicPanel;
            this.kryptonLabel4.Location = new System.Drawing.Point(18, 13);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel4.TabIndex = 4;
            this.kryptonLabel4.Values.Text = "Archivo:";
            // 
            // btnSearchFileReloj2
            // 
            this.btnSearchFileReloj2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.btnSearchFileReloj2.Controls.Add(this.txtReloj2Password);
            this.btnSearchFileReloj2.Controls.Add(this.txtReloj2File);
            this.btnSearchFileReloj2.Controls.Add(this.kryptonLabel5);
            this.btnSearchFileReloj2.Controls.Add(this.kryptonLabel6);
            this.btnSearchFileReloj2.Flags = 65534;
            this.btnSearchFileReloj2.LastVisibleSet = true;
            this.btnSearchFileReloj2.MinimumSize = new System.Drawing.Size(50, 50);
            this.btnSearchFileReloj2.Name = "btnSearchFileReloj2";
            this.btnSearchFileReloj2.Size = new System.Drawing.Size(443, 90);
            this.btnSearchFileReloj2.Text = "Reloj 2";
            this.btnSearchFileReloj2.TextDescription = "Configurar Base de Datos del Reloj 2, debe ser STK";
            this.btnSearchFileReloj2.TextTitle = "Configurar Base de Datos del Reloj 2";
            this.btnSearchFileReloj2.ToolTipTitle = "Page ToolTip";
            this.btnSearchFileReloj2.UniqueName = "CFCC72407CC549CFEEADE18E5C025B93";
            // 
            // txtReloj2Password
            // 
            this.txtReloj2Password.Location = new System.Drawing.Point(77, 36);
            this.txtReloj2Password.Name = "txtReloj2Password";
            this.txtReloj2Password.PasswordChar = '●';
            this.txtReloj2Password.Size = new System.Drawing.Size(133, 20);
            this.txtReloj2Password.TabIndex = 7;
            this.txtReloj2Password.UseSystemPasswordChar = true;
            // 
            // txtReloj2File
            // 
            this.txtReloj2File.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny2});
            this.txtReloj2File.Location = new System.Drawing.Point(77, 6);
            this.txtReloj2File.Name = "txtReloj2File";
            this.txtReloj2File.Size = new System.Drawing.Size(296, 24);
            this.txtReloj2File.TabIndex = 6;
            // 
            // buttonSpecAny2
            // 
            this.buttonSpecAny2.Image = global::ControlNominasAddIn.Properties.Resources.database_black;
            this.buttonSpecAny2.Tag = "reloj2";
            this.buttonSpecAny2.UniqueName = "661F52CC6148412FED9FF6F24C04D39C";
            this.buttonSpecAny2.Click += new System.EventHandler(this.btnSearchFilePermisos_Click);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ItalicPanel;
            this.kryptonLabel5.Location = new System.Drawing.Point(8, 39);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel5.TabIndex = 5;
            this.kryptonLabel5.Values.Text = "Password:";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ItalicPanel;
            this.kryptonLabel6.Location = new System.Drawing.Point(18, 10);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel6.TabIndex = 4;
            this.kryptonLabel6.Values.Text = "Archivo:";
            // 
            // kryptonPage4
            // 
            this.kryptonPage4.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage4.Controls.Add(this.kryptonLabel8);
            this.kryptonPage4.Controls.Add(this.kryptonLabel7);
            this.kryptonPage4.Controls.Add(this.kpSelectTheme);
            this.kryptonPage4.Controls.Add(this.txtClaveChofer);
            this.kryptonPage4.Flags = 65534;
            this.kryptonPage4.LastVisibleSet = true;
            this.kryptonPage4.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage4.Name = "kryptonPage4";
            this.kryptonPage4.Size = new System.Drawing.Size(443, 90);
            this.kryptonPage4.Text = "Otros";
            this.kryptonPage4.TextDescription = "Muestra algunas optras configuraciones del AddIn";
            this.kryptonPage4.TextTitle = "Otras Configuraciones";
            this.kryptonPage4.ToolTipTitle = "Page ToolTip";
            this.kryptonPage4.UniqueName = "12F142B5D2754294748FBAD7DAA65F3F";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ItalicPanel;
            this.kryptonLabel8.Location = new System.Drawing.Point(43, 39);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(43, 20);
            this.kryptonLabel8.TabIndex = 3;
            this.kryptonLabel8.Values.Text = "Tema:";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ItalicPanel;
            this.kryptonLabel7.Location = new System.Drawing.Point(8, 10);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(78, 20);
            this.kryptonLabel7.TabIndex = 2;
            this.kryptonLabel7.Values.Text = "ClaveChofer:";
            // 
            // kpSelectTheme
            // 
            this.kpSelectTheme.DropDownWidth = 215;
            this.kpSelectTheme.Location = new System.Drawing.Point(92, 36);
            this.kpSelectTheme.Name = "kpSelectTheme";
            this.kpSelectTheme.Size = new System.Drawing.Size(215, 21);
            this.kpSelectTheme.TabIndex = 1;
            // 
            // txtClaveChofer
            // 
            this.txtClaveChofer.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ControlNominasAddIn.Properties.Settings.Default, "claveChofer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtClaveChofer.Location = new System.Drawing.Point(92, 7);
            this.txtClaveChofer.Name = "txtClaveChofer";
            this.txtClaveChofer.Size = new System.Drawing.Size(100, 20);
            this.txtClaveChofer.TabIndex = 0;
            this.txtClaveChofer.Text = global::ControlNominasAddIn.Properties.Settings.Default.claveChofer;
            this.txtClaveChofer.Validating += new System.ComponentModel.CancelEventHandler(this.txtClaveChofer_Validating);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.dataBaseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(445, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = global::ControlNominasAddIn.Properties.Resources.diskette;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::ControlNominasAddIn.Properties.Resources.cross;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // dataBaseToolStripMenuItem
            // 
            this.dataBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarBaseDeDatosDePermisosToolStripMenuItem,
            this.seleccionarBaseDeDatosDelReloj1ToolStripMenuItem,
            this.seleccionarBaseDeDatosDelReloj2ToolStripMenuItem});
            this.dataBaseToolStripMenuItem.Name = "dataBaseToolStripMenuItem";
            this.dataBaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.dataBaseToolStripMenuItem.Text = "DataBase";
            // 
            // seleccionarBaseDeDatosDePermisosToolStripMenuItem
            // 
            this.seleccionarBaseDeDatosDePermisosToolStripMenuItem.Image = global::ControlNominasAddIn.Properties.Resources.database_black;
            this.seleccionarBaseDeDatosDePermisosToolStripMenuItem.Name = "seleccionarBaseDeDatosDePermisosToolStripMenuItem";
            this.seleccionarBaseDeDatosDePermisosToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.seleccionarBaseDeDatosDePermisosToolStripMenuItem.Text = "Seleccionar Base de Datos de Permisos";
            this.seleccionarBaseDeDatosDePermisosToolStripMenuItem.Click += new System.EventHandler(this.btnSearchFilePermisos_Click);
            // 
            // seleccionarBaseDeDatosDelReloj1ToolStripMenuItem
            // 
            this.seleccionarBaseDeDatosDelReloj1ToolStripMenuItem.Image = global::ControlNominasAddIn.Properties.Resources.database_black;
            this.seleccionarBaseDeDatosDelReloj1ToolStripMenuItem.Name = "seleccionarBaseDeDatosDelReloj1ToolStripMenuItem";
            this.seleccionarBaseDeDatosDelReloj1ToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.seleccionarBaseDeDatosDelReloj1ToolStripMenuItem.Text = "Seleccionar Base de Datos del Reloj 1";
            this.seleccionarBaseDeDatosDelReloj1ToolStripMenuItem.Click += new System.EventHandler(this.btnSearchFilePermisos_Click);
            // 
            // seleccionarBaseDeDatosDelReloj2ToolStripMenuItem
            // 
            this.seleccionarBaseDeDatosDelReloj2ToolStripMenuItem.Image = global::ControlNominasAddIn.Properties.Resources.database_black;
            this.seleccionarBaseDeDatosDelReloj2ToolStripMenuItem.Name = "seleccionarBaseDeDatosDelReloj2ToolStripMenuItem";
            this.seleccionarBaseDeDatosDelReloj2ToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.seleccionarBaseDeDatosDelReloj2ToolStripMenuItem.Text = "Seleccionar Base de Datos del Reloj2";
            this.seleccionarBaseDeDatosDelReloj2ToolStripMenuItem.Click += new System.EventHandler(this.btnSearchFilePermisos_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(445, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::ControlNominasAddIn.Properties.Resources.diskette;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(69, 22);
            this.toolStripButton1.Text = "Guardar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = global::ControlNominasAddIn.Properties.Settings.Default.Theme;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "mdb";
            this.openFileDialog1.Filter = "Microsoft Access(*.mdb)|*.mdb";
            // 
            // frmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 227);
            this.Controls.Add(this.kryptonNavigator1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.frmConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pgDBPermisos)).EndInit();
            this.pgDBPermisos.ResumeLayout(false);
            this.pgDBPermisos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pgReloj1)).EndInit();
            this.pgReloj1.ResumeLayout(false);
            this.pgReloj1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchFileReloj2)).EndInit();
            this.btnSearchFileReloj2.ResumeLayout(false);
            this.btnSearchFileReloj2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).EndInit();
            this.kryptonPage4.ResumeLayout(false);
            this.kryptonPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpSelectTheme)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
		private ComponentFactory.Krypton.Navigator.KryptonPage pgDBPermisos;
		private ComponentFactory.Krypton.Navigator.KryptonPage pgReloj1;
		private ComponentFactory.Krypton.Navigator.KryptonPage btnSearchFileReloj2;
		private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage4;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPermisosPassword;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPermisosFileName;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchFilePermisos;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dataBaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem seleccionarBaseDeDatosDePermisosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem seleccionarBaseDeDatosDelReloj1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem seleccionarBaseDeDatosDelReloj2ToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtReloj1Password;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtReloj1File;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchFileReloj1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtReloj2Password;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtReloj2File;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny2;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtClaveChofer;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox kpSelectTheme;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}