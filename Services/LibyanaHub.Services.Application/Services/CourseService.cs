using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Domain.Entities;
using LibyanaHub.Services.Infrastructure.IRepository;
using LibyanaHub.Services.Models.Course;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.User;
using Mapster;
using System;
using System.Collections.Generic;

namespace LibyanaHub.Services.Application.Services
{
	public class CourseService : ICourseService
	{
		private readonly IDbUnitOfWork _unitOfWork;

		protected ResponseDto _response;

		public CourseService(IDbUnitOfWork unitOfWork, IUnitOfServices unitOfServices)
		{
			_unitOfWork = unitOfWork;
			_response = new();
		}

		public async Task<ResponseDto> GetAllCoursesAsync(PaginatedModel paginatedModel)
		{
			try
			{
				IEnumerable<Course> courses;

				if (paginatedModel.Value == null || String.IsNullOrEmpty(paginatedModel.Value.Replace(" ", "")))
				{
					courses = await _unitOfWork.Course.GetAll(PageSize: paginatedModel.PageSize, PageNumber: paginatedModel.PageNumber);

				}
				else
				{
	
					courses = await _unitOfWork.Course.GetAll(f => f.Title.Contains(paginatedModel.Value), PageSize: paginatedModel.PageSize, PageNumber: paginatedModel.PageNumber);
				}

				_response.Result = courses;

				return _response;
			}
			catch (Exception ex)
			{
				string detail = ex.InnerException.ToString();

				_response.IsSuccess = false;
				_response.Message = ex.Message;

				return _response;
			}
		}

		public async Task<ResponseDto> GetCourseByIdAsync(Guid courseId)
		{
			try
			{
				if (courseId == null)
				{
					_response.IsSuccess = false;
					_response.Message = "not found";
					return _response;
				}

				Course Course = await _unitOfWork.Course.GetFirstOrDefault(c => c.Id == courseId);

				if (Course == null)
				{
					_response.IsSuccess = false;
					_response.Message = "not Exist";
					return _response;
				}

				_response.Result = Course;

				return _response;
			}
			catch (Exception ex)
			{
				string detail = ex.InnerException.ToString();

				_response.IsSuccess = false;
				_response.Message = ex.Message;

				return _response;
			}
		}

		public async Task<ResponseDto> AddCourseAsync(Input course)
		{
			course.Id = new();

			try 
			{
				if (course == null)
				{
					_response.IsSuccess = false;
					_response.Message = "no Course inserted";
					return _response;
				}

				if (await _unitOfWork.Course.IsCheckDuplicateAsync(c => c.Title.ToLower()== course.Title.ToLower()))
				{
					_response.IsSuccess = false;
					_response.Message = "This Course Title Existed";
					return _response;
				}

				if (await _unitOfWork.Course.IsCheckDuplicateAsync(c => c.Description.ToLower() == course.Description.ToLower()))
				{
					_response.IsSuccess = false;
					_response.Message = "This Course Description Existed";
					return _response;
				}

				Course Course = course.Adapt<Course>();

				Course.SetCreated();

				bool b = await _unitOfWork.Course.Add(Course);

				_response.Result = Course.Adapt<Output>();

				return _response;
			}
			catch (Exception ex) 
			{
				string detail = ex.InnerException.ToString();

				_response.IsSuccess = false;
				_response.Message = ex.Message;

				return _response;
			}
		}

		

		public async Task<ResponseDto> UpdateCourseAsync(Input courseNew)
		{
			try
			{
				if (courseNew == null)
				{
					_response.IsSuccess = false;
					_response.Message = "no Course inserted";
					return _response;
				}

				if (await _unitOfWork.Course.IsCheckDuplicateAsync(c => c.Title.ToLower() == courseNew.Title.ToLower()))
				{
					_response.IsSuccess = false;
					_response.Message = "This Course Title Existed";
					return _response;
				}

				if (await _unitOfWork.Course.IsCheckDuplicateAsync(c => c.Description.ToLower() == courseNew.Description.ToLower()))
				{
					_response.IsSuccess = false;
					_response.Message = "This Course Description Existed";
					return _response;
				}

				Course courseUpdated = await _unitOfWork.Course.GetFirstOrDefault(c => c.Id == courseNew.Id);

				//
				courseUpdated.Title = courseNew.Title;
				courseUpdated.Description = courseNew.Description;
				courseUpdated.SetUpdated();

				await _unitOfWork.Course.Update(courseUpdated);

				_response.Result = courseUpdated.Adapt<Output>();

				return _response;
			}
			catch (Exception ex)
			{
				string detail = ex.InnerException.ToString();

				_response.IsSuccess = false;
				_response.Message = ex.Message;

				return _response;
			}
		}

		//

		public async Task<ResponseDto> DeleteCourseAsync(Guid courseId)
		{
			try
			{
				if (courseId == null)
				{
					_response.IsSuccess = false;
					_response.Message = "not found";
					return _response;
				}

				Course Course = await _unitOfWork.Course.GetFirstOrDefault(c => c.Id == courseId);

				_unitOfWork.Course.Remove(Course);

				await _unitOfWork.Course.Save();

				return _response;
			}
			catch (Exception ex)
			{
				string detail = ex.InnerException.ToString();

				_response.IsSuccess = false;
				_response.Message = ex.Message;

				return _response;
			}
		}

	}

}
