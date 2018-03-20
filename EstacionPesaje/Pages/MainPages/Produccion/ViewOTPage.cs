using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstacionPesaje.Pages.MainPages {
	public partial class ViewOTPage : Base.DocumentPageBase {
		public ViewOTPage () {
			InitializeComponent ( );
			KP.ImageSmall = Properties.Resources.report_open1;
		}

		private void ctlEmptyOTs1_ChangeOT ( object sender, string Name ) {
			PageTitleText ="OT "+ Name;
		}
	}
}
