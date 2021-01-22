using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace excelnobleza.shared.Models.Tablas.Produccion
{
	[Table("TPRODUCCION")]
	public class Produccion
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "El numero de orden de trabajo es requerido")]
		public string OT { get; set; }


		[Required(ErrorMessage = "El tipo de proceso es requerido")]
		public int TIPOPROCESO { get; set; }

		//[Index]
		public int NUMERO { get; set; }

		public double PESOBRUTO { get; set; }

		[NotMapped]
		public double PESONETO { get { try { return PESOBRUTO - PESOCORE; } catch { return 0; } } }
		public double PESOCORE { get; set; }
		public int PIEZAS { get; set; }
		public int BANDERAS { get; set; }
		public int MAQUINA { get; set; }
		public string ORIGEN { get; set; }
		public string OPERADOR { get; set; }
		public int TURNO { get; set; }
		public DateTime FECHA { get; set; }
		public short ENSANEO { get; set; }
		public short FUESANEADA { get; set; }
		public short FUEEDITADA { get; set; }
		public short ESRECHAZADA { get; set; }
		public string USUARIO { get; set; }

		//[Index(IsUnique = true)]
		[MaxLength(128)]
		public string INDICE { get; set; }
		public int REPETICION { get; set; }
		public string EXTRUSION_ID { get; set; }

		[ForeignKey("TIPOPROCESO")]
		public virtual Proceso Proceso_ { get; set; }

		[ForeignKey("MAQUINA")]
		public virtual Maquina Maquina_ { get; set; }

		[ForeignKey("OT")]
		public virtual OrdenTrabajo OrdenTrabajo { get; set; }

		// Control de dureza en bobinas
		public double? DurezaIzquierda { get; set; }
		public double? DurezaDerecha { get; set; }
		public double? DurezaCentro { get; set; }

		// Almacenamiento del Item de la bobina
		public string Item { get; set; }

		/// <summary>
		/// Almacena los comentarios sobre la bobina capturada
		/// </summary>
		public string Comentarios { get; set; }
		public bool EnSaneoArrugas { get; set; }
	}
}
