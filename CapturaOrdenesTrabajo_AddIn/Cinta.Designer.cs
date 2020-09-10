namespace CapturaOrdenesTrabajo_AddIn
{
	partial class Cinta : Microsoft.Office.Tools.Ribbon.RibbonBase
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Cinta ()
			: base ( Globals.Factory.GetRibbonFactory ( ) )
		{
			InitializeComponent ( );
		}

		/// <summary> 
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Código generado por el Diseñador de componentes

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent ()
		{
			this.CapturaOrdenes = this.Factory.CreateRibbonTab();
			this.group1 = this.Factory.CreateRibbonGroup();
			this.btnCrearActualizar = this.Factory.CreateRibbonButton();
			this.btnLimpiar = this.Factory.CreateRibbonButton();
			this.btnBuscar = this.Factory.CreateRibbonButton();
			this.separator1 = this.Factory.CreateRibbonSeparator();
			this.btnAbrir = this.Factory.CreateRibbonButton();
			this.btnGuardarLibro = this.Factory.CreateRibbonButton();
			this.menuOpciones = this.Factory.CreateRibbonMenu();
			this.chkGuardarALEnviar = this.Factory.CreateRibbonCheckBox();
			this.chkCrearActualizar = this.Factory.CreateRibbonCheckBox();
			this.btnConfigurar = this.Factory.CreateRibbonButton();
			this.CapturaOrdenes.SuspendLayout();
			this.group1.SuspendLayout();
			this.SuspendLayout();
			// 
			// CapturaOrdenes
			// 
			this.CapturaOrdenes.Groups.Add(this.group1);
			this.CapturaOrdenes.Label = "Captura de Ordenes";
			this.CapturaOrdenes.Name = "CapturaOrdenes";
			// 
			// group1
			// 
			this.group1.Items.Add(this.btnCrearActualizar);
			this.group1.Items.Add(this.btnLimpiar);
			this.group1.Items.Add(this.btnBuscar);
			this.group1.Items.Add(this.separator1);
			this.group1.Items.Add(this.btnAbrir);
			this.group1.Items.Add(this.btnGuardarLibro);
			this.group1.Items.Add(this.menuOpciones);
			this.group1.Name = "group1";
			// 
			// btnCrearActualizar
			// 
			this.btnCrearActualizar.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.btnCrearActualizar.Enabled = global::CapturaOrdenesTrabajo_AddIn.Properties.Settings.Default.EnableCrear;
			this.btnCrearActualizar.Image = global::CapturaOrdenesTrabajo_AddIn.Properties.Resources.add2;
			this.btnCrearActualizar.Label = "Crear/ Actualizar";
			this.btnCrearActualizar.Name = "btnCrearActualizar";
			this.btnCrearActualizar.ShowImage = true;
			this.btnCrearActualizar.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCrearActualizar_Click);
			// 
			// btnLimpiar
			// 
			this.btnLimpiar.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.btnLimpiar.Image = global::CapturaOrdenesTrabajo_AddIn.Properties.Resources.erase;
			this.btnLimpiar.Label = "Limpiar";
			this.btnLimpiar.Name = "btnLimpiar";
			this.btnLimpiar.ShowImage = true;
			this.btnLimpiar.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnLimpiar_Click);
			// 
			// btnBuscar
			// 
			this.btnBuscar.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.btnBuscar.Image = global::CapturaOrdenesTrabajo_AddIn.Properties.Resources.magnifying_glass;
			this.btnBuscar.Label = "Buscar";
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.ShowImage = true;
			this.btnBuscar.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnBuscar_Click);
			// 
			// separator1
			// 
			this.separator1.Name = "separator1";
			// 
			// btnAbrir
			// 
			this.btnAbrir.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.btnAbrir.Image = global::CapturaOrdenesTrabajo_AddIn.Properties.Resources.document;
			this.btnAbrir.Label = "Abrir Plantilla";
			this.btnAbrir.Name = "btnAbrir";
			this.btnAbrir.ShowImage = true;
			this.btnAbrir.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAbrir_Click);
			// 
			// btnGuardarLibro
			// 
			this.btnGuardarLibro.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.btnGuardarLibro.Enabled = global::CapturaOrdenesTrabajo_AddIn.Properties.Settings.Default.AutomaticSaveBook;
			this.btnGuardarLibro.Image = global::CapturaOrdenesTrabajo_AddIn.Properties.Resources.book_2;
			this.btnGuardarLibro.Label = "Guardar Libro";
			this.btnGuardarLibro.Name = "btnGuardarLibro";
			this.btnGuardarLibro.ShowImage = true;
			this.btnGuardarLibro.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnGuardarLibro_Click);
			// 
			// menuOpciones
			// 
			this.menuOpciones.Image = global::CapturaOrdenesTrabajo_AddIn.Properties.Resources.adjustment;
			this.menuOpciones.Items.Add(this.chkGuardarALEnviar);
			this.menuOpciones.Items.Add(this.chkCrearActualizar);
			this.menuOpciones.Items.Add(this.btnConfigurar);
			this.menuOpciones.Label = "Opciones";
			this.menuOpciones.Name = "menuOpciones";
			this.menuOpciones.ShowImage = true;
			// 
			// chkGuardarALEnviar
			// 
			this.chkGuardarALEnviar.Checked = global::CapturaOrdenesTrabajo_AddIn.Properties.Settings.Default.AutomaticSaveBook;
			this.chkGuardarALEnviar.Label = "Guardar libro manualmente ";
			this.chkGuardarALEnviar.Name = "chkGuardarALEnviar";
			this.chkGuardarALEnviar.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.chkGuardarALEnviar_Click);
			// 
			// chkCrearActualizar
			// 
			this.chkCrearActualizar.Checked = global::CapturaOrdenesTrabajo_AddIn.Properties.Settings.Default.EnableCrear;
			this.chkCrearActualizar.Label = "Permitir crear y actualizar";
			this.chkCrearActualizar.Name = "chkCrearActualizar";
			this.chkCrearActualizar.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.chkCrearActualizar_Click);
			// 
			// btnConfigurar
			// 
			this.btnConfigurar.Image = global::CapturaOrdenesTrabajo_AddIn.Properties.Resources.cog_gear;
			this.btnConfigurar.Label = "Configurar Plantilla";
			this.btnConfigurar.Name = "btnConfigurar";
			this.btnConfigurar.ShowImage = true;
			this.btnConfigurar.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnConfigurar_Click);
			// 
			// Cinta
			// 
			this.Name = "Cinta";
			this.RibbonType = "Microsoft.Excel.Workbook";
			this.Tabs.Add(this.CapturaOrdenes);
			this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Cinta_Load);
			this.CapturaOrdenes.ResumeLayout(false);
			this.CapturaOrdenes.PerformLayout();
			this.group1.ResumeLayout(false);
			this.group1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		internal Microsoft.Office.Tools.Ribbon.RibbonTab CapturaOrdenes;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCrearActualizar;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnLimpiar;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnBuscar;
		internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAbrir;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnGuardarLibro;
		internal Microsoft.Office.Tools.Ribbon.RibbonMenu menuOpciones;
		internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox chkGuardarALEnviar;
		internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox chkCrearActualizar;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnConfigurar;
	}

	partial class ThisRibbonCollection
	{
		internal Cinta Cinta
		{
			get { return this.GetRibbon<Cinta> ( ); }
		}
	}
}
