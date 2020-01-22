using ComponentFactory.Krypton.Toolkit;

namespace EstacionPesaje
{
	partial class SinBasculaForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.kryptonButton1, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.kryptonButton2, 1, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.72222F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.27778F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(512, 156);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Image = global::EstacionPesaje.Properties.Resources.cancel;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.tableLayoutPanel1.SetRowSpan(this.label1, 2);
			this.label1.Size = new System.Drawing.Size(98, 116);
			this.label1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Maroon;
			this.label2.Location = new System.Drawing.Point(107, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(402, 69);
			this.label2.TabIndex = 1;
			this.label2.Text = "¡Verifique la conexion de la bascula!";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(107, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(402, 47);
			this.label3.TabIndex = 2;
			this.label3.Text = "La bascula se encuentra desconectada de la estación. \r\n¿Desea continuar con la ca" +
    "ptura?";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// kryptonButton1
			// 
			this.kryptonButton1.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.kryptonButton1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonButton1.Location = new System.Drawing.Point(338, 119);
			this.kryptonButton1.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
			this.kryptonButton1.Name = "kryptonButton1";
			this.kryptonButton1.Size = new System.Drawing.Size(144, 34);
			this.kryptonButton1.TabIndex = 3;
			this.kryptonButton1.Values.Text = "Si, Continuar";
			// 
			// kryptonButton2
			// 
			this.kryptonButton2.DialogResult = System.Windows.Forms.DialogResult.No;
			this.kryptonButton2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonButton2.Location = new System.Drawing.Point(134, 119);
			this.kryptonButton2.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
			this.kryptonButton2.Name = "kryptonButton2";
			this.kryptonButton2.Size = new System.Drawing.Size(144, 34);
			this.kryptonButton2.TabIndex = 4;
			this.kryptonButton2.Values.Text = "No";
			// 
			// SinBasculaForm
			// 
			this.AcceptButton = this.kryptonButton2;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.CancelButton = this.kryptonButton1;
			this.ClientSize = new System.Drawing.Size(512, 156);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SinBasculaForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SinBasculaForm";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private KryptonButton kryptonButton1;
		private KryptonButton kryptonButton2;
	}
}