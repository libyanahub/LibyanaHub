using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Models.Coach;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibyanaHub.Services.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize] // Protecting all endpoints in this controller
	public class CoachController : ControllerBase
	{
		private readonly IUnitOfServices _unitOfServices;
		protected ResponseDto _response;

		public CoachController(IUnitOfServices unitOfServices)
		{
			_unitOfServices = unitOfServices;
			_response = new();
		}

		[HttpGet("GetCoach")]
		public async Task<IActionResult> Get(Guid coachId)
		{
			try
			{
				var response = await _unitOfServices.CoachService.GetByIdAsync(coachId);
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

		[HttpGet("GetAllCoaches")]
		public async Task<IActionResult> GetAll([FromQuery] PaginatedModel paginatedModel)
		{
			try
			{
				var response = await _unitOfServices.CoachService.GetAllAsync(paginatedModel);
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

		[HttpPost("CreateCoach")]
		public async Task<IActionResult> Create([FromBody] Input inputCoach)
		{
			try
			{
				var response = await _unitOfServices.CoachService.AddAsync(inputCoach);
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

		[HttpPut("UpdateCoach")]
		public async Task<IActionResult> Update([FromBody] Input updateCoach)
		{
			try
			{
				var response = await _unitOfServices.CoachService.UpdateAsync(updateCoach);
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

		[HttpDelete("DeleteCoach")]
		public async Task<IActionResult> Delete(Guid coachId)
		{
			try
			{
				var response = await _unitOfServices.CoachService.DeleteAsync(coachId);
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