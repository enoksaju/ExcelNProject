using excelnobleza.shared.Auxiliares.VariablesCriticas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace excelnobleza.shared.Models.Tablas.VarCriticas
{
	public class BaseParametros
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int MaquinaId { get; set; }
		[ForeignKey("MaquinaId")]
		public virtual Produccion.Maquina Maquina { get; set; }
		public virtual DateTime FechaCaptura { get; set; }
		public virtual DateTime FechaActualizacion { get; set; }
		public virtual ParameterType<double> Velocidad { get; set; }
		public virtual ParameterType<double> TaperTension { get; set; }
		public int BaseProcesoId { get; set; }
		[ForeignKey("BaseProcesoId")]
		[JsonIgnore]
		public virtual BaseProceso Proceso { get; set; }
	}
}
