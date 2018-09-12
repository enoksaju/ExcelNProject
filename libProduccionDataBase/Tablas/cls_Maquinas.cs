using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace libProduccionDataBase.Tablas
{
	/// <summary>
	/// Maquinas Existentes
	/// </summary>
	[Table ( "Maquinas" )]
	[Serializable]
	public class Maquina
	{
		private ObservableListSource<Rodillo> _Rodillos= new ObservableListSource<Rodillo>();
		private ObservableListSource<Produccion> _Produccion= new ObservableListSource<Tablas.Produccion>();
		private ObservableListSource<Desperdicio> _Desperdicio= new ObservableListSource<Tablas.Desperdicio>();

		public int Id { get; set; }

		[Required ( ErrorMessage = "El nombre de la Maquina es requerido" )]
		public string NombreMaquina { get; set; }		
		public string ModeloMaquina { get; set; }

		#region ForCotizador

		public double? CostoArranque { get; set; }

		public double? CostoTurno { get; set; }

		public double? PorcentajeDesperdicio { get; set; }

		public int? MinutosTurno { get; set; }

		public double? AnchoMinimoImpresion { get; set; }

		public double? AnchoMaximoImpresion { get; set; }

		public double? AnchoMinimoMaterial { get; set; }

		public double? AnchoMaximoMaterial { get; set; }

		[Required ( ErrorMessage = "La velocidad de la Maquina es requerida" )]
		public double? Velocidad { get; set; }

		[Required ( ErrorMessage = "El Numero de Decks de la Maquina es requerido" )]
		public int? Decks { get; set; }
		public virtual ObservableListSource<configTintaMaquina> ConfiguracionTintas { get; set; }

		#endregion
		

		[InverseProperty ( "Maquina" )]
		public virtual ObservableListSource<Rodillo> Rodillos { get { return _Rodillos; } private set { _Rodillos = value; } }
		public virtual ObservableListSource<Produccion> Produccion { get { return _Produccion; } private set { _Produccion = value; } }
		public virtual ObservableListSource<Desperdicio> Desperdicio { get { return _Desperdicio; } private set { _Desperdicio = value; } }

		[Required ( ErrorMessage = "El Tipo de maquina es requerido" )]
		public int? TipoMaquina_Id { get; set; }
		[ForeignKey ( "TipoMaquina_Id" )]
		public virtual TipoMaquina TipoMaquina { get; set; }

		[Required ( ErrorMessage = "La Linea a la que pertenece la maquina es requerida" )]
		[ForeignKey("Linea")]
		public int? Linea_Id { get; set; }
		public virtual Linea Linea { get; set; }
		
		public override string ToString () => this.NombreMaquina;

	}

	/// <summary>
	/// Un Rodillo debe pertenecer a una maquina de Tipo Impresora
	/// </summary>
	[Table ( "Rodillos" )]
	public class Rodillo
	{
		public int Id { get; set; }
		public double Medida { get; set; }
		public int Cantidad { get; set; }
		[Required]
		[ScriptIgnore]
		public virtual Maquina Maquina { get; set; }

		public override string ToString () => this.Medida.ToString ( "#0.00" );
	}

	/// <summary>
	/// Define los tipos de maquinas en la Base de Datos
	/// </summary>
	[Table ( "TiposMaquina" )]
	[DefaultProperty ( "Id" )]
	public class TipoMaquina
	{
		private ObservableListSource<Maquina> _Maquinas = new ObservableListSource<Maquina> ( );
		public int Id { get; set; }
		public string Tipo_Maquina { get; set; }
		public virtual ObservableListSource<Maquina> Maquinas { get { return _Maquinas; } }
		public override string ToString () => this.Tipo_Maquina;
	}

	[Table ( "Lineas" )]
	public class Linea
	{
		//private ObservableListSource<Maquina> _Maquinas = new ObservableListSource<Maquina>();
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Responsable { get; set; }
		public string EmailResponsable { get; set; }

		public virtual ObservableListSource<Maquina> Maquinas { get; } = new ObservableListSource<Maquina> ( );

		public override string ToString () => this.Nombre;
	}

	[Table("config_tintas_maquina") ]
	public class configTintaMaquina
	{
		[Key, Column ( Order = 0 ), DatabaseGenerated ( DatabaseGeneratedOption.None )]
		public int MaquinaId { get; set; }
		[Key, Column ( Order = 1 ), DatabaseGenerated ( DatabaseGeneratedOption.None )]
		public int Cantidad { get; set; }
		[Required ( ErrorMessage = "El metraje minimo para el numero de tintas es requerido" )]
		public double MinimoMetros { get; set; }
	}

}
