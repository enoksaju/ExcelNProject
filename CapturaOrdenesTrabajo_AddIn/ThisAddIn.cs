using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Windows.Forms;

namespace CapturaOrdenesTrabajo_AddIn
{
    public partial class ThisAddIn
    {
		public NotifyIcon ntMSG { get; set; }

		private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
			this.ntMSG = new NotifyIcon ( );
			this.ntMSG.Icon = Properties.Resources.OTICON;
			this.ntMSG.Visible = true;
		}

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
			this.ntMSG.Visible = false;
			this.ntMSG.Dispose ( );
		}

        #region Código generado por VSTO

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
