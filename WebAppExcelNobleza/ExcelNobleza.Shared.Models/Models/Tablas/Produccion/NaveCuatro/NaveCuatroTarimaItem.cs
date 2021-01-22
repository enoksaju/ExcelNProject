using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.Produccion.NaveCuatro
{
	[Table("ncuatro_tarimas_items")]
	public class NaveCuatro_TarimaItem
	{
		public int Item_Id { get; set; }
		public int Tarima_Id { get; set; }

		[ForeignKey("Item_Id")]
		public virtual Produccion Item { get; set; }
		[ForeignKey("Tarima_Id")]
		public virtual NaveCuatro_Tarima Tarima { get; set; }
		public override string ToString() => $"{Item.OT}_{Item.NUMERO}_{ Item.EXTRUSION_ID }";
		public string ToShow => String.Format("{0,10:0000000000} {1,6} {2,10:#0.00} Kg", this.Item?.Id, this.Item?.EXTRUSION_ID, this.Item?.PESONETO);

	}
}
