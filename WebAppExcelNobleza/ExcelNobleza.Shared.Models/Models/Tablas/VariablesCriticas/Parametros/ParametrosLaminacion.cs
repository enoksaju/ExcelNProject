using ExcelNobleza.Shared.Models.ComplexObjects;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Parametros
{
	public class ParametrosLaminacion : BaseParametros
	{
		public virtual ParameterType<double> TemperaturaResina { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> TemperaturaCatalizador { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> TemperaturaRodilloAplicador { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> TemperaturaRodilloLaminador { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> PresionRodilloMangas { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> RodilloLaminadorPresionIzquierda { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> RodilloPresorPresionIzquierda { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> GalgaRodilloAplicacionIzquierda { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> PotenciaTratador { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> TensionDesbobinadorUno { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> TensionDesbobinadorDos { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> TensionBobinador { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> TensionPuente { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> PresionRodilloAplicador { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> RodilloLaminadorPresionDerecha { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> RodilloPresorPresionDerecha { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> GalgaRodilloAplicacionDerecha { get; set; } = new ParameterType<double>();

		[Column("Manga_A")]
		public double MangaAncho { get; set; } = 0;
		[Column("Manga_UA")]
		public double MangaUtilAdhesivo { get; set; } = 0;
		[Column("Manga_TL")]
		public double MangaTotalLaminado { get; set; } = 0;
	}
}
