using LibyanaHub.Services.Domain.Entities;
using LibyanaHub.Services.Models.FitnessCategory;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Application.IServices
{
	public interface IFitnessCategoryService
	{
		Task<ResponseDto> GetAllAsync(PaginatedModel paginatedModel);

		Task<ResponseDto> GetByIdAsync(Guid fitnessCat_Id);

		Task<ResponseDto> AddAsync(Input fitness_Cat);

		Task<ResponseDto> UpdateAsync(Input fitness_CatNew);

		Task<ResponseDto> DeleteAsync(Guid fitnessCat_Id);
	}
}
