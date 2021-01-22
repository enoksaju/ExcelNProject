using excelnobleza.shared.Auxiliares.VariablesCriticas;
using System;
using System.Collections.Generic;
using System.Text;

namespace excelnobleza.shared.Models.Tablas.VarCriticas
{
	public class ParametrosLaminacion : BaseParametros
	{
		public virtual ParameterType<double> TemperaturaResina { get; set; }
		public virtual ParameterType<double> TemperaturaCatalizador { get; set; }
		public virtual ParameterType<double> TemperaturaRodilloAplicador { get; set; }
		public virtual ParameterType<double> TemperaturaRodilloLaminador { get; set; }
		public virtual ParameterType<double> PresionRodilloMangas { get; set; }
		public virtual ParameterType<double> RodilloLaminadorPresionIzquierda { get; set; }
		public virtual ParameterType<double> RodilloPresorPresionIzquierda { get; set; }
		public virtual ParameterType<double> GalgaRodilloAplicacionIzquierda { get; set; }
		public virtual ParameterType<double> PotenciaTratador { get; set; }
		public virtual ParameterType<double> TensionDesbobinadorUno { get; set; }
		public virtual ParameterType<double> TensionDesbobinadorDos { get; set; }
		public virtual ParameterType<double> TensionBobinador { get; set; }
		public virtual ParameterType<double> TensionPuente { get; set; }
		public virtual ParameterType<double> PresionRodilloAplicador { get; set; }
		public virtual ParameterType<double> RodilloLaminadorPresionDerecha { get; set; }
		public virtual ParameterType<double> RodilloPresorPresionDerecha { get; set; }
		public virtual ParameterType<double> GalgaRodilloAplicacionDerecha{ get; set; }
	}
}
