namespace ContabilidadIntelisisRep_AddIn.Forms {
	partial class frmSelectorCuentas {
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
			System.Windows.Forms.Label cuentaLabel;
			System.Windows.Forms.Label descripcionLabel;
			System.Windows.Forms.Label tipoLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectorCuentas));
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.treeImages = new System.Windows.Forms.ImageList(this.components);
			this.cuentasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.cuentasListBox = new System.Windows.Forms.ListBox();
			this.cuentaTextBox = new System.Windows.Forms.TextBox();
			this.descripcionTextBox = new System.Windows.Forms.TextBox();
			this.tipoTextBox = new System.Windows.Forms.TextBox();
			cuentaLabel = new System.Windows.Forms.Label();
			descripcionLabel = new System.Windows.Forms.Label();
			tipoLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.cuentasBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// cuentaLabel
			// 
			cuentaLabel.AutoSize = true;
			cuentaLabel.Location = new System.Drawing.Point(14, 353);
			cuentaLabel.Name = "cuentaLabel";
			cuentaLabel.Size = new System.Drawing.Size(44, 13);
			cuentaLabel.TabIndex = 2;
			cuentaLabel.Text = "Cuenta:";
			// 
			// descripcionLabel
			// 
			descripcionLabel.AutoSize = true;
			descripcionLabel.Location = new System.Drawing.Point(265, 353);
			descripcionLabel.Name = "descripcionLabel";
			descripcionLabel.Size = new System.Drawing.Size(66, 13);
			descripcionLabel.TabIndex = 4;
			descripcionLabel.Text = "Descripcion:";
			// 
			// tipoLabel
			// 
			tipoLabel.AutoSize = true;
			tipoLabel.Location = new System.Drawing.Point(27, 379);
			tipoLabel.Name = "tipoLabel";
			tipoLabel.Size = new System.Drawing.Size(31, 13);
			tipoLabel.TabIndex = 6;
			tipoLabel.Text = "Tipo:";
			// 
			// treeView1
			// 
			this.treeView1.ImageIndex = 0;
			this.treeView1.ImageList = this.treeImages;
			this.treeView1.Location = new System.Drawing.Point(12, 12);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = 0;
			this.treeView1.Size = new System.Drawing.Size(247, 316);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// treeImages
			// 
			this.treeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImages.ImageStream")));
			this.treeImages.TransparentColor = System.Drawing.Color.Transparent;
			this.treeImages.Images.SetKeyName(0, "folder.png");
			this.treeImages.Images.SetKeyName(1, "folder_open.png");
			// 
			// cuentasBindingSource
			// 
			this.cuentasBindingSource.DataSource = typeof(ContabilidadIntelisisRep_AddIn.Modelos.Cuentas);
			// 
			// cuentasListBox
			// 
			this.cuentasListBox.DataSource = this.cuentasBindingSource;
			this.cuentasListBox.DisplayMember = "Descripcion";
			this.cuentasListBox.FormattingEnabled = true;
			this.cuentasListBox.Location = new System.Drawing.Point(265, 12);
			this.cuentasListBox.Name = "cuentasListBox";
			this.cuentasListBox.Size = new System.Drawing.Size(335, 316);
			this.cuentasListBox.TabIndex = 2;
			this.cuentasListBox.ValueMember = "Cuenta";
			this.cuentasListBox.DoubleClick += new System.EventHandler(this.cuentasListBox_DoubleClick);
			// 
			// cuentaTextBox
			// 
			this.cuentaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cuentasBindingSource, "Cuenta", true));
			this.cuentaTextBox.Location = new System.Drawing.Point(64, 350);
			this.cuentaTextBox.Name = "cuentaTextBox";
			this.cuentaTextBox.ReadOnly = true;
			this.cuentaTextBox.Size = new System.Drawing.Size(195, 20);
			this.cuentaTextBox.TabIndex = 3;
			// 
			// descripcionTextBox
			// 
			this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cuentasBindingSource, "Descripcion", true));
			this.descripcionTextBox.Location = new System.Drawing.Point(337, 350);
			this.descripcionTextBox.Name = "descripcionTextBox";
			this.descripcionTextBox.ReadOnly = true;
			this.descripcionTextBox.Size = new System.Drawing.Size(263, 20);
			this.descripcionTextBox.TabIndex = 5;
			// 
			// tipoTextBox
			// 
			this.tipoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cuentasBindingSource, "Tipo", true));
			this.tipoTextBox.Location = new System.Drawing.Point(64, 376);
			this.tipoTextBox.Name = "tipoTextBox";
			this.tipoTextBox.ReadOnly = true;
			this.tipoTextBox.Size = new System.Drawing.Size(195, 20);
			this.tipoTextBox.TabIndex = 7;
			// 
			// frmSelectorCuentas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(612, 404);
			this.Controls.Add(tipoLabel);
			this.Controls.Add(this.tipoTextBox);
			this.Controls.Add(descripcionLabel);
			this.Controls.Add(this.descripcionTextBox);
			this.Controls.Add(cuentaLabel);
			this.Controls.Add(this.cuentaTextBox);
			this.Controls.Add(this.cuentasListBox);
			this.Controls.Add(this.treeView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSelectorCuentas";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Selector Cuentas";
			((System.ComponentModel.ISupportInitialize)(this.cuentasBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ImageList treeImages;
		private System.Windows.Forms.BindingSource cuentasBindingSource;
		private System.Windows.Forms.ListBox cuentasListBox;
		private System.Windows.Forms.TextBox cuentaTextBox;
		private System.Windows.Forms.TextBox descripcionTextBox;
		private System.Windows.Forms.TextBox tipoTextBox;
	}
}