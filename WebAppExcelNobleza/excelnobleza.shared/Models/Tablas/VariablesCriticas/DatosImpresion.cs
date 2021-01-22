using excelnobleza.shared.Auxiliares.VariablesCriticas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace excelnobleza.shared.Models.Tablas.VariablesCriticas
{
	/// <summary>
	/// Contiene los datos de las variables criticas del proceso de impresión para una impresora especifica
	/// </summary>
	public class DatosImpresion: BaseProcesos
	{
		/// <summary>
		/// Se utiliza para seleccionar el tipo de Par que se rellenearan en el formato
		/// </summary>
		public enum TiposImpresora { gearless, engranes }

		/// <summary>
		///  Tipo de impresora al que pertenece la informacion (gearless o engranes)
		/// </summary>
		public TiposImpresora TipoImpresora { get; set; }

		/// <summary>
		/// Tipo de tinta que se utilizará para procesar el producto
		/// </summary>
		public string TipoTinta { get; set; }

		/// <summary>
		/// Par 
		/// </summary>
		public ParameterType<double> ParPresRodPisorCalandra { get; set; } = new ParameterType<double>("Bar");

		/// <summary>
		/// Par 
		/// </summary>
		public ParameterType<double> ParPresRodTamborCentral { get; set; } = new ParameterType<double>("Bar");

		/// <summary>
		/// Par 
		/// </summary>
		public ParameterType<double> ParPresRodPisorEmbobinador { get; set; } = new ParameterType<double>("Bar");

		/// <summary>
		/// Par 
		/// </summary>
		public ParameterType<double> ParTenEmbobinador { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par 
		/// </summary>
		public ParameterType<double> ParTenBanda { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par 
		/// </summary>
		public ParameterType<double> ParTenArrastreODesbobinador { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par Gearless 
		/// </summary>
		public ParameterType<double> ParGTenRodRefrigerante { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par Grarless
		/// </summary>
		public ParameterType<double> ParGFuerzaApriete { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par Grarless
		/// </summary>
		public double? ParGDiametroInicial { get; set; }

		/// <summary>
		/// Par Grarless
		/// </summary>
		public double? ParGDiametroFinal { get; set; }

		/// <summary>
		/// Par Engranes
		/// </summary>
		public ParameterType<double> ParEPresBalancinEmbobinador { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par Engranes
		/// </summary>
		public ParameterType<double> ParEPresBalancinDesbobinador { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par Engranes
		/// </summary>
		public ParameterType<double> ParEOffset { get; set; } = new ParameterType<double>("N");

		/// <summary>
		/// Par 
		/// </summary>
		public ParameterType<string> ParTempPuente { get; set; } = new ParameterType<string>("°C");

		/// <summary>
		/// Par 
		/// </summary>
		public ParameterType<string> ParTempEntrecolores { get; set; } = new ParameterType<string>("°C");
				
		public virtual List<DecksImpresion> Decks { get; set; } = new List<DecksImpresion>();
	}
}
