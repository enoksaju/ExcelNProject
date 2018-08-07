using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.StaticFiles;
using Owin;
using System;
using System.IO;
using libProduccionDataBase.Contexto;
using Cotizador.Models;
using Cotizador.Providers;

[assembly: OwinStartup ( typeof ( Cotizador.Startup ) )]
namespace Cotizador
{
	public class Startup
	{
		public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
		public static string PublicClientId { get; private set; }
		public void Configuration ( IAppBuilder app )
		{
			string root = AppDomain.CurrentDomain.BaseDirectory;
			var physicalFileSystem = new PhysicalFileSystem ( Path.Combine ( root, "wwwroot" ) );
			var options = new FileServerOptions
			{
				RequestPath = PathString.Empty,
				EnableDefaultFiles = true,
				FileSystem = physicalFileSystem
			};


			options.StaticFileOptions.FileSystem = physicalFileSystem;
			options.StaticFileOptions.ServeUnknownFileTypes = false;


			app.UseFileServer ( options );
			this.ConfigureAuth ( app );
		}

		public void ConfigureAuth ( IAppBuilder app )
		{
			app.CreatePerOwinContext( DataBaseContexto.Create);

			app.CreatePerOwinContext<ApplicationUserManager> ( ApplicationUserManager.Create );
			app.CreatePerOwinContext<ApplicationRoleManager> ( ApplicationRoleManager.Create );

			app.UseCookieAuthentication ( new CookieAuthenticationOptions ( ) );
			app.UseExternalSignInCookie ( DefaultAuthenticationTypes.ExternalCookie );

			// Configure la aplicación para el flujo basado en OAuth
			PublicClientId = "self";
			OAuthOptions = new OAuthAuthorizationServerOptions
			{
				TokenEndpointPath = new PathString ( "/Token" ),
				Provider = new ApplicationOAuthProvider ( PublicClientId ),
				AuthorizeEndpointPath = new PathString ( "/api/Account/ExternalLogin" ),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays ( 1 ),
				// En el modo de producción establezca AllowInsecureHttp = false
				AllowInsecureHttp = true
			};

			// Permitir que la aplicación use tokens portadores para autenticar usuarios
			app.UseOAuthBearerTokens ( OAuthOptions );

		}
	}
}