namespace ControlNominasAddIn.Forms {
	partial class SQLPage {
		/// <summary> 
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		///// <summary> 
		///// Limpiar los recursos que se estén usando.
		///// </summary>
		///// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		//protected override void Dispose ( bool disposing ) {
		//	if ( disposing && ( components != null ) ) {
		//		components.Dispose ( );
		//	}
		//	base.Dispose ( disposing );
		//}

		#region Código generado por el Diseñador de componentes

		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent ( ) {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLPage));
			this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
			this.fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
			this.kryptonGroupBox1.Panel.SuspendLayout();
			this.kryptonGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
			this.kryptonSplitContainer1.Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
			this.kryptonSplitContainer1.Panel2.SuspendLayout();
			this.kryptonSplitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// kryptonGroupBox1
			// 
			this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonGroupBox1.Location = new System.Drawing.Point(0, 0);
			this.kryptonGroupBox1.Name = "kryptonGroupBox1";
			// 
			// kryptonGroupBox1.Panel
			// 
			this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonDataGridView1);
			this.kryptonGroupBox1.Size = new System.Drawing.Size(150, 95);
			this.kryptonGroupBox1.TabIndex = 4;
			this.kryptonGroupBox1.Values.Heading = "Resultados";
			// 
			// kryptonDataGridView1
			// 
			this.kryptonDataGridView1.AllowUserToAddRows = false;
			this.kryptonDataGridView1.AllowUserToDeleteRows = false;
			this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonDataGridView1.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
			this.kryptonDataGridView1.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
			this.kryptonDataGridView1.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.kryptonDataGridView1.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.kryptonDataGridView1.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 0);
			this.kryptonDataGridView1.Name = "kryptonDataGridView1";
			this.kryptonDataGridView1.ReadOnly = true;
			this.kryptonDataGridView1.RowHeadersWidth = 25;
			this.kryptonDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.kryptonDataGridView1.Size = new System.Drawing.Size(146, 71);
			this.kryptonDataGridView1.TabIndex = 1;
			// 
			// kryptonSplitContainer1
			// 
			this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
			this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
			this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
			this.kryptonSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// kryptonSplitContainer1.Panel1
			// 
			this.kryptonSplitContainer1.Panel1.Controls.Add(this.fastColoredTextBox1);
			this.kryptonSplitContainer1.Panel1MinSize = 50;
			// 
			// kryptonSplitContainer1.Panel2
			// 
			this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonGroupBox1);
			this.kryptonSplitContainer1.Panel2Collapsed = true;
			this.kryptonSplitContainer1.Panel2MinSize = 50;
			this.kryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
			this.kryptonSplitContainer1.Size = new System.Drawing.Size(447, 305);
			this.kryptonSplitContainer1.SplitterDistance = 159;
			this.kryptonSplitContainer1.TabIndex = 5;
			// 
			// fastColoredTextBox1
			// 
			this.fastColoredTextBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
			this.fastColoredTextBox1.AutoIndentCharsPatterns = "";
			this.fastColoredTextBox1.AutoScrollMinSize = new System.Drawing.Size(131, 28);
			this.fastColoredTextBox1.BackBrush = null;
			this.fastColoredTextBox1.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.fastColoredTextBox1.ChangedLineColor = System.Drawing.Color.Navy;
			this.fastColoredTextBox1.CharHeight = 14;
			this.fastColoredTextBox1.CharWidth = 8;
			this.fastColoredTextBox1.CommentPrefix = "--";
			this.fastColoredTextBox1.CurrentLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.fastColoredTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fastColoredTextBox1.IndentBackColor = System.Drawing.Color.DodgerBlue;
			this.fastColoredTextBox1.IsReplaceMode = false;
			this.fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.SQL;
			this.fastColoredTextBox1.LeftBracket = '(';
			this.fastColoredTextBox1.LineNumberColor = System.Drawing.Color.White;
			this.fastColoredTextBox1.Location = new System.Drawing.Point(0, 0);
			this.fastColoredTextBox1.Name = "fastColoredTextBox1";
			this.fastColoredTextBox1.Paddings = new System.Windows.Forms.Padding(0);
			this.fastColoredTextBox1.RightBracket = ')';
			this.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.fastColoredTextBox1.ServiceColors = null;
			this.fastColoredTextBox1.Size = new System.Drawing.Size(447, 305);
			this.fastColoredTextBox1.TabIndex = 1;
			this.fastColoredTextBox1.Text = "SELECT *\r\nFROM PERMISOS";
			this.fastColoredTextBox1.Zoom = 100;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "icons8-sql.png");
			this.imageList1.Images.SetKeyName(1, "icons8-tabla.png");
			this.imageList1.Images.SetKeyName(2, "table_select_column.png");
			this.imageList1.Images.SetKeyName(3, "icons8-additional.png");
			this.imageList1.Images.SetKeyName(4, "icons8-hashtag-grande.png");
			this.imageList1.Images.SetKeyName(5, "icons8-verdadero-falso.png");
			this.imageList1.Images.SetKeyName(6, "icons8-calendario.png");
			// 
			// SQLPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.kryptonSplitContainer1);
			this.Name = "SQLPage";
			this.Size = new System.Drawing.Size(447, 305);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
			this.kryptonGroupBox1.Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
			this.kryptonGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
			this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
			this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
			this.kryptonSplitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
		private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
		private System.Windows.Forms.ImageList imageList1;
	}
}
