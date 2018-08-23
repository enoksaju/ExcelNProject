using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Cotizador.Models;
using Cotizador.Models.AccountBindingModel;
using Cotizador.Models.AccountViewModel;
using Cotizador.Providers;
using Cotizador.Results;
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;

namespace Cotizador.Controllers
{
	[Authorize ( Roles = "Administrador, Sistemas, Develop" )]
	[RoutePrefix ( "api/Account" )]
	public class AccountController : ApiController
	{
		#region Cofiguration Class
		private ApplicationRoleManager _roleManager;
		private const string LocalLoginProvider = "Local";
		private Models.ApplicationUserManager _userManager;

		public Models.ApplicationUserManager UserManager
		{
			get { return _userManager ?? Request.GetOwinContext ( ).GetUserManager<Models.ApplicationUserManager> ( ); }
			private set { _userManager = value; }
		}
		public ApplicationRoleManager RoleManager
		{
			get { return _roleManager ?? Request.GetOwinContext ( ).Get<ApplicationRoleManager> ( ); }
			private set { _roleManager = value; }
		}
		public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; }

		public AccountController () { }
		public AccountController ( Models.ApplicationUserManager userManager, ISecureDataFormat<AuthenticationTicket> accessTokenFormat )
		{
			UserManager = userManager;
			AccessTokenFormat = accessTokenFormat;
		}

		#endregion

		// GET api/Account/ExternalLogin
		[OverrideAuthentication]
		[HostAuthentication ( DefaultAuthenticationTypes.ExternalCookie )]
		[AllowAnonymous]
		[Route ( "ExternalLogin", Name = "ExternalLogin" )]
		public async Task<IHttpActionResult> GetExternalLogin ( string provider, string error = null )
		{
			if ( error != null )
			{
				return Redirect ( Url.Content ( "~/" ) + "#error=" + Uri.EscapeDataString ( error ) );
			}

			if ( !User.Identity.IsAuthenticated )
			{
				return new ChallengeResult ( provider, this );
			}

			ExternalLoginData externalLogin = ExternalLoginData.FromIdentity ( User.Identity as ClaimsIdentity );

			if ( externalLogin == null )
			{
				return InternalServerError ( );
			}

			if ( externalLogin.LoginProvider != provider )
			{
				Authentication.SignOut ( DefaultAuthenticationTypes.ExternalCookie );
				return new ChallengeResult ( provider, this );
			}

			ApplicationUser user = await UserManager.FindAsync ( new UserLoginInfo ( externalLogin.LoginProvider,
				externalLogin.ProviderKey ) );

			bool hasRegistered = user != null;

			if ( hasRegistered )
			{
				Authentication.SignOut ( DefaultAuthenticationTypes.ExternalCookie );

				ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync ( UserManager, OAuthDefaults.AuthenticationType );
				ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync ( UserManager, CookieAuthenticationDefaults.AuthenticationType );

				AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties ( user.UserName, user.Id );
				Authentication.SignIn ( properties, oAuthIdentity, cookieIdentity );
			}
			else
			{
				IEnumerable<Claim> claims = externalLogin.GetClaims ( );
				ClaimsIdentity identity = new ClaimsIdentity ( claims, OAuthDefaults.AuthenticationType );
				Authentication.SignIn ( identity );
			}

			return Ok ( );
		}

		// GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
		[AllowAnonymous]
		[Route ( "ExternalLogins" )]
		public IEnumerable<ExternalLoginViewModel> GetExternalLogins ( string returnUrl, bool generateState = false )
		{
			IEnumerable<AuthenticationDescription> descriptions = Authentication.GetExternalAuthenticationTypes ( );
			List<ExternalLoginViewModel> logins = new List<ExternalLoginViewModel> ( );

			string state;

			if ( generateState )
			{
				const int strengthInBits = 256;
				state = RandomOAuthStateGenerator.Generate ( strengthInBits );
			}
			else
			{
				state = null;
			}

			foreach ( AuthenticationDescription description in descriptions )
			{
				ExternalLoginViewModel login = new ExternalLoginViewModel
				{
					Name = description.Caption,
					Url = Url.Route ( "ExternalLogin", new
					{
						provider = description.AuthenticationType,
						response_type = "token",
						client_id = Startup.PublicClientId,
						redirect_uri = new Uri ( Request.RequestUri, returnUrl ).AbsoluteUri,
						state = state
					} ),
					State = state
				};
				logins.Add ( login );
			}

			return logins;
		}

		[Route ( "UserRoles" )]
		[HttpPost]
		[AllowAnonymous]
		public IHttpActionResult UserRoles ( [FromBody]int? Id )
		{
			int currentUserId;
			int.TryParse ( User.Identity.GetUserId ( ), out currentUserId );
			var _id = Id ?? currentUserId;

			if ( _id == 0 ) return Ok ( new List<string> ( ) { "Usuario" } );

			using ( var DB = new DataBaseContexto ( ) )
			{
				if ( !DB.Users.Any ( o => o.Id == _id ) ) return BadRequest ( "Usuario no valido" );
			}
			return Ok ( UserManager.GetRoles ( _id ) );
		}

		// POST api/Account/Register		
		[Route ( "Register" )]
		public async Task<IHttpActionResult> Register ( RegisterBindingModel model )
		{

			if ( !ModelState.IsValid )
			{
				return BadRequest ( ModelState );
			}

			var user = new ApplicationUser ( )
			{
				UserName = model.Email,
				Email = model.Email,
				Nombre = model.Nombre,
				ApellidoPaterno = model.ApellidoPaterno,
				ApellidoMaterno = model.ApellidoMaterno,
				Estatus = ApplicationUser.status.Espera,
				ClaveTrabajador = model.Clave.ToString ( )
			};
			IdentityResult result = null;

			try
			{
				result = await UserManager.CreateAsync ( user, model.Password );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.GetInnerException ( ex ) );
			}

			if ( !result.Succeeded )
			{
				return GetErrorResult ( result );
			}
			else
			{
				System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage (

				 new System.Net.Mail.MailAddress ( "hsalinas@excelnobleza.com.mx", "Registro de usuarios" ),
				 new System.Net.Mail.MailAddress ( user.Email ) )
				{
					Subject = "Email confirmation",
					Body = string.Format ( @"
		Hola {0} 
		<br /> 
		Gracias, para poder continuar , por favor haga click en el siguiente link de confirmación: 
		<a href =""{1}"" title =""Confirmar usuario"">Confirme su Correo</a>",
		$"{ user.Nombre } { user.ApellidoPaterno }",
		$"{ Url.Link ( "Default", new { Controller = "Services", Action = "ConfirmEmail" } ) }?Email={HttpUtility.UrlEncode ( user.Email )}&Token={ HttpUtility.UrlEncode ( user.Id.ToString ( ) ) }" ),
					IsBodyHtml = true
				};

				System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient ( "webmail.excelnobleza.com.mx", 25 );
				smtp.Credentials = new System.Net.NetworkCredential ( "hsalinas@excelnobleza.com.mx", "hsj43295" );
				// smtp.EnableSsl = true;
				smtp.Send ( m );

				UserManager.AddToRole ( user.Id, "Usuario" );
				return Ok ( );
			}
		}

		[Route ( "ManageRoles" )]
		public async Task<IHttpActionResult> ManageRoles ( AddRemoveUserRoleModel model )
		{
			if ( !ModelState.IsValid )
			{
				return BadRequest ( ModelState );
			}
			var user = await UserManager.FindByIdAsync ( model.UserId );
			if ( user == null )
			{
				return BadRequest ( "Error en los datos" );
			}

			if ( !await RoleManager.RoleExistsAsync ( model.Role ) ) return BadRequest ( "El rol indicado no existe" );

			switch ( model.Action )
			{
				case AddRemoveUserRoleModel.Actions.Add:
					await UserManager.AddToRoleAsync ( model.UserId, model.Role );
					break;
				case AddRemoveUserRoleModel.Actions.Remove:
					await UserManager.RemoveFromRoleAsync ( model.UserId, model.Role );
					break;
				default:
					return BadRequest ( "Error en los datos" );
			}
			return Ok ( $"Se completo la accion {model.Action.ToString ( )} del rol {model.Role} al usuario {user.Nombre} {user.ApellidoPaterno} {user.ApellidoMaterno }." );
		}

		[Route ( "Users" )]
		[HttpGet]
		public async Task<IHttpActionResult> UsuariosList ()
		{
			var ret = new List<BasicInfoUser> ( );

			foreach ( var itm in await UserManager.Users.ToListAsync ( ) )
			{
				ret.Add ( new BasicInfoUser ( )
				{
					Nombre = $"{itm.Nombre} {itm.ApellidoPaterno} {itm.ApellidoMaterno}",
					Email = itm.Email,
					EmailConfirmed = itm.EmailConfirmed,
					Id = itm.Id,
					Roles = ( await UserManager.GetRolesAsync ( itm.Id ) ).ToList ( )
				} );
			}

			return Ok ( ret );
		}

		#region Aplicaciones Auxiliares
		private IAuthenticationManager Authentication => Request.GetOwinContext ( ).Authentication;
		private IHttpActionResult GetErrorResult ( IdentityResult result )
		{
			if ( result == null )
			{
				return InternalServerError ( );
			}

			if ( !result.Succeeded )
			{
				if ( result.Errors != null )
				{
					foreach ( string error in result.Errors )
					{
						ModelState.AddModelError ( "", error );
					}
				}

				if ( ModelState.IsValid )
				{
					// No hay disponibles errores ModelState para enviar, por lo que simplemente devuelva un BadRequest vacío.
					return BadRequest ( );
				}

				return BadRequest ( ModelState );
			}
			return null;
		}
		private class ExternalLoginData
		{
			public string LoginProvider { get; set; }
			public string ProviderKey { get; set; }
			public string UserName { get; set; }

			public IList<Claim> GetClaims ()
			{
				IList<Claim> claims = new List<Claim> ( );
				claims.Add ( new Claim ( ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider ) );

				if ( UserName != null )
				{
					claims.Add ( new Claim ( ClaimTypes.Name, UserName, null, LoginProvider ) );
				}

				return claims;
			}

			public static ExternalLoginData FromIdentity ( ClaimsIdentity identity )
			{
				if ( identity == null )
				{
					return null;
				}

				Claim providerKeyClaim = identity.FindFirst ( ClaimTypes.NameIdentifier );

				if ( providerKeyClaim == null || String.IsNullOrEmpty ( providerKeyClaim.Issuer )
					|| String.IsNullOrEmpty ( providerKeyClaim.Value ) )
				{
					return null;
				}

				if ( providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer )
				{
					return null;
				}

				return new ExternalLoginData
				{
					LoginProvider = providerKeyClaim.Issuer,
					ProviderKey = providerKeyClaim.Value,
					UserName = identity.FindFirstValue ( ClaimTypes.Name )
				};
			}
		}
		private static class RandomOAuthStateGenerator
		{
			private static RandomNumberGenerator _random = new RNGCryptoServiceProvider ( );

			public static string Generate ( int strengthInBits )
			{
				const int bitsPerByte = 8;

				if ( strengthInBits % bitsPerByte != 0 )
				{
					throw new ArgumentException ( "strengthInBits debe ser uniformemente divisible por 8.", nameof ( strengthInBits ) );
				}

				int strengthInBytes = strengthInBits / bitsPerByte;

				byte[] data = new byte[ strengthInBytes ];
				_random.GetBytes ( data );
				return HttpServerUtility.UrlTokenEncode ( data );
			}
		}
		#endregion
	}
}
