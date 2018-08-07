using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Cotizador.Models
{
	public class ApplicationRoleManager : RoleManager<ApplicationRole, int>
	{
		public ApplicationRoleManager ( ApplicationRoleStore store ) : base ( store ) { }
		public static ApplicationRoleManager Create ( IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context )
		{
			return new ApplicationRoleManager ( new ApplicationRoleStore ( context.Get<DataBaseContexto> ( ) ) );
		}
	}

	public class ApplicationUserManager : UserManager<ApplicationUser, int>
	{
		public ApplicationUserManager ( ApplicationUserStore store )
			: base ( store )
		{
			this.PasswordValidator = new PasswordValidator
			{
				RequiredLength = 5,
				RequireUppercase = false,
				RequireNonLetterOrDigit = false,
				RequireDigit = true,
				RequireLowercase = false
			};
		}

		public static ApplicationUserManager Create ( IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context )
		{
			var manager = new ApplicationUserManager ( new ApplicationUserStore ( context.Get<DataBaseContexto> ( ) ) );
			// Configure la lógica de validación de nombres de usuario
			manager.UserValidator = new UserValidator<ApplicationUser, int> ( manager )
			{
				AllowOnlyAlphanumericUserNames = false,
				RequireUniqueEmail = true
			};
			// Configure la lógica de validación de contraseñas
			manager.PasswordValidator = new PasswordValidator
			{
				RequiredLength = 5,
				RequireUppercase = false,
				RequireNonLetterOrDigit = false,
				RequireDigit = true,
				RequireLowercase = false
			};
			var dataProtectionProvider = options.DataProtectionProvider;
			if ( dataProtectionProvider != null )
			{
				manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser, int> ( dataProtectionProvider.Create ( "ASP.NET Identity" ) );
			}
			return manager;
		}
	}
}