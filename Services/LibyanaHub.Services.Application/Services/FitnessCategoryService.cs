using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Domain.Entities;
using LibyanaHub.Services.Infrastructure.IRepository;
using LibyanaHub.Services.Models.FitnessCategory;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.User;
using Mapster;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LibyanaHub.Services.Application.Services
{
	public class FitnessCategoryService : IFitnessCategoryService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		private readonly IDbUnitOfWork _unitOfWork;

		protected ResponseDto _response;

		public FitnessCategoryService(IDbUnitOfWork unitOfWork, IUnitOfServices unitOfServices, IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_unitOfWork = unitOfWork;
			_response = new();
		}

		public async Task<ResponseDto> GetAllAsync(PaginatedModel paginatedModel)
		{
			try
			{
				IEnumerable<FitnessCategory> fitnessCategories;

				if (paginatedModel.Value == null || String.IsNullOrEmpty(paginatedModel.Value.Replace(" ", "")))
				{
					fitnessCategories = await _unitOfWork.FitnessCategory.GetAll(PageSize: paginatedModel.PageSize, PageNumber: paginatedModel.PageNumber);

				}
				else
				{

					fitnessCategories = await _unitOfWork.FitnessCategory.GetAll(f => f.Name.Contains(paginatedModel.Value), PageSize: paginatedModel.PageSize, PageNumber: paginatedModel.PageNumber);
				}

				_response.Result = fitnessCategories;

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

		public async Task<ResponseDto> GetByIdAsync(Guid fitnessCat_Id)
		{
			try
			{
				if (fitnessCat_Id == null)
				{
					_response.IsSuccess = false;
					_response.Message = "not found";
					return _response;
				}

				FitnessCategory fitnessCat = await _unitOfWork.FitnessCategory.GetFirstOrDefault(c => c.Id == fitnessCat_Id);

				if (fitnessCat == null)
				{
					_response.IsSuccess = false;
					_response.Message = "not Exist";
					return _response;
				}

				_response.Result = fitnessCat;

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

		public async Task<ResponseDto> AddAsync(Input fitness_Cat)
		{
			fitness_Cat.Id = new();

			Guid.TryParse(_httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid userId);

			try
			{
				if (fitness_Cat == null)
				{
					_response.IsSuccess = false;
					_response.Message = "no Course inserted";
					return _response;
				}

				if (await _unitOfWork.FitnessCategory.IsCheckDuplicateAsync
					(c => c.Name.ToLower() == fitness_Cat.Name.ToLower()))
				{
					_response.IsSuccess = false;
					_response.Message = "This Category Title Existed";
					return _response;
				}

				FitnessCategory Fitness_Cat = fitness_Cat.Adapt<FitnessCategory>();

				Fitness_Cat.UserId = userId;
				Fitness_Cat.SetCreated();

				bool b = await _unitOfWork.FitnessCategory.Add(Fitness_Cat);

				_response.Result = Fitness_Cat.Adapt<Output>();

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

		public async Task<ResponseDto> UpdateAsync(Input fitness_CatNew)
		{
			try
			{
				if (fitness_CatNew == null)
				{
					_response.IsSuccess = false;
					_response.Message = "no Course inserted";
					return _response;
				}

				if (await _unitOfWork.Course.IsCheckDuplicateAsync(c => c.Title.ToLower() == fitness_CatNew.Name.ToLower()))
				{
					_response.IsSuccess = false;
					_response.Message = "This Course Title Existed";
					return _response;
				}




				FitnessCategory fitness_CatUpdated = await _unitOfWork.FitnessCategory.GetFirstOrDefault(c => c.Id == fitness_CatNew.Id);

				//
				fitness_CatUpdated.Name = fitness_CatNew.Name;
				fitness_CatUpdated.Description = fitness_CatNew.Description;
				fitness_CatUpdated.IconUrl = fitness_CatNew.IconUrl;
				fitness_CatUpdated.ImageUrl = fitness_CatNew.ImageUrl;

				fitness_CatUpdated.SetUpdated();

				await _unitOfWork.FitnessCategory.Update(fitness_CatUpdated);

				_response.Result = fitness_CatUpdated.Adapt<Output>();

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

		public async Task<ResponseDto> DeleteAsync(Guid fitnessCat_Id)
		{
			try
			{
				if (fitnessCat_Id == null)
				{
					_response.IsSuccess = false;
					_response.Message = "not found";
					return _response;
				}

				FitnessCategory fitnessCat = await _unitOfWork.FitnessCategory.GetFirstOrDefault(c => c.Id == fitnessCat_Id);

				await _unitOfWork.FitnessCategory.Remove(fitnessCat);

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