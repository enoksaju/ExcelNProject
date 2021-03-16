﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WappExcelNobleza.Data.Models.Identity;

namespace ExcelNoblezaBlazor.Areas.Identity.Pages.Account.Manage
{
	public class Disable2faModel : PageModel
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ILogger<Disable2faModel> _logger;

		public Disable2faModel(
			UserManager<ApplicationUser> userManager,
			ILogger<Disable2faModel> logger)
		{
			_userManager = userManager;
			_logger = logger;
		}

		[TempData]
		public string StatusMessage { get; set; }

		public async Task<IActionResult> OnGet()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound($"No se pudo cargar el usuario con ID '{_userManager.GetUserId(User)}'.");
			}

			if (!await _userManager.GetTwoFactorEnabledAsync(user))
			{
				throw new InvalidOperationException($"No se puede deshabilitar 2FA para el usuario con ID '{_userManager.GetUserId(User)}' as it's not currently enabled.");
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

			var disable2faResult = await _userManager.SetTwoFactorEnabledAsync(user, false);
			if (!disable2faResult.Succeeded)
			{
				throw new InvalidOperationException($"Se produjo un error inesperado al inhabilitar 2FA para el usuario con ID '{_userManager.GetUserId(User)}'.");
			}

			_logger.LogInformation("La usuario con ID '{UserId}' ha deshabilitado 2fa.", _userManager.GetUserId(User));
			StatusMessage = "2fa se ha desactivado. Puede volver a habilitar 2fa cuando configura una aplicación de autenticación";
			return RedirectToPage("./TwoFactorAuthentication");
		}
	}
}