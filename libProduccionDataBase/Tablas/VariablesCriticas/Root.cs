using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas.VariablesCriticas
{
	[Table("VC_Root")]
	public class VariablesCriticasRoot
	{
		/// <summary>
		/// Clave de diseño a la que se asignaran las Variables Criticas
		/// </summary>
		[Key, Column("ClaveDiseno")]
		public string ClaveDiseño { get; set; }

		/// <summary>
		/// Ruta en la que se encuentra la imagen de la figura de salida
		/// </summary>
		public string RutaImagenFigura { get; set; }

		/// <summary>
		/// Tamaño de fotocelda
		/// </summary>
		public VCStr Fotocelda { get; set; } = new VCStr("mm");

		/// <summary>
		/// Numero de Codigo de Barras
		/// </summary>
		public string CodigoBarras { get; set; }

		/// <summary>
		/// Ancho del material en el proceso de impresion, contien los valores de tolerancia
		/// </summary>
		public VCNum Ancho { get; set; } = new VCNum("cm");

		/// <summary>
		/// Alto o repeticion del diseño en el proceso de impresión, contien los valores de tolerancia
		/// </summary>
		public VCNum Alto { get; set; } = new VCNum("cm");

		/// <summary>
		/// Numero de sobre viajero que contiene la informacion del producto asociado al diseño
		/// </summary>
		public string NumeroSobre { get; set; }

		public virtual ObservableListSource<BaseProcesos> Procesos { get; set; } = new ObservableListSource<BaseProcesos>();

		public virtual ObservableListSource<Tablas.TemporalOrdenTrabajo> OrdenesTrabajo { get; set; } = new ObservableListSource<TemporalOrdenTrabajo>();

		/// <summary>
		/// Datos de los elementos que participan en la produccion del diseño
		/// </summary>
		public virtual ObservableListSource<EstructuraItems> EstructuraItems { get; set; } = new ObservableListSource<VariablesCriticas.EstructuraItems>();

		[NotMapped]
		public string Estructura
		{
			get
			{
				return "datos de la estructura\nTODO: modificar cosntructor del string"; // TODO: Falta desarrollo
			}
		}
	}

	#region Estructura

	/// <summary>
	/// Item que contiene los datos para un elemto de la estructura
	/// </summary>
	[Table("VC_Estructura_Items")]
	public class EstructuraItems
	{
		/// <summary>
		/// Unidades para asignar el calibre a un sustrato
		/// </summary>
		public enum Unidades_Calibre { NA, Um, CI }

		/// <summary>
		/// Diseño al que pertenece el Item
		/// </summary>
		[Key, Column("ClaveDiseno", Order = 0)]
		public string ClaveDiseño { get; set; }

		/// <summary>
		/// Posicion del elemento en la estructura
		/// </summary>
		[Key, Column(Order = 1)]
		public int Posicion { get; set; }

		/// <summary>
		/// Descripcion del elemento {Sustrato, tinta, adhesivo, tratado, etc.}
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
		public VCStr Tratado { get; set; } = new VCStr("Dinas", "38", "38", ">38");

		[ForeignKey("ClaveDiseño")]
		public virtual VariablesCriticasRoot Root { get; set; }
	}
	#endregion

	#region Procesos

	/// <summary>
	/// Contiene los datos de las variables criticas del proceso de impresión para una impresora especifica
	/// </summary>
	public class DatosImpresion : BaseProcesos
	{
		/// <summary>
		/// Se utiliza para seleccionar el tipo de parametros que se rellenearan en el formato
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
		/// Parametro 
		/// </summary>
		public VCNum ParametroPresionRodilloPisorCalandra { get; set; } = new VCNum("Bar");

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCNum ParametroPresionRodilloTamborCentral { get; set; } = new VCNum("Bar");

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCNum ParametroPresionRodilloPisorEmbobinador { get; set; } = new VCNum("Bar");

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCNum ParametroTensionEmbobinador { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCNum ParametroTensionBanda { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCNum ParametroTensionArrastreODesbobinador { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro Gearless 
		/// </summary>
		public VCNum ParametroGearlessTensionRodilloRefrigerante { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro Grarless
		/// </summary>
		public VCNum ParametroGearlessFuerzaApriete { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro Grarless
		/// </summary>
		public double? ParametroGearlessDiametroInicial { get; set; }

		/// <summary>
		/// Parametro Grarless
		/// </summary>
		public double? ParametroGearlessDiametroFinal { get; set; }

		/// <summary>
		/// Parametro Engranes
		/// </summary>
		public VCNum ParametroEngranesPresionBalancinEmbobinador { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro Engranes
		/// </summary>
		public VCNum ParametroEngranesPresionBalancinDesbobinador { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro Engranes
		/// </summary>
		public VCNum ParametroEngranesOffset { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCStr ParametroTemperaturaPuente { get; set; } = new VCStr("°C");

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCStr ParametroTemperaturaEntrecolores { get; set; } = new VCStr("°C");

		[InverseProperty("DatosImpresion")]
		public virtual ObservableListSource<DeckImpresion> Decks { get; set; } = new ObservableListSource<DeckImpresion>();

		///// <summary>
		///// Datos de la tinta y anilox utilizado en la unidad 1
		///// </summary>
		//public DeckImpresion Unidad1 { get; set; } = new DeckImpresion();

		///// <summary>
		///// Datos de la tinta y anilox utilizado en la unidad 2
		///// </summary>
		//public DeckImpresion Unidad2 { get; set; } = new DeckImpresion();

		///// <summary>
		///// Datos de la tinta y anilox utilizado en la unidad 3
		///// </summary>
		//public DeckImpresion Unidad3 { get; set; } = new DeckImpresion();

		///// <summary>
		///// Datos de la tinta y anilox utilizado en la unidad 4
		///// </summary>
		//public DeckImpresion Unidad4 { get; set; } = new DeckImpresion();

		///// <summary>
		///// Datos de la tinta y anilox utilizado en la unidad 5
		///// </summary>
		//public DeckImpresion Unidad5 { get; set; } = new DeckImpresion();

		///// <summary>
		///// Datos de la tinta y anilox utilizado en la unidad 6
		///// </summary>
		//public DeckImpresion Unidad6 { get; set; } = new DeckImpresion();

		///// <summary>
		///// Datos de la tinta y anilox utilizado en la unidad 7
		///// </summary>
		//public DeckImpresion Unidad7 { get; set; } = new DeckImpresion();

		///// <summary>
		///// Datos de la tinta y anilox utilizado en la unidad 8
		///// </summary>
		//public DeckImpresion Unidad8 { get; set; } = new DeckImpresion();

		///// <summary>
		///// Datos de la tinta y anilox utilizado en la unidad 9
		///// </summary>
		//public DeckImpresion Unidad9 { get; set; } = new DeckImpresion();

		///// <summary>
		///// Datos de la tinta y anilox utilizado en la unidad 10
		///// </summary>
		//public DeckImpresion Unidad10 { get; set; } = new DeckImpresion();

	}

	/// <summary>
	/// Clase contenedora de los datos de una unidad de impresion, contiene informacion del color a utilizar, el anilox y los valores LAB
	/// </summary>
	[Table("VC_DecksImpresion")]
	public class DeckImpresion
	{
		public int Id { get; set; }

		[Index("UniqueDeck", IsUnique = true, Order = 0)]
		public int IdProceso { get; set; }

		[Index("UniqueDeck", IsUnique = true, Order = 1)]
		public int Unidad { get; set; }

		public string Color { get; set; }
		public string Descripcion { get; set; }
		public string Anilox { get; set; }
		public string Stickyback { get; set; }
		public double? L { get; set; }
		public double? A { get; set; }
		public double? B { get; set; }
		public double? Densidad { get; set; }

		[ForeignKey("IdProceso")]
		public virtual DatosImpresion DatosImpresion { get; set; }
	}

	/// <summary>
	/// Contiene los datos de las variables criticas del proceso de laminacion
	/// <para>Pueden ser parametros para Laminación, Trilamianción o Tetralaminación</para>
	/// </summary>
	public class DatosLaminacion : BaseProcesos
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
		public string AdhesivoResinaClave { get; set; }

		/// <summary>
		/// Clave del catalizador o del segundo elemento en solventbase
		/// </summary>
		public string AdhesivoCatalizadorClave { get; set; }

		/// <summary>
		/// Parametro Relacion de Catalizador
		/// </summary>
		public VCNum ParametroAdhesivoCatalizadorRelacion { get; set; } = new VCNum("%");

		/// <summary>
		/// Parametro: Aplicacion de adhesivo por metro cuadrado
		/// </summary>
		public VCNum ParametroAdhesivoAplicacion { get; set; } = new VCNum("");

		/// <summary>
		/// Parametro: Temperatura de la resina
		/// </summary>
		public VCNum ParametroTemperaturaResina { get; set; } = new VCNum("°C");

		/// <summary>
		/// Parametro: Temperatura del Catalizador
		/// </summary>
		public VCNum ParametroTemperaturaCatalizador { get; set; } = new VCNum("°C");

		/// <summary>
		/// Parametro: Temperatura del Rodillo Aplicador
		/// </summary>
		public VCNum ParametroTemperaturaRodilloAplicador { get; set; } = new VCNum("°C");

		/// <summary>
		/// Parametro: Temperatura del Rodillo Laminador
		/// </summary>
		public VCNum ParametroTemperaturaRodilloLaminador { get; set; } = new VCNum("°C");

		/// <summary>
		/// Parametro: Presion Rodillo Mangas 
		/// </summary>
		public VCNum ParametroPresionRodilloMangas { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro: Presion Rodillo Laminador Izquierdo 
		/// </summary>
		public VCNum ParametroPresionRodilloLaminadorIzquierdo { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro: Presion Rodillo Laminador Derecho 
		/// </summary>
		public VCNum ParametroPresionRodilloLaminadorDerecho { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro: Pesion Rodillo Presor Izquierdo 
		/// </summary>
		public VCNum ParametroPresionRodilloPresorIzquierdo { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro: Presion Rodillo Presor Derecho 
		/// </summary>
		public VCNum ParametroPresionRodilloPresorDerecho { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro: Presion Rodillo Aplicador  
		/// </summary>
		public VCNum ParametroPresionRodilloAplicador { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro: Galga Izquierdo 
		/// </summary>
		public VCNum ParametroGalgaIzquierda { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro:Galga Derecha 
		/// </summary>
		public VCNum ParametroGalgaDerecha { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro: Tension Desbobinador uno 
		/// </summary>
		public VCNum ParametroTensionDesbobinadorUno { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro: Tension Desbobinador dos 
		/// </summary>
		public VCNum ParametroTensionDesbobinadorDos { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro:Tension embobinador 
		/// </summary>
		public VCNum ParametroTensionBobinador { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro:Tension Puente 
		/// </summary>
		public VCNum ParametroTensionPuente { get; set; } = new VCNum("N");

		/// <summary>
		/// Parametro: Curling en grados
		/// </summary>
		public VCNum Curling { get; set; } = new VCNum("°");

		/// <summary>
		/// Parametro: Fuerza de laminado 40 minutos 
		/// </summary>
		public VCNum FuerzaLaminacionUno { get; set; } = new VCNum("");

		/// <summary>
		/// Parametro: Fuerza de laminado 4 horas 
		/// </summary>
		public VCNum FuerzaLaminacionDos { get; set; } = new VCNum("");

		/// <summary>
		/// Elemento del desbobinador Unod
		/// </summary>
		public string DesbobinadorUnoElemento { get; set; }

		/// <summary>
		/// Tratado del elemento del desbobinador uno
		/// </summary>
		public VCStr DesbobinadorUnoTratado { get; set; } = new VCStr("Dinas", "38", "38", ">38");

		/// <summary>
		/// Elemento del desbobinador dos
		/// </summary>
		public string DesbobinadorDosElemento { get; set; }

		/// <summary>
		/// Tratado del elemento del desbobinador dos
		/// </summary>
		public VCStr DesbobinadorDosTratado { get; set; } = new VCStr("Dinas", "38", "38", ">38");
	}

	public class DatosRefinado : BaseProcesos
	{
		public enum Cores { Tres = 3, Seis = 6 }
		public Cores Core { get; set; } = Cores.Tres;
		public string Marca { get; set; }
		public string VariableSecundaria { get; set; }
		public string VariablePrincipal { get; set; }
		public VCStr VariablePrincipalTolerancias { get; set; }
		public VCNum ParametroTensionDesbobinador { get; set; }
		public VCNum ParametroTensionBobinadorSuperior { get; set; }
		public VCNum ParametroTensionBobinadorInferior { get; set; }
		public VCNum ParametroPresionRodilloPisorSuperior { get; set; }
		public VCNum ParametroPresionRodilloPisorInferior { get; set; }

	}

	#endregion

	#region ComplexType

	/// <summary>
	/// Parametros con valores numericos con tolerancias y unidad
	/// </summary>
	[ComplexType]
	public class VCNum
	{
		public double? Estandar { get; set; }
		public double? Minimo { get; set; }
		public double? Maximo { get; set; }
		public string Unidad { get; set; }
		public VCNum() { }
		public VCNum(string Unidad)
		{
			this.Unidad = Unidad;
		}
		public VCNum(string Unidad, double Estandar, double Minimo, double Maximo)
		{
			this.Unidad = Unidad;
			this.Estandar = Estandar;
			this.Minimo = Minimo;
			this.Maximo = Maximo;
		}
	}

	/// <summary>
	/// Parametros de valor de tipo cadena con tolerancias y unidad
	/// </summary>
	[ComplexType]
	public class VCStr
	{
		public string Estandar { get; set; }
		public string Minimo { get; set; }
		public string Maximo { get; set; }
		public string Unidad { get; set; }
		public VCStr() { }
		public VCStr(string Unidad)
		{
			this.Unidad = Unidad;
		}
		public VCStr(string Unidad, string Estandar, string Minimo, string Maximo)
		{
			this.Unidad = Unidad;
			this.Estandar = Estandar;
			this.Minimo = Minimo;
			this.Maximo = Maximo;
		}
	}




	#endregion
}
