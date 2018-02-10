namespace ExcelNoblezaControlProduccion.DockContents.CatalogosAddEdit
{
    partial class AgregarEditarMaterial
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
            this.materialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aparienciaKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.densidadKryptonNumericUpDown = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.formulaKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.familiaMaterialesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.familiaMaterialesKryptonComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.materialBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.familiaMaterialesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.familiaMaterialesKryptonComboBox)).BeginInit();
            this.SuspendLayout();
            // 
            // materialBindingSource
            // 
            this.materialBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Material);
            // 
            // aparienciaKryptonTextBox
            // 
            this.aparienciaKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.materialBindingSource, "Apariencia", true));
            this.aparienciaKryptonTextBox.Location = new System.Drawing.Point(132, 101);
            this.aparienciaKryptonTextBox.Name = "aparienciaKryptonTextBox";
            this.aparienciaKryptonTextBox.Size = new System.Drawing.Size(146, 23);
            this.aparienciaKryptonTextBox.TabIndex = 2;
            // 
            // densidadKryptonNumericUpDown
            // 
            this.densidadKryptonNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.materialBindingSource, "Densidad", true));
            this.densidadKryptonNumericUpDown.DecimalPlaces = 3;
            this.densidadKryptonNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.densidadKryptonNumericUpDown.Location = new System.Drawing.Point(132, 159);
            this.densidadKryptonNumericUpDown.Name = "densidadKryptonNumericUpDown";
            this.densidadKryptonNumericUpDown.Size = new System.Drawing.Size(146, 22);
            this.densidadKryptonNumericUpDown.TabIndex = 4;
            // 
            // formulaKryptonTextBox
            // 
            this.formulaKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.materialBindingSource, "Formula", true));
            this.formulaKryptonTextBox.Location = new System.Drawing.Point(131, 130);
            this.formulaKryptonTextBox.Name = "formulaKryptonTextBox";
            this.formulaKryptonTextBox.Size = new System.Drawing.Size(146, 23);
            this.formulaKryptonTextBox.TabIndex = 6;
            // 
            // familiaMaterialesBindingSource
            // 
            this.familiaMaterialesBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.FamiliaMateriales);
            // 
            // kryptonWrapLabel2
            // 
            this.kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel2.Location = new System.Drawing.Point(60, 109);
            this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            this.kryptonWrapLabel2.Size = new System.Drawing.Size(66, 15);
            this.kryptonWrapLabel2.Text = "Apariencia:";
            // 
            // kryptonWrapLabel3
            // 
            this.kryptonWrapLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel3.Location = new System.Drawing.Point(72, 138);
            this.kryptonWrapLabel3.Name = "kryptonWrapLabel3";
            this.kryptonWrapLabel3.Size = new System.Drawing.Size(54, 15);
            this.kryptonWrapLabel3.Text = "Formula:";
            // 
            // kryptonWrapLabel4
            // 
            this.kryptonWrapLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel4.Location = new System.Drawing.Point(67, 166);
            this.kryptonWrapLabel4.Name = "kryptonWrapLabel4";
            this.kryptonWrapLabel4.Size = new System.Drawing.Size(59, 15);
            this.kryptonWrapLabel4.Text = "Densidad:";
            // 
            // familiaMaterialesKryptonComboBox
            // 
            this.familiaMaterialesKryptonComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.materialBindingSource, "FamiliaMateriales", true));
            this.familiaMaterialesKryptonComboBox.DataSource = this.familiaMaterialesBindingSource;
            this.familiaMaterialesKryptonComboBox.DisplayMember = "NombreFamilia";
            this.familiaMaterialesKryptonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.familiaMaterialesKryptonComboBox.DropDownWidth = 146;
            this.familiaMaterialesKryptonComboBox.Location = new System.Drawing.Point(131, 68);
            this.familiaMaterialesKryptonComboBox.Name = "familiaMaterialesKryptonComboBox";
            this.familiaMaterialesKryptonComboBox.Size = new System.Drawing.Size(146, 21);
            this.familiaMaterialesKryptonComboBox.TabIndex = 7;
            this.familiaMaterialesKryptonComboBox.ValueMember = "Id";
            // 
            // AgregarEditarMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BindingSource = this.materialBindingSource;
            this.ClientSize = new System.Drawing.Size(419, 361);
            this.Controls.Add(this.familiaMaterialesKryptonComboBox);
            this.Controls.Add(this.kryptonWrapLabel4);
            this.Controls.Add(this.kryptonWrapLabel3);
            this.Controls.Add(this.kryptonWrapLabel2);
            this.Controls.Add(this.aparienciaKryptonTextBox);
            this.Controls.Add(this.densidadKryptonNumericUpDown);
            this.Controls.Add(this.formulaKryptonTextBox);
            this.HeaderDescripcion = "";
            this.HeaderImage = global::ExcelNoblezaControlProduccion.Properties.Resources.LayersMenu;
            this.HeaderText = "Material";
            this.Name = "AgregarEditarMaterial";
            this.TabText = "Material";
            this.Text = "Material";
            this.Controls.SetChildIndex(this.formulaKryptonTextBox, 0);
            this.Controls.SetChildIndex(this.densidadKryptonNumericUpDown, 0);
            this.Controls.SetChildIndex(this.aparienciaKryptonTextBox, 0);
            this.Controls.SetChildIndex(this.kryptonWrapLabel2, 0);
            this.Controls.SetChildIndex(this.kryptonWrapLabel3, 0);
            this.Controls.SetChildIndex(this.kryptonWrapLabel4, 0);
            this.Controls.SetChildIndex(this.familiaMaterialesKryptonComboBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.materialBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.familiaMaterialesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.familiaMaterialesKryptonComboBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource materialBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox aparienciaKryptonTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown densidadKryptonNumericUpDown;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox formulaKryptonTextBox;
        private System.Windows.Forms.BindingSource familiaMaterialesBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox familiaMaterialesKryptonComboBox;
    }
}