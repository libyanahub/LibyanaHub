using LibyanaHub.Services.Domain.Entities.Identity;
using LibyanaHub.Services.Infrastructure.Data;
using LibyanaHub.Services.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.Infrastructure.Repository
{
	public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
	{
		private readonly AppDbContext _dbContext;
		public ApplicationUserRepository(AppDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void Update(ApplicationUser applicationUser)
		{
			_dbContext.ApplicationUsers.Update(applicationUser);
		}
	}
}