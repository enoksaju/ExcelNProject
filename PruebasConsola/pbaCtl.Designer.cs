namespace PruebasConsola
{
	partial class pbaCtl
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
			this.ctlCierreOrdenes1 = new libIntelisisReports.Controles.ctlCierreOrdenes();
			this.SuspendLayout();
			// 
			// ctlCierreOrdenes1
			// 
			this.ctlCierreOrdenes1.Location = new System.Drawing.Point(0, 0);
			this.ctlCierreOrdenes1.Name = "ctlCierreOrdenes1";
			this.ctlCierreOrdenes1.Size = new System.Drawing.Size(565, 392);
			this.ctlCierreOrdenes1.TabIndex = 0;
			// 
			// pbaCtl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(565, 392);
			this.Controls.Add(this.ctlCierreOrdenes1);
			this.Name = "pbaCtl";
			this.Text = "pbaCtl";
			this.ResumeLayout(false);

		}

		#endregion

		private libIntelisisReports.Controles.ctlCierreOrdenes ctlCierreOrdenes1;
	}
}