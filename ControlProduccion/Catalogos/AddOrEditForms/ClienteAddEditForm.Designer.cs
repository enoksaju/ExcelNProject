namespace ControlProduccion.Catalogos.AddOrEditForms
{
    partial class ClienteAddEditForm
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
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recetasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ClientekryptonMaskedTextBox = new ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ClienteKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.ClearNombreKryptonButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recetasBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Cliente);
            // 
            // recetasBindingSource
            // 
            this.recetasBindingSource.DataMember = "Recetas";
            this.recetasBindingSource.DataSource = this.clienteBindingSource;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ClientekryptonMaskedTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ClienteKryptonTextBox, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(485, 77);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonLabel2.Location = new System.Drawing.Point(67, 51);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.kryptonLabel2.Size = new System.Drawing.Size(58, 23);
            this.kryptonLabel2.TabIndex = 6;
            this.kryptonLabel2.Values.Text = "Nombre:";
            // 
            // ClientekryptonMaskedTextBox
            // 
            this.ClientekryptonMaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clienteBindingSource, "ClaveCliente", true));
            this.ClientekryptonMaskedTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.ClientekryptonMaskedTextBox.Location = new System.Drawing.Point(131, 23);
            this.ClientekryptonMaskedTextBox.Mask = "0000000000";
            this.ClientekryptonMaskedTextBox.Name = "ClientekryptonMaskedTextBox";
            this.ClientekryptonMaskedTextBox.PromptChar = '0';
            this.ClientekryptonMaskedTextBox.Size = new System.Drawing.Size(181, 23);
            this.ClientekryptonMaskedTextBox.TabIndex = 6;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonLabel1.Location = new System.Drawing.Point(83, 23);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.kryptonLabel1.Size = new System.Drawing.Size(42, 22);
            this.kryptonLabel1.TabIndex = 5;
            this.kryptonLabel1.Values.Text = "Clave:";
            // 
            // ClienteKryptonTextBox
            // 
            this.ClienteKryptonTextBox.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.ClearNombreKryptonButton});
            this.ClienteKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clienteBindingSource, "NombreCliente", true));
            this.ClienteKryptonTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.ClienteKryptonTextBox.Location = new System.Drawing.Point(131, 51);
            this.ClienteKryptonTextBox.Name = "ClienteKryptonTextBox";
            this.ClienteKryptonTextBox.Size = new System.Drawing.Size(300, 23);
            this.ClienteKryptonTextBox.TabIndex = 5;
            this.ClienteKryptonTextBox.WordWrap = false;
            // 
            // ClearNombreKryptonButton
            // 
            this.ClearNombreKryptonButton.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.ClearNombreKryptonButton.ToolTipBody = "Limpiar el campo";
            this.ClearNombreKryptonButton.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Close;
            this.ClearNombreKryptonButton.UniqueName = "E5F9D072A98148DE79B27089EEFA5453";
            this.ClearNombreKryptonButton.Click += new System.EventHandler(this.ClearNombreKryptonButton_Click);
            // 
            // ClienteAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.BindingSource = this.clienteBindingSource;
            this.ClientSize = new System.Drawing.Size(485, 390);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ImageForm = global::ControlProduccion.Properties.Resources.Management_32px;
            this.Name = "ClienteAddEditForm";
            this.Text = "ClienteAddEditForm";
            this.TitleText = "Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recetasBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource clienteBindingSource;
        private System.Windows.Forms.BindingSource recetasBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ClienteKryptonTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox ClientekryptonMaskedTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny ClearNombreKryptonButton;
    }
}