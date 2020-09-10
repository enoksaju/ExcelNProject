using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ApiConection
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapRoute ( "React", "{*pathInfo}",
				defaults: new { controller = "App", Action = "Index", id = UrlParameter.Optional }
				);

			//routes.MapRoute (
			//	name: "Default",
			//	url: "{controller}/{action}/{id}",
			//	defaults: new { controller = "App", action = "Index", id = UrlParameter.Optional }
			//);
		}
	}
}
