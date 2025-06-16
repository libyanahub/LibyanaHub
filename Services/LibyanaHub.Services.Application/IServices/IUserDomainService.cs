using LibyanaHub.Services.Domain.Entities;
using LibyanaHub.Services.Models.UserDomain;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Application.IServices
{
	public interface IUserDomainService
	{
		Task<ResponseDto> GetAllAsync(PaginatedModel paginatedModel);
		Task<ResponseDto> GetByIdAsync(Guid userDomainId);
		Task<ResponseDto> AddAsync(Input userDomain);
		Task<ResponseDto> UpdateAsync(Input userDomain);
		Task<ResponseDto> DeleteAsync(Guid userDomainId);
	}
}