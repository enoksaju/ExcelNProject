

namespace libEmbarquesNCuatro.WinForms.Controls {
	partial class frmCrearTarimaNueva {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( ) {
			this.components = new System.ComponentModel.Container();
			ComponentFactory.Krypton.Toolkit.KryptonLabel oTLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel fechaExtrusionLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel anchoLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel calibreLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel usuarioLabel;
			ComponentFactory.Krypton.Toolkit.KryptonLabel pesoNetoTotalLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrearTarimaNueva));
			this.temporalOrdenTrabajoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.oTKryptonLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.tarimasNCuatroBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.fechaExtrusionKryptonDateTimePicker = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
			this.anchoKryptonNumericUpDown = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
			this.calibreKryptonNumericUpDown = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
			this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.usuarioKryptonLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonListBox1 = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.pesoNetoTotalKryptonWrapLabel = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
			oTLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			fechaExtrusionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			anchoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			calibreLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			usuarioLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			pesoNetoTotalLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			((System.ComponentModel.ISupportInitialize)(this.temporalOrdenTrabajoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tarimasNCuatroBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// oTLabel
			// 
			oTLabel.Location = new System.Drawing.Point(79, 16);
			oTLabel.Name = "oTLabel";
			oTLabel.Size = new System.Drawing.Size(29, 20);
			oTLabel.TabIndex = 1;
			oTLabel.Values.Text = "OT:";
			// 
			// fechaExtrusionLabel
			// 
			fechaExtrusionLabel.Location = new System.Drawing.Point(18, 42);
			fechaExtrusionLabel.Name = "fechaExtrusionLabel";
			fechaExtrusionLabel.Size = new System.Drawing.Size(98, 20);
			fechaExtrusionLabel.TabIndex = 2;
			fechaExtrusionLabel.Values.Text = "Fecha Extrusion:";
			// 
			// anchoLabel
			// 
			anchoLabel.Location = new System.Drawing.Point(63, 69);
			anchoLabel.Name = "anchoLabel";
			anchoLabel.Size = new System.Drawing.Size(48, 20);
			anchoLabel.TabIndex = 4;
			anchoLabel.Values.Text = "Ancho:";
			// 
			// calibreLabel
			// 
			calibreLabel.Location = new System.Drawing.Point(62, 97);
			calibreLabel.Name = "calibreLabel";
			calibreLabel.Size = new System.Drawing.Size(51, 20);
			calibreLabel.TabIndex = 6;
			calibreLabel.Values.Text = "Calibre:";
			// 
			// usuarioLabel
			// 
			usuarioLabel.Location = new System.Drawing.Point(58, 125);
			usuarioLabel.Name = "usuarioLabel";
			usuarioLabel.Size = new System.Drawing.Size(55, 20);
			usuarioLabel.TabIndex = 9;
			usuarioLabel.Values.Text = "Usuario:";
			// 
			// pesoNetoTotalLabel
			// 
			pesoNetoTotalLabel.Location = new System.Drawing.Point(143, 440);
			pesoNetoTotalLabel.Name = "pesoNetoTotalLabel";
			pesoNetoTotalLabel.Size = new System.Drawing.Size(100, 20);
			pesoNetoTotalLabel.TabIndex = 12;
			pesoNetoTotalLabel.Values.Text = "Peso Neto Total:";
			// 
			// temporalOrdenTrabajoBindingSource
			// 
			this.temporalOrdenTrabajoBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.TemporalOrdenTrabajo);
			// 
			// oTKryptonLabel
			// 
			this.oTKryptonLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.temporalOrdenTrabajoBindingSource, "OT", true));
			this.oTKryptonLabel.Location = new System.Drawing.Point(110, 16);
			this.oTKryptonLabel.Name = "oTKryptonLabel";
			this.oTKryptonLabel.Size = new System.Drawing.Size(34, 20);
			this.oTKryptonLabel.TabIndex = 0;
			this.oTKryptonLabel.Values.Text = "{OT}";
			// 
			// tarimasNCuatroBindingSource
			// 
			this.tarimasNCuatroBindingSource.DataMember = "TarimasNCuatro";
			this.tarimasNCuatroBindingSource.DataSource = this.temporalOrdenTrabajoBindingSource;
			// 
			// fechaExtrusionKryptonDateTimePicker
			// 
			this.fechaExtrusionKryptonDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tarimasNCuatroBindingSource, "FechaExtrusion", true));
			this.fechaExtrusionKryptonDateTimePicker.Location = new System.Drawing.Point(110, 42);
			this.fechaExtrusionKryptonDateTimePicker.Name = "fechaExtrusionKryptonDateTimePicker";
			this.fechaExtrusionKryptonDateTimePicker.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.fechaExtrusionKryptonDateTimePicker.Size = new System.Drawing.Size(240, 21);
			this.fechaExtrusionKryptonDateTimePicker.TabIndex = 3;
			// 
			// anchoKryptonNumericUpDown
			// 
			this.anchoKryptonNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tarimasNCuatroBindingSource, "Ancho", true));
			this.anchoKryptonNumericUpDown.Location = new System.Drawing.Point(110, 69);
			this.anchoKryptonNumericUpDown.Name = "anchoKryptonNumericUpDown";
			this.anchoKryptonNumericUpDown.Size = new System.Drawing.Size(120, 22);
			this.anchoKryptonNumericUpDown.TabIndex = 4;
			// 
			// calibreKryptonNumericUpDown
			// 
			this.calibreKryptonNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tarimasNCuatroBindingSource, "Calibre", true));
			this.calibreKryptonNumericUpDown.Location = new System.Drawing.Point(110, 97);
			this.calibreKryptonNumericUpDown.Name = "calibreKryptonNumericUpDown";
			this.calibreKryptonNumericUpDown.Size = new System.Drawing.Size(120, 22);
			this.calibreKryptonNumericUpDown.TabIndex = 5;
			// 
			// itemsBindingSource
			// 
			this.itemsBindingSource.DataMember = "Items";
			this.itemsBindingSource.DataSource = this.tarimasNCuatroBindingSource;
			// 
			// usuarioKryptonLabel
			// 
			this.usuarioKryptonLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tarimasNCuatroBindingSource, "Usuario", true));
			this.usuarioKryptonLabel.Location = new System.Drawing.Point(110, 125);
			this.usuarioKryptonLabel.Name = "usuarioKryptonLabel";
			this.usuarioKryptonLabel.Size = new System.Drawing.Size(60, 20);
			this.usuarioKryptonLabel.TabIndex = 6;
			this.usuarioKryptonLabel.Values.Text = "{Usuario}";
			// 
			// kryptonListBox1
			// 
			this.kryptonListBox1.ContextMenuStrip = this.contextMenuStrip1;
			this.kryptonListBox1.DataSource = this.itemsBindingSource;
			this.kryptonListBox1.DisplayMember = "ToShow";
			this.kryptonListBox1.Location = new System.Drawing.Point(24, 205);
			this.kryptonListBox1.Name = "kryptonListBox1";
			this.kryptonListBox1.Size = new System.Drawing.Size(326, 232);
			this.kryptonListBox1.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.kryptonListBox1.StateCommon.Item.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
			this.kryptonListBox1.StateCommon.Item.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
			this.kryptonListBox1.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.kryptonListBox1.StateCommon.Item.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
			this.kryptonListBox1.StateCommon.Item.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
			this.kryptonListBox1.TabIndex = 2;
			this.kryptonListBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.kryptonListBox1_KeyUp);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrarToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(165, 26);
			// 
			// borrarToolStripMenuItem
			// 
			this.borrarToolStripMenuItem.Image = global::libEmbarquesNCuatro.Properties.Resources.button_rounded_red_delete;
			this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
			this.borrarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
			this.borrarToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.borrarToolStripMenuItem.Text = "Borrar";
			this.borrarToolStripMenuItem.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
			// 
			// kryptonTextBox1
			// 
			this.kryptonTextBox1.ContextMenuStrip = this.contextMenuStrip1;
			this.kryptonTextBox1.Location = new System.Drawing.Point(26, 176);
			this.kryptonTextBox1.Name = "kryptonTextBox1";
			this.kryptonTextBox1.Size = new System.Drawing.Size(324, 23);
			this.kryptonTextBox1.TabIndex = 1;
			this.kryptonTextBox1.Enter += new System.EventHandler(this.kryptonTextBox1_Enter);
			this.kryptonTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.kryptonTextBox1_KeyUp);
			// 
			// kryptonButton1
			// 
			this.kryptonButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.kryptonButton1.Location = new System.Drawing.Point(241, 70);
			this.kryptonButton1.Name = "kryptonButton1";
			this.kryptonButton1.Size = new System.Drawing.Size(108, 48);
			this.kryptonButton1.TabIndex = 14;
			this.kryptonButton1.Values.Text = "Crear y &Guardar";
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.kryptonButton2);
			this.kryptonPanel1.Controls.Add(this.pesoNetoTotalKryptonWrapLabel);
			this.kryptonPanel1.Controls.Add(this.oTKryptonLabel);
			this.kryptonPanel1.Controls.Add(oTLabel);
			this.kryptonPanel1.Controls.Add(this.kryptonButton1);
			this.kryptonPanel1.Controls.Add(this.fechaExtrusionKryptonDateTimePicker);
			this.kryptonPanel1.Controls.Add(pesoNetoTotalLabel);
			this.kryptonPanel1.Controls.Add(fechaExtrusionLabel);
			this.kryptonPanel1.Controls.Add(this.anchoKryptonNumericUpDown);
			this.kryptonPanel1.Controls.Add(this.kryptonTextBox1);
			this.kryptonPanel1.Controls.Add(anchoLabel);
			this.kryptonPanel1.Controls.Add(usuarioLabel);
			this.kryptonPanel1.Controls.Add(this.calibreKryptonNumericUpDown);
			this.kryptonPanel1.Controls.Add(this.usuarioKryptonLabel);
			this.kryptonPanel1.Controls.Add(calibreLabel);
			this.kryptonPanel1.Controls.Add(this.kryptonListBox1);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.FormMain;
			this.kryptonPanel1.Size = new System.Drawing.Size(377, 479);
			this.kryptonPanel1.TabIndex = 15;
			// 
			// kryptonButton2
			// 
			this.kryptonButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.kryptonButton2.Location = new System.Drawing.Point(241, 122);
			this.kryptonButton2.Name = "kryptonButton2";
			this.kryptonButton2.Size = new System.Drawing.Size(108, 48);
			this.kryptonButton2.TabIndex = 16;
			this.kryptonButton2.Values.Text = "&Cancelar";
			// 
			// pesoNetoTotalKryptonWrapLabel
			// 
			this.pesoNetoTotalKryptonWrapLabel.AutoSize = false;
			this.pesoNetoTotalKryptonWrapLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tarimasNCuatroBindingSource, "PesoNetoTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "#,#0.00 Kg"));
			this.pesoNetoTotalKryptonWrapLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.pesoNetoTotalKryptonWrapLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
			this.pesoNetoTotalKryptonWrapLabel.Location = new System.Drawing.Point(249, 440);
			this.pesoNetoTotalKryptonWrapLabel.Name = "pesoNetoTotalKryptonWrapLabel";
			this.pesoNetoTotalKryptonWrapLabel.Size = new System.Drawing.Size(101, 23);
			this.pesoNetoTotalKryptonWrapLabel.Text = "{PesoN Total}";
			this.pesoNetoTotalKryptonWrapLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmCrearTarimaNueva
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(377, 479);
			this.Controls.Add(this.kryptonPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmCrearTarimaNueva";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Crear Tarima Nueva [OT]";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCrearTarimaNueva_FormClosing);
			this.Load += new System.EventHandler(this.frmCrearTarimaNueva_Load);
			this.Enter += new System.EventHandler(this.frmCrearTarimaNueva_Enter);
			((System.ComponentModel.ISupportInitialize)(this.temporalOrdenTrabajoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tarimasNCuatroBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.BindingSource temporalOrdenTrabajoBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel oTKryptonLabel;
		private System.Windows.Forms.BindingSource tarimasNCuatroBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker fechaExtrusionKryptonDateTimePicker;
		private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown anchoKryptonNumericUpDown;
		private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown calibreKryptonNumericUpDown;
		private System.Windows.Forms.BindingSource itemsBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel usuarioKryptonLabel;
		private ComponentFactory.Krypton.Toolkit.KryptonListBox kryptonListBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
		private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel pesoNetoTotalKryptonWrapLabel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
	}
}