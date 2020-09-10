namespace EstacionPesaje.Pages.MainPages {
	partial class ViewOTPage {
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.txtOT = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnTodas = new System.Windows.Forms.ToolStripButton();
			this.btnImpresion = new System.Windows.Forms.ToolStripButton();
			this.btnLaminacion = new System.Windows.Forms.ToolStripButton();
			this.btnRefinado = new System.Windows.Forms.ToolStripButton();
			this.btnEmbobinado = new System.Windows.Forms.ToolStripButton();
			this.btnSellado = new System.Windows.Forms.ToolStripButton();
			this.btnCorte = new System.Windows.Forms.ToolStripButton();
			this.btnDoblado = new System.Windows.Forms.ToolStripButton();
			this.btnExtrusion = new System.Windows.Forms.ToolStripButton();
			this.btnMangas = new System.Windows.Forms.ToolStripButton();
			this.ordenTrabajo_ReportViewer1 = new libProduccionDataBase.Reportes.OrdenTrabajo_ReportViewer();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtOT,
            this.toolStripSeparator1,
            this.btnTodas,
            this.btnImpresion,
            this.btnLaminacion,
            this.btnRefinado,
            this.btnEmbobinado,
            this.btnSellado,
            this.btnCorte,
            this.btnDoblado,
            this.btnExtrusion,
            this.btnMangas});
			this.toolStrip1.Location = new System.Drawing.Point(5, 5);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(80, 608);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "Ordenes de Trabajo";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(77, 21);
			this.toolStripLabel1.Text = "OT:";
			// 
			// txtOT
			// 
			this.txtOT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtOT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.txtOT.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.txtOT.Name = "txtOT";
			this.txtOT.Size = new System.Drawing.Size(75, 27);
			this.txtOT.ToolTipText = "OT";
			this.txtOT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOT_KeyDown);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(77, 6);
			// 
			// btnTodas
			// 
			this.btnTodas.Image = global::EstacionPesaje.Properties.Resources.OTICON;
			this.btnTodas.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTodas.Name = "btnTodas";
			this.btnTodas.Size = new System.Drawing.Size(77, 49);
			this.btnTodas.Text = "Todas";
			this.btnTodas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnTodas.Click += new System.EventHandler(this.btnTodas_Click);
			// 
			// btnImpresion
			// 
			this.btnImpresion.Image = global::EstacionPesaje.Properties.Resources.IMPRESION;
			this.btnImpresion.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImpresion.Name = "btnImpresion";
			this.btnImpresion.Size = new System.Drawing.Size(77, 49);
			this.btnImpresion.Tag = "Impresion";
			this.btnImpresion.Text = "Impresión";
			this.btnImpresion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnImpresion.Click += new System.EventHandler(this.OpenOrder_Click_1);
			// 
			// btnLaminacion
			// 
			this.btnLaminacion.Image = global::EstacionPesaje.Properties.Resources.LAMINACION;
			this.btnLaminacion.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnLaminacion.Name = "btnLaminacion";
			this.btnLaminacion.Size = new System.Drawing.Size(77, 49);
			this.btnLaminacion.Tag = "Laminacion";
			this.btnLaminacion.Text = "Laminación";
			this.btnLaminacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnLaminacion.Click += new System.EventHandler(this.OpenOrder_Click_1);
			// 
			// btnRefinado
			// 
			this.btnRefinado.Image = global::EstacionPesaje.Properties.Resources.REFINADO;
			this.btnRefinado.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRefinado.Name = "btnRefinado";
			this.btnRefinado.Size = new System.Drawing.Size(77, 49);
			this.btnRefinado.Tag = "Refinado";
			this.btnRefinado.Text = "Refinado";
			this.btnRefinado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnRefinado.Click += new System.EventHandler(this.OpenOrder_Click_1);
			// 
			// btnEmbobinado
			// 
			this.btnEmbobinado.Image = global::EstacionPesaje.Properties.Resources.EMBOBINADO;
			this.btnEmbobinado.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEmbobinado.Name = "btnEmbobinado";
			this.btnEmbobinado.Size = new System.Drawing.Size(77, 49);
			this.btnEmbobinado.Tag = "Embobinado";
			this.btnEmbobinado.Text = "Embobinado";
			this.btnEmbobinado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEmbobinado.Click += new System.EventHandler(this.OpenOrder_Click_1);
			// 
			// btnSellado
			// 
			this.btnSellado.Image = global::EstacionPesaje.Properties.Resources.PEGADO;
			this.btnSellado.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSellado.Name = "btnSellado";
			this.btnSellado.Size = new System.Drawing.Size(77, 49);
			this.btnSellado.Tag = "Sellado";
			this.btnSellado.Text = "Sellado";
			this.btnSellado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnSellado.Click += new System.EventHandler(this.OpenOrder_Click_1);
			// 
			// btnCorte
			// 
			this.btnCorte.Image = global::EstacionPesaje.Properties.Resources.CORTE;
			this.btnCorte.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCorte.Name = "btnCorte";
			this.btnCorte.Size = new System.Drawing.Size(77, 49);
			this.btnCorte.Tag = "Corte";
			this.btnCorte.Text = "Corte";
			this.btnCorte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnCorte.Click += new System.EventHandler(this.OpenOrder_Click_1);
			// 
			// btnDoblado
			// 
			this.btnDoblado.Image = global::EstacionPesaje.Properties.Resources.DOBLADO;
			this.btnDoblado.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDoblado.Name = "btnDoblado";
			this.btnDoblado.Size = new System.Drawing.Size(77, 49);
			this.btnDoblado.Tag = "Doblado";
			this.btnDoblado.Text = "Doblado";
			this.btnDoblado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnDoblado.Click += new System.EventHandler(this.OpenOrder_Click_1);
			// 
			// btnExtrusion
			// 
			this.btnExtrusion.AutoSize = false;
			this.btnExtrusion.Image = global::EstacionPesaje.Properties.Resources.EXTRUSION;
			this.btnExtrusion.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExtrusion.Name = "btnExtrusion";
			this.btnExtrusion.Size = new System.Drawing.Size(60, 50);
			this.btnExtrusion.Tag = "Extrusion";
			this.btnExtrusion.Text = "Extrusión";
			this.btnExtrusion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnExtrusion.Click += new System.EventHandler(this.OpenOrder_Click_1);
			// 
			// btnMangas
			// 
			this.btnMangas.Image = global::EstacionPesaje.Properties.Resources.MANGAS;
			this.btnMangas.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnMangas.Name = "btnMangas";
			this.btnMangas.Size = new System.Drawing.Size(77, 49);
			this.btnMangas.Tag = "Mangas";
			this.btnMangas.Text = "Mangas";
			this.btnMangas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnMangas.Click += new System.EventHandler(this.OpenOrder_Click_1);
			// 
			// ordenTrabajo_ReportViewer1
			// 
			this.ordenTrabajo_ReportViewer1.IsDocumentMapWidthFixed = true;
			this.ordenTrabajo_ReportViewer1.Location = new System.Drawing.Point(85, 5);
			this.ordenTrabajo_ReportViewer1.MapWidth = 150;
			this.ordenTrabajo_ReportViewer1.Name = "ordenTrabajo_ReportViewer1";
			this.ordenTrabajo_ReportViewer1.OT = null;
			this.ordenTrabajo_ReportViewer1.Proceso = libProduccionDataBase.Reportes.Models.OrdenTrabajoModel.Procesos.Progreso;
			this.ordenTrabajo_ReportViewer1.Size = new System.Drawing.Size(760, 608);
			this.ordenTrabajo_ReportViewer1.TabIndex = 3;
			// 
			// ViewOTPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ordenTrabajo_ReportViewer1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "ViewOTPage";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.PageTitleText = "Orden de Trabajo ";
			this.Size = new System.Drawing.Size(850, 618);
			this.Load += new System.EventHandler(this.ViewOTPage_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripTextBox txtOT;
		private System.Windows.Forms.ToolStripButton btnLaminacion;
		private System.Windows.Forms.ToolStripButton btnTodas;
		private System.Windows.Forms.ToolStripButton btnImpresion;
		private System.Windows.Forms.ToolStripButton btnRefinado;
		private libProduccionDataBase.Reportes.OrdenTrabajo_ReportViewer ordenTrabajo_ReportViewer1;
		private System.Windows.Forms.ToolStripButton btnEmbobinado;
		private System.Windows.Forms.ToolStripButton btnSellado;
		private System.Windows.Forms.ToolStripButton btnCorte;
		private System.Windows.Forms.ToolStripButton btnDoblado;
		private System.Windows.Forms.ToolStripButton btnExtrusion;
		private System.Windows.Forms.ToolStripButton btnMangas;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}
