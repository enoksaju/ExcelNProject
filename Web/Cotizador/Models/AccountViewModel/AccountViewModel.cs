using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cotizador.Models.AccountViewModel
{
	public class ExternalLoginViewModel
	{
		public string Name { get; set; }

		public string Url { get; set; }

		public string State { get; set; }
	}
	public class BasicInfoUser
	{
		public string Nombre { get; set; }
		public string Email { get; set; }
		public bool EmailConfirmed { get; set; }
		public int Id { get; set; }
		public List<string> Roles { get; set; } = new List<string> ( );
	}
	public class UserInfoViewModel
	{
		public string Email { get; set; }
		public bool HasRegistered { get; set; }
		public string LoginProvider { get; set; }
	}

}