namespace EstacionesPesaje.DockContents.Catalogos
{
    partial class CatalogoMateriales
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
            this.components = new System.ComponentModel.Container();
            this.FamiliaMaterialesKryptonListBox = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.familiaMaterialesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InfoContainerkryptonSplitContainer = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.materialesKryptonListBox = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.materialesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LoaderPicktureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.familiaMaterialesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoContainerkryptonSplitContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoContainerkryptonSplitContainer.Panel1)).BeginInit();
            this.InfoContainerkryptonSplitContainer.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoContainerkryptonSplitContainer.Panel2)).BeginInit();
            this.InfoContainerkryptonSplitContainer.Panel2.SuspendLayout();
            this.InfoContainerkryptonSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoaderPicktureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FamiliaMaterialesKryptonListBox
            // 
            this.FamiliaMaterialesKryptonListBox.DataSource = this.familiaMaterialesBindingSource;
            this.FamiliaMaterialesKryptonListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FamiliaMaterialesKryptonListBox.Location = new System.Drawing.Point(0, 0);
            this.FamiliaMaterialesKryptonListBox.Name = "FamiliaMaterialesKryptonListBox";
            this.FamiliaMaterialesKryptonListBox.Size = new System.Drawing.Size(111, 408);
            this.FamiliaMaterialesKryptonListBox.TabIndex = 5;
            // 
            // familiaMaterialesBindingSource
            // 
            this.familiaMaterialesBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.FamiliaMateriales);
            // 
            // InfoContainerkryptonSplitContainer
            // 
            this.InfoContainerkryptonSplitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.InfoContainerkryptonSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoContainerkryptonSplitContainer.Location = new System.Drawing.Point(1, 51);
            this.InfoContainerkryptonSplitContainer.Name = "InfoContainerkryptonSplitContainer";
            // 
            // InfoContainerkryptonSplitContainer.Panel1
            // 
            this.InfoContainerkryptonSplitContainer.Panel1.Controls.Add(this.FamiliaMaterialesKryptonListBox);
            // 
            // InfoContainerkryptonSplitContainer.Panel2
            // 
            this.InfoContainerkryptonSplitContainer.Panel2.Controls.Add(this.materialesKryptonListBox);
            this.InfoContainerkryptonSplitContainer.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.InfoContainerkryptonSplitContainer.Size = new System.Drawing.Size(333, 408);
            this.InfoContainerkryptonSplitContainer.SplitterDistance = 111;
            this.InfoContainerkryptonSplitContainer.TabIndex = 7;
            // 
            // materialesKryptonListBox
            // 
            this.materialesKryptonListBox.DataSource = this.materialesBindingSource;
            this.materialesKryptonListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialesKryptonListBox.Location = new System.Drawing.Point(0, 0);
            this.materialesKryptonListBox.Name = "materialesKryptonListBox";
            this.materialesKryptonListBox.Size = new System.Drawing.Size(217, 408);
            this.materialesKryptonListBox.TabIndex = 0;
            // 
            // materialesBindingSource
            // 
            this.materialesBindingSource.DataMember = "Materiales";
            this.materialesBindingSource.DataSource = this.familiaMaterialesBindingSource;
            // 
            // LoaderPicktureBox
            // 
            this.LoaderPicktureBox.BackColor = System.Drawing.Color.Transparent;
            this.LoaderPicktureBox.Image = global::EstacionesPesaje.Properties.Resources.loading;
            this.LoaderPicktureBox.Location = new System.Drawing.Point(111, 85);
            this.LoaderPicktureBox.Name = "LoaderPicktureBox";
            this.LoaderPicktureBox.Size = new System.Drawing.Size(90, 90);
            this.LoaderPicktureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LoaderPicktureBox.TabIndex = 1;
            this.LoaderPicktureBox.TabStop = false;
            // 
            // CatalogoMateriales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 460);
            this.Controls.Add(this.LoaderPicktureBox);
            this.Controls.Add(this.InfoContainerkryptonSplitContainer);
            this.Name = "CatalogoMateriales";
            this.TabText = "Catalogo de Materiales";
            this.Text = "Catalogo de Materiales";
            this.Controls.SetChildIndex(this.InfoContainerkryptonSplitContainer, 0);
            this.Controls.SetChildIndex(this.LoaderPicktureBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.familiaMaterialesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoContainerkryptonSplitContainer.Panel1)).EndInit();
            this.InfoContainerkryptonSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InfoContainerkryptonSplitContainer.Panel2)).EndInit();
            this.InfoContainerkryptonSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InfoContainerkryptonSplitContainer)).EndInit();
            this.InfoContainerkryptonSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.materialesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoaderPicktureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonListBox FamiliaMaterialesKryptonListBox;
        private System.Windows.Forms.BindingSource familiaMaterialesBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer InfoContainerkryptonSplitContainer;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox materialesKryptonListBox;
        private System.Windows.Forms.BindingSource materialesBindingSource;
        private System.Windows.Forms.PictureBox LoaderPicktureBox;
    }
}