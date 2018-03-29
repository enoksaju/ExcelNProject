namespace libControlesCapturaOrdenes {
	partial class CapturaOts_ctrl {
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
			this.reoGridControl1 = new unvell.ReoGrid.ReoGridControl();
			this.SuspendLayout();
			// 
			// reoGridControl1
			// 
			this.reoGridControl1.BackColor = System.Drawing.Color.White;
			this.reoGridControl1.ColumnHeaderContextMenuStrip = null;
			this.reoGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.reoGridControl1.LeadHeaderContextMenuStrip = null;
			this.reoGridControl1.Location = new System.Drawing.Point(5, 5);
			this.reoGridControl1.Name = "reoGridControl1";
			this.reoGridControl1.RowHeaderContextMenuStrip = null;
			this.reoGridControl1.Script = null;
			this.reoGridControl1.SheetTabContextMenuStrip = null;
			this.reoGridControl1.SheetTabNewButtonVisible = false;
			this.reoGridControl1.SheetTabVisible = false;
			this.reoGridControl1.SheetTabWidth = 120;
			this.reoGridControl1.ShowScrollEndSpacing = true;
			this.reoGridControl1.Size = new System.Drawing.Size(589, 451);
			this.reoGridControl1.TabIndex = 0;
			this.reoGridControl1.Text = "reoGridControl1";
			// 
			// CapturaOts_ctrl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.reoGridControl1);
			this.Name = "CapturaOts_ctrl";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Size = new System.Drawing.Size(599, 461);
			this.Load += new System.EventHandler(this.CapturaOts_ctrl_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private unvell.ReoGrid.ReoGridControl reoGridControl1;
	}
}
