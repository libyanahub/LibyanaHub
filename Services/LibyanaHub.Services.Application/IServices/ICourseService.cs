using LibyanaHub.Services.Domain.Entities;
using LibyanaHub.Services.Models.Course;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Application.IServices
{
	public interface ICourseService
	{
		Task<ResponseDto> GetAllCoursesAsync(PaginatedModel paginatedModel);

		Task<ResponseDto> GetCourseByIdAsync(Guid courseId);

		Task<ResponseDto> AddCourseAsync(Input course);

		Task<ResponseDto> UpdateCourseAsync(Input course);

		Task<ResponseDto> DeleteCourseAsync(Guid courseId);
	}
}
