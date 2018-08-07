using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Cotizador.Models;
using libProduccionDataBase.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Cotizador.Controllers
{
	public class ServicesController : Controller
	{
		private Models.ApplicationUserManager _userManager;
		public Models.ApplicationUserManager UserManager
		{
			get { return _userManager ?? Request.GetOwinContext ( ).GetUserManager<Models.ApplicationUserManager> ( ); }
			private set { _userManager = value; }
		}

		[AllowAnonymous]
		public async Task<ActionResult> ConfirmEmail ( int Token = 0, string Email = "" )
		{
			ApplicationUser user = this.UserManager.FindById ( Token );
			if ( user != null )
			{
				if ( user.Email == Email )
				{
					user.EmailConfirmed = true;
					await UserManager.UpdateAsync ( user );
					return View ( );
				}
			}
			//return View ( );
			return RedirectToAction ( "ConfirmationError", "Services", new { Email = Email } );
		}
		[AllowAnonymous]
		public ActionResult ConfirmationError ( string Email = "" )
		{
			return View ( );
		}
	}
}