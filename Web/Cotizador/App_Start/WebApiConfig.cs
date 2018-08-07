using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

namespace Cotizador
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			// Configuración y servicios de API web
			config.Formatters.XmlFormatter.SupportedMediaTypes.Clear ( );
			config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
			config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;


			// Configure Web API para usar solo la autenticación de token de portador.
			config.SuppressDefaultHostAuthentication ( );
			config.Filters.Add ( new HostAuthenticationFilter ( OAuthDefaults.AuthenticationType ) );


			// Rutas de API web
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
