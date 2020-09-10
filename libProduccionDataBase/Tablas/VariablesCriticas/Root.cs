using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas.VariablesCriticas
{
	[Table ( "VC_Root" )]
	public class VariablesCriticasRoot
	{
		/// <summary>
		/// Clave de diseño a la que se asignaran las Variables Criticas
		/// </summary>
		[Key, ForeignKey ( "Estructura" ), Column ( "ClaveDiseno" )]
		public string ClaveDiseño { get; set; }

		/// <summary>
		/// Ruta en la que se encuentra la imagen de la figura de salida
		/// </summary>
		public string RutaImagenFigura { get; set; }

		/// <summary>
		/// Fecha en la que se captura el elemento
		/// </summary>
		public DateTime FechaCaptura { get; set; }

		/// <summary>
		/// Datos de los elementos que participan en la produccion del diseño
		/// </summary>
		public virtual Estructura Estructura { get; set; }

		/// <summary>
		/// Tamaño de fotocelda
		/// </summary>
		public VCStr Fotocelda { get; set; } = new VCStr ( "cmXcm" );

		/// <summary>
		/// Numero de Codigo de Barras
		/// </summary>
		public string CodigoBarras { get; set; }

		/// <summary>
		/// Coleccion de datos de impresion, un diseño puede imprimirse en diferentes impresoras.
		/// </summary>
		public virtual ObservableListSource<DatosImpresion> DatosImpresion { get; set; }

	}


	#region Estructura

	/// <summary>
	/// Contenedor de los elementos de una estructura para un diseño.
	/// </summary>
	[Table ( "VC_Estructura" )]
	public class Estructura
	{
		/// <summary>
		/// Diseño al que pertenece la estructura
		/// </summary>
		[Key, Column ( "ClaveDiseno" )]
		public string ClaveDiseño { get; set; }

		/// <summary>
		/// Fecha en que se captura por primera vez el elemento
		/// </summary>
		public DateTime FechaCaptura { get; set; }

		/// <summary>
		/// Fecha de la ultima actualizacion del elemento
		/// </summary>
		public DateTime FechaUltimaActualizacion { get; set; }

		/// <summary>
		/// Lista de elementos que pertenecen a la estructura
		/// </summary>
		public virtual ObservableListSource<EstructuraItems> Items { get; set; }

		/// <summary>
		/// Conversion a texto para la presentacion en el formato de Variables Criticas o en el DGrid
		/// </summary>
		/// <returns></returns>
		public override string ToString ()
		{
			// Reviso que la estructura tenga elementos
			if ( Items != null && Items.Count > 0 )
			{
				return "Datos"; // TODO: realizar adecuaciones para presentacion de las cadena en el reporte
			}
			else
			{
				return "Sin Datos";
			}
		}
	}

	/// <summary>
	/// Item que contiene los datos para un elemto de la estructura
	/// </summary>
	[Table ( "VC_Estructura_Items" )]
	public class EstructuraItems
	{
		/// <summary>
		/// Unidades para asignar el calibre a un sustrato
		/// </summary>
		public enum Unidades_Calibre { NA, Um, CI }

		/// <summary>
		/// Diseño al que pertenece el Item
		/// </summary>
		[Key, Column ( "ClaveDiseno", Order = 0 )]
		public string ClaveDiseño { get; set; }

		/// <summary>
		/// Posicion del elemento en la estructura
		/// </summary>
		[Key, Column ( Order = 1 )]
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
		public Unidades_Calibre UnidadCalibre { get; set; } = Unidades_Calibre.Um;

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
		public VCStr Tratado { get; set; } = new VCStr ( "Dinas", "38", "38", ">38" );

		// public virtual Estructura Estructura { get; set; }
	}
	#endregion

	#region Procesos
	#region Impresion
	[Table ( "VC_Impresion" )]
	public class DatosImpresion
	{
		/// <summary>
		/// Se utiliza para seleccionar el tipo de parametros que se rellenearan en el formato
		/// </summary>
		public enum TiposImpresora { gearless, engranes }

		/// <summary>
		/// Clave de diseño al quue esta asociada la informacion
		/// </summary>
		[Key, Column ( "ClaveDiseno", Order = 0 )]
		public string ClaveDiseño { get; set; }

		/// <summary>
		/// Id de la maquina Impresora
		/// </summary>
		[Key, Column ( Order = 1 ), ForeignKey ( "Maquina" )]
		public int MaquinaId { get; set; }

		/// <summary>
		///  Tipo de impresora al que pertenece la informacion (gearless o engranes)
		/// </summary>
		public TiposImpresora TipoImpresora { get; set; }

		/// <summary>
		/// Figura de salida del proceso de impresión
		/// </summary>
		public int FiguraSalida { get; set; }

		/// <summary>
		/// Tipo de tinta que se utilizará para procesar el producto
		/// </summary>
		public string TipoTinta { get; set; }

		/// <summary>
		/// Numero de sobre viajero que contiene la informacion del producto asociado al diseño
		/// </summary>
		public string NumeroSobre { get; set; }

		/// <summary>
		/// Ancho del material en el proceso de impresion, contien los valores de tolerancia
		/// </summary>
		public VCNum Ancho { get; set; } = new VCNum ( "cm" );

		/// <summary>
		/// Alto o repeticion del diseño en el proceso de impresión, contien los valores de tolerancia
		/// </summary>
		public VCNum Alto { get; set; } = new VCNum ( "cm" );

		/// <summary>
		/// Dureza que deberan tener las bobinas resultantes, el valor predeterminado es min:26 std:36 max:46
		/// </summary>
		public VCNum Dureza { get; set; } = new VCNum ( "cm", 36, 26, 46 );

		/// <summary>
		/// Velocidad registrada para la produccion del producto
		/// </summary>
		public VCNum Velocidad { get; set; } = new VCNum ( "m/min" );

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCNum PresionRodilloPisorCalandra { get; set; } = new VCNum ( "Bar" );

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCNum PresionRodilloTamborCentral { get; set; } = new VCNum ( "Bar" );

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCNum PresionRodilloPisorEmbobinador { get; set; } = new VCNum ( "Bar" );

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCNum PotenciaTratador { get; set; } = new VCNum ( "m/%" );

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCNum TensionEmbobinador { get; set; } = new VCNum ( "N" );

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCNum TensionBanda { get; set; } = new VCNum ( "N" );

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCNum TensionArrastreODesbobinador { get; set; } = new VCNum ( "N" );

		/// <summary>
		/// Parametro Gearless 
		/// </summary>
		public VCNum G_TensionRodilloRefrigerante { get; set; } = new VCNum ( "N" );

		/// <summary>
		/// Parametro Grarless
		/// </summary>
		public VCNum G_FuerzaApriete { get; set; } = new VCNum ( "N" );

		/// <summary>
		/// Parametro Grarless
		/// </summary>
		public VCNum G_IndiceReduccion { get; set; } = new VCNum ( "%" );

		/// <summary>
		/// Parametro Grarless
		/// </summary>
		public double? G_DiametroInicial { get; set; }

		/// <summary>
		/// Parametro Grarless
		/// </summary>
		public double? G_DiametroFinal { get; set; }

		/// <summary>
		/// Parametro Engranes
		/// </summary>
		public VCNum E_PresionBalancinEmbobinador { get; set; } = new VCNum ( "N" );

		/// <summary>
		/// Parametro Engranes
		/// </summary>
		public VCNum E_PresionBalancinDesbobinador { get; set; } = new VCNum ( "N" );

		/// <summary>
		/// Parametro Engranes
		/// </summary>
		public VCNum E_Offset { get; set; } = new VCNum ( "N" );

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCStr TemperaturaPuente { get; set; } = new VCStr ( "°C" );

		/// <summary>
		/// Parametro 
		/// </summary>
		public VCStr TemperaturaEntrecolores { get; set; } = new VCStr ( "°C" );

		/// <summary>
		/// Comentarios sobre la informacion del proceso de impresión
		/// </summary>
		public string Comentarios { get; set; }


		/// <summary>
		/// Datos de la tinta y anilox utilizado en la unidad 1
		/// </summary>
		public DeckImpresion Unidad1 { get; set; }

		/// <summary>
		/// Datos de la tinta y anilox utilizado en la unidad 2
		/// </summary>
		public DeckImpresion Unidad2 { get; set; }

		/// <summary>
		/// Datos de la tinta y anilox utilizado en la unidad 3
		/// </summary>
		public DeckImpresion Unidad3 { get; set; }

		/// <summary>
		/// Datos de la tinta y anilox utilizado en la unidad 4
		/// </summary>
		public DeckImpresion Unidad4 { get; set; }

		/// <summary>
		/// Datos de la tinta y anilox utilizado en la unidad 5
		/// </summary>
		public DeckImpresion Unidad5 { get; set; }

		/// <summary>
		/// Datos de la tinta y anilox utilizado en la unidad 6
		/// </summary>
		public DeckImpresion Unidad6 { get; set; }

		/// <summary>
		/// Datos de la tinta y anilox utilizado en la unidad 7
		/// </summary>
		public DeckImpresion Unidad7 { get; set; }

		/// <summary>
		/// Datos de la tinta y anilox utilizado en la unidad 8
		/// </summary>
		public DeckImpresion Unidad8 { get; set; }

		/// <summary>
		/// Datos de la tinta y anilox utilizado en la unidad 9
		/// </summary>
		public DeckImpresion Unidad9 { get; set; }

		/// <summary>
		/// Datos de la tinta y anilox utilizado en la unidad 10
		/// </summary>
		public DeckImpresion Unidad10 { get; set; }


		/// <summary>
		/// Fecha en que se realizó la captura de la información
		/// </summary>
		public DateTime FechaCaptura { get; set; }

		/// <summary>
		/// Fecha de la ultima actualización de la información
		/// </summary>
		public DateTime FechaActualizacion { get; set; }


		/// <summary>
		/// Datos de la maquina asociada a la informacion
		/// </summary>
		public virtual Maquina Maquina { get; set; }

		/// <summary>
		/// Constructor de la clase
		/// </summary>
		public DatosImpresion ()
		{
			FechaCaptura = DateTime.Now;
		}
	}
	#endregion

	#region Laminacion
	[Table ( "VC_Laminacion" )]
	public class DatosLaminacion
	{

	}
	#endregion

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

		public VCNum () { }
		public VCNum ( string Unidad )
		{
			this.Unidad = Unidad;
		}
		public VCNum ( string Unidad, double Estandar, double Minimo, double Maximo )
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

		public VCStr () { }
		public VCStr ( string Unidad )
		{
			this.Unidad = Unidad;
		}
		public VCStr ( string Unidad, string Estandar, string Minimo, string Maximo )
		{
			this.Unidad = Unidad;
			this.Estandar = Estandar;
			this.Minimo = Minimo;
			this.Maximo = Maximo;
		}

	}


	/// <summary>
	/// Clase contenedora de los datos de una unidad de impresion, contiene informacion del color a utilizar, el anilox y los valores LAB
	/// </summary>
	[ComplexType]
	public class DeckImpresion
	{
		public string Color { get; set; }
		public string Descripcion { get; set; }
		public string Anilox { get; set; }
		public string Stickyback { get; set; }
		public double? L { get; set; }
		public double? A { get; set; }
		public double? B { get; set; }
		public double? Densidad { get; set; }

	}
	#endregion
}
