using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas {

	[Table ( "Tinta_Proveedores" )]
	public class ProveedorTinta {
		public ProveedorTinta ( ) {
			TiposTinta = new ObservableListSource<Tablas.TiposTinta> ( );
			Articulos = new ObservableListSource<ArticuloTinta> ( );
		}
		public int Id { get; set; }
		public string Nombre { get; set; }
		public virtual ObservableListSource<TiposTinta> TiposTinta { get; set; }
		public virtual ObservableListSource<ArticuloTinta> Articulos { get; set; }
		public override string ToString ( ) {
			return this.Nombre;
		}
	}

	[Table ( "Tinta_Articulos" )]
	public class ArticuloTinta {

		public ArticuloTinta ( ) {
			Entradas = new ObservableListSource<EntradaTinta> ( );
			Salidas = new ObservableListSource<ComponentesSalida> ( );
		}

		[Key, Required ( ErrorMessage = "La Clave es Requerida." )]
		public string Clave { get; set; }
		[Required ( ErrorMessage = "La descripcion del Articulo es requerida." )]
		public string Descripcion { get; set; }

		[ForeignKey ( "Tipo" ), Required ( ErrorMessage = "La Familia a la que pertenece el Articulo es Requerida." )]
		public int? TiposTinta_Id { get; set; } = null;
		public virtual TiposTinta Tipo { get; set; }

		[ForeignKey ("Proveedor")]
		public int Proveedor_Id { get; set; }
		public virtual ProveedorTinta Proveedor { get; set; }

		public string ClaveIntelisis { get; set; }
		public virtual ObservableListSource<EntradaTinta> Entradas { get; set; }
		public virtual ObservableListSource<ComponentesSalida> Salidas { get; set; }
		public virtual double? Existencias {
			get {
				return Entradas?.Sum ( o => o.Cantidad ) - Salidas?.Sum ( o => o.Cantidad );
			}
		}
	}

	[Table ( "Tinta_Tipos" )]
	public class TiposTinta {
		public TiposTinta ( ) {
			this.Articulos = new ObservableListSource<ArticuloTinta> ( );
		}
		public int Id { get; set; }
		public string Nombre { get; set; }
		public override string ToString ( ) => this.Nombre;
		public virtual ObservableListSource<ArticuloTinta> Articulos { get; set; }

		[ForeignKey ( "Proveedor" )]
		public int Proveedor_Id { get; set; }
		public virtual ProveedorTinta Proveedor { get; set; }
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
		public SalidaTinta ( ) {
			this.Componentes = new ObservableListSource<ComponentesSalida> ( );
		}

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

	[Table ( "Tinta_SalidasComponents" )]
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
