namespace EstacionPesaje.Pages.MainPages.Intelisis {
	partial class CierreOrdenesPage {
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
			this.ctlCierreOrdenes1 = new libIntelisisReports.Controles.ctlCierreOrdenes();
			this.SuspendLayout();
			// 
			// ctlCierreOrdenes1
			// 
			this.ctlCierreOrdenes1.Location = new System.Drawing.Point(5, 5);
			this.ctlCierreOrdenes1.Name = "ctlCierreOrdenes1";
			this.ctlCierreOrdenes1.OT = null;
			this.ctlCierreOrdenes1.Size = new System.Drawing.Size(517, 439);
			this.ctlCierreOrdenes1.TabIndex = 0;
			this.ctlCierreOrdenes1.changedOT += new System.EventHandler<string>(this.movimientosOT1_changedOT);
			// 
			// CierreOrdenesPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ctlCierreOrdenes1);
			this.Name = "CierreOrdenesPage";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Size = new System.Drawing.Size(527, 449);
			this.ResumeLayout(false);

		}

		#endregion

		private libIntelisisReports.Controles.ctlCierreOrdenes ctlCierreOrdenes1;
	}
}
