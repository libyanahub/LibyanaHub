using Microsoft.AspNetCore.Identity;

namespace LibyanaHub.Services.Domain.Entities.Identity
{
	public class ApplicationUser : IdentityUser
	{
		public string Name { get; set; }
	}
}
