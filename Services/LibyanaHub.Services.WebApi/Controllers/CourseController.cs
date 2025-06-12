using Azure;
using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Application.Services;
using LibyanaHub.Services.Models.Course;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace LibyanaHub.Services.WebApi.Controllers
{
	public class CourseController : Controller
	{
		private readonly IUnitOfServices _unitOfServices;

		protected ResponseDto _response;

		public CourseController(IUnitOfServices unitOfServices)
		{
			_unitOfServices = unitOfServices;
			_response = new();
		}

		[HttpGet("GetCourse")]
		public async Task<IActionResult> GetCourse(Guid courseID)
		{
			try
			{
				var response = await _unitOfServices.CourseService.GetCourseByIdAsync(courseID);

				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetAllCourses")]
		public async Task<IActionResult> GetAllCourses(PaginatedModel paginatedModel)
		{
			try
			{
				var response = await _unitOfServices.CourseService.GetAllCoursesAsync(paginatedModel);

				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create([FromBody] Input inputCourse)
		{
			try
			{
				var response = await _unitOfServices.CourseService.AddCourseAsync(inputCourse);

				if (response.IsSuccess)
					return Ok(response);	
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


		[HttpPut("Update")]
		public async Task<IActionResult> Update([FromBody] Input updateCourse)
		{
			try
			{
				var response = await _unitOfServices.CourseService.UpdateCourseAsync(updateCourse);

				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("Delete")]
		public async Task<IActionResult> DeleteCourse(Guid courseID)
		{
			try
			{
				var response = await _unitOfServices.CourseService.DeleteCourseAsync(courseID);

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
