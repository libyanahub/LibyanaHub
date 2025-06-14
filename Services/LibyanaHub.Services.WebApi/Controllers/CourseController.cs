﻿using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Models.Course;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace LibyanaHub.Services.WebApi.Controllers
{
	public class CourseController : ControllerBase
	{
		private readonly IUnitOfServices _unitOfServices;

		protected ResponseDto _response;

		public CourseController(IUnitOfServices unitOfServices)
		{
			_unitOfServices = unitOfServices;
			_response = new();
		}

		[HttpGet("GetCourse")]
		public async Task<IActionResult> Get(Guid courseID)
		{
			try
			{
				var response = await _unitOfServices.CourseService.GetByIdAsync(courseID);

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
		public async Task<IActionResult> GetAll(PaginatedModel paginatedModel)
		{
			try
			{
				var response = await _unitOfServices.CourseService.GetAllAsync(paginatedModel);

				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("CreateCourse")]
		public async Task<IActionResult> Create([FromBody] Input inputCourse)
		{
			try
			{
				var response = await _unitOfServices.CourseService.AddAsync(inputCourse);

				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


		[HttpPut("UpdateCourse")]
		public async Task<IActionResult> Update([FromBody] Input updateCourse)
		{
			try
			{
				var response = await _unitOfServices.CourseService.UpdateAsync(updateCourse);

				if (response.IsSuccess)
					return Ok(response);
				return BadRequest(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("DeleteCourse")]
		public async Task<IActionResult> Delete(Guid courseID)
		{
			try
			{
				var response = await _unitOfServices.CourseService.DeleteAsync(courseID);

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
