using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Owin.Security.OAuth;

namespace ApiConection
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters ( GlobalFilterCollection filters )
		{
			filters.Add ( new HandleErrorAttribute ( ) );
		
		
		}
	}
}
