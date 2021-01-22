using Microsoft.AspNetCore.Components;

namespace WappExcelNobleza.Shared
{
	public class RedirectToLogin : ComponentBase
	{
		[Inject]
		protected NavigationManager NavigationManager { get; set; }

		protected override void OnInitialized()
		{
			NavigationManager.NavigateTo("/Identity/Account/Login");
            StateHasChanged();
		}
	}
}
