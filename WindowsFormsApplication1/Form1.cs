using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace WindowsFormsApplication1 {
	public partial class Form1 : KryptonForm {

		private System.ComponentModel.IContainer components = null;
				
		protected override void Dispose ( bool disposing ) {
			if (disposing && ( components != null )) {
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		private void InitializeComponent () {
			this.components = new System.ComponentModel.Container();
			this.kryptonRibbon1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbon();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).BeginInit();
			this.SuspendLayout();

			this.kryptonRibbon1.InDesignHelperMode = true;
			this.kryptonRibbon1.Name = "kryptonRibbon1";
			this.kryptonRibbon1.SelectedContext = null;
			this.kryptonRibbon1.SelectedTab = null;
			this.kryptonRibbon1.Size = new System.Drawing.Size(535, 114);
			this.kryptonRibbon1.TabIndex = 0;

			this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2013White;

			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(535, 398);
			this.Controls.Add(this.kryptonRibbon1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public Form1 () {
			InitializeComponent ( );
		}
	}
}
