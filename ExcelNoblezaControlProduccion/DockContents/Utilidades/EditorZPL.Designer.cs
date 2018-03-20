namespace EstacionPesaje.DockContents.Utilidades
{
    partial class EditorZPL
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
            this.zplCodeEditor1 = new libControlesPersonalizados.ZPLCodeEditor();
            this.SuspendLayout();
            // 
            // zplCodeEditor1
            // 
            this.zplCodeEditor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zplCodeEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zplCodeEditor1.HeightLabel = 2D;
            this.zplCodeEditor1.Location = new System.Drawing.Point(1, 1);
            this.zplCodeEditor1.Name = "zplCodeEditor1";
            this.zplCodeEditor1.ScaleLabel = 1D;
            this.zplCodeEditor1.ShowToolStrip = true;
            this.zplCodeEditor1.Size = new System.Drawing.Size(769, 474);
            this.zplCodeEditor1.TabIndex = 0;
            this.zplCodeEditor1.WidthLabel = 4D;
            // 
            // EditorZPL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 476);
            this.Controls.Add(this.zplCodeEditor1);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Name = "EditorZPL";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.Text = "EditorZPL";
            this.ResumeLayout(false);

        }

        #endregion

        private libControlesPersonalizados.ZPLCodeEditor zplCodeEditor1;
    }
}