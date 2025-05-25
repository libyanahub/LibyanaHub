using Mango.Services.AuthAPI.Models.Dtos;

namespace LibyanaHub.Services.Application.IServices
{
	public interface IAuthService
	{
		Task<string> Register(RegistrationRequestDto registrationRequestDto);
		Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
		Task<bool> AssignRole(string email, string roleName);
	}
}
