namespace LibyanaHub.Services.Application.IServices
{
	public interface IUnitOfServices
	{		
		IAuthService AuthService { get; }
		
		IJwtTokenGenerator JwtTokenGenerator { get; }
		
		IKannelService KannelService { get; }

		ICourseService CourseService { get; }
	}
}