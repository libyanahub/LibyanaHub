using LibyanaHub.Services.Models.Trainee;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Application.IServices
{
	public interface ITraineeService
	{
		Task<ResponseDto> GetAllAsync(PaginatedModel paginatedModel);
		Task<ResponseDto> GetByIdAsync(Guid traineeId);
		Task<ResponseDto> AddAsync(Input trainee);
		Task<ResponseDto> UpdateAsync(Input trainee);
		Task<ResponseDto> DeleteAsync(Guid traineeId);
	}
}