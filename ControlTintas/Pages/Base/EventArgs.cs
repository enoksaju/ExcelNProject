using ComponentFactory.Krypton.Navigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTintas.Pages.Base {
    public class EnterPageEventArgs : EventArgs
    {
        public KryptonPage Item { get; set; }
        public string ContextNames { get; set; }
    }

    public class LeavePageEventArgs : EventArgs
    {
        public KryptonPage Item { get; set; }
        public string ContextNames { get; set; }
    }

	public class ChangeStatusMessageEventArgs : EventArgs {
		/// <summary>
		/// Mensaje del evento
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Titulo del mensaje
		/// </summary>
		public string Title { get; set; }
	}

}
