using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProduccionDataBase.Tablas;

namespace libProduccionDataBase.Tablas {
	[Table ( "ncuatro_tarimas" )]
	public class NaveCuatro_Tarima {
		public NaveCuatro_Tarima ( ) {
			this.Items = new ObservableListSource<NaveCuatro_TarimaItem> ( );
		}

		public int Id { get; set; }

		public DateTime FechaCaptura { get; set; }
		public DateTime FechaExtrusion { get; set; }

		public string Usuario { get; set; }
		public double Ancho { get; set; }
		public double Calibre { get; set; }

		[Required ( ErrorMessage = "La OT a ala que pertenece la tarima es requerida" )]
		public string OT { get; set; }
		[ForeignKey ( "OT" )]
		public virtual TemporalOrdenTrabajo OrdenTrabajo { get; set; }

		public virtual ObservableListSource<NaveCuatro_TarimaItem> Items { get; private set; }

	}
	[Table ( "ncuatro_tarimas_items" )]
	public class NaveCuatro_TarimaItem {

		[Key, DatabaseGenerated ( DatabaseGeneratedOption.Identity )]
		public int Id { get; set; }

		public int Item_Id { get; set; }

		[ForeignKey ( "Item_Id" )]
		public virtual TempProduccion Item { get; set; }

		public int Tarima_Id { get; set; }
		[ForeignKey ( "Tarima_Id" )]
		public virtual NaveCuatro_Tarima Tarima { get; set; }

		public override string ToString ( ) {
			return $"{Item.OT}_{Item.NUMERO}_{ Item.EXTRUSION_ID }";
		}

	}
}
