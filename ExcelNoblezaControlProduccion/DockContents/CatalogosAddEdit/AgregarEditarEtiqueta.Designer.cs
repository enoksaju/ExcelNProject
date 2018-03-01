namespace ExcelNoblezaControlProduccion.DockContents.CatalogosAddEdit
{
    partial class AgregarEditarEtiqueta
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
            this.components = new System.ComponentModel.Container();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.zplCodeEditor1 = new libControlesPersonalizados.ZPLCodeEditor();
            this.etiquetaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nombreKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.etiquetaBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(10, 84);
            this.kryptonGroupBox1.Margin = new System.Windows.Forms.Padding(10);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.zplCodeEditor1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(648, 411);
            this.kryptonGroupBox1.TabIndex = 3;
            this.kryptonGroupBox1.Values.Heading = "Codigo ZPL y Vista PRevia";
            // 
            // zplCodeEditor1
            // 
            this.zplCodeEditor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zplCodeEditor1.DataBindings.Add(new System.Windows.Forms.Binding("ZPLText", this.etiquetaBindingSource, "ZPLCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.zplCodeEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zplCodeEditor1.HeightLabel = 2D;
            this.zplCodeEditor1.Location = new System.Drawing.Point(0, 0);
            this.zplCodeEditor1.Name = "zplCodeEditor1";
            this.zplCodeEditor1.ScaleLabel = 0.5D;
            this.zplCodeEditor1.ShowPreview = false;
            this.zplCodeEditor1.ShowToolStrip = false;
            this.zplCodeEditor1.Size = new System.Drawing.Size(644, 387);
            this.zplCodeEditor1.TabIndex = 1;
            this.zplCodeEditor1.WidthLabel = 4D;
            this.zplCodeEditor1.ZPLText = "\r\n^FX\r\n              Autor: Excel Nobleza\r\n        Descripción: Etiqueta ***\r\n   " +
    "         Cliente:\r\n Nombre del Archivo:\r\n^FS\r\n\r\n^XA\r\n\r\n    ^FX Ingrese el codigo" +
    " de la etiqueta aqui ^FS\r\n\r\n^XZ";
            // 
            // etiquetaBindingSource
            // 
            this.etiquetaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Etiqueta);
            // 
            // nombreKryptonTextBox
            // 
            this.nombreKryptonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.etiquetaBindingSource, "Nombre", true));
            this.nombreKryptonTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nombreKryptonTextBox.Location = new System.Drawing.Point(84, 3);
            this.nombreKryptonTextBox.MaximumSize = new System.Drawing.Size(250, 0);
            this.nombreKryptonTextBox.Name = "nombreKryptonTextBox";
            this.nombreKryptonTextBox.Size = new System.Drawing.Size(250, 23);
            this.nombreKryptonTextBox.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel1.Location = new System.Drawing.Point(22, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(56, 24);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "Nombre";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.kryptonGroupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.kryptonGroupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 32);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(668, 505);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox2.Location = new System.Drawing.Point(10, 10);
            this.kryptonGroupBox2.Margin = new System.Windows.Forms.Padding(10);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.tableLayoutPanel2);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(648, 54);
            this.kryptonGroupBox2.TabIndex = 4;
            this.kryptonGroupBox2.Values.Heading = "Datos";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.nombreKryptonTextBox, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(644, 30);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // AgregarEditarEtiqueta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BindingSource = this.etiquetaBindingSource;
            this.ClientSize = new System.Drawing.Size(670, 538);
            this.Controls.Add(this.tableLayoutPanel1);
            this.HeaderDescripcion = "";
            this.HeaderText = "Etiqueta";
            this.Name = "AgregarEditarEtiqueta";
            this.Text = "";
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.etiquetaBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private libControlesPersonalizados.ZPLCodeEditor zplCodeEditor1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private System.Windows.Forms.BindingSource etiquetaBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox nombreKryptonTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}