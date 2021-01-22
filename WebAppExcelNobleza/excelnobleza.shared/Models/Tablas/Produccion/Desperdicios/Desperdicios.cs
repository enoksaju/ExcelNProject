using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace excelnobleza.shared.Models.Tablas.Produccion.Desperdicios
{
	[Table("TDESPERDICIOS")]
	public class Desperdicio
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "El numero de orden de trabajo es requerido")]
		public string OT { get; set; }
		[Required(ErrorMessage = "EL operador es requerido")]
		public string OPERADOR { get; set; }
		public int TURNO { get; set; }
		public int MAQUINA { get; set; }
		public int NUMERO { get; set; }
		public double PESO { get; set; }
		public int DEFECTO { get; set; }
		public string DESCRIPCION { get; set; }
		public DateTime FECHA { get; set; }
		public string USUARIO { get; set; }
		public string ESTRUCTURA { get; set; }
		[ForeignKey("DEFECTO")]
		public virtual TFamiliaDefectosTDefecto FamiliaDefectosDefecto { get; set; }

		//[ForeignKey("OT")]
		//public virtual TemporalOrdenTrabajo OrdenTrabajo { get; set; }

		[ForeignKey("MAQUINA")]
		public virtual Maquina Maquina_ { get; set; }

		[NotMapped]
		public virtual TFamiliaDefectos FamiliaDefecto { get { return FamiliaDefectosDefecto?.FamiliaDefectos; } }
	}
}
