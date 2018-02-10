namespace ExcelNoblezaControlProduccion.ConfiguracionForms
{
    partial class BasculaConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
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
            this.filteredPropertyGrid1 = new Azuria.Common.Controls.FilteredPropertyGrid();
            this.SuspendLayout();
            // 
            // filteredPropertyGrid1
            // 
            this.filteredPropertyGrid1.BrowsableProperties = null;
            this.filteredPropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filteredPropertyGrid1.HiddenAttributes = null;
            this.filteredPropertyGrid1.HiddenProperties = null;
            this.filteredPropertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.filteredPropertyGrid1.Name = "filteredPropertyGrid1";
            this.filteredPropertyGrid1.Size = new System.Drawing.Size(287, 441);
            this.filteredPropertyGrid1.TabIndex = 0;
            // 
            // BasculaConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 441);
            this.Controls.Add(this.filteredPropertyGrid1);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight;
            this.HideOnClose = true;
            this.Name = "BasculaConfigForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.TabText = "Configuración de la Bascula";
            this.Text = "Configuración de la Bascula";
            this.Load += new System.EventHandler(this.BasculaConfigForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Azuria.Common.Controls.FilteredPropertyGrid filteredPropertyGrid1;
    }
}