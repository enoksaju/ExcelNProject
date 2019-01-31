using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiControlAlmacen.Controllers
{
	public class DefaultController : ApiController
	{
		[HttpGet]
		public IHttpActionResult Probe ()
		{
			return Ok ( "La prueba funciona" );
		}
	}

	public class RacksController : ApiController
	{
		[HttpGet]
		public IHttpActionResult Get ()
		{
			return Ok ( new List<Object> { new { ubucacion = 1, rack = 22 }, new { ubicacion = 2, rack = 22 } } );
		}
		[HttpPost]
		public IHttpActionResult Post (Object model)
		{
			return Ok ( model );
		}
	}
}
