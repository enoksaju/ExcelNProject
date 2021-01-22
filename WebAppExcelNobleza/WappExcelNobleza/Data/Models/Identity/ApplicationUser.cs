using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WappExcelNobleza.Data.Models.Identity
{
	public class ApplicationUser : IdentityUser
	{
		public string Nombre { get; set; }
		public string Apellidos { get; set; }
		public string Area { get; set; }

		[Required(ErrorMessage = "Es necesario su numero de trabajador")]
		public string ClaveTrabajador { get; set; }
	}
}
