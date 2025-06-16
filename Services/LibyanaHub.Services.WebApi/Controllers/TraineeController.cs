using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Models.Trainee;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibyanaHub.Services.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize]
	public class TraineeController : ControllerBase
	{
		private readonly IUnitOfServices _unitOfServices;
		protected ResponseDto _response;

		public TraineeController(IUnitOfServices unitOfServices)
		{
			_unitOfServices = unitOfServices;
			_response = new();
		}

		[HttpGet("GetTrainee")]
		public async Task<IActionResult> Get(Guid traineeId)
		{
			try
			{
				var response = await _unitOfServices.TraineeService.GetByIdAsync(traineeId);
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

		[HttpGet("GetAllTrainees")]
		public async Task<IActionResult> GetAll([FromQuery] PaginatedModel paginatedModel)
		{
			try
			{
				var response = await _unitOfServices.TraineeService.GetAllAsync(paginatedModel);
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

		[HttpPost("CreateTrainee")]
		public async Task<IActionResult> Create([FromBody] Input inputTrainee)
		{
			try
			{
				var response = await _unitOfServices.TraineeService.AddAsync(inputTrainee);
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

		[HttpPut("UpdateTrainee")]
		public async Task<IActionResult> Update([FromBody] Input updateTrainee)
		{
			try
			{
				var response = await _unitOfServices.TraineeService.UpdateAsync(updateTrainee);
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

		[HttpDelete("DeleteTrainee")]
		public async Task<IActionResult> Delete(Guid traineeId)
		{
			try
			{
				var response = await _unitOfServices.TraineeService.DeleteAsync(traineeId);
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