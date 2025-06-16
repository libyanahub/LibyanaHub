using LibyanaHub.Services.Domain.Entities;
using LibyanaHub.Services.Infrastructure.Data;
using LibyanaHub.Services.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;


namespace LibyanaHub.Services.Infrastructure.Repository
{
	public class UserDomainRepository : Repository<UserDomain>, IUserDomainRepository
	{
		private readonly AppDbContext _dbContext;

		public UserDomainRepository(AppDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Update(UserDomain userDomain)
		{
			if (userDomain == null)
			{
				throw new ArgumentNullException(nameof(userDomain));
			}

			var existingUserDomain = await _dbContext.UserDomains.FirstOrDefaultAsync(ud => ud.Id == userDomain.Id);
			if (existingUserDomain != null)
			{
				// Update properties related to the application status
				existingUserDomain.Status = userDomain.Status;
				existingUserDomain.ApprovedAt = userDomain.ApprovedAt;
				existingUserDomain.RejectedAt = userDomain.RejectedAt;

				_dbContext.UserDomains.Update(existingUserDomain);
				await _dbContext.SaveChangesAsync();
			}
		}
	}
}