using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProduccionDataBase.Tablas;

namespace ControlProgramaProduccion.Controles
{
	public class DropCompletedEventArg : EventArgs
	{
		public DataBaseViewModels.PlaneacionProduccionViewModel Item { get; set; }
		public bool fromUnasigned { get; set; }
		public DropCompletedEventArg ( DataBaseViewModels.PlaneacionProduccionViewModel Item, bool fromUnasigned )
		{
			this.Item = Item;
			this.fromUnasigned = fromUnasigned;
		}
	}
}
