using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace libProduccionDataBase.Identity
{
	public class ApplicationUserManager_: UserManager<ApplicationUser, int>
	{
		public ApplicationUserManager_ ( IUserStore<ApplicationUser, int> store ) : base ( store ) { }

	}
}
