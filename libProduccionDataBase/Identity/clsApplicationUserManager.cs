using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Identity
{
    public class ApplicationUserManager_ : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManager_( IUserStore<ApplicationUser, int> store ) : base( store )
        {

            // this.UserValidator = new CustomUserValidator<ApplicationUser>(this);           
        }
    }        
}
