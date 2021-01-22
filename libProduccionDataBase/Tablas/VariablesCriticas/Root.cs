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
		/// Ancho del material en el proceso de imPres, contien los valores de tolerancia
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
		public VCNum ParPresRodPisorCalandra { get; set; } = new VCNum("Bar");

		/// <summary>
		/// Par 
		/// </summary>
		public VCNum ParPresRodTamborCentral { get; set; } = new VCNum("Bar");

		/// <summary>
		/// Par 
		/// </summary>
		public VCNum ParPresRodPisorEmbobinador { get; set; } = new VCNum("Bar");

		/// <summary>
		/// Par 
		/// </summary>
		public VCNum ParTenEmbobinador { get; set; } = new VCNum("N");

		/// <summary>
		/// Par 
		/// </summary>
		public VCNum ParTenBanda { get; set; } = new VCNum("N");

		/// <summary>
		/// Par 
		/// </summary>
		public VCNum ParTenArrastreODesbobinador { get; set; } = new VCNum("N");

		/// <summary>
		/// Par Gearless 
		/// </summary>
		public VCNum ParGTenRodRefrigerante { get; set; } = new VCNum("N");

		/// <summary>
		/// Par Grarless
		/// </summary>
		public VCNum ParGFuerzaApriete { get; set; } = new VCNum("N");

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
		public VCNum ParEPresBalancinEmbobinador { get; set; } = new VCNum("N");

		/// <summary>
		/// Par Engranes
		/// </summary>
		public VCNum ParEPresBalancinDesbobinador { get; set; } = new VCNum("N");

		/// <summary>
		/// Par Engranes
		/// </summary>
		public VCNum ParEOffset { get; set; } = new VCNum("N");

		/// <summary>
		/// Par 
		/// </summary>
		public VCStr ParTempPuente { get; set; } = new VCStr("°C");

		/// <summary>
		/// Par 
		/// </summary>
		public VCStr ParTempEntrecolores { get; set; } = new VCStr("°C");

		[InverseProperty("DatosImPres")]
		public virtual ObservableListSource<DeckImPres> Decks { get; set; } = new ObservableListSource<DeckImPres>();
	}

	/// <summary>
	/// Clase contenedora de los datos de una unidad de imPres, contiene informacion del color a utilizar, el anilox y los valores LAB
	/// </summary>
	[Table("VC_DecksImPres")]
	public class DeckImPres
	{
		public int Id { get; set; }

		[Index("UniqueDeck", IsUnique = true, Order = 0)]
		public int IdProceso { get; set; }

		[Index("UniqueDeck", IsUnique = true, Order = 1)]
		public int Unidad { get; set; }

		public string Color { get; set; }
		public string Descripcion { get; set; }
		public string AniloxLPI { get; set; }
		public string BCM { get; set; }
		public string Stickyback { get; set; }
		public double? L { get; set; }
		public double? A { get; set; }
		public double? B { get; set; }
		public double? Densidad { get; set; }
		public double? Secado { get; set; }
		public double? Viscosidad { get; set; }
		
		[ForeignKey("IdProceso")]
		public virtual DatosImpresion DatosImPres { get; set; }
	}

	/// <summary>
	/// Contiene los datos de las variables criticas del proceso de laminacion
	/// <para>Pueden ser Pars para Laminación, Trilamianción o Tetralaminación</para>
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
		public string AdhResinaClave { get; set; }

		/// <summary>
		/// Clave del catalizador o del segundo elemento en solventbase
		/// </summary>
		public string AdhCatalizadorClave { get; set; }

		/// <summary>
		/// Par Relacion de Catalizador
		/// </summary>
		public VCNum ParAdhCatalizadorRelacion { get; set; } = new VCNum("%");

		/// <summary>
		/// Par: Aplicacion de Adh por metro cuadrado
		/// </summary>
		public VCNum ParAdhAplicacion { get; set; } = new VCNum("");

		/// <summary>
		/// Par: Temp de la resina
		/// </summary>
		public VCNum ParTempResina { get; set; } = new VCNum("°C");

		/// <summary>
		/// Par: Temp del Catalizador
		/// </summary>
		public VCNum ParTempCatalizador { get; set; } = new VCNum("°C");

		/// <summary>
		/// Par: Temp del Rod Aplicador
		/// </summary>
		public VCNum ParTempRodAplicador { get; set; } = new VCNum("°C");

		/// <summary>
		/// Par: Temp del Rod Laminador
		/// </summary>
		public VCNum ParTempRodLaminador { get; set; } = new VCNum("°C");

		/// <summary>
		/// Par: Pres Rod Mangas 
		/// </summary>
		public VCNum ParPresRodMangas { get; set; } = new VCNum("N");

		/// <summary>
		/// Par: Pres Rod Laminador Izquierdo 
		/// </summary>
		public VCNum ParPresRodLaminadorIzquierdo { get; set; } = new VCNum("N");

		/// <summary>
		/// Par: Pres Rod Laminador Derecho 
		/// </summary>
		public VCNum ParPresRodLaminadorDerecho { get; set; } = new VCNum("N");

		/// <summary>
		/// Par: Pesion Rod Presor Izquierdo 
		/// </summary>
		public VCNum ParPresRodPresorIzquierdo { get; set; } = new VCNum("N");

		/// <summary>
		/// Par: Pres Rod Presor Derecho 
		/// </summary>
		public VCNum ParPresRodPresorDerecho { get; set; } = new VCNum("N");

		/// <summary>
		/// Par: Pres Rod Aplicador  
		/// </summary>
		public VCNum ParPresRodAplicador { get; set; } = new VCNum("N");

		/// <summary>
		/// Par: Galga Izquierdo 
		/// </summary>
		public VCNum ParGalgaIzquierda { get; set; } = new VCNum("N");

		/// <summary>
		/// Par:Galga Derecha 
		/// </summary>
		public VCNum ParGalgaDerecha { get; set; } = new VCNum("N");

		/// <summary>
		/// Par: Ten Desbobinador uno 
		/// </summary>
		public VCNum ParTenDesbobinadorUno { get; set; } = new VCNum("N");

		/// <summary>
		/// Par: Ten Desbobinador dos 
		/// </summary>
		public VCNum ParTenDesbobinadorDos { get; set; } = new VCNum("N");

		/// <summary>
		/// Par:Ten embobinador 
		/// </summary>
		public VCNum ParTenBobinador { get; set; } = new VCNum("N");

		/// <summary>
		/// Par:Ten Puente 
		/// </summary>
		public VCNum ParTenPuente { get; set; } = new VCNum("N");

		/// <summary>
		/// Par: Curling en grados
		/// </summary>
		public VCNum Curling { get; set; } = new VCNum("°");

		/// <summary>
		/// Par: Fuerza de laminado 40 minutos 
		/// </summary>
		public VCNum FuerzaLaminacionUno { get; set; } = new VCNum("");

		/// <summary>
		/// Par: Fuerza de laminado 4 horas 
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
		public VCNum ParTenDesbobinador { get; set; }
		public VCNum ParTenBobinadorSuperior { get; set; }
		public VCNum ParTenBobinadorInferior { get; set; }
		public VCNum ParPresRodPisorSuperior { get; set; }
		public VCNum ParPresRodPisorInferior { get; set; }

	}

	#endregion

	#region ComplexType

	/// <summary>
	/// Pars con valores numericos con tolerancias y unidad
	/// </summary>
	[ComplexType]
	public class VCNum
	{
		public double? Std { get; set; }
		public double? Min { get; set; }
		public double? Max { get; set; }
		public string Unidad { get; set; }
		public VCNum() { }
		public VCNum(string Unidad)
		{
			this.Unidad = Unidad;
		}
		public VCNum(string Unidad, double Estandar, double Minimo, double Maximo)
		{
			this.Unidad = Unidad;
			this.Std = Estandar;
			this.Min = Minimo;
			this.Max = Maximo;
		}
	}

	/// <summary>
	/// Pars de valor de tipo cadena con tolerancias y unidad
	/// </summary>
	[ComplexType]
	public class VCStr
	{
		public string Std { get; set; }
		public string Min { get; set; }
		public string Max { get; set; }
		public string Unidad { get; set; }
		public VCStr() { }
		public VCStr(string Unidad)
		{
			this.Unidad = Unidad;
		}
		public VCStr(string Unidad, string Estandar, string Minimo, string Maximo)
		{
			this.Unidad = Unidad;
			this.Std = Estandar;
			this.Min = Minimo;
			this.Max = Maximo;
		}
	}

	#endregion
}
