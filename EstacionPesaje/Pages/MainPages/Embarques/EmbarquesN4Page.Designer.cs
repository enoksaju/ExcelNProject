namespace EstacionPesaje.Pages.MainPages.Embarques {
	partial class EmbarquesN4Page {
		/// <summary> 
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose ( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Código generado por el Diseñador de componentes

		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent ( ) {
			this.crearPapeletaTarima1 = new libEmbarquesNCuatro.WinForms.Controls.CrearPapeletaTarima();
			this.SuspendLayout();
			// 
			// crearPapeletaTarima1
			// 
			this.crearPapeletaTarima1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crearPapeletaTarima1.Location = new System.Drawing.Point(0, 0);
			this.crearPapeletaTarima1.Name = "crearPapeletaTarima1";
			this.crearPapeletaTarima1.Size = new System.Drawing.Size(677, 486);
			this.crearPapeletaTarima1.TabIndex = 0;
			// 
			// EmbarquesN4Page
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.crearPapeletaTarima1);
			this.Name = "EmbarquesN4Page";
			this.Size = new System.Drawing.Size(677, 486);
			this.ResumeLayout(false);

		}

		#endregion

		private libEmbarquesNCuatro.WinForms.Controls.CrearPapeletaTarima crearPapeletaTarima1;
	}
}
