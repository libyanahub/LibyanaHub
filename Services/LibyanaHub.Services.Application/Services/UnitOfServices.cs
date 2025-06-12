using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Domain.Entities.Identity;
using LibyanaHub.Services.Infrastructure.IRepository;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace LibyanaHub.Services.Application.Services
{
    public class UnitOfServices : IUnitOfServices
	{
		public IDbUnitOfWork DbUnitOfWork { get; set; }
		public IKannelService KannelService { get; set; }
		public IAuthService AuthService { get; set; }
		public IJwtTokenGenerator JwtTokenGenerator { get; set; }
		public ICourseService CourseService { get; set; }

		public UnitOfServices(
			IConfiguration config ,
			IDbUnitOfWork dbUnitOfWork ,
			IOptions<JwtOptions> jwtOptions,
			UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole<Guid>> roleManager)
		{
			AuthService = new AuthService(dbUnitOfWork, JwtTokenGenerator, userManager, roleManager);

			JwtTokenGenerator = new JwtTokenGenerator(jwtOptions);
			
			KannelService = new KannelService(config , this);

			CourseService = new CourseService(dbUnitOfWork, this);
		}
	}
}
