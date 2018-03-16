namespace EstacionesPesaje.DockContents.CatalogosAddEdit
{
    partial class AgregarEditarCliente
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
            this.nombreClienteKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.claveClienteKryptonMaskedTextBox = new ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Cliente);
            // 
            // nombreClienteKryptonTextBox
            // 
            this.nombreClienteKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clienteBindingSource, "NombreCliente", true));
            this.nombreClienteKryptonTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nombreClienteKryptonTextBox.Location = new System.Drawing.Point(108, 31);
            this.nombreClienteKryptonTextBox.MaximumSize = new System.Drawing.Size(300, 0);
            this.nombreClienteKryptonTextBox.Name = "nombreClienteKryptonTextBox";
            this.nombreClienteKryptonTextBox.Size = new System.Drawing.Size(205, 23);
            this.nombreClienteKryptonTextBox.TabIndex = 4;
            this.nombreClienteKryptonTextBox.Text = "*";
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(3, 0);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(99, 28);
            this.kryptonWrapLabel1.Text = "Clave:";
            this.kryptonWrapLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kryptonWrapLabel2
            // 
            this.kryptonWrapLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonWrapLabel2.Location = new System.Drawing.Point(3, 28);
            this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            this.kryptonWrapLabel2.Size = new System.Drawing.Size(99, 28);
            this.kryptonWrapLabel2.Text = "Nombre:";
            this.kryptonWrapLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // claveClienteKryptonMaskedTextBox
            // 
            this.claveClienteKryptonMaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clienteBindingSource, "ClaveCliente", true));
            this.claveClienteKryptonMaskedTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.claveClienteKryptonMaskedTextBox.Location = new System.Drawing.Point(108, 3);
            this.claveClienteKryptonMaskedTextBox.Mask = "0000000000";
            this.claveClienteKryptonMaskedTextBox.MaximumSize = new System.Drawing.Size(150, 0);
            this.claveClienteKryptonMaskedTextBox.Name = "claveClienteKryptonMaskedTextBox";
            this.claveClienteKryptonMaskedTextBox.PromptChar = '0';
            this.claveClienteKryptonMaskedTextBox.Size = new System.Drawing.Size(150, 23);
            this.claveClienteKryptonMaskedTextBox.TabIndex = 6;
            this.claveClienteKryptonMaskedTextBox.Text = "0000000000";
            this.claveClienteKryptonMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(5, 5);
            this.kryptonGroupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.tableLayoutPanel1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(320, 422);
            this.kryptonGroupBox1.TabIndex = 8;
            this.kryptonGroupBox1.Values.Heading = "Datos del Cliente";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.Controls.Add(this.kryptonWrapLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nombreClienteKryptonTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.claveClienteKryptonMaskedTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonWrapLabel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(316, 56);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.kryptonGroupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 37);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(330, 432);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // AgregarEditarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BindingSource = this.clienteBindingSource;
            this.ClientSize = new System.Drawing.Size(332, 470);
            this.Controls.Add(this.tableLayoutPanel2);
            this.HeaderDescripcion = "";
            this.HeaderImage = global::EstacionesPesaje.Properties.Resources.GroupAssignments;
            this.HeaderText = "Clientes";
            this.Name = "AgregarEditarCliente";
            this.Text = "AgregarEditarCliente";
            this.Controls.SetChildIndex(this.tableLayoutPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource clienteBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox nombreClienteKryptonTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox claveClienteKryptonMaskedTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}