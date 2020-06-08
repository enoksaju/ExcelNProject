using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using ApiConection.Models;
using libProduccionDataBase.Identity;
using libProduccionDataBase.Contexto;

namespace ApiConection
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<libProduccionDataBase.Identity.ApplicationUser, int>
    {
        public ApplicationUserManager(IUserStore<libProduccionDataBase.Identity.ApplicationUser, int> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
			var manager = new ApplicationUserManager ( new UserStore<libProduccionDataBase.Identity.ApplicationUser, libProduccionDataBase.Identity.ApplicationRole, int, libProduccionDataBase.Identity.ApplicationUserLogin, libProduccionDataBase.Identity.ApplicationUserRole, libProduccionDataBase.Identity.ApplicationUserClaim> (context.Get<libProduccionDataBase.Contexto.DataBaseContexto>() ) );

				//new UserStore<libProduccionDataBase.Identity.ApplicationUser> (context.Get<libProduccionDataBase.Contexto.DataBaseContexto>()));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<libProduccionDataBase.Identity.ApplicationUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<libProduccionDataBase.Identity.ApplicationUser, int>(dataProtectionProvider.Create("ExcelNobleza_HenocSalinas"));
            }
            return manager;
        }
    }

	public class ApplicationRoleManager : RoleManager<ApplicationRole, int>
	{
		public ApplicationRoleManager ( ApplicationRoleStore store ) : base ( store ) { }
		public static ApplicationRoleManager Create ( IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context )
		{
			return new ApplicationRoleManager ( new ApplicationRoleStore ( context.Get<DataBaseContexto> ( ) ) );
		}
	}
}
