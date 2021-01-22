using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas.AVT
{
	public class AVTFolios
	{
		public int Id { get; set; }
		public DateTime	FechaImpresion { get; set; }
		public AVTFolios()
		{
			FechaImpresion = DateTime.Now;
		}

	}
}
