using LibyanaHub.Services.Domain.Entities.Identity;

namespace LibyanaHub.Services.Application.IServices
{
	public interface IJwtTokenGenerator
	{
		string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
	}
}
