namespace ControlProduccion
{
    partial class tryKryptonIpalette
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        ///// <summary>
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose( bool disposing )
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose( disposing );
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.SuspendLayout();
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(445, 36);
            this.kryptonHeader1.TabIndex = 1;
            this.kryptonHeader1.Values.Description = "Agregar o Editar una Entidad";
            this.kryptonHeader1.Values.Heading = "Formulario";
            this.kryptonHeader1.Values.Image = global::ControlProduccion.Properties.Resources.AddField_32x;
            // 
            // tryKryptonIpalette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 368);
            this.Controls.Add(this.kryptonHeader1);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Name = "tryKryptonIpalette";
            this.Text = "tryKryptonIpalette";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
    }
}