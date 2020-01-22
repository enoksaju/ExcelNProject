namespace TryAppDesktopKripton
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent ()
		{
			this.components = new System.ComponentModel.Container();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
			this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
			this.kryptonTrackBar1 = new ComponentFactory.Krypton.Toolkit.KryptonTrackBar();
			this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonRichTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.kryptonRadioButton1 = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.kryptonNumericUpDown1 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonComboBox1 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
			this.kryptonGroupBox1.Panel.SuspendLayout();
			this.kryptonGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// kryptonManager1
			// 
			this.kryptonManager1.GlobalPalette = this.kryptonPalette1;
			this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom;
			// 
			// kryptonPalette1
			// 
			this.kryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
			this.kryptonPalette1.Common.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonPalette1.CustomisedKryptonPaletteFilePath = null;
			// 
			// kryptonButton1
			// 
			this.kryptonButton1.Location = new System.Drawing.Point(12, 10);
			this.kryptonButton1.Name = "kryptonButton1";
			this.kryptonButton1.Size = new System.Drawing.Size(169, 79);
			this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton1.TabIndex = 0;
			this.kryptonButton1.Values.Image = global::TryAppDesktopKripton.Properties.Resources.calendar2;
			this.kryptonButton1.Values.Text = "Add";
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel1);
			this.kryptonPanel1.Controls.Add(this.kryptonTrackBar1);
			this.kryptonPanel1.Controls.Add(this.kryptonTextBox1);
			this.kryptonPanel1.Controls.Add(this.kryptonRichTextBox1);
			this.kryptonPanel1.Controls.Add(this.kryptonRadioButton1);
			this.kryptonPanel1.Controls.Add(this.kryptonNumericUpDown1);
			this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
			this.kryptonPanel1.Controls.Add(this.kryptonComboBox1);
			this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(500, 385);
			this.kryptonPanel1.TabIndex = 1;
			// 
			// kryptonWrapLabel1
			// 
			this.kryptonWrapLabel1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.Black;
			this.kryptonWrapLabel1.Location = new System.Drawing.Point(282, 0);
			this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
			this.kryptonWrapLabel1.Size = new System.Drawing.Size(182, 26);
			this.kryptonWrapLabel1.Text = "kryptonWrapLabel1";
			// 
			// kryptonTrackBar1
			// 
			this.kryptonTrackBar1.DrawBackground = true;
			this.kryptonTrackBar1.Location = new System.Drawing.Point(37, 263);
			this.kryptonTrackBar1.Name = "kryptonTrackBar1";
			this.kryptonTrackBar1.Size = new System.Drawing.Size(203, 27);
			this.kryptonTrackBar1.TabIndex = 9;
			// 
			// kryptonTextBox1
			// 
			this.kryptonTextBox1.Location = new System.Drawing.Point(247, 112);
			this.kryptonTextBox1.Name = "kryptonTextBox1";
			this.kryptonTextBox1.Size = new System.Drawing.Size(209, 34);
			this.kryptonTextBox1.TabIndex = 8;
			this.kryptonTextBox1.Text = "kryptonTextBox1";
			// 
			// kryptonRichTextBox1
			// 
			this.kryptonRichTextBox1.Location = new System.Drawing.Point(264, 204);
			this.kryptonRichTextBox1.Name = "kryptonRichTextBox1";
			this.kryptonRichTextBox1.Size = new System.Drawing.Size(208, 144);
			this.kryptonRichTextBox1.TabIndex = 7;
			this.kryptonRichTextBox1.Text = "kryptonRichTextBox1";
			// 
			// kryptonRadioButton1
			// 
			this.kryptonRadioButton1.Location = new System.Drawing.Point(264, 151);
			this.kryptonRadioButton1.Name = "kryptonRadioButton1";
			this.kryptonRadioButton1.Size = new System.Drawing.Size(215, 31);
			this.kryptonRadioButton1.TabIndex = 6;
			this.kryptonRadioButton1.Values.Text = "kryptonRadioButton1";
			// 
			// kryptonNumericUpDown1
			// 
			this.kryptonNumericUpDown1.AllowDecimals = true;
			this.kryptonNumericUpDown1.DecimalPlaces = 2;
			this.kryptonNumericUpDown1.Location = new System.Drawing.Point(247, 73);
			this.kryptonNumericUpDown1.Name = "kryptonNumericUpDown1";
			this.kryptonNumericUpDown1.Size = new System.Drawing.Size(209, 33);
			this.kryptonNumericUpDown1.TabIndex = 5;
			this.kryptonNumericUpDown1.ThousandsSeparator = true;
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
			this.kryptonLabel1.Location = new System.Drawing.Point(138, 0);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(141, 31);
			this.kryptonLabel1.TabIndex = 4;
			this.kryptonLabel1.Values.Text = "kryptonLabel1";
			// 
			// kryptonComboBox1
			// 
			this.kryptonComboBox1.DropDownWidth = 188;
			this.kryptonComboBox1.IntegralHeight = false;
			this.kryptonComboBox1.Location = new System.Drawing.Point(37, 204);
			this.kryptonComboBox1.Name = "kryptonComboBox1";
			this.kryptonComboBox1.Size = new System.Drawing.Size(188, 32);
			this.kryptonComboBox1.StateCommon.ComboBox.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
			this.kryptonComboBox1.TabIndex = 2;
			this.kryptonComboBox1.Text = "kryptonComboBox1";
			// 
			// kryptonGroupBox1
			// 
			this.kryptonGroupBox1.Location = new System.Drawing.Point(37, 23);
			this.kryptonGroupBox1.Name = "kryptonGroupBox1";
			// 
			// kryptonGroupBox1.Panel
			// 
			this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonButton1);
			this.kryptonGroupBox1.Size = new System.Drawing.Size(203, 156);
			this.kryptonGroupBox1.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 385);
			this.Controls.Add(this.kryptonPanel1);
			this.CustomCaptionArea = new System.Drawing.Rectangle(89, 0, 468, 26);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
			this.kryptonGroupBox1.Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
			this.kryptonGroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonTrackBar kryptonTrackBar1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox kryptonRichTextBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton kryptonRadioButton1;
		private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox kryptonComboBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
	}
}

