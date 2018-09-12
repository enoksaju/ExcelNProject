using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cotizador.Models.FrontEndModels.Catalogos
{
	public class Impresora
	{
		private libProduccionDataBase.Tablas.ObservableListSource<Rodillo> _Rodillos = new libProduccionDataBase.Tablas.ObservableListSource<Rodillo> ( );

		public int? Id { get; set; }

		[Required ( ErrorMessage = "El nombre de la Maquina es requerido" )]
		public string NombreMaquina { get; set; }
		public string ModeloMaquina { get; set; }

		[Required]
		public double? CostoArranque { get; set; }

		[Required]
		public double? CostoTurno { get; set; }

		[Required]
		public double? PorcentajeDesperdicio { get; set; }

		[Required]
		public int? MinutosTurno { get; set; }

		[Required]
		public double? AnchoMinimoImpresion { get; set; }

		[Required]
		public double? AnchoMaximoImpresion { get; set; }

		[Required]
		public double? AnchoMinimoMaterial { get; set; }

		[Required]
		public double? AnchoMaximoMaterial { get; set; }

		[Required ( ErrorMessage = "La velocidad de la Maquina es requerida" )]
		public double? Velocidad { get; set; }

		[Required ( ErrorMessage = "El Numero de Decks de la Maquina es requerido" )]
		public int? Decks { get; set; }
		public virtual libProduccionDataBase.Tablas.ObservableListSource<libProduccionDataBase.Tablas.configTintaMaquina> ConfiguracionTintas { get; set; } = new libProduccionDataBase.Tablas.ObservableListSource<libProduccionDataBase.Tablas.configTintaMaquina> ( );

		public virtual libProduccionDataBase.Tablas.ObservableListSource<Rodillo> Rodillos { get; set; } = new libProduccionDataBase.Tablas.ObservableListSource<Rodillo> ( );

		[Required ( ErrorMessage = "La Linea a la que pertenece la maquina es requerida" )]
		public int? Linea_Id { get; set; }

		public string LineaNombre { get; set; }
	}

	public class Rodillo
	{
		public int? Id { get; set; }
		[Required]
		public double? Medida { get; set; }
		[Required]
		public int? Cantidad { get; set; }

		public static libProduccionDataBase.Tablas.ObservableListSource<Rodillo> fromObservableList ( libProduccionDataBase.Tablas.ObservableListSource<libProduccionDataBase.Tablas.Rodillo> lista )
		{
			var y = new libProduccionDataBase.Tablas.ObservableListSource<Rodillo> ( );

			foreach ( var item in lista )
			{
				y.Add ( new Rodillo ( ) { Cantidad = item.Cantidad, Medida = item.Medida, Id = item.Id } );
			}
			return y;
		}
	}
}