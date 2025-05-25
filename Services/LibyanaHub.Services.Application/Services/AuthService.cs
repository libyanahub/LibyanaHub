
using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Domain.Entities.Identity;
using LibyanaHub.Services.Infrastructure.Data;
using LibyanaHub.Services.Infrastructure.IRepository;
using LibyanaHub.Services.Infrastructure.Repository;
using Mango.Services.AuthAPI.Models.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Service
{
	public class AuthService : IAuthService
	{
		private readonly IDbUnitOfWork _unitOfWork;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IJwtTokenGenerator _jwtTokenGenerator;

		public AuthService(IDbUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator,
			UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_unitOfWork = unitOfWork;
			_jwtTokenGenerator = jwtTokenGenerator;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task<bool> AssignRole(string email, string roleName)
		{
			var user = await _unitOfWork.ApplicationUserRepository.GetFirstOrDefault(u => u.Email.ToLower() == email.ToLower());
			if (user != null)
			{
				if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
				{
					//create role if it does not exist
					_roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
				}
				await _userManager.AddToRoleAsync(user, roleName);
				return true;
			}
			return false;

		}

		public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
		{
			var all = await _unitOfWork.ApplicationUserRepository.GetAll();


			var user = await _unitOfWork.ApplicationUserRepository.GetFirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

			bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

			if (user == null || isValid == false)
			{
				return new LoginResponseDto() { User = null, Token = "" };
			}

			//if user was found , Generate JWT Token
			var roles = await _userManager.GetRolesAsync(user);
			var token = _jwtTokenGenerator.GenerateToken(user, roles);

			UserDto userDTO = new()
			{
				Email = user.Email,
				ID = user.Id,
				Name = user.Name,
				PhoneNumber = user.PhoneNumber
			};

			LoginResponseDto loginResponseDto = new LoginResponseDto()
			{
				User = userDTO,
				Token = token
			};

			return loginResponseDto;
		}

		public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
		{
			ApplicationUser user = new()
			{
				UserName = registrationRequestDto.PhoneNumber,
				Email = registrationRequestDto.Email,
				NormalizedEmail = registrationRequestDto.Email.ToUpper(),
				Name = registrationRequestDto.Name,
				PhoneNumber = registrationRequestDto.PhoneNumber
			};

			try
			{
				var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
				if (result.Succeeded)
				{
					var userToReturn = await _unitOfWork.ApplicationUserRepository.GetFirstOrDefault(u => u.UserName == registrationRequestDto.PhoneNumber);

					UserDto userDto = new()
					{
						Email = userToReturn.Email,
						ID = userToReturn.Id,
						Name = userToReturn.Name,
						PhoneNumber = userToReturn.PhoneNumber
					};

					return "";

				}
				else
				{
					return result.Errors.FirstOrDefault().Description;
				}

			}
			catch (Exception ex)
			{
				return ex.Message;
			}
			//return "Error Encountered";
		}
	}
}