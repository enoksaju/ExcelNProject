namespace EstacionPesaje.Pages.tools {
	partial class PreviewLabel_frm<t> {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing ) {
			if (disposing && ( components != null )) {
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
			this.components = new System.ComponentModel.Container();
			this.PreviewPictureBox = new System.Windows.Forms.PictureBox();
			this.PreviewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.zOOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoom25ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoom50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoom75ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoom100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoom150ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoom200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.PrintZPL = new libControlesPersonalizados.ReplaceAndPrintZPLProduccion(this.components);
			this.zplImageConverter = new libControlesPersonalizados.ZPLCONVERTER.zplImageConverter();
			((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).BeginInit();
			this.PreviewContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// PreviewPictureBox
			// 
			this.PreviewPictureBox.ContextMenuStrip = this.PreviewContextMenuStrip;
			this.PreviewPictureBox.Location = new System.Drawing.Point(12, 12);
			this.PreviewPictureBox.Name = "PreviewPictureBox";
			this.PreviewPictureBox.Size = new System.Drawing.Size(282, 192);
			this.PreviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.PreviewPictureBox.TabIndex = 0;
			this.PreviewPictureBox.TabStop = false;
			// 
			// PreviewContextMenuStrip
			// 
			this.PreviewContextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.PreviewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zOOMToolStripMenuItem});
			this.PreviewContextMenuStrip.Name = "contextMenuStrip1";
			this.PreviewContextMenuStrip.Size = new System.Drawing.Size(111, 26);
			// 
			// zOOMToolStripMenuItem
			// 
			this.zOOMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoom25ToolStripMenuItem,
            this.zoom50ToolStripMenuItem,
            this.zoom75ToolStripMenuItem,
            this.zoom100ToolStripMenuItem,
            this.zoom150ToolStripMenuItem,
            this.zoom200ToolStripMenuItem});
			this.zOOMToolStripMenuItem.Name = "zOOMToolStripMenuItem";
			this.zOOMToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.zOOMToolStripMenuItem.Text = "ZOOM";
			// 
			// zoom25ToolStripMenuItem
			// 
			this.zoom25ToolStripMenuItem.Name = "zoom25ToolStripMenuItem";
			this.zoom25ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.zoom25ToolStripMenuItem.Tag = "0.25";
			this.zoom25ToolStripMenuItem.Text = "25%";
			this.zoom25ToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
			// 
			// zoom50ToolStripMenuItem
			// 
			this.zoom50ToolStripMenuItem.Name = "zoom50ToolStripMenuItem";
			this.zoom50ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.zoom50ToolStripMenuItem.Tag = "0.5";
			this.zoom50ToolStripMenuItem.Text = "50%";
			this.zoom50ToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
			// 
			// zoom75ToolStripMenuItem
			// 
			this.zoom75ToolStripMenuItem.Name = "zoom75ToolStripMenuItem";
			this.zoom75ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.zoom75ToolStripMenuItem.Tag = "0.75";
			this.zoom75ToolStripMenuItem.Text = "75%";
			this.zoom75ToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
			// 
			// zoom100ToolStripMenuItem
			// 
			this.zoom100ToolStripMenuItem.Name = "zoom100ToolStripMenuItem";
			this.zoom100ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.zoom100ToolStripMenuItem.Tag = "1";
			this.zoom100ToolStripMenuItem.Text = "100%";
			this.zoom100ToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
			// 
			// zoom150ToolStripMenuItem
			// 
			this.zoom150ToolStripMenuItem.Name = "zoom150ToolStripMenuItem";
			this.zoom150ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.zoom150ToolStripMenuItem.Tag = "1.5";
			this.zoom150ToolStripMenuItem.Text = "150%";
			this.zoom150ToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
			// 
			// zoom200ToolStripMenuItem
			// 
			this.zoom200ToolStripMenuItem.Name = "zoom200ToolStripMenuItem";
			this.zoom200ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.zoom200ToolStripMenuItem.Tag = "2";
			this.zoom200ToolStripMenuItem.Text = "200%";
			this.zoom200ToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
			// 
			// PrintZPL
			// 
			this.PrintZPL.PrinterName = "";
			// 
			// zplImageConverter
			// 
			this.zplImageConverter.BlacknessLimitPercentage = 48;
			this.zplImageConverter.CompressHex = true;
			this.zplImageConverter.Image = null;
			this.zplImageConverter.LengToSplit = 40;
			// 
			// PreviewLabel_frm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(682, 471);
			this.Controls.Add(this.PreviewPictureBox);
			this.Name = "PreviewLabel_frm";
			this.ShowIcon = false;
			this.Text = "Simular Etiqueta";
			((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).EndInit();
			this.PreviewContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox PreviewPictureBox;
		private System.Windows.Forms.ContextMenuStrip PreviewContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem zOOMToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem zoom25ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem zoom50ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem zoom75ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem zoom100ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem zoom150ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem zoom200ToolStripMenuItem;
		private libControlesPersonalizados.ReplaceAndPrintZPLProduccion PrintZPL;
		private libControlesPersonalizados.ZPLCONVERTER.zplImageConverter zplImageConverter;
	}
}