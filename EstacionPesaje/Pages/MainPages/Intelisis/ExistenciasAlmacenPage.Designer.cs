namespace EstacionPesaje.Pages.MainPages.Intelisis {
	partial class ExistenciasAlmacenPage {
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
			this.ctlExistencias1 = new TRYINTELISISSELECTCTL.ctlExistencias();
			this.SuspendLayout();
			// 
			// ctlExistencias1
			// 
			this.ctlExistencias1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctlExistencias1.Location = new System.Drawing.Point(5, 5);
			this.ctlExistencias1.Name = "ctlExistencias1";
			this.ctlExistencias1.Size = new System.Drawing.Size(388, 358);
			this.ctlExistencias1.TabIndex = 0;
			this.ctlExistencias1.changeAlamacen += new System.EventHandler<string>(this.ctlExistencias1_changeAlamacen);
			// 
			// ExistenciasAlmacenPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ctlExistencias1);
			this.Name = "ExistenciasAlmacenPage";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.ResumeLayout(false);

		}

		#endregion

		private TRYINTELISISSELECTCTL.ctlExistencias ctlExistencias1;
	}
}
