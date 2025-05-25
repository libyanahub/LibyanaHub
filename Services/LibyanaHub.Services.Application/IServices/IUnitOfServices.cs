namespace LibyanaHub.Services.Application.IServices
{
	public interface IUnitOfServices
	{
		IKannelService KannelService { get; }
		IAuthService AuthService { get; }
		IJwtTokenGenerator JwtTokenGenerator { get; }

		
	}
}