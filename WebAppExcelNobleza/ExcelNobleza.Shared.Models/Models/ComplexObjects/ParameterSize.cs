using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.ComplexObjects
{
	[ComplexType]
	[Owned]
	public class ParameterSize
	{
		public virtual ParameterType<double> Alto { get; private set; }
		public virtual ParameterType<double> Ancho { get; private set; }

		public ParameterSize() : this("mm", default, default, 0, 0) { }
		public ParameterSize(string unidad) : this(unidad, default, default, 0, 0) { }
		public ParameterSize(string unidad, double anchoStd, double altoStd, double toleranciaAncho, double toleranciaAlto) : this(unidad, anchoStd, altoStd, altoStd - toleranciaAlto, altoStd + toleranciaAlto, anchoStd - toleranciaAncho, anchoStd + toleranciaAncho)
		{
		}
		public ParameterSize(string unidad, double anchoStd, double altoStd, double minAlto, double maxAlto, double minAncho, double maxAncho)
		{
			this.Alto = new ParameterType<double>(unidad, altoStd, minAlto, maxAlto);
			this.Ancho = new ParameterType<double>(unidad, anchoStd, minAncho, maxAncho);
		}
	}
}
