using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Domain.Entities;
using LibyanaHub.Services.Infrastructure.IRepository;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.Trainee;
using LibyanaHub.Services.Models.User;
using Mapster;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LibyanaHub.Services.Application.Services
{
	public class TraineeService : ITraineeService
	{
		private readonly IDbUnitOfWork _unitOfWork;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public TraineeService(IDbUnitOfWork unitOfWork, IUnitOfServices unitOfServices, IHttpContextAccessor httpContextAccessor)
		{
			_unitOfWork = unitOfWork;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<ResponseDto> AddAsync(Input traineeInput)
		{
			var response = new ResponseDto();
			try
			{
				if (await _unitOfWork.Trainee.IsCheckDuplicateAsync(t => t.ApplicationUserId == traineeInput.ApplicationUserId))
				{
					response.IsSuccess = false;
					response.Message = "This user already has a trainee profile.";
					return response;
				}

				Guid.TryParse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid creatorId);

				Trainee trainee = traineeInput.Adapt<Trainee>();
				trainee.UserId = creatorId;
				trainee.SetCreated();

				await _unitOfWork.Trainee.Add(trainee);

				response.Result = trainee.Adapt<Output>();
				return response;
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseDto> UpdateAsync(Input traineeInput)
		{
			var response = new ResponseDto();
			try
			{
				var existingTrainee = await _unitOfWork.Trainee.GetFirstOrDefault(t => t.Id == traineeInput.Id);
				if (existingTrainee == null)
				{
					response.IsSuccess = false;
					response.Message = "Trainee profile not found.";
					return response;
				}

				existingTrainee.SetUpdated();

				await _unitOfWork.Trainee.Update(existingTrainee);

				response.Result = existingTrainee.Adapt<Output>();
				return response;
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseDto> GetAllAsync(PaginatedModel paginatedModel)
		{
			var response = new ResponseDto();
			try
			{
				var trainees = await _unitOfWork.Trainee.GetAll(PageSize: paginatedModel.PageSize, PageNumber: paginatedModel.PageNumber);
				response.Result = trainees.Adapt<IEnumerable<Output>>();
				return response;
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseDto> GetByIdAsync(Guid traineeId)
		{
			var response = new ResponseDto();
			try
			{
				var trainee = await _unitOfWork.Trainee.GetFirstOrDefault(t => t.Id == traineeId);
				if (trainee == null)
				{
					response.IsSuccess = false;
					response.Message = "Trainee not found.";
					return response;
				}
				response.Result = trainee.Adapt<Output>();
				return response;
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseDto> DeleteAsync(Guid traineeId)
		{
			var response = new ResponseDto();
			try
			{
				var trainee = await _unitOfWork.Trainee.GetFirstOrDefault(t => t.Id == traineeId);
				if (trainee == null)
				{
					response.IsSuccess = false;
					response.Message = "Trainee not found.";
					return response;
				}

				await _unitOfWork.Trainee.Remove(trainee);
				response.Message = "Trainee profile deleted successfully.";
				return response;
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
				return response;
			}
		}
	}
}