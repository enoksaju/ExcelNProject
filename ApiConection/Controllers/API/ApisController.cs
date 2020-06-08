using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using libProduccionDataBase.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace ApiConection.Controllers.API
{

	[RoutePrefix ( "api" )]
	public partial class ApisController : ApiController
    {
		private ApplicationUserManager _userManager;
		private libProduccionDataBase.Contexto.DataBaseContexto DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );
		public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; }

		private const string SUCCESS_INSERT_MESSAGE = "Se inserto correctamente el elemento:";
		private const string SUCCESS_UPDATE_MESSAGE = "Se actualizó correctamente el elemento:";
		private const string SUCCESS_DELETE_MESSAGE = "Se Eliminó correctamente el elemento:";
		private const string NOT_VALID_ENTITY = "La entidad solicitada no es valida:";

		public ApplicationUserManager UserManager
		{
			get { return _userManager ?? Request.GetOwinContext ( ).GetUserManager<ApplicationUserManager> ( ); }
			private set { _userManager = value; }
		}

		public ApisController ()
		{
			UserManager = new ApplicationUserManager ( new ApplicationUserStore ( DB ) );

		//	DB.Database.Log = (d)=> System.Diagnostics.Debug.WriteLine(d);
		}

		public ApisController ( ApplicationUserManager userManager, ISecureDataFormat<AuthenticationTicket> accessTokenFormat )
		{
			UserManager = userManager;
			AccessTokenFormat = accessTokenFormat;
		}
	}
}
