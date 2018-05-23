using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas {
	[Table ( "Tinta_Articulos" )]
	public class ArticuloTinta {
		[Key]
		public string Clave { get; set; }
		public string Descripcion { get; set; }
		public int TiposTinta_Id { get; set; }
		[ForeignKey ( "TiposTinta_Id" )]
		public virtual TiposTinta Tipo { get; set; }

		public virtual ObservableListSource<EntradaTinta> Entradas { get; set; }
		public virtual ObservableListSource<ComponentesSalida> Salidas { get; set; }

		public virtual double Existencias => Entradas.Sum ( o => o.Cantidad ) - Salidas.Sum ( o => o.Cantidad );
	}

	[Table ( "Tinta_Tipos" )]
	public class TiposTinta {
		public int Id { get; set; }
		public string Nombre { get; set; }
		public override string ToString ( ) => this.Nombre;
	}

	[Table ( "Tinta_Entradas" )]
	public class EntradaTinta {
		[Key, DatabaseGenerated ( DatabaseGeneratedOption.Identity )]
		public int MovId { get; set; }
		public DateTime Fecha { get; set; }
		public DateTime FechaCaptura { get; set; }
		public string ClaveTinta { get; set; }
		[ForeignKey ( "ClaveTinta" )]
		public virtual ArticuloTinta Tinta { get; set; }
		public double Cantidad { get; set; }
		public bool UsoBascula { get; set; }
	}

	[Table ( "Tinta_Salidas" )]
	public class SalidaTinta {
		private string _OT = "";
		public enum MotivosSalida { Entonacion, Produccion }
		[Key, DatabaseGenerated ( DatabaseGeneratedOption.Identity )]
		public int MovId { get; set; }
		public DateTime Fecha { get; set; }
		public DateTime FechaCaptura { get; set; }
		public string OT { get { return _OT; } set { _OT = value.Trim ( ); } }
		public virtual TemporalOrdenTrabajo OrdenTrabajo { get; set; }
		public virtual ObservableListSource<ComponentesSalida> Componentes { get; set; }
		public MotivosSalida Motivo { get; set; }
	}
	[Table ( "Tinta_SallidasComponents" )]
	public class ComponentesSalida {
		[Key, DatabaseGenerated ( DatabaseGeneratedOption.Identity )]
		public int ComponenteId { get; set; }
		public int MovId { get; set; }
		public virtual SalidaTinta SalidaTinta { get; set; }
		public string ClaveTinta { get; set; }
		[ForeignKey ( "ClaveTinta" )]
		public virtual ArticuloTinta Tinta { get; set; }
		public double Cantidad { get; set; }
		public bool UsoBascula { get; set; }
	}

}
