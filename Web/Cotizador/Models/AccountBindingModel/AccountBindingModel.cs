using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cotizador.Models.AccountBindingModel
{
	public class RegisterBindingModel
	{
		[Required]
		[Display ( Name = "Correo electrónico" )]
		public string Email { get; set; }

		[Required]
		[StringLength ( 100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6 )]
		[DataType ( DataType.Password )]
		public string Password { get; set; }

		[DataType ( DataType.Password )]
		[Compare ( "Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden." )]
		public string ConfirmPassword { get; set; }

		[Required]
		public string Nombre { get; set; }

		[Required]
		public string ApellidoPaterno { get; set; }

		[Required]
		public string ApellidoMaterno { get; set; }
		[RegularExpression("[0-9]{4,}", ErrorMessage ="El valor debe ser numérico y contener al menos 4 digitos")]
		public int Clave { get; set; }
	}

	public class AddRemoveUserRoleModel
	{
		public enum Actions { Add, Remove }
		[Required]
		public string Role { get; set; }
		[Required]
		public Actions Action { get; set; }
		[Required]
		public int UserId { get; set; }
	}
}