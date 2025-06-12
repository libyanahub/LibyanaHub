using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace LibyanaHub.Services.WebApi.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthAPIController : ControllerBase
	{
		private readonly IUnitOfServices _unitOfServices;

		protected ResponseDto _response;
		public AuthAPIController(IUnitOfServices unitOfServices)
		{
			_unitOfServices = unitOfServices;
			_response = new();
		}



		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
		{
			try
			{
				var errorMessage = await _unitOfServices.AuthService.Register(model);
				if (!string.IsNullOrEmpty(errorMessage))
				{
					_response.IsSuccess = false;
					_response.Message = errorMessage;
					return BadRequest(_response);
				}
				return Ok(_response);


			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
		{
			try
			{
				var loginResponse = await _unitOfServices.AuthService.Login(model);
				if (loginResponse.User == null)
				{
					_response.IsSuccess = false;
					_response.Message = "Username or password is incorrect";
					return BadRequest(_response);
				}
				_response.Result = loginResponse;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("AssignRole")]
		public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
		{
			var assignRoleSuccessful = await _unitOfServices.AuthService.AssignRole(model.Email, model.Role.ToUpper());
			if (!assignRoleSuccessful)
			{
				_response.IsSuccess = false;
				_response.Message = "Error encountered";
				return BadRequest(_response);
			}
			return Ok(_response);
		}
	}
}

