namespace EstacionesPesaje.Pages.MainPages {
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
			this.ctlEmptyOTs1 = new libReportsOTS.ctlEmptyOTs();
			this.SuspendLayout();
			// 
			// ctlEmptyOTs1
			// 
			this.ctlEmptyOTs1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctlEmptyOTs1.Location = new System.Drawing.Point(5, 5);
			this.ctlEmptyOTs1.Name = "ctlEmptyOTs1";
			this.ctlEmptyOTs1.Size = new System.Drawing.Size(546, 436);
			this.ctlEmptyOTs1.TabIndex = 0;
			this.ctlEmptyOTs1.ChangeOT += new libReportsOTS.ctlEmptyOTs.ChangeOTEventHandler(this.ctlEmptyOTs1_ChangeOT);
			// 
			// ViewOTPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ctlEmptyOTs1);
			this.Name = "ViewOTPage";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.PageTitleText = "Orden de Trabajo ";
			this.Size = new System.Drawing.Size(556, 446);
			this.ResumeLayout(false);

		}

		#endregion

		private libReportsOTS.ctlEmptyOTs ctlEmptyOTs1;
	}
}
