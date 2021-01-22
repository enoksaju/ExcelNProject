namespace EstacionPesaje.Pages.tools
{
	partial class AVTLabelGenerator_frm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.Cantidadnbx = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
			this.printbtn = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
			this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
			this.FolioActuallbl = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.Cancelbtn = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(378, 231);
			this.kryptonPanel1.TabIndex = 0;
			// 
			// Cantidadnbx
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.Cantidadnbx, 2);
			this.Cantidadnbx.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Cantidadnbx.Location = new System.Drawing.Point(15, 95);
			this.Cantidadnbx.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.Cantidadnbx.Name = "Cantidadnbx";
			this.Cantidadnbx.Size = new System.Drawing.Size(348, 22);
			this.Cantidadnbx.TabIndex = 0;
			this.Cantidadnbx.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// printbtn
			// 
			this.printbtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.printbtn.Location = new System.Drawing.Point(194, 143);
			this.printbtn.Margin = new System.Windows.Forms.Padding(5, 5, 10, 10);
			this.printbtn.Name = "printbtn";
			this.printbtn.Size = new System.Drawing.Size(174, 78);
			this.printbtn.TabIndex = 2;
			this.printbtn.Values.Image = global::EstacionPesaje.Properties.Resources.Print_16x;
			this.printbtn.Values.Text = "Imprimir";
			this.printbtn.Click += new System.EventHandler(this.printbtn_Click);
			// 
			// kryptonWrapLabel1
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.kryptonWrapLabel1, 2);
			this.kryptonWrapLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
			this.kryptonWrapLabel1.Location = new System.Drawing.Point(15, 46);
			this.kryptonWrapLabel1.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
			this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
			this.kryptonWrapLabel1.Size = new System.Drawing.Size(348, 46);
			this.kryptonWrapLabel1.Text = "Cantidad a Imprimir:";
			this.kryptonWrapLabel1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// kryptonWrapLabel2
			// 
			this.kryptonWrapLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
			this.kryptonWrapLabel2.Location = new System.Drawing.Point(3, 0);
			this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
			this.kryptonWrapLabel2.Size = new System.Drawing.Size(183, 46);
			this.kryptonWrapLabel2.Text = "Folio Actual:";
			this.kryptonWrapLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FolioActuallbl
			// 
			this.FolioActuallbl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FolioActuallbl.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.FolioActuallbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
			this.FolioActuallbl.Location = new System.Drawing.Point(192, 0);
			this.FolioActuallbl.Name = "FolioActuallbl";
			this.FolioActuallbl.Size = new System.Drawing.Size(183, 46);
			this.FolioActuallbl.Text = "{folioActual}";
			this.FolioActuallbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.Cancelbtn, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.kryptonWrapLabel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.kryptonWrapLabel1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.Cantidadnbx, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.FolioActuallbl, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.printbtn, 1, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(378, 231);
			this.tableLayoutPanel1.TabIndex = 7;
			// 
			// Cancelbtn
			// 
			this.Cancelbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancelbtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Cancelbtn.Location = new System.Drawing.Point(10, 143);
			this.Cancelbtn.Margin = new System.Windows.Forms.Padding(10, 5, 5, 10);
			this.Cancelbtn.Name = "Cancelbtn";
			this.Cancelbtn.Size = new System.Drawing.Size(174, 78);
			this.Cancelbtn.TabIndex = 1;
			this.Cancelbtn.Values.Image = global::EstacionPesaje.Properties.Resources.Cancel_16x;
			this.Cancelbtn.Values.Text = "Cancelar";
			this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
			// 
			// AVTLabelGenerator_frm
			// 
			this.AcceptButton = this.Cancelbtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(378, 231);
			this.ControlBox = false;
			this.Controls.Add(this.kryptonPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AVTLabelGenerator_frm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AVTLabelGenerator_frm";
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
		private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown Cantidadnbx;
		private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel FolioActuallbl;
		private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
		private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton printbtn;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton Cancelbtn;
	}
}