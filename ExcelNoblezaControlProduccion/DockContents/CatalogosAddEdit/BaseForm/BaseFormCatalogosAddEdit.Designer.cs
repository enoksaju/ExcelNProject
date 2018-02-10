namespace ExcelNoblezaControlProduccion.DockContents.CatalogosAddEdit.BaseForm
{
    partial class BaseFormCatalogosAddEdit
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
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HeaderForm = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.SuspendLayout();
            // 
            // HeaderForm
            // 
            this.HeaderForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderForm.Location = new System.Drawing.Point(1, 1);
            this.HeaderForm.Name = "HeaderForm";
            this.HeaderForm.Size = new System.Drawing.Size(363, 31);
            this.HeaderForm.TabIndex = 0;
            this.HeaderForm.Values.Heading = "Agregar o Editar";
            this.HeaderForm.Values.Image = global::ExcelNoblezaControlProduccion.Properties.Resources.EditPage_16x;
            // 
            // BaseFormCatalogosAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(365, 458);
            this.Controls.Add(this.HeaderForm);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Name = "BaseFormCatalogosAddEdit";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.Text = "CatalogosAddEditBase";
            this.Load += new System.EventHandler(this.BaseFormCatalogosAddEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeader HeaderForm;
    }
}