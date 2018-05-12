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
			this.FechaCaptura = DateTime.Now;
			this.FechaExtrusion = DateTime.Now;
			this.Usuario = Environment.MachineName;
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

		public override string ToString ( ) => $"{this.OT}_{ FechaCaptura.ToString ( "ddMMyyHHmm" )}";
		public string toShow => $"{this.OT}_{ FechaCaptura.ToString ( "ddMMyyHHmm" )}";

		public double PesoNetoTotal => Items.Sum ( o => ( o.Item?.PESONETO ).Value );

	}
	[Table ( "ncuatro_tarimas_items" )]
	public class NaveCuatro_TarimaItem {

		//[Key, DatabaseGenerated ( DatabaseGeneratedOption.Identity )]
		[Key, Column ( Order = 0 )]
		public int Item_Id { get; set; }

		[Key, Column ( Order = 1 )]
		public int Tarima_Id { get; set; }

		//[Index ("ItemTarima_Idx",IsUnique =true, Order =1)]

		[ForeignKey ( "Item_Id" )]
		public virtual TempProduccion Item { get; set; }
		[ForeignKey ( "Tarima_Id" )]
		public virtual NaveCuatro_Tarima Tarima { get; set; }

		public override string ToString ( ) => $"{Item.OT}_{Item.NUMERO}_{ Item.EXTRUSION_ID }";

		public string ToShow => String.Format ( "{0,10:0000000000} {1,6} {2,10:#0.00} Kg" , this.Item?.Id , this.Item?.EXTRUSION_ID , this.Item?.PESONETO );

	}
}
