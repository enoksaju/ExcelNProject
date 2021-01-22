using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WappExcelNobleza.Data.Models.Identity;
namespace ExcelNoblezaBlazor.Areas.Identity.Pages.Account.Manage
{
	public class ChangePasswordModel : PageModel
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ILogger<ChangePasswordModel> _logger;

		public ChangePasswordModel(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			ILogger<ChangePasswordModel> logger)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_logger = logger;
		}

		[BindProperty]
		public InputModel Input { get; set; }

		[TempData]
		public string StatusMessage { get; set; }

		public class InputModel
		{
			[Required(ErrorMessage = "El campo {0} es requerido")]
			[DataType(DataType.Password)]
			[Display(Name = "Contraseña Actual")]
			public string OldPassword { get; set; }

			[Required(ErrorMessage = "El campo {0} es requerido")]
			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			[DataType(DataType.Password)]
			[Display(Name = "Contraseña Nueva")]
			public string NewPassword { get; set; }

			[DataType(DataType.Password)]
			[Display(Name = "Confirme la Nueva Contraseña")]
			[Compare("NewPassword", ErrorMessage = "No coincide con la Contraseña.")]
			public string ConfirmPassword { get; set; }
		}

		public async Task<IActionResult> OnGetAsync()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound($"No se puede cargar el usuario con ID '{_userManager.GetUserId(User)}'.");
			}

			var hasPassword = await _userManager.HasPasswordAsync(user);
			if (!hasPassword)
			{
				return RedirectToPage("./SetPassword");
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound($"No se puede cargar el usuario con ID '{_userManager.GetUserId(User)}'.");
			}

			var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
			if (!changePasswordResult.Succeeded)
			{
				foreach (var error in changePasswordResult.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
				return Page();
			}

			await _signInManager.RefreshSignInAsync(user);
			_logger.LogInformation("El usuario cambio su contraseña correctamente.");
			StatusMessage = "Su contraseña se ha cambiado.";

			return RedirectToPage();
		}
	}
}
