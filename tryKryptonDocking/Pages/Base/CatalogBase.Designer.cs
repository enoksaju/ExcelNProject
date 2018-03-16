namespace EstacionesPesaje.Pages.Base
{
    partial class CatalogBase<T> : DefaultPageContent, ICatalogPage, IToKryptonPage where T : class
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {            
            this.LoaderPicktureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LoaderPicktureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoaderPicktureBox
            // 
            this.LoaderPicktureBox.BackColor = System.Drawing.Color.Transparent;
            this.LoaderPicktureBox.Image = global::EstacionesPesaje.Properties.Resources.Loader;
            this.LoaderPicktureBox.Location = new System.Drawing.Point(8, 8);
            this.LoaderPicktureBox.Name = "LoaderPicktureBox";
            this.LoaderPicktureBox.Size = new System.Drawing.Size(107, 84);
            this.LoaderPicktureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LoaderPicktureBox.TabIndex = 0;
            this.LoaderPicktureBox.TabStop = false;
            this.LoaderPicktureBox.Visible = false;
            // 
            // CatalogBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LoaderPicktureBox);
            this.Name = "CatalogBase";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(252, 494);
            this.Load += new System.EventHandler(this.CatalogBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LoaderPicktureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox LoaderPicktureBox;
    }
}
