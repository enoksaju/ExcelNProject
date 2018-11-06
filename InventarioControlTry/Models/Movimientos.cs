using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioControlTry.Models
{
	public class Almacen
	{
		[Column ( "almacen" ), Key]
		public string AlmacenId { get; set; }
		public string Descripcion { get; set; }
		public virtual ICollection<Movimiento> Movimientos { get; set; }
		public Almacen ()
		{
			Movimientos = new HashSet<Movimiento> ( );
		}
	}
	public abstract class Movimiento
	{
		public enum UnidadMovimiento { Kg, Millares, Piezas }
		[Key, DatabaseGenerated ( DatabaseGeneratedOption.Identity )]
		public int MovimientoId { get; set; }
		public DateTime FechaGenerado { get; set; }
		public DateTime FechaConcluido { get; set; }
		public string Usuario { get; set; }
		public string Terminal { get; set; }

		[Column ( "alm_origen" ), ForeignKey ( "AlmacenOrigen" )]
		public string AlmacenOrigenId { get; set; }
		[Column ( "alm_destino" ), ForeignKey ( "AlmacenDestino" )]
		public string AlamcenDestinoId { get; set; }

		[Column ( "cantidad" )]
		public double Cantidad { get; set; }

		[NotMapped]
		public UnidadMovimiento Unidad { get; set; }
		[Column ( "unidad" )]
		public string UnidadString
		{
			get
			{
				return Unidad.ToString ( );
			}
			private set
			{
				UnidadMovimiento unit;
				if ( Enum.TryParse ( value, out unit ) )
				{
					Unidad = unit;
				}
				else
				{
					Unidad = UnidadMovimiento.Kg;
				}
			}
		}

		public double Factor { get; set; }

		#region Navigation Properties
		public virtual Almacen AlmacenOrigen { get; set; }
		public virtual Almacen AlmacenDestino { get; set; }
		#endregion

	}

	public class Entrada : Movimiento
	{
		public DateTime FechaEntrada { get; set; }
		[Column("ubicacion_destino"), MaxLength (128)]
		public string Ubicacion { get; set; }
	}

	public class Transferencia : Movimiento
	{
		[Column ( "ubicacion_origen" ), MaxLength ( 128 )]
		public string UbicacionOrigen { get; set; }
		[Column ( "ubicacion_destino" ), MaxLength ( 128 )]
		public string UbicacionDestino { get; set; }
	}
}
