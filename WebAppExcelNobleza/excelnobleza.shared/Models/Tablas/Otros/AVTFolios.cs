using System;

namespace excelnobleza.shared.Models.Tablas.Otros
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
