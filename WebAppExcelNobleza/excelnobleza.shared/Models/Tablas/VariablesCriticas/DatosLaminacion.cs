using excelnobleza.shared.Auxiliares.VariablesCriticas;
using System;
using System.Collections.Generic;
using System.Text;

namespace excelnobleza.shared.Models.Tablas.VariablesCriticas
{
	public class DatosLaminacion:BaseProcesos
	{
		/// <summary>
		/// Ancho de la goma que se utiliza para el proceso de laminación
		/// </summary>
		public double? GomaMedida { get; set; }

		/// <summary>
		/// Ancho util de la laminacion
		/// </summary>
		public double? GomaAnchoUtil { get; set; }

		/// <summary>
		/// Ancho total laminado
		/// </summary>
		public double? GomaAnchoTotal { get; set; }

		/// <summary>
		/// Comentarios referentes al estado de la goma
		/// </summary>
		public string GomaComentarios { get; set; }

		/// <summary>
		/// Clave de la resina
		/// </summary>		
		public string AdhResinaClave { get; set; }

		/// <summary>
		/// Clave del catalizador o del segundo elemento en solventbase
		/// </summary>
		public string AdhCatalizadorClave { get; set; }

		/// <summary>
		/// Par Relacion de Catalizador
		/// </summary>
		public ParameterType<double> ParAdhCatalizadorRelacion { get; set; } = new ParameterType<double>("%");

		/// <summary>
		/// Par: Aplicacion de Adh por metro cuadrado
		/// </summary>
		public ParameterType<double> ParAdhAplicacion { get; set; } = new ParameterType<double>("");

		/// <summary>
		/// Par: Temp de la resina
		/// </summary>
		public ParameterType<double> ParTempResina { get; set; } = new ParameterType<double>("°C");

		/// <summary>
		/// Par: Temp del Catalizador
		/// </summary>
		public ParameterType<double> ParTempCatalizador { get; set; } = new ParameterType<double>("°C");

		/// <summary>
		/// Par: Temp del Rod Aplicador
		/// </summary>
		public ParameterType<double> ParTempRodAplicador { get; set; } = new ParameterType<double>("°C");

		/// <summary>
		/// Par: Temp del Rod Laminador
		/// </summary>
		public ParameterType<double> ParTempRodLaminador { get; set; } = new ParameterType<double>("°C");

		/// <summary>
		/// Par: Pres Rod Mangas 
		/// </summary>
		public ParameterType<double> ParPresRodMangas { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par: Pres Rod Laminador Izquierdo 
		/// </summary>
		public ParameterType<double> ParPresRodLaminadorIzquierdo { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par: Pres Rod Laminador Derecho 
		/// </summary>
		public ParameterType<double> ParPresRodLaminadorDerecho { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par: Pesion Rod Presor Izquierdo 
		/// </summary>
		public ParameterType<double> ParPresRodPresorIzquierdo { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par: Pres Rod Presor Derecho 
		/// </summary>
		public ParameterType<double> ParPresRodPresorDerecho { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par: Pres Rod Aplicador  
		/// </summary>
		public ParameterType<double> ParPresRodAplicador { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par: Galga Izquierdo 
		/// </summary>
		public ParameterType<double> ParGalgaIzquierda { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par:Galga Derecha 
		/// </summary>
		public ParameterType<double> ParGalgaDerecha { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par: Ten Desbobinador uno 
		/// </summary>
		public ParameterType<double> ParTenDesbobinadorUno { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par: Ten Desbobinador dos 
		/// </summary>
		public ParameterType<double> ParTenDesbobinadorDos { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par:Ten embobinador 
		/// </summary>
		public ParameterType<double> ParTenBobinador { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par:Ten Puente 
		/// </summary>
		public ParameterType<double> ParTenPuente { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par: Curling en grados
		/// </summary>
		public ParameterType<double> Curling { get; set; } = new ParameterType<double>("°");

		/// <summary>
		/// Par: Fuerza de laminado 40 minutos 
		/// </summary>
		public ParameterType<double> FuerzaLaminacionUno { get; set; } = new ParameterType<double>("");

		/// <summary>
		/// Par: Fuerza de laminado 4 horas 
		/// </summary>
		public ParameterType<double> FuerzaLaminacionDos { get; set; } = new ParameterType<double>("");

		/// <summary>
		/// Elemento del desbobinador Unod
		/// </summary>
		public string DesbobinadorUnoElemento { get; set; }

		/// <summary>
		/// Tratado del elemento del desbobinador uno
		/// </summary>
		public ParameterType<string> DesbobinadorUnoTratado { get; set; } = new ParameterType<string>("Dinas", "38", "38", ">38");

		/// <summary>
		/// Elemento del desbobinador dos
		/// </summary>
		public string DesbobinadorDosElemento { get; set; }

		/// <summary>
		/// Tratado del elemento del desbobinador dos
		/// </summary>
		public ParameterType<string> DesbobinadorDosTratado { get; set; } = new ParameterType<string>("Dinas", "38", "38", ">38");
	}
}
