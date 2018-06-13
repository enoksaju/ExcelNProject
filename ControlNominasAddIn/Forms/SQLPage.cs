using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Navigator;
using System.Data.OleDb;

namespace ControlNominasAddIn.Forms {
	public partial class SQLPage : UserControl {
		public KryptonPage KP { get; set; }

		public string PageTitleText {
			get { return KP.TextTitle; }
			set { KP.TextTitle = value; KP.Text = value; }
		}
		public string PageDescriptionText {
			get { return KP.TextDescription; }
			set { KP.TextDescription = value; }
		}

		public SQLPage ( ) {
			InitializeComponent ( );
			KP = new KryptonPage ( );
			this.PageTitleText = "new query";
		}
		public KryptonPage GetKryptonPage ( ) {
			if ( !this.KP.Controls.Contains ( this ) ) {
				this.Dock = DockStyle.Fill;
				this.KP.Controls.Add ( this );
			}
			return this.KP;
		}
	}
}
