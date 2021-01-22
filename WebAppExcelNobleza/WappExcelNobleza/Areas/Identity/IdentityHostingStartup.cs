using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(WappExcelNobleza.Areas.Identity.IdentityHostingStartup))]
namespace WappExcelNobleza.Areas.Identity
{
	public class IdentityHostingStartup : IHostingStartup
	{
		public void Configure(IWebHostBuilder builder)
		{
			builder.ConfigureServices((context, services) =>
			{
			});
		}
	}
}