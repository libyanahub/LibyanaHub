﻿using LibyanaHub.Services.Domain.Entities;
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
		Task<ResponseDto> GetAllAsync(PaginatedModel paginatedModel);

		Task<ResponseDto> GetByIdAsync(Guid courseId);

		Task<ResponseDto> AddAsync(Input course);

		Task<ResponseDto> UpdateAsync(Input course);

		Task<ResponseDto> DeleteAsync(Guid courseId);
	}
}
