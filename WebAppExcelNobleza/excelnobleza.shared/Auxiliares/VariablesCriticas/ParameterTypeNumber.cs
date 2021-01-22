using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text;

namespace excelnobleza.shared.Auxiliares.VariablesCriticas
{
	[Owned]
	[ComplexType]
	public class ParameterType<T>
	{
		public T Std { get; set; }
		public T Min { get; set; }
		public T Max { get; set; }
		public string Unidad { get; set; }
		public ParameterType() : this(default, default, default, default) { }
		public ParameterType(string unidad) : this(unidad, default, default, default) { }
		public ParameterType(string unidad, T std) : this(unidad, std, default, default) { }
		public ParameterType(string unidad, T std, T min, T max)
		{
			this.Unidad = unidad;
			this.Std = std;
			this.Min = min;
			this.Max = max;
		}
	}
}
