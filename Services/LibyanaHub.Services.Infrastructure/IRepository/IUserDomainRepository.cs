using LibyanaHub.Services.Domain.Entities;


namespace LibyanaHub.Services.Infrastructure.IRepository
{
	public interface IUserDomainRepository : IRepository<UserDomain>
	{
		public Task Update(UserDomain userDomain);
	}
}
