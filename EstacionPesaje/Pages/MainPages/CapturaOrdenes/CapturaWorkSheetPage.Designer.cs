namespace EstacionPesaje.Pages.MainPages.CapturaOrdenes {
	partial class CapturaWorkSheetPage {
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
			//this.insertarnuevaotTableAdapter1 = new CapturaTabla.DataSet1TableAdapters.INSERTARNUEVAOTTableAdapter();
			this.capturaOts_ctrl1 = new libControlesCapturaOrdenes.CapturaOts_ctrl();
			this.SuspendLayout();
			// 
			// insertarnuevaotTableAdapter1
			// 
			//this.insertarnuevaotTableAdapter1.ClearBeforeFill = true;
			// 
			// capturaOts_ctrl1
			// 
			this.capturaOts_ctrl1.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlGroupBox;
			this.capturaOts_ctrl1.BorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlGroupBox;
			this.capturaOts_ctrl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.capturaOts_ctrl1.Location = new System.Drawing.Point(0, 0);
			this.capturaOts_ctrl1.Name = "capturaOts_ctrl1";
			this.capturaOts_ctrl1.Padding = new System.Windows.Forms.Padding(5);
			this.capturaOts_ctrl1.Size = new System.Drawing.Size(599, 478);
			this.capturaOts_ctrl1.TabIndex = 0;
			// 
			// CapturaWorkSheetPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.capturaOts_ctrl1);
			this.Name = "CapturaWorkSheetPage";
			this.Size = new System.Drawing.Size(599, 478);
			this.ResumeLayout(false);

		}

		#endregion

		//private CapturaTabla.DataSet1TableAdapters.INSERTARNUEVAOTTableAdapter insertarnuevaotTableAdapter1;
		private libControlesCapturaOrdenes.CapturaOts_ctrl capturaOts_ctrl1;
	}
}
