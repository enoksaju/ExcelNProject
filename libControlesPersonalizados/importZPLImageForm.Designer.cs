namespace libControlesPersonalizados
{
    partial class importZPLImageForm
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.openFileSpectButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonNumericUpDown1 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.LargoLinea = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.AddCodeButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancelButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ResultCodeRichTextBox = new System.Windows.Forms.RichTextBox();
            this.zplImageConverter1 = new libControlesPersonalizados.ZPLCONVERTER.zplImageConverter();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.openFileSpectButton});
            this.kryptonTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonTextBox1.Location = new System.Drawing.Point(5, 10);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(459, 28);
            this.kryptonTextBox1.TabIndex = 5;
            // 
            // openFileSpectButton
            // 
            this.openFileSpectButton.Image = global::libControlesPersonalizados.Properties.Resources.OpenFolder;
            this.openFileSpectButton.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.openFileSpectButton.Text = "Abrir";
            this.openFileSpectButton.ToolTipBody = "Abrir un Archivo de Imagen";
            this.openFileSpectButton.ToolTipTitle = "Abrir";
            this.openFileSpectButton.UniqueName = "68D92F1EB3FA4E479386FB81F91B486C";
            this.openFileSpectButton.Click += new System.EventHandler(this.openFileSpectButton_Click);
            // 
            // ofdImage
            // 
            this.ofdImage.Filter = "Archivos de Imagen(*.bmp, *.png, *.jpg)|*.bmp;*.jpg;*.png";
            this.ofdImage.InitialDirectory = "c:\\";
            this.ofdImage.Title = "Abrir Imagen";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(262, 3);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.pictureBox2);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(194, 185);
            this.kryptonGroupBox1.TabIndex = 11;
            this.kryptonGroupBox1.Values.Heading = "Resultado";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(190, 161);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox2.Location = new System.Drawing.Point(3, 3);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.pictureBox1);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(193, 185);
            this.kryptonGroupBox2.TabIndex = 12;
            this.kryptonGroupBox2.Values.Heading = "Imagen";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 161);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel2);
            this.kryptonPanel1.Controls.Add(this.kryptonTextBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.kryptonPanel1.Size = new System.Drawing.Size(469, 351);
            this.kryptonPanel1.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonGroupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonGroupBox1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(459, 191);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.kryptonWrapLabel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.kryptonNumericUpDown1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.kryptonWrapLabel2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.LargoLinea, 0, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(202, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.10122F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.96626F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.96626F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.96626F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(54, 185);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(3, 31);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(48, 15);
            this.kryptonWrapLabel1.Text = "% Brillo";
            // 
            // kryptonNumericUpDown1
            // 
            this.kryptonNumericUpDown1.Location = new System.Drawing.Point(3, 49);
            this.kryptonNumericUpDown1.Name = "kryptonNumericUpDown1";
            this.kryptonNumericUpDown1.Size = new System.Drawing.Size(48, 22);
            this.kryptonNumericUpDown1.TabIndex = 1;
            this.kryptonNumericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.kryptonNumericUpDown1.ValueChanged += new System.EventHandler(this.Darknes_ValueChanged);
            // 
            // kryptonWrapLabel2
            // 
            this.kryptonWrapLabel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel2.Location = new System.Drawing.Point(3, 108);
            this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            this.kryptonWrapLabel2.Size = new System.Drawing.Size(48, 30);
            this.kryptonWrapLabel2.Text = "Largo Linea:";
            // 
            // LargoLinea
            // 
            this.LargoLinea.Dock = System.Windows.Forms.DockStyle.Top;
            this.LargoLinea.Location = new System.Drawing.Point(3, 141);
            this.LargoLinea.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.LargoLinea.Name = "LargoLinea";
            this.LargoLinea.Size = new System.Drawing.Size(48, 22);
            this.LargoLinea.TabIndex = 3;
            this.LargoLinea.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.LargoLinea.ValueChanged += new System.EventHandler(this.LargoLinea_ValueChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ResultCodeRichTextBox, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 229);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(459, 112);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.AddCodeButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnCancelButton, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(336, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(120, 100);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // AddCodeButton
            // 
            this.AddCodeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddCodeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddCodeButton.Enabled = false;
            this.AddCodeButton.Location = new System.Drawing.Point(10, 10);
            this.AddCodeButton.Margin = new System.Windows.Forms.Padding(10);
            this.AddCodeButton.Name = "AddCodeButton";
            this.AddCodeButton.Size = new System.Drawing.Size(100, 30);
            this.AddCodeButton.TabIndex = 0;
            this.AddCodeButton.Values.Image = global::libControlesPersonalizados.Properties.Resources.ok;
            this.AddCodeButton.Values.Text = "Agregar";
            // 
            // CancelButton
            // 
            this.btnCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelButton.Location = new System.Drawing.Point(10, 60);
            this.btnCancelButton.Margin = new System.Windows.Forms.Padding(10);
            this.btnCancelButton.Name = "CancelButton";
            this.btnCancelButton.Size = new System.Drawing.Size(100, 30);
            this.btnCancelButton.TabIndex = 1;
            this.btnCancelButton.Values.Image = global::libControlesPersonalizados.Properties.Resources.cancel;
            this.btnCancelButton.Values.Text = "Cancelar";
            // 
            // ResultCodeRichTextBox
            // 
            this.ResultCodeRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ResultCodeRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultCodeRichTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultCodeRichTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ResultCodeRichTextBox.Location = new System.Drawing.Point(3, 3);
            this.ResultCodeRichTextBox.Name = "ResultCodeRichTextBox";
            this.ResultCodeRichTextBox.Size = new System.Drawing.Size(327, 106);
            this.ResultCodeRichTextBox.TabIndex = 8;
            this.ResultCodeRichTextBox.Text = "";
            this.ResultCodeRichTextBox.WordWrap = false;
            // 
            // zplImageConverter1
            // 
            this.zplImageConverter1.BlacknessLimitPercentage = 40;
            this.zplImageConverter1.CompressHex = true;
            this.zplImageConverter1.Image = null;
            this.zplImageConverter1.LengToSplit = 40;
            // 
            // importZPLImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 351);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "importZPLImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "importZPLImageForm";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ZPLCONVERTER.zplImageConverter zplImageConverter1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny openFileSpectButton;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton AddCodeButton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelButton;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown LargoLinea;
        private System.Windows.Forms.RichTextBox ResultCodeRichTextBox;
    }
}