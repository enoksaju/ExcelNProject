namespace EstacionPesaje.Pages.MainPages.Produccion {
	partial class progresoOTPage {
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
			this.ordenTrabajo_ReportViewer1 = new libProduccionDataBase.Reportes.OrdenTrabajo_ReportViewer();
			this.SuspendLayout();
			// 
			// ordenTrabajo_ReportViewer1
			// 
			this.ordenTrabajo_ReportViewer1.Location = new System.Drawing.Point(0, 0);
			this.ordenTrabajo_ReportViewer1.Name = "ordenTrabajo_ReportViewer1";
			this.ordenTrabajo_ReportViewer1.Size = new System.Drawing.Size(705, 499);
			this.ordenTrabajo_ReportViewer1.TabIndex = 0;
			// 
			// progresoOTPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.ordenTrabajo_ReportViewer1);
			this.Name = "progresoOTPage";
			this.Size = new System.Drawing.Size(705, 499);
			this.Load += new System.EventHandler(this.progresoOTPage_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private libProduccionDataBase.Reportes.OrdenTrabajo_ReportViewer ordenTrabajo_ReportViewer1;
	}
}
