using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Domain.Entities;
using LibyanaHub.Services.Infrastructure.IRepository;
using LibyanaHub.Services.Models.Coach;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.User;
using Mapster;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LibyanaHub.Services.Application.Services
{
	public class CoachService : ICoachService
	{
		private readonly IDbUnitOfWork _unitOfWork;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public CoachService(IDbUnitOfWork unitOfWork, IUnitOfServices unitOfServices, IHttpContextAccessor httpContextAccessor)
		{
			_unitOfWork = unitOfWork;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<ResponseDto> AddAsync(Input coachInput)
		{
			var response = new ResponseDto();
			try
			{
				if (await _unitOfWork.Coach.IsCheckDuplicateAsync(c => c.ApplicationUserId == coachInput.ApplicationUserId))
				{
					response.IsSuccess = false;
					response.Message = "This user already has a coach profile.";
					return response;
				}

				Guid.TryParse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid creatorId);

				Coach coach = coachInput.Adapt<Coach>();
				coach.UserId = creatorId;
				coach.SetCreated();

				await _unitOfWork.Coach.Add(coach);

				response.Result = coach.Adapt<Output>();
				return response;
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseDto> UpdateAsync(Input coachInput)
		{
			var response = new ResponseDto();
			try
			{
				var existingCoach = await _unitOfWork.Coach.GetFirstOrDefault(c => c.Id == coachInput.Id);
				if (existingCoach == null)
				{
					response.IsSuccess = false;
					response.Message = "Coach profile not found.";
					return response;
				}

				existingCoach.PassportNumber = coachInput.PassportNumber;
				existingCoach.NationalId = coachInput.NationalId;
				existingCoach.SelfieImageUrl = coachInput.SelfieImageUrl;
				existingCoach.IntroVideoUrl = coachInput.IntroVideoUrl;
				existingCoach.Bio = coachInput.Bio;
				existingCoach.SetUpdated();

				await _unitOfWork.Coach.Update(existingCoach);

				response.Result = existingCoach.Adapt<Output>();
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
				var coaches = await _unitOfWork.Coach.GetAll(PageSize: paginatedModel.PageSize, PageNumber: paginatedModel.PageNumber);
				response.Result = coaches.Adapt<IEnumerable<Output>>();
				return response;
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseDto> GetByIdAsync(Guid coachId)
		{
			var response = new ResponseDto();
			try
			{
				var coach = await _unitOfWork.Coach.GetFirstOrDefault(c => c.Id == coachId);
				if (coach == null)
				{
					response.IsSuccess = false;
					response.Message = "Coach not found.";
					return response;
				}
				response.Result = coach.Adapt<Output>();
				return response;
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseDto> DeleteAsync(Guid coachId)
		{
			var response = new ResponseDto();
			try
			{
				var coach = await _unitOfWork.Coach.GetFirstOrDefault(c => c.Id == coachId);
				if (coach == null)
				{
					response.IsSuccess = false;
					response.Message = "Coach not found.";
					return response;
				}

				await _unitOfWork.Coach.Remove(coach);
				response.Message = "Coach profile deleted successfully.";
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