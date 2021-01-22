using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using WappExcelNobleza.Data.Models.Identity;

namespace ExcelNoblezaBlazor.Areas.Identity.Pages.Account.Manage
{
	public class GenerateRecoveryCodesModel : PageModel
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ILogger<GenerateRecoveryCodesModel> _logger;

		public GenerateRecoveryCodesModel(
			UserManager<ApplicationUser> userManager,
			ILogger<GenerateRecoveryCodesModel> logger)
		{
			_userManager = userManager;
			_logger = logger;
		}

		[TempData]
		public string[] RecoveryCodes { get; set; }

		[TempData]
		public string StatusMessage { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound($"No se pudo cargar el usuario con ID '{_userManager.GetUserId(User)}'.");
			}

			var isTwoFactorEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
			if (!isTwoFactorEnabled)
			{
				var userId = await _userManager.GetUserIdAsync(user);
				throw new InvalidOperationException($"No se pueden generar códigos de recuperación para el usuario con ID '{userId}' because they do not have 2FA enabled.");
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound($"No se pudo cargar el usuario con ID '{_userManager.GetUserId(User)}'.");
			}

			var isTwoFactorEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
			var userId = await _userManager.GetUserIdAsync(user);
			if (!isTwoFactorEnabled)
			{
				throw new InvalidOperationException($"No se pueden generar códigos de recuperación para el usuario con ID '{userId}' as they do not have 2FA enabled.");
			}

			var recoveryCodes = await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);
			RecoveryCodes = recoveryCodes.ToArray();

			_logger.LogInformation("El usuario con ID '{UserId}' ha generado nuevos códigos de recuperación 2FA.", userId);
			StatusMessage = "Ha generado nuevos códigos de recuperación.";
			return RedirectToPage("./ShowRecoveryCodes");
		}
	}
}