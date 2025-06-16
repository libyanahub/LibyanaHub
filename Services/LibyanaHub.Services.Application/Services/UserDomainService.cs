using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Domain.Entities;
using LibyanaHub.Services.Infrastructure.IRepository;
using LibyanaHub.Services.Models.Helper;
using LibyanaHub.Services.Models.User;
using LibyanaHub.Services.Models.UserDomain;
using Mapster;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LibyanaHub.Services.Application.Services
{
	public class UserDomainService : IUserDomainService
	{
		private readonly IDbUnitOfWork _unitOfWork;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserDomainService(IDbUnitOfWork unitOfWork, IUnitOfServices unitOfServices, IHttpContextAccessor httpContextAccessor)
		{
			_unitOfWork = unitOfWork;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<ResponseDto> AddAsync(Input userDomainInput)
		{
			var response = new ResponseDto();
			try
			{
				if (await _unitOfWork.UserDomain.IsCheckDuplicateAsync(ud => ud.ApplicationUserId == userDomainInput.ApplicationUserId && ud.DomainType == userDomainInput.DomainType))
				{
					response.IsSuccess = false;
					response.Message = "An application for this domain already exists for this user.";
					return response;
				}

				Guid.TryParse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid creatorId);

				UserDomain userDomain = userDomainInput.Adapt<UserDomain>();
				userDomain.UserId = creatorId;
				userDomain.AppliedAt = DateTime.UtcNow;
				userDomain.SetCreated();

				await _unitOfWork.UserDomain.Add(userDomain);

				response.Result = userDomain.Adapt<Output>();
				return response;
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseDto> UpdateAsync(Input userDomainInput)
		{
			var response = new ResponseDto();
			try
			{
				var existingDomain = await _unitOfWork.UserDomain.GetFirstOrDefault(ud => ud.Id == userDomainInput.Id);
				if (existingDomain == null)
				{
					response.IsSuccess = false;
					response.Message = "User domain application not found.";
					return response;
				}

				existingDomain.Status = userDomainInput.Status;

				if (userDomainInput.Status.Equals("Approved", StringComparison.OrdinalIgnoreCase))
				{
					existingDomain.ApprovedAt = DateTime.UtcNow;
				}
				else if (userDomainInput.Status.Equals("Rejected", StringComparison.OrdinalIgnoreCase))
				{
					existingDomain.RejectedAt = DateTime.UtcNow;
				}

				existingDomain.SetUpdated();

				await _unitOfWork.UserDomain.Update(existingDomain);

				response.Result = existingDomain.Adapt<Output>();
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
				var userDomains = await _unitOfWork.UserDomain.GetAll(PageSize: paginatedModel.PageSize, PageNumber: paginatedModel.PageNumber);
				response.Result = userDomains.Adapt<IEnumerable<Output>>();
				return response;
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseDto> GetByIdAsync(Guid userDomainId)
		{
			var response = new ResponseDto();
			try
			{
				var userDomain = await _unitOfWork.UserDomain.GetFirstOrDefault(ud => ud.Id == userDomainId);
				if (userDomain == null)
				{
					response.IsSuccess = false;
					response.Message = "User domain application not found.";
					return response;
				}
				response.Result = userDomain.Adapt<Output>();
				return response;
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
				return response;
			}
		}

		public async Task<ResponseDto> DeleteAsync(Guid userDomainId)
		{
			var response = new ResponseDto();
			try
			{
				var userDomain = await _unitOfWork.UserDomain.GetFirstOrDefault(ud => ud.Id == userDomainId);
				if (userDomain == null)
				{
					response.IsSuccess = false;
					response.Message = "User domain application not found.";
					return response;
				}

				await _unitOfWork.UserDomain.Remove(userDomain);
				response.Message = "User domain application deleted successfully.";
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
