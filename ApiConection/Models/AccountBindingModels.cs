using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ApiConection.Models
{
    // Modelos usados como parámetros para las acciones de AccountController.

    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "Token de acceso externo")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar la nueva contraseña")]
        [Compare("NewPassword", ErrorMessage = "La nueva contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

		[Display(Name = "Nombre")]
		[Required ( ErrorMessage = "El nombre del usuario es requerido" )]
		public string Nombre { get; set; }

		[Display ( Name = "Apellido Paterno" )]
		[Required ( ErrorMessage = "El Apellido Paterno del usuario es requerido" )]
		public string ApellidoPaterno { get; set; }

		[Display ( Name = "Apellido Materno" )]
		[Required ( ErrorMessage = "El Apellido Materno del usuario es requerido" )]
		public string ApellidoMaterno { get; set; }

		[Display(Name ="Clave Trabajador")]
		[MaxLength ( 10, ErrorMessage = "El largo maximo para la clave del trabajador es de 10 caracteres" )]
		public string ClaveTrabajador { get; set; }
	}

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }

	public class LoginBindingModel
	{
		[Required]
		[Display ( Name = "Usuario" )]
		public string UserName { get; set; }

		[Required]
		[Display ( Name = "Contraseña" )]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}


	public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Proveedor de inicio de sesión")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Clave de proveedor")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar la nueva contraseña")]
        [Compare("NewPassword", ErrorMessage = "La nueva contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}
