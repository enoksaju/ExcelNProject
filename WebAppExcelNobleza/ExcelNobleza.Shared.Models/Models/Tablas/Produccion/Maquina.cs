using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.Produccion
{
	public class Maquina
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "El nombre de la Maquina es requerido")]
		//[StringLength(150, ErrorMessage = "{0} debe tener {1} caracteres como máximo")]
		public string NombreMaquina { get; set; }

		//[StringLength(150, ErrorMessage = "{0} debe tener {1} caracteres como máximo")]
		public string ModeloMaquina { get; set; } = "";

		//#region ForCotizador

		//public double? CostoArranque { get; set; }

		//public double? CostoTurno { get; set; }

		//public double? PorcentajeDesperdicio { get; set; }

		//public int? MinutosTurno { get; set; }

		//public double? AnchoMinimoImpresion { get; set; }

		//public double? AnchoMaximoImpresion { get; set; }

		//public double? AnchoMinimoMaterial { get; set; }

		//public double? AnchoMaximoMaterial { get; set; }

		//[Required(ErrorMessage = "La velocidad de la Maquina es requerida")]
		//public double? Velocidad { get; set; }

		//[Required(ErrorMessage = "El Numero de Decks de la Maquina es requerido")]
		//public int? Decks { get; set; }
		//public virtual ObservableListSource<configTintaMaquina> ConfiguracionTintas { get; set; }

		//#endregion
		//[InverseProperty("Maquina")]
		//public virtual ObservableListSource<Rodillo> Rodillos { get { return _Rodillos; } private set { _Rodillos = value; } }

		[Required(ErrorMessage = "El Tipo de maquina es requerido")]
		[Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un elemento")]
		public int? TipoMaquina_Id { get; set; } = -1;
		[ForeignKey("TipoMaquina_Id")]
		public virtual TipoMaquina TipoMaquina { get; set; }

		[Required(ErrorMessage = "La Linea a la que pertenece la maquina es requerida")]
		[ForeignKey("Linea")]
		[Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un elemento")]
		public int? Linea_Id { get; set; } = -1;

		public virtual Linea Linea { get; set; }

		public override string ToString() => this.NombreMaquina;

		//[NotMapped]
		//public TiposProcesoProduccion Procesos
		//{
		//	get
		//	{
		//		switch (TipoMaquina_Id)
		//		{
		//			case 1:
		//				return TiposProcesoProduccion.Impresion;
		//			case 2:
		//				return TiposProcesoProduccion.Laminacion | TiposProcesoProduccion.Trilaminacion | TiposProcesoProduccion.Trilaminacion;
		//			case 3:
		//				return TiposProcesoProduccion.Corte | TiposProcesoProduccion.Refinado | TiposProcesoProduccion.Embobinado;
		//			case 4:
		//				return TiposProcesoProduccion.Doblado | TiposProcesoProduccion.Embobinado;
		//			case 5:
		//			case 6:
		//				return TiposProcesoProduccion.Sellado;
		//			case 7:
		//				return TiposProcesoProduccion.Extrusion;
		//			case 8:
		//				return TiposProcesoProduccion.Embobinado;
		//			case 9:
		//				return TiposProcesoProduccion.Troquelar | TiposProcesoProduccion.Microperforado | TiposProcesoProduccion.Embobinado;
		//			default:
		//				return TiposProcesoProduccion.Impresion;
		//		}

		//	}
		//}
	}
}
