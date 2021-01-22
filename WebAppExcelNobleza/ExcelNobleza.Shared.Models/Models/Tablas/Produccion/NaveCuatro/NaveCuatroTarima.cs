using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.Produccion.NaveCuatro
{
	[Table("ncuatro_tarimas")]
	public class NaveCuatro_Tarima
	{
		public NaveCuatro_Tarima()
		{
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

		[Required(ErrorMessage = "La OT a ala que pertenece la tarima es requerida")]
		public string OT { get; set; }
		[ForeignKey("OT")]
		public virtual OrdenTrabajo OrdenTrabajo { get; set; }

		public virtual List<NaveCuatro_TarimaItem> Items { get; private set; } = new List<NaveCuatro_TarimaItem>();

		public override string ToString() => $"{this.OT}_{ FechaCaptura:ddMMyyHHmm}";
		public string toShow => $"{this.OT}_{ FechaCaptura:ddMMyyHHmm}";

		public double PesoNetoTotal => Items.Sum(o => (o.Item?.PESONETO).Value);

	}
}
