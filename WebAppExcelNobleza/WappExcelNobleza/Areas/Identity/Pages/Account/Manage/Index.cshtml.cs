using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WappExcelNobleza.Data.Models.Identity;

namespace ExcelNoblezaBlazor.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _environment;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _environment = environment;
        }

        [Display(Name = "Login Name")]
        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Número de Teléfono")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido")]
            [Display(Name = "Nombre")]
            public string Nombre { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido")]
            [Display(Name = "Apellido(s)")]
            public string Apellidos { get; set; }

            [BindProperty]
            [Display(Name = "Imagen de Perfil")]
            public Microsoft.AspNetCore.Http.IFormFile Upload { get; set; }


            public string PathImageProfile { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var claim = (await _userManager.GetClaimsAsync(user)).FirstOrDefault(u => u.Type == "ImageProfile");

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Nombre = user.Nombre,
                Apellidos = user.Apellidos,
                PathImageProfile = claim != null ? claim.Value : $"/assets/images/default-avatar.png"
            };


        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"No se puede cargar el usuario con ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"No se puede cargar el usuario con ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Error inesperado al intentar cambiar el Número de Teléfono.";
                    return RedirectToPage();
                }
            }

            if (Input.Nombre != user.Nombre)
            {
                user.Nombre = Input.Nombre;
                var setNombre = await _userManager.UpdateAsync(user);
                if (!setNombre.Succeeded)
                {
                    StatusMessage = "Error inesperado al intentar cambiar el Nombre.";
                    return RedirectToPage();
                }
            }

            if (Input.Apellidos != user.Apellidos)
            {
                user.Apellidos = Input.Apellidos;
                var setApellidos = await _userManager.UpdateAsync(user);
                if (!setApellidos.Succeeded)
                {
                    StatusMessage = "Error inesperado al intentar cambiar los Apellidos.";
                    return RedirectToPage();
                }
            }

            if (Input.Upload != null)
            {
                System.IO.Directory.CreateDirectory(Path.Combine(_environment.ContentRootPath, "wwwroot\\uploads", user.ClaveTrabajador));
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot\\uploads", user.ClaveTrabajador, Input.Upload.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Input.Upload.CopyToAsync(fileStream);
                }

                if (_userManager.SupportsUserClaim)
                {
                    var claim = (await _userManager.GetClaimsAsync(user)).FirstOrDefault(u => u.Type == "ImageProfile");
                    if (claim != null) await _userManager.RemoveClaimAsync(user, claim);

                    await _userManager.AddClaimAsync(user, new Claim("ImageProfile", $"/uploads/{user.ClaveTrabajador}/{ Input.Upload.FileName}"));

                }


            }


            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Su perfil ha sido actualizado";
            return RedirectToPage();
        }
    }
}
