using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace LibyanaHub.Services.WebApi.Controllers
{
	public class FitnessCategoryController : ControllerBase
	{
		private readonly IUnitOfServices _unitOfServices;

		protected ResponseDto _response;

		public FitnessCategoryController(IUnitOfServices unitOfServices)
		{
			_unitOfServices = unitOfServices;
			_response = new();
		}

		[HttpGet("GetFitCategory")]
		public async Task<IActionResult> Get(Guid fitnessCat_Id)
		{
			try
			{
				var response = await _unitOfServices.FitnessCategoryService.GetByIdAsync(fitnessCat_Id);

				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetAllFitCategory")]
		public async Task<IActionResult> GetAll(PaginatedModel paginatedModel)
		{
			try
			{
				var response = await _unitOfServices.FitnessCategoryService.GetAllAsync(paginatedModel);

				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("CreateFitnessCategory")]
		public async Task<IActionResult> Create([FromBody] LibyanaHub.Services.Models.FitnessCategory.Input inputFitnessCat)
		{
			try
			{
				var response = await _unitOfServices.FitnessCategoryService.AddAsync(inputFitnessCat);

				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


		[HttpPut("UpdateFitnessCategory")]
		public async Task<IActionResult> Update([FromBody] LibyanaHub.Services.Models.FitnessCategory.Input updateFitnessCat)
		{
			try
			{
				var response = await _unitOfServices.FitnessCategoryService.UpdateAsync(updateFitnessCat);

				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("DeleteFitCategory")]
		public async Task<IActionResult> Delete(Guid fitnessCat_Id)
		{
			try
			{
				var response = await _unitOfServices.FitnessCategoryService.DeleteAsync(fitnessCat_Id);

				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
