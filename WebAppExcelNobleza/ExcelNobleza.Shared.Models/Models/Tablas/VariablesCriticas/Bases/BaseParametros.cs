using ExcelNobleza.Shared.Models.ComplexObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Bases
{
	public class BaseParametros
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[ForeignKey("Maquina")]
		public int MaquinaId { get; set; }
		public virtual Produccion.Maquina Maquina { get; set; }
		public virtual DateTime FechaCaptura { get; set; }
		public virtual DateTime FechaActualizacion { get; set; }
		public string Comentarios { get; set; } = "";
		public virtual ParameterType<double> Velocidad { get; set; } = new ParameterType<double>();
		public virtual ParameterType<double> TaperTension { get; set; } = new ParameterType<double>();

		[ForeignKey("Proceso")]
		public int BaseProcesoId { get; set; }
		public virtual BaseProceso Proceso { get; set; }
	}
}
