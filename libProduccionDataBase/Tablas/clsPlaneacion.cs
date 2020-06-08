using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas
{
	/// <summary>
	/// <para>Entidad de una planeacion, contiene información sobre los procesos requeridos para la fabricacion de un pedido.</para>
	/// <para>Esta entidad contiene entidades hijo con la información necesaria para cada uno de los proccesos requeridos en la fabricacion del pedido.</para>
	/// </summary>
	[Table ( "Planeacion" )]
	public class Planeacion
	{
		private string _OT = "";

		/// <summary>
		/// Flags de los procesos involucrados en la fabricacion de un producto
		/// </summary>
		[Flags]
		public enum TiposProcesoProduccion
		{
			Impresion = 1 << 0,
			Laminacion = 1 << 1,
			Refinado = 1 << 2,
			Doblado = 1 << 3,
			Corte = 1 << 4,
			Embobinado = 1 << 5,
			Mangas = 1 << 6,
			Sellado = 1 << 7,
			Extrusion = 1 << 8,
			Trilaminacion = 1 << 9,
			Tetralaminacion = 1 << 10,
			Desmetalizar = 1 << 11,
			Microperforado = 1 << 12,
			Troquelar = 1 << 13
		}

		/// <summary>
		/// Flags del estatus del plan de produccion de una orden de trabajo 
		/// </summary>
		[Flags]
		public enum statusPlaneacion
		{
			PedidoNuevo = 1 << 0,
			PedidoEnPrograma = 1 << 1,
			PedidoTerminado = 1 << 2,
			PedidoReposicion = 1 << 3,
			PedidoReprogramado = 1 << 4
		}

		/// <summary>
		/// Flags del estatus de un diseño
		/// </summary>
		public enum estatusDiseño
		{
			NoAsignado = 0,
			EnRevision = 1,
			Autorizado = 2,
			Repetido = 4
		}

		/// <summary>
		/// Constructor de la clase, se asignan valores predeterminados para una nueva instancia
		/// </summary>
		public Planeacion ()
		{
			this.Status = statusPlaneacion.PedidoNuevo;
			this.FechaCaptura = DateTime.Now;
			this.EstatusDiseño = estatusDiseño.NoAsignado;
			this.UltimaActualizacion = DateTime.Now;
			this.Comentarios = "";
		}

		/// <summary>
		/// Clave de la orden de trabajo con la que se relaciona el plan de producción.
		/// </summary>
		[Key, ForeignKey ( "OrdenTrabajo" )]
		public string OT { get { return _OT; } set { _OT = value.Trim ( ); } }

		/// <summary>
		/// Entidad de la orden de trabajo, facilita acceso a las propiedades de las ordenes
		/// </summary>
		public virtual TemporalOrdenTrabajo OrdenTrabajo { get; set; }

		/// <summary>
		/// Indica el estatus del plan de produccion.
		/// </summary>
		public statusPlaneacion Status { get; set; }

		/// <summary>
		/// Indica la fecha en que se realizó la ultima modificacion a la Orden de Trabajo.
		/// </summary>
		public DateTime UltimaActualizacion { get; set; }

		/// <summary>
		/// Indica la fecha en que se capturó la Orden de Trabajo por vez primera.
		/// </summary>
		public DateTime FechaCaptura { get; set; }

		/// <summary>
		/// Indica la Fecha en la que estará disponible el Polietileno
		/// </summary>
		public DateTime FechaPE { get; set; }

		/// <summary>
		/// Indica la fecha en que estaran disponibles los Materiales diferentes a Polietileno
		/// </summary>
		public DateTime FechaMateriales { get; set; }

		/// <summary>
		/// Indica la Fecha en la que se debe entregar el pedido al almacen
		/// </summary>
		public DateTime FechaProgEntregaAlmacen { get; set; }

		/// <summary>
		/// Indica la Fecha en la que se debe entregar el pedido al almacen
		/// </summary>
		public DateTime FechaRealEntregaAlmacen { get; set; }

		/// <summary>
		/// Indica la fecha en la que el pedido se embarcara al cliente
		/// </summary>
		public DateTime FechaEmbarque { get; set; }

		/// <summary>
		/// Indica la fecha en la que el pedido se entregará al cliente
		/// </summary>
		public DateTime FechaEntregaCliente { get; set; }

		/// <summary>
		/// Indica el estado del diseño con el que se imrpimira la orden de trabajo.
		/// </summary>
		[Column ( "estatusDiseno" )]
		public estatusDiseño EstatusDiseño { get; set; }

		/// <summary>
		/// Agrega informacion al plan de producción.
		/// </summary>
		public string Comentarios { get; set; }

		/// <summary>
		/// Listado de Procesos involucrados en la produccion de la orden de trabajo, el campo <b>Activa</b> indica si el tipo de proceso es requerido para la produccion del pedido.
		/// </summary>
		public virtual ObservableListSource<PlaneacionProduccion> Procesos { get; set; } = new ObservableListSource<PlaneacionProduccion> ( );

		/// <summary>
		/// Serie de instrucciones que crean los procesos necesarios en la base de datos para la fabricacion de un pedido.
		/// </summary>
		/// <param name="procesosToAdd">Banderas de los procesos requeridos</param>
		public void CrearProcesos ( TiposProcesoProduccion procesosToAdd )
		{
			foreach ( TiposProcesoProduccion p in Enum.GetValues ( typeof ( TiposProcesoProduccion ) ) )
			{
				Procesos.Add ( new PlaneacionProduccion ( p, procesosToAdd.HasFlag ( p ) ) );
			};
		}

		/// <summary>
		/// Instrucciones para actualizar la base de datos, se un proceso contiene instrucciones se agrega informacion a la BD, set <b>Activa = True</b> si las instrucciones del proceso contienen información.
		/// </summary>
		/// <param name="procesosToAdd"></param>
		public void UpdateProcesos ( TiposProcesoProduccion procesosToAdd )
		{
			foreach ( TiposProcesoProduccion p in Enum.GetValues ( typeof ( TiposProcesoProduccion ) ) )
			{
				if ( procesosToAdd.HasFlag ( p ) )
				{
					this.Procesos.FirstOrDefault ( u => u.TipoProceso == p ).Activa = true;
				}
				else
				{
					this.Procesos.FirstOrDefault ( u => u.TipoProceso == p ).Activa = false;
				}
			};

			this.UltimaActualizacion = DateTime.Now;
		}

		public static void AddToOT ( libProduccionDataBase.Tablas.TemporalOrdenTrabajo OT )
		{
			OT.Planeacion = OT.Planeacion ?? ( new Planeacion ( ) );

			if ( OT.Planeacion.Procesos.Count == 0 )
			{
				Tablas.Planeacion.TiposProcesoProduccion tp = new Tablas.Planeacion.TiposProcesoProduccion ( );
				if ( OT.INSTCORTE.Trim ( ) != "" ) tp |= Tablas.Planeacion.TiposProcesoProduccion.Corte;
				if ( OT.INSTDOBLADO.Trim ( ) != "" ) tp |= Tablas.Planeacion.TiposProcesoProduccion.Doblado;
				if ( OT.INSTEMBOBINADO.Trim ( ) != "" ) tp |= Tablas.Planeacion.TiposProcesoProduccion.Embobinado;
				if ( OT.INSTEXTRUSION.Trim ( ) != "" ) tp |= Tablas.Planeacion.TiposProcesoProduccion.Extrusion;
				if ( OT.INSTIMPRESION.Trim ( ) != "" ) tp |= Tablas.Planeacion.TiposProcesoProduccion.Impresion;
				if ( OT.INSTLAMINACION.Trim ( ) != "" ) tp |= Tablas.Planeacion.TiposProcesoProduccion.Laminacion;
				if ( OT.INSTMANGAS.Trim ( ) != "" ) tp |= Tablas.Planeacion.TiposProcesoProduccion.Mangas;
				if ( OT.INSTREFINADO.Trim ( ) != "" ) tp |= Tablas.Planeacion.TiposProcesoProduccion.Refinado;
				if ( OT.INSTSELLADO.Trim ( ) != "" ) tp |= Tablas.Planeacion.TiposProcesoProduccion.Sellado;
				if ( OT.INSTLAMINACION.ToUpper ( ).Contains ( "TRILAMINAR" ) ) tp |= Tablas.Planeacion.TiposProcesoProduccion.Trilaminacion;
				if ( OT.INSTLAMINACION.ToUpper ( ).Contains ( "TETRALAMINAR" ) ) tp |= Tablas.Planeacion.TiposProcesoProduccion.Tetralaminacion;
				if ( OT.INSTEMBOBINADO.ToUpper ( ).Contains ( "DESMETALIZAR" ) || OT.INSTCORTE.ToUpper ( ).Contains ( "DESMETALIZAR" ) || OT.INSTREFINADO.ToUpper ( ).Contains ( "DESMETALIZAR" ) ) tp |= Tablas.Planeacion.TiposProcesoProduccion.Desmetalizar;

				if ( OT.INSTEMBOBINADO.ToUpper ( ).Contains ( "MICROPERFORAR" ) ) tp |= Tablas.Planeacion.TiposProcesoProduccion.Microperforado;
				if ( OT.INSTEMBOBINADO.ToUpper ( ).Contains ( "TROQUELAR" ) ) tp |= Tablas.Planeacion.TiposProcesoProduccion.Troquelar;

				OT.Planeacion.CrearProcesos ( tp );
			}
			else
			{

				OT.Planeacion.UltimaActualizacion = DateTime.Now;
				Tablas.Planeacion.TiposProcesoProduccion toAdd = new Tablas.Planeacion.TiposProcesoProduccion ( );

				if ( OT.INSTCORTE.Trim ( ) != "" ) toAdd |= Tablas.Planeacion.TiposProcesoProduccion.Corte;
				if ( OT.INSTDOBLADO.Trim ( ) != "" ) toAdd |= Tablas.Planeacion.TiposProcesoProduccion.Doblado;
				if ( OT.INSTEMBOBINADO.Trim ( ) != "" ) toAdd |= Tablas.Planeacion.TiposProcesoProduccion.Embobinado;
				if ( OT.INSTEXTRUSION.Trim ( ) != "" ) toAdd |= Tablas.Planeacion.TiposProcesoProduccion.Extrusion;
				if ( OT.INSTIMPRESION.Trim ( ) != "" ) toAdd |= Tablas.Planeacion.TiposProcesoProduccion.Impresion;
				if ( OT.INSTLAMINACION.Trim ( ) != "" ) toAdd |= Tablas.Planeacion.TiposProcesoProduccion.Laminacion;
				if ( OT.INSTMANGAS.Trim ( ) != "" ) toAdd |= Tablas.Planeacion.TiposProcesoProduccion.Mangas;
				if ( OT.INSTREFINADO.Trim ( ) != "" ) toAdd |= Tablas.Planeacion.TiposProcesoProduccion.Refinado;
				if ( OT.INSTSELLADO.Trim ( ) != "" ) toAdd |= Tablas.Planeacion.TiposProcesoProduccion.Sellado;
				if ( OT.INSTLAMINACION.ToUpper ( ).Contains ( "TRILAMINAR" ) ) toAdd |= Tablas.Planeacion.TiposProcesoProduccion.Trilaminacion;
				if ( OT.INSTLAMINACION.ToUpper ( ).Contains ( "TETRALAMINAR" ) ) toAdd |= Tablas.Planeacion.TiposProcesoProduccion.Tetralaminacion;
				if ( OT.INSTEMBOBINADO.ToUpper ( ).Contains ( "DESMETALIZAR" ) || OT.INSTCORTE.ToUpper ( ).Contains ( "DESMETALIZAR" ) || OT.INSTREFINADO.ToUpper ( ).Contains ( "DESMETALIZAR" ) ) toAdd |= Tablas.Planeacion.TiposProcesoProduccion.Desmetalizar;
				OT.Planeacion.UpdateProcesos ( toAdd );
			}
		}
	}

	/// <summary>
	/// Contiene Informacion sobre el programa de los procesos requeridos en el plan de produccion de un pedido.
	/// </summary>
	[Table ( "PlaneacionProducciones" )]
	public class PlaneacionProduccion
	{
		private string _OT = "";

		/// <summary>
		/// Flags del estatus del proceso en la planeacion de la producción.
		/// </summary>
		[Flags]
		public enum statusProcesoProduccion
		{
			PorProgramar = 1 << 0,
			Programada = 1 << 1,
			Reprogramada = 1 << 2,
			EnProceso = 1 << 3,
			Concluida = 1 << 4,
			Activa = 1 << 5
		}

		/// <summary>
		/// Constructor principal
		/// </summary>
		public PlaneacionProduccion () { }

		/// <summary>
		/// Constructor que asigna un valor al tipo de proceso que se crea, indica si el proceso es requerido o no para la fabricación del pedido
		/// </summary>
		/// <param name="tipo">Tipo de proceso</param>
		/// <param name="Active">Indica si es requerido para la fabricacion del pedido</param>
		public PlaneacionProduccion ( Planeacion.TiposProcesoProduccion tipo, bool Active = false )
		{
			this.TipoProceso = tipo;
			this.Activa = Active;
		}

		/// <summary>
		/// Orden de trabajo con la que se relaciona el plan, servira en futuras versiones para ligar la produccion a cada proceso
		/// </summary>
		[Key, ForeignKey ( "Planeacion" ), Column ( Order = 0 )]
		public string OT { get { return _OT; } set { _OT = value.Trim ( ); } }

		/// <summary>
		/// Almacena el tipo de proceso de la instancia.
		/// </summary>
		[Key, Column ( Order = 1 )]
		public Planeacion.TiposProcesoProduccion TipoProceso { get; set; }

		/// <summary>
		/// Almacena el ID de la maquina en la que se realizará la producción del proceso
		/// </summary>
		[ForeignKey ( "Maquina" )]
		public int? MaquinaId { get; set; }

		/// <summary>
		/// Instancia de la maquina, contiene información sobre cpacidades, velocidad, anchos, rodillos disponibles en caso de que la maquina sea una impresora
		/// </summary>
		public virtual Maquina Maquina { get; set; }

		/// <summary>
		/// Determina si el proceso creado se utilizara para la produccion de esta orden de trabajo
		/// </summary>
		public bool Activa
		{
			get
			{
				return this.Estatus.HasFlag ( statusProcesoProduccion.Activa );
			}
			set
			{
				if ( !value ) { this.Estatus &= ~statusProcesoProduccion.Activa; } else { this.Estatus |= statusProcesoProduccion.Activa; };

			}
		}

		/// <summary>
		/// Almacena en la BD el nombre del proceso de la instancia
		/// </summary>
		public string TipoProcesoNombre { private set { } get { return this.TipoProceso.ToString ( ); } }

		/// <summary>
		/// Almacena la fecha en la que se planea que se ejecute la orden de trabajo del proceso indicado en la maquina asignada
		/// </summary>
		public DateTime? FechaProgramada { get; set; }

		/// <summary>
		/// Almacena la fecha en la que se procesó realmente la orden de trabajo en la maquina indicada
		/// </summary>
		public DateTime? FechaProcesada { get; set; }

		/// <summary>
		/// Indica la prioridad que tendra la orden de trabajo en la fecha planeada
		/// </summary>
		public int? prioridad { get; set; }

		/// <summary>
		/// Estatus y seguimiento del proceso de produccion
		/// </summary>
		public statusProcesoProduccion Estatus { get; set; } = statusProcesoProduccion.PorProgramar;

		/// <summary>
		/// Entidad Padre.
		/// </summary>
		public virtual Planeacion Planeacion { get; set; }


		#region WPF Planeacion
		private bool _IsSelected = false;
		[NotMapped]
		public bool IsSelected
		{
			get; set;
			//get { return _IsSelected; }
			//set { if ( _IsSelected != value ) { _IsSelected = value; OnPropertyChanged ( ); } }
		}
		//#region INotifyPropertyChanged Implementation

		//public event PropertyChangedEventHandler PropertyChanged;
		//// This method is called by the Set accessor of each property.
		//// The CallerMemberName attribute that is applied to the optional propertyName
		//// parameter causes the property name of the caller to be substituted as an argument.
		//private void OnPropertyChanged ( [System.Runtime.CompilerServices.CallerMemberName] String propertyName = "" )
		//{
		//	PropertyChanged?.Invoke ( this, new PropertyChangedEventArgs ( propertyName ) );
		//}

		//#endregion
		#endregion
	}


}
