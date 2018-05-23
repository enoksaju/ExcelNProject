namespace ControlTintas.Pages.Pages {
	partial class CatalogoArticulo {
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
			this.components = new System.ComponentModel.Container();
			this.articuloTintaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tiposTintaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.articuloTintaKryptonDataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.articuloTintaBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tiposTintaBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.articuloTintaKryptonDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// articuloTintaBindingSource
			// 
			this.articuloTintaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.ArticuloTinta);
			// 
			// tiposTintaBindingSource
			// 
			this.tiposTintaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.TiposTinta);
			// 
			// articuloTintaKryptonDataGridView
			// 
			this.articuloTintaKryptonDataGridView.AllowUserToAddRows = false;
			this.articuloTintaKryptonDataGridView.AllowUserToDeleteRows = false;
			this.articuloTintaKryptonDataGridView.AllowUserToOrderColumns = true;
			this.articuloTintaKryptonDataGridView.AutoGenerateColumns = false;
			this.articuloTintaKryptonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.articuloTintaKryptonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
			this.articuloTintaKryptonDataGridView.DataSource = this.articuloTintaBindingSource;
			this.articuloTintaKryptonDataGridView.Location = new System.Drawing.Point(17, 66);
			this.articuloTintaKryptonDataGridView.Name = "articuloTintaKryptonDataGridView";
			this.articuloTintaKryptonDataGridView.Size = new System.Drawing.Size(643, 441);
			this.articuloTintaKryptonDataGridView.TabIndex = 0;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Clave";
			this.dataGridViewTextBoxColumn1.HeaderText = "Clave";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Descripcion";
			this.dataGridViewTextBoxColumn2.HeaderText = "Descripcion";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "Tipo";
			this.dataGridViewTextBoxColumn4.HeaderText = "Tipo";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.DataPropertyName = "Existencias";
			this.dataGridViewTextBoxColumn5.HeaderText = "Existencias";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			// 
			// CatalogoArticulo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.articuloTintaKryptonDataGridView);
			this.Name = "CatalogoArticulo";
			this.PageDescriptionText = "Formulario Que muestra el Catalogo de Las Tintas Disponibles.";
			this.PageImageLarge = global::ControlTintas.Properties.Resources.paintcan1;
			this.PageImageSmall = global::ControlTintas.Properties.Resources.paintcan;
			this.PageTitleText = "Catalogo de Tintas";
			this.Size = new System.Drawing.Size(672, 522);
			((System.ComponentModel.ISupportInitialize)(this.articuloTintaBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tiposTintaBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.articuloTintaKryptonDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.BindingSource articuloTintaBindingSource;
		private System.Windows.Forms.BindingSource tiposTintaBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView articuloTintaKryptonDataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
	}
}
