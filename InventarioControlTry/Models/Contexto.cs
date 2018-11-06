using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioControlTry.Models
{
	#region Context
	[DbConfigurationType ( typeof ( MySql.Data.EntityFramework.MySqlEFConfiguration ) )]
	public class DbInventarioContexto : System.Data.Entity.DbContext
	{
		public DbInventarioContexto () : base ( "InventarioControlTry.Properties.Settings.DataBase" )
		{
			Configuration.LazyLoadingEnabled = true;
			this.Database.Log = ( t ) => { System.Diagnostics.Debug.WriteLine ( t ); };
		}

		protected override void OnModelCreating ( DbModelBuilder modelBuilder )
		{
			//base.OnModelCreating ( modelBuilder );

			modelBuilder
			.Properties ( )
			.Where ( p => p.PropertyType.Name == "String" &
				!(
					Attribute.IsDefined ( p, typeof ( KeyAttribute ) )
					| Attribute.IsDefined ( p, typeof ( MaxLengthAttribute ) )
					| Attribute.IsDefined ( p, typeof ( MinLengthAttribute ) )
				)
			)
			.Configure ( p => p.HasMaxLength ( 250 ) );

			//modelBuilder.Entity<Movimiento> ( ).Map<Solicitud> ( S => S.Requires ( "TipoMov" ).HasValue ( "SOLICITUD" ) );
			//modelBuilder.Entity<Movimiento> ( ).Map<Transferencia> ( S => S.Requires ( "TipoMov" ).HasValue ( "TRANSFERENCIA" ) );
			//modelBuilder.Entity<Movimiento> ( ).Map<Consumo> ( S => S.Requires ( "TipoMov" ).HasValue ( "CONSUMO" ) );

			// modelBuilder.Entity<Ubicacion> ( ).Property ( p => p.RackId ).HasDatabaseGeneratedOption ( DatabaseGeneratedOption.Computed ); 

		}

		//public DbSet<Articulo> Articulos { get; set; }
		//public DbSet<Rack> Racks { get; set; }
		//public DbSet<Movimiento> Movimientos { get; set; }
		 public virtual DbSet <Movimiento > Movimientos { get; set; }
	}
	#endregion

	//#region Tables


	//[Table ( "articulos" )]
	//public class Articulo
	//{
	//	[Key, DatabaseGenerated ( DatabaseGeneratedOption.None )]
	//	public string ClaveArticulo { get; set; }
	//	public string Descripcion { get; set; }
	//}

	//[Table ( "racks" )]
	//public class Rack
	//{
	//	public enum RackTypes { Rack, onFloor, Rail, Warehouse }
	//	public int RackId { get; set; }
	//	[Required]
	//	public string Nombre { get; set; }
	//	[MaxLength ( 1000 )]
	//	public string Descripcion { get; set; }
	//	public RackTypes Tipo { get; set; }
	//	public override string ToString () => this.Nombre;
	//	public ICollection<Ubicacion> Ubicaciones { get; private set; } = new HashSet<Ubicacion> ( );

	//}

	//[Table ( "ubicaciones" )]
	//public class Ubicacion
	//{
	//	[Key, DatabaseGenerated ( DatabaseGeneratedOption.None )]
	//	public string UbicacionId { get { return this.ToString ( ); } private set { } }

	//	[Required, ForeignKey ( "Rack" )]
	//	public int RackId { get; set; }
	//	[Required, MaxLength ( 1 )]
	//	public string Nivel { get; set; }

	//	[Required, MaxLength ( 1 )]
	//	public string Columna { get; set; }

	//	[Required, MaxLength ( 1 )]
	//	public string Division { get; set; }

	//	public bool Reutilizable { get; set; } = false;

	//	public virtual Rack Rack { get; set; }
	//	public override string ToString () => $"{RackId}{Nivel}{Columna}{Division}";
	//}




	//public class Solicitud : Movimiento
	//{				
	//	[Column ( "alm_destino" )]
	//	public string AlmacenDestino { get; set; }
	//}

	//public class Transferencia : Movimiento
	//{		
	//	[ForeignKey ( "Solicitud" ), Column ( "SolicitudOrigen" )]
	//	public int SolicitudOrigen { get; set; }
	//	public virtual Solicitud Solicitud { get; set; }
	//	[Column ( "alm_origen" )]
	//	public string AlmacenOrigen { get; set; }
	//	[Column ( "alm_destino" )]
	//	public string AlmacenDestino { get; set; }		
	//	public virtual Ubicacion UbicacionOrigen { get; set; }
	//	public virtual Ubicacion UbicacionDestino { get; set; }
	//}
	//public class Consumo : Movimiento
	//{

	//	[Column ( "alm_origen" )]
	//	public string AlmacenOrigen { get; set; }
	//	[ForeignKey ( "ArticuloDestino_Entity" )]
	//	public string ArticuloDestino { get; set; }
	//	public virtual Articulo ArticuloDestino_Entity { get; set; }
	//}

	//#endregion

	//#region Abstract Tables

	//[Table ( "movimientos" )]
	//public abstract class Movimiento
	//{
	//	public enum EstatusMovimiento { SinAfectar, Cancelado, Concluido, Parcial }
	//	public int MovimientoId { get; set; }
	//	[ForeignKey ( "Articulo" )]
	//	public string ClaveArticulo { get; set; }

	//	public DateTime FechaGenerado { get; set; }
	//	[MaxLength ( 10 )]
	//	public string OT { get; set; }
	//	[Required]
	//	public double Cantidad { get; set; }

	//	[NotMapped]
	//	public  EstatusMovimiento Estatus { get; set; }
	//	[Column("estado")]
	//	public string Estatus_string
	//	{
	//		get { return Estatus.ToString ( ); }
	//		private set { Estatus = value.ParseEnum<EstatusMovimiento> ( ); }
	//	}
	//	public virtual Articulo Articulo { get; set; }
	//}

	//#endregion

	//#region ComplexTypes
	//public static class StringExtensions
	//{
	//	public static T ParseEnum<T> ( this string value )
	//	{
	//		return (T)Enum.Parse ( typeof ( T ), value, true );
	//	}
	//}
	//#endregion
}
