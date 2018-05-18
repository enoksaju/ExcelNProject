namespace ContabilidadIntelisisRep_AddIn.Forms {
	partial class frmContResultados {
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.spVerContBalanza_ModDataGridView = new System.Windows.Forms.DataGridView();
			this.Mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statusMessage_lbl = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.spVerContBalanza_ModBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.spVerContBalanza_ModDataGridView)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spVerContBalanza_ModBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// spVerContBalanza_ModDataGridView
			// 
			this.spVerContBalanza_ModDataGridView.AllowUserToAddRows = false;
			this.spVerContBalanza_ModDataGridView.AllowUserToDeleteRows = false;
			this.spVerContBalanza_ModDataGridView.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.spVerContBalanza_ModDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.spVerContBalanza_ModDataGridView.AutoGenerateColumns = false;
			this.spVerContBalanza_ModDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.spVerContBalanza_ModDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.spVerContBalanza_ModDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.spVerContBalanza_ModDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Mes,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.Familia,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
			this.spVerContBalanza_ModDataGridView.DataSource = this.spVerContBalanza_ModBindingSource;
			this.spVerContBalanza_ModDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spVerContBalanza_ModDataGridView.Location = new System.Drawing.Point(0, 0);
			this.spVerContBalanza_ModDataGridView.Name = "spVerContBalanza_ModDataGridView";
			this.spVerContBalanza_ModDataGridView.ReadOnly = true;
			this.spVerContBalanza_ModDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.spVerContBalanza_ModDataGridView.Size = new System.Drawing.Size(625, 426);
			this.spVerContBalanza_ModDataGridView.TabIndex = 1;
			// 
			// Mes
			// 
			this.Mes.DataPropertyName = "Mes";
			this.Mes.HeaderText = "Mes";
			this.Mes.Name = "Mes";
			this.Mes.ReadOnly = true;
			// 
			// Familia
			// 
			this.Familia.DataPropertyName = "Familia";
			this.Familia.HeaderText = "Familia";
			this.Familia.Name = "Familia";
			this.Familia.ReadOnly = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMessage_lbl,
            this.toolStripProgressBar1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 426);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(625, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// statusMessage_lbl
			// 
			this.statusMessage_lbl.Name = "statusMessage_lbl";
			this.statusMessage_lbl.Size = new System.Drawing.Size(508, 17);
			this.statusMessage_lbl.Spring = true;
			this.statusMessage_lbl.Text = "Listo";
			this.statusMessage_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copiarToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(152, 26);
			// 
			// copiarToolStripMenuItem
			// 
			this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
			this.copiarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copiarToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.copiarToolStripMenuItem.Text = "Copiar";
			this.copiarToolStripMenuItem.Click += new System.EventHandler(this.copiarToolStripMenuItem_Click);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Periodo";
			this.dataGridViewTextBoxColumn1.HeaderText = "Periodo";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Ejercicio";
			this.dataGridViewTextBoxColumn2.HeaderText = "Ejercicio";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "ClaveMayor";
			this.dataGridViewTextBoxColumn3.HeaderText = "ClaveMayor";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "Mayor";
			this.dataGridViewTextBoxColumn4.HeaderText = "Mayor";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.DataPropertyName = "ClaveSubCuenta";
			this.dataGridViewTextBoxColumn5.HeaderText = "ClaveSubCuenta";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.DataPropertyName = "SubCuenta";
			this.dataGridViewTextBoxColumn6.HeaderText = "SubCuenta";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.DataPropertyName = "Cuenta";
			this.dataGridViewTextBoxColumn7.HeaderText = "Cuenta";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.DataPropertyName = "Descripcion";
			this.dataGridViewTextBoxColumn8.HeaderText = "Descripcion";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn9
			// 
			this.dataGridViewTextBoxColumn9.DataPropertyName = "Inicio";
			this.dataGridViewTextBoxColumn9.HeaderText = "Inicio";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn10
			// 
			this.dataGridViewTextBoxColumn10.DataPropertyName = "Cargos";
			this.dataGridViewTextBoxColumn10.HeaderText = "Cargos";
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn11
			// 
			this.dataGridViewTextBoxColumn11.DataPropertyName = "Abonos";
			this.dataGridViewTextBoxColumn11.HeaderText = "Abonos";
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn11.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn12
			// 
			this.dataGridViewTextBoxColumn12.DataPropertyName = "Final";
			this.dataGridViewTextBoxColumn12.HeaderText = "Final";
			this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn12.ReadOnly = true;
			// 
			// spVerContBalanza_ModBindingSource
			// 
			this.spVerContBalanza_ModBindingSource.DataSource = typeof(ContabilidadIntelisisRep_AddIn.Modelos.spVerContBalanza_Mod);
			// 
			// frmContResultados
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(625, 448);
			this.Controls.Add(this.spVerContBalanza_ModDataGridView);
			this.Controls.Add(this.statusStrip1);
			this.Name = "frmContResultados";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Balanza Comprobación";
			this.Load += new System.EventHandler(this.frmContResultados_Load);
			((System.ComponentModel.ISupportInitialize)(this.spVerContBalanza_ModDataGridView)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.spVerContBalanza_ModBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.BindingSource spVerContBalanza_ModBindingSource;
		private System.Windows.Forms.DataGridView spVerContBalanza_ModDataGridView;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel statusMessage_lbl;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Mes;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private System.Windows.Forms.DataGridViewTextBoxColumn Familia;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
	}
}