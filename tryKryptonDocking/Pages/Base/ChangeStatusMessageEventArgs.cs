using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tryKryptonDocking.Pages.Base
{
    /// <summary>
    /// Clase que contiene los argumentos del evento de cambio del mensaje de estado
    /// </summary>
    public class ChangeStatusMessageEventArgs : EventArgs
    {
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
