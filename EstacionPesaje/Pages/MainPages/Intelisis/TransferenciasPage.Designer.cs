namespace EstacionPesaje.Pages.MainPages.Intelisis {
	partial class TransferenciasPage {
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
			this.ctlMoviminetosFechaLinea1 = new TRYINTELISISSELECTCTL.ctlMoviminetosFechaLinea();
			this.SuspendLayout();
			// 
			// ctlMoviminetosFechaLinea1
			// 
			this.ctlMoviminetosFechaLinea1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctlMoviminetosFechaLinea1.Location = new System.Drawing.Point(5, 5);
			this.ctlMoviminetosFechaLinea1.Name = "ctlMoviminetosFechaLinea1";
			this.ctlMoviminetosFechaLinea1.Padding = new System.Windows.Forms.Padding(5);
			this.ctlMoviminetosFechaLinea1.Size = new System.Drawing.Size(548, 452);
			this.ctlMoviminetosFechaLinea1.TabIndex = 0;
			this.ctlMoviminetosFechaLinea1.changedLinea += new System.EventHandler<string>(this.ctlMoviminetosFechaLinea1_changedLinea);
			// 
			// TransferenciasPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.ctlMoviminetosFechaLinea1);
			this.Name = "TransferenciasPage";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Size = new System.Drawing.Size(558, 462);
			this.ResumeLayout(false);

		}

		#endregion

		private TRYINTELISISSELECTCTL.ctlMoviminetosFechaLinea ctlMoviminetosFechaLinea1;
	}
}
