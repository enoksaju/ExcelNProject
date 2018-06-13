using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http.Description;
using ExcelNoblezaWebApp.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ExcelNoblezaWebApp.Controllers
{
    public class UsuariosController : ApiController
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public UsuariosController() { }
        public UsuariosController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        [Route("api/Usuarios/getAll")]
        [Authorize(Roles = "Admin, Develop")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUsers()
        {
            System.Threading.Thread.Sleep(500);
            using (var db = new ApplicationDbContext())
            {
                var res = new List<UsuarioReturnModel>();
                await db.Users
                    .Include(p => p.Roles)
                    .OrderBy(t => t.UserName)
                    .ForEachAsync(y =>
                {
                    List<string> _roles = new List<string>();

                    y.Roles.ToList().ForEach(r =>
                    {
                        _roles.Add(RoleManager.FindById(r.RoleId).Name);
                    });

                    res.Add(new UsuarioReturnModel(y.UserName, y.Id, y.Email, String.Format("{0} {1} {2}", y.Nombre, y.ApellidoPaterno, y.ApellidoMaterno), _roles.ToArray()));
                });

                return Ok(res);
            }
        }


        [Route("api/Usuarios/roles")]
        [Authorize(Roles = "Admin, Develop")]
        [ResponseType(typeof(roleAction))]
        [HttpPost]
        public IHttpActionResult Role(roleAction rol)
        {
            var message = "";
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (!UserManager.Users.Any(t => t.Id == rol.UserId)) { return BadRequest("Usuario no valido"); }
            if (rol.Role.Trim() == String.Empty) { return BadRequest("Rol invalido"); }

            if (!RoleManager.RoleExists(rol.Role))
            {
                RoleManager.Create(new IdentityRole() { Name = rol.Role });
            }

            switch (rol.Action)
            {
                case 1:
                    if (!UserManager.IsInRole(rol.UserId, rol.Role))
                    {
                        UserManager.AddToRole(rol.UserId, rol.Role);
                        message = "Agregado correctamente";
                    }
                    else
                    {
                        return BadRequest("El usuario ya tiene el Rol indicado");
                    }
                    break;
                case 2:
                    UserManager.RemoveFromRole(rol.UserId, rol.Role);
                    message = "Eliminado correctamente";
                    break;
                default:
                    return BadRequest("Accion no valida");
            }

            return Ok(message);

        }

        [Route("api/Account/user")]
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteUser(string Id)
        {
            if (ModelState.IsValid)
            {
                var t = await UserManager.DeleteAsync(await UserManager.FindByIdAsync(Id));
                if (t.Succeeded)
                {
                    return Ok("Usuario eliminado exitosamente");
                }

                foreach (var error in t.Errors)
                {
                    ModelState.AddModelError("DeleteErrors", error);
                }
            }
            return BadRequest(ModelState);
        }

        [Route("api/Account/user")]
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(RegisterViewModel))]
        [HttpPost]
        public async Task<IHttpActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Nombre = model.Nombre,
                    ApellidoPaterno = model.ApellidoPaterno,
                    ApellidoMaterno = model.ApellidoMaterno
                };

                var result = await UserManager.CreateAsync(user, model.Password);

                if (!RoleManager.RoleExists("User"))
                {
                    RoleManager.Create(new IdentityRole() { Name = "User" });
                } 

                if (result.Succeeded)
                {
                    
                    UserManager.AddToRole(user.Id, "User");
                    return Ok("Usuario Registrado");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("regErrors", error);
                }

            }

            return BadRequest(ModelState);

        }
    }

    public class roleAction
    {
        public string UserId { get; set; }
        public string Role { get; set; }
        public int Action { get; set; }
    }

    public class UsuarioReturnModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public List<string> Roles { get; set; }

        public UsuarioReturnModel(string UserName, string Id, string Email, string FullName, params string[] Roles)
        {
            this.UserName = UserName;
            this.UserId = Id;
            this.Email = Email;
            this.FullName = FullName;
            this.Roles = new List<string>();
            this.Roles.AddRange(Roles);
        }
    }
}
