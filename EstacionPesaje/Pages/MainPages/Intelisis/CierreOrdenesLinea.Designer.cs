namespace EstacionPesaje.Pages.MainPages.Intelisis
{
	partial class CierreOrdenesLinea
	{
		/// <summary> 
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			this.transferenciasOT1 = new libIntelisisReports.Controles.TransferenciasOT();
			this.SuspendLayout();
			// 
			// transferenciasOT1
			// 
			this.transferenciasOT1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.transferenciasOT1.Location = new System.Drawing.Point(0, 0);
			this.transferenciasOT1.Name = "transferenciasOT1";
			this.transferenciasOT1.Size = new System.Drawing.Size(624, 400);
			this.transferenciasOT1.TabIndex = 0;
			this.transferenciasOT1.ChangedOT += new libIntelisisReports.Controles.TransferenciasOT.OnRefreshOT(this.transferenciasOT1_ChangedOT);
			this.transferenciasOT1.ChangedMsg += new libIntelisisReports.Controles.TransferenciasOT.OnChengeMsg(this.transferenciasOT1_ChangedMsg);
			// 
			// CierreOrdenesLinea
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.transferenciasOT1);
			this.Name = "CierreOrdenesLinea";
			this.Size = new System.Drawing.Size(624, 400);
			this.ResumeLayout(false);

		}

		#endregion

		private libIntelisisReports.Controles.TransferenciasOT transferenciasOT1;
	}
}
