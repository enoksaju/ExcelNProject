using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cotizador.Models.FrontEndModels.Catalogos
{
	public class FronEndModel_FamiliasMateriales
	{
		public int Id { get; set; }
		[Required]
		public string NombreFamilia { get; set; }
	}
}