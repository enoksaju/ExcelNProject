namespace EstacionesPesaje.Pages.Config {
	partial class ConfigBasculaPage {
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
			this.FilterPropertyGrid = new Azuria.Common.Controls.FilteredPropertyGrid();
			this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.SuspendLayout();
			// 
			// FilterPropertyGrid
			// 
			this.FilterPropertyGrid.BrowsableProperties = null;
			this.FilterPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FilterPropertyGrid.HiddenAttributes = null;
			this.FilterPropertyGrid.HiddenProperties = null;
			this.FilterPropertyGrid.Location = new System.Drawing.Point(5, 5);
			this.FilterPropertyGrid.Name = "FilterPropertyGrid";
			this.FilterPropertyGrid.Size = new System.Drawing.Size(289, 453);
			this.FilterPropertyGrid.TabIndex = 0;
			// 
			// kryptonTextBox1
			// 
			this.kryptonTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.kryptonTextBox1.Location = new System.Drawing.Point(5, 458);
			this.kryptonTextBox1.Name = "kryptonTextBox1";
			this.kryptonTextBox1.Size = new System.Drawing.Size(289, 23);
			this.kryptonTextBox1.TabIndex = 1;
			// 
			// ConfigBasculaPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.FilterPropertyGrid);
			this.Controls.Add(this.kryptonTextBox1);
			this.Name = "ConfigBasculaPage";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.PageTitleText = "Configuración de Bascula";
			this.Size = new System.Drawing.Size(299, 486);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private Azuria.Common.Controls.FilteredPropertyGrid FilterPropertyGrid;
		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
	}
}
