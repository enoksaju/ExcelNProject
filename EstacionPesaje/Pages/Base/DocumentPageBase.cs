using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libProduccionDataBase.Contexto;

namespace EstacionesPesaje.Pages.Base {
	public partial class DocumentPageBase : DefaultPageContent, IToKryptonPage {

		public DataBaseContexto DB = null;
		public DocumentPageBase () {
			InitializeComponent ( );
		}
	}
}
