using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Models.UserDomain;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibyanaHub.Services.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize]
	public class UserDomainController : ControllerBase
	{
		private readonly IUnitOfServices _unitOfServices;
		protected ResponseDto _response;

		public UserDomainController(IUnitOfServices unitOfServices)
		{
			_unitOfServices = unitOfServices;
			_response = new();
		}

		[HttpGet("GetUserDomain")]
		public async Task<IActionResult> Get(Guid userDomainId)
		{
			try
			{
				var response = await _unitOfServices.UserDomainService.GetByIdAsync(userDomainId);
				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
				return BadRequest(_response);
			}
		}

		[HttpGet("GetAllUserDomains")]
		public async Task<IActionResult> GetAll([FromQuery] PaginatedModel paginatedModel)
		{
			try
			{
				var response = await _unitOfServices.UserDomainService.GetAllAsync(paginatedModel);
				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
				return BadRequest(_response);
			}
		}

		[HttpPost("CreateUserDomain")]
		public async Task<IActionResult> Create([FromBody] Input inputUserDomain)
		{
			try
			{
				var response = await _unitOfServices.UserDomainService.AddAsync(inputUserDomain);
				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
				return BadRequest(_response);
			}
		}

		[HttpPut("UpdateUserDomain")]
		public async Task<IActionResult> Update([FromBody] Input updateUserDomain)
		{
			try
			{
				var response = await _unitOfServices.UserDomainService.UpdateAsync(updateUserDomain);
				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
				return BadRequest(_response);
			}
		}

		[HttpDelete("DeleteUserDomain")]
		public async Task<IActionResult> Delete(Guid userDomainId)
		{
			try
			{
				var response = await _unitOfServices.UserDomainService.DeleteAsync(userDomainId);
				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
				return BadRequest(_response);
			}
		}
	}
}