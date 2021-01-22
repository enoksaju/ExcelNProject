using excelnobleza.shared.Auxiliares.VariablesCriticas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static excelnobleza.shared.Enums.DataBaseEnums;

namespace excelnobleza.shared.Models.Tablas.VariablesCriticas
{
	
	public class EstructuraItem
	{
		/// <summary>
		/// Diseño al que pertenece el Item
		/// </summary>		
		[Column("ClaveDiseno"), MaxLength(50)]
		public string ClaveDiseño { get; set; }

		/// <summary>
		/// Posicion del elemento en la estructura
		/// </summary>		
		public int Posicion { get; set; }

		/// <summary>
		/// Descripcion del elemento {Sustrato, tinta, Adh, tratado, etc.}
		/// </summary>
		public string Elemento { get; set; }

		/// <summary>
		/// Ancho del elemento, solo si aplica
		/// </summary>
		public string Ancho { get; set; }

		/// <summary>
		/// Calibre del elemento, solo si aplica
		/// </summary>
		public string Calibre { get; set; }

		/// <summary>
		/// Unidad del calibre
		/// </summary>
		public Unidades_Calibre UnidadCalibre { get; set; } = Unidades_Calibre.NA;

		/// <summary>
		/// Descripcion o comentarios del elemento
		/// </summary>
		public string Descripcion { get; set; }

		/// <summary>
		///  Indica si el elemento es utilizado para impresión
		/// </summary>
		public bool SeImprime { get; set; } = false;

		/// <summary>
		/// Indica si el elemento es un suistrato
		/// </summary>
		public bool EsSustrato { get; set; } = false;

		/// <summary>
		/// Indica el Tratado que debe tener un elemento si es un sustrato. por defecto 38 Dinas
		/// </summary>
		public ParameterType<string> Tratado { get; set; } = new ParameterType<string>("Dinas", "38", "38", ">38");

		[ForeignKey("ClaveDiseño")]
		public virtual Root Root { get; set; }
	}
}
