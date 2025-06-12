using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Domain.Entities.Identity;
using LibyanaHub.Services.Infrastructure.IRepository;
using LibyanaHub.Shared.StaticData;
using LibyanaHub.Services.Models.User;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace LibyanaHub.Services.Application.Services
{
	public class AuthService : IAuthService
	{
		private readonly IDbUnitOfWork _unitOfWork;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole<Guid>> _roleManager;
		private readonly IJwtTokenGenerator _jwtTokenGenerator;

		public AuthService(
			IDbUnitOfWork unitOfWork,
			IJwtTokenGenerator jwtTokenGenerator,
			UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole<Guid>> roleManager)
		{
			_unitOfWork = unitOfWork;
			_jwtTokenGenerator = jwtTokenGenerator;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task<bool> ChangeRole(string email, string roleName)
		{
			var user = await _unitOfWork.ApplicationUser
				.GetFirstOrDefault(u => u.Email.ToLower() == email.ToLower());
			if (user == null) return false;

			if (!await _roleManager.RoleExistsAsync(roleName))
			{
				var role = new IdentityRole<Guid>(roleName)
				{
					Id = Guid.NewGuid(),
					NormalizedName = roleName.ToUpperInvariant()
				};
				await _roleManager.CreateAsync(role);
			}

			await _userManager.AddToRoleAsync(user, roleName);
			return true;
		}

		public async Task<bool> AssignRole(string phoneNumber, string roleName)
		{
			var user = await _unitOfWork.ApplicationUser
				.GetFirstOrDefault(u => u.UserName.ToLower() == phoneNumber.ToLower());
			if (user == null) return false;

			roleName = CultureInfo.CurrentCulture.TextInfo
				.ToTitleCase(roleName.ToLower());

			if (!await _roleManager.RoleExistsAsync(roleName))
			{
				var role = new IdentityRole<Guid>(roleName)
				{
					Id = Guid.NewGuid(),
					NormalizedName = roleName.ToUpperInvariant()
				};
				await _roleManager.CreateAsync(role);
			}

			await _userManager.AddToRoleAsync(user, roleName);
			return true;
		}

		public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
		{
			var user = await _unitOfWork.ApplicationUser
				.GetFirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

			var isValid = user != null
					   && await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

			if (!isValid)
				return new LoginResponseDto { User = null, Token = "" };

			var roles = await _userManager.GetRolesAsync(user);
			var token = _jwtTokenGenerator.GenerateToken(user, roles);

			var userDto = new UserDto
			{
				ID = user.Id,
				Email = user.Email,
				Name = user.Name,
				PhoneNumber = user.PhoneNumber
			};

			return new LoginResponseDto { User = userDto, Token = token };
		}

		public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
		{
			var user = new ApplicationUser
			{
				UserName = registrationRequestDto.PhoneNumber,
				Email = registrationRequestDto.Email,
				NormalizedEmail = registrationRequestDto.Email.ToUpperInvariant(),
				Name = registrationRequestDto.Name,
				PhoneNumber = registrationRequestDto.PhoneNumber
			};

			var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
			if (!result.Succeeded)
				return result.Errors.First().Description;

			// Immediately assign Trainee role
			await _userManager.AddToRoleAsync(user, SD.Roles.Trainee);
			return string.Empty;
		}
	}
}
