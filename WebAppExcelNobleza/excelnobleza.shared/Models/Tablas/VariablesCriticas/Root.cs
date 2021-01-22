using excelnobleza.shared.Auxiliares.VariablesCriticas;
using excelnobleza.shared.Models.Tablas.Produccion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace excelnobleza.shared.Models.Tablas.VariablesCriticas
{
	[Table("VC_Root")]
	public class Root
	{
		/// <summary>
		/// Clave de diseño a la que se asignaran las Variables Criticas
		/// </summary>
		[Key, Column("ClaveDiseno"), MaxLength(50)]
		public string ClaveDiseño { get; set; }

		/// <summary>
		/// Ruta en la que se encuentra la imagen de la figura de salida
		/// </summary>
		public string RutaImagenFigura { get; set; }

		/// <summary>
		/// Tamaño de fotocelda
		/// </summary>
		public ParameterType<string> Fotocelda { get; set; } = new ParameterType<string>("mm");

		/// <summary>
		/// Numero de Codigo de Barras
		/// </summary>
		public string CodigoBarras { get; set; }

		/// <summary>
		/// Ancho del material en el proceso de imPres, contien los valores de tolerancia
		/// </summary>
		public ParameterType<double> Ancho { get; set; } = new ParameterType<double>("cm");

		/// <summary>
		/// Alto o repeticion del diseño en el proceso de impresión, contien los valores de tolerancia
		/// </summary>
		public ParameterType<double> Alto { get; set; } = new ParameterType<double>("cm");

		/// <summary>
		/// Numero de sobre viajero que contiene la informacion del producto asociado al diseño
		/// </summary>
		public string NumeroSobre { get; set; }

		public virtual List<BaseProcesos> Procesos { get; set; } = new List<BaseProcesos>();

		public virtual List<OrdenTrabajo> OrdenesTrabajo { get; set; } = new List<OrdenTrabajo>();

		/// <summary>
		/// Datos de los elementos que participan en la produccion del diseño
		/// </summary>
		public virtual List<EstructuraItem> EstructuraItems { get; set; } = new List<EstructuraItem>();

		[NotMapped]
		public string Estructura
		{
			get
			{
				return "datos de la estructura\nTODO: modificar cosntructor del string"; // TODO: Falta desarrollo
			}
		}
	}
}
