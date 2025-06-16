using LibyanaHub.Services.Application.IServices;

namespace LibyanaHub.Services.Application.IServices
{
	public interface IUnitOfServices
	{		
		IAuthService AuthService { get; }
		
		IJwtTokenGenerator JwtTokenGenerator { get; }
		
		IKannelService KannelService { get; }

		ICourseService CourseService { get; }

		IFitnessCategoryService FitnessCategoryService { get; }

		ITraineeService TraineeService { get; }


		IUserDomainService UserDomainService { get; }


		ICoachService CoachService { get; }

	}
}