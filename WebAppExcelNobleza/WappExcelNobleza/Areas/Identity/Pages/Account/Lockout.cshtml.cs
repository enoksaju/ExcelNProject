using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExcelNoblezaBlazor.Areas.Identity.Pages.Account
{
	[AllowAnonymous]
	public class LockoutModel : PageModel
	{
		public void OnGet()
		{

		}
	}
}
