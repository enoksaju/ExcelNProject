using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.Otros
{
	public class AVTFolios
	{
		public int Id { get; set; }
		public DateTime FechaImpresion { get; set; }
		public AVTFolios()
		{
			FechaImpresion = DateTime.Now;
		}

	}
}
