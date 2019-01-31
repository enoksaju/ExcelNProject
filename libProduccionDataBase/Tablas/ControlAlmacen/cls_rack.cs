using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas.ControlAlmacen
{
	[Table ( "alm_zona" )]
	public class zona
	{
		[Key, MaxLength ( 3, ErrorMessage = "EL tamaño maximo es de 3 caracteres" )]
		public string ZonaId { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public virtual ObservableListSource<ubicacion> Ubicaciones { get; private set; }
		public zona ()
		{
			Ubicaciones = new ObservableListSource<ubicacion> ( );
		}
	}

	[Table ( "alm_ubic" )]
	public class ubicacion
	{
		[Key, DatabaseGenerated ( DatabaseGeneratedOption.Computed )]
		public string UbicacionId { get; set; }
		[MaxLength ( 3, ErrorMessage = "EL tamaño maximo es de 3 caracteres" ), ForeignKey ( "Zona" )]
		public string ZonaId { get; set; }
		public int RackId { get; set; }
		[MaxLength ( 1, ErrorMessage = "Solo acepta 1 caracter, normalmente 'A' o 'B'" )]
		public string Lado { get; set; }
		public int Nivel { get; set; }
		public int Columna { get; set; }
		public virtual zona Zona { get; set; }

		public virtual ObservableListSource<Contenido> ContenidoHistory { get; private set; }
		public ubicacion ()
		{
			ContenidoHistory = new ObservableListSource<Contenido> ( );
		}
	}

	[Table ( "alm_cont" )]
	public class Contenido
	{
		public int ContenidoId { get; set; }
		[ForeignKey ( "Ubicacion" )]
		public string UbicacionId { get; set; }
		[ForeignKey ( "Roll" )]
		public int RollId { get; set; }
		public DateTime FechaEntrada { get; set; }
		public DateTime FechaSalida { get; set; }
		public bool esContenidoActual { get; set; }
		public virtual ubicacion Ubicacion { get; set; }
		public virtual TempProduccion Roll { get; set; }
	}


	public abstract class Rollo
	{
		public int RolloId { get; set; }
		public virtual ObservableListSource<Rollo> RollosOrigen { get; private set; }
	}


}
