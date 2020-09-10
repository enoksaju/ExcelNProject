using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using ApiConection.Models;
using libProduccionDataBase.Identity;

namespace ApiConection.Providers
{
	public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
	{
		private readonly string _publicClientId;

		public ApplicationOAuthProvider ( string publicClientId )
		{
			if ( publicClientId == null )
			{
				throw new ArgumentNullException ( "publicClientId" );
			}

			_publicClientId = publicClientId;
		}

		public override async Task GrantResourceOwnerCredentials ( OAuthGrantResourceOwnerCredentialsContext context )
		{
			var userManager = context.OwinContext.GetUserManager<ApplicationUserManager> ( );

			libProduccionDataBase.Identity.ApplicationUser user = await userManager.FindAsync ( context.UserName, context.Password );

			if ( user == null )
			{
				context.SetError ( "invalid_grant", "El nombre de usuario o la contraseña no son correctos." );
				return;
			}
			if ( user.Estatus == ApplicationUser.status.Baja )
			{
				context.SetError ( "invalid_grant", "Usuario no Autorizado." );
				return;
			}

			ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync ( userManager, OAuthDefaults.AuthenticationType );
			ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync ( userManager, CookieAuthenticationDefaults.AuthenticationType );

			var roles = await userManager.GetRolesAsync ( user.Id );

			AuthenticationProperties properties = CreateProperties ( user.UserName, user.Nombre, user.ApellidoPaterno, user.ApellidoMaterno, user.ClaveTrabajador, roles.ToArray ( ), user.Id );

			AuthenticationTicket ticket = new AuthenticationTicket ( oAuthIdentity, properties );
			context.Validated ( ticket );
			context.Request.Context.Authentication.SignIn ( cookiesIdentity );
		}

		#region[TokenEndpoint]
		public override Task TokenEndpoint ( OAuthTokenEndpointContext context )
		{
			foreach ( KeyValuePair<string, string> property in context.Properties.Dictionary )
			{
				context.AdditionalResponseParameters.Add ( property.Key, property.Value );
			}
			return Task.FromResult<object> ( null );
		}
		#endregion

		#region[ValidateClientAuthentication]
		public override Task ValidateClientAuthentication ( OAuthValidateClientAuthenticationContext context )
		{
			if ( context.ClientId == null )
				context.Validated ( );

			return Task.FromResult<object> ( null );
		} /**/
		#endregion

		public override Task ValidateClientRedirectUri ( OAuthValidateClientRedirectUriContext context )
		{
			if ( context.ClientId == _publicClientId )
			{
				Uri expectedRootUri = new Uri ( context.Request.Uri, "/" );

				if ( expectedRootUri.AbsoluteUri == context.RedirectUri )
				{
					context.Validated ( );
				}
			}

			return Task.FromResult<object> ( null );
		}

		#region[GrantRefreshToken]
		public override Task GrantRefreshToken ( OAuthGrantRefreshTokenContext context )
		{
			// Change authentication ticket for refresh token requests  
			var newIdentity = new ClaimsIdentity ( context.Ticket.Identity );
			// newIdentity.AddClaim(new Claim("newClaim", "newValue"));

			var newTicket = new AuthenticationTicket ( newIdentity, context.Ticket.Properties );
			context.Validated ( newTicket );

			return Task.FromResult<object> ( null );
		}
		#endregion

		public static AuthenticationProperties CreateProperties ( string userName, string Nombre, string ApellidoPaterno, string ApellidoMaterno, string Clave, string[] roles = null, int userId = 0 )
		{
			roles = roles ?? new string[] { "Usuario" };

			var x = new
			{
				Id = userId,
				Nombre = Nombre,
				ApellidoPaterno = ApellidoPaterno,
				ApellidoMaterno = ApellidoMaterno,
				Clave = Clave,
				Roles = roles,
				Email = userName
			};


			IDictionary<string, string> data = new Dictionary<string, string> {
				{ "data",  Newtonsoft.Json.JsonConvert.SerializeObject( x) }
			};
			return new AuthenticationProperties ( data );
		}
	}


	public class OAuthCustomRefreshTokenProvider : Microsoft.Owin.Security.Infrastructure.IAuthenticationTokenProvider
	{
		private static System.Collections.Concurrent.ConcurrentDictionary<string, AuthenticationTicket> _refreshTokens = new System.Collections.Concurrent.ConcurrentDictionary<string, AuthenticationTicket> ( );

		#region[CreateAsync]
		public async Task CreateAsync ( Microsoft.Owin.Security.Infrastructure.AuthenticationTokenCreateContext context )
		{
			var guid = Guid.NewGuid ( ).ToString ( );
			/* Copy claims from previous token
             ***********************************/
			var refreshTokenProperties = new AuthenticationProperties ( context.Ticket.Properties.Dictionary )
			{
				IssuedUtc = context.Ticket.Properties.IssuedUtc,
				ExpiresUtc = DateTime.UtcNow.AddHours ( 48 )
			};
			var refreshTokenTicket = await Task.Run ( () => new AuthenticationTicket ( context.Ticket.Identity, refreshTokenProperties ) );

			_refreshTokens.TryAdd ( guid, refreshTokenTicket );

			// consider storing only the hash of the handle  
			context.SetToken ( guid );
		}
		#endregion

		#region[ReceiveAsync]
		public async Task ReceiveAsync ( Microsoft.Owin.Security.Infrastructure.AuthenticationTokenReceiveContext context )
		{

			AuthenticationTicket ticket;
			string header = await Task.Run ( () => context.OwinContext.Request.Headers[ "Authorization" ] );

			if ( _refreshTokens.TryRemove ( context.Token, out ticket ) )
				context.SetTicket ( ticket );
		}
		#endregion

		#region[Create & Receive Synchronous methods]
		public void Create ( Microsoft.Owin.Security.Infrastructure.AuthenticationTokenCreateContext context )
		{
			throw new NotImplementedException ( );
		}
		public void Receive ( Microsoft.Owin.Security.Infrastructure.AuthenticationTokenReceiveContext context )
		{
			throw new NotImplementedException ( );
		}
		#endregion
	}
}