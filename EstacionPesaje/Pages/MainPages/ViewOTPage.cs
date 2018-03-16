using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstacionesPesaje.Pages.MainPages {
	public partial class ViewOTPage : Base.DocumentPageBase {
		public ViewOTPage () {
			InitializeComponent ( );
		}

		private void ctlEmptyOTs1_ChangeOT ( object sender, string Name ) {
			PageTitleText ="OT "+ Name;
		}
	}
}
