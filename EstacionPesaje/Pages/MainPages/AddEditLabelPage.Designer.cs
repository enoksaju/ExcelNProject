namespace EstacionesPesaje.Pages.MainPages {
	partial class AddEditLabelPage {
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

		#region Código generado por el Diseñador de componentes

		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent () {
			this.components = new System.ComponentModel.Container();
			this.zplCodeEditor1 = new libControlesPersonalizados.ZPLCodeEditor();
			this.etiquetaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.nombreKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			((System.ComponentModel.ISupportInitialize)(this.etiquetaBindingSource)).BeginInit();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// zplCodeEditor1
			// 
			this.zplCodeEditor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.zplCodeEditor1.DataBindings.Add(new System.Windows.Forms.Binding("ZPLText", this.etiquetaBindingSource, "ZPLCode", true));
			this.zplCodeEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zplCodeEditor1.HeightLabel = 2D;
			this.zplCodeEditor1.Location = new System.Drawing.Point(5, 70);
			this.zplCodeEditor1.Name = "zplCodeEditor1";
			this.zplCodeEditor1.ScaleLabel = 1D;
			this.zplCodeEditor1.ShowPreview = false;
			this.zplCodeEditor1.ShowToolStrip = false;
			this.zplCodeEditor1.Size = new System.Drawing.Size(604, 440);
			this.zplCodeEditor1.TabIndex = 0;
			this.zplCodeEditor1.WidthLabel = 4D;
			this.zplCodeEditor1.ZPLText = "\r\n^FX\r\n              Autor: Excel Nobleza\r\n        Descripción: Etiqueta ***\r\n   " +
    "         Cliente:\r\n Nombre del Archivo:\r\n^FS\r\n\r\n^XA\r\n\r\n    ^FX Ingrese el codigo" +
    " de la etiqueta aqui ^FS\r\n\r\n^XZ";
			// 
			// etiquetaBindingSource
			// 
			this.etiquetaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Etiqueta);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
			this.toolStrip1.Location = new System.Drawing.Point(5, 5);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(604, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Image = global::EstacionesPesaje.Properties.Resources.database_restore;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(161, 22);
			this.toolStripButton1.Text = "Guardar en Base de Datos";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// nombreKryptonTextBox
			// 
			this.nombreKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.etiquetaBindingSource, "Nombre", true));
			this.nombreKryptonTextBox.Location = new System.Drawing.Point(102, 12);
			this.nombreKryptonTextBox.Name = "nombreKryptonTextBox";
			this.nombreKryptonTextBox.Size = new System.Drawing.Size(195, 23);
			this.nombreKryptonTextBox.TabIndex = 4;
			this.nombreKryptonTextBox.Text = "kryptonTextBox1";
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Location = new System.Drawing.Point(40, 12);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(56, 20);
			this.kryptonLabel1.TabIndex = 5;
			this.kryptonLabel1.Values.Text = "Nombre";
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.nombreKryptonTextBox);
			this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.kryptonPanel1.Location = new System.Drawing.Point(5, 30);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(604, 40);
			this.kryptonPanel1.TabIndex = 6;
			// 
			// AddEditLabelPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.zplCodeEditor1);
			this.Controls.Add(this.kryptonPanel1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "AddEditLabelPage";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Size = new System.Drawing.Size(614, 515);
			this.Load += new System.EventHandler(this.AddEditLabelPage_Load);
			((System.ComponentModel.ISupportInitialize)(this.etiquetaBindingSource)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private libControlesPersonalizados.ZPLCodeEditor zplCodeEditor1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.BindingSource etiquetaBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox nombreKryptonTextBox;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
	}
}
