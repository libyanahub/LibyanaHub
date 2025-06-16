using LibyanaHub.Services.Models.Coach;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.User;

namespace LibyanaHub.Services.Application.IServices
{
	public interface ICoachService
	{
		Task<ResponseDto> GetAllAsync(PaginatedModel paginatedModel);
		Task<ResponseDto> GetByIdAsync(Guid coachId);
		Task<ResponseDto> AddAsync(Input coach);
		Task<ResponseDto> UpdateAsync(Input coach);
		Task<ResponseDto> DeleteAsync(Guid coachId);
	}
}
