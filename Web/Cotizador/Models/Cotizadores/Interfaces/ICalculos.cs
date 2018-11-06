using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizador.Models.Cotizadores.Interfaces
{
	public enum tiposCalculos
	{
		m2, kg, real
	}
	public interface ICalculos
	{
		tiposCalculos Tipo { get; }
		double CostoPelicula { get; }
		double CostoArranque { get; }
		double CostoTinta { get; }
		double CostoSolvente { get; }
		double TintaResidual { get; }
		double PrecioMaquina { get; }
		double CostoDesperdicio { get; }
		double CostoStikyback { get; }
		double CostoTotal { get; }
	}

	public abstract class CalculosBase<T> : ICalculos where T : ICalc
	{
		T ICalc { get; }
		public abstract double CostoArranque { get; }
		public abstract double CostoDesperdicio { get; }
		public abstract double CostoPelicula { get; }
		public abstract double CostoSolvente { get; }
		public abstract double CostoStikyback { get; }
		public abstract double CostoTinta { get; }
		public abstract double CostoTotal { get; }
		public abstract double PrecioMaquina { get; }
		public abstract double TintaResidual { get; }
		public virtual tiposCalculos Tipo { get; private set; }

		public CalculosBase(T ICalc )
		{
			this.ICalc = ICalc;
		}
	}

}
