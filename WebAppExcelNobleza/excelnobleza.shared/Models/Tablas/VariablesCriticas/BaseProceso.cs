using excelnobleza.shared.Auxiliares.VariablesCriticas;
using excelnobleza.shared.Models.Tablas.Produccion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace excelnobleza.shared.Models.Tablas.VariablesCriticas
{
	public abstract class BaseProcesos
	{
		private ParameterType<double> _ancho;
		private ParameterType<double> _largo;

		public int Id { get; set; }
		/// <summary>
		/// Clave de diseño al quue esta asociada la informacion
		/// </summary>
		//[Index("UniqueBase", IsUnique = true, Order = 0), Column("ClaveDiseno")]
		[Column("ClaveDiseno"), MaxLength(50)]
		public string ClaveDiseño { get; set; }

		[ForeignKey("ClaveDiseño")]
		public virtual Root Root { get; set; }
		/// <summary>
		/// Id de la maquina Impresora
		/// </summary>
		//[Index("UniqueBase", IsUnique = true, Order = 1), 
		[ForeignKey("Maquina")]
		public int MaquinaId { get; set; }


		//[Index("UniqueBase", IsUnique = true, Order = 2), 
		[Required(ErrorMessage = "El tipo de proceso es requerido")]
		public int TipoProceso { get; set; }

		[ForeignKey("TipoProceso")]
		public virtual Proceso Proceso { get; set; }

		/// <summary>
		/// Datos de la maquina asociada a la informacion
		/// </summary>
		public virtual Maquina Maquina { get; set; }

		/// <summary>
		/// Figura de salida del proceso
		/// </summary>
		public int FiguraSalida { get; set; }

		/// <summary>
		/// Dureza que deberan tener las bobinas resultantes, el valor predeterminado es min:26 std:36 max:46
		/// </summary>
		public ParameterType<double> Dureza { get; set; } = new ParameterType<double>("cm", 36, 26, 46);

		/// <summary>
		/// Comentarios sobre la informacion del proceso
		/// </summary>
		public string Comentarios { get; set; }

		/// <summary>
		/// Velocidad registrada para la produccion del producto
		/// </summary>
		public ParameterType<double> ParVelocidad { get; set; } = new ParameterType<double>("m/min");

		/// <summary>
		/// Par: Ten Decreciente
		/// </summary>
		public ParameterType<double> ParTenDecreciente { get; set; }

		/// <summary>
		/// Par 
		/// </summary>
		public ParameterType<double> ParPotenciaTratador { get; set; } = new ParameterType<double>("%");

		/// <summary>
		/// Fecha en que se realizó la captura de la información
		/// </summary>
		public DateTime FechaCaptura { get; set; }

		/// <summary>
		/// Fecha de la ultima actualización de la información
		/// </summary>
		public DateTime FechaActualizacion { get; set; }

		public BaseProcesos()
		{
			FechaCaptura = DateTime.Now;
		}
	}
}
