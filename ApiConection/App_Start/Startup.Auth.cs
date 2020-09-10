﻿using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ApiConection.Providers;
using libProduccionDataBase.Contexto;


namespace ApiConection
{
	public partial class Startup
	{
		public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
		public static string PublicClientId { get; private set; }

		// Para obtener más información para configurar la autenticación, visite http://go.microsoft.com/fwlink/?LinkId=301864
		public void ConfigureAuth ( IAppBuilder app )
		{
			// Configure el contexto de base de datos y el administrador de usuarios para usar una única instancia por solicitud
			// app.CreatePerOwinContext( libProduccionDataBase.Contexto.DataBaseContexto.Create);
			// app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);


			app.CreatePerOwinContext ( () => { return DataBaseContexto.Create ( ); } );

			app.CreatePerOwinContext<ApplicationUserManager> ( ApplicationUserManager.Create );
			app.CreatePerOwinContext<ApplicationRoleManager> ( ApplicationRoleManager.Create );

			// Permitir que la aplicación use una cookie para almacenar información para el usuario que inicia sesión
			// y una cookie para almacenar temporalmente información sobre un usuario que inicia sesión con un proveedor de inicio de sesión de terceros
			app.UseCookieAuthentication ( new CookieAuthenticationOptions ( ) );
			app.UseExternalSignInCookie ( DefaultAuthenticationTypes.ExternalCookie );

			// Configure la aplicación para el flujo basado en OAuth
			PublicClientId = "self";

			OAuthOptions = new OAuthAuthorizationServerOptions
			{
				TokenEndpointPath = new PathString ( "/Token" ),
				Provider = new ApplicationOAuthProvider ( PublicClientId ),
				AuthorizeEndpointPath = new PathString ( "/api/Account/ExternalLogin" ),
				AccessTokenExpireTimeSpan = TimeSpan.FromHours(24),
				// En el modo de producción establezca AllowInsecureHttp = false
				AllowInsecureHttp = true,
				RefreshTokenProvider = new OAuthCustomRefreshTokenProvider()

			};

			// Permitir que la aplicación use tokens portadores para autenticar usuarios
			app.UseOAuthBearerTokens ( OAuthOptions );

			// Quitar los comentarios de las siguientes líneas para habilitar el inicio de sesión con proveedores de inicio de sesión de terceros

			//app.UseMicrosoftAccountAuthentication(
			//    clientId: "",
			//    clientSecret: "");

			//app.UseTwitterAuthentication(
			//    consumerKey: "",
			//    consumerSecret: "");

			//app.UseFacebookAuthentication(
			//    appId: "",
			//    appSecret: "");

			//app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
			//{
			//    ClientId = "",
			//    ClientSecret = ""
			//});
		}
	}	
}
