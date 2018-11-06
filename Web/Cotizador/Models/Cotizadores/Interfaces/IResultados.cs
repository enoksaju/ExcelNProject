using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizador.Models.Cotizadores.Interfaces
{
	public interface IResultados
	{
		ICalc Parent { get; set; }
		double PorcentDesperdicio { get; }
		double PrecioDesperdicio { get; }

		double CostoReal_Desperdicio { get; }
		double CostoReal_Total { get; }

		double PrecioObjetivo { get;  }
		double PrecioUltimo { get;  }
		double Comision_Kg { get; }
		double Comision_Total { get; }
		double Comision_Equivalente { get; }
	}
}
