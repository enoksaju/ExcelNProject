
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WappExcelNobleza.Data.Models.Identity;

namespace WappExcelNobleza
{
	public class CustomClaims : IClaimsTransformation
	{
		private readonly UserManager<ApplicationUser> _userStorage;

		public CustomClaims(UserManager<ApplicationUser> userStorage)
		{
			_userStorage = userStorage;
		}

		public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
		{
			try
			{


				var identity = (ClaimsIdentity)principal.Identity;
				var id = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
				if (id != "")
				{
					var user = await _userStorage.FindByIdAsync(id);
					if (user != null)
					{
						identity.AddClaim(new Claim("Nombre", user.Nombre));
						identity.AddClaim(new Claim("Apellidos", user.Apellidos));
						identity.AddClaim(new Claim("ClaveTrabajador", user.ClaveTrabajador));
						identity.AddClaim(new Claim("NombreCompleto", $"{user.Nombre} {user.Apellidos}"));

						if (!identity.HasClaim(u => u.Type == "ImageProfile"))
						{
							identity.AddClaim(new Claim("ImageProfile", "/assets/images/default-avatar.png"));
						}


						identity.AddClaim(new Claim("Area", user.Area ?? "company"));
						identity.AddClaim(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? "0000000000"));
					}
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
			return principal;
		}
	}
}
