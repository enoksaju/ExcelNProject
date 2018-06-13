namespace ControlNominasAddIn.Forms {
	partial class frmImportarPermisos {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( ) {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportarPermisos));
			this.clDateRange = new System.Windows.Forms.MonthCalendar();
			this.btnImportar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// clDateRange
			// 
			this.clDateRange.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clDateRange.Location = new System.Drawing.Point(9, 9);
			this.clDateRange.MaxSelectionCount = 10;
			this.clDateRange.Name = "clDateRange";
			this.tableLayoutPanel1.SetRowSpan(this.clDateRange, 2);
			this.clDateRange.TabIndex = 0;
			// 
			// btnImportar
			// 
			this.btnImportar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnImportar.Location = new System.Drawing.Point(274, 9);
			this.btnImportar.Margin = new System.Windows.Forms.Padding(9);
			this.btnImportar.Name = "btnImportar";
			this.btnImportar.Size = new System.Drawing.Size(148, 65);
			this.btnImportar.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
			this.btnImportar.TabIndex = 1;
			this.btnImportar.Values.Image = global::ControlNominasAddIn.Properties.Resources.database_export;
			this.btnImportar.Values.Text = "Importar Registros";
			this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.statusStrip1.Location = new System.Drawing.Point(0, 181);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			this.statusStrip1.Size = new System.Drawing.Size(431, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
			this.tableLayoutPanel1.Controls.Add(this.btnImportar, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.clDateRange, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(431, 181);
			this.tableLayoutPanel1.TabIndex = 3;
			// 
			// frmImportarPermisos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(431, 203);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.statusStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmImportarPermisos";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Importar Permisos";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MonthCalendar clDateRange;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnImportar;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.StatusStrip statusStrip1;
	}
}